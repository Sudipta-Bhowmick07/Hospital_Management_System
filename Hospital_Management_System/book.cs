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
    public partial class book: Form
    {
        SqlConnection Con = new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        public book()
        {
            InitializeComponent();
            populate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
        private void book_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ABook r = new ABook();
            r.Show();
            this.Hide();
        }
    }
}
