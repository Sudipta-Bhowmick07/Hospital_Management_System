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
    public partial class PDoctor: Form
    {
        public string PName, Pass;
        SqlConnection con = new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        public PDoctor()
        {
            InitializeComponent();
            display_data();
        }
        public void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Doctor";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            con.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login s = new Login();
            s.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PHome l = new PHome();
            l.PName = this.PName;
            l.Pass = this.Pass;
            l.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PPatient w = new PPatient();
            w.PName = this.PName;
            w.Pass = this.Pass;
            w.Show();
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
            PBill f = new PBill();
            f.PName = this.PName;
            f.Pass = this.Pass;
            f.Show();
            this.Hide();
        }

        private void PDoctor_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Doctor where Speciality='" + textBox6.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            con.Close();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
