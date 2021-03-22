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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Homepage Home = new Homepage();
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

        private void Student_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Show();
            this.Hide();


        }

        private void Books_Click(object sender, EventArgs e)
        {
           Department Book = new Department();
            Book.Show();
            this.Hide();
        }

        private void IssueBooks_Click(object sender, EventArgs e)
        {
            IssueBooks Issu = new IssueBooks();
            Issu.Show();
            this.Show();

        }

        private void ReturnBooks_Click(object sender, EventArgs e)
        {
            ReturnBook Return = new ReturnBook();
            Return.Show();
            this.Hide();

        }

        private void Libarians_Click(object sender, EventArgs e)
        {
            Librarians Librarians = new Librarians();
            Librarians.Show();
            this.Hide();

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comments Home = new comments();
            Home.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            About Home = new About();
            Home.Show();
            this.Hide();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {

        }
    }
}
