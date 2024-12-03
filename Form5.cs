using Microsoft.VisualBasic.ApplicationServices;
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
using OfficeOpenXml;

namespace Event_management
{
    public partial class Form5 : Form
    {
        private int eventId;

        public Form5(int eventId)
        {
            InitializeComponent();
            this.eventId = eventId;
            this.Shown += Form5_Shown;
            this.FormClosed += Form5_FormClosed;


        }


        public void reloadresources()
        {
            string query = "\t\t \r\nSELECT r.ResourceName, r.Quantity, r.Cost, er.QuantityUsed\r\nFROM Resources r\r\nINNER JOIN Event_Resources er \r\n    ON r.ResourceID = er.ResourceID\r\nINNER JOIN Events e \r\n    ON er.EventID = e.EventID\r\nWHERE e.EventID = @EventID;";
            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EventID", eventId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable eventDetailsTable = new DataTable();
                adapter.Fill(eventDetailsTable);

                dataGridView1.DataSource = eventDetailsTable;

                HighlightExceededQuantities();
            }
        }

        public void reloadattendees()
        {
            string attendeeQuery = "select * from UserLoginInfo where Id in( " +
                    "select AttendeeID from Event_Attendees where EventID in (@EventID))";
            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(attendeeQuery, connection);
                cmd.Parameters.AddWithValue("@EventID", eventId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable eventDetailsTable = new DataTable();
                adapter.Fill(eventDetailsTable);

                dataGridView2.DataSource = eventDetailsTable;
            }
        }

        public void LoadEventDetails()
        {
            try
            {
                string attendeeQuery = "select * from UserLoginInfo where Id in( " +
                    "select AttendeeID from Event_Attendees where EventID in (@EventID))";
                string estimatedQuery = "select Budget from Events where EventID = @EventID";
                string actualQuery = "select ActualCost from Events where EventID = @EventID";
                string organizerQuery = "select FullName from UserLoginInfo where Id in ( select OrganizerID from Events where EventID in (@EventID))";
                string dateQuery = "\r\nselect eventDate from Events where EventID = @EventID";
                string venueQuery = "SELECT VenueName FROM Venues WHERE VenueID = (SELECT VenueID FROM Events WHERE EventID = @EventID)";


                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(attendeeQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable eventDetailsTable = new DataTable();
                    adapter.Fill(eventDetailsTable);

                    dataGridView2.DataSource = eventDetailsTable;
                }
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(venueQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        textBox1.Text = result.ToString();
                    }
                    else
                    {
                        textBox1.Text = "Venue: Not Available";
                    }
                }
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(estimatedQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        textBox2.Text = result.ToString();
                    }
                    else
                    {
                        textBox2.Text = "Budget : Not available";
                    }
                }
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(actualQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    object result = cmd.ExecuteScalar();

                    if (!Convert.IsDBNull(result))
                    {
                        textBox3.Text = result.ToString();
                    }
                    else
                    {
                        textBox3.Text = "Cost: Not Available";
                    }
                }
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(organizerQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        textBox4.Text = result.ToString();
                    }
                    else
                    {
                        textBox4.Text = "Organizer : Not Available";
                    }
                }
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(dateQuery, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventId);
                    var result = cmd.ExecuteScalar();  // ExecuteScalar returns a single value

                    if (result != null)
                    {
                        DateTime eventDate = Convert.ToDateTime(result);
                        textBox5.Text = eventDate.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        textBox5.Text = "Date : Not Available";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading event details: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {


        }
        private void Form5_Shown(object sender, EventArgs e)
        {
            LoadEventDetails();
            reloadresources();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form eventDetail = new Form5(this.eventId);
            foreach (Form child in this.MdiParent.MdiChildren)
            {
                if (child.Text == "Form5")
                    eventDetail = child;
            }

            Frm_ResourcesAdd frm_ResourcesAdd = new Frm_ResourcesAdd(eventDetail, eventId);
            frm_ResourcesAdd.Show();
        }

        public void HighlightExceededQuantities()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    object quantityUsedValue = row.Cells["QuantityUsed"].Value;
                    object quantityValue = row.Cells["Quantity"].Value;

                    if (quantityUsedValue != null && quantityValue != null &&
                        int.TryParse(quantityUsedValue.ToString(), out int quantityUsed) &&
                        int.TryParse(quantityValue.ToString(), out int quantity))
                    {
                        if (quantityUsed > quantity)
                        {

                            row.Cells["QuantityUsed"].Style.ForeColor = Color.Red;
                        }
                        else
                        {

                            row.Cells["QuantityUsed"].Style.ForeColor = Color.Green;
                        }
                    }
                }
            }
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {

            adminForm1 adminForm = new adminForm1();
            adminForm.MdiParent = this.MdiParent;
            adminForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Select an Excel File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ImportAttendeesToEvent(filePath, eventId);

            }

        }

        private void ImportAttendeesToEvent(string filePath, int eventId)
        {
            DataTable attendeesTable = new DataTable();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                attendeesTable.Columns.Add("FullName");
                attendeesTable.Columns.Add("Email");
                attendeesTable.Columns.Add("PhoneNumber");

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    DataRow dr = attendeesTable.NewRow();
                    dr["FullName"] = worksheet.Cells[row, 1].Text;
                    dr["Email"] = worksheet.Cells[row, 2].Text;
                    dr["PhoneNumber"] = worksheet.Cells[row, 3].Text;
                    attendeesTable.Rows.Add(dr);
                }
            }

            // Step 1: Insert into UserLoginInfo and get inserted IDs
            List<int> attendeeIds = InsertAttendeesIntoUserLoginInfo(attendeesTable);

            // Step 2: Insert into Event_Attendees
            if (attendeeIds.Count > 0)
            {
                MapAttendeesToEvent(attendeeIds, eventId);
                DialogResult result =  MessageBox.Show("Attendees imported and mapped to the event successfully!");
                if (result == DialogResult.OK)
                {
                    reloadattendees();
                }
            }
            else
            {
                MessageBox.Show("No attendees were added.");
            }
        }


        private void MapAttendeesToEvent(List<int> attendeeIds, int eventId)
        {
            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                string query = @"
            INSERT INTO Event_Attendees (EventID, AttendeeID)
            VALUES (@EventId, @AttendeeId)";

                try
                {
                    connection.Open();

                    foreach (int attendeeId in attendeeIds)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@EventId", eventId);
                            command.Parameters.AddWithValue("@AttendeeId", attendeeId);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while mapping attendees to the event: {ex.Message}");
                }
            }
        }

        private List<int> InsertAttendeesIntoUserLoginInfo(DataTable attendeesTable)
        {
            List<int> insertedIds = new List<int>();

            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                string query = @"
            INSERT INTO UserLoginInfo (FullName, Email, PhoneNumber,CatUserRoleId) 
            OUTPUT INSERTED.Id 
            VALUES (@FullName, @Email, @PhoneNumber,@id)";

                try
                {
                    connection.Open();

                    foreach (DataRow row in attendeesTable.Rows)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@FullName", row["FullName"]);
                            command.Parameters.AddWithValue("@Email", row["Email"]);
                            command.Parameters.AddWithValue("@PhoneNumber", row["PhoneNumber"]);
                            command.Parameters.AddWithValue("@id", 4);

                            object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                insertedIds.Add(Convert.ToInt32(result));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while inserting attendees: {ex.Message}");
                }
            }

            return insertedIds;
        }


       

    }

}

