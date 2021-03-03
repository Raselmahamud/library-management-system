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
using System.Data.OleDb;

namespace Library_Managment_System
{
    public partial class loginpage : Form
    {
        SqlConnection conn = new SqlConnection();
        public loginpage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\6th Semester\sd2\Full Project\library managment system\DataBase\librarymanagment.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM librarianstable1 WHERE  liName='" + username.Text + "' AND liPassword='" + password.Text + "'", conn);


            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {

                Homepage homr = new Homepage();
                new Homepage().Show();

                this.Hide();


            }
            else
            {
                MessageBox.Show(" Wrong UserName and Password");
            }

           



        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            username.Text = "";
            password.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void loginpage_Load(object sender, EventArgs e)
        {
            try
            {

                conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\6th Semester\sd2\Full Project\library managment system\DataBase\librarymanagment.mdf;Integrated Security=True;Connect Timeout=30;";
                conn.Open();


                conn.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show("Error" + es);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            singup Home = new singup();
            Home.Show();
            this.Hide();
        }
    }
}
