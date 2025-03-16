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
    public partial class PBook: Form
    {
        SqlConnection Con= new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        public string PName, Pass;
        public PBook()
        {
            InitializeComponent();
            populate();
            populate1();
        }
        public void populate()
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from booking where Patient_name='"+PName+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            Con.Close();
        }
        public void populate1()
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from odoctor ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gunaDataGridView2.DataSource = dt;
            Con.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PHome m = new PHome();
            m.PName = this.PName;
            m.Pass = this.Pass;
            m.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PDoctor x = new PDoctor();
            x.PName = this.PName;
            x.Pass = this.Pass;
            x.Show();
            this.Hide();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PPatient z = new PPatient();
            z.PName = this.PName;
            z.Pass = this.Pass;
            z.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PDiagnosis j = new PDiagnosis();
            j.PName = this.PName;
            j.Pass = this.Pass;
            j.Show();
            this.Hide();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            PBill k = new PBill();
            k.PName = this.PName;
            k.Pass = this.Pass;
            k.Show();
            this.Hide();
        
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
            this.Hide();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" ||textBox4.Text == "" || textBox5.Text == ""||textBox6.Text=="")
                {
                    MessageBox.Show("Please Enter All the Details");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into booking(Patient_name,DOctor_name,Ph_no,Visit_time,Visiting_date,Booking_date) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','"+dateTimePicker1.Value+"')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Booking is Successfully Created");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                Con.Close();
                populate();
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = gunaDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox6.Text = gunaDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = gunaDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = gunaDataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            dateTimePicker1.Text = gunaDataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void gunaDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = gunaDataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            textBox6.Text = gunaDataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = gunaDataGridView2.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("No Empty Fill Accepted");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = Con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from odoctor where speciality='" + textBox3.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                gunaDataGridView2.DataSource = dt;
                Con.Close();
            }
        }

        private void PBook_Load(object sender, EventArgs e)
        {
            populate();
            populate1();
        }
    }
}
