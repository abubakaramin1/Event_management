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

        adminForm1 adminForm = new adminForm1();


        public frm_Main(long Id)
        {
            InitializeComponent();
            userId = Id;
        }







        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


        private void frm_Main_Load(object sender, EventArgs e)
        {
            // Apply the custom renderer to the MainMenuStrip
            this.MainMenuStrip.Renderer = new RoundedToolStripRenderer();

            MainMenuStrip.Height = 200;

            // Your existing code for login and form display
            //if (Class1.login_flag == 2)
            //{
            //    Form3 frmeventlisting = new Form3();
            //    this.addOrganizerToolStripMenuItem.Visible = false;
            //    frmeventlisting.MdiParent = this;
            //    frmeventlisting.Show();
            //}
            //else if (Class1.login_flag == 1)
            //{

            adminForm.MdiParent = this;
            adminForm.Show();
            toolStripLabel2.Text = "Hello " + Class1.name;
            //}

            toolStripLabel1.Margin = new Padding(300, 0, 20, 0);
            toolStripLabel2.Margin = new Padding(200, 0, 0, 0);

            logOutToolStripMenuItem.Padding = new Padding(5, 25, 25, 5);
            registerToolStripMenuItem.Padding = new Padding(5, 25, 25, 5);
            addOrganizerToolStripMenuItem.Padding = new Padding(5, 25, 25, 5);
            addOwnerToolStripMenuItem.Padding = new Padding(5, 25, 25, 5);
            addResourceToolStripMenuItem.Padding = new Padding(5, 25, 25, 5);
            addVenueToolStripMenuItem.Padding = new Padding(5, 25, 25, 5);
            viewVenuesToolStripMenuItem.Padding = new Padding(5, 25, 25, 5);

            registerToolStripMenuItem.Margin = new Padding(10, 30, 10, 0);
            addOrganizerToolStripMenuItem.Margin = new Padding(10, 30, 10, 0);
            addOwnerToolStripMenuItem.Margin = new Padding(10, 30, 10, 0);
            logOutToolStripMenuItem.Margin = new Padding(10, 30, 10, 0);
            addResourceToolStripMenuItem.Margin = new Padding(10, 30, 10, 0);
            addVenueToolStripMenuItem.Margin = new Padding(10, 30, 10, 0);
            viewVenuesToolStripMenuItem.Margin = new Padding(10, 30, 10, 0);

        }





        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged Out succesfully");
            IsLogout = true;
            this.Close();



        }



        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form adminform = new adminForm1();
            foreach (Form child in this.MdiChildren)
            {
                if (child.Text == "Form6")
                    adminform = child;
            }
            AdminForm2 form2 = new AdminForm2(adminform, userId);
            form2.Show();




        }

        private void addOrganizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class1.add_flag = 2;

            if (Class1.organizer_flag == 2)
            {
                Form form = new adminForm1();
                foreach (Form child in this.MdiChildren)
                {
                    if (child.Text == "Form5")
                        form = child;
                }
                frm_registerowner _Registerowner = new frm_registerowner(form);
                _Registerowner.ShowDialog();

            }
            else if (Class1.organizer_flag == 1)
            {
                frm_registerowner frm_Registerowner = new frm_registerowner();
                frm_Registerowner.ShowDialog();
            }


        }

        private void addOwnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class1.add_flag = 1;
            frm_registerowner frm_Registerowner = new frm_registerowner();
            frm_Registerowner.ShowDialog();
        }

        private void addResourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateResources form = new updateResources();
            form.MdiParent = this;
            form.Show();
            adminForm.Close();
        }

       

        private void viewVenuesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frm_venues venues = new frm_venues();
            venues.MdiParent = this;
            venues.Show();
            adminForm.Close();

        }

      

 

        private void eventSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            EventSummaryReportForm form = new EventSummaryReportForm();
            form.MdiParent = this;
            form.Show();
            adminForm.Close();
        }
    }
}
