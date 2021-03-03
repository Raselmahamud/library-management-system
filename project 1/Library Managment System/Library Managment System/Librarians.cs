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
    public partial class Librarians : Form
    {
        SqlConnection conn = new SqlConnection();
        public Librarians()
        {
            InitializeComponent();
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
            Homepage Home = new Homepage();
            Home.Show();
            this.Hide();

        }

        private void Librarians_Load(object sender, EventArgs e)
        {
              
            try
            {
                
                conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\6th Semester\sd2\Full Project\library managment system\DataBase\librarymanagment.mdf;Integrated Security=True;Connect Timeout=30;";
                conn.Open();
                
                
                conn.Close();
            }
            catch(Exception es)
            {
                MessageBox.Show("Error" +  es);
            }
            populatel();

        }
        public void populatel()
        {
            conn.Open();
            String query = "select * from librarianstable1";
            SqlDataAdapter da = new SqlDataAdapter(query,conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            librariansDGV.DataSource = ds.Tables[0];
            conn.Close();
                

        }

        private void ADD_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "insert into librarianstable1 (liid,liName,liPassword,liPhone) values('"+liid.Text+"','" +liName.Text +"','" + liPassword.Text+"','" +liPhone.Text +"')";

            comm.ExecuteNonQuery();
            MessageBox.Show("Libririans ADD successfulluy");

            conn.Close();
            populatel();
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            if ( liid.Text== "")
            {
                MessageBox.Show("Enter The Librarin ID");

            }
            else
            {
                conn.Open();
                string query = "delete from librarianstable1 where liid=" + liid.Text + ";";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("Libririan successfully Deleted ");
                conn.Close();
                populatel();
            }
        }

        private void librarianDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void EDIT_Click(object sender, EventArgs e)
        {
            if(liid.Text==""|| liName.Text==""||liPassword.Text==""||liPhone.Text=="")
                {
                MessageBox.Show("Missing Information");


            }
            else
            { conn.Open();

                string query = "update librarianstable1 set liName='"+liName.Text+"',liPassword ='" + liPassword.Text + "',liPhone='" + liPhone.Text + "' where liid='" + liid.Text + "';";
                SqlCommand comm = new SqlCommand(query,conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("Librarian Successfully Update");

                conn.Close();
                populatel();

            }
        }

        private void librariansDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            liid.Text = librariansDGV.SelectedRows[0].Cells[0].Value.ToString();
            liName.Text = librariansDGV.SelectedRows[0].Cells[1].Value.ToString();
            liPassword.Text = librariansDGV.SelectedRows[0].Cells[2].Value.ToString();
            liPhone.Text = librariansDGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void liName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void liid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void liPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void liPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
