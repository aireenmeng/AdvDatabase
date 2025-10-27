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
        private DataTable fullSupplierData; // Stores the in-memory data
        public SuppliersUC()
        {
            InitializeComponent();

            // Wire up necessary events
            dgvSuppliersList.SelectionChanged += DgvSuppliersList_SelectionChanged;
            btnSearchSupplier.Click += btnSearchSupplier_Click;
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
            // CRITICAL FIX: Initialize the persistent data ONLY IF it hasn't been loaded yet.
            if (fullSupplierData == null)
            {
                fullSupplierData = DataService.GetData("SUPPLIERS").Copy();
            }

            DataTable dt = fullSupplierData; // Use the persistent class field for filtering

            // Apply search filter in-memory using DataView.RowFilter
            if (!string.IsNullOrEmpty(searchTerm))
            {
                string filter = $"Name LIKE '%{searchTerm}%' OR Contact_Info LIKE '%{searchTerm}%'";
                dt.DefaultView.RowFilter = filter;
            }
            else
            {
                // FIX: This section is safe now because dt (fullSupplierData) is guaranteed not to be null.
                dt.DefaultView.RowFilter = string.Empty;
            }

            // Bind the existing filtered DataTable (dt.DefaultView)
            dgvSuppliersList.DataSource = dt.DefaultView;
            dgvSuppliersList.Columns["Supplier_ID"].Visible = false;
            dgvSuppliersList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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

            // --- DISCONNECTED MOCK LOGIC ---
            // Simulates adding a new row to the in-memory DataTable
            DataTable dt = dgvSuppliersList.DataSource as DataTable;
            DataRow newRow = dt.NewRow();

            // Generate mock ID
            int newId = dt.AsEnumerable().Max(row => row.Field<int>("Supplier_ID")) + 1;

            newRow["Supplier_ID"] = newId;
            newRow["Name"] = txtSupplierName.Text.Trim();
            newRow["Contact_Info"] = GetCombinedContactInfo();

            dt.Rows.Add(newRow);
            dt.AcceptChanges(); // Commit the change to the in-memory data

            MessageBox.Show("Supplier added successfully (Simulated)!", "Success");
            btnClearSupplierFields_Click(null, null);
            LoadSuppliersData();
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            if (selectedSupplierId == 0) { MessageBox.Show("Please select a supplier to update.", "Error"); return; }

            // --- DISCONNECTED MOCK LOGIC ---
            DataTable dt = dgvSuppliersList.DataSource as DataTable;
            DataRow rowToUpdate = dt.AsEnumerable().FirstOrDefault(r => r.Field<int>("Supplier_ID") == selectedSupplierId);

            if (rowToUpdate != null)
            {
                rowToUpdate["Name"] = txtSupplierName.Text.Trim();
                rowToUpdate["Contact_Info"] = GetCombinedContactInfo();

                dt.AcceptChanges();
                MessageBox.Show("Supplier updated successfully (Simulated)!", "Success");
                btnClearSupplierFields_Click(null, null);
                LoadSuppliersData();
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (selectedSupplierId == 0) { MessageBox.Show("Please select a supplier to delete.", "Error"); return; }
            if (MessageBox.Show("Are you sure you want to delete this supplier? (Simulated)", "Confirm Delete",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            // --- DISCONNECTED MOCK LOGIC ---
            DataTable dt = dgvSuppliersList.DataSource as DataTable;
            DataRow rowToDelete = dt.AsEnumerable().FirstOrDefault(r => r.Field<int>("Supplier_ID") == selectedSupplierId);

            if (rowToDelete != null)
            {
                rowToDelete.Delete();
                dt.AcceptChanges();

                MessageBox.Show("Supplier deleted successfully (Simulated)!", "Success");
                btnClearSupplierFields_Click(null, null);
                LoadSuppliersData();
            }
        }

        private void SuppliersUC_Load(object sender, EventArgs e)
        {
            LoadSuppliersData();
        }
    }
}
