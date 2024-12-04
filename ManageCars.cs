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
    public partial class ManageCars : Form
    {
        public ManageCars()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //capture the data entered
            string model = txt_model.Text;
            int seat_number = int.Parse(txt_seatNumber.Text);
            string ID=txt_ID.Text;
            
            //create an object of the car class
            Car car=new Car(ID,model,seat_number);
            //create an object of the admin class, call the AddCar method with the car class's get methods as parameters
            Admin admin=new Admin();
            admin.AddCar(car.GetModel(model), car.GetSeatNumber(seat_number),car.GetID(ID),car.GetAvailability());
            

        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            string id=txt_ID.Text;
            string model=txt_model.Text;
            int seat_Number=int.Parse(txt_seatNumber.Text);

            Car car=new Car(id,model,seat_Number);
            Admin admin=new Admin();
            admin.RemoveCar(car.GetID(id));
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
