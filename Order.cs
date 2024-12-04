using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CabManagement
{
    public class Order
    {
        string id {  get; set; }
        DateTime date {  get; set; }
        string customerid {  get; set; }
        string driverid {  get; set; }
        string status {  get; set; }
        int price {  get; set; }
        string carid {  get; set; }
        string pickup {  get; set; }
        string destination { get; set; }

        public Order() { }
        public Order(string id,DateTime date, string customerid , string driverid, string status,int price,string carid,string pickup,string destination)
        {
            this.id = id;
            this.date=date;
            this.customerid = customerid;
            
            this.driverid = driverid;
            this.status = status;
            this.price=price;
            this.carid = carid;
            this.pickup = pickup;
            this.destination = destination;
        }
        public string Getcarid() { return this.carid; }
        public string Getid()
        {
            return this.id;
        }
        public DateTime Getdate()
        {
            return this.date;
        }
        public string Getcustomerid()
        {
            return this.customerid;
        }
        public int Getprice()
        {
            return this.price;
        }
        public string Getstatus()
        {
            return this.status;
        }
        public string Getdriverid() { return this.driverid; }
        public string Getpickup() { return this.pickup; }
        public string Getdestination() {  return this.destination; }
        

        public string generateOrderID()
        {
            int length = 8;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            StringBuilder ID = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                ID.Append(chars[random.Next(chars.Length)]);
            }
            return ID.ToString();


        }
        


        public int calculateprice(int thepickup, int thedestination)
        {
            int price = (thedestination - thepickup) * 50;
            price = Math.Abs(price);
            return price;
        }
        public void setPrice(int price)
        {
            price= Math.Abs(price);
        }
        public void UpdateAvailability(string driverid,string carid,int availability)
        {
            
            using (var conn=DB.GetConnection())
            {
                try
                {
                    conn.Open();

                    string queryString = "UPDATE Drivers SET Availability = @availability WHERE ID = @driverid";
                    using (var command = new SqlCommand(queryString, conn))
                    {
                        command.Parameters.AddWithValue("@driverID", driverid);
                        command.Parameters.AddWithValue("@availability", availability);

                        command.ExecuteNonQuery();
                    }

                    string sql = "UPDATE Cars SET Availability = @availability WHERE ID = @carid";
                    using (var command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@carid", carid);
                        command.Parameters.AddWithValue("@availability", availability);

                        command.ExecuteNonQuery();
                    }


                }
                catch (SqlException ex)
                {
                    // Handle SQL exceptions (e.g., connection errors, syntax errors)
                    Console.WriteLine("Error updating availability: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void UpdateAvailability(string driverid, int availability)
        {
            using (var conn = DB.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Update driver availability
                    string queryString = "UPDATE Drivers SET Availability = @availability WHERE ID = @driverid";
                    using (var command = new SqlCommand(queryString, conn))
                    {
                        command.Parameters.AddWithValue("@driverid", driverid);
                        command.Parameters.AddWithValue("@availability", availability);
                        command.ExecuteNonQuery();
                    }

                    // Get carid associated with the driver
                    string carid = null;
                    string sql0 = "SELECT carid FROM Orders WHERE driverID = @driverid";
                    using (SqlCommand command = new SqlCommand(sql0, conn))
                    {
                        command.Parameters.AddWithValue("@driverid", driverid);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                carid = reader.GetString(7); 
                            }
                        }
                    }

                    // Update car availability if carid was found
                    if (carid != null)
                    {
                        string sql = "UPDATE Cars SET Availability = @availability WHERE ID = @carid";
                        using (var command = new SqlCommand(sql, conn))
                        {
                            command.Parameters.AddWithValue("@carid", carid);
                            command.Parameters.AddWithValue("@availability", availability);
                            command.ExecuteNonQuery();
                        }
                    }

                }
                catch (SqlException ex)
                {
                    // Handle SQL exceptions (e.g., connection errors, syntax errors)
                    Console.WriteLine("Error updating availability: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public int GetPrice(int price) { return price; }
        public void InsertOrder(string id, DateTime date, string customerid, string driverid, string status, int price,string carid,string pickup,string destination) 
        {
            using (var conn = DB.GetConnection())
            {
                try
                {
                    conn.Open();

      
                    string sql1 = "INSERT INTO Orders(id,date,customerid,driverid,status,price,carid,pickup,destination) VALUES(@id,@date,@customerid,@driverid,@status,@price,@carid,@pickup,@destination)";
                    SqlCommand cmd = new SqlCommand(sql1, conn);
                    cmd.Parameters.AddWithValue("@id",id);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@customerid",customerid);
                    cmd.Parameters.AddWithValue("@driverid",driverid);
                    cmd.Parameters.AddWithValue("@status",status);
                    cmd.Parameters.AddWithValue("@price",price);
                    cmd.Parameters.AddWithValue("@carid", carid);
                    cmd.Parameters.AddWithValue("@pickup",pickup);
                    cmd.Parameters.AddWithValue("@destination", destination);




                    cmd.ExecuteNonQuery();



                    conn.Close();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }




            }
        }
        public string findpickupname(int pickup)

        {
            using (var conn = DB.GetConnection())
            {
                string cityName = null;
                try
                {
                    conn.Open();
                    string sql = "SELECT City FROM Location WHERE Weight = @pickup";
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@pickup", pickup);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            cityName = reader.GetString(0); // Assuming "City" is the first column (index 0)
                        }
                    }

                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
                conn.Close();
                return cityName;

            }
        }
        public string finddestinationname(int destination)

        {
            using (var conn = DB.GetConnection())
            {
                string cityName = null;
                try
                {
                    conn.Open();
                    string sql = "SELECT City FROM Location WHERE Weight = @destination";
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@destination", destination);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            cityName = reader.GetString(0); // Assuming "City" is the first column (index 0)
                        }
                    }

                }

                catch (Exception ex) { MessageBox.Show(ex.Message); }
                conn.Close();
                return cityName;

            }
        }
        public void updatestatus(string driverid, string status)
        {
            using (var conn = DB.GetConnection())
            {
                try
                {
                    conn.Open();

                    string queryString = "UPDATE orders SET status = 'Complete' WHERE driverid = @driverid;";
                    using (var command = new SqlCommand(queryString, conn))
                    {
                        command.Parameters.AddWithValue("@driverID", driverid);
                        command.Parameters.AddWithValue("@status", status);

                        command.ExecuteNonQuery();
                    }



                }
                catch (SqlException ex)
                {
                    // Handle SQL exceptions (e.g., connection errors, syntax errors)
                    Console.WriteLine("Error updating status: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }



    }
}
