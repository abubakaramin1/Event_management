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

namespace Event_management
{
    public partial class RegisterOrganizer : Form
    {
        public RegisterOrganizer()
        {
            InitializeComponent();
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(local);Initial Catalog=event_management;Integrated Security=True;TrustServerCertificate=True";
            string username = textBox1.Text;
            string password = textBox2.Text;
            int catuserrole = 2;
            string fullname = textBox3.Text;
            string email = textBox4.Text;
            string phone = textBox5.Text;

            string query = "insert into UserLoginInfo values\r\n(@username, @password, @catuserrole, @fullname, @email, @phone)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@catuserrole", catuserrole);
                    command.Parameters.AddWithValue("@fullname", fullname);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@phone", phone);
                    try
                    {

                        connection.Open();


                        int rowsAffected = command.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Organizer added successfully.");
                            this.Close();


                        }
                        else
                        {
                            MessageBox.Show("Error occured in registering event");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }
    }
}
