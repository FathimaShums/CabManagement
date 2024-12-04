using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabManagement
{
    public class Car
    {
        string ID {  get; set; }
        string Model { get; set; }
        int seat_number {  get; set; }
        int availability {  get; set; }
        public Car(string ID, string model, int seat_number)
        {
            this.ID = ID;
            this.Model = model;
            this.seat_number = seat_number;
            this.availability = 1;

        }
        public string GetID(string ID)
        {
            return this.ID;
        }
        public string GetModel(string model)
        {
            return this.Model;
        }
        public int GetSeatNumber(int seat_number)
        {
            return this.seat_number;
        }
        public int GetAvailability()
        {
            return this.availability;
        }


    }
    
  

}
