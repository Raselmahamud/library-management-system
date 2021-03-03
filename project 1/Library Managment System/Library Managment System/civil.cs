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
    public partial class civil : Form
    {
        SqlConnection conn = new SqlConnection();
        public civil()
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
            comm.CommandText = "insert into CivilTable1 (BookName,Author,Publisher,Version,Quantity) values('" + ciBookName.Text + "','" + ciAuthor.Text + "','" + ciPublisher.Text + "','" + ciVersion.Text + "','" +ciQuantity.Text + "')";

            comm.ExecuteNonQuery();
            MessageBox.Show("Book ADD successfulluy");

            conn.Close();
            populatel();
        }
        public void populatel()
        {
            conn.Open();
            String query = "select * from CivilTable1";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            cibookDGV.DataSource = ds.Tables[0];
            conn.Close();


        }

        private void civil_Load(object sender, EventArgs e)
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
            if (ciBookName.Text == "")
            {
                MessageBox.Show("Enter The BookName ");

            }
            else
            {
                conn.Open();
                string query = "delete from CivilTable1 where BookName ='" + ciBookName.Text + "';";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("Book successfully Deleted ");
                conn.Close();
                populatel();
            }
        }

        private void EDIT_Click(object sender, EventArgs e)
        {
            if (ciBookName.Text == "" || ciAuthor.Text == "" || ciPublisher.Text == "" || ciVersion.Text == "" || ciQuantity.Text == "")
            {
                MessageBox.Show("Missing Information");


            }
            else
            {
                conn.Open();

                string query = "update CivilTable1 set Author ='" + ciAuthor.Text + "',Publisher='" + ciPublisher.Text + "',Version='" + ciVersion.Text + "',Quantity='" + ciQuantity.Text + "' where BookName='" + ciBookName.Text + "';";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("Book Successfully Update");

                conn.Close();
                populatel();
            }
        }

        private void bookDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ciBookName.Text = cibookDGV.SelectedRows[0].Cells[0].Value.ToString();
            ciAuthor.Text = cibookDGV.SelectedRows[0].Cells[1].Value.ToString();
            ciPublisher.Text = cibookDGV.SelectedRows[0].Cells[2].Value.ToString();
            ciVersion.Text = cibookDGV.SelectedRows[0].Cells[3].Value.ToString();
            ciQuantity.Text = cibookDGV.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
}
