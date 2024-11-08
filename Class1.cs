using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_management
{
    internal class Class1
    {
       
            private string connectionString = "Server=DESKTOP-ECBNEFI;Database=event_management;User Id=abubakar111;Password=abubakar111;";

            public DataSet ConnectToDatabase()
            {
            string query = "Select * from Events";
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    
                    adapter.Fill(ds);

                }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection failed: " + ex.Message);
                    }
                
               return ds;

            }
            
        }
    }
}
