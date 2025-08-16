using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Passenger : Form
    {
        public Passenger()
        {
            InitializeComponent();
            LoadPassengerData();
        }

        private void LoadPassengerData()
        {
            string ConnectionString = "Data Source=.;Initial Catalog=Transport_Management_System;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Passenger";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard d = new Dashboard();
            d.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=.;Initial Catalog=Transport_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string name = textBox1.Text;
            string contactInfo = textBox2.Text;
            string query = "insert into Passenger (Name, ContactInfo) values (@Name, @ContactInfo)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@ContactInfo", contactInfo);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Passenger Added Successfully");

            textBox1.Clear();
            textBox2.Clear();
            con.Close();
            LoadPassengerData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=.;Initial Catalog=Transport_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string name = textBox1.Text; // Assuming textBox1 contains the Name
            string contactInfo = textBox2.Text;

            // Check if the name exists in the database
            string checkQuery = "SELECT COUNT(*) FROM Passenger WHERE Name = @Name";
            SqlCommand checkCmd = new SqlCommand(checkQuery, con);
            checkCmd.Parameters.AddWithValue("@Name", name);
            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                // Name exists, proceed with the update
                string updateQuery = "UPDATE Passenger SET ContactInfo = @ContactInfo WHERE Name = @Name";
                SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                updateCmd.Parameters.AddWithValue("@Name", name);
                updateCmd.Parameters.AddWithValue("@ContactInfo", contactInfo);
                updateCmd.ExecuteNonQuery();
                MessageBox.Show("Passenger Updated Successfully");
            }
            else
            {
                // Name does not exist, show an error message
                MessageBox.Show("Name not found in the database.");
            }

            // Clear the text boxes
            textBox1.Clear();
            textBox2.Clear();
            con.Close();
            LoadPassengerData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=.;Initial Catalog=Transport_Management_System;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string name = textBox1.Text; // Assuming textBox1 contains the Name

            // Check if the name exists in the database
            string checkQuery = "SELECT COUNT(*) FROM Passenger WHERE Name = @Name";
            SqlCommand checkCmd = new SqlCommand(checkQuery, con);
            checkCmd.Parameters.AddWithValue("@Name", name);
            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                // Name exists, proceed with the delete
                string deleteQuery = "DELETE FROM Passenger WHERE Name = @Name";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, con);
                deleteCmd.Parameters.AddWithValue("@Name", name);
                deleteCmd.ExecuteNonQuery();
                MessageBox.Show("Passenger Deleted Successfully");
            }
            else
            {
                // Name does not exist, show an error message
                MessageBox.Show("Name not found in the database.");
            }

            // Clear the text box
            textBox1.Clear();
            con.Close();
            LoadPassengerData();
        }
    }
}
