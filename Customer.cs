using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabManagement
{
    public class Customer:Person
    {
        private string pickup;
        private string destination;
        
        public Customer( string Name, string ID, string Contact_No, string Account_No,string pickup, string destination) : base(Name, ID, Contact_No, Account_No)
        {
            this.pickup = pickup;
            this.destination = destination;
            
        }
      

        public override string GetName()
        {
            return Name;
        }
        public override string GetID()
        {
            return ID;
        }
        public override string GetContact_No()
        {
            return Contact_No;
        }
        public override string GetAccount_No()
        {
            return Account_No;
        }

        public string Getpickup(string pickup)
        {
            return pickup;
        }
        public string Getdestination() { return destination; }
        public void RegisterCustomer(string Name, string ID, string Contact_No, string Account_No, string password)
        {
            using (var conn = DB.GetConnection())
            {
                conn.Open();
                string sql1 = "INSERT INTO Customers(name, ID, Contact_No, Account_No) VALUES(@name,@ID,@Contact_No,@Account_No)";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@name", Name);
                cmd1.Parameters.AddWithValue("@ID", ID);
                cmd1.Parameters.AddWithValue("@Contact_No", Contact_No);
                cmd1.Parameters.AddWithValue("@Account_No", Account_No);
                cmd1.ExecuteNonQuery();
                int usertype = 1;

                string sql2 = "INSERT INTO users(username,password,type) VALUES(@ID,@password,@usertype)";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@ID", ID);
                cmd2.Parameters.AddWithValue("@password", password);
                cmd2.Parameters.AddWithValue("@usertype", usertype);
                cmd2.ExecuteNonQuery();
                conn.Close();
            }

        }

    }
}
