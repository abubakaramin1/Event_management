﻿using System;
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
        public frm_Main(long Id)
        {
            InitializeComponent();
            userId = Id;
        }

        private void MIaddevent_Click(object sender, EventArgs e)
        {
            Form listingform =new Form3();
            foreach (Form child in this.MdiChildren)
            {
                // For example, you can get the name or change the title of the MDI child
                if (child.Text == "Form3")
                    listingform = child;
            }
            Form4 frmaddevent = new Form4(listingform,userId);
            frmaddevent.ShowDialog();
        } 

        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Form1 frmlogin = new Form1();
            //frmlogin.Close();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            Form3 frmeventlisting = new Form3();
            frmeventlisting.MdiParent = this;
            frmeventlisting.Show();
        }
    }
}
