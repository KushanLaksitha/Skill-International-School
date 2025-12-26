using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_International_School
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
               textBox1.Clear();
               textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
			string username = "admin";
			string password = "admin123";
			string user = textBox1.Text;
			string pass = textBox2.Text;
			if (user.Equals(username) && pass.Equals(password))
			{
				dashboard dash = new dashboard();
				dash.ShowDialog();

			}



			else
			{
				MessageBox.Show("Invalid Username or Password!");

			}
		}
    }
}
