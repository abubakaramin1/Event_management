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
    public partial class AddVenue : Form
    {
        frm_venues frm_Venues = new frm_venues();
        public AddVenue(frm_venues venues)
        {
            InitializeComponent();
            frm_Venues = venues;
        }
        public AddVenue()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string venueName = txtname.Text.Trim();
            string location = txtloc.Text.Trim();
            string capacityText = txtcapacity.Text.Trim();
            string costText = txtcost.Text.Trim();

            // Validate inputs
            if (string.IsNullOrWhiteSpace(venueName))
            {
                MessageBox.Show("Venue Name is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("Location is required.");
                return;
            }

            if (!int.TryParse(capacityText, out int capacity) || capacity <= 0)
            {
                MessageBox.Show("Capacity must be a positive integer.");
                return;
            }

            if (!decimal.TryParse(costText, out decimal cost) || cost <= 0)
            {
                MessageBox.Show("Cost must be a non-negative number.");
                return;
            }

            // Database connection and insertion
            string query = "INSERT INTO Venues (VenueName, Location, Capacity, Cost) VALUES (@VenueName, @Location, @Capacity, @Cost)";
            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VenueName", venueName);
                    command.Parameters.AddWithValue("@Location", location);
                    command.Parameters.AddWithValue("@Capacity", capacity);
                    command.Parameters.AddWithValue("@Cost", cost);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Venue added successfully.");
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Error: Venue could not be added.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
        }

        private void AddVenue_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Class1.venue_flag == 1)
            {
                frm_Venues.showvenues();
            }
        }
    }
}
