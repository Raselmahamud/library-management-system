﻿using System;
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
    public partial class Math : Form
    {
        SqlConnection conn = new SqlConnection();
        public Math()
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
            comm.CommandText = "insert into MathTable (BookName,Author,Publisher,Version,Quantity) values('" + maBookName.Text + "','" + maAuthor.Text + "','" + maPublisher.Text + "','" + maVersion.Text + "','" + maQuantity.Text + "')";

            comm.ExecuteNonQuery();
            MessageBox.Show("Book ADD successfulluy");

            conn.Close();
            populatel();
        }

        private void Math_Load(object sender, EventArgs e)
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
            String query = "select * from MathTable";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            mabookDGV.DataSource = ds.Tables[0];
            conn.Close();


        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            if (maBookName.Text == "")
            {
                MessageBox.Show("Enter The BookName ");

            }
            else
            {
                conn.Open();
                string query = "delete from MathTable where BookName ='" + maBookName.Text + "';";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("Book successfully Deleted ");
                conn.Close();
                populatel();
            }
        }

        private void EDIT_Click(object sender, EventArgs e)
        {
            if (maBookName.Text == "" || maAuthor.Text == "" || maPublisher.Text == "" || maVersion.Text == "" || maQuantity.Text == "")
            {
                MessageBox.Show("Missing Information");


            }
            else
            {
                conn.Open();

                string query = "update MathTable set Author ='" + maAuthor.Text + "',Publisher='" + maPublisher.Text + "',Version='" + maVersion.Text + "',Quantity='" + maQuantity.Text + "' where BookName='" + maBookName.Text + "';";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("Book Successfully Update");

                conn.Close();
                populatel();
            }
        }

        private void bookDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maBookName.Text = mabookDGV.SelectedRows[0].Cells[0].Value.ToString();
            maAuthor.Text = mabookDGV.SelectedRows[0].Cells[1].Value.ToString();
            maPublisher.Text = mabookDGV.SelectedRows[0].Cells[2].Value.ToString();
            maVersion.Text = mabookDGV.SelectedRows[0].Cells[3].Value.ToString();
            maQuantity.Text = mabookDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            String query = "select * from MathTable";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            mabookDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Search_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "select * from MathTable where BookName = '" + serch.Text + "' or Author= '" + serch.Text + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            mabookDGV.DataSource = ds.Tables[0];
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            maBookName.Text = " ";
            maAuthor.Text = " ";
            maPublisher.Text = " ";
            maVersion.Text = " ";
            maQuantity.Text = " ";

        }
    }
}
