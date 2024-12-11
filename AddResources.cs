using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Event_management
{
    public partial class AddResources : Form
    {
        int numericValue;

        private void PopulateComboBox()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>
    {
        new ComboBoxItem { Text = "chair", Id = 1 },
        new ComboBoxItem { Text = "table", Id = 2 },
        new ComboBoxItem { Text = "sofa", Id = 3 },
         new ComboBoxItem { Text = "microphone", Id = 4 },
        new ComboBoxItem { Text = "light", Id = 5 },
        new ComboBoxItem { Text = "bulbs", Id = 6 },
        new ComboBoxItem { Text = "lamps", Id = 7 },

    };

            comboBox2.DataSource = items;
        }
        public AddResources()
        {
            InitializeComponent();
            PopulateComboBox();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox2.SelectedItem;

            if (selectedItem != null)
            {
                numericValue = selectedItem.Id;
                MessageBox.Show($"Selected Resource Type ID: {numericValue}"); // Debug message
            }
        }

        private void AddResources_Load(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle comboBox1 selection change if needed
        }

       

        private void AddResources_Load_1(object sender, EventArgs e)
        {

        }



        //private void LoadResourcetypeNames()
        //{
        //    try
        //    {
        //        string query = "SELECT Title FROM CatResourceType";

        //        using (SqlConnection connection = new SqlConnection(Class1.connectionString))
        //        {
        //            connection.Open();

        //            SqlCommand cmd = new SqlCommand(query, connection);
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            comboBox2.Items.Clear();

        //            while (reader.Read())
        //            {
        //                comboBox2.Items.Add(reader[0].ToString());
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error loading Resource names: {ex.Message}");
        //    }
        //}

        private void confirmButton_Click(object sender, EventArgs e)
        {
            // Get values from TextBoxes and ComboBoxes
            string resourceName = textBox1.Text;  // Assuming textBox1 is for Resource Name
            string quantity = textBox2.Text;  // Assuming textBox2 is for Quantity
            string cost = textBox3.Text;  // Assuming textBox3 is for Cost

            // Basic validation to ensure fields are not empty
            if (string.IsNullOrWhiteSpace(resourceName) || string.IsNullOrWhiteSpace(quantity) ||
                string.IsNullOrWhiteSpace(cost) || numericValue == 0) // Check if numericValue is set
            {
                MessageBox.Show("Please fill in all fields and select a resource type.");
                return;
            }

            try
            {
                // SQL query to insert new resource into the Resources table
                string insertQuery = @"
        INSERT INTO Resources (ResourceName, Quantity, Cost, CatResourceTypeId)
        VALUES (@ResourceName, @Quantity, @Cost, @CatResourceTypeId)";

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@ResourceName", resourceName);
                    cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(quantity)); // Assuming Quantity is an integer
                    cmd.Parameters.AddWithValue("@Cost", Convert.ToDecimal(cost)); // Assuming Cost is a decimal
                    cmd.Parameters.AddWithValue("@CatResourceTypeId", numericValue);  // Use the selected resource type ID from comboBox2

                    int rowsAffected = cmd.ExecuteNonQuery(); // Execute the insert query

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Resource added successfully!");
                        this.Close(); // Close the form after adding the resource
                    }
                    else
                    {
                        MessageBox.Show("Failed to add resource. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding resource: {ex.Message}");
            }
        }



    }
}