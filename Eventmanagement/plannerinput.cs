using MaterialSkin.Controls;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Eventmanagement
{
    public partial class plannerinput : MaterialForm
    {
        public plannerinput()
        {
            InitializeComponent();
        }

        public static string compName;

        private void plannerinput_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            signup room = new signup();
            room.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string companyname = textBox1.Text;
            string password = textBox2.Text;
            compName = companyname;
            if (companyname == String.Empty || password == String.Empty)
            {
                MessageBox.Show("Fill in all the required fields");
            }
            try
            {
                string connectionstring = "Server=localhost\\SQLEXPRESS;Database=csharpproject;Trusted_Connection=True";

                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();

                string query = "SELECT * FROM vendors WHERE companyname = @compname";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@compname", companyname);
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string db_password = reader.GetString(3);
                    if (db_password == password)
                    {
                        MessageBox.Show("Log in successful");
                        this.Close();
                        itemEntry rap = new itemEntry();
                        rap.Show();
                    }
                    else
                    {
                        MessageBox.Show("Password incorrect");
                    }
                }
                else
                {
                    MessageBox.Show("Company name incorrect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
