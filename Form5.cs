﻿using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using QRCoder;

namespace Event_management
{

    public partial class Form5 : Form
    {
        private long eventId;
        string originalprofit;
        string originalvenue;

        private bool isLoading = false;
        adminForm1 Listingformobj;

        public Form5(long eventId)
        {
            InitializeComponent();
            this.eventId = eventId;
            // Store the reference to the existing AdminForm1
            this.Shown += Form5_Shown;
            this.FormClosed += Form5_FormClosed;
        }

        public Form5(long eventId, Form listingForm)
        {
            InitializeComponent();
            this.eventId = eventId;
            // Store the reference to the existing AdminForm1
            this.Shown += Form5_Shown;
            this.FormClosed += Form5_FormClosed;
        }


        public void reloadresources()
        {
            string query = "\t\t \r\nSELECT r.ResourceName, r.Quantity, r.Cost, er.QuantityUsed\r\nFROM Resources r\r\nINNER JOIN Event_Resources er \r\n    ON r.ResourceID = er.ResourceID\r\nINNER JOIN Events e \r\n    ON er.EventID = e.EventID\r\nWHERE e.EventID = @EventID;";
            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EventID", eventId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable eventDetailsTable = new DataTable();
                adapter.Fill(eventDetailsTable);

                dataGridView1.DataSource = eventDetailsTable;

                HighlightExceededQuantities();
            }
        }

        public void reloadattendees()
        {
            string attendeeQuery = "select * from UserLoginInfo where Id in( " +
                    "select AttendeeID from Event_Attendees where EventID in (@EventID))";
            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(attendeeQuery, connection);
                cmd.Parameters.AddWithValue("@EventID", eventId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable eventDetailsTable = new DataTable();
                adapter.Fill(eventDetailsTable);

                dataGridView2.DataSource = eventDetailsTable;
            }
        }

