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

            // Wire up search button
            btnDashboardSearch.Click += btnDashboardSearch_Click;
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
            // DISCONNECTED LOGIC: Fetches calculated metrics from DataService
            DataTable metrics = DataService.GetDashboardMetrics();

            if (metrics.Rows.Count > 0)
            {
                DataRow reader = metrics.Rows[0];
                // Today's Sale
                lblTodaySaleValue.Text = reader.Field<decimal>("TodaySale").ToString("C2");
                // Total Products
                lblTotalProductsCount.Text = reader.Field<int>("TotalProducts").ToString();
                // Expired Items
                lblExpiredItemsCount.Text = reader.Field<int>("ExpiredItems").ToString();
                // Low Stock Items
                lblLowStockCount.Text = reader.Field<int>("LowStock").ToString();
            }
        }

        private void LoadRecentTransactions()
        {
            // DISCONNECTED LOGIC: Use DataService to fetch all sales
            DataTable sales = DataService.GetData("SALES");

            // In-memory filtering/sorting to simulate the SQL query's results
            var recentSales = sales.AsEnumerable()
                .Where(row => row.Field<string>("Status") == "Completed")
                .OrderByDescending(row => row.Field<DateTime>("Sales_Date"))
                .Take(10);

            if (recentSales.Any())
            {
                dgvRecentTransactions.DataSource = recentSales.CopyToDataTable();
            }
            else
            {
                dgvRecentTransactions.DataSource = null;
            }

            dgvRecentTransactions.Columns["Total_Amount"].DefaultCellStyle.Format = "C2";
            dgvRecentTransactions.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void LoadProactiveAlerts()
        {
            // DISCONNECTED LOGIC: Use DataService to fetch inventory data
            DataTable inventory = DataService.GetData("INVENTORY");
            DateTime today = DateTime.Today;
            DateTime nearExpiryDate = today.AddDays(60);

            // In-memory LINQ query to simulate the complex SQL alert logic
            var alerts = inventory.AsEnumerable()
                .Where(row =>
                    row.Field<int>("Quantity") == 0 ||
                    row.Field<DateTime>("Expiry_Date").Date < today.Date ||
                    row.Field<DateTime>("Expiry_Date").Date <= nearExpiryDate.Date ||
                    (row.Field<int>("Quantity") <= LOW_STOCK_THRESHOLD && row.Field<int>("Quantity") > 0)
                )
                // Project results with calculated AlertType
                .Select(row => new
                {
                    Product_Name = row.Field<string>("Product_Name"),
                    Quantity = row.Field<int>("Quantity"),
                    Expiry_Date = row.Field<DateTime>("Expiry_Date"),
                    AlertType = row.Field<int>("Quantity") == 0 ? "OUT OF STOCK" :
                                row.Field<DateTime>("Expiry_Date").Date < today.Date ? "EXPIRED" :
                                row.Field<DateTime>("Expiry_Date").Date <= nearExpiryDate.Date ? "NEAR EXPIRY" :
                                row.Field<int>("Quantity") <= LOW_STOCK_THRESHOLD ? "LOW STOCK" : "OK"
                })
                // Order by alert priority
                .OrderBy(a => a.AlertType.Contains("OUT") ? 1 : a.AlertType.Contains("EXPIR") ? 2 : a.AlertType.Contains("NEAR") ? 3 : a.AlertType.Contains("LOW") ? 4 : 5)
                .ToList();

            dgvProactiveAlerts.DataSource = alerts;
            dgvProactiveAlerts.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        // ---------------------------------------------------------------------------------------------------
        // 3. METRIC CLICK NAVIGATION LOGIC
        // ---------------------------------------------------------------------------------------------------

        // This method handles the navigation click events for the metrics.
        private void MetricLabel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            HomeForm parentForm = this.ParentForm as HomeForm;
            if (parentForm != null)
            {
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
