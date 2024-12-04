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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CabManagement
{
    public partial class placeorder : Form
    {
        
        
        private string username;

        private DataTable driversTable;
        private DataTable pickupTable;
        private DataTable destinationTable;
        private DataTable carTable;
        private int selectedcarID;
        private int selectedpickup;
        private int selecteddestination;
        private string selectedDriverID;
        public placeorder(string username)
        {
          
            InitializeComponent();
            this.username = username;
            
            Loadpickup();
            Loaddestination();
            Loadcar();  
            Loaddriversnames();
            textBox1.Text = username;
        }
        private void Loaddestination()
        {
            destinationTable = new DataTable();
            using (var conn = DB.GetConnection())
            {
                string sql = "SELECT city,weight FROM Location";
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(destinationTable);

                    comboBox2.DataSource = destinationTable;
                    comboBox2.DisplayMember = "city";
                    comboBox2.ValueMember = "weight";
                }
                catch (SqlException ex) { MessageBox.Show("There was an error loading the destinations:" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void Loadpickup()
        {
            pickupTable = new DataTable();
            using (var conn = DB.GetConnection())
            {
                string sql = "SELECT city,weight FROM Location";
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(pickupTable);

                    comboBox1.DataSource = pickupTable;
                    comboBox1.DisplayMember = "city";
                    comboBox1.ValueMember = "weight";
                }
                catch (SqlException ex) { MessageBox.Show("There was an error loading the  pickup locations:" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void Loadcar()
        {
            carTable = new DataTable();
            using (var conn = DB.GetConnection())
            {
                string sql = "SELECT CONCAT (model,' |seats: ', seatNumber) AS DisplayText, ID FROM Cars WHERE availability = 1";

                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(carTable);

                    comboBox3.DataSource = carTable;
                    comboBox3.DisplayMember = "DisplayText";
                    comboBox3.ValueMember = "ID";
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error loading car details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void Loaddriversnames()
        {
            driversTable = new DataTable();
            using (var conn = DB.GetConnection())
            {
                string sql = "SELECT name,ID FROM Drivers WHERE availability=1";
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(driversTable);

                    comboBox4.DataSource = driversTable;
                    comboBox4.DisplayMember = "name";
                    comboBox4.ValueMember = "ID";

                }
                catch (SqlException ex) { MessageBox.Show("There was an error loading driver names:" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void placeorder_Load(object sender, EventArgs e)
        {
            
            


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            int thepickup = (int)comboBox1.SelectedValue;
            int thedestination = (int)comboBox2.SelectedValue;
            
            Order order = new Order();
            int price = order.calculateprice(thepickup, thedestination);
            order.setPrice(price);
            string message = "The price is: Rs. " + price.ToString();
            MessageBox.Show(message);
            
            
         
        }
        

        private void btn_placeorder_Click(object sender, EventArgs e)
        {
            
            int thepickup = (int)comboBox1.SelectedValue;
            int thedestination = (int)comboBox2.SelectedValue;
            
           
            string carid=((string)comboBox3.SelectedValue);
            Order order = new Order();
            string pickup = order.findpickupname(thepickup);
            string destination=order.finddestinationname(thedestination);
            


            string orderID=order.generateOrderID();
            
            DateTime now = DateTime.Now;

            string customerid = username;
            int availability = 0;
            

            string driverid=((string)comboBox4.SelectedValue);
            string status = "pending";
            int price=order.calculateprice(thepickup,thedestination);
            Order order1 = new Order(orderID,now,customerid,driverid,status,price,carid,pickup,destination);
            try
            {
                order1.InsertOrder(order1.Getid(), order1.Getdate(), order1.Getcustomerid(), order1.Getdriverid(), order1.Getstatus(), order1.Getprice(),order1.Getcarid(),order1.Getpickup(),order1.Getdestination());
                MessageBox.Show("successfully added an order!");
                order1.UpdateAvailability(order1.Getdriverid(),order1.Getcarid(),availability);
                MessageBox.Show("Driver and car availability toggled");
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }




            





        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
