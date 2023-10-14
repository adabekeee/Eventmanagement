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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace Eventmanagement
{
    public partial class plannerregistration : MaterialForm
    {
        public static string companyname;
        Form1 back = new Form1();
        public plannerregistration()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            back.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstname = textBox1.Text;
            string lastname = textBox2.Text;
            companyname = textBox3.Text;
            string phonenumber = textBox4.Text;
            string emailaddress = textBox5.Text;
            string location = textBox6.Text;
            string password = textBox7.Text;

            if (firstname == String.Empty || lastname == String.Empty || companyname ==  String.Empty || phonenumber == String.Empty || emailaddress == String.Empty || location == String.Empty || password == String.Empty ) {
                MessageBox.Show("Fill all the required fields");
            }
            try
            {

                string connectionString = "Server=localhost\\SQLEXPRESS;Database=csharpproject;Trusted_Connection=True";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "INSERT INTO vendors (firstname, lastname, phonenumber, emailaddress, location, password, companyname) VALUES (@finame, @laname, @phonumber, @emailadd, @locon, @pasord, @compname)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@finame", firstname);
                command.Parameters.AddWithValue("@laname", lastname);
                command.Parameters.AddWithValue("@phonumber", phonenumber);
                command.Parameters.AddWithValue("@emailadd", emailaddress);
                command.Parameters.AddWithValue("@locon", location);
                command.Parameters.AddWithValue("@pasord", password);
                command.Parameters.AddWithValue("@compname", companyname);
                command.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
             this.Close();
             itemEntry enter = new itemEntry();
             enter.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            signup form = new signup();   
            form.Show();
        }
    }
}
