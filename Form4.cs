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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Event_management
{


    public partial class Form4 : Form
    {
        string connectionString;
        Form3 Listingformobj;
        private long userId;


        public Form4(Form listingform,long id)
        {
            InitializeComponent();
            Listingformobj = (Form3)listingform;
            this.userId = id;
        }

        


        private void Form4_Load(object sender, EventArgs e)
        {
            connectionString = "Data Source=(local);Initial Catalog=event_management;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT * FROM Venues";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open connection
                    connection.Open();

                    SqlDataReader reader;

                    // Execute query
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        reader = command.ExecuteReader();


                        venueBox.Items.Clear();


                        while (reader.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Id = Convert.ToInt32(reader["VenueID"]),
                                Text = reader["VenueName"].ToString()
                            };
                            venueBox.Items.Add(item);
                        }

                        reader.Close();

                    }
                    query = "Select Id,FullName from UserLoginInfo where CatUserRoleId = 3";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        reader = command.ExecuteReader();


                        comboBox2.Items.Clear();


                        while (reader.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Text = reader["FullName"].ToString()
                            };
                            comboBox2.Items.Add(item);
                        }

                        reader.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string EventName = textBox1.Text;
            DateTime EventDate = dateTimePicker1.Value.Date;
            int VenueID = ((ComboBoxItem)venueBox.SelectedItem).Id;
            decimal Budget = decimal.Parse(textBox3.Text);
            string Description = textBox4.Text;
            int OwnerID = ((ComboBoxItem)comboBox2.SelectedItem).Id;

            string query = "INSERT INTO Events (EventName, EventDate, VenueID, OrganizerID, Budget, Description, OwnerID) " +
                   "VALUES (@EventName, @EventDate, @VenueID,@OrganizerID, @Budget, @Description, @OwnerID)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventName", EventName);
                    command.Parameters.AddWithValue("@EventDate", EventDate);
                    command.Parameters.AddWithValue("@VenueID", VenueID);
                    command.Parameters.AddWithValue("@Budget", Budget);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@OwnerID", OwnerID);
                    command.Parameters.AddWithValue("@OrganizerID", userId);

                    try
                    {

                        connection.Open();


                        int rowsAffected = command.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Event added successfully.");
                            this.Close();
                           Listingformobj.populateeventlisting();

                        }
                        else
                        {
                            MessageBox.Show("Error occured in registering event");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }






        }
    }

    public class ComboBoxItem
    {
        public int Id { get; set; }
        public string Text { get; set; }

        // Override ToString to show the text in the ComboBox
        public override string ToString()
        {
            return Text;
        }
    }
}
