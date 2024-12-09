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

        private void frm_venues_Load(object sender, EventArgs e)
        {

            showvenues();
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
            Class1.venue_flag = 1;
            AddVenue addVenue = new AddVenue(this);
            addVenue.Show();
        }
    }
}
