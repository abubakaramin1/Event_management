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
    public partial class frm_Main : Form
    {
        long userId;
        public bool IsLogout { get; private set; } = false;


        public frm_Main(long Id)
        {
            InitializeComponent();
            userId = Id;
           
        }

        private void MIaddevent_Click(object sender, EventArgs e)
        {
            Form listingform = new Form3();
            foreach (Form child in this.MdiChildren)
            {
                if (child.Text == "Form3")
                    listingform = child;
            }
            Form4 frmaddevent = new Form4(listingform, userId);
            frmaddevent.ShowDialog();
        }

        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


        private void frm_Main_Load(object sender, EventArgs e)
        {
            Form3 frmeventlisting = new Form3();
            frmeventlisting.MdiParent = this;
            frmeventlisting.Show();
        }

        private void eventOwnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_registerowner frm_Registerowner = new frm_registerowner();
            frm_Registerowner.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged Out succesfully");
            IsLogout = true;
            this.Close();



        }
    }
}
