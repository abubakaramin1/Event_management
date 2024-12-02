using Microsoft.VisualBasic.ApplicationServices;
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

namespace Event_management
{

    public partial class Form5 : Form
    {
        private int eventId;
        private bool isLoading = false;
        adminForm1 Listingformobj;

        public Form5(int eventId)
        {
            InitializeComponent();
            this.eventId = eventId;
            // Store the reference to the existing AdminForm1
            this.Shown += Form5_Shown;
            this.FormClosed += Form5_FormClosed;
        }

        public Form5(int eventId, Form listingForm)
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

        public void LoadEventDetails()
        {
            try
            {
                string attendeeQuery = "select * from UserLoginInfo where Id in( " +
                    "select AttendeeID from Event_Attendees where EventID in (@EventID))";
                string estimatedQuery = "select Budget from Events where EventID = @EventID";
                string actualQuery = "select ActualCost from Events where EventID = @EventID";
                string organizerQuery = "select FullName from UserLoginInfo where Id in ( select OrganizerID from Events where EventID in (@EventID))";
                string dateQuery = "\r\nselect eventDate from Events where EventID = @EventID";
                string venueQuery = "SELECT VenueName FROM Venues WHERE VenueID = (SELECT VenueID FROM Events WHERE EventID = @EventID)";
                string organizer = "select FullName from UserLoginInfo where Id in ( select OrganizerID from Events where EventID in (@EventID))";
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(organizer, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        textBox1.Text = result.ToString();
                    }
                    else
                    {
                        textBox1.Text = "Organizer: Not Available";
                    }
                }
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
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(venueQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        comboBoxVenue.Text = result.ToString();
                    }
                    else
                    {
                        comboBoxVenue.Text = "Venue: Not Available";
                    }
                }
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(estimatedQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        textBox2.Text = result.ToString();
                    }
                    else
                    {
                        textBox2.Text = "Budget : Not available";
                    }
                }
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(actualQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    object result = cmd.ExecuteScalar();

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
                    SqlCommand cmd = new SqlCommand(organizerQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string organizerName = result.ToString();
                        LoadOrganizerNames(); // Populate the ComboBox

                        // Set the selected organizer
                        comboBoxOrganizer.SelectedItem = organizerName;
                    }
                    else
                    {
                        comboBoxOrganizer.Text = "Organizer: Not Available";
                    }
                }
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(dateQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();  // ExecuteScalar returns a single value

                    if (result != null)
                    {
                        DateTime eventDate = Convert.ToDateTime(result);
                        textBox5.Text = eventDate.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        textBox5.Text = "Date : Not Available";
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
            reloadresources();
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

                        // Refresh the listing in AdminForm1


                        // Close Form5
                        this.Close();
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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }



}

