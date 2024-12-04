using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabManagement
{
    public class Admin
    {
        
        public void AddDriver(string username, string ID, string contact_No, string Account_No,int availability, string password)
        {
          

            using (var conn=DB.GetConnection())
            {
                try
                {
                    conn.Open();

                   
                    int usertype = 2;
                    string sql1 = "INSERT INTO Drivers(name,ID,contact_No,Account_No,availability) VALUES(@username,@ID,@contact_No,@Account_No,@availability)";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn);
                    cmd1.Parameters.AddWithValue("@username", username);
                    cmd1.Parameters.AddWithValue("@ID", ID);
                    cmd1.Parameters.AddWithValue("@contact_No", contact_No);
                    cmd1.Parameters.AddWithValue("@Account_No", Account_No);
                    cmd1.Parameters.AddWithValue("@availability", availability);
                    cmd1.ExecuteNonQuery();

                    string sql2 = "INSERT INTO users(username,password,type) VALUES(@ID,@password,@usertype)";
                    SqlCommand cmd2 = new SqlCommand(sql2, conn);
                    cmd2.Parameters.AddWithValue("@ID", ID);
                    cmd2.Parameters.AddWithValue("@password", password);
                    cmd2.Parameters.AddWithValue("@usertype", usertype);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }




            }


        }
        public void RemoverDriver(string removeID)
        {
            //sql logic to remove from usertable & customer
            using (var conn = DB.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM Drivers WHERE ID = @removeID";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    // Add parameter for removeID
                    command.Parameters.AddWithValue("@removeID", removeID);

                    // Execute the DELETE statement
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Driver with ID {0} removed successfully.", removeID);
                    }
                    else
                    {
                        Console.WriteLine("No driver found with ID {0}.", removeID);
                    }
                }
                conn.Close();

            }
        }
        public void AddCar(string Model,int seatnumber,string ID,int availability)
        {
            using (var conn = DB.GetConnection())
            {
                try
                {
                    conn.Open();

                    

                    string sql = "INSERT INTO Cars(model,seatNumber,ID,availability) VALUES(@Model,@seatnumber,@ID,@availability)";
                    SqlCommand cmd3 = new SqlCommand(sql, conn);
                    cmd3.Parameters.AddWithValue("@Model", Model);
                    cmd3.Parameters.AddWithValue("@seatnumber", seatnumber);
                    cmd3.Parameters.AddWithValue(@"ID", ID);
                    cmd3.Parameters.AddWithValue("@availability", availability);
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("Successfully added a car");
                    conn.Close();





                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                    
                }




            }
        }
        public void RemoveCar(string ID)
        {

            using (var conn = DB.GetConnection())
            {
                    try
                    {
                        conn.Open();

                        string sql = "DELETE FROM Cars WHERE ID = @ID";
                        SqlCommand cmd3 = new SqlCommand(sql, conn);
                        cmd3.Parameters.AddWithValue("@ID", ID);
                        cmd3.ExecuteNonQuery();
                        MessageBox.Show("successfully removed a car");
                        conn.Close();

                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                conn.Close();
                }
            

        }
        public void ViewOrders()
        {

            using (var conn = DB.GetConnection()) {
                try {
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                conn.Close ();
            }
        }
    }
}
