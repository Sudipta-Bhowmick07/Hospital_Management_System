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
    public partial class Signin : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        public Signin()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Login et = new Login();
            this.Hide();
            et.Show();
        }

        private void Signin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text==""||textBox2.Text==""||textBox3.Text==""||textBox4.Text==""||textBox5.Text=="")
                {
                    MessageBox.Show("Please Enter All the Details");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Patient(Patient_name,Password,DOB,Age,Gender,Blood_Group,Ph_no,Address) values('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value + "','" + textBox3.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + textBox4.Text + "','" + textBox5.Text + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Account is Successfully Created");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            DateTime dob = dateTimePicker1.Value;
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;
            textBox3.Text = age.ToString();
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
