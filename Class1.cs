﻿using System;
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
        public static int organizer_flag = 1;
        public static string name;

        public static void showorganizers(ComboBox comboBox)
        {
            try
            {
                string query = "select FullName from UserLoginInfo\r\nwhere CatUserRoleId = 2";

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    comboBox.Items.Clear();

                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader["FullName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading organizer names: {ex.Message}");
            }
        }

        public static DataTable loadvenues()
        {
            string attendeeQuery = "select * from Venues";
            DataTable eventDetailsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(attendeeQuery, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(eventDetailsTable);
            }

            return eventDetailsTable;
        }

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
                        decimal resourceCost = reader.GetDecimal(0);  
                        totalResourceCost += resourceCost;
                    }
                }

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

                decimal totalEventCost = venueCost + totalResourceCost;
                decimal profit = totalEventCost * profitPercentage;
                decimal finalCost = totalEventCost + profit;


                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    string Query = "UPDATE Events SET ExpenseAmount = @expense WHERE EventID = @EventID";
                    SqlCommand cmd = new SqlCommand(Query, connection);
                    cmd.Parameters.AddWithValue("@expense", totalEventCost);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    cmd.ExecuteNonQuery();

                }


                    finalCost = Math.Round(finalCost, 2);

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    string updateCostQuery = "UPDATE Events SET ActualCost = @ActualCost , ProfitAmount = @ProfitAmount\r\n WHERE EventID = @EventID";
                    SqlCommand cmd = new SqlCommand(updateCostQuery, connection);
                    cmd.Parameters.AddWithValue("@ActualCost", finalCost);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    cmd.Parameters.AddWithValue("@ProfitAmount", profit);


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

        public static void UpdateEventStatuses()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("UpdateEventStatuses", connection);
                    command.CommandType = CommandType.StoredProcedure;

                   command.ExecuteNonQuery();

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating event statuses: {ex.Message}");
            }
        }

        public static void UpdatePaymentStatusToOverdue()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) // Replace 'connectionString' with your actual connection string
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdatePaymentStatusToOverdue", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery(); // Execute the stored procedure
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating payment statuses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
