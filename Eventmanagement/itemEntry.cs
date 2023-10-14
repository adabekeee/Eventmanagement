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
    public partial class itemEntry : MaterialForm
    {

        signup back = new signup();
        public itemEntry()
        {
            InitializeComponent();
        }

        private void itemEntry_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            back.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == String.Empty || textBox2.Text.Trim() == String.Empty || textBox3.Text.Trim() == String.Empty || textBox4.Text.Trim() == String.Empty || textBox5.Text.Trim() == String.Empty || textBox6.Text.Trim() == String.Empty || textBox7.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Enter all the required fields");
            }
            else
            {
                string ballons = textBox1.Text;
                int ballon = int.Parse(ballons);
                string tables = textBox2.Text;
                int table = int.Parse(tables);
                string chairs = textBox3.Text;
                int chair = int.Parse(chairs);
                string coolers = textBox4.Text;
                int cooler = int.Parse(coolers);
                string cakes = textBox5.Text;
                int cake = int.Parse(cakes);
                string canopies = textBox6.Text;
                int canopy = int.Parse(canopies);
                string polls = textBox7.Text;
                int poll = int.Parse(polls);


                try
                {
                    string companyname = plannerinput.compName != null ? plannerinput.compName : plannerregistration.companyname;


                    string connection = "Server=localhost\\SQLEXPRESS;Database=csharpproject;Trusted_Connection=True";

                    SqlConnection itemEnter = new SqlConnection(connection);
                    itemEnter.Open();

                    string query = "INSERT INTO items (ballons, tables, chairs, coolers, cakes, canopies, polls, companyname) VALUES (@bal, @tab, @cha, @cool, @cak, @cano, @pol, @comp)";
                    SqlCommand comm = new SqlCommand(query, itemEnter);

                    comm.Parameters.AddWithValue("@bal", ballon);
                    comm.Parameters.AddWithValue("@tab", table);
                    comm.Parameters.AddWithValue("@cha", chair);
                    comm.Parameters.AddWithValue("@cool", cooler);
                    comm.Parameters.AddWithValue("@cak", cake);
                    comm.Parameters.AddWithValue("@cano", canopy);
                    comm.Parameters.AddWithValue("@pol", poll);
                    comm.Parameters.AddWithValue("@comp", companyname);


                    var t = comm.ExecuteNonQuery();

                    itemEnter.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
