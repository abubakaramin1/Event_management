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
using static Microsoft.IO.RecyclableMemoryStreamManager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Event_management
{
    public partial class resourcesForm : Form
    {
        int resourceid;
        public resourcesForm(int resourceID)
        {
            InitializeComponent();
            this.resourceid = resourceID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = ShowInputBox("Enter a numeric value:", "Numeric Input");
            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int value))
            {
                MessageBox.Show($"You entered: {value}");
            }
            else
            {
                MessageBox.Show("Invalid input!");
            }
        }

        public static string ShowInputBox(string prompt, string title)
        {
            Form inputForm = new Form();
            inputForm.Text = title;
            System.Windows.Forms.TextBox txtInput = new System.Windows.Forms.TextBox { Left = 10, Top = 10, Width = 200 };
            System.Windows.Forms.Button btnOK = new System.Windows.Forms.Button { Text = "OK", Left = 10, Top = 40 };


            inputForm.ClientSize = new System.Drawing.Size(230, 80);
            inputForm.Controls.AddRange(new Control[] { txtInput, btnOK });
            inputForm.AcceptButton = btnOK;
            inputForm.StartPosition = FormStartPosition.CenterParent;
            inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;

            if (inputForm.ShowDialog() == DialogResult.OK)
                return txtInput.Text;

            return null;
        }

        private void resourcesForm_Load(object sender, EventArgs e)
        {
            try
            {
                string nameQuery = "SELECT r.ResourceName FROM Resources r where ResourceID = @resourceid";
                string costQuery = "SELECT r.Cost FROM Resources r where ResourceID = @resourceid";
                string QuantityQuery = "SELECT r.Quantity FROM Resources r where ResourceID = @resourceid";

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(nameQuery, connection);
                    cmd.Parameters.AddWithValue("@resourceid", resourceid);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        textBox1.Text = result.ToString();
                    }
                    else
                    {
                        textBox1.Text = "Resource: Not Available";
                    }
                }
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(costQuery, connection);
                    cmd.Parameters.AddWithValue("@resourceid", resourceid);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        textBox2.Text = result.ToString();
                    }
                    else
                    {
                        textBox2.Text = "Cost: Not Available";
                    }
                }
                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(QuantityQuery, connection);
                    cmd.Parameters.AddWithValue("@resourceid", resourceid);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        textBox3.Text = result.ToString();
                    }
                    else
                    {
                        textBox3.Text = "Quantity: Not Available";
                    }
                }

            }


            catch (Exception ex)
            {
                MessageBox.Show($"Error loading event details: {ex.Message}");
            }
        }
    }
}
