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
    public partial class Login: Form
    {
        SqlConnection con = new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Verify ji = new Verify();
            this.Hide();
            ji.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Admin rp = new Admin();
            rp.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Admin rp = new Admin();
            rp.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                
                
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Please Enter All the Details");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from Patient where Patient_name='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        PHome ph = new PHome();
                        ph.PName = this.textBox1.Text;
                        ph.Pass = this.textBox2.Text;
                        ph.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password");
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
