using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCabBookingWithDb
{
    public class Admin
    {
        static string name;
        static string password;
        internal Dictionary<int, string> locationPair = new Dictionary<int, string>();
        public Admin()                          //assigns access location as default
        {
            locationPair[1] = "Chennai";
            locationPair[2] = "Coimbatore";
            locationPair[3] = "Erode";
            locationPair[4] = "Madurai";
            locationPair[5] = "Tirunelveli";
        }
        public void AddLocation(string location)            //location to add by admin
        {

            locationPair[locationPair.Count + 1] = location;
            Console.WriteLine("Location added successfully as {0}th service", locationPair.Count);
            Console.WriteLine("Our Service locations\n");
        }
        void DisplayLocation()
        {
            for (int i = 1; i <= locationPair.Count; i++)
            {
                Console.WriteLine(locationPair[i]);
            }
        }
        static Admin()              //assigns default admin login
        {
            name = "admin";
            password = "admin@yourcabs";
        }
        internal static void ValidateLogin()            //validate for admin login
        {
            Console.WriteLine("Enter the AdminName");
            string adminName = Console.ReadLine();
            if (adminName == name)
            {
                Console.WriteLine("Enter the password");
                string pass = Console.ReadLine();
                if (pass == password)
                {
                    SelectToChange();

                }
                else
                {
                    ValidateLogin();
                }
            }
            else
            {
                ValidateLogin();
            }
        }
        static void AddAdmin()
        {
            Console.WriteLine("This is not accesible from the account");
            SelectToChange();
        }
        static void AddNewLocation()         //add location for operation
        {
            Admin admin = new Admin();
            Console.WriteLine("Enter the location to add");
            string location = Console.ReadLine();
            admin.AddLocation(location);
            admin.DisplayLocation();
            Console.WriteLine("hjdsbgh");
            ///break;
        }
        static void ViewCustomer()                  //method for displaying customer and driver details for admin
        {
            Console.WriteLine("The registered Customers for the location are");
            for (int i = 0; i < Customer.customerList.Count; i++)
            {
                Console.WriteLine("{0} - {1} {2}", i + 1, Customer.customerList[i].FirstName, Customer.customerList[i].LastName);
            }
            Console.WriteLine("The available dirver in the locality \n {0}-- {1} {2}-- {3}", Driver.id, Driver.firstName, Driver.lastName, Driver.number);

        }
        static void SelectToChange()          //selection for admin preferance
        {
            Console.WriteLine("Choose to perform the action");
            Console.WriteLine("1 - Add another admin account\n2 - Add New Location\n3 - See available drivers or customers");
            byte choice;
            choice = byte.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddAdmin();
                    break;
                case 2:
                    AddNewLocation();
                    break;
                case 3:
                    ViewCustomer();
                    break;
            }
        }
    }
}
