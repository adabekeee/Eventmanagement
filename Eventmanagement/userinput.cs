using MaterialSkin.Controls;
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

namespace Eventmanagement
{
    public partial class userinput : MaterialForm
    {
        public static string email;
        public userinput()
        {
            InitializeComponent();
        }

        private void userinput_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            signin lap = new signin();
            lap.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            email = textBox1.Text;
            string password = textBox2.Text;

            if(email == string.Empty || password == string.Empty)
            {
                MessageBox.Show("Fill in all the required fields");
            }

            try
            {
                string connectionstring = "Server=localhost\\SQLEXPRESS;Database=csharpproject;Trusted_Connection=True";

                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();

                String query = "SELECT * FROM users WHERE emailaddress = @email";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string db_password = reader.GetString(4);
                    if (db_password == password)
                    {
                        MessageBox.Show("Log in Successful");
                        this.Hide();
                        order rack = new order();
                        rack.Show();

                    }
                    else
                    {
                        MessageBox.Show("Wrong password entered");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong email address entered");
                } 
            } 
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
        }
    }
}
