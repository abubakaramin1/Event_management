using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.IO.RecyclableMemoryStreamManager;

namespace Event_management
{
    public partial class SubtractResources : Form
    {
        long eventId;

        Form5 eventDetails;

        public SubtractResources(Form5 events , long eventid)
        {
            InitializeComponent();
            this.eventId = eventid; // Assign the eventId first
            reloadresources();      // Then call reloadresources
            eventDetails = events;
        }



        public void reloadresources()
        {
            string query = "\t\t \r\nSELECT r.ResourceId, r.ResourceName, er.QuantityUsed\r\nFROM Resources r\r\nINNER JOIN Event_Resources er \r\n    ON r.ResourceID = er.ResourceID\r\nINNER JOIN Events e \r\n    ON er.EventID = e.EventID\r\nWHERE e.EventID = @EventID;";
            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EventID", eventId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable eventDetailsTable = new DataTable();
                adapter.Fill(eventDetailsTable);

                dataGridView1.DataSource = eventDetailsTable;
                dataGridView1.Columns[0].Visible = false;


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool updateSuccessful = false;

            using (SqlConnection conn = new SqlConnection(Class1.connectionString))
            {
                conn.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        object cellValue = row.Cells["QuantityUsed"].Value;
                        int newQuantityUsed = 0;

                        if (cellValue != null && int.TryParse(cellValue.ToString(), out int parsedValue))
                        {
                            newQuantityUsed = parsedValue; // Use the valid value
                        }

                        if (newQuantityUsed > 0)
                        {
                            if (row.Cells["ResourceId"].Value != null && int.TryParse(row.Cells["ResourceId"].Value.ToString(), out int resourceId))
                            {
                                // Query to fetch the current quantity used
                                string getCurrentQuantityQuery = @"
                        SELECT QuantityUsed
                        FROM Event_Resources
                        WHERE ResourceID = @resourceid AND EventID = @eventid";

                                SqlCommand getCurrentCmd = new SqlCommand(getCurrentQuantityQuery, conn);
                                getCurrentCmd.Parameters.AddWithValue("@resourceid", resourceId);
                                getCurrentCmd.Parameters.AddWithValue("@eventid", eventId);

                                var result = getCurrentCmd.ExecuteScalar();

                                if (result != null && int.TryParse(result.ToString(), out int currentQuantityUsed))
                                {
                                    if (newQuantityUsed > currentQuantityUsed)
                                    {
                                        MessageBox.Show($"The new quantity ({newQuantityUsed}) exceeds the existing quantity used ({currentQuantityUsed}). Update skipped for this row.");
                                        continue; // Skip this row
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Failed to retrieve the current quantity used. Update skipped for this row.");
                                    continue; 
                                }

                                string updateQuery = @"
                        UPDATE Event_Resources
                        SET QuantityUsed = @newQuantityUsed
                        WHERE ResourceID = @resourceid AND EventID = @eventid";

                                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("@newQuantityUsed", newQuantityUsed);
                                    updateCmd.Parameters.AddWithValue("@resourceid", resourceId);
                                    updateCmd.Parameters.AddWithValue("@eventid", eventId);

                                    int rowsAffected = updateCmd.ExecuteNonQuery();
                                    if (rowsAffected > 0)
                                    {
                                        updateSuccessful = true;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Row {row.Index + 1}: Invalid ResourceId. Update skipped for this row.");
                            }
                        }
                    }
                }
            }

            if (updateSuccessful)
            {
                MessageBox.Show("Quantities updated successfully!");
            }
            else
            {
                MessageBox.Show("No quantities were updated.");
            }

            this.Close();
        }



        private void SubtractResources_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.eventDetails.reloadresources();
            Class1.CalculateEventCost(eventId);
            this.eventDetails.reloadcost();
        }
    }
}
