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
    public partial class YearlyReport : Form
    {
        public YearlyReport()
        {
            InitializeComponent();
            PopulateYearComboBox();
        }

        private void PopulateYearComboBox()
        {
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear - 10; year <= currentYear; year++)
            {
                comboBoxYear.Items.Add(year);
            }
            comboBoxYear.SelectedIndex = 0; 
        }


        private void YearlyReport_Load(object sender, EventArgs e)
        {

        }

        private void btnFetchSummary_Click(object sender, EventArgs e)
        {
            if (comboBoxYear.SelectedItem == null)
            {
                MessageBox.Show("Please select a year.");
                return;
            }

            int selectedYear = Convert.ToInt32(comboBoxYear.SelectedItem);

            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("GetYearlySummary", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Year", selectedYear);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable summaryTable = new DataTable();
                        adapter.Fill(summaryTable);

                        dataGridView1.DataSource = summaryTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching data: {ex.Message}");
                }
            }
        }
    }
}
