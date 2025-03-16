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
    public partial class Admin: Form
    {
        SqlConnection con = new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        SqlCommand cmd;
        SqlDataReader dr;
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login r = new Login();
            r.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from AdLog_in where id=@id and Password=@pass",con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                AHome n = new AHome();
                n.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("User not Verified");
            }
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
