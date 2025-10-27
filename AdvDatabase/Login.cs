using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AdvDatabase
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            lblError.Visible = false;

            // --- DISCONNECTED LOGIC: Using DataService for simulated authentication ---
            // The original MySQL query and connection logic are replaced here:

            // NOTE: The DataService method mirrors the DB query for Employee_Name (Username) 
            // and Contact_Info (Password).
            DataRow userRow = DataService.AuthenticateUser(username, password);

            if (userRow != null)
            {
                // Authentication Successful
                // We must use .Field<T> to safely access DataRow columns
                int employeeId = userRow.Field<int>("Employee_ID");
                string position = userRow.Field<string>("Position");
                string employeeName = userRow.Field<string>("Employee_Name");

                ShowHomeForm(employeeId, employeeName, position);
                this.Hide();
            }
            else
            {
                // Authentication Failed
                lblError.Text = "Invalid Username or Password. (Try AdminUser/admin123)";
                lblError.Visible = true;
                txtPassword.Clear();
            }
        }

        private void ShowHomeForm(int employeeId, string employeeName, string position)
        {
            // Instantiates the main application form (HomeForm) using the parameterized constructor
            HomeForm mainForm = new HomeForm(employeeId, employeeName, position);
            mainForm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

    
