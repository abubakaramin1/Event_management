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
using static Microsoft.IO.RecyclableMemoryStreamManager;

namespace Event_management
{
    public partial class updateResources : Form
    {
        public updateResources()
        {
            InitializeComponent();
        }

        private void CenterDataGridView(DataGridView dataGridView)
        {
            // Calculate the position to center the DataGridView
            int x = (this.ClientSize.Width - dataGridView.Width) / 2;
            int y = (this.ClientSize.Height - dataGridView.Height) / 2;

            // Set the location of the DataGridView
            dataGridView.Location = new Point(x, y);
        }

        private void updateResources_Load(object sender, EventArgs e)
        {
            loadresources();
            ApplyDataGridViewStyles(dataGridView1);
            CenterDataGridView(dataGridView1);
        }



        private void ApplyDataGridViewStyles(DataGridView dataGridView)
        {
            // Hide row headers
            dataGridView.RowHeadersVisible = false;

            // Disable visual styles for custom header styles
            dataGridView.EnableHeadersVisualStyles = false;

            // Customize column header style
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(73, 54, 40); // RGB(73, 54, 40)
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // White text
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9); // Bold font
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Apply alternate row coloring
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(214, 192, 179); // RGB(214, 192, 179)
            dataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(228, 224, 225); // RGB(228, 224, 225)
            dataGridView.RowsDefaultCellStyle.ForeColor = Color.Black; // Text color for consistency

            // Center align text in rows
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Optional: Set a consistent row height

        }

        public void loadresources()
        {
            try
            {
                string query = "SELECT ResourceID, ResourceName, Cost, Quantity FROM Resources";
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    if (dataGridView1.Columns["ResourceID"] != null)
                    {
                        dataGridView1.Columns["ResourceID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading resources: {ex.Message}");
            }
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int resourceId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ResourceID"].Value);

                resourcesForm form = new resourcesForm(resourceId);

                // Subscribe to the ResourceUpdated event
                form.ResourceUpdated += () =>
                {
                    loadresources(); // Refresh the DataGridView
                };

                form.ShowDialog();
            }
        }

        private void updateResources_FormClosed(object sender, FormClosedEventArgs e)
        {
            adminForm1 admin = new adminForm1();
            admin.MdiParent = this.MdiParent;
            admin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddResources form = new AddResources(this);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Prompt the user for the resource type title
            string input = Prompt.ShowDialog("Enter Resource Type", "Add Resource Type");

            // Check if input is valid
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Resource type cannot be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // SQL query to insert the resource type into the CatResourceType table
                string query = "INSERT INTO CatResourceType (Title) VALUES (@Title)";

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Title", input);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Resource type added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the resource type. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the resource type: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label label = new Label() { Left = 20, Top = 20, Text = text, Width = 350 };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 350 };
            Button confirmation = new Button() { Text = "OK", Left = 250, Width = 100, Top = 100, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Cancel", Left = 140, Width = 100, Top = 100, DialogResult = DialogResult.Cancel };

            prompt.Controls.Add(label);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            DialogResult result = prompt.ShowDialog();

            return result == DialogResult.OK ? textBox.Text.Trim() : null;
        }
    }
}
