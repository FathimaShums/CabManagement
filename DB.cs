using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace CabManagement
{
    public static class DB
    {
        private static string connectionString = "Data Source=SHAKIRS-INSPIRO\\SQLEXPRESS;Initial Catalog=cab_management;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";


        public static SqlConnection GetConnection()
        {
            
                
                try
                {
                    return new SqlConnection(connectionString);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error connecting to database: " + ex.Message); // Log error message
                    return null;
                }
            

            
        }
    }
}
