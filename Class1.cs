using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_management
{
    static class Class1
    {
       public static long organizerID;
        public static string connectionString = "Data Source=(local);Initial Catalog=event_management;Integrated Security=True;TrustServerCertificate=True";
        public static int login_flag;
        public static int add_flag;
        public static DataSet populateeventlisting(string query)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                try
                {
                    connection.Open();


                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@organizerid", organizerID);
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
