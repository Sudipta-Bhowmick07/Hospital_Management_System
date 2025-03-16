using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class PBill: Form
    {
        public string PName, Pass;
        SqlConnection Con = new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        public PBill()
        {
            InitializeComponent();
        }
        public void populate()
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from bill where patient_name='" + PName + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            Con.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PHome l = new PHome();
            l.PName = this.PName;
            l.Pass = this.Pass;
            l.Show();
            this.Hide();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PDoctor h = new PDoctor();
            h.PName = this.PName;
            h.Pass = this.Pass;
            h.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PPatient s = new PPatient();
            s.PName = this.PName;
            s.Pass = this.Pass;
            s.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            PBook a = new PBook();
            a.PName = this.PName;
            a.Pass = this.Pass;
            a.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PBook d = new PBook();
            d.PName = this.PName;
            d.Pass = this.Pass;
            d.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login k = new Login();
            k.Show();
            this.Hide();
        }

        private void PBill_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
