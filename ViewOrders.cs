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
    public partial class ViewOrders : Form
    {
        public ViewOrders()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ViewOrders_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cab_managementDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.cab_managementDataSet.Orders);

        }
    }
}
