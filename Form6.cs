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

namespace Event_management
{
    public partial class adminForm1 : Form
    {
        long userId;
        DataSet ds;


        public adminForm1(long Id)
        {
            InitializeComponent();
            userId = Id;
        }

        private void adminForm1_Load(object sender, EventArgs e)
        {
            populateeventlisting();
        }

        public void populateeventlisting()
        {
            string query = "select ev.EventID , ev.EventName as [Event Name] , ev.EventDate as [Date] , v.VenueName as Venue , o.FullName as [Organizer] ,ev.Budget,ev.[Description] , ow.FullName as [Owner]from [Events] ev\r\nleft join Venues v on v.VenueID=ev.VenueID\r\nleft join UserLoginInfo o on o.Id=ev.OrganizerID\r\nleft join UserLoginInfo ow on ow.Id=OwnerID ";

            ds = Class1.populateeventlisting(query);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["EventID"].Visible = false; // Hide EventID column
            }
            else
            {
                MessageBox.Show("No events found or unable to load data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null; 
            }
        }



        


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { }


        

       

    }
}
