using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CabManagement
{
    public partial class Driver_dashboard : Form
    {
        private DataTable Order;
        private string Ordernow;
        private string userName;
        private string carid;
        public Driver_dashboard(string userName)
        {
            InitializeComponent();
            this.userName = userName;
            

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Driver_dashboard_Load(object sender, EventArgs e)
        {
            DisplayOrder(userName, label2);
        }
        public void DisplayOrder(string userName,Label label2)
        {
            using (var conn = DB.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Orders WHERE DriverID = @userName AND status = 'pending'"
;
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@userName", userName);
                StringBuilder orderDetails = new StringBuilder();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                          
                            string orderId =reader.GetString(0); 
                            string customerid = reader.GetString(2);
                            string status = reader.GetString(4);
                            string pickup = reader.GetString(7);
                            string carid=reader.GetString(6);

                            string destination=reader.GetString(8);
                            

                            orderDetails.AppendLine($"Order ID: {orderId}");
                            orderDetails.AppendLine($"Customer Name: {customerid}");
                            orderDetails.AppendLine($"carid:{carid}");
                            orderDetails.AppendLine($"Destination: {destination}");
                            orderDetails.AppendLine($"Pickup:{ pickup}");
                            orderDetails.AppendLine($"status:{status}");
                            
                            this.carid = carid;
                            
                        }
                    }
                    else
                    {
                        orderDetails.AppendLine("No orders found for this driver.");
                    }
                }
                label2.Text = orderDetails.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string status = "complete";
            Order order = new Order();
            order.updatestatus(userName, status);
            MessageBox.Show("successfully update order");
            int availability = 1;
            order.UpdateAvailability(userName,carid,availability);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
