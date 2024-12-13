using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            Console.WriteLine($"Padding: {eventSummaryReportToolStripMenuItem.Padding}");
            Console.WriteLine($"Margin: {eventSummaryReportToolStripMenuItem.Margin}");

        }

        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


        private void frm_Main_Load(object sender, EventArgs e)
        {


            // Your existing code for login and form displa
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
            label1.Text = "Hello";
            label2.Text = Class1.name + "!";
            //}

            roundedButton1.Padding = new Padding(5, 25, 25, 5);
            roundedButton2.Padding = new Padding(5, 25, 25, 5);
            roundedButton3.Padding = new Padding(5, 25, 25, 5);
            roundedButton4.Padding = new Padding(5, 25, 25, 5);
            roundedButton5.Padding = new Padding(5, 25, 25, 5);
            roundedButton6.Padding = new Padding(5, 25, 25, 5);
            roundedButton7.Padding = new Padding(5, 25, 25, 5);

            roundedButton1.Margin = new Padding(10, 30, 10, 0);
            roundedButton2.Margin = new Padding(10, 30, 10, 0);
            roundedButton3.Margin = new Padding(10, 30, 10, 0);
            roundedButton4.Margin = new Padding(10, 30, 10, 0);
            roundedButton5.Margin = new Padding(10, 30, 10, 0);
            roundedButton6.Margin = new Padding(10, 30, 10, 0);
            roundedButton7.Margin = new Padding(10, 30, 10, 0);

            AssignButtonHoverEffects();
        }

        private void AssignButtonHoverEffects()
        {
            foreach (var control in Controls)
            {
                if (control is System.Windows.Forms.Button button) // Ensure it's a button
                {
                    // Hover effects
                    button.MouseEnter += (s, e) =>
                    {
                        button.BackColor = Color.FromArgb(150, 113, 23); // Hover: Lighter color
                        button.FlatAppearance.BorderColor = Color.FromArgb(150, 113, 23); // Optional: Change border color
                        button.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 113, 23); // Ensure consistent color
                    };

                    button.MouseLeave += (s, e) =>
                    {
                        button.BackColor = Color.FromArgb(171, 136, 109); // Reset: Original color
                        button.FlatAppearance.BorderColor = Color.FromArgb(171, 136, 109); // Reset border color
                        button.FlatAppearance.MouseOverBackColor = Color.FromArgb(171, 136, 109); // Reset hover back color
                    };
                }
            }
        }




        private void roundedButton1_Click(object sender, EventArgs e)
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

        private void roundedButton2_Click(object sender, EventArgs e)
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

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            Class1.add_flag = 1;
            frm_registerowner frm_Registerowner = new frm_registerowner();
            frm_Registerowner.ShowDialog();
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {

            frm_venues venues = new frm_venues();
            venues.MdiParent = this;
            venues.Show();
            adminForm.Close();

        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            updateResources form = new updateResources();
            form.MdiParent = this;
            form.Show();
            adminForm.Close();
        }

        private void roundedButton6_Click(object sender, EventArgs e)
        {
            EventSummaryReportForm form = new EventSummaryReportForm();
            form.MdiParent = this;
            form.Show();
            adminForm.Close();
        }

        private void roundedButton7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged Out succesfully");
            IsLogout = true;
            this.Close();
        }

    }
}
