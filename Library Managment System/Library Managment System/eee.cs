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
    public partial class eee : Form
    {
        SqlConnection conn = new SqlConnection();
        public eee()
        {
            InitializeComponent();
        }

        private void HOME_Click(object sender, EventArgs e)
        {
            Department Home = new Department();
            Home.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ADD_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "insert into EEETable (BookName,Author,Publisher,Version,Quantity) values('" + eeBookName.Text + "','" + eeAuthor.Text + "','" + eePublisher.Text + "','" + eeVersion.Text + "','" + eeQuantity.Text + "')";

            comm.ExecuteNonQuery();
            MessageBox.Show("Book ADD successfulluy");

            conn.Close();
            populatel();
        }
        public void populatel()
        {
            conn.Open();
            String query = "select * from EEETable";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            eebookDGV.DataSource = ds.Tables[0];
            conn.Close();


        }
        private void eee_Load(object sender, EventArgs e)
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

        private void DELETE_Click(object sender, EventArgs e)
        {
            if (eeBookName.Text == "")
            {
                MessageBox.Show("Enter The BookName ");

            }
            else
            {
                conn.Open();
                string query = "delete from EEETable where BookName ='" + eeBookName.Text + "';";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("Book successfully Deleted ");
                conn.Close();
                populatel();
            }
        }

        private void EDIT_Click(object sender, EventArgs e)
        {
            if (eeBookName.Text == "" || eeAuthor.Text == "" || eePublisher.Text == "" || eeVersion.Text == "" || eeQuantity.Text == "")
            {
                MessageBox.Show("Missing Information");


            }
            else
            {
                conn.Open();

                string query = "update EEETable set Author ='" + eeAuthor.Text + "',Publisher='" + eePublisher.Text + "',Version='" + eeVersion.Text + "',Quantity='" + eeQuantity.Text + "' where BookName='" + eeBookName.Text + "';";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("Book Successfully Update");

                conn.Close();
                populatel();
            }
        }

        private void bookDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            eeBookName.Text = eebookDGV.SelectedRows[0].Cells[0].Value.ToString();
            eeAuthor.Text = eebookDGV.SelectedRows[0].Cells[1].Value.ToString();
            eePublisher.Text = eebookDGV.SelectedRows[0].Cells[2].Value.ToString();
            eeVersion.Text = eebookDGV.SelectedRows[0].Cells[3].Value.ToString();
            eeQuantity.Text = eebookDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void searchb_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "select * from EEETable where BookName = '" + searche.Text + "' or Author= '" + searche.Text + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            eebookDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            String query = "select * from EEETable";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            eebookDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            eeBookName.Text = " ";
            eeAuthor.Text = " ";
            eePublisher.Text = " ";
            eeVersion.Text = " ";
            eeQuantity.Text = " ";
        }
    }
}
