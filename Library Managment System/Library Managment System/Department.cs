using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Managment_System
{
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }

        private void HOME_Click(object sender, EventArgs e)
        {
            Homepage Home = new  Homepage();
            Home.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cse Home = new cse();
            Home.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Math Home = new Math();
            Home.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            eee Home = new eee();
            Home.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textile Home = new textile();
            Home.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            civil Home = new civil();
            Home.Show();
            this.Hide();
        }

        private void Department_Load(object sender, EventArgs e)
        {

        }
    }
}
