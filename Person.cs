using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabManagement
{
    public abstract class Person
    {
        protected string Name { get; set; }
        protected string ID { get; set; }
        protected string Contact_No { get; set; }
        protected string Account_No { get; set; }

        public Person(string Name, string ID, string Contact_No, string Account_No)
        {
            this.Name = Name;
            this.ID = ID;
            this.Contact_No = Contact_No;
            this.Account_No = Account_No;
        }

        public abstract string GetName();
        public abstract string GetID();
        public abstract string GetContact_No();
        public abstract string GetAccount_No();



    }
}
