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
    public partial class IssueBooks : Form
    {
        SqlConnection conn = new SqlConnection();
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
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
            Homepage Home = new Homepage();
            Home.Show();
            this.Hide();
        }
        private void FillStudent()
        {
            conn.Open();
            SqlCommand cmmd = new SqlCommand("select stid from studenttable1", conn);
            SqlDataReader rdrr;
            rdrr = cmmd.ExecuteReader();
            DataTable dtt = new DataTable();
            dtt.Columns.Add("stid", typeof(int));
            dtt.Load(rdrr);
            Istd.ValueMember = "stid";
            Istd.DataSource = dtt;
            conn.Close();
        }
        
        private void FillBook()
        {
            conn.Open();
            SqlCommand cmmd = new SqlCommand("select BookName from csetable1", conn);
            
            SqlDataReader rdrr;
            rdrr = cmmd.ExecuteReader();
           
            DataTable dtt = new DataTable();
            dtt.Columns.Add("BookName", typeof(string));
            dtt.Load(rdrr);
           
            ibook.ValueMember = "BookName";
            ibook.DataSource = dtt;
            
            conn.Close();
        }
       
        private void fetchstddata()
        {
            conn.Open();
            string query = "select * from studenttable1 where stid=" + Istd.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter daa= new SqlDataAdapter(cmd);
            daa.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                stNametb.Text = dr["stName"].ToString();
                istDepartment.Text = dr["stDepartment"].ToString();
                istPhone.Text = dr["stPhone"].ToString();


            }

            conn.Close();


          }
        


        private void IssueBooks_Load(object sender, EventArgs e)
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
            FillStudent();
            FillBook();
           
            populatel();
            
        }

        private void Istd_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void Istd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchstddata();
        }
        public void populatel()
        {
            conn.Open();
            String query = "select * from issuebooktable1";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            issueDGV.DataSource = ds.Tables[0];
            conn.Close();


        }
        private void ADD_Click(object sender, EventArgs e)
        {

            string date = issueDate.Value.Year.ToString();
            conn.Open();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandText = "insert into issuebooktable1  values('" + lssuNumber.Text + "','" + Istd.SelectedValue.ToString() + "','" + stNametb.Text + "','" + istDepartment.Text + "','" + istPhone.Text + "','"+ ibook.SelectedValue.ToString()+"','" + date + "')";

            int v = comm.ExecuteNonQuery();
            MessageBox.Show("Issue Book successfulluy");

            conn.Close();
            populatel();
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            if (lssuNumber.Text == "")
            {
                MessageBox.Show("Enter The Issue Number");

            }
            else
            {
                conn.Open();
                string query = "delete from issuebooktable1 where IssueNum =" + lssuNumber.Text + ";";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show(" successfully Deleted ");
                conn.Close();
                populatel();
            }
        }

        private void EDIT_Click(object sender, EventArgs e)
        {

            if (lssuNumber.Text == "" || Istd.SelectedValue.ToString() == "" || stNametb.Text == "" || istDepartment.Text == "" || istPhone.Text == ""|| ibook.SelectedValue.ToString()== ""|| issueDate.Text=="")
            {
                MessageBox.Show("Missing Information");


            }
            else
            {
                conn.Open();
                string query = "update issuebooktable1 set stid ='"+ Istd.SelectedValue.ToString()+"',stName='" + stNametb.Text +"',stDepartment='"+istDepartment.Text+"',stPhone='"+istPhone+ "',IssueBook='"+ ibook.SelectedValue.ToString() + "',IssueDate='"+issueDate.Text+"' where IssueNum='" + lssuNumber.Text  + "';";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("Issue book Successfully Update");
                conn.Close();
                populatel();
            }
        }

        private void librariansDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lssuNumber.Text = issueDGV.SelectedRows[0].Cells[0].Value.ToString();
            Istd.SelectedValue = issueDGV.SelectedRows[0].Cells[1].Value.ToString();
            stNametb.Text = issueDGV.SelectedRows[0].Cells[2].Value.ToString();
            istDepartment.Text = issueDGV.SelectedRows[0].Cells[3].Value.ToString();
            istPhone.Text = issueDGV.SelectedRows[0].Cells[4].Value.ToString();
            ibook.SelectedValue = issueDGV.SelectedRows[0].Cells[5].Value.ToString();
            issueDate.Text = issueDGV.SelectedRows[0].Cells[6].Value.ToString();
        }
    }
}
