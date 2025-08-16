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
    public partial class Vehicle : Form
    {
        public Vehicle()
        {
            InitializeComponent();
            LoadVehicleData();
        }

        private void Vehicle_Load(object sender, EventArgs e)
        {
            LoadVehicleData(); // Load data when the form loads
        }
        private void LoadVehicleData()
        {
            string ConnectionString = "Data Source=.;Initial Catalog=Transport_Management_System;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Vehicle";
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
            string query = "insert into Vehicle (RegistrationNumber, VehicleType, Capacity, Status) values ('" + regno + "', '" + vehtype + "', '" + capacity + "', '" + status + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Vehicle Added Successfully");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = 0;

            LoadVehicleData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=.;Initial Catalog=Transport_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);

            string regno = textBox1.Text;
            string vehtype = textBox2.Text;
            string capacity = textBox3.Text;
            string status = comboBox1.SelectedItem.ToString();

            string query = "UPDATE Vehicle SET VehicleType = @VehicleType, Capacity = @Capacity, Status = @Status WHERE RegistrationNumber = @RegistrationNumber";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@VehicleType", vehtype);
                cmd.Parameters.AddWithValue("@Capacity", capacity);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@RegistrationNumber", regno);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Vehicle Updated Successfully");

                        // Clear the textboxes after editing the vehicle
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No vehicle found with the given registration number");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            LoadVehicleData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=.;Initial Catalog=Transport_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);

            string regno = textBox1.Text;

            string query = "DELETE FROM Vehicle WHERE RegistrationNumber = @RegistrationNumber";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@RegistrationNumber", regno);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Vehicle Deleted Successfully");

                        // Clear the textboxes after deleting the vehicle
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No vehicle found with the given registration number");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            LoadVehicleData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard d = new Dashboard();
            d.Show();
        }
    }
}

