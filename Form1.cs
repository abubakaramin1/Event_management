using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Event_management;

namespace Event_management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
            form3.FormClosed += (s, args) => this.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }


}
