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
    public partial class AdminForm2 : Form
    {
        string connectionString = Class1.connectionString;
        adminForm1 Listingformobj;
        private long userId;

        public AdminForm2(Form listingform, long id)
        {
            InitializeComponent();
            Listingformobj = (adminForm1)listingform;
            this.userId = id;
        }


        private void AdminForm2_Load(object sender, EventArgs e)
        {

            string query = "SELECT * FROM Venues";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader;

                    // Populate Venues
                    using (SqlCommand command = new SqlCommand(query, connection))

                    {
                        reader = command.ExecuteReader();
                        comboBox1.Items.Clear();
                        while (reader.Read())
                        {
                            ComboBoxItem item = new ComboBoxItem
                            {
                                Id = Convert.ToInt32(reader["VenueID"]),
                                Text = reader["VenueName"].ToString()
                            };
                            comboBox1.Items.Add(item);
                        }
                        reader.Close();
                    }

                    // Check if any items were added
                    if (comboBox1.Items.Count == 0)
                    {
                        MessageBox.Show("No venues found.");
                    }

                    // Populate Event Owners
                    query = "SELECT Id, FullName FROM UserLoginInfo WHERE CatUserRoleId = 3";
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

                    if (Class1.login_flag == 1)
                    {
                        query = "SELECT Id, FullName FROM UserLoginInfo WHERE CatUserRoleId = 2";
                        using (SqlCommand command = new SqlCommand(query, connection))

                        {
                            reader = command.ExecuteReader();
                            comboBox3.Items.Clear();
                            while (reader.Read())
                            {
                                ComboBoxItem item = new ComboBoxItem
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Text = reader["FullName"].ToString()
                                };
                                comboBox3.Items.Add(item);
                            }
                            reader.Close();
                        }
                    }
                    else if(Class1.login_flag == 2)
                    {
                        label7.Visible = false;
                        comboBox3.Visible = false;
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
            long OrganizerID = 0;
            string EventName = textBox1.Text;
            DateTime EventDate = dateTimePicker1.Value.Date;
            int VenueID = ((ComboBoxItem)comboBox1.SelectedItem).Id;
            decimal Budget = decimal.Parse(textBox2.Text);
            string Description = textBox3.Text;
            int OwnerID = ((ComboBoxItem)comboBox2.SelectedItem).Id;
            decimal ProfitPercentage = decimal.Parse(roundedTextBox1.Text); 

            if (Class1.login_flag == 1)
            {
                OrganizerID = ((ComboBoxItem)comboBox3.SelectedItem).Id;
            }
            else if (Class1.login_flag == 2)
            {
                OrganizerID = Class1.organizerID;
            }

            string query = "INSERT INTO Events (EventName, EventDate, VenueID, OrganizerID, Budget, Description, OwnerID, ProfitPercentage) " +
                   "VALUES (@EventName, @EventDate, @VenueID, @OrganizerID, @Budget, @Description, @OwnerID, @ProfitPercentage); " +
                   "SELECT SCOPE_IDENTITY();";

                
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
                    command.Parameters.AddWithValue("@OrganizerID", OrganizerID);
                    command.Parameters.AddWithValue("@ProfitPercentage", ProfitPercentage);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            long eventID = Convert.ToInt64(result); 


                            MessageBox.Show("Event added successfully.");
                            Class1.CalculateEventCost(eventID);
                            this.Close();
                            Listingformobj.populateeventlisting();
                        }
                        else
                        {
                            MessageBox.Show("Error occurred while registering the event.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
