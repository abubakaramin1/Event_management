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
    public partial class Form3 : Form
    {
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
            string query = "select ev.EventID , ev.EventName as [Event Name] , ev.EventDate as [Date] , v.VenueName as Venue , o.FullName as [Organizer] ,ev.Budget,ev.[Description] , ow.FullName as [Owner]from [Events] ev\r\nleft join Venues v on v.VenueID=ev.VenueID\r\nleft join UserLoginInfo o on o.Id=ev.OrganizerID\r\nleft join UserLoginInfo ow on ow.Id=OwnerID where ev.OrganizerID = @organizerid\r\n";
            DataSet ds = Class1.populateeventlisting(query);
            

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
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
