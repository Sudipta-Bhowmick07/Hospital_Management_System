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
    public partial class PHome: Form
    {
        public string PName, Pass;
        public PHome()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PDoctor d = new PDoctor();
            d.PName = this.PName;
            d.Pass = this.Pass;
            d.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PPatient p = new PPatient();
            p.PName = this.PName;
            p.Pass = this.Pass;
            p.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            PBook k = new PBook();
            k.PName = this.PName;
            k.Pass = this.Pass;
            k.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PDiagnosis a = new PDiagnosis();
            a.PName = this.PName;
            a.Pass = this.Pass;
            a.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            PBill n = new PBill();
            n.PName = this.PName;
            n.Pass = this.Pass;
            n.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login h = new Login();
            h.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                pictureBox10.Image = Properties.Resources.home1; // Replace with your image
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                pictureBox10.Image = Properties.Resources.home2; // Replace with your image
            }
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

        private void PHome_Load(object sender, EventArgs e)
        {
            
        }
    }
}
