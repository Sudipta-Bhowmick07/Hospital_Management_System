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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital_Management_System
{
    public partial class PPatient: Form
    {
        public string PName, Pass;

        SqlConnection Con = new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        public PPatient()
        {
            InitializeComponent();
            populate();
        }
        public void populate()
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Patient where Patient_name='"+PName+"' and Password='"+Pass+"' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            Con.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PHome k = new PHome();
            k.PName = this.PName;
            k.Pass = this.Pass;
            k.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PDoctor l = new PDoctor();
            l.PName = this.PName;
            l.Pass = this.Pass;
            l.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            PBook h = new PBook();
            h.PName = this.PName;
            h.Pass = this.Pass;
            h.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PDiagnosis g = new PDiagnosis();
            g.PName = this.PName;
            g.Pass = this.Pass;
            g.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            PBill d = new PBill();
            d.PName = this.PName;
            d.Pass = this.Pass;
            d.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login b = new Login();
            b.Show();
            this.Hide();
        }

        private void PPatient_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
