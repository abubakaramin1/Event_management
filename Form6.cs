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
    public partial class adminForm1 : Form
    {
        long userId;
        DataSet ds;
        public adminForm1()
        {
            InitializeComponent();
        }

        public adminForm1(long Id)
        {
            InitializeComponent();
            userId = Id;
        }

        private void adminForm1_Load(object sender, EventArgs e)
        {
            populateeventlisting();
        }

        public void populateeventlisting()
        {
            Class1 class1 = new Class1();
            ds = class1.ConnectToDatabase();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["EventID"].Visible = false; // Hide EventID column
            }
            else
            {
                MessageBox.Show("No events found or unable to load data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null; // Clear the DataGridView if no data is found
            }
        }



        private void LoadEventTable()
        {
            // Connection string
            string connectionString = "Data Source=(local);Initial Catalog=event_management;Integrated Security=True;TrustServerCertificate=True";


            // Query to fetch all rows and columns from the Event table
            string query = "SELECT * FROM Events";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    dataGridView1.AutoGenerateColumns = true;  // Automatically generate columns
                    dataGridView1.DataSource = dataTable;      // Display the data in DataGridView
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., database connection issues)
                    MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { }


        private void button1_Click(object sender, EventArgs e)
        {
            AdminForm2 form2 = new AdminForm2(this, userId); // Pass the current form reference
            form2.Show(); // Show AdminForm2
            this.Hide();  // Hide the current form

            // Ensure adminForm1 reappears when AdminForm2 closes
            form2.FormClosed += (s, args) => this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterOwner form = new RegisterOwner();
            form.Show();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegisterOrganizer form = new RegisterOrganizer();
            form.Show();
            this.Hide();
            form.FormClosed += (s, args) => this.Show();
        }
    }
}
