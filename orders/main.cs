
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Threading.Channels;

namespace orders
{
    public class main
    {

         
        public static void Main(String[] args)
        {

            string connectionString = "Server=DESKTOP-B55SNFG; Database=orders; Integrated Security=True; TrustServerCertificate=True;";

            ordering ordering = new ordering();
            
            manageRecords manageRecords = new manageRecords();

           

            string value;
            bool isValid = false;


            do
            {
                Console.WriteLine("Do you want to order (y/n):");
                value = Console.ReadLine();
                if (value != "y" && value != "Y")
                {
                    break;

                }
                int cID = 0;
                while (!isValid)
                {
                    Console.WriteLine("Enter you Customer ID:");
                    
                    string customerID = Console.ReadLine();
                    if (int.TryParse(customerID, out cID))
                    {
                        if (cID != 0) isValid = true; 
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Try again.");
                    }
                }
                
                     
              
                
                if (manageRecords.check_customer(connectionString, cID))
                {


                    Console.WriteLine("customer exists! ");
                    ordering.order(connectionString, cID);

                   







                }
                else
                {

                    Console.WriteLine("Customer ID does not exists!");
                    Console.WriteLine("Adding new customer.");
                    cID = 0;
                    isValid = false;
                    while (!isValid)
                    {
                        Console.WriteLine("Enter you Customer ID:");
                        string customerID = Console.ReadLine();
                        if (int.TryParse(customerID, out cID))
                        {
                            if (cID != 0) isValid = true; 
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Try again.");
                        }
                    }


                    
                   
                    while (manageRecords.check_customer(connectionString,cID))
                    {
                        Console.WriteLine("this ID exists! ENTER another ID:");
                        cID = 0;
                        isValid = false;
                        while (!isValid)
                        {
                            Console.WriteLine("Enter you Customer ID:");
                            string customerID = Console.ReadLine();
                            if (int.TryParse(customerID, out cID))
                            {
                                if (cID != 0) isValid = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Try again.");
                            }
                        }


                    }
                    Console.WriteLine("ID Accepted!");



                    Console.WriteLine("Enter Your Name:");
                    string CName = Console.ReadLine();
                    Console.WriteLine("name accepted");
                    manageRecords.add_customer(connectionString, cID, CName);
                    Console.WriteLine("Customer added!");
                    ordering.order(connectionString, cID);
                 






                }

            } while (true);

            ordering.display_customers(connectionString);
            ordering.display_orders(connectionString);
            Console.WriteLine("Connection closed.");



        }





    }

}