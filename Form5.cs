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

namespace Event_management
{
    public partial class Form5 : Form
    {
        private int eventId;
        public Form5(int eventId)
        {
            InitializeComponent();
            this.eventId = eventId;
            LoadEventDetails();
        }

        private void LoadEventDetails()
        {
            try
            {
                string query = "select * from Resources where ResourceID in(" +
                               "select ResourceID from Event_Resources where EventID = @EventID)";
                string attendeeQuery = "select * from Attendees where AttendeeID in( " +
                    "select AttendeeID from Event_Attendees where EventID in (@EventID))";
                string estimatedQuery = "select EstimatedBudget from Budget where EventID in (@EventID)";
                string actualQuery = "select ActualCost from Budget where EventID in (@EventID)";
                string organizerQuery = "select OrganizerName from Organizers where OrganizerID in ( select OrganizerID from Events where EventID in (@EventID))";
                string dateQuery = "\r\nselect eventDate from Events where EventID in (@EventID)";
                string venueQuery = "SELECT VenueName FROM Venues WHERE VenueID = (SELECT VenueID FROM Events WHERE EventID = @EventID)";
                string connectionString = "Server=DESKTOP-ECBNEFI;Database=event_management;User Id=abubakar111;Password=abubakar111;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable eventDetailsTable = new DataTable();
                    adapter.Fill(eventDetailsTable);

                    dataGridView1.DataSource = eventDetailsTable;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(attendeeQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable eventDetailsTable = new DataTable();
                    adapter.Fill(eventDetailsTable);

                    dataGridView2.DataSource = eventDetailsTable;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(venueQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();  // ExecuteScalar returns a single value

                    if (result != null)
                    {
                        textBox1.Text = result.ToString();
                    }
                    else
                    {
                        textBox1.Text = "Venue: Not Available";
                    }
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(estimatedQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();  // ExecuteScalar returns a single value

                    if (result != null)
                    {
                        textBox2.Text = result.ToString();
                    }
                    else
                    {
                        textBox2.Text = "Venue: Not Available";
                    }
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(actualQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();  // ExecuteScalar returns a single value

                    if (result != null)
                    {
                        textBox3.Text = result.ToString();
                    }
                    else
                    {
                        textBox3.Text = "Venue: Not Available";
                    }
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(organizerQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();  // ExecuteScalar returns a single value

                    if (result != null)
                    {
                        textBox4.Text = result.ToString();
                    }
                    else
                    {
                        textBox4.Text = "Venue: Not Available";
                    }
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
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
                        textBox5.Text = "Venue: Not Available";
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

        
    }
}
