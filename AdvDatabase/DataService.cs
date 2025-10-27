using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AdvDatabase
{
    // This class simulates all database interactions.
    // When connecting to MySQL, the logic inside these methods would be replaced with MySqlConnection/MySqlCommand.
    public static class DataService
    {
        // 1. Simulates Login Authentication (used in LoginForm)
        public static DataRow AuthenticateUser(string username, string password)
        {
            DataTable employees = DummyData.GetEmployees();
            // Simulates searching the EMPLOYEES table
            var result = employees.AsEnumerable()
                                  .FirstOrDefault(row =>
                                      row.Field<string>("Employee_Name") == username &&
                                      row.Field<string>("Contact_Info") == password);

            if (result != null)
            {
                return result; // Login successful
            }
            return null; // Login failed
        }

        // 2. Simulates simple ComboBox population (used in InventoryUC, NewTransactionForm)
        public static DataTable GetLookupData(string type)
        {
            if (type == "SUPPLIERS")
                return DummyData.GetSuppliers();
            if (type == "CATEGORIES")
                return DummyData.GetCategories();
            if (type == "PRODUCTS_FOR_POS")
                return DummyData.GetProductLookup();

            return new DataTable();
        }

        // 3. Simulates Data Loading for Grids (used in DashboardUC, TransactionsUC, InventoryUC)
        public static DataTable GetData(string dataType)
        {
            switch (dataType)
            {
                case "INVENTORY": return DummyData.GetInventory();
                case "SALES": return DummyData.GetSalesHistory();
                case "SUPPLIERS": return DummyData.GetSuppliers();
                default: return new DataTable();
            }
        }

        // 4. Placeholder for logging Item movements (like Void - used in TransactionsUC)
        public static void LogItemMovement(int salesId, string action)
        {
            MessageBox.Show($"[DB LOG] Simulated Log: Sale ID {salesId} -> Action: {action}", "Audit Simulation");
        }

        // 5. Simulates Metrics Loading (used in DashboardUC)
        public static DataTable GetDashboardMetrics()
        {
            // Simulate complex queries by calculating metrics in-memory
            DataTable dt = new DataTable();
            dt.Columns.Add("TodaySale", typeof(decimal));
            dt.Columns.Add("TotalProducts", typeof(int));
            dt.Columns.Add("ExpiredItems", typeof(int));
            dt.Columns.Add("LowStock", typeof(int));

            // Logic is complex, simplified to return hardcoded dummy values for immediate metric display
            dt.Rows.Add(350.50m, 15, 2, 4);
            return dt;
        }

        // 6. Placeholder for Transaction Finalization (used in NewTransactionForm)
        public static void ExecuteTransaction(string status, DataTable cart, int employeeId, int? salesIdToResume = null)
        {
            string action = salesIdToResume.HasValue ? "UPDATE (Resume) & FINALIZE" : "INSERT & FINALIZE";
            MessageBox.Show($"[DB TRANSACTION] Simulated {action}. Status: {status}. Cart items processed: {cart.Rows.Count}", "Transaction Simulation Success");
        }
    }
}
