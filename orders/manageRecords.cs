using Microsoft.Data.SqlClient;

namespace orders
{
    public class manageRecords
    {

        //private static string connectionString = "Server=desktop-ol5def3; Database=orders; Integrated Security=True; TrustServerCertificate=True;";


        public void add_order(string connectionString ,int customer_id, int price, string order_name, int quantity)
        {

            DataAccess insertion = new DataAccess(connectionString);
            
            var data = new Dictionary<string, object>();
            data.Add("customerID", customer_id);
            data.Add("price", price);
            data.Add("order_name",order_name);
            data.Add("quantity", quantity);


            SqlConnection cnn = insertion.connect_to_SQL();
            
            insertion.insert_record(cnn, "orders",data);
            cnn.Close();

        }


        public void add_customer(string connectionString, int cID, string Cname)
        {
            DataAccess insertion = new DataAccess(connectionString);
            
            var data = new Dictionary<string, object>();
             data.Add("customerID", cID);
             data.Add("CustomerName", Cname);
            SqlConnection cnn = insertion.connect_to_SQL();

            insertion.insert_record(cnn, "customers", data);


        }



        public Boolean check_customer(string connectionString, int cID)
        {
            int count = 0;
            DataAccess Checking = new DataAccess(connectionString);
            string query = "SELECT COUNT(1) FROM customers WHERE customerID = @customerID";
            SqlConnection cnn = Checking.connect_to_SQL();
            using (SqlCommand command = new SqlCommand(query, cnn))
            {


                command.Parameters.AddWithValue("@customerID", cID);
                cnn = Checking.connect_to_SQL();
                 count = (int)command.ExecuteScalar();
                cnn.Close();
            }

            return count > 0;

        }









    }
}
