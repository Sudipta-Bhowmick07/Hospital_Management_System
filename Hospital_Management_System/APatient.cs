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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital_Management_System
{
    public partial class APatient: Form
    {
        SqlConnection Con = new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        public APatient()
        {
            InitializeComponent();
            populate();
        }
        public void populate()
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Patient ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            Con.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AHome r = new AHome();
            r.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ADoctor q = new ADoctor();
            q.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AInventory s = new AInventory();
            s.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ADashboard w = new ADashboard();
            w.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ADiagnosis h = new ADiagnosis();
            h.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ABook ko = new ABook();
            ko.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ABill f = new ABill();
            f.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            DateTime date = dateTimePicker1.Value;
            int years = DateTime.Now.Year - date.Year;
            textBox5.Text = years.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox7.Text == "" || textBox4.Text == "" || textBox5.Text == ""||textBox6.Text=="")
                {
                    MessageBox.Show("Please Enter All the Details");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Patient(Patient_name,Password,DOB,Age,Gender,Blood_Group,Ph_no,Address,Disease,status) values('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value + "','" + textBox5.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Account is Successfully Created");
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

        private void APatient_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label21.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = gunaDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = gunaDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = gunaDataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            textBox4.Text = gunaDataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox7.Text = gunaDataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            textBox8.Text = gunaDataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            comboBox1.Text= gunaDataGridView1.SelectedRows[0].Cells[5].Value.ToString(); 
            comboBox2.Text = gunaDataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            dateTimePicker1.Text = gunaDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this doctor?",
                                                       "Confirm Deletion",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Warning);
            try
            {
                
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Select The Patient to Delete");
                }
                else
                {
                    Con.Open();
                    
                    int id = Convert.ToInt32(label21.Text);
                    string query = "delete from Patient where Patient_id='" + id+ "'";
                    SqlCommand Cmd = new SqlCommand(query, Con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient's Data Deleted Successfully");
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox7.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("No Empty Fill Accepted");
                }
                else
                {
                    Con.Open();
                    int id = Convert.ToInt32(label21.Text);
                    string name = textBox1.Text;
                    string pass = textBox2.Text;
                    string DOB = dateTimePicker1.Value.ToString();
                    string age = textBox5.Text;
                    string gen = comboBox1.SelectedItem.ToString();
                    string Bg = comboBox2.SelectedItem.ToString();
                    string ph = textBox4.Text;
                    string add = textBox6.Text;
                    string dis = textBox7.Text;
                    string stat = textBox8.Text;
                    
                    string query = "update Patient set Patient_name='" + name + "',Password='" + pass + "'" +
                        ",DOB='" + DOB + "',Age='" + age + "',gender='" + gen + "',Blood_group='" + Bg + "'" +
                        ",Ph_no='" + ph + "',address='" + add+ "',disease='" + dis + "',status='" + stat + "' where Patient_id='"+id+"'";
                    SqlCommand Cmd = new SqlCommand(query, Con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient's Data Updated Successfully");
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
    }
}
