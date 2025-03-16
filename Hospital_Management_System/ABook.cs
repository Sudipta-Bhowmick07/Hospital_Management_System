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
    public partial class ABook: Form
    {
        SqlConnection Con = new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        public ABook()
        {
            InitializeComponent();
            populate();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from ODoctor";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gunaDataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void ABook_Load(object sender, EventArgs e)
        {
            populate();
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login k = new Login();
            k.Show();
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ADiagnosis h = new ADiagnosis();
            h.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            book g = new book();
            g.Show();
            this.Hide();
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
                    MessageBox.Show("Select The Patient to Delete");
                }
                else
                {
                    Con.Open();
                   
                    string name = textBox1.Text;
                    string query = "delete from ODoctor where Doctor_name='" + name + "'";
                    SqlCommand Cmd = new SqlCommand(query, Con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Outdoor Doctor's Data Deleted Successfully");
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
                populate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" )
                {
                    MessageBox.Show("No Empty Fill Accepted");
                }
                else
                {
                    Con.Open();
                   
                    string name = textBox1.Text;
                    string spec = textBox2.Text;
                    string dat = textBox3.Text;
                    string ti = textBox4.Text;
                    string query = "insert into ODoctor values('" + name + "','" + spec + "','" + dat + "','"+ti+"')";
                    SqlCommand Cmd = new SqlCommand(query, Con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show(" Outdoor Doctor's Data Added Successfully");
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
                
                populate();
            }
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = gunaDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = gunaDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" )
                {
                    MessageBox.Show("No Empty Fill Accepted");
                }
                else
                {
                    Con.Open();
                    string name = textBox1.Text;
                    string spec = textBox2.Text;
                    string dat = textBox3.Text;
                    string ti = textBox4.Text;
                    

                    string query = "update ODoctor set Speciality='" + spec + "'" +
                        ",Date='" + dat+ "',Visit_Time='" + ti + "' where Doctor_name='" + name + "'";
                    SqlCommand Cmd = new SqlCommand(query, Con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Outdoor Doctor's Data Updated Successfully");
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
                populate();
            }
        }
    }
}
