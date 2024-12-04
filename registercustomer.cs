using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabManagement
{
    public partial class registercustomer : Form
    {
        public registercustomer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            string Name = txt_Name.Text;
            string ID = txt_ID.Text;
            string Contact_No = txt_contact.Text;
            string Account_No = txt_accountNo.Text;
            string pickup = "";
            string destination = "";
            string password = txt_password.Text;
            try
            {
                Customer Customer = new Customer(Name, ID, Contact_No, Account_No, pickup, destination);
                Customer.RegisterCustomer(Customer.GetName(), Customer.GetID(), Customer.GetContact_No(), Customer.GetAccount_No(),password);
                MessageBox.Show("successfully managed to register!");
                Login login = new Login();
                login.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);



            }
        }
    }
}