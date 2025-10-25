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

    public partial class DashboardUC : UserControl
    {

        // Define the Low Stock Threshold (must match InventoryUC)
        private const int LOW_STOCK_THRESHOLD = 20;

        public DashboardUC()
        {
            InitializeComponent();
        }

        private void DashboardUC_Load(object sender, EventArgs e)
        {
            // Execute all data fetching methods when the control becomes visible
            LoadMetrics();
            LoadRecentTransactions();
            LoadProactiveAlerts();

            // Wire up the metric labels to handle the click navigation
            WireUpMetricLabels();
        }

        private void WireUpMetricLabels()
        {
            // Add a single click handler to all metric labels for navigation
            lblTodaySaleValue.Click += MetricLabel_Click;
            lblTotalProductsCount.Click += MetricLabel_Click;
            lblExpiredItemsCount.Click += MetricLabel_Click;
            lblLowStockCount.Click += MetricLabel_Click;
        }

        // ---------------------------------------------------------------------------------------------------
        // 2. DATA LOADING LOGIC
        // ---------------------------------------------------------------------------------------------------

        private void LoadMetrics()
        {
            // Fetches all four metrics in one efficient database trip
            string query = $@"
            SELECT 
                (SELECT IFNULL(SUM(Total_Amount), 0) FROM SALES WHERE DATE(Sales_Date) = CURDATE() AND Status = 'Completed') AS TodaySale,
                (SELECT COUNT(DISTINCT Product_ID) FROM PRODUCTS) AS TotalProducts,
                (SELECT COUNT(Inventory_ID) FROM INVENTORY WHERE Is_Expired = 1 OR Expiry_Date < CURDATE()) AS ExpiredItems,
                (SELECT COUNT(Inventory_ID) FROM INVENTORY WHERE Quantity <= {LOW_STOCK_THRESHOLD} AND Quantity > 0 AND (Is_Expired = 0 OR Expiry_Date >= CURDATE())) AS LowStock;
        ";

            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                if (conn == null) return;

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    try
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Today's Sale
                                lblTodaySaleValue.Text = reader.GetDecimal("TodaySale").ToString("C2");

                                // Total Products
                                lblTotalProductsCount.Text = reader["TotalProducts"].ToString();

                                // Expired Items
                                lblExpiredItemsCount.Text = reader["ExpiredItems"].ToString();

                                // Low Stock Items
                                lblLowStockCount.Text = reader["LowStock"].ToString();
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error loading dashboard metrics: " + ex.Message);
                    }
                }
            }
        }

        private void LoadRecentTransactions()
        {
            string query = @"
            SELECT 
                s.Sales_ID, 
                s.Sales_Date, 
                s.Total_Amount, 
                e.Employee_Name AS Cashier
            FROM 
                SALES s
            LEFT JOIN 
                EMPLOYEES e ON s.Logged_By = e.Employee_ID
            WHERE 
                s.Status = 'Completed' 
            ORDER BY 
                s.Sales_Date DESC 
            LIMIT 10;
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
                        dgvRecentTransactions.DataSource = dt;
                        dgvRecentTransactions.Columns["Total_Amount"].DefaultCellStyle.Format = "C2";
                        dgvRecentTransactions.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error loading recent transactions: " + ex.Message);
                    }
                }
            }
        }

        private void LoadProactiveAlerts()
        {
            // Combines Near Expiry, Low Stock, and Out of Stock for the alert list
            string query = $@"
            SELECT 
                p.Name AS Product_Name, 
                i.Quantity, 
                i.Expiry_Date,
                CASE 
                    WHEN i.Quantity = 0 THEN 'OUT OF STOCK'
                    WHEN i.Expiry_Date < CURDATE() THEN 'EXPIRED'
                    WHEN i.Expiry_Date <= DATE_ADD(CURDATE(), INTERVAL 60 DAY) THEN 'NEAR EXPIRY'
                    WHEN i.Quantity <= {LOW_STOCK_THRESHOLD} THEN 'LOW STOCK'
                    ELSE 'OK' 
                END AS AlertType
            FROM 
                INVENTORY i
            JOIN 
                PRODUCTS p ON i.Product_ID = p.Product_ID
            WHERE 
                i.Quantity = 0 OR 
                i.Expiry_Date < CURDATE() OR 
                i.Expiry_Date <= DATE_ADD(CURDATE(), INTERVAL 60 DAY) OR
                i.Quantity <= {LOW_STOCK_THRESHOLD}
            ORDER BY 
                CASE AlertType 
                    WHEN 'OUT OF STOCK' THEN 1 
                    WHEN 'EXPIRED' THEN 2
                    WHEN 'NEAR EXPIRY' THEN 3
                    WHEN 'LOW STOCK' THEN 4
                    ELSE 5 END,
                i.Expiry_Date ASC;
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
                        dgvProactiveAlerts.DataSource = dt;
                        dgvProactiveAlerts.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error loading proactive alerts: " + ex.Message);
                    }
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // 3. METRIC CLICK NAVIGATION LOGIC
        // ---------------------------------------------------------------------------------------------------

        // This method handles the navigation click events for the metrics.
        private void MetricLabel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            // Find the parent HomeForm to use its public navigation method
            HomeForm parentForm = this.ParentForm as HomeForm;
            if (parentForm != null)
            {
                // Pass the control's variable name to the HomeForm to identify the filter
                parentForm.NavigateAndFilter(clickedLabel.Name);
            }
        }

        private void btnDashboardSearch_Click(object sender, EventArgs e)
        {
            // Search functionality can be implemented here to filter the two grids,
            // or more simply, to load the InventoryUC with the search term.
            MessageBox.Show("Dashboard search logic to load InventoryUC with the search term must be implemented.", "Action Required");
        }
    }
}
