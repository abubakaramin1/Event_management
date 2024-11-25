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
    public partial class frm_registerowner : Form
    {
        int catuserrole = 0;
        string query = null;
        public frm_registerowner()
        {
            InitializeComponent();
        }

        private void frm_registerowner_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (Class1.add_flag == 1)
            {
               query = "INSERT INTO UserLoginInfo (UserName, [Password], CatUserRoleId, FullName, Email, PhoneNumber) " +
                  "VALUES (@UserName, @Password, @CatUserRoleId, @FullName, @Email, @PhoneNumber)";
                catuserrole = 3;
            }
            else if (Class1.add_flag == 2)
            {
                catuserrole = 2;
                query = "insert into UserLoginInfo values\r\n(@UserName, @Password, @CatUserRoleId, @FullName, @Email, @PhoneNumber)";
            }
            

            using (SqlConnection connection = new SqlConnection(Class1.connectionString))   
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters with their values
                    command.Parameters.AddWithValue("@UserName", txt_username.Text.Trim());
                    command.Parameters.AddWithValue("@Password", txt_password.Text.Trim());
                    command.Parameters.AddWithValue("@CatUserRoleId", catuserrole); 
                    command.Parameters.AddWithValue("@FullName", txt_Name.Text.Trim());
                    command.Parameters.AddWithValue("@Email", txt_email.Text.Trim());
                    command.Parameters.AddWithValue("@PhoneNumber", txt_phonenumber.Text.Trim());

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User added successfully!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add the user.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
        }
    }
}
