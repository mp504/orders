using Microsoft.Data.SqlClient;
using System.Security.Cryptography;


namespace orders
{
    public class ordering
    {
        
        


        public void order(string connectionString,int CID)
        {



            
            bool isValid = false;
            int orderNum= 0;
            while (!isValid)
            {
                Console.WriteLine(@"what is your order name:
                      1-Pizza 30 SAR.
                      2-Burger 20 SAR.
                      3-Shawrma 10 SAR.
                    Write the number only!
                    ");
                string order_name = Console.ReadLine();
                if (int.TryParse(order_name, out orderNum))
                {
                    if(orderNum != 0)  isValid = true; // Exit loop on successful conversion
                }
                else
                {

                }


                int price = 0;
                switch (orderNum)
                {

                    case 1:
                        price = 30;
                        Console.WriteLine("you choosed pizza.");
                        order_name = "Pizza";
                        break;

                    case 2:
                        price = 20;
                        Console.WriteLine("you choosed Burger.");
                        order_name = "Burger";
                        break;

                    case 3:
                        price = 10;
                        Console.WriteLine("you choosed Shawrma.");
                        order_name = "Shawrma";
                        break;

                    default:
                        Console.WriteLine("order does not Exists!!");
                        return;



                }
                Console.WriteLine("what is the quantity:");
                isValid = false;
                int quantity_result = 0;
                while (!isValid)
                {
                    Console.WriteLine("Enter the quantity:");
                    string quantity = Console.ReadLine();
                    if (int.TryParse(quantity, out quantity_result)  )
                    {

                        if (quantity_result != 0)  isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Try again.");
                    }
                }
                price = quantity_result * price;
                manageRecords addOrder = new manageRecords();
                addOrder.add_order( connectionString, CID, price, order_name, quantity_result);







            }
        }



        public void display_orders(String ConnectionString)
        {



            string query = "SELECT * FROM orders";

            DataAccess dataAccess = new DataAccess(ConnectionString);
            using (SqlConnection cnn = dataAccess.connect_to_SQL())
            {
                try
                {



                    SqlCommand command = new SqlCommand(query, cnn);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader.GetName(i) + "\t");
                            }
                            Console.WriteLine();


                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write(reader[i] + "\t");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }


        }


        public void display_customers(string connectionString)
        {



            string query = "SELECT * FROM customers";

            DataAccess dataAccess = new DataAccess(connectionString);
            using (SqlConnection cnn = dataAccess.connect_to_SQL())
            {
                try
                {



                    SqlCommand command = new SqlCommand(query, cnn);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            // print headers
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader.GetName(i) + "\t");
                            }
                            Console.WriteLine();


                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write(reader[i] + "\t");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }


            }
        }



    }
}
