using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace OnlineCabBookingWithDb
{
    class Customer : CustomerRepository, IRideDetails
    {


        protected string firstName;
        protected string lastName;
        protected string mailId;
        protected long mobile;
        public string Password { get; set; }
        string location;
        protected int referralCode;
        public string pickLocation { get; set; }
        public string dropLocation { get; set; }
        public string Location
        {
            set
            {
                location = value;
            }
            get
            {
                return location;
            }
        }
        public string FirstName
        {
            set
            {
                firstName = value;
            }
            get
            {
                return firstName;
            }
        }
        public string LastName
        {
            set
            {
                lastName = value;
            }
            get
            {
                return lastName;
            }
        }
        public string MailId
        {
            set
            {
                mailId = value;
            }
            get
            {
                return mailId;
            }
        }
        public long Mobile
        {
            set
            {
                mobile = value;
            }
            get
            {
                return mobile;
            }
        }





        /// ///////////////////////////
   
        byte choice;
       //Driver driver1 = new Driver();
        //CustomerValidation validation = new CustomerValidation();

       

        public Driver ProcessRide(Driver customer)           //called for getting ride locations
        { 
            //Driver driver1 = new Driver();
            Console.WriteLine("Enter the Pickup location in {0}", customerList[customerList.Count - 1].Location);
            customer.pickLocation = Console.ReadLine();
            Console.WriteLine("Enter the drop location within {0} range", customerList[customerList.Count - 1].Location);
            customer.dropLocation = Console.ReadLine();
            return customer;
        }
        public void ProcessRide(string choice)          //called for getting ride locations for existing login
        {
            Console.WriteLine("Enter the Pickup location in {0}", customerList[customerList.Count - 1].Location);
            customerList[customerList.Count - 1].pickLocation = Console.ReadLine();
            Console.WriteLine("Enter the drop location within {0} range", customerList[customerList.Count - 1].Location);
            customerList[customerList.Count - 1].dropLocation = Console.ReadLine();
        }
        void SignUp(Driver driver)          //signup for new user
        {
            CustomerValidation validation = new CustomerValidation();
            Driver driver1 = new Driver();
            Customer customer = new Customer();
            Console.WriteLine("Welcome to Your Cab");
            Thread.Sleep(1000);
            Console.WriteLine("Follow our simple registration process to Enjoy your ride");
            Thread.Sleep(1500);
            Console.WriteLine("Enter your first Name:");
            customer.FirstName = validation.ValidateName(1);
            Console.WriteLine("Enter your last Name:");
            customer.LastName = validation.ValidateName(2);
            Console.WriteLine("Enter your MailId:");
            customer.MailId = validation.ValidateMailId();
            Console.WriteLine("Enter your Mobile Number:");
            customer.Mobile = validation.ValidateMobileNumber();
            Console.WriteLine("Choose a location");
            customer.Location = validation.ValidateLocation();
            Console.WriteLine("Enter the referrel code to enjoy rewards");
            Console.WriteLine("Sit back...Your registration is done");
            //Customer.customerList.Add(driver1);
            Thread.Sleep(2000);
            Console.WriteLine("Enter the Pickup location in {0}", customer.Location);
            customer.pickLocation = Console.ReadLine();
            Console.WriteLine("Enter the drop location within {0} range", customer.Location);
            customer.dropLocation = Console.ReadLine();
            //Customer customer1=(Customer)ProcessRide((Driver)customer);
            Customer.customerList.Add(customer);
            int count=CustomerDbConnection(customer);
            Console.WriteLine("Press 1 to view your details...Else press any key");
            byte choice = byte.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Driver.lastData += 1;
                driver.ProcessRide();
                Console.WriteLine("Press Enter to confirm your ride");
                Console.ReadLine();
                Console.WriteLine("Your ride is confirmed...We will notify you with Driver contact");
                Console.WriteLine("Happy Journey...");
            }
        }
        void SignIn(Driver driver)              //login for existing user
        {
            CustomerValidation validation = new CustomerValidation();
            Console.WriteLine("Enter your Existing mobile number to login");
            validation.ValidateExistingLogin();
            Console.WriteLine("Welcome back...Continue your ride with us");
            ProcessRide("signin");
            Console.WriteLine("Press 1 to view your details...Else press any key");
            byte choice = byte.Parse(Console.ReadLine());
            if (choice == 1)
            {
                driver.ProcessRide();
                Console.WriteLine("Press Enter to confirm your ride");
                Console.ReadLine();
                Console.WriteLine("Your ride is confirmed...We will notify you with Driver contact");
                Console.WriteLine("Happy Journey...");
            }
        }

        public void GetRegistrationChoice(Driver driver)     //choice between new and existing users
        {

            while (true)
            {
                Console.WriteLine("Select 1 or 2 to continue\n1-SignUp\n2-SignIn");
                try
                {
                    choice = byte.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter only single digit number");
                }
            }
            switch (choice)
            {
                case 1:
                    SignUp(driver);
                    break;
                case 2:

                    SignIn(driver);
                    break;
                default:
                    {
                        Console.WriteLine("Please Choose appropirate action");
                        GetRegistrationChoice(driver);
                        break;
                    }
            }
        }
        static void Main(string[] args)
        {
            Home home = new Home();
            home.GetLogin();
            Thread.Sleep(1000);
            Console.Read();
        }
    }
}
