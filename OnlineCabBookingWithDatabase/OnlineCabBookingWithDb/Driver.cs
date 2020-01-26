using System;
using System.Threading;

namespace OnlineCabBookingWithDb
{
    class Driver : Customer, IRideDetails
    {
        public static string firstName = "Karthi";          // default assignment for driver
        public static string lastName = "R";
        public static long number = 9876545678;
        public static int id = 987654;
        static string password = "driver987654";
        public static int lastData = Customer.customerList.Count - 1;
        public void ProcessRide()           //display the details 
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("***************Customer Details*******************");
            Thread.Sleep(500);
            Console.WriteLine("Customer name  : {0} {1}", Customer.customerList[lastData].FirstName, Customer.customerList[lastData].LastName);
            Thread.Sleep(500);
            Console.WriteLine("Customer MailId: {0}", Customer.customerList[lastData].MailId);
            Thread.Sleep(500);
            Console.WriteLine("Customer Mobile Number: {0}", Customer.customerList[lastData].Mobile);
            Thread.Sleep(500);
            Console.WriteLine("The travel is from {0} to {1}", Customer.customerList[lastData].pickLocation, Customer.customerList[lastData].dropLocation);
            Thread.Sleep(500);

        }
        internal static void ValidateDriver(Driver obj)         //validation for driver login
        {
            Console.WriteLine("Enter your Id to login");
            if (int.Parse(Console.ReadLine()) == id)
            {
                Console.WriteLine("Enter your password");
                if (Console.ReadLine() == password)
                {
                    Console.WriteLine("welcome {0} {1} \nYou are logged in successfully", firstName, lastName);
                    Console.WriteLine("press 1 to view customer details in queue");
                    while (true)
                    {
                        try
                        {
                            if (int.Parse(Console.ReadLine()) == 1)
                                obj.ProcessRide();
                            Console.WriteLine("Press 1 to pick the ride\n2 to pass to another driver");
                            int temp = int.Parse(Console.ReadLine());
                            if (temp == 1)
                                Console.WriteLine("Your contact details will be notified to the customer\nHave a safe ride");
                            else if (temp == 2)
                                Console.WriteLine("The ride is transferred to next driver\nStay tuned for next ride");
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Enter only digits");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Enter only digits");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Your password is incorrect");
                    ValidateDriver(obj);
                }
            }
            else
            {
                Console.WriteLine("Enter a valid login");
                ValidateDriver(obj);
            }
        }
    }
}
