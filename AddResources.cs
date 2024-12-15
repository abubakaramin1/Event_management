using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Event_management
{
    public partial class AddResources : Form
    {
        updateResources updateResources;

        public AddResources(updateResources update)
        {
            InitializeComponent();
            LoadResourcetypeNames();
            updateResources = update;
        }





        private void LoadResourcetypeNames()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>();

            try
            {
                string query = "SELECT Id,Title FROM CatResourceType";

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    resourcecombobox.Items.Clear();

                    while (reader.Read())
                    {

                        items.Add(new ComboBoxItem
                        {
                            Text = reader["Title"].ToString(),
                            resourceid = Convert.ToInt64(reader["Id"])
                        });




                    }
                    reader.Close();

                    resourcecombobox.DataSource = items;
                    resourcecombobox.DisplayMember = "Text"; // Set the display property.
                    resourcecombobox.ValueMember = "resourceid";    // Set the value property.
                    resourcecombobox.SelectedIndex = -1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Resource names: {ex.Message}");
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(resourceNameTextBox.Text) ||
        string.IsNullOrWhiteSpace(quantityTextBox.Text) ||
        string.IsNullOrWhiteSpace(costTextBox.Text) ||
        resourcecombobox.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all the fields and select a resource type.");
                return;
            }

            // Parse input values
            string resourceName = resourceNameTextBox.Text.Trim();
            int quantity;
            decimal cost;
            long resourceTypeId;


            if (!int.TryParse(quantityTextBox.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            if (!decimal.TryParse(costTextBox.Text, out cost) || cost < 0)
            {
                MessageBox.Show("Please enter a valid cost.");
                return;
            }

            ComboBoxItem selectedItem = (ComboBoxItem)resourcecombobox.SelectedItem;

            if (selectedItem == null)
            {
                MessageBox.Show("Please select a valid resource type.");
                return;
            }
            resourceTypeId = selectedItem.resourceid;

            try
            {
                string query = "INSERT INTO Resources (ResourceName, Quantity, Cost, CatResourceTypeId) " +
                               "VALUES (@ResourceName, @Quantity, @Cost, @ResourceTypeID)";

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ResourceName", resourceName);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@Cost", cost);
                        cmd.Parameters.AddWithValue("@ResourceTypeID", resourceTypeId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Resource added successfully.");
                            updateResources.loadresources();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the resource. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the resource: {ex.Message}");
            }

        }


        private void AddResources_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void AddResources_Load(object sender, EventArgs e)
        {

        }
    }


}