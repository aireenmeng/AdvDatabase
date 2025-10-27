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
    public partial class NewTransactionForm : Form
    {
        // Constants and state flags
        private const decimal SALES_TAX_RATE = 0.08m;
        private bool isRefundMode = false;
        private int salesIdToResume = 0;
        private int loggedInEmployeeId;

        // Internal storage for available products (from DataService)
        private DataTable productLookupTable = new DataTable();

        // Constructor for a new sale/refund
        public NewTransactionForm(int employeeId)
        {
            InitializeComponent();
            loggedInEmployeeId = employeeId;
            SetupForm();
        }

        // Constructor for resuming a PENDING transaction
        public NewTransactionForm(int employeeId, int salesId)
        {
            InitializeComponent();
            loggedInEmployeeId = employeeId;
            salesIdToResume = salesId;
            SetupForm();
        }

        private void SetupForm()
        {
            // 1. Initialize data grid view columns
            SetupCartDataGridView();

            // 2. Set Transaction Date (Read-only)
            dtpTransactionDate.Value = DateTime.Now;
            dtpTransactionDate.Enabled = false;

            // 3. Load lookup data (products and discounts)
            LoadProductsForSearch();
            LoadDiscountTypes();

            // 4. Setup Transaction Type ComboBox and events
            cmbTransactionType.Items.AddRange(new object[] { "Sale", "Refund/Return" });
            cmbTransactionType.SelectedIndex = 0;
            cmbTransactionType.SelectedIndexChanged += CmbTransactionType_SelectedIndexChanged;

            // 5. Load Pending Data if resuming
            if (salesIdToResume > 0)
            {
                LoadPendingTransaction(salesIdToResume);
            }

            // 6. Event Wiring and Initial Calculations
            UpdateSummaryTotals();
            txtMoneyReceived.TextChanged += TxtMoneyReceived_TextChanged;
            cmbProductSearch.SelectedIndexChanged += CmbProductSearch_SelectedIndexChanged;

            // Initialize item price display
            lblItemPrice.Text = 0.00m.ToString("C2");

            // Wire up remaining action buttons (ensure these match your designer names)
            btnAddtoCart.Click += btnAddtoCart_Click;
            btnRemoveItem.Click += btnRemoveItem_Click;
            btnCompleteSale.Click += btnCompleteSale_Click;
            btnHoldTransaction.Click += btnHoldTransaction_Click;
            btnCancelTransaction.Click += btnCancelTransaction_Click;
        }

        private void SetupCartDataGridView()
        {
            // Define columns for the shopping cart grid
            dgvCartItems.ColumnCount = 6;
            dgvCartItems.Columns[0].Name = "ProductID";
            dgvCartItems.Columns[0].Visible = false;
            dgvCartItems.Columns[1].Name = "Product";
            dgvCartItems.Columns[2].Name = "Quantity";
            dgvCartItems.Columns[3].Name = "Unit Price";
            dgvCartItems.Columns[4].Name = "Discount %";
            dgvCartItems.Columns[5].Name = "Line Total";
            dgvCartItems.Dock = DockStyle.Fill;
        }

        // ---------------------------------------------------------------------------------------------------
        // 2. DATA LOADING AND LOOKUPS
        // ---------------------------------------------------------------------------------------------------

        private void LoadProductsForSearch()
        {
            // DISCONNECTED LOGIC: Get data from DataService instead of database
            productLookupTable = DataService.GetLookupData("PRODUCTS_FOR_POS");

            // Bind data for display and storage
            cmbProductSearch.DataSource = productLookupTable;
            cmbProductSearch.DisplayMember = "Name";
            cmbProductSearch.ValueMember = "Product_ID";

            // Setup auto-complete 
            AutoCompleteStringCollection productNames = new AutoCompleteStringCollection();
            foreach (DataRow row in productLookupTable.Rows)
            {
                productNames.Add(row["Name"].ToString());
            }
            cmbProductSearch.AutoCompleteCustomSource = productNames;
        }

        private void LoadDiscountTypes()
        {
            // Hardcoded discount options
            cmbItemDiscount.Items.AddRange(new object[] {
            "0%", "5% Promo", "10% Promo", "15% Employee", "20% Senior/PWD"
            });
            cmbItemDiscount.SelectedIndex = 0;
        }

        private void LoadPendingTransaction(int salesId)
        {
            // NOTE: Full logic requires fetching line items from SALES_ITEMS table via DataService

            MessageBox.Show($"[SIMULATION] Loading pending items for Sale ID: {salesId}. Items loaded into cart.", "Resuming Sale");

            // Sample data load: (In production, load actual items from DataService here)
            dgvCartItems.Rows.Add(1, "Paracetamol 500mg", 5, 1.50m.ToString("C2"), "0%", 7.50m.ToString("C2"));

            // Prevent changes to the sale type/hold status on resumed sales
            cmbTransactionType.SelectedItem = "Sale";
            cmbTransactionType.Enabled = false;
            btnHoldTransaction.Enabled = false;
        }

        // ---------------------------------------------------------------------------------------------------
        // 3. EVENT HANDLERS
        // ---------------------------------------------------------------------------------------------------


        private void CmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvCartItems.Rows.Count > 0 && MessageBox.Show("Switching mode will clear the current cart. Proceed?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                cmbTransactionType.SelectedItem = isRefundMode ? "Refund/Return" : "Sale";
                return;
            }

            isRefundMode = cmbTransactionType.SelectedItem.ToString() == "Refund/Return";

            // Visual updates for Refund mode
            if (isRefundMode)
            {
                lblTotalAmountDue.Text = "REFUND DUE:";
                lblTotalAmountDue.ForeColor = Color.Red;
                btnCompleteSale.Text = "PROCESS REFUND";
            }
            else
            {
                lblTotalAmountDue.Text = "TOTAL DUE:";
                lblTotalAmountDue.ForeColor = SystemColors.ControlText;
                btnCompleteSale.Text = "COMPLETE SALE";
            }

            dgvCartItems.Rows.Clear();
            UpdateSummaryTotals();
        }

        private void CmbProductSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Updates Item Price label when a product is selected
            if (cmbProductSearch.SelectedValue is int productId)
            {
                DataRow[] rows = productLookupTable.Select($"Product_ID = {productId}");
                if (rows.Length > 0 && rows[0]["Selling_Price"] != DBNull.Value)
                {
                    decimal price = Convert.ToDecimal(rows[0]["Selling_Price"]);
                    lblItemPrice.Text = price.ToString("C2");
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // 4. CART MANAGEMENT (ADD/REMOVE)
        // ---------------------------------------------------------------------------------------------------



        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            if (cmbProductSearch.SelectedValue == null || !int.TryParse(txtItemQuantity.Text, out int quantity) || quantity == 0)
            {
                MessageBox.Show("Please select a valid product and enter a non-zero quantity.");
                return;
            }

            int productId = (int)cmbProductSearch.SelectedValue;
            string productName = cmbProductSearch.Text;

            // Fetch original unit price
            DataRow[] rows = productLookupTable.Select($"Product_ID = {productId}");
            if (rows.Length == 0) return;
            decimal unitPrice = Convert.ToDecimal(rows[0]["Selling_Price"]);

            string discountText = cmbItemDiscount.Text;
            decimal discountRate = decimal.Parse(discountText.Split('%')[0].Trim()) / 100m;

            // Calculate Discount Before Tax
            decimal unitDiscountAmount = unitPrice * discountRate;
            decimal discountedUnitPrice = unitPrice - unitDiscountAmount;
            decimal lineTotal = discountedUnitPrice * Math.Abs(quantity);

            // --- Refund Logic Adjustment ---
            if (isRefundMode)
            {
                quantity = Math.Abs(quantity) * -1; // Force negative quantity
                lineTotal *= -1; // Force negative financial value
            }

            // Add item to DataGridView
            dgvCartItems.Rows.Add(productId, productName, quantity, unitPrice.ToString("C2"), discountText, lineTotal.ToString("C2"));

            txtItemQuantity.Clear();
            UpdateSummaryTotals();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count > 0)
            {
                dgvCartItems.Rows.RemoveAt(dgvCartItems.SelectedRows[0].Index);
                UpdateSummaryTotals();
            }
        }


        // ---------------------------------------------------------------------------------------------------
        // 5. FINANCIAL CALCULATION LOGIC
        // ---------------------------------------------------------------------------------------------------

        private void UpdateSummaryTotals()
        {
            decimal grossSubtotal = 0m;
            decimal totalDiscountAmount = 0m;
            decimal subtotalAfterDiscount = 0m;

            // Calculate totals by iterating through the cart
            foreach (DataGridViewRow row in dgvCartItems.Rows)
            {
                if (row.Cells["Line Total"].Value == null) continue;

                decimal unitPrice = decimal.Parse(row.Cells["Unit Price"].Value.ToString().Replace("₱", "").Replace("$", ""));
                int quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                string discountText = row.Cells["Discount %"].Value.ToString();
                decimal lineTotal = decimal.Parse(row.Cells["Line Total"].Value.ToString().Replace("₱", "").Replace("$", ""));

                // 1. Gross Subtotal (Original Price)
                grossSubtotal += unitPrice * Math.Abs(quantity);

                // 2. Discounted Subtotal (Used for final calculation)
                subtotalAfterDiscount += lineTotal;

                // 3. Total Discount Amount (For display)
                totalDiscountAmount += (unitPrice * Math.Abs(quantity)) - Math.Abs(lineTotal);
            }

            // Calculate tax on the discounted subtotal (Discount Before Tax Policy)
            decimal taxAmount = subtotalAfterDiscount * SALES_TAX_RATE;

            // Final Total
            decimal grandTotal = subtotalAfterDiscount + taxAmount;

            // Update Labels
            lblGrandSubtotal.Text = grossSubtotal.ToString("C2");
            lblTotalDiscount.Text = totalDiscountAmount.ToString("C2");
            lblTaxAmount.Text = taxAmount.ToString("C2");
            lblTotalAmountDue.Text = grandTotal.ToString("C2");

            // Recalculate change if money is received
            TxtMoneyReceived_TextChanged(null, null);
        }

        private void TxtMoneyReceived_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(lblTotalAmountDue.Text.Replace("₱", "").Replace("$", ""), out decimal totalDue) &&
                decimal.TryParse(txtMoneyReceived.Text, out decimal moneyReceived))
            {
                decimal change = moneyReceived - totalDue;
                lblChangeDue.Text = change.ToString("C2");
            }
            else
            {
                lblChangeDue.Text = "N/A";
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // 6. TRANSACTION FINALIZATION (Complete, Hold, Cancel)
        // ---------------------------------------------------------------------------------------------------


        private void btnCompleteSale_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.Rows.Count == 0) { MessageBox.Show("Cart is empty."); return; }

            // Basic payment validation
            if (!decimal.TryParse(lblChangeDue.Text.Replace("₱", "").Replace("$", ""), out decimal change) || change < 0)
            {
                MessageBox.Show("Payment is insufficient or invalid. Check Money Received.", "Payment Error");
                return;
            }

            string status = isRefundMode ? "Refunded" : "Completed";

            // Execute the DataService call instead of a DB connection
            DataService.ExecuteTransaction(status, (DataTable)dgvCartItems.DataSource, loggedInEmployeeId, salesIdToResume > 0 ? salesIdToResume : (int?)null);

            // Placeholder for successful transaction:
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHoldTransaction_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.Rows.Count == 0) { MessageBox.Show("Cart is empty."); return; }

            string status = "Pending";

            // Execute the DataService call instead of a DB connection
            DataService.ExecuteTransaction(status, (DataTable)dgvCartItems.DataSource, loggedInEmployeeId);

            MessageBox.Show("[SIMULATION] Transaction Saved! Status: Pending.", "Hold Success");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelTransaction_Click(object sender, EventArgs e)
        {
            // Status: None (No record saved)
            this.Close();
        }

        private void NewTransactionForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtMoneyReceived_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
