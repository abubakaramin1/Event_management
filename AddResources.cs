using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Event_management
{
    public partial class AddResources : Form
    {
        public AddResources()
        {
            InitializeComponent();
        }

        private void AddResources_Load(object sender, EventArgs e)
        {
            // Query for VendorName
            string vendorQuery = @"
                SELECT DISTINCT VendorName 
                FROM Vendors 
                WHERE VendorID IN (
                    SELECT VendorID 
                    FROM Resources
                )";

            // Query for ResourceType (CatResourceType)
            string resourceTypeQuery = "SELECT Title FROM CatResourceType";

            // Populate comboBox1 with Vendor Names
            PopulateComboBox(comboBox1, vendorQuery);

            // Populate comboBox2 with Resource Type Titles
            PopulateComboBox(comboBox2, resourceTypeQuery);
        }

        // Helper function to populate a ComboBox based on a query
        private void PopulateComboBox(ComboBox comboBox, string query)
        {
            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    comboBox.Items.Clear();  // Ensure ComboBox is cleared before adding items

                    int count = 0;

                    while (reader.Read())
                    {
                        string item = reader[0].ToString();
                        if (!string.IsNullOrEmpty(item))
                        {
                            comboBox.Items.Add(item);
                            count++;
                        }
                    }

                    // Show message based on results
                    if (count > 0)
                    {
                        MessageBox.Show($"{count} items loaded into {comboBox.Name}");
                    }
                    else
                    {
                        MessageBox.Show($"No items found for {comboBox.Name}");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading items for {comboBox.Name}: {ex.Message}");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle comboBox1 selection change if needed
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle comboBox2 selection change if needed
        }
    }
}
