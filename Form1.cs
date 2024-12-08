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
            this.BackColor = Color.FromArgb(214, 192, 179);
            this.button2 = new RoundedButton();

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
            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
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
                    Class1.organizerID = userId;
                    
                    
                    if (numericValue == 2)
                    {
                        Class1.login_flag = 2;
                        
                    }
                    else if (numericValue  == 1 )
                    {
                        Class1.login_flag = 1;
                        
                    }
                    frm_Main frmMain = new frm_Main(userId);
                    frmMain.Show();
                    this.Hide();
                    frmMain.FormClosed += (s, args) => {
                        if (frmMain.IsLogout)
                        {
                            this.Show();
                        }
                        else
                        {
                            this.Close();
                        }
                    };
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
            //this.StartPosition = FormStartPosition.CenterScreen;
            //this.WindowState = FormWindowState.Maximized;
        }
    }

    public class ComboBoxItem
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }





}
