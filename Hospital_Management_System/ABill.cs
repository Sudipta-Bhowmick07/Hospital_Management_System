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
    public partial class ABill: Form
    {
        SqlConnection Con = new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        public ABill()
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
            cmd.CommandText = "select * from Treatment ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gunaDataGridView2.DataSource = dt;
            Con.Close();
        }
        public void populate1()
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Bill ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
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
            ADoctor we = new ADoctor();
            we.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            APatient lo = new APatient();
            lo.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ABook ko = new ABook();
            ko.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ADiagnosis h = new ADiagnosis();
            h.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login g = new Login();
            g.Show();
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            bill r = new bill();
            r.Show();
            this.Hide();
        }

        private void ABill_Load(object sender, EventArgs e)
        {
            populate1();
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.SelectedIndex ==-1)
                {
                    MessageBox.Show("Please Enter All the Details");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Bill(Patient_name,ph_no,treatment,charge,status,bill_date) values('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + comboBox1.SelectedItem.ToString() + "','"+dateTimePicker1.Value+"')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Added Successfully");
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
                textBox4.Text = "";
                comboBox1.SelectedIndex = -1;
                textBox5.Text = "";
                populate1();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Select The Patient to Delete");
                }
                else
                {
                    Con.Open();
                    DialogResult confirm = MessageBox.Show("Are you sure you want to delete this doctor?",
                                                       "Confirm Deletion",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Warning);
                    int id = Convert.ToInt32(label17.Text);

                    string query = "delete from Bill where bill_id='" + id + "'";
                    SqlCommand Cmd = new SqlCommand(query, Con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Deleted Successfully");
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
                textBox4.Text = "";
                comboBox1.SelectedIndex = -1;
                textBox5.Text = "";
                populate1();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("No Empty Fill Accepted");
                }
                else
                {
                    Con.Open();
                    int id = Convert.ToInt32(label17.Text);
                    string name = textBox1.Text;
                    string treat = textBox2.Text;
                    string charg = textBox5.Text;
                    string stat = comboBox1.SelectedItem.ToString();
                    string ph = textBox4.Text;
                    

                    string query = "update bill set Patient_name='" + name + "',Treatment='" + treat + "'" +
                        ",Charge='" + charg + "',status='" + stat + "',ph_no='"+textBox4.Text+"',Bill_date='"+dateTimePicker1.Value+"'where bill_id='"+id+"' ";
                    SqlCommand Cmd = new SqlCommand(query, Con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Updated Successfully");
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
                textBox4.Text = "";
                comboBox1.SelectedIndex = -1;
                textBox5.Text = "";
                populate1();
            }
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label17.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = gunaDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = gunaDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = gunaDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = gunaDataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            dateTimePicker1.Text = gunaDataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        

        private void gunaDataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            textBox2.Text = gunaDataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            textBox5.Text = gunaDataGridView2.SelectedRows[0].Cells[1].Value.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("No Empty Fill Accepted");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = Con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Treatment where Treatment='" + textBox7.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                gunaDataGridView2.DataSource = dt;
                Con.Close();
            }
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
                cmd.CommandText = "select * from bill where Patient_name='" + textBox3.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                gunaDataGridView1.DataSource = dt;
                Con.Close();
            }
        }

        

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";

        }
    }
}
