using System;
using System.Collections.Generic;

namespace Car_Tracker
{
    public delegate void NotificationEventHandler(string message);

    public class Events
    {
        public event NotificationEventHandler? Event;

        protected void Notify(string message)
        {
            var handler = Event;
            if (handler != null)
            {
                handler(message);
            }
        }
    }

    public class Tasks : Events
    {
        private enum CarStatus
        {
            Available = 3,
            Reserved = 2,
            Sold = 1
        }

        private sealed class CarInfo
        {
            public string Name { get; set; } = string.Empty;
            public int Year { get; set; }
            public CarStatus Status { get; set; } = CarStatus.Available;
        }

        private readonly List<CarInfo> cars = new List<CarInfo>();

        public virtual int insert()
        {
            try
            {
                Console.WriteLine("Enter car name:");
                string? name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty.");
                    return 1;
                }

                Console.WriteLine("Enter car year:");
                if (!int.TryParse(Console.ReadLine(), out int year))
                {
                    Console.WriteLine("Invalid year.");
                    return 1;
                }

                var existing = cars.Find(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
                if (existing != null)
                {
                    Console.WriteLine($"Car with name '{name}' already exists. Updating year to {year} and keeping status {existing.Status}.");
                    existing.Year = year;
                    Notify($"Updated car: {name} ({year})");
                }
                else
                {
                    cars.Add(new CarInfo { Name = name.Trim(), Year = year, Status = CarStatus.Available });
                    Notify($"Added car: {name} ({year})");
                }

                Console.WriteLine("Do you want to add another car? Enter 1 to continue, 0 to stop:");
                return int.TryParse(Console.ReadLine(), out int cont) ? cont : 0;
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while inserting the car.");
                return 1;
            }
        }

        public virtual void GetCarsByYear(int year)
        {
            var results = cars.FindAll(c => c.Year == year);
            if (results.Count == 0)
            {
                Console.WriteLine($"No cars found for year {year}.");
                return;
            }

            Console.WriteLine($"Cars for year {year}:");
            foreach (var car in results)
            {
                Console.WriteLine($"- {car.Name} | Year: {car.Year} | Status: {car.Status}");
            }
        }

        public virtual void removeCar(string carName)
        {
            if (string.IsNullOrWhiteSpace(carName))
            {
                Console.WriteLine("Please provide a valid car name.");
                return;
            }

            int removed = cars.RemoveAll(c => string.Equals(c.Name, carName, StringComparison.OrdinalIgnoreCase));
            if (removed > 0)
            {
                Notify($"Removed {removed} car(s) with name '{carName}'.");
            }
            else
            {
                Console.WriteLine($"No car found with name '{carName}'.");
            }
        }

        public virtual void details()
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("No cars available.");
                return;
            }

            Console.WriteLine("All cars:");
            foreach (var car in cars)
            {
                Console.WriteLine($"- {car.Name} | Year: {car.Year} | Status: {car.Status}");
            }
        }

        public virtual void updateStatus(int statusOption, string carName)
        {
            if (string.IsNullOrWhiteSpace(carName))
            {
                Console.WriteLine("Please provide a valid car name.");
                return;
            }

            var car = cars.Find(c => string.Equals(c.Name, carName, StringComparison.OrdinalIgnoreCase));
            if (car == null)
            {
                Console.WriteLine($"No car found with name '{carName}'.");
                return;
            }

            switch (statusOption)
            {
                case 1:
                    car.Status = CarStatus.Sold;
                    Notify($"Marked '{car.Name}' as Sold.");
                    break;
                case 2:
                    car.Status = CarStatus.Reserved;
                    Notify($"Marked '{car.Name}' as Reserved.");
                    break;
                case 3:
                    car.Status = CarStatus.Available;
                    Notify($"Marked '{car.Name}' as Available.");
                    break;
                default:
                    Console.WriteLine("Invalid status option. Please choose between 1 and 3.");
                    break;
            }
        }

        public virtual void saveAndExit()
        {
            Notify($"Exiting. Total cars tracked: {cars.Count}.");
        }
    }
}

