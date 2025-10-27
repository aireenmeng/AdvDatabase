using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvDatabase
{
    public partial class HomeForm : Form
    {
        // Stores the user's details received from the LoginForm
        private int loggedInEmployeeId;
        private string loggedInEmployeeName;
        private string loggedInUserPosition;

        public HomeForm(int employeeId, string employeeName, string position)
        {
            InitializeComponent();

            // Store the details
            loggedInEmployeeId = employeeId;
            loggedInEmployeeName = employeeName;
            loggedInUserPosition = position;

            // Update the UI label in the sidebar
            lblAdminRole.Text = position.ToUpper();

            // Apply permissions based on the user's role
            ApplyRolePermissions(position);

            // Load the initial view (Dashboard)
            btnDashboard.PerformClick();
        }

        // -------------------------------------------------------------------------
        // ROLE-BASED ACCESS CONTROL (RBAC)
        // -------------------------------------------------------------------------
        private void ApplyRolePermissions(string position)
        {
            // Hide Inventory and Suppliers for 'Cashier' role
            if (position.Equals("Cashier", StringComparison.OrdinalIgnoreCase))
            {
                btnInventory.Visible = false;
                btnSuppliers.Visible = false;
            }
        }

        // -------------------------------------------------------------------------
        // USER CONTROL LOADING UTILITY
        // -------------------------------------------------------------------------
        private void LoadUserControl(UserControl uc)
        {
            // Clear any previous controls in the main panel
            panelMainContent.Controls.Clear();

            // Configure the new User Control
            uc.Dock = DockStyle.Fill;

            // Add the new User Control to the panel
            panelMainContent.Controls.Add(uc);
        }

        // -------------------------------------------------------------------------
        // SIDEBAR NAVIGATION IMPLEMENTATION
        // -------------------------------------------------------------------------

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            DashboardUC dashboard = new DashboardUC();
            LoadUserControl(dashboard);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            // Note: We should pass the Employee ID to the TransactionsUC for auditing
            TransactionsUC transactions = new TransactionsUC(loggedInEmployeeId);
            LoadUserControl(transactions);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            // Simple permission check before loading, though buttons are hidden for Cashiers
            if (!loggedInUserPosition.Equals("Admin", StringComparison.OrdinalIgnoreCase) &&
                !loggedInUserPosition.Equals("Manager", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Access Denied.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            InventoryUC inventory = new InventoryUC();
            LoadUserControl(inventory);
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            // Simple permission check before loading, though buttons are hidden for Cashiers
            if (!loggedInUserPosition.Equals("Admin", StringComparison.OrdinalIgnoreCase) &&
                !loggedInUserPosition.Equals("Manager", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Access Denied.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SuppliersUC suppliers = new SuppliersUC();
            LoadUserControl(suppliers);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Confirms logout and returns to the login screen
            if (MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }


        // -------------------------------------------------------------------------
        // DASHBOARD NAVIGATION AND FILTERING LOGIC (Public Method)
        // -------------------------------------------------------------------------

        /// <summary>
        /// Handles navigation and filtering when a Dashboard metric is clicked.
        /// </summary>
        /// <param name="filterType">The name of the label clicked (e.g., lblExpiredItemsCount).</param>
        public void NavigateAndFilter(string filterType)
        {
            if (filterType.Contains("Sale"))
            {
                // Go to Transactions
                btnTransactions.PerformClick();

                // Example of how to call the filter method on the currently loaded UC:
                if (panelMainContent.Controls.Count > 0 && panelMainContent.Controls[0] is TransactionsUC transactionsUc)
                {
                    transactionsUc.ApplyDashboardFilter("TodaySale");
                }
            }
            else // Inventory related metrics
            {
                // Re-check permission before proceeding to Inventory (safety check)
                if (loggedInUserPosition.Equals("Cashier", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Access Denied. Only Managers and Admins can view Inventory.", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Go to Inventory
                btnInventory.PerformClick();

                if (panelMainContent.Controls.Count > 0 && panelMainContent.Controls[0] is InventoryUC inventoryUc)
                {
                    if (filterType.Contains("Expired"))
                    {
                        inventoryUc.ApplyDashboardFilter("Expired");
                    }
                    else if (filterType.Contains("LowStock"))
                    {
                        inventoryUc.ApplyDashboardFilter("LowStock");
                    }
                }
            }
        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

        }
    }
}