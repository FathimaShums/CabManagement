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

namespace CabManagement
{
    public partial class Login : Form
    {
        public string username { get; set; }
        public string Password { get; set; }

        public Login()
        {
            InitializeComponent();




        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            using (var conn = DB.GetConnection())
            {
                try
                {
                    conn.Open();
                    string userName = txt_Uname.Text;
                    string password = txt_Pswrd.Text;
                    //saving to public properties
                    username = userName;
                    Password = password;
                    string sql = "SELECT type FROM users WHERE username = @userName  and password = @password";
                    // parameterized queries used to prevent SQL injection attacks
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@password", password);
                    // Query excecuted and potential errorshandled
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // Read the first row (search for the matching user)
                            reader.Read();
                            int usertype;

                            // Check for null value before conversion 
                            if (reader["type"] != DBNull.Value)
                            {
                                usertype = (int)reader["type"];

                            }
                            else
                            {
                                // Handle the case where "type" is null
                                usertype = -1;

                                Console.WriteLine("Warning: 'type' field is null for user " + userName);
                            }
                            //loading the relevant form for the user
                            this.Hide();
                            if (usertype == 0)
                            {
                                Admin_dashboard adminDashboardForm = new Admin_dashboard();
                                adminDashboardForm.Show();
                            }

                            else if (usertype == 1)
                            {
                                Customer_dashboard customerDashboardForm = new Customer_dashboard(userName);
                                customerDashboardForm.Show()

                                   ;
                                //call set_Customer methods(select customer details from table where id matches username)




                            }
                            else if (usertype == 2)
                            {
                                Driver_dashboard driverDashboardForm = new Driver_dashboard(userName);
                                driverDashboardForm.Show();
                            }

                        }
                        else
                        {
                            //prepare form for if user wants to re-enter the detials because it was invalid
                            MessageBox.Show("Invalid username or password.");
                            txt_Uname.Text = string.Empty;
                            txt_Pswrd.Text = string.Empty;

                        }
                    }
                }
                catch (Exception ex) {Console.WriteLine("error due to", ex.Message); }
                conn.Close();



            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            registercustomer registercustomer = new registercustomer();
            registercustomer.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_Uname.Clear();
            txt_Pswrd.Clear();


        }
    }
}
