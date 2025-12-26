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

namespace Skill_International_School
{
    public partial class Register : Form
	{
		SqlConnection con = null;
		public Register()
        {
			con = new SqlConnection("Data Source=Kushanlk;Initial Catalog=Skill_international_db;Integrated Security=True;");
			InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
			loadtable();

	   }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
			try
			{
				con.Open();
				IsCheck();
				SqlCommand cmd = new SqlCommand(
				    @"INSERT INTO students
					(fName, lName, dateOfBirth, gender, address, email,
					 mobilePhone, homePhone, parentName, NIC, contactNo)
					VALUES
					(@fName, @lName, @dateOfBirth, @gender, @address, @email,
					 @mobilePhone, @homePhone, @parentName, @NIC, @contactNo)", con);

				cmd.Parameters.AddWithValue("@fName", textBoxFname.Text);
				cmd.Parameters.AddWithValue("@lName", textBoxLname.Text);
				cmd.Parameters.AddWithValue("@dateOfBirth", dateTimePicker1.Value);

				string gender = rbMale.Checked ? "Male" : "Female";
				cmd.Parameters.AddWithValue("@gender", gender);

				cmd.Parameters.AddWithValue("@address", textBoxAddress.Text);
				cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
				cmd.Parameters.AddWithValue("@mobilePhone", textBoxMobile.Text);
				cmd.Parameters.AddWithValue("@homePhone", textBoxHomeNo.Text);
				cmd.Parameters.AddWithValue("@parentName", textBoxParentName.Text);
				cmd.Parameters.AddWithValue("@NIC", textBoxNIC.Text);
				cmd.Parameters.AddWithValue("@contactNo", textBoxContactNo.Text);

				cmd.ExecuteNonQuery();
				con.Close();

				MessageBox.Show("Student record inserted successfully!");

				// Clear fields
				textBoxRegNo.Clear();
				textBoxFname.Clear();
				textBoxLname.Clear();
				textBoxAddress.Clear();
				textBoxEmail.Clear();
				textBoxMobile.Clear();
				textBoxHomeNo.Clear();
				textBoxParentName.Clear();
				textBoxNIC.Clear();
				textBoxContactNo.Clear();
				rbMale.Checked = false;
				rbFemale.Checked = false;
				dateTimePicker1.Value = DateTime.Now;
				loadtable();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}

		}

        private void IsCheck()
        {
			// Check empty fields
			if (string.IsNullOrWhiteSpace(textBoxFname.Text) ||
			    string.IsNullOrWhiteSpace(textBoxLname.Text) ||
			    string.IsNullOrWhiteSpace(textBoxAddress.Text) ||
			    string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
			    string.IsNullOrWhiteSpace(textBoxMobile.Text) ||
			    string.IsNullOrWhiteSpace(textBoxParentName.Text) ||
			    string.IsNullOrWhiteSpace(textBoxNIC.Text) ||
			    string.IsNullOrWhiteSpace(textBoxContactNo.Text))
			{
				MessageBox.Show(
				    "Please fill in all required fields.",
				    "Validation Error",
				    MessageBoxButtons.OK,
				    MessageBoxIcon.Warning
				);
				return;
			}

			// Gender validation
			if (!rbMale.Checked && !rbFemale.Checked)
			{
				MessageBox.Show(
				    "Please select Gender (Male or Female).",
				    "Validation Error",
				    MessageBoxButtons.OK,
				    MessageBoxIcon.Warning
				);
				return;
			}

		}

		private void loadtable()
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

