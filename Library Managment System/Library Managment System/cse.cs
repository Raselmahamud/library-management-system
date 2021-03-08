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
    public partial class cse : Form
    {
        SqlConnection conn = new SqlConnection();
        public cse()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
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

        private void HOME_Click(object sender, EventArgs e)
        {
            Department Home = new Department();
            Home.Show();
            this.Hide();

        }

        private void Books_Load(object sender, EventArgs e)
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
            String query = "select * from csetable1";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            bookDGV.DataSource = ds.Tables[0];
            conn.Close();


        }

        private void ADD_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "insert into csetable1 (BookName,Author,Publisher,Price,Quantity) values('" + BookName.Text + "','" + Author.Text + "','" + Publisher.Text + "','" + Price.Text + "','" + Quantity.Text + "')";

            comm.ExecuteNonQuery();
            MessageBox.Show("Book ADD successfulluy");

            conn.Close();
            populatel();
        }

        private void DELETE_Click(object sender, EventArgs e)
        {

            if (BookName.Text == "")
            {
                MessageBox.Show("Enter The BookName ");

            }
            else
            {
                conn.Open();
                string query = "delete from csetable1 where BookName ='" + BookName.Text + "';";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("Book successfully Deleted ");
                conn.Close();
                populatel();
            }
        }

        private void EDIT_Click(object sender, EventArgs e)
        {
            if (BookName.Text == "" || Author.Text == "" || Publisher.Text == "" || Price.Text == "" || Quantity.Text == "")
            {
                MessageBox.Show("Missing Information");


            }
            else
            {
                conn.Open();

                string query = "update csetable1 set Author ='" + Author.Text + "',Publisher='" + Publisher.Text + "',Price='" + Price.Text + "',Quantity='" + Quantity.Text + "' where BookName='" + BookName.Text + "';";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("Book Successfully Update");

                conn.Close();
                populatel();
            }
        }

        private void librariansDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BookName.Text = bookDGV.SelectedRows[0].Cells[0].Value.ToString();
            Author.Text = bookDGV.SelectedRows[0].Cells[1].Value.ToString();
            Publisher.Text = bookDGV.SelectedRows[0].Cells[2].Value.ToString();
            Price.Text = bookDGV.SelectedRows[0].Cells[3].Value.ToString();
            Quantity.Text = bookDGV.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
    }
