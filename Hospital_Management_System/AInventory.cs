using Guna.UI.WinForms;
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
    public partial class AInventory: Form
    {
        SqlConnection Con = new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        public AInventory()
        {
            InitializeComponent();
            populate();
        }
        public void populate()
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Inventory ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            Con.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AHome k = new AHome();
            k.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ADoctor l = new ADoctor();
            l.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            APatient s = new APatient();
            s.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ABook m = new ABook();
            m.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ADiagnosis z = new ADiagnosis();
            z.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ABill g = new ABill();
            g.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
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
                if (textBox1.Text == "" || textBox2.Text == "" )
                {
                    MessageBox.Show("Please Enter All the Details");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Inventory(Product_name,Quantity) values('" + textBox2.Text + "','" + textBox1.Text + "')", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Record is Successfully Added");
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
                populate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this Item?",
                                                       "Confirm Deletion",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Warning);
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Select the Inventory Item to Delete");
                }
                else
                {
                    Con.Open();
                    
                    int id = Convert.ToInt32(label11.Text);

                    string query = "delete from Inventory where Product_id='" + id + "'";
                    SqlCommand Cmd = new SqlCommand(query, Con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Deleted Successfully");
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
                if (textBox1.Text == "" || textBox2.Text == "" )
                {
                    MessageBox.Show("No Empty Fill Accepted");
                }
                else
                {
                    Con.Open();
                    string quan = textBox1.Text;
                    string name = textBox2.Text;
                    int id = Convert.ToInt32(label11.Text);

                    string query = "update Inventory set Product_name='" + name + "',quantity='" + quan + "' where Product_id='" + id + "'";
                    SqlCommand Cmd = new SqlCommand(query, Con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Item's Data Updated Successfully");
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

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label11.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = gunaDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
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
                cmd.CommandText = "select * from Inventory where Product_name='" + textBox3.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                gunaDataGridView1.DataSource = dt;
                Con.Close();
            }
        }
    }
}
