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
using System.Xml.Linq;

namespace Eventmanagement
{
    public partial class userregistration : MaterialForm
    {
        public static string email;
        signin Back = new signin();
        public userregistration()
        {
            InitializeComponent();
        }

        private void userregistration_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Back.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            string lname = textBox2.Text;
            string phoneno = textBox3.Text;
            email = textBox4.Text;
            string locate = textBox5.Text;
            string security = textBox6.Text;

            if (fname == String.Empty || lname == String.Empty || phoneno == String.Empty || email == String.Empty || locate == String.Empty || security == String.Empty)
            {
                MessageBox.Show("Fill in all the required fields");
            } 
            try
            {

                string connectionString = "Server=localhost\\SQLEXPRESS;Database=csharpproject;Trusted_Connection=True";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "INSERT INTO users (firstname, lastname, phonenumber, emailaddress, location, password) VALUES (@finame, @laname, @phonumber, @emailadd, @locon, @pasord)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@finame", fname);
                command.Parameters.AddWithValue("@laname", lname);
                command.Parameters.AddWithValue("@phonumber", phoneno);
                command.Parameters.AddWithValue("@emailadd", email);
                command.Parameters.AddWithValue("@locon", locate);
                command.Parameters.AddWithValue("@pasord", security);
                command.ExecuteNonQuery();

                connection.Close();

            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            this.Hide();
            order room = new order();
            room.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
