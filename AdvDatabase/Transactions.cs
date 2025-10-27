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
    public partial class TransactionsUC : UserControl
    {
        private int loggedInEmployeeId;
        private string initialFilter = "";
        private DataTable fullSalesData;

        // NEW CONSTRUCTOR: Receives Employee ID from HomeForm for auditing
        public TransactionsUC(int employeeId)
        {
            InitializeComponent();
            this.loggedInEmployeeId = employeeId;
            // Wire up the search button here (or in Load, but here is cleaner for events)
        }

        // Default constructor is also needed for Visual Studio Designer
        public TransactionsUC()
        {
            InitializeComponent();
            // Default ID 1 for design view, will be overwritten by parameterized constructor
            this.loggedInEmployeeId = 1;
        }

        // Public method called by HomeForm.NavigateAndFilter (for 'Today's Sale' click)
        public void ApplyDashboardFilter(string filterType)
        {
            if (filterType == "TodaySale")
            {
                this.initialFilter = "Today";
            }
        }

        private void TransactionsUC_Load(object sender, EventArgs e)
        {
            PopulateFilters();
            LoadTransactionHistory();

            // Apply the initial filter if set by the Dashboard
            if (!string.IsNullOrEmpty(initialFilter))
            {
                if (initialFilter == "Today")
                {
                    cmbTimeFilter.SelectedItem = "Today";
                    ApplyFilters();
                }
            }

            // Wire up the filter events after loading data
            cmbStatusFilter.SelectedIndexChanged += CmbFilters_SelectedIndexChanged;
            cmbTimeFilter.SelectedIndexChanged += CmbFilters_SelectedIndexChanged;
            btnSearchTransaction.Click += btnSearchTransaction_Click; // Assuming search button is wired up
        }

        // ---------------------------------------------------------------------------------------------------
        // 2. DATA LOADING AND FILTER POPULATION
        // ---------------------------------------------------------------------------------------------------

        private void PopulateFilters()
        {
            cmbStatusFilter.Items.AddRange(new object[] { "All Statuses", "Completed", "Refunded", "Pending", "Voided" });
            cmbStatusFilter.SelectedIndex = 0;

            cmbTimeFilter.Items.AddRange(new object[] { "All Time", "Today", "Yesterday", "Last 7 Days", "Last 30 Days" });
            cmbTimeFilter.SelectedIndex = 0;
        }

        private void LoadTransactionHistory()
        {
            // DISCONNECTED LOGIC: Replaces complex MySQL code with DataService call
            fullSalesData = DataService.GetData("SALES");
            dgvTransactionHistory.DataSource = fullSalesData;

            // NOTE: We don't need a complex query string here; the logic is encapsulated in DataService/DummyData

            // Formatting and resizing remain the same
            dgvTransactionHistory.Columns["Total_Amount"].DefaultCellStyle.Format = "C2";
            dgvTransactionHistory.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        // ---------------------------------------------------------------------------------------------------
        // 3. FILTERING AND SEARCH LOGIC
        // ---------------------------------------------------------------------------------------------------

        private void CmbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnSearchTransaction_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            // The filtering remains an in-memory operation using DataView.RowFilter
            DataTable dt = dgvTransactionHistory.DataSource as DataTable;
            if (dt == null) return;

            // ... (RowFilter logic remains the same as previously reviewed) ...
            string finalFilter = "";

            // --- 1. Status Filter ---
            if (cmbStatusFilter.SelectedIndex > 0)
            {
                finalFilter = $"Status = '{cmbStatusFilter.SelectedItem.ToString()}'";
            }

            // --- 2. Time/Range Filter ---
            string dateFilter = GetDateRangeFilter(cmbTimeFilter.SelectedItem.ToString());
            if (!string.IsNullOrEmpty(dateFilter))
            {
                if (!string.IsNullOrEmpty(finalFilter)) finalFilter += " AND ";
                finalFilter += dateFilter;
            }

            // --- 3. Text Search Filter ---
            string searchTerm = txtTransactionSearch.Text.Trim().Replace("'", "''");
            if (!string.IsNullOrEmpty(searchTerm))
            {
                string searchFilter = $"Sales_ID = '{searchTerm}' OR Cashier_Name LIKE '%{searchTerm}%'";
                if (!string.IsNullOrEmpty(finalFilter)) finalFilter += " AND ";
                finalFilter += searchFilter;
            }

            dt.DefaultView.RowFilter = finalFilter;
        }

        private string GetDateRangeFilter(string selectedRange)
        {
            string filter = "";
            string today = DateTime.Today.ToString("yyyy-MM-dd");

            if (selectedRange == "Today")
                filter = $"Sales_Date >= '{today}'";
            else if (selectedRange == "Yesterday")
                filter = $"Sales_Date >= '{DateTime.Today.AddDays(-1):yyyy-MM-dd}' AND Sales_Date < '{today}'";
            else if (selectedRange == "Last 7 Days")
                filter = $"Sales_Date >= '{DateTime.Today.AddDays(-7):yyyy-MM-dd}'";
            else if (selectedRange == "Last 30 Days")
                filter = $"Sales_Date >= '{DateTime.Today.AddDays(-30):yyyy-MM-dd}'";

            return filter;
        }
        // ---------------------------------------------------------------------------------------------------
        // 4. ACTION BUTTONS (Launching the POS Form)
        // ---------------------------------------------------------------------------------------------------


        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            // Launch the New Transaction Form (POS) in default 'Sale' mode (no ID passed)
            NewTransactionForm posForm = new NewTransactionForm(loggedInEmployeeId); // Pass employee ID
            posForm.ShowDialog();

            // Reload history after the POS form is closed to show the new sale/refund/hold
            LoadTransactionHistory();
        }

        private void btnResumeTransaction_Click(object sender, EventArgs e)
        {
            if (dgvTransactionHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to resume.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string status = dgvTransactionHistory.SelectedRows[0].Cells["Status"].Value.ToString();

            if (status.Equals("Pending", StringComparison.OrdinalIgnoreCase))
            {
                int salesId = Convert.ToInt32(dgvTransactionHistory.SelectedRows[0].Cells["Sales_ID"].Value);

                // Launch the New Transaction Form (POS) and pass the Sales_ID to load the pending cart
                NewTransactionForm posForm = new NewTransactionForm(loggedInEmployeeId, salesId);
                posForm.ShowDialog();

                // Reload history after resume attempt
                LoadTransactionHistory();
            }
            else
            {
                MessageBox.Show("Only transactions with 'Pending' status can be resumed.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoidTransaction_Click(object sender, EventArgs e)
        {
            if (dgvTransactionHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a COMPLETED sale to void.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string status = dgvTransactionHistory.SelectedRows[0].Cells["Status"].Value.ToString();
            int salesId = Convert.ToInt32(dgvTransactionHistory.SelectedRows[0].Cells["Sales_ID"].Value);

            if (status.Equals("Completed", StringComparison.OrdinalIgnoreCase) || status.Equals("Refunded", StringComparison.OrdinalIgnoreCase))
            {
                // Prompt for a void reason (requires a new small input form)
                string reason = PromptForVoidReason();

                if (!string.IsNullOrEmpty(reason))
                {
                    // Execute the complex void/reverse inventory logic
                    // Placeholder: We would call a method in DbHelper here to perform a transaction
                    MessageBox.Show($"Executing Void Logic for Sale ID {salesId}. Reason: {reason}. Stock must be reversed and VOIDS table updated.", "Voiding in Progress");
                    // After successful void:
                    LoadTransactionHistory();
                }
            }
            else
            {
                MessageBox.Show("Only 'Completed' or 'Refunded' sales can be voided for audit purposes.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Placeholder method for getting void reason
        private string PromptForVoidReason()
        {
            // *** REMOVED: Microsoft.VisualBasic.Interaction.InputBox ***

            // Instead, you should create a dedicated small WinForm for secure input.
            // OR, for a quick temporary fix (requires you to handle the input on your own custom dialog):
            // For now, let's just confirm the action until the custom dialog is built:

            if (MessageBox.Show("Are you sure you want to proceed with the Void? A reason will be logged.", "Confirm Void", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Replace this with a call to your custom input form later
                return "Reason entered via placeholder/debug.";
            }
            return string.Empty; // Return empty string if canceled
        }
    }
}
