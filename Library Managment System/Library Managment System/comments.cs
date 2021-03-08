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
    public partial class comments : Form
    {
        SqlConnection conn = new SqlConnection();
        public comments()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void comments_Load(object sender, EventArgs e)
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
            populatel();
        }

        public void populatel()
        {
            conn.Open();
            String query = "select * from CommentsTable";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            commentDGV.DataSource = ds.Tables[0];
            conn.Close();


        }
        private void comment_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "insert into CommentsTable  values('" + title.Text + "','" + text.Text + "')";

            comm.ExecuteNonQuery();
            MessageBox.Show(" ADD successfulluy");

            conn.Close();
            populatel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (title.Text == "")
            {
                MessageBox.Show("Enter Title");

            }
            else
            {
                conn.Open();
                string query = "delete from CommentsTable where Title= '" + title.Text + "';";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show(" successfully Deleted ");
                conn.Close();
                populatel();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Homepage Home = new Homepage();
            Home.Show();
            this.Hide();
        }

        private void commentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            title.Text = commentDGV.SelectedRows[0].Cells[0].Value.ToString();
            text.Text = commentDGV.SelectedRows[0].Cells[1].Value.ToString();
        }
    }
}
