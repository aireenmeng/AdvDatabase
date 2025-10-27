using System.Data;
using System;

namespace AdvDatabase
{
    public static class DummyData
    {
        // Low Stock Threshold Constant (Used for simulation logic)
        public const int LOW_STOCK_THRESHOLD = 20;

        // 1. Employee Data (For Login Authentication)
        public static DataTable GetEmployees()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Employee_ID", typeof(int));
            dt.Columns.Add("Employee_Name", typeof(string));
            dt.Columns.Add("Contact_Info", typeof(string)); // Used as password placeholder
            dt.Columns.Add("Position", typeof(string));

            // Test Users (Name = Username, Contact_Info = Password)
            dt.Rows.Add(101, "AdminUser", "admin123", "Admin");
            dt.Rows.Add(102, "CashierJane", "cashier1", "Cashier");
            dt.Rows.Add(103, "ManagerMark", "manager1", "Manager");
            return dt;
        }

        // 2. Product Lookup (For Inventory/POS ComboBoxes)
        public static DataTable GetProductLookup()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Product_ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Selling_Price", typeof(decimal));
            dt.Rows.Add(1, "Paracetamol 500mg", 1.50m);
            dt.Rows.Add(2, "Amoxicillin 250mg", 5.75m);
            dt.Rows.Add(3, "Vitamin C 500mg", 2.00m);
            dt.Rows.Add(4, "Betadine Solution", 55.00m);
            dt.Rows.Add(5, "Expired Item Test", 10.00m);
            dt.Rows.Add(6, "Low Stock Test", 8.00m);
            dt.Rows.Add(7, "Near Expiry Item", 12.00m);
            return dt;
        }

        // 3. Inventory Data (For Grid Display and Alerts)
        public static DataTable GetInventory()
        {
            DataTable dt = new DataTable();
            // Columns must match InventoryUC load query output
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("Inventory_ID", typeof(int)),
                new DataColumn("Product_ID", typeof(int)),
                new DataColumn("Product_Name", typeof(string)),
                new DataColumn("Manufacturer", typeof(string)),
                new DataColumn("Description", typeof(string)),
                new DataColumn("Date_Added", typeof(DateTime)),
                new DataColumn("Supplier_Name", typeof(string)),
                new DataColumn("Batch_Number", typeof(string)),
                new DataColumn("Quantity", typeof(int)),
                new DataColumn("Cost_Price", typeof(decimal)),
                new DataColumn("Selling_Price", typeof(decimal)),
                new DataColumn("Expiry_Date", typeof(DateTime)),
                new DataColumn("Is_Expired", typeof(int))
            });

            // Sample data for alerts:
            dt.Rows.Add(1, 1, "Paracetamol 500mg", "MedCo", "Pain Reliever", DateTime.Now.AddMonths(-6), "Supplier A", "P123A", 150, 1.00m, 1.50m, DateTime.Now.AddMonths(20), 0);
            dt.Rows.Add(2, 2, "Amoxicillin 250mg", "PharmaCorp", "Antibiotic", DateTime.Now.AddMonths(-1), "Supplier B", "A456B", 5, 4.00m, 5.75m, DateTime.Now.AddMonths(18), 0); // Low Stock (5)
            dt.Rows.Add(3, 3, "Vitamin C 500mg", "Nutra", "Supplement", DateTime.Now.AddMonths(-12), "Supplier C", "V789C", 50, 1.50m, 2.00m, DateTime.Now.AddDays(15), 0); // Near Expiry (15 days)
            dt.Rows.Add(4, 5, "Expired Item Test", "Expired Inc.", "Test Item", DateTime.Now.AddYears(-2), "Supplier A", "EXP001", 10, 5.00m, 10.00m, DateTime.Now.AddDays(-5), 1); // Expired (5 days ago)
            dt.Rows.Add(5, 6, "Low Stock Test", "Test Labs", "Alert", DateTime.Now.AddMonths(-3), "Supplier B", "LST999", 0, 7.00m, 8.00m, DateTime.Now.AddMonths(10), 0); // Out of Stock (0)
            return dt;
        }

        // 4. Suppliers (For SupplierUC)
        public static DataTable GetSuppliers()
        {
            DataTable dt = new DataTable();
            // FIX: Ensure the types are correctly referenced using the standard typeof(int) syntax
            dt.Columns.Add("Supplier_ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Contact_Info", typeof(string));
            dt.Rows.Add(1, "Supplier A Distributors", "Phone: 555-1234 | Email: a@dist.com");
            dt.Rows.Add(2, "Supplier B Pharma", "Phone: 555-4567 | Email: b@pharma.com");
            dt.Rows.Add(3, "Supplier C Nutra", "Phone: 555-7890 | Email: c@nutra.com");
            return dt;
        }

        // 5. Transaction History (For TransactionsUC)
        public static DataTable GetSalesHistory()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Sales_ID", typeof(int));
            dt.Columns.Add("Sales_Date", typeof(DateTime));
            dt.Columns.Add("Total_Amount", typeof(decimal));
            dt.Columns.Add("Payment_Method", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("Cashier_Name", typeof(string));
            dt.Rows.Add(1001, DateTime.Now.AddHours(-1), 150.50m, "Cash", "Completed", "CashierJane");
            dt.Rows.Add(1002, DateTime.Now.AddHours(-3), -20.00m, "Cash", "Refunded", "AdminUser");
            dt.Rows.Add(1003, DateTime.Now.AddDays(-1), 85.00m, "GCash", "Completed", "CashierJane");
            dt.Rows.Add(1004, DateTime.Now.AddHours(-2), 42.00m, "Cash", "Pending", "ManagerMark"); // Pending Sale
            return dt;
        }

        // 6. Categories (For lookups)
        public static DataTable GetCategories()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category_ID", typeof(int));
            dt.Columns.Add("Category_Name", typeof(string));
            dt.Rows.Add(1, "Pain Relievers");
            dt.Rows.Add(2, "Antibiotics");
            dt.Rows.Add(3, "Vitamins");
            return dt;
        }
    }
}
