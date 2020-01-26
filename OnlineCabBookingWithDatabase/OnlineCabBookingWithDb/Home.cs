using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCabBookingWithDb
{
    class Home
    {
        Customer customer = new Customer();
        Driver driverObj = new Driver();
        enum Setup                  //enumeration for admin login
        {
            admin,
            user,
            driver
        };
        public void GetLogin()         // get the choice for login
        {
            Console.WriteLine("Enter the option");
            Setup forSwitch;
            while (true)
            {
                foreach (Setup set in Enum.GetValues(typeof(Setup)))
                {
                    Console.WriteLine(set);
                }

                try
                {
                    string enumChoice = Console.ReadLine();
                    forSwitch = (Setup)Enum.Parse(typeof(Setup), enumChoice);
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Please enter from the options");
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter from the options");
                }
            }
            switch (forSwitch)
            {
                case Setup.admin:
                    {
                        Admin.ValidateLogin();
                        Console.WriteLine("Done process...Press Enter to Logout");
                        break;
                    }
                case Setup.user:
                    {
                        Console.WriteLine("Welcome to YOUR CAB");
                        customer.GetRegistrationChoice(driverObj);
                        Console.WriteLine("Done the process...Press Enter to exit. Hope see you again");
                        break;
                    }
                case Setup driver:
                    {
                        Console.WriteLine("Welcome to Your Cabs\nDrivers are first asset");
                        Driver.ValidateDriver(driverObj);
                        Console.WriteLine("Done process...Press Enter to have your ride");
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
