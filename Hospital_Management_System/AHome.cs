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
    public partial class AHome: Form
    {
        public AHome()
        {
            InitializeComponent();
        }

        private void AHome_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ADoctor q = new ADoctor();
            q.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login t = new Login();
            t.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            APatient q = new APatient();
            q.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ABook l = new ABook();
            l.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ADiagnosis h = new ADiagnosis();
            h.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ABill er = new ABill();
            er.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AInventory o = new AInventory();
            o.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ADashboard d = new ADashboard();
            d.Show();
            this.Hide();

        }
        
        
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                pictureBox10.Image = Properties.Resources.home3; // Replace with your image
            }
            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                pictureBox10.Image = Properties.Resources.home4; // Replace with your image
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
             if (radioButton2.Checked)
            {
                pictureBox10.Image = Properties.Resources.home2; // Replace with your image
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                pictureBox10.Image = Properties.Resources.home1; // Replace with your image
            }
            
        }
    }
}
