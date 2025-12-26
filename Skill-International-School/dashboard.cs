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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
               this.Hide();
			Register dash = new Register();
			dash.ShowDialog();
		}

        private void button2_Click(object sender, EventArgs e)
        {
               this.Hide();
			ViewAll dash = new ViewAll();
			dash.ShowDialog();
		}

        private void button3_Click(object sender, EventArgs e)
        {
                 this.Close();
		}
    }
}
