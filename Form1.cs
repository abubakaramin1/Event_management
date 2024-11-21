using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Event_management;

namespace Event_management
{
    public partial class Form1 : Form
    {
        int numericValue;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void PopulateComboBox()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>
    {
        new ComboBoxItem { Text = "Admin", Id = 1 },
        new ComboBoxItem { Text = "Event Organizer", Id = 2 },
        new ComboBoxItem { Text = "Event Owner", Id = 3 },

    };

            comboBox1.DataSource = items;
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox1.SelectedItem;

            if (selectedItem != null)
            {
                numericValue = selectedItem.Id;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            String Password = textBox2.Text;
           
            string query = "SELECT * FROM UserLoginInfo WHERE UserName = @username AND Password = @password AND CatUserRoleId = @role";
            string connectionString = "Data Source=(local);Initial Catalog=event_management;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", Password);
                command.Parameters.AddWithValue("@role", numericValue);


                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    long userId = (long)reader["Id"];
                    frm_Main frmMain = new frm_Main(userId);

                    frmMain.Show();
                    this.Hide();
                    frmMain.FormClosed += (s, args) => this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username, password . Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
               

         


            }


        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
        }
    }




}
