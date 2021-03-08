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
    public partial class lodingpage : Form
    {
        public lodingpage()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        int startpoint = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 5;
            myprogress.Value = startpoint;
            if(myprogress.Value == 100)
            {
                myprogress.Value = 0;
                timer1.Stop();
                loginpage log = new loginpage();
                log.Show();
                this.Hide();
            }
        }

        private void lodingpage_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
