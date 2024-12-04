using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CabManagement
{
    public class Driver:Person
    {
        
        private int Availability {  get; set; }
        public Driver( string Name, string ID, string Contact_No, string Account_No) : base(Name, ID, Contact_No, Account_No)
        {
            Availability = 1;
        }
        public override string GetName()
        {
            return this.Name;
          
        }
        public override string GetID()
        {
            return this.ID;
        }
        public override string GetContact_No()
        {
            return this.Contact_No;
        }
        public override string GetAccount_No()
        {
            return this.Account_No;
        }
        public int GetAvailability() { return Availability; }

       
        
           

        
    }
}
