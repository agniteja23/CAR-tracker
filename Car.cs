using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Tracker
{
    public enum status
    {
        Sold ,
        Reserved,
        Available
    }
    public class Car : Tasks
    {
        private string name;
        private int year;
        private string company;
        private string model_number;
        private status cstatus;
       
        
        public Car() { }
        public Car(string Name, int Year, string Company, string Model_number)
        {
            name=Name;
            year=Year;
            company=Company;
            model_number=Model_number;
            cstatus=status.Available;
        }
        public status Cstatus
        {
            set { cstatus = value; }
            get { return cstatus; }
        }
        public string Model_number
        {
            set { model_number=value; }
            get { return model_number; }
        }

        public string Name
        {
            set { name=value; }
            get { return name; }
        }

        public int Year
        {
            set { year=value; }
            get { return year; }
        }

        public string Company
        {
            set { company=value; }
            get { return company; }
        }

        public void display()
        {
            Console.WriteLine("\n============================================\n");
            Console.WriteLine($"Car Name:{name}\nManufacturing Year: {year}\nCompany: {company}\nModel Number: {model_number}\nStatus: {cstatus}\n");
        }
    }
}
