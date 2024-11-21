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
       
            private string connectionString = "Data Source=(local);Initial Catalog=event_management;Integrated Security=True;TrustServerCertificate=True";

            public DataSet ConnectToDatabase()
            {
            string query = "select ev.EventID , ev.EventName as [Event Name] , ev.EventDate as [Date] , v.VenueName as Venue , o.FullName as [Organizer] ,ev.Budget,ev.[Description] , ow.FullName as [Owner]from [Events] ev\r\nleft join Venues v on v.VenueID=ev.VenueID\r\nleft join UserLoginInfo o on o.Id=ev.OrganizerID\r\nleft join UserLoginInfo ow on ow.Id=OwnerID\r\n";
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
