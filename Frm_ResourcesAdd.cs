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
    public partial class Frm_ResourcesAdd : Form
    {
        int eventId;
        string connectionString = Class1.connectionString;
        Form5 eventDetails;
        public Frm_ResourcesAdd(Form eventDetails,int eventId)
        {
            InitializeComponent();
            this.eventId = eventId;
            this.eventDetails = (Form5)eventDetails;   
        }

        private void Frm_ResourcesAdd_Load(object sender, EventArgs e)
        {

            string query = "SELECT EventDate FROM Events WHERE EventID = @EventID";


            string queryUseDate = @"
                   select r.ResourceID , r.ResourceName ,r.Quantity ,  r.Quantity - ISNULL((SELECT SUM(er.QuantityUsed) as Quantity
         FROM Event_Resources er
         INNER JOIN Events e ON er.EventID = e.EventID
         where e.EventDate = @EventDate AND r.ResourceID = er.ResourceID),0) as Available from Resources r ";
            DateTime eventDate;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EventID", eventId);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        eventDate = Convert.ToDateTime(result);
                        SqlCommand commandUseDate = new SqlCommand(queryUseDate, connection);
                        commandUseDate.Parameters.AddWithValue("@EventDate", eventDate);

                        SqlDataAdapter adapter = new SqlDataAdapter(commandUseDate);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataTable.Columns.Add("AvailabilityStatus", typeof(string));

                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row["Available"] != DBNull.Value && Convert.ToInt32(row["Available"]) < 0)
                            {
                                row["AvailabilityStatus"] = "Not Available";
                            }
                            else
                            {
                                row["AvailabilityStatus"] = row["Available"].ToString();
                            }
                        }
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.Columns["Required"].DisplayIndex = dataGridView1.Columns.Count - 1;
                        dataGridView1.Columns["ResourceID"].Visible = false;
                        dataGridView1.Columns["AvailabilityStatus"].HeaderText = "Available Amount";
                        dataGridView1.Columns["AvailabilityStatus"].DisplayIndex = dataGridView1.Columns.Count - 2;
                        dataGridView1.Columns["Available"].Visible = false;


                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    object cellValue = row.Cells["Required"].Value;
                    int requiredQuantity = 0;

                    if (cellValue != null && int.TryParse(cellValue.ToString(), out int parsedValue))
                    {
                        requiredQuantity = parsedValue; // Use the valid value
                    }

                    if (requiredQuantity > 0)
                    {
                        int resourceId = int.Parse(row.Cells["ResourceID"].Value.ToString());

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = @"
                        UPDATE Event_Resources
                        SET QuantityUsed = QuantityUsed + @RequiredQuantity
                        WHERE ResourceID = @resourceid AND EventID = @eventid
                        ";

                            string checkquery = "select count(*) from Event_Resources where EventID = @eventid and ResourceID = @resourceid";
                            using (SqlCommand checkCmd = new SqlCommand(checkquery, conn))
                            {
                                checkCmd.Parameters.AddWithValue("@eventid", eventId);
                                checkCmd.Parameters.AddWithValue("@resourceid", resourceId);

                                int recordExists = (int)checkCmd.ExecuteScalar();

                                if (recordExists > 0)
                                {




                                    using (SqlCommand cmd = new SqlCommand(query, conn))
                                    {
                                        cmd.Parameters.AddWithValue("@RequiredQuantity", requiredQuantity);
                                        cmd.Parameters.AddWithValue("@resourceid", resourceId);
                                        cmd.Parameters.AddWithValue("@eventid", eventId);

                                        cmd.ExecuteNonQuery(); // Execute the update query

                                    }

                                }

                                else
                                {
                                    string insertQuery = @"
                                INSERT INTO Event_Resources (EventID, ResourceID, QuantityUsed)
                                VALUES (@EventID, @resourceid, @RequiredQuantity)";

                                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                                    {
                                        insertCmd.Parameters.AddWithValue("@EventID", eventId);
                                        insertCmd.Parameters.AddWithValue("@resourceid", resourceId);
                                        insertCmd.Parameters.AddWithValue("@RequiredQuantity", requiredQuantity);

                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            MessageBox.Show("Data updated successfully!");
            this.Close();

        }

        private void Frm_ResourcesAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.eventDetails.reloadresources();
        }
    }
}
