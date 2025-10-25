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
            // Ensure security is set in code if not done in designer:
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            lblError.Visible = false;

            // Query to check if the employee exists in the EMPLOYEES table
            string query = "SELECT Employee_ID, Position, Employee_Name FROM EMPLOYEES WHERE Employee_Name = @username AND Contact_Info = @password";

            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                if (conn == null) return; // Exit if connection failed

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    try
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Authentication Successful
                                int employeeId = reader.GetInt32("Employee_ID");
                                string position = reader.GetString("Position");
                                string employeeName = reader.GetString("Employee_Name");

                                ShowHomeForm(employeeId, employeeName, position);
                                this.Hide();
                            }
                            else
                            {
                                // Authentication Failed
                                lblError.Text = "Invalid Username or Password.";
                                lblError.Visible = true;
                                txtPassword.Clear();
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        lblError.Text = "A database error occurred during login. " + ex.Message;
                        lblError.Visible = true;
                    }
                }
            }
        }

        private void ShowHomeForm(int employeeId, string employeeName, string position)
        {
            // Instantiates the main application form (HomeForm) using the parameterized constructor
            HomeForm mainForm = new HomeForm(employeeId, employeeName, position);
            mainForm.Show();
        }
    }
}

    
