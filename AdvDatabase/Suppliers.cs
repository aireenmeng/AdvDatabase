using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AdvDatabase
{
    public partial class SuppliersUC : UserControl
    {
        private int selectedSupplierId = 0;
        public SuppliersUC()
        {
            InitializeComponent();
            // Wire up necessary events
            dgvSuppliersList.SelectionChanged += DgvSuppliersList_SelectionChanged;
            btnSearchSupplier.Click += btnSearchSupplier_Click;

            // Wire up CRUD buttons
            btnAddSupplier.Click += btnAddSupplier_Click;
            btnUpdateSupplier.Click += btnUpdateSupplier_Click;
            btnDeleteSupplier.Click += btnDeleteSupplier_Click;
            btnClearSupplierFields.Click += btnClearSupplierFields_Click;
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            LoadSuppliersData();
        }

        // -------------------------------------------------------------------------
        // DATA LOADING AND DISPLAY
        // -------------------------------------------------------------------------

        private void LoadSuppliersData(string searchTerm = "")
        {
            string query = @"
                SELECT 
                    Supplier_ID, 
                    Name, 
                    Contact_Info
                FROM 
                    SUPPLIERS
                ";

            // Add WHERE clause if a search term is provided
            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Search by Supplier Name or Contact Info
                query += " WHERE Name LIKE @searchTerm OR Contact_Info LIKE @searchTerm";
            }

            query += " ORDER BY Name;";

            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                if (conn == null) return;

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        // Parameterized query for safe searching
                        adapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                    }

                    DataTable dt = new DataTable();
                    try
                    {
                        adapter.Fill(dt);
                        dgvSuppliersList.DataSource = dt;
                        dgvSuppliersList.Columns["Supplier_ID"].Visible = false;
                        dgvSuppliersList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error loading supplier data: " + ex.Message, "Database Error");
                    }
                }
            }
        }

        // Handles filling the input fields when a row is selected
        private void DgvSuppliersList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSuppliersList.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvSuppliersList.SelectedRows[0];

                selectedSupplierId = Convert.ToInt32(row.Cells["Supplier_ID"].Value);
                txtSupplierName.Text = row.Cells["Name"].Value.ToString();

                // Clear contact fields as we don't parse the single DB string back out automatically
                txtContactNo.Clear();
                txtContactEmail.Clear();
            }
            else
            {
                // Clear fields if selection is lost
                btnClearSupplierFields_Click(null, null);
            }
        }

        // -------------------------------------------------------------------------
        // SEARCH AND CLEAR
        // -------------------------------------------------------------------------

        private void btnSearchSupplier_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSupplierSearch.Text.Trim();
            LoadSuppliersData(searchTerm);
        }

        private void btnClearSupplierFields_Click(object sender, EventArgs e)
        {
            txtSupplierName.Clear();
            txtContactNo.Clear();
            txtContactEmail.Clear();
            selectedSupplierId = 0;
            txtSupplierSearch.Clear();
            LoadSuppliersData(); // Reset search filter and reload
        }

        // -------------------------------------------------------------------------
        // CRUD OPERATIONS
        // -------------------------------------------------------------------------

        // Helper method to combine UI fields into the single DB field (Contact_Info)
        private string GetCombinedContactInfo()
        {
            string phone = string.IsNullOrWhiteSpace(txtContactNo.Text) ? "N/A" : txtContactNo.Text.Trim();
            string email = string.IsNullOrWhiteSpace(txtContactEmail.Text) ? "N/A" : txtContactEmail.Text.Trim();
            return $"Phone: {phone} | Email: {email}";
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("Supplier Name is required.", "Validation Error");
                return;
            }

            string query = "INSERT INTO SUPPLIERS (Name, Contact_Info) VALUES (@Name, @ContactInfo);";

            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                if (conn == null) return;
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", txtSupplierName.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactInfo", GetCombinedContactInfo());

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Supplier added successfully!", "Success");
                        btnClearSupplierFields_Click(null, null);
                        LoadSuppliersData();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error adding supplier: " + ex.Message, "Database Error");
                    }
                }
            }
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            if (selectedSupplierId == 0)
            {
                MessageBox.Show("Please select a supplier to update.", "Error");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("Supplier Name is required.", "Validation Error");
                return;
            }

            string query = "UPDATE SUPPLIERS SET Name = @Name, Contact_Info = @ContactInfo WHERE Supplier_ID = @ID;";

            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                if (conn == null) return;
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", txtSupplierName.Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactInfo", GetCombinedContactInfo());
                    cmd.Parameters.AddWithValue("@ID", selectedSupplierId);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Supplier updated successfully!", "Success");
                        btnClearSupplierFields_Click(null, null);
                        LoadSuppliersData();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error updating supplier: " + ex.Message, "Database Error");
                    }
                }
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (selectedSupplierId == 0)
            {
                MessageBox.Show("Please select a supplier to delete.", "Error");
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this supplier? This may affect existing products/orders.",
                                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            string query = "DELETE FROM SUPPLIERS WHERE Supplier_ID = @ID;";

            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                if (conn == null) return;
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", selectedSupplierId);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Supplier deleted successfully!", "Success");
                        }
                        else
                        {
                            MessageBox.Show("Supplier not found or delete failed.", "Error");
                        }
                        btnClearSupplierFields_Click(null, null);
                        LoadSuppliersData();
                    }
                    catch (MySqlException ex)
                    {
                        // Catch FK violation (Error number 1451 is common for MySQL FK constraint failure)
                        if (ex.Number == 1451)
                        {
                            MessageBox.Show("Cannot delete supplier: Products or Purchase Orders currently depend on this record.", "Integrity Error");
                        }
                        else
                        {
                            MessageBox.Show("Error deleting supplier: " + ex.Message, "Database Error");
                        }
                    }
                }
            }
        }
    }
}
