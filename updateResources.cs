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

        private void loadresources()
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
    }
}
