using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventmanagement
{
    public partial class signup : MaterialForm
    {
        public signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            plannerregistration roof = new plannerregistration();
            roof.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            plannerinput land = new plannerinput();
            land.Show();
        }

        private void signup_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loop = new Form1();
            loop.Show();
        }
    }
}
