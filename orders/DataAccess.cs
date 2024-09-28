

using Microsoft.Data.SqlClient;

namespace orders
{
    public class DataAccess
    {

        private string connectionString;
        //= "Server=desktop-ol5def3; Database=orders; Integrated Security=True; TrustServerCertificate=True;";


        public DataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }



        public SqlConnection connect_to_SQL()
        {


            SqlConnection connection = new SqlConnection(connectionString);
            
                try
                {
                    connection.Open(); // Open the connection
                    
                    
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }


                return connection;
            

        }





        public void insert_record(SqlConnection cnn, string tableName, Dictionary<string, object> columns)
            {
                var columnNames = string.Join(", ", columns.Keys);
                var parameterNames = string.Join(", ", columns.Keys.Select(k => "@" + k));

                string sql = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";
                using (SqlCommand command = new SqlCommand(sql, cnn))
                {

                    foreach (var column in columns)
                    {
                        command.Parameters.AddWithValue("@" + column.Key, column.Value);
                    }

                    command.ExecuteNonQuery();
                    Console.WriteLine("record Inserted!");
                }


            }









        }
}


