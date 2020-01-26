using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OnlineCabBookingWithDb
{
    class CustomerValidation : Customer             //validation class inherits reppository to check for validation
    {
       // Regex regexName = new Regex(@"^[A-Za-z]+$", RegexOptions.IgnoreCase);       //regular expression for name validation
        public string ValidateName(byte nameSelection)
        {
            Regex regexName = new Regex(@"^[A-Za-z]+$", RegexOptions.IgnoreCase);       //regular expression for name validation
            Dictionary<byte, string> name = new Dictionary<byte, string>();
            name[nameSelection] = Console.ReadLine();

            if (!regexName.IsMatch(name[nameSelection]))        //validation check
            {
                Console.WriteLine("Please Enter a valid name");
                ValidateName(nameSelection);                //calls method again for re entry
                return "";
            }
            else
            {
                if (nameSelection == 1)
                {
                    firstName = name[1];
                    return firstName;
                }
                else
                {
                    lastName = name[2];
                    return lastName;
                }
            }

        }

        //readonly Regex regexMail = new Regex("^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$");      //regular expression for mail validation
        public string ValidateMailId()
        {
            Regex regexMail = new Regex("^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$");      //regular expression for mail validation
            mailId = Console.ReadLine();
            try
            {
                if (!regexMail.IsMatch(mailId))
                {
                    Console.WriteLine("Please enter a valid mail Id");
                    ValidateMailId();                                                       //calls method again for re entry
                }
                return mailId;
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a valid mail Id");
                ValidateMailId();                                               //calls method again for re entry
                return "";
            }
        }
        public void ValidateExistingLogin()
        {
            try
            {
                long loginNumber = long.Parse(Console.ReadLine());
                int count = Customer.customerList.Count;
                int dataPosition;
                for (dataPosition = 0; dataPosition < count; dataPosition++)
                {
                    if (Customer.customerList[dataPosition].Mobile == loginNumber)
                    {
                        Console.WriteLine("Enter your password");
                        while (true)                                                //loop for login check
                        {
                            string login = Console.ReadLine();
                            if (login == Customer.customerList[dataPosition].Password)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please Enter Correct password");
                            }
                        }
                        break;
                    }
                    if (dataPosition == count - 1)
                    {
                        Console.WriteLine("The number does not exist...Enter valid number");
                        ValidateExistingLogin();                                    //calls method again for re entry
                    }

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter valid mobile number");
                ValidateExistingLogin();                            //calls method again for re entry
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter valid mobile number");
                ValidateExistingLogin();                                    //calls method again for re entry
            }

        }
        public long ValidateMobileNumber()
        {
            Console.WriteLine("Enter the mobile number");
            try
            {
                mobile = long.Parse(Console.ReadLine());
                if (mobile.ToString().Length != 10)                     //validation check
                {
                    Console.WriteLine("Please enter valid mobile number");
                    ValidateMobileNumber();
                    return 0;
                }
                if ((mobile / 1000000000 != 9) && (mobile / 1000000000 != 8) && (mobile / 1000000000 != 7))         //validation check
                {
                    Console.WriteLine("Please enter valid mobile number starting with 9 or 8 or 7");
                    ValidateMobileNumber();
                    return 0;
                }
                return mobile;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter valid mobile number");
                ValidateMobileNumber();
                return 0;
            }

        }
        public string ValidateLocation()                //location validation
        {
            Admin admin = new Admin();
            for (byte i = 1; i <= admin.locationPair.Count; i++)
            {
                Console.WriteLine("{0} - {1}", i, admin.locationPair[i]);
            }
            byte locationChoice = 0;
            try
            {
                locationChoice = byte.Parse(Console.ReadLine());
                if (locationChoice > admin.locationPair.Count || locationChoice < 1)
                {
                    Console.WriteLine("Please choose within the Available service regions");
                    ValidateLocation();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please choose from 1 to {0}", admin.locationPair.Count);
                ValidateLocation();
            }

            return admin.locationPair[locationChoice];
        }
        public int ValidateCode()                   //referrel code validation
        {
            Console.WriteLine("Enter the 6 digit code");
            try
            {
                referralCode = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("please Enter only correct input");
                ValidateCode();
            }
            if (referralCode.ToString().Length > 6 || referralCode.ToString().Length < 1)
            {
                ValidateCode();
            }
            return referralCode;
        }
    }
}