        private void button3_Click(object sender, EventArgs e)
        {
			if (string.IsNullOrWhiteSpace(textBoxRegNo.Text))
			{
				MessageBox.Show(
				    "Please select a student record to update.",
				    "Update Error",
				    MessageBoxButtons.OK,
				    MessageBoxIcon.Warning
				);
				return;
			}

			// 2️⃣ Required fields validation
			if (string.IsNullOrWhiteSpace(textBoxFname.Text) ||
			    string.IsNullOrWhiteSpace(textBoxLname.Text) ||
			    string.IsNullOrWhiteSpace(textBoxAddress.Text) ||
			    string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
			    string.IsNullOrWhiteSpace(textBoxMobile.Text) ||
			    string.IsNullOrWhiteSpace(textBoxParentName.Text) ||
			    string.IsNullOrWhiteSpace(textBoxNIC.Text) ||
			    string.IsNullOrWhiteSpace(textBoxContactNo.Text))
			{
				MessageBox.Show(
				    "Please fill in all required fields.",
				    "Validation Error",
				    MessageBoxButtons.OK,
				    MessageBoxIcon.Warning
				);
				return;
			}

			// 3️⃣ Gender validation
			string gender = "";
			if (rbMale.Checked)
				gender = "Male";
			else if (rbFemale.Checked)
				gender = "Female";
			else
			{
				MessageBox.Show(
				    "Please select Gender (Male or Female).",
				    "Validation Error",
				    MessageBoxButtons.OK,
				    MessageBoxIcon.Warning
				);
				return;
			}

			// 4️⃣ Confirm update
			DialogResult result = MessageBox.Show(
			    "Are you sure you want to update this record?",
			    "Confirm Update",
			    MessageBoxButtons.YesNo,
			    MessageBoxIcon.Question
			);

			if (result != DialogResult.Yes)
				return;

			// 5️⃣ Update database
			try
			{
				con.Open();

				SqlCommand cmd = new SqlCommand(
				    @"UPDATE students SET
				 fName = @fName,
				 lName = @lName,
				 dateOfBirth = @dateOfBirth,
				 gender = @gender,
				 address = @address,
				 email = @email,
				 mobilePhone = @mobilePhone,
				 homePhone = @homePhone,
				 parentName = @parentName,
				 NIC = @NIC,
				 contactNo = @contactNo
			     WHERE RegNo = @RegNo", con);

				cmd.Parameters.AddWithValue("@RegNo", textBoxRegNo.Text);
				cmd.Parameters.AddWithValue("@fName", textBoxFname.Text);
				cmd.Parameters.AddWithValue("@lName", textBoxLname.Text);
				cmd.Parameters.AddWithValue("@dateOfBirth", dateTimePicker1.Value);
				cmd.Parameters.AddWithValue("@gender", gender);
				cmd.Parameters.AddWithValue("@address", textBoxAddress.Text);
				cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
				cmd.Parameters.AddWithValue("@mobilePhone", textBoxMobile.Text);
				cmd.Parameters.AddWithValue("@homePhone", textBoxHomeNo.Text);
				cmd.Parameters.AddWithValue("@parentName", textBoxParentName.Text);
				cmd.Parameters.AddWithValue("@NIC", textBoxNIC.Text);
				cmd.Parameters.AddWithValue("@contactNo", textBoxContactNo.Text);

				cmd.ExecuteNonQuery();
				con.Close();

				MessageBox.Show(
				    "Student record updated successfully!",
				    "Success",
				    MessageBoxButtons.OK,
				    MessageBoxIcon.Information
				);

				loadtable(); // Refresh DataGridView
				textBoxRegNo.Clear();
				textBoxFname.Clear();
				textBoxLname.Clear();
				textBoxAddress.Clear();
				textBoxEmail.Clear();
				textBoxMobile.Clear();
				textBoxHomeNo.Clear();
				textBoxParentName.Clear();
				textBoxNIC.Clear();
				textBoxContactNo.Clear();
				rbMale.Checked = false;
				rbFemale.Checked = false;
				dateTimePicker1.Value = DateTime.Now;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

        private void button4_Click(object sender, EventArgs e)
        {
			if (string.IsNullOrWhiteSpace(textBoxRegNo.Text))
			{
				MessageBox.Show(
				    "Please select a student record to delete.",
				    "Delete Error",
				    MessageBoxButtons.OK,
				    MessageBoxIcon.Warning
				);
				return;
			}

			// 2️⃣ Confirm delete
			DialogResult result = MessageBox.Show(
			    "Are you sure you want to delete this student record?\nThis action cannot be undone.",
			    "Confirm Delete",
			    MessageBoxButtons.YesNo,
			    MessageBoxIcon.Warning
			);

			if (result != DialogResult.Yes)
				return;

			// 3️⃣ Delete from database
			try
			{
				con.Open();

				SqlCommand cmd = new SqlCommand(
				    "DELETE FROM students WHERE RegNo = @RegNo", con);

				cmd.Parameters.AddWithValue("@RegNo", textBoxRegNo.Text);

				int rowsAffected = cmd.ExecuteNonQuery();
				con.Close();

				if (rowsAffected > 0)
				{
					MessageBox.Show(
					    "Student record deleted successfully!",
					    "Success",
					    MessageBoxButtons.OK,
					    MessageBoxIcon.Information
					);

					// Clear fields after delete
					textBoxRegNo.Clear();
					textBoxFname.Clear();
					textBoxLname.Clear();
					textBoxAddress.Clear();
					textBoxEmail.Clear();
					textBoxMobile.Clear();
					textBoxHomeNo.Clear();
					textBoxParentName.Clear();
					textBoxNIC.Clear();
					textBoxContactNo.Clear();
					rbMale.Checked = false;
					rbFemale.Checked = false;
					dateTimePicker1.Value = DateTime.Now;

					loadtable(); // Refresh DataGridView
				}
				else
				{
					MessageBox.Show(
					    "Record not found or already deleted.",
					    "Delete Failed",
					    MessageBoxButtons.OK,
					    MessageBoxIcon.Warning
					);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

        private void button5_Click(object sender, EventArgs e)
        {
			textBoxRegNo.Clear();
			textBoxFname.Clear();
			textBoxLname.Clear();
			textBoxAddress.Clear();
			textBoxEmail.Clear();
			textBoxMobile.Clear();
			textBoxHomeNo.Clear();
			textBoxParentName.Clear();
			textBoxNIC.Clear();
			textBoxContactNo.Clear();
			rbMale.Checked = false;
			rbFemale.Checked = false;
			dateTimePicker1.Value = DateTime.Now;
		}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			if (e.RowIndex < 0)
				return;

			DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

			// Load data into textboxes
			textBoxRegNo.Text = row.Cells["RegNo"].Value.ToString();
			textBoxFname.Text = row.Cells["fName"].Value.ToString();
			textBoxLname.Text = row.Cells["lName"].Value.ToString();
			textBoxAddress.Text = row.Cells["address"].Value.ToString();
			textBoxEmail.Text = row.Cells["email"].Value.ToString();
			textBoxMobile.Text = row.Cells["mobilePhone"].Value.ToString();
			textBoxHomeNo.Text = row.Cells["homePhone"].Value.ToString();
			textBoxParentName.Text = row.Cells["parentName"].Value.ToString();
			textBoxNIC.Text = row.Cells["NIC"].Value.ToString();
			textBoxContactNo.Text = row.Cells["contactNo"].Value.ToString();

			// Date of Birth
			dateTimePicker1.Value = Convert.ToDateTime(row.Cells["dateOfBirth"].Value);

			// Gender radio buttons
			string gender = row.Cells["gender"].Value.ToString();

			if (gender == "Male")
			{
				rbMale.Checked = true;
			}
			else if (gender == "Female")
			{
				rbFemale.Checked = true;
			}
		}

        private void button6_Click(object sender, EventArgs e)
        {
			// Check search box empty
			if (string.IsNullOrWhiteSpace(textBoxSearchFname.Text))
			{
				MessageBox.Show(
				    "Please enter a First Name to search.",
				    "Search Error",
				    MessageBoxButtons.OK,
				    MessageBoxIcon.Warning
				);
				return;
			}

			try
			{
				con.Open();

				SqlCommand cmd = new SqlCommand(
				    "SELECT * FROM students WHERE fName LIKE @fName", con);

				cmd.Parameters.AddWithValue("@fName", "%" + textBoxSearchFname.Text + "%");

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);

				con.Close();

				if (dt.Rows.Count > 0)
				{
					dataGridView1.DataSource = dt;
				}
				else
				{
					MessageBox.Show(
					    "No student found with the given First Name.",
					    "Search Result",
					    MessageBoxButtons.OK,
					    MessageBoxIcon.Information
					);
					dataGridView1.DataSource = null;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}
    }
}