        public void reloadcost()
        {
            string actualQuery = "SELECT ActualCost FROM Events WHERE EventID = @EventID";
            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                connection.Open();

                // Actual Cost Query
                SqlCommand cmd = new SqlCommand(actualQuery, connection);
                cmd.Parameters.AddWithValue("@EventID", eventId);
                var result = cmd.ExecuteScalar();

                if (!Convert.IsDBNull(result))
                {
                    textBox3.Text = result.ToString();
                }
                else
                {
                    textBox3.Text = "Cost: Not Available";
                }
            }
        }

        public void LoadEventDetails()
        {
            try
            {
                string attendeeQuery = "SELECT * FROM UserLoginInfo WHERE Id IN ( " +
                                       "SELECT AttendeeID FROM Event_Attendees WHERE EventID = @EventID)";
                string estimatedQuery = "SELECT Budget FROM Events WHERE EventID = @EventID";
                string actualQuery = "SELECT ActualCost FROM Events WHERE EventID = @EventID";
                string organizerQuery = "SELECT FullName FROM UserLoginInfo WHERE Id IN ( SELECT OrganizerID FROM Events WHERE EventID = @EventID)";
                string dateQuery = "SELECT EventDate FROM Events WHERE EventID = @EventID";
                string venueQuery = "SELECT VenueName FROM Venues WHERE VenueID = (SELECT VenueID FROM Events WHERE EventID = @EventID)";
                string profitQuery = "SELECT ProfitPercentage FROM Events WHERE EventID = @EventID";
                string query = "\t\t \r\nSELECT r.ResourceName, r.Quantity, r.Cost, er.QuantityUsed\r\nFROM Resources r\r\nINNER JOIN Event_Resources er \r\n    ON r.ResourceID = er.ResourceID\r\nINNER JOIN Events e \r\n    ON er.EventID = e.EventID\r\nWHERE e.EventID = @EventID;";
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable eventDetailsTable = new DataTable();
                    adapter.Fill(eventDetailsTable);

                    dataGridView1.DataSource = eventDetailsTable;

                    HighlightExceededQuantities();
                }

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    // Organizer Query
                    SqlCommand cmd = new SqlCommand(organizerQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        textBox1.Text = result.ToString();
                        comboBoxOrganizer.Text = result.ToString();
                    }
                    else
                    {
                        textBox1.Text = "Organizer: Not Available";
                    }
                }

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    // Attendee Query
                    SqlCommand cmd = new SqlCommand(attendeeQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable eventDetailsTable = new DataTable();
                    adapter.Fill(eventDetailsTable);

                    dataGridView2.DataSource = eventDetailsTable;
                }

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    // Venue Query
                    SqlCommand cmd = new SqlCommand(venueQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        originalvenue = comboBoxVenue.Text = result.ToString();
                    }
                    else
                    {
                        comboBoxVenue.Text = "Venue: Not Available";
                    }
                }

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    // Estimated Budget Query
                    SqlCommand cmd = new SqlCommand(estimatedQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        textBox2.Text = result.ToString();
                    }
                    else
                    {
                        textBox2.Text = "Budget: Not Available";
                    }
                }

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    // Actual Cost Query
                    SqlCommand cmd = new SqlCommand(actualQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();

                    if (!Convert.IsDBNull(result))
                    {
                        textBox3.Text = result.ToString();
                    }
                    else
                    {
                        textBox3.Text = "Cost: Not Available";
                    }
                }

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    // Date Query
                    SqlCommand cmd = new SqlCommand(dateQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        DateTime eventDate = Convert.ToDateTime(result);
                        textBox5.Text = eventDate.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        textBox5.Text = "Date: Not Available";
                    }
                }

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    // Profit Query
                    SqlCommand cmd = new SqlCommand(profitQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        originalprofit = result.ToString();
                        textBoxProfit.Text = result.ToString() + " %";
                    }
                    else
                    {
                        textBoxProfit.Text = "Profit: Not Available";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading event details: {ex.Message}");
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {


        }
        private void Form5_Shown(object sender, EventArgs e)
        {

            LoadEventDetails();
            if (Class1.login_flag == 1)
            {
                LoadOrganizerNames();
                textBox1.Visible = false;

            }
            else
            {

                comboBoxOrganizer.Visible = false;
            }
            LoadVenues();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form eventDetail = new Form5(this.eventId);
            foreach (Form child in this.MdiParent.MdiChildren)
            {
                if (child.Text == "Form5")
                    eventDetail = child;
            }

            Frm_ResourcesAdd frm_ResourcesAdd = new Frm_ResourcesAdd(eventDetail, eventId);
            frm_ResourcesAdd.Show();
        }

        public void HighlightExceededQuantities()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    object quantityUsedValue = row.Cells["QuantityUsed"].Value;
                    object quantityValue = row.Cells["Quantity"].Value;

                    if (quantityUsedValue != null && quantityValue != null &&
                        int.TryParse(quantityUsedValue.ToString(), out int quantityUsed) &&
                        int.TryParse(quantityValue.ToString(), out int quantity))
                    {
                        if (quantityUsed > quantity)
                        {

                            row.Cells["QuantityUsed"].Style.ForeColor = Color.Red;
                        }
                        else
                        {

                            row.Cells["QuantityUsed"].Style.ForeColor = Color.Green;
                        }
                    }
                }
            }
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            adminForm1 adminForm = new adminForm1();
            adminForm.MdiParent = this.MdiParent;
            adminForm.Show();

        }



        private void ImportAttendeesToEvent(string filePath, long eventId)
        {
            DataTable attendeesTable = new DataTable();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                attendeesTable.Columns.Add("FullName");
                attendeesTable.Columns.Add("Email");
                attendeesTable.Columns.Add("PhoneNumber");

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    DataRow dr = attendeesTable.NewRow();
                    dr["FullName"] = worksheet.Cells[row, 1].Text;
                    dr["Email"] = worksheet.Cells[row, 2].Text;
                    dr["PhoneNumber"] = worksheet.Cells[row, 3].Text;
                    attendeesTable.Rows.Add(dr);
                }
            }

            // Step 1: Insert into UserLoginInfo and get inserted IDs
            List<long> attendeeIds = InsertAttendeesIntoUserLoginInfo(attendeesTable);

            // Step 2: Insert into Event_Attendees
            if (attendeeIds.Count > 0)
            {
                MapAttendeesToEvent(attendeeIds, eventId);
                DialogResult result = MessageBox.Show("Attendees imported and mapped to the event successfully!");
                if (result == DialogResult.OK)
                {
                    reloadattendees();
                }
            }
            else
            {
                MessageBox.Show("No attendees were added.");
            }
        }

        private List<long> InsertAttendeesIntoUserLoginInfo(DataTable attendeesTable)
        {
            List<long> insertedIds = new List<long>();

            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                string query = @"
            INSERT INTO UserLoginInfo (FullName, Email, CatUserRoleId , PhoneNumber) 
            OUTPUT INSERTED.Id 
            VALUES (@FullName, @Email,@role, @PhoneNumber)";

                try
                {
                    connection.Open();

                    foreach (DataRow row in attendeesTable.Rows)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@FullName", row["FullName"]);
                            command.Parameters.AddWithValue("@Email", row["Email"]);
                            command.Parameters.AddWithValue("@PhoneNumber", row["PhoneNumber"]);
                            command.Parameters.AddWithValue("@role", 4);

                            object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                insertedIds.Add(Convert.ToInt32(result));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while inserting attendees: {ex.Message}");
                }
            }

            return insertedIds;
        }

        private void MapAttendeesToEvent(List<long> attendeeIds, long eventId)
        {
            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                string query = @"
            INSERT INTO Event_Attendees (EventId, AttendeeId)
            VALUES (@EventId, @AttendeeId)";

                try
                {
                    connection.Open();

                    foreach (int attendeeId in attendeeIds)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@EventId", eventId);
                            command.Parameters.AddWithValue("@AttendeeId", attendeeId);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while mapping attendees to the event: {ex.Message}");
                }
            }
        }



        private void LoadOrganizerNames()
        {
            try
            {
                // Define query to fetch organizer names
                string query = "select FullName from UserLoginInfo\r\nwhere CatUserRoleId = 2";

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Clear any existing items in the ComboBox
                    comboBoxOrganizer.Items.Clear();

                    // Populate the ComboBox with organizer names
                    while (reader.Read())
                    {
                        comboBoxOrganizer.Items.Add(reader["FullName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading organizer names: {ex.Message}");
            }
        }

        private void LoadVenues()
        {
            try
            {
                string query = "select VenueName from Venues";
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    comboBoxVenue.Items.Clear();
                    while (reader.Read())
                    {
                        comboBoxVenue.Items.Add(reader["VenueName"].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading venues: {ex.Message}");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string profitText = null;
            string venue = null;
            try
            {
                // Initialize query parts
                string query = "UPDATE Events SET ";
                List<string> updateFields = new List<string>();
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                // Check and add fields to update if they have been modified
                if (comboBoxOrganizer.SelectedItem != null)
                {
                    updateFields.Add("OrganizerID = (SELECT Id FROM UserLoginInfo WHERE FullName = @OrganizerName)");
                    parameters["@OrganizerName"] = comboBoxOrganizer.SelectedItem.ToString();
                }

                if (comboBoxVenue.SelectedItem != null)
                {
                    updateFields.Add("VenueID = (SELECT VenueID FROM Venues WHERE VenueName = @VenueName)");
                    venue = comboBoxVenue.SelectedItem.ToString();
                    parameters["@VenueName"] = comboBoxVenue.SelectedItem.ToString();
                }

                if (!string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    if (DateTime.TryParseExact(textBox5.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                    {
                        updateFields.Add("EventDate = @EventDate");
                        parameters["@EventDate"] = parsedDate;
                    }
                    else
                    {
                        MessageBox.Show("Invalid date format! Use 'dd-MM-yyyy'.");
                        return;
                    }
                }

                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    if (decimal.TryParse(textBox2.Text, out decimal parsedBudget))
                    {
                        updateFields.Add("Budget = @Budget");
                        parameters["@Budget"] = parsedBudget;
                    }
                    else
                    {
                        MessageBox.Show("Invalid budget format! Please enter a numeric value.");
                        return;
                    }
                }

                if (!string.IsNullOrWhiteSpace(textBoxProfit.Text))
                {
                    profitText = textBoxProfit.Text.Trim();

                    // Remove the '%' sign if it exists
                    if (profitText.EndsWith("%"))
                    {
                        profitText = profitText.TrimEnd('%');
                    }

                    profitText = profitText.Trim();

                    // Attempt to parse the profit value
                    if (decimal.TryParse(profitText, out decimal parsedProfit))
                    {
                        updateFields.Add("ProfitPercentage = @Profit");
                        parameters["@Profit"] = parsedProfit;
                    }
                    else
                    {
                        MessageBox.Show("Invalid profit format! Please enter a numeric value.");
                        return;
                    }
                }

                // If no fields are modified, show a message and return
                if (updateFields.Count == 0)
                {
                    MessageBox.Show("No fields have been modified!");
                    return;
                }

                // Combine query
                query += string.Join(", ", updateFields) + " WHERE EventID = @EventID";

                // Execute the query
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Add parameters
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                    cmd.Parameters.AddWithValue("@EventID", eventId);

                    // Execute the update
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Event details updated successfully!");

                        if (originalprofit != profitText || originalvenue != venue)
                        {
                            Class1.CalculateEventCost(eventId);

                        }
                        LoadEventDetails();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update event details. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating event details: {ex.Message}");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Select an Excel File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ImportAttendeesToEvent(filePath, eventId);

            }
        }
       

        private List<(string AttendeeName, string EventName, DateTime EventDate, string VenueName, string TicketID)> FetchTicketData(long eventId)
        {
            var ticketData = new List<(string AttendeeName, string EventName, DateTime EventDate, string VenueName, string TicketID)>();

            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                connection.Open();

                string query = @"
        SELECT 
                UI.FullName AS AttendeeName,  
                E.EventName,
                E.EventDate,
                V.VenueName,
                CONCAT(E.EventID, '-', EA.AttendeeID) AS TicketID
            FROM 
                Event_Attendees EA
            JOIN Events E ON EA.EventID = E.EventID
            JOIN Venues V ON E.VenueID = V.VenueID
            JOIN UserLoginInfo UI ON EA.AttendeeID = UI.Id  
            WHERE E.EventID = @EventID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EventID", eventId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ticketData.Add((
                        reader["AttendeeName"].ToString(),
                        reader["EventName"].ToString(),
                        Convert.ToDateTime(reader["EventDate"]).Date,
                        reader["VenueName"].ToString(),
                        reader["TicketID"].ToString()
                    ));
                }
            }

            return ticketData;
        }

      


       

        private void button3_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderDialog.SelectedPath;
                    // Generate ticket data (this method only fetches data)
                    var tickets = FetchTicketData(eventId);

                    // Open the TicketPreviewForm to show thumbnails
                    TicketPreviewForm previewForm = new TicketPreviewForm(tickets, selectedFolder, eventId);
                    previewForm.ShowDialog(); // Show the form as a dialog
                }
            }
        }
    }
}

