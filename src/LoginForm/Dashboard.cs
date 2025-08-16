using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Vehicle v = new Vehicle();
            v.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Driver d = new Driver();
            d.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Passenger p = new Passenger();
            p.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
