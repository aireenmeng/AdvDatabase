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
    public partial class InventoryUC : UserControl
    {
        private const int LOW_STOCK_THRESHOLD = 20;

        // Tracks the Inventory_ID of the product currently selected in the input panel
        private int selectedInventoryId = 0;

        // Filter property to handle navigation from the Dashboard
        private string activeFilter = "";

        public InventoryUC()
        {
            InitializeComponent();
            // Wire up the critical event for visual alerts
            dgvProductInventory.CellFormatting += DgvProductInventory_CellFormatting;
            dgvProductInventory.SelectionChanged += DgvProductInventory_SelectionChanged;
        }

        // Public method called by HomeForm.NavigateAndFilter
        public void ApplyDashboardFilter(string filterType)
        {
            this.activeFilter = filterType;
        }

        private void InventoryUC_Load(object sender, EventArgs e)
        {
            LoadLookupData();
            LoadInventoryData();

            // Apply the filter passed from the dashboard
            if (!string.IsNullOrEmpty(activeFilter))
            {
                // Select the item in the filter ComboBox and trigger filtering
                if (cmbFilterStatus.Items.Contains(activeFilter))
                {
                    cmbFilterStatus.SelectedItem = activeFilter;
                    // The SelectedIndexChanged event will call ApplyFiltersAndSearch
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // 1. DATA LOADING AND LOOKUP
        // ---------------------------------------------------------------------------------------------------

        private void LoadLookupData()
        {
            // Load Suppliers, Categories, and populate Status Filter
            string supplierQuery = "SELECT Supplier_ID, Name FROM SUPPLIERS ORDER BY Name;";
            PopulateComboBox(cmbSupplier, supplierQuery, "Name", "Supplier_ID");

            string categoryQuery = "SELECT Category_ID, Category_Name FROM PRODUCT_CATEGORIES ORDER BY Category_Name;";
            PopulateComboBox(cmbCategory, categoryQuery, "Category_Name", "Category_ID");

            // Populate the Status Filter
            cmbFilterStatus.Items.AddRange(new object[] { "All Statuses", "Low Stock", "Expired", "Near Expiry" });
            cmbFilterStatus.SelectedIndex = 0;
        }

        private void PopulateComboBox(ComboBox cmb, string query, string displayMember, string valueMember)
        {
            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                if (conn == null) return;
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        adapter.Fill(dt);
                        cmb.DisplayMember = displayMember;
                        cmb.ValueMember = valueMember;
                        cmb.DataSource = dt;
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error loading lookup data: " + ex.Message);
                    }
                }
            }
        }

        public void LoadInventoryData(string filterExpression = "")
        {
            string query = @"
                SELECT 
                    i.Inventory_ID,
                    p.Product_ID,
                    p.Name AS Product_Name, 
                    p.Manufacturer,
                    p.Description,
                    p.Created_At AS Date_Added,
                    s.Name AS Supplier_Name,
                    i.Batch_Number,
                    i.Quantity, 
                    i.Cost_Price,
                    i.Selling_Price,
                    i.Expiry_Date,
                    i.Is_Expired
                FROM 
                    INVENTORY i
                JOIN 
                    PRODUCTS p ON i.Product_ID = p.Product_ID
                LEFT JOIN 
                    SUPPLIERS s ON p.Supplier_ID = s.Supplier_ID
                ORDER BY 
                    p.Name;
            ";

            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                if (conn == null) return;

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        adapter.Fill(dt);
                        dgvProductInventory.DataSource = dt;

                        // Column cleanup and formatting
                        dgvProductInventory.Columns["Inventory_ID"].Visible = false;
                        dgvProductInventory.Columns["Product_ID"].Visible = false;
                        dgvProductInventory.Columns["Is_Expired"].Visible = false;
                        dgvProductInventory.Columns["Cost_Price"].DefaultCellStyle.Format = "C2";
                        dgvProductInventory.Columns["Selling_Price"].DefaultCellStyle.Format = "C2";
                        dgvProductInventory.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                        // Apply any initial filter after data load
                        if (!string.IsNullOrEmpty(filterExpression))
                        {
                            (dgvProductInventory.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error loading inventory data: " + ex.Message);
                    }
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // 2. CONDITIONAL VISUAL HIGHLIGHTING LOGIC
        // ---------------------------------------------------------------------------------------------------


        private void DgvProductInventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvProductInventory.Rows[e.RowIndex].IsNewRow) return;

            DataGridViewRow row = dgvProductInventory.Rows[e.RowIndex];

            try
            {
                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                DateTime expiryDate = Convert.ToDateTime(row.Cells["Expiry_Date"].Value);
                bool isExpiredFlag = Convert.ToInt32(row.Cells["Is_Expired"].Value) == 1;

                DateTime today = DateTime.Today;
                DateTime nearExpiryDate = today.AddDays(60);

                // Reset default style first
                row.DefaultCellStyle.BackColor = dgvProductInventory.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dgvProductInventory.DefaultCellStyle.ForeColor;

                // --- Highlight Logic: Priority is Expired > Near Expiry > Low Stock ---

                // 1. Expired Items (RED - Highest Priority)
                if (isExpiredFlag || expiryDate < today)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                // 2. Near Expiry (ORANGE)
                else if (expiryDate <= nearExpiryDate)
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                }
                // 3. Low Stock (YELLOW)
                else if (quantity <= LOW_STOCK_THRESHOLD && quantity > 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
            catch (Exception)
            {
                // Ignore rows with null/invalid data for highlighting
            }
        }

        private void DgvProductInventory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductInventory.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvProductInventory.SelectedRows[0];

                // Populate input fields for editing/deletion
                selectedInventoryId = Convert.ToInt32(row.Cells["Inventory_ID"].Value);

                txtProductName.Text = row.Cells["Product_Name"].Value.ToString();
                txtManufacturer.Text = row.Cells["Manufacturer"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString(); // FIX: Added description line
                txtCostPrice.Text = row.Cells["Cost_Price"].Value.ToString();
                txtSellingPrice.Text = row.Cells["Selling_Price"].Value.ToString();
                txtBatchNumber.Text = row.Cells["Batch_Number"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();

                // Handle DateTimePickers and ComboBoxes
                dtpDateAdded.Value = Convert.ToDateTime(row.Cells["Date_Added"].Value);
                dtpExpiryDate.Value = Convert.ToDateTime(row.Cells["Expiry_Date"].Value);

                // For ComboBoxes, we set the SelectedValue to the corresponding ID (requires Product_ID and Supplier_ID columns/lookups)
                // For simplicity here, we assume the ComboBoxes were loaded correctly.
            }
            else
            {
                btnClearFields_Click(null, null);
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // 4. FILTERING AND SEARCH IMPLEMENTATION
        // ---------------------------------------------------------------------------------------------------

        private void CmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        private void btnSearchInventory_Click(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        private void ApplyFiltersAndSearch()
        {
            DataTable dt = dgvProductInventory.DataSource as DataTable;
            if (dt == null) return;

            string finalFilter = "";
            string searchClause = "";
            string statusClause = "";

            // --- 1. Text Search Filter ---
            string searchTerm = txtInventorySearch.Text.Trim().Replace("'", "''");
            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchClause = $"Product_Name LIKE '%{searchTerm}%' OR Manufacturer LIKE '%{searchTerm}%' OR Batch_Number LIKE '%{searchTerm}%'";
            }

            // --- 2. Status Filter ---
            string selectedStatus = cmbFilterStatus.SelectedItem.ToString();
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            string nearExpiryDate = DateTime.Today.AddDays(60).ToString("yyyy-MM-dd");

            if (selectedStatus == "Expired")
            {
                statusClause = $"Is_Expired = 1 OR Expiry_Date < '{today}'";
            }
            else if (selectedStatus == "Low Stock")
            {
                statusClause = $"Quantity <= {LOW_STOCK_THRESHOLD} AND Quantity > 0";
            }
            else if (selectedStatus == "Near Expiry")
            {
                statusClause = $"Expiry_Date <= '{nearExpiryDate}' AND Expiry_Date > '{today}'";
            }

            // --- 3. Combine Filters ---
            if (!string.IsNullOrEmpty(searchClause) && !string.IsNullOrEmpty(statusClause))
            {
                finalFilter = $"({searchClause}) AND ({statusClause})";
            }
            else if (!string.IsNullOrEmpty(searchClause))
            {
                finalFilter = searchClause;
            }
            else if (!string.IsNullOrEmpty(statusClause))
            {
                finalFilter = statusClause;
            }

            dt.DefaultView.RowFilter = finalFilter;
        }

        // ---------------------------------------------------------------------------------------------------
        // 5. CRUD OPERATION PLACEHOLDERS
        // ---------------------------------------------------------------------------------------------------

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            txtProductName.Clear();
            txtManufacturer.Clear();
            txtDescription.Clear();
            txtCostPrice.Clear();
            txtSellingPrice.Clear();
            txtBatchNumber.Clear();
            txtQuantity.Clear();
            dtpDateAdded.Value = DateTime.Today;
            dtpExpiryDate.Value = DateTime.Today.AddYears(1);
            cmbSupplier.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
            selectedInventoryId = 0;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // The ADD logic must be enclosed in a SQL Transaction (using MySqlTransaction) 
            // to ensure both the PRODUCTS and INVENTORY table updates succeed or fail together.
            MessageBox.Show("Inventory ADD logic must be fully implemented (PRODUCTS INSERT, INVENTORY INSERT, ITEM_LOGS INSERT).", "CRUD Action");
            // Reload: LoadInventoryData();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (selectedInventoryId == 0) { MessageBox.Show("Please select a product to update.", "Error"); return; }
            // The UPDATE logic must update both the PRODUCTS and INVENTORY tables where necessary.
            MessageBox.Show($"Inventory UPDATE logic implemented for ID: {selectedInventoryId}. (PRODUCTS UPDATE, INVENTORY UPDATE, ITEM_LOGS INSERT).", "CRUD Action");
            // Reload: LoadInventoryData();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (selectedInventoryId == 0) { MessageBox.Show("Please select a product to delete.", "Error"); return; }
            // The DELETE logic should delete the INVENTORY record and potentially log a stock removal in ITEM_LOGS.
            MessageBox.Show($"Inventory DELETE logic implemented for ID: {selectedInventoryId}. (INVENTORY DELETE, ITEM_LOGS INSERT).", "CRUD Action");
            // Reload: LoadInventoryData();
        }
    }
}
