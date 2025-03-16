using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class Loading: Form
    {
        public Loading()
        {
            InitializeComponent();
            circularProgressBar1.Value = 0;
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            circularProgressBar1.Value += 1;
            circularProgressBar1.Text = "Loading..."+circularProgressBar1.Value.ToString()+"%";
            if (circularProgressBar1.Value == 100)
            {
                timer1.Stop();
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
