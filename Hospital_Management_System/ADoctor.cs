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
    public partial class ADoctor: Form
    {
        SqlConnection Con=new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        public ADoctor()
        {
            InitializeComponent();
            populate();

        }
       public void populate()
        {
            Con.Open();
            string query = "select * from Doctor";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gunaDataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login u = new Login();
            u.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AHome k = new AHome();
            k.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            APatient q = new APatient();
            q.Show();
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ABill f = new ABill();
            f.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("No Empty Fill Accepted");
                }
                else
                {
                    Con.Open();
                    string id = textBox1.Text;
                    string name = textBox2.Text;
                    string exp = textBox5.Text;
                    string deg = textBox3.Text;
                    string spec = textBox4.Text;
                    string query = "insert into Doctor values('" + id + "','" + name + "','" + exp + "','" + deg + "','" + spec + "')";
                    SqlCommand Cmd = new SqlCommand(query, Con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor's Data Added Successfully");
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
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                populate();
            }
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox5.Text = gunaDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = gunaDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = gunaDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this doctor?",
                                                       "Confirm Deletion",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Warning);
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Select The Doctor to Delete");
                }
                else
                {
                    Con.Open();
                    
                    string id = textBox1.Text;
                    string query = "delete from Doctor where Doctor_id='" + id + "'";
                    SqlCommand Cmd = new SqlCommand(query, Con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor's Data Deleted Successfully");
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
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                populate();
            }   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("No Empty Fill Accepted");
                }
                else
                {
                    Con.Open();
                    string id = textBox1.Text;
                    string name = textBox2.Text;
                    string exp = textBox5.Text;
                    string deg = textBox3.Text;
                    string spec = textBox4.Text;
                    string query = "update Doctor set Doctor_name='" + name + "',Experience='" + exp + "',Degree='" + deg + "',Speciality='" + spec + "' where Doctor_id='" + id + "'";
                    SqlCommand Cmd = new SqlCommand(query, Con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor's Data Updated Successfully");
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
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                populate();
            }
        }

        private void ADoctor_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ( textBox6.Text == "")
            {
                MessageBox.Show("No Empty Fill Accepted");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = Con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Doctor where Speciality='" + textBox6.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                gunaDataGridView1.DataSource = dt;
                Con.Close();
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
