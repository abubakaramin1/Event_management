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
        public event Action ResourceUpdated;
        int resourceid;
        public resourcesForm(int resourceID)
        {
            InitializeComponent();
            this.resourceid = resourceID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show input box to get the new quantity from the user
            string input = ShowInputBox("Enter the new quantity:", "Set Quantity");

            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int newQuantity))
            {
                try
                {
                    // Query to update the quantity in the database
                    string updateQuantityQuery = "UPDATE Resources SET Quantity = @newQuantity WHERE ResourceID = @resourceid";

                    using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                    {
                        connection.Open();

                        // Update the quantity directly in the database
                        SqlCommand updateCmd = new SqlCommand(updateQuantityQuery, connection);
                        updateCmd.Parameters.AddWithValue("@newQuantity", newQuantity);
                        updateCmd.Parameters.AddWithValue("@resourceid", resourceid);
                        updateCmd.ExecuteNonQuery();

                        // Update the textBox3 to display the new quantity
                        textBox3.Text = newQuantity.ToString();

                        
                        ResourceUpdated?.Invoke(); // Trigger the event to notify the change
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating quantity: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Invalid input! Please enter a numeric value.");
            }
        }


        public static string ShowInputBox(string prompt, string title)
        {
            Form inputForm = new Form();
            inputForm.Text = title;
            System.Windows.Forms.TextBox txtInput = new System.Windows.Forms.TextBox { Left = 10, Top = 10, Width = 200 };
            System.Windows.Forms.Button btnOK = new System.Windows.Forms.Button { Text = "OK", Left = 10, Top = 40 };

            btnOK.Click += (sender, e) => { inputForm.DialogResult = DialogResult.OK; inputForm.Close(); };

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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "UPDATE Resources SET Cost = @cost, Quantity = @quantity WHERE ResourceID = @resourceid";

                using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(updateQuery, connection);
                    cmd.Parameters.AddWithValue("@cost", decimal.Parse(textBox2.Text)); // Cost from textBox2
                    cmd.Parameters.AddWithValue("@quantity", int.Parse(textBox3.Text)); // Quantity from textBox3
                    cmd.Parameters.AddWithValue("@resourceid", resourceid);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Resource updated successfully!");

                        // Trigger the ResourceUpdated event to notify updateResources
                        ResourceUpdated?.Invoke();

                        this.Close(); // Close the current form after updating
                    }
                    else
                    {
                        MessageBox.Show("No changes were made to the resource.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating resource: {ex.Message}");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers, one decimal point, and backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Show input box to get the new cost from the user
            string input = ShowInputBox("Enter the new cost:", "Update Cost");

            if (!string.IsNullOrEmpty(input) && decimal.TryParse(input, out decimal newCost))
            {
                try
                {
                    // Query to update the cost in the database
                    string updateCostQuery = "UPDATE Resources SET Cost = @newCost WHERE ResourceID = @resourceid";

                    using (SqlConnection connection = new SqlConnection(Class1.connectionString))
                    {
                        connection.Open();

                        // Update the cost in the database
                        SqlCommand updateCmd = new SqlCommand(updateCostQuery, connection);
                        updateCmd.Parameters.AddWithValue("@newCost", newCost);
                        updateCmd.Parameters.AddWithValue("@resourceid", resourceid);
                        updateCmd.ExecuteNonQuery();

                        // Update the textBox2 to display the updated cost
                        textBox2.Text = newCost.ToString();

                        ResourceUpdated?.Invoke(); // Trigger the event to notify the change
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating cost: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Invalid input! Please enter a numeric value.");
            }
        }

    }
}
