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

        public void loadresources()
        {
            string query = "SELECT r.ResourceID,r.ResourceName, r.Quantity, r.Cost FROM Resources r";
            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable eventDetailsTable = new DataTable();
                adapter.Fill(eventDetailsTable);

                dataGridView1.DataSource = eventDetailsTable;
                dataGridView1.Columns[0].Visible = false;

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int resourceId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ResourceID"].Value);


                resourcesForm form = new resourcesForm(resourceId);
                form.Show();
            }
        }
    }
}
