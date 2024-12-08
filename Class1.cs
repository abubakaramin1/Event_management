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
        public static void CalculateEventCost(long eventId)
        {
            decimal venueCost = 0;
            decimal totalResourceCost = 0;
            decimal profitPercentage = 0;

            try
            {
                // Get the venue cost for the event
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    string venueCostQuery = "SELECT Cost FROM Venues WHERE VenueID = (SELECT VenueID FROM Events WHERE EventID = @EventID)";
                    SqlCommand cmd = new SqlCommand(venueCostQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();

                    if (result != null && decimal.TryParse(result.ToString(), out venueCost))
                    {
                        // Venue cost fetched successfully
                    }
                    else
                    {
                        MessageBox.Show("Error fetching venue cost.");
                        return;
                    }
                }

                // Calculate the resource costs for the event
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    string resourceCostQuery = @"
                SELECT r.Cost * er.QuantityUsed
                FROM Event_Resources er
                JOIN Resources r ON er.ResourceID = r.ResourceID
                WHERE er.EventID = @EventID";
                    SqlCommand cmd = new SqlCommand(resourceCostQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        decimal resourceCost = reader.GetDecimal(0);  // Cost * Quantity
                        totalResourceCost += resourceCost;
                    }
                }

                // Get profit percentage for the event
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    string profitQuery = "SELECT ProfitPercentage FROM Events WHERE EventID = @EventID";
                    SqlCommand cmd = new SqlCommand(profitQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();

                    if (result != null && decimal.TryParse(result.ToString(), out profitPercentage))
                    {
                        profitPercentage = profitPercentage / 100;
                    }
                    else
                    {
                        MessageBox.Show("Error fetching profit percentage.");
                        return;
                    }
                }

                // Calculate total cost
                decimal totalEventCost = venueCost + totalResourceCost;
                decimal profit = totalEventCost * profitPercentage;
                decimal finalCost = totalEventCost + profit;

                finalCost = Math.Round(finalCost, 2);

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    string updateCostQuery = "UPDATE Events SET ActualCost = @ActualCost WHERE EventID = @EventID";
                    SqlCommand cmd = new SqlCommand(updateCostQuery, connection);
                    cmd.Parameters.AddWithValue("@ActualCost", finalCost);
                    cmd.Parameters.AddWithValue("@EventID", eventId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Failed to update event cost.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating event cost: {ex.Message}");
            }
        }



    }
}
