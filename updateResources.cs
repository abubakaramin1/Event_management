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

        private void updateResources_Load(object sender, EventArgs e)
        {
            loadresources();
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
