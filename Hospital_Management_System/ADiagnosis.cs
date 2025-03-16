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
    public partial class ADiagnosis: Form
    {
        SqlConnection Con = new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        public ADiagnosis()
        {
            InitializeComponent();
            populate();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from Diagnosis";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gunaDataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AHome q = new AHome();
            q.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ADoctor w = new ADoctor();
            w.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            APatient r = new APatient();
            r.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ABook l = new ABook();
            l.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login j = new Login();
            j.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ABill f = new ABill();
            f.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ADashboard w = new ADashboard();
            w.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AInventory s = new AInventory();
            s.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            diagnosis k = new diagnosis();
            k.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox5.Text == ""||comboBox1.SelectedIndex==-1||comboBox2.SelectedIndex==-1)
                {
                    MessageBox.Show("No Empty Fill Accepted");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Diagnosis (Patient_name,Date,Age,Gender,Symptoms,Blood_Group,Address,Diagnosis) values('" + textBox1.Text + "','"+dateTimePicker1.Value+"','" + textBox5.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox2.Text + "','" + comboBox2.SelectedItem.ToString() + "','" + textBox6.Text + "','" + textBox7.Text + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Report is Successfully Created");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                Con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Now;
                populate();
            }
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label18.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = gunaDataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            textBox5.Text = gunaDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox6.Text = gunaDataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox7.Text = gunaDataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            comboBox1.Text = gunaDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox2.Text = gunaDataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            dateTimePicker1.Text = gunaDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void ADiagnosis_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this Report?",
                                                       "Confirm Deletion",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Warning);
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Select The Report to Delete");
                }
                else
                {
                    Con.Open();

                    int id = Convert.ToInt32(label18.Text);
                    string query = "delete from Diagnosis where Patient_name='" + id + "'";
                    SqlCommand Cmd = new SqlCommand(query, Con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Selected Report Deleted Successfully");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                Con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Now;
                populate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox5.Text == "" || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("No Empty Fill Accepted");
                }
                else
                {
                    Con.Open();
                    int id = Convert.ToInt32(label18.Text);
                    string name = textBox1.Text;
                    string sym = textBox2.Text;
                    string Dat = dateTimePicker1.Value.ToString();
                    string age = textBox5.Text;
                    string gen = comboBox1.SelectedItem.ToString();
                    string Bg = comboBox2.SelectedItem.ToString();
                    string add = textBox6.Text;
                    string dia = textBox7.Text;

                    string query = "update Diagnosis set Date='" + Dat + "',Age='" + age + "',gender='" + gen + "',Patient_name='" + name + "',Blood_group='" + Bg + "'" +
                        ",Symptoms='" + sym + "',address='" + add + "',diagnosis='" + dia + "' where diagnosis_id='"+id+"'";
                    SqlCommand Cmd = new SqlCommand(query, Con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Report's Data Updated Successfully");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                Con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Now;
                populate();
            }
        }
    }
}
