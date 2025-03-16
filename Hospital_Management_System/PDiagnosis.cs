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
    public partial class PDiagnosis: Form
    {
        public string PName, Pass;
        SqlConnection Con = new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        public PDiagnosis()
        {
            InitializeComponent();
            populate();
        }
        public void populate()
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Diagnosis where patient_name='"+PName+"' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            Con.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PHome h = new PHome();
            h.PName = this.PName;
            h.Pass = this.Pass;
            h.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PDoctor k = new PDoctor();
            k.PName = this.PName;
            k.Pass = this.Pass;
            k.Show();
            this.Hide();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PPatient l = new PPatient();
            l.PName = this.PName;
            l.Pass = this.Pass;
            l.Show();
            this.Hide();

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            PBook s = new PBook();
            s.PName = this.PName;
            s.Pass = this.Pass;
            s.Show();
            this.Hide();

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            PBill a = new PBill();
            a.PName = this.PName;
            a.Pass = this.Pass;
            a.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login b = new Login();
            b.Show();
            this.Hide();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PDiagnosis_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
