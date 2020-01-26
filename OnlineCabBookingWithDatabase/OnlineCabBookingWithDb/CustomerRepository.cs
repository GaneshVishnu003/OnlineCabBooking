using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Configuration;
using System.Data.SqlClient;

namespace OnlineCabBookingWithDb
{
    class CustomerRepository
    {

        /////////////////////////
        ///

        public static List<Customer> customerList = new List<Customer>();

        //static CustomerRepository()           //initializes automatically as default data 
        //{
        //    Customer tempObject = new Customer();
        //    tempObject.FirstName = "Ganesh";
        //    tempObject.LastName = "Vishnu";
        //    tempObject.MailId = "ganesh@gmail.com";
        //    tempObject.Mobile = 9876543210;
        //    tempObject.Password = "ganesh12345";
        //    tempObject.Location = "Erode";
        //    tempObject.pickLocation = "Kollampalayam";
        //    tempObject.dropLocation = "Solar";
        //    customerList.Add(tempObject);       //adds in the list
        //}

        static string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection dbConnection = new SqlConnection(connectionString);
        public int CustomerDbConnection(Customer custObject)
        {
            int affectedRows;
            try
            {
                dbConnection.Open();
                string command = "insertIntoCustomer";              //stored prodecure
                using(SqlCommand insertCommand=new SqlCommand(command,dbConnection))
                {
                    insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@fname",custObject.FirstName);
                    insertCommand.Parameters.AddWithValue("@lname", custObject.LastName);
                    insertCommand.Parameters.AddWithValue("@mailId", custObject.MailId);
                    insertCommand.Parameters.AddWithValue("@phone", custObject.Mobile);
                    insertCommand.Parameters.AddWithValue("@location", custObject.Location);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.InsertCommand = insertCommand;
                    affectedRows = insertCommand.ExecuteNonQuery();
                }
                return affectedRows;
            }
            catch(Exception e)
            {
                Console.WriteLine("{0}- {1}", e.GetType(), e.Message);
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}
