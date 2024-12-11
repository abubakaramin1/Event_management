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
            LoadResourcetypeNames();
        }

        private void AddResources_Load(object sender, EventArgs e)
        {
            
        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle comboBox1 selection change if needed
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle comboBox2 selection change if needed
        }

        private void AddResources_Load_1(object sender, EventArgs e)
        {

        }

        

        private void LoadResourcetypeNames()
        {
            try
            {
                string query = "SELECT Title FROM CatResourceType";

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    comboBox2.Items.Clear();

                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Resource names: {ex.Message}");
            }
        }


    }
}
