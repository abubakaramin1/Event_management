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
            if (Class1.login_flag == 2)
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
            else if (Class1.login_flag == 1)
            {
                Form adminform = new adminForm1(userId);
                foreach (Form child in this.MdiChildren)
                {
                    if (child.Text == "Form6")
                        adminform = child;
                }
                AdminForm2 form2 = new AdminForm2(adminform, userId); // Pass the current form reference
                form2.Show(); // Show AdminForm2



            }


        }

        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


        private void frm_Main_Load(object sender, EventArgs e)
        {
            if (Class1.login_flag == 2)
            {
                Form3 frmeventlisting = new Form3();
                this.eventOrganizerToolStripMenuItem.Visible = false;
                frmeventlisting.MdiParent = this;
                frmeventlisting.Show();
            }
            else if (Class1.login_flag == 1)
            {
                adminForm1 adminForm = new adminForm1(userId);
                adminForm.MdiParent = this;
                adminForm.Show();
            }

        }

        private void eventOwnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class1.add_flag = 1;
            frm_registerowner frm_Registerowner = new frm_registerowner();
            frm_Registerowner.Show();

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged Out succesfully");
            IsLogout = true;
            this.Close();



        }

        private void eventOrganizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class1.add_flag = 2;
            frm_registerowner frm_Registerowner = new frm_registerowner();
            frm_Registerowner.Show();

        }
    }
}
