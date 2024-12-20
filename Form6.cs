﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_management
{
    public partial class adminForm1 : Form
    {
        
        DataSet ds;
        ShadowPanel shadowPanel;



        public adminForm1()
        {
            InitializeComponent();
            

           
            this.Resize += new EventHandler(adminForm1_Resize);
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;

        }



        private void ChangeHeaderRowColor()
        {
            // Change the background color of the header row
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(73, 54, 40);

            // Optionally, change the foreground color (text color)
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;           

            // Apply any other styles you want
            dataGridView1.EnableHeadersVisualStyles = true; // Required for custom styling to take effect
        }

        private void adminForm1_Load(object sender, EventArgs e)
        {
            populateeventlisting();
            CenterDataGridView();

            // Row header visibility and padding
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dataGridView1.RowHeadersDefaultCellStyle.Padding = new Padding(5);

            // Disable visual styles to apply custom header styles
            dataGridView1.EnableHeadersVisualStyles = false;

            // Apply initial header styles
            ApplyColumnHeaderStyles();

            ChangeRowColors();
            AddGradientShadowEffect();
        }


        private void ApplyColumnHeaderStyles()
        {
            // Ensure visual styles are disabled
            dataGridView1.EnableHeadersVisualStyles = false;

            // Set header styles
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(73, 54, 40); // RGB(73, 54, 40)
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // White text
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Bold font
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Set font to bold

            // Set header height
            dataGridView1.ColumnHeadersHeight = 80;

            // Force header redraw
            dataGridView1.Refresh(); // Refresh ensures all style changes are applied
        }





        private void ChangeRowColors()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (i % 2 == 0) // Even rows
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(214, 192, 179); // Light color for even rows
                }
                else // Odd rows
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(228, 224, 225); // Default color for odd rows
                }

                // Optional: Set text color for consistency
                dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
            }
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersHeight = 40;
        }

        private void AddGradientShadowEffect()
        {
            // Create an instance of the custom ShadowPanel
            shadowPanel = new ShadowPanel
            {
                Size = new Size(dataGridView1.Width + 10, dataGridView1.Height + 10), // Slightly larger than the DataGridView
                Location = new Point(dataGridView1.Location.X + 5, dataGridView1.Location.Y + 5), // Slightly offset for shadow
                                                                                                  // No need to set BackColor to transparent, since we override OnPaint to draw the gradient
            };

            // Add the shadow panel to the form
            this.Controls.Add(shadowPanel);

            // Send the shadow panel to the back (behind the DataGridView)
            shadowPanel.SendToBack();

            // Bring the DataGridView to the front to ensure it is above the shadow
            dataGridView1.BringToFront();
        }





        private void CenterDataGridView()
        {
            // Calculate the center position for the DataGridView
            int x = (this.ClientSize.Width - dataGridView1.Width) / 2;
            int y = (this.ClientSize.Height - dataGridView1.Height) / 2;

            // Set the DataGridView location
            dataGridView1.Location = new Point(x, y);
        }

        public void populateeventlisting()
        {
            string query = null;
            if(Class1.login_flag == 1)
            {
                query = "select ev.EventID , ev.EventName as [Event Name] , ev.EventDate as [Date] , v.VenueName as Venue , o.FullName as [Organizer] ,ev.Budget,ev.[Description] , ow.FullName as [Owner]from [Events] ev\r\nleft join Venues v on v.VenueID=ev.VenueID\r\nleft join UserLoginInfo o on o.Id=ev.OrganizerID\r\nleft join UserLoginInfo ow on ow.Id=OwnerID ";

            }

            else if(Class1.login_flag == 2)
            {
                 query = "select ev.EventID , ev.EventName as [Event Name] , ev.EventDate as [Date] , v.VenueName as Venue , o.FullName as [Organizer] ,ev.Budget,ev.[Description] , ow.FullName as [Owner]from [Events] ev\r\nleft join Venues v on v.VenueID=ev.VenueID\r\nleft join UserLoginInfo o on o.Id=ev.OrganizerID\r\nleft join UserLoginInfo ow on ow.Id=OwnerID where ev.OrganizerID = @organizerid\r\n";

            }


            ds = Class1.populateeventlisting(query);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["EventID"].Visible = false;
                dataGridView1.DataBindingComplete += (s, e) => {
                    ChangeHeaderRowColor();
                    ChangeRowColors();
                };
            }
            else
            {
                MessageBox.Show("No events found or unable to load data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null; 
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                long eventId = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["EventID"].Value);

                Class1.organizer_flag = 2;
                Form5 form5 = new Form5(eventId);
                form5.MdiParent = this.MdiParent;
                form5.Show();
                this.Close();

            }
        }









        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { }

        private void adminForm1_Resize(object sender, EventArgs e)
        {
            CenterDataGridView(); // Re-center the DataGridView when the form is resized

            // Check if shadowPanel is initialized before trying to invalidate it
            if (shadowPanel != null)
            {
                shadowPanel.Invalidate(); // Redraw the shadow panel to update the shadow effect
            }
        }







    }
}
