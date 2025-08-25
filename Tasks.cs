using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Car_Tracker
{
    public class Tasks:Events
    {
        public List<Car> cars = new List<Car>();
        public int insert() {
            Console.WriteLine("Enter Car Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter manufacturing Year: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Company: ");
            string company = Console.ReadLine();
            Console.WriteLine("Enter Model Number: ");
            string model_number = Console.ReadLine();
            cars.Add(new Car(name, year, company, model_number));
           

            string msg = $"{name} added to the list successfully";  //Use of Event
            startEvent(msg);

            Console.WriteLine("Enter 1 to continue or Enter zero to stop adding car details: ");
            int n=int.Parse(Console.ReadLine());
            return n;

           
        }
        public void GetCarsByYear(int year) {
        /*
            int count = 0;
            
            foreach (Car c in cars)
            {
                if (c.Year == year) { count++;
                    c.display(); }
            }
            if (count == 0) {
                string msg = $"Zero cars present for the entered year:{year}";  //Use of Event
                startEvent(msg);
            }
        */
        var c = from car in cars where car.Year == year select car;   //LinQ Query

            if (!c.Any())
            {
                string msg = $"Zero cars present for the entered year:{year}";  //Use of Event
                startEvent(msg);
            }
            else
            {
                foreach (var car in c) { car.display(); }
            }

        }

        public void removeCar(string name) {
            int count = 0;
            for (int i = cars.Count - 1; i >= 0; i--) //cannot use foreach loop to remove. //
                                                   //can also use => cars.RemoveAll(car => car.Name == cname);

            {

                if (cars[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                    cars.RemoveAt(i);
                    
                }
               
            }
            if (count!=0)
            {
                string msg = $"{name} successfully Deleted";
                startEvent(msg);
            }
            else {
                string msg = $"No Car found with the given name: {name}";
                startEvent(msg);
            }
        }

        public void details() {


            if (cars.Count == 0)
            {
                string msg = "There are no cars present in the inventory";
                startEvent(msg);
            }
            else
            {
                Console.WriteLine("             Car Details:                ");
                cars.ForEach (Car => Car.display()) ;  //LinQ Method
            }
        }

        public void updateStatus(int n, String carName) {

            int count = 0;
            bool updated = false;
            string msg = "";

            for (int i = cars.Count - 1; i >= 0; i--)
            {
                if (cars[i].Name.Equals(carName, StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                    switch (n)
                    {
                        case 1:

                            if (cars[i].Cstatus != status.Sold)
                            {
                                cars[i].Cstatus = status.Sold;
                                updated = true;
                            }
                            else
                            {
                                msg = "Car is already Sold";
                            }
                            break;
                        case 2:
                            if (cars[i].Cstatus != status.Reserved)
                            {
                                cars[i].Cstatus = status.Reserved;
                                updated = true;
                            }
                            else
                            {
                                msg = "Car is already Reserved";
                            }
                            break;
                        case 3:
                            if (cars[i].Cstatus != status.Available)
                            {
                                cars[i].Cstatus = status.Available;
                                updated = true;
                            }
                            else
                            {
                                msg = "Car is already in Available status";
                            }
                            break;
                        default:
                            msg = "Invalid status code";
                            break;
                    }
                }
            }

            if (count == 0)
            {
                msg = "No car found with the given name to update the status";
            }
            else if (updated)
            {
                msg = $"{carName} status updated successfully";
            }

            startEvent(msg);

        }

        public void saveAndExit() {

            string path = "C:\\Users\\GBO3KOR\\Desktop\\C# edited files\\car_tracker.json";
            string json = JsonSerializer.Serialize(cars, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);

            string msg =  $"Data is saved to {path}. \nExiting the program.";
            startEvent(msg);

        }
    }
}

