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
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Class1 class1 = new Class1();
            dataGridView1.DataSource = class1.ConnectToDatabase().Tables[0];
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
            this.Hide();
            form.FormClosed += (s, args) => this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int eventId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["EventID"].Value);
               

                Form5 form5 = new Form5(eventId);
                form5.Show();
                this.Hide();
                form5.FormClosed += (s, args) => this.Close();
            }
        }
    }
}
