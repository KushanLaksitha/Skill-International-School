using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Skill_International_School
{
	public partial class ViewAll : Form
    {
		SqlConnection con = null;
		public ViewAll()
        {
			con = new SqlConnection("Data Source=Kushanlk;Initial Catalog=Skill_international_db;Integrated Security=True;");
			InitializeComponent();
        }

        private void ViewAll_Load(object sender, EventArgs e)
        {
			try
			{

				con.Open();
				// label3.Text = "Connection Successfull!";

				SqlCommand cmd = con.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "select * from students";
				cmd.ExecuteNonQuery();
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
				dataGridView1.DataSource = dt;

				con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error" + ex);
			}
		}

        private void button1_Click(object sender, EventArgs e)
        {
			this.Close();
		}

        private void button2_Click(object sender, EventArgs e)
        {
			this.Hide();
			Register dash = new Register();
			dash.ShowDialog();
		}
    }
}
