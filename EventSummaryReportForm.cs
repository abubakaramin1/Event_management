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
    public partial class EventSummaryReportForm : Form
    {
        private string connectionString = Class1.connectionString;

        DateTime? startDate = null;
        DateTime? endDate = null;
        long? organizerId = null;
        int? venueId = null;
        long? ownerId = null;


        public EventSummaryReportForm()
        {
            InitializeComponent();
            LoadEventSummaryReport(startDate, endDate, organizerId, venueId, ownerId);
            LoadEventSummaryAggregates(startDate, endDate, organizerId, venueId, ownerId);
            InitializeDataGridView();
            LoadOrganizers();
            LoadVenues();
            LoadOwners();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
        }


        private void EventSummaryReportForm_Load(object sender, EventArgs e)
        {
            dateTimePickerStartDate.ShowCheckBox = true;
            dateTimePickerStartDate.Checked = false;

            dateTimePickerEndDate.ShowCheckBox = true;
            dateTimePickerEndDate.Checked = false;
        }
        private void LoadEventSummaryAggregates(DateTime? startDate, DateTime? endDate, long? organizerId, int? venueId, long? ownerId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetEventSummaryAggregates", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add input parameters
                        command.Parameters.AddWithValue("@StartDate", startDate ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EndDate", endDate ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@OrganizerID", organizerId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@VenueID", venueId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@OwnerID", ownerId ?? (object)DBNull.Value);

                        // Add output parameters
                        SqlParameter totalEventsParam = new SqlParameter("@TotalEvents", SqlDbType.BigInt)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(totalEventsParam);

                        SqlParameter totalActualCostParam = new SqlParameter("@TotalActualCost", SqlDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(totalActualCostParam);

                        // Execute the procedure
                        command.ExecuteNonQuery();

                        // Retrieve the output values
                        long totalEvents = (long)totalEventsParam.Value;
                        decimal totalActualCost = totalActualCostParam.Value != DBNull.Value ? (decimal)totalActualCostParam.Value : 0;

                        // Update the labels or UI elements
                        lblTotalEvents.Text = $"Total Events: {totalEvents}";
                        lblTotalActualCost.Text = $"Total Actual Cost: {totalActualCost:C}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading aggregates: {ex.Message}");
            }
        }


        private void LoadEventSummaryReport(DateTime? startDate, DateTime? endDate, long? organizerId, int? venueId, long? ownerId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetEventSummaryReport", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.AddWithValue("@StartDate", startDate ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EndDate", endDate ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@OrganizerID", organizerId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@VenueID", venueId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@OwnerID", ownerId ?? (object)DBNull.Value);


                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable reportTable = new DataTable();
                        adapter.Fill(reportTable);

                        // Bind the data to the DataGridView
                        dataGridView1.DataSource = reportTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        private void LoadOrganizers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("select Id,FullName from UserLoginInfo where CatUserRoleId = 2\r\n", connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable organizerTable = new DataTable();
                        adapter.Fill(organizerTable);

                        DataRow defaultRow = organizerTable.NewRow();
                        defaultRow["Id"] = DBNull.Value; // Null value to represent no selection
                        defaultRow["FullName"] = "None";
                        organizerTable.Rows.InsertAt(defaultRow, 0);

                        comboBoxOrganizers.DataSource = organizerTable;
                        comboBoxOrganizers.DisplayMember = "FullName";
                        comboBoxOrganizers.ValueMember = "Id";
                        comboBoxOrganizers.SelectedIndex = 0; // Default to no selection
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading organizers: {ex.Message}");
            }
        }

        private void btnShowResults_Click(object sender, EventArgs e)
        {
            startDate = dateTimePickerStartDate.Checked ? dateTimePickerStartDate.Value.Date : (DateTime?)null;
            endDate = dateTimePickerEndDate.Checked ? dateTimePickerEndDate.Value.Date : (DateTime?)null;
            organizerId = comboBoxOrganizers.SelectedValue != DBNull.Value
                   ? (long?)comboBoxOrganizers.SelectedValue
                   : null;

            venueId = comboBoxVenues.SelectedValue != DBNull.Value
                           ? (int?)comboBoxVenues.SelectedValue
                           : null;

            ownerId = comboBoxOwners.SelectedValue != DBNull.Value
                             ? (long?)comboBoxOwners.SelectedValue
                             : null;

            LoadEventSummaryReport(startDate, endDate, organizerId, venueId, ownerId);

            LoadEventSummaryAggregates(startDate, endDate, organizerId, venueId, ownerId);


        }

        private void LoadVenues()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT VenueID, VenueName FROM Venues", connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable venueTable = new DataTable();
                        adapter.Fill(venueTable);

                        DataRow defaultRow = venueTable.NewRow();
                        defaultRow["VenueID"] = DBNull.Value; // Null value to represent no selection
                        defaultRow["VenueName"] = "None";
                        venueTable.Rows.InsertAt(defaultRow, 0);

                        comboBoxVenues.DataSource = venueTable;
                        comboBoxVenues.DisplayMember = "VenueName";
                        comboBoxVenues.ValueMember = "VenueID";
                        comboBoxVenues.SelectedIndex = 0; // Default to no selection
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading venues: {ex.Message}");
            }
        }

        private void LoadOwners()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT Id, FullName FROM UserLoginInfo WHERE CatUserRoleId = 3", connection)) // Assuming CatUserRoleId = 3 for owners
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable ownerTable = new DataTable();
                        adapter.Fill(ownerTable);

                        DataRow defaultRow = ownerTable.NewRow();
                        defaultRow["Id"] = DBNull.Value; // Null value to represent no selection
                        defaultRow["FullName"] = "None";
                        ownerTable.Rows.InsertAt(defaultRow, 0);

                        comboBoxOwners.DataSource = ownerTable;
                        comboBoxOwners.DisplayMember = "FullName";
                        comboBoxOwners.ValueMember = "Id";
                        comboBoxOwners.SelectedIndex = 0; // Default to no selection
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading owners: {ex.Message}");
            }
        }

        private void EventSummaryReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           adminForm1 admin = new adminForm1();
            admin.MdiParent = this.MdiParent;
            admin.Show();
        }
    }
}
