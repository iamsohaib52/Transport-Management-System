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

namespace LoginForm
{
    public partial class Driver : Form
    {
        public Driver()
        {
            InitializeComponent();
            LoadDriverData();
        }
        private void LoadDriverData()
        {
            string ConnectionString = "Data Source=.;Initial Catalog=Transport_Management_System;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Driver";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=.;Initial Catalog=Transport_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string regno = textBox1.Text;
            string vehtype = textBox2.Text;
            string capacity = textBox3.Text;
            string status = comboBox1.SelectedItem.ToString();
            string query = "insert into Driver (Name, LicenseNumber, ContactInfo, Status) values ('" + regno + "', '" + vehtype + "', '" + capacity + "', '" + status + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Driver Added Successfully");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = 0;
            LoadDriverData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=.;Initial Catalog=Transport_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);

            string name = textBox1.Text;
            string licenseNumber = textBox2.Text;
            string contactInfo = textBox3.Text;
            string status = comboBox1.SelectedItem.ToString();

            string query = "UPDATE Driver SET Name = @Name, ContactInfo = @ContactInfo, Status = @Status WHERE LicenseNumber = @LicenseNumber";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@ContactInfo", contactInfo);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@LicenseNumber", licenseNumber);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Driver Updated Successfully");

                        // Clear the textboxes after editing the driver
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No driver found with the given license number");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            LoadDriverData();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=.;Initial Catalog=Transport_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);

            string licenseNumber = textBox2.Text;

            string query = "DELETE FROM Driver WHERE LicenseNumber = @LicenseNumber";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@LicenseNumber", licenseNumber);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Driver Deleted Successfully");

                        // Clear the textboxes after deleting the driver
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No driver found with the given license number");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            LoadDriverData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard d = new Dashboard();
            d.Show();
        }
    }
}
