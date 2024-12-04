using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CabManagement
{
    public partial class Customer_dashboard : Form
    {
        private string username;
        private string name;
        private string contact;
        private string account;
        private List<string> customerDetails;


        public Customer_dashboard(string username)
        {
            InitializeComponent();
            this.username = username;
         
            
            


        }
        List<string> GetCustomerDetailsByUsername(string username)
        {
            List<string> customerDetails = new List<string>();
            using (var conn = DB.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Use parameterized query to prevent SQL injection
                    string sql = "SELECT name, contact_No, Account_No FROM Customers WHERE ID = @username;";
                    SqlCommand cmd3 = new SqlCommand(sql, conn);
                    cmd3.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = cmd3.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read()) // Loop through all matching rows
                            {
                                string name = reader.GetString(0); // Use ordinal for clarity (can change column order)
                                string contactNo = reader.GetString(1); // Use ordinal for clarity
                                string accountNo = reader.GetString(2); // Use ordinal for clarity

                                customerDetails.Add(name + "," + contactNo + "," + accountNo); // Combine details
                            }
                        }
                        else
                        {
                            // Handle case where no user found (optional)
                            // Console.WriteLine("No user found with username: " + username);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception details for better error handling
                    Console.WriteLine("Error occurred: " + ex.Message);
                }
                conn.Close();
            }

            return customerDetails;
            
        }








        private void button3_Click(object sender, EventArgs e)
        {
            placeorder placeorder = new placeorder(username);
            placeorder.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Customer_dashboard_Load(object sender, EventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
