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
    public partial class frm_venues : Form
    {
        public frm_venues()
        {
            InitializeComponent();
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

        private void frm_venues_Load(object sender, EventArgs e)
        {

            showvenues();
            ApplyDataGridViewStyles(dataGridView1);
        }

        public void showvenues()
        {
            DataTable eventDetailsTable = new DataTable();
            eventDetailsTable = Class1.loadvenues();

            dataGridView1.DataSource = eventDetailsTable;
            dataGridView1.Columns[0].Visible = false;

        }



        private void frm_venues_FormClosed(object sender, FormClosedEventArgs e)
        {
            adminForm1 adminForm1 = new adminForm1();
            adminForm1.MdiParent = this.MdiParent;
            adminForm1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddVenue addVenue = new AddVenue(this);
            addVenue.ShowDialog();
        }

       
    }

}
