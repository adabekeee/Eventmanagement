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
    public partial class Form1 : MaterialForm
        {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            signin user = new signin();
            user.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            signup planner = new signup();
            planner.Show();
        }
    }
}
