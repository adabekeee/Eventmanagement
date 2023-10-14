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
    public partial class order : MaterialForm
    {
        public static int ballon, table, chair, cooler, cake, canopy, poll;
        public order()
        {
            InitializeComponent();
        }

        private void order_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            signin limb = new signin();
            limb.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ballons = textBox1.Text;
            ballon = int.Parse(ballons);
            string tables = textBox2.Text; 
            table = int.Parse(tables);    
            string chairs = textBox3.Text;
            chair = int.Parse(chairs);
            string coolers = textBox4.Text;
            cooler = int.Parse(coolers);
            string cakes = textBox5.Text;
            cake = int.Parse(cakes);
            string canopies = textBox6.Text;
            canopy = int.Parse(canopies);
            string polls = textBox7.Text;
            poll = int.Parse(polls);

            if (ballons == String.Empty || tables == String.Empty || chairs == String.Empty || coolers == String.Empty || cakes == String.Empty || canopies == String.Empty || polls == String.Empty)
            {
                MessageBox.Show("Fill in the required fields");
            }
            else
            {
                this.Hide();
                company company = new company();
                company.Show();
            }


        }
    }
}
