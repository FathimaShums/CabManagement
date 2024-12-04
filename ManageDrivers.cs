using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CabManagement
{
    public partial class ManageDrivers : Form
    {
        private DataTable driversTable;
        private string selectedDriverID;
        public ManageDrivers()
        {
            InitializeComponent();
            

            

        }
        private void Loaddriversnames()
        {
            driversTable = new DataTable();
            using (var conn = DB.GetConnection())
            {
                string sql = "SELECT name,ID FROM Drivers";
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(driversTable);

                    comboBox1.DataSource = driversTable;
                    comboBox1.DisplayMember = "name";
                    comboBox1.ValueMember = "ID";

                }
                catch (SqlException ex) { MessageBox.Show("There was an error loading driver names:" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            //capture the values
            string name=txt_name.Text;
            string id=txt_id.Text; 
            string contact=txt_contact.Text;
            string account=txt_account.Text;
            string password=txt_password.Text;

            //create an object of the driver class
            Driver driver=new Driver(name,id,contact,account);
            //create an object of the admin class
            Admin admin = new Admin();
            admin.AddDriver(driver.GetName(), driver.GetID(), driver.GetContact_No(), driver.GetAccount_No(), driver.GetAvailability(), password);
            MessageBox.Show("Successfully added a driver!");
            

        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            string driversid= (string)comboBox1.SelectedValue;
            Admin admin = new Admin();
            admin.RemoverDriver(driversid);
            MessageBox.Show("Driver removed:", driversid);

        }

        private void ManageDrivers_Load(object sender, EventArgs e)
        {
            Loaddriversnames();

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
