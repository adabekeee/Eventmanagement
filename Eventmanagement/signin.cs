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
    public partial class signin : MaterialForm
    {
        public signin()
        {
            InitializeComponent();
        }

        private void signin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            userregistration userregistration = new userregistration();
            userregistration.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            userinput userinput = new userinput();
            userinput.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 lamb = new Form1();
            lamb.Show();
        }
    }
}
