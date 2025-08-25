namespace Car_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int option = 0;
            Car car = new Car();
            
            EventHandlers eventHandlers = new EventHandlers();
            car.Event+=eventHandlers.handleNotificationEvent;

            //Since car inherits tasks and tasks inherit Events class,
            //we can directly use car object to access Events class parameter or methods.
            Console.WriteLine("====CAR TRACKER====");
            while (option!=6)
            {
                try
                {
                    Console.WriteLine("Choose one of the following:\n1.Add Car\n2.View by Year\n3.Remove Car\n4.View All\n5.Update Status\n6.EXIT");
                    option = int.Parse(Console.ReadLine());
                }
                catch (Exception e) { Console.WriteLine("Please eneter a valid number between 1 to 6 :)"); }
                switch (option) {
                    case 1:
                        int n = 1;
                        //adding car details to a list
                        while (n !=0)
                        {
                            n=car.insert();
                        }
                        break;
                    case 2:
                        //get car details by Year
                      
                        try
                        {
                            Console.WriteLine("Which year car details you want?: ");
                            int y = int.Parse(Console.ReadLine());
                            car.GetCarsByYear(y);
                        }
                        catch (Exception e) { Console.WriteLine("Please eneter a valid Year :)"); }  
                        break;
                    case 3:
                        //Delete car
                        Console.WriteLine("Enter name of the car you want to remove: ");
                        String cname = Console.ReadLine();
                        car.removeCar(cname);
                        break;
                    case 4:
                        //Display car details
                        car.details();
                        break;
                    case 5:
                        //Update Status
                        try
                        {
                            Console.WriteLine("Choose the following to update the status of the car: \n1)Sold\n2)Reserved\n3)Available");
                            int sn = int.Parse(Console.ReadLine());
                            if (sn <=0 || sn>3) { throw new Exception(); }
                            Console.WriteLine("Enter name of the car you want to update the status for:");
                            String carName = Console.ReadLine();
                            car.updateStatus(sn, carName);
                        }
                        catch (Exception e) { Console.WriteLine("Please choose a valid option between 1 to 3 :)"); }
                        
                        break;
                    case 6:
                        car.saveAndExit();
                        return;
                    default:
                        Console.WriteLine(" Entered Option is invalid");
                        break;
                }
            }
        }
    }
}
