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
using System.Windows.Forms.DataVisualization.Charting;

namespace Hospital_Management_System
{
    public partial class ADashboard: Form
    {
        SqlConnection Con = new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");
        public ADashboard()
        {
            InitializeComponent();
            CountDoctor();
            CountPatient();
            CountBook();
            CountReport();
            CountInventory();
            CountBill();
            LoadChartData();
        }
        private void CountDoctor()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Doctor", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            D1.Text = dt.Rows[0][0].ToString();

            Con.Close();
        }
        private void CountPatient()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Doctor", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            P1.Text = dt.Rows[0][0].ToString();

            Con.Close();
        }
        private void CountBook()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Booking", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            B1.Text = dt.Rows[0][0].ToString();

            Con.Close();
        }
        private void CountReport()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Diagnosis", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            R1.Text = dt.Rows[0][0].ToString();

            Con.Close();
        }
        private void CountInventory()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Inventory", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            I1.Text = dt.Rows[0][0].ToString();

            Con.Close();
        }
        
        private void CountBill()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(charge) from bill", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            T1.Text = dt.Rows[0][0].ToString();

            Con.Close();
        }
        private void LoadChartData()
        {

            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;  // Remove vertical grid lines
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;  // Remove horizontal grid lines

            chart1.ChartAreas[0].AxisX.LineWidth = 2;  // Make X-axis visible
            chart1.ChartAreas[0].AxisY.LineWidth = 2;  // Make Y-axis visible

            string connectionString = "Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;";
            string query = @"
                SELECT Bill_Date, SUM(charge) AS TotalAmount 
                FROM Bill 
                GROUP BY Bill_Date
                ORDER BY Bill_Date";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                chart1.Series.Clear();
                Series series = chart1.Series.Add("Bill Amount");
                series.ChartType = SeriesChartType.Column;
                chart1.Series[0].Color = System.Drawing.Color.FromArgb(117,84,174);
                //foreach (DataRow row in dt.Rows)
                //{
                //    series.IsValueShownAsLabel = true;
                //    series.Points.AddXY(Convert.ToDateTime(row["Bill_Date"]), row["TotalAmount"]); // Keep DateTime format
                //}

                foreach (DataRow row in dt.Rows)
                {
                    series.IsValueShownAsLabel = true;
                    series.Points.AddXY(Convert.ToDateTime(row["Bill_Date"]).ToString("dd-MM-yyyy"), row["TotalAmount"]);
                }
            }
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login q = new Login();
            q.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AInventory p = new AInventory();
            p.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ABill k = new ABill();
            k.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ADiagnosis v = new ADiagnosis();
            v.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ABook t = new ABook();
            t.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            APatient gh = new APatient();
            gh.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ADoctor tr = new ADoctor();
            tr.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AHome h = new AHome();
            h.Show();
            this.Hide();
        }

        private void ADashboard_Load(object sender, EventArgs e)
        {
            CountBill();
            CountBook();
            CountDoctor();
            CountInventory();
            CountPatient();
            CountReport();
            LoadChartData();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
