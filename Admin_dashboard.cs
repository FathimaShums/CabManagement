using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabManagement
{
    public partial class Admin_dashboard : Form
    {
        public Admin_dashboard()
        {
            InitializeComponent();
            
        }
 
  


    private void button1_Click(object sender, EventArgs e)
        {
            ManageCars manageCars = new ManageCars();
            manageCars.Show();
            this.Hide();
        }

       

        private void Admin_dashboard_Load(object sender, EventArgs e)
        {
           ;

        }

        private void btn_Managedrivers_Click(object sender, EventArgs e)
        {
            ManageDrivers manageDrivers = new ManageDrivers();
            manageDrivers.Show();
            this.Hide();
        }

        private void btn_vieworderhistory_Click(object sender, EventArgs e)
        {
            ViewOrders history = new ViewOrders();
            history.Show();
        }
    }
}
