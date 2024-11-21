using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_management
{
    public partial class Form3 : Form
    {
        DataSet ds;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            populateeventlisting();
           
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }
        public void populateeventlisting()
        {
            Class1 class1 = new Class1();
            ds = class1.ConnectToDatabase();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["EventID"].Visible = false;
        }
        




        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int eventId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["EventID"].Value);


                Form5 form5 = new Form5(eventId);
                form5.MdiParent = this.MdiParent;
                form5.Show();
            }
        }

      
    }
}
