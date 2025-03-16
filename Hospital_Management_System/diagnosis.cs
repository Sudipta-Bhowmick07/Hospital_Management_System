using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class diagnosis: Form
    {
        private string Date;    
        public diagnosis()
        {
            InitializeComponent();
            Date = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void Print(Panel pn1)
        {
            PrinterSettings ps = new PrinterSettings();
            panel1 = pn1;
            getprintarea(panel1);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();

        }
        private Bitmap memoryImage;
        private void getprintarea(Panel pnl)
        {
            memoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ADiagnosis s = new ADiagnosis();
            s.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int diagnosisId))
            {
                DataTable dt = DatabaseHelper.GetDiagnosisById(diagnosisId);

                if (dt.Rows.Count > 0)
                {
                    textBox7.Text = dt.Rows[0]["Patient_Name"].ToString();
                    textBox9.Text = dt.Rows[0]["Date"].ToString();//Convert.ToDateTime(dt.Rows[0]["ReportOn"]).ToString("yyyy-MM-dd");
                    textBox8.Text = dt.Rows[0]["Gender"].ToString();
                    textBox5.Text = dt.Rows[0]["Blood_Group"].ToString();
                    textBox4.Text = dt.Rows[0]["Symptoms"].ToString();
                    textBox2.Text = dt.Rows[0]["Diagnosis"].ToString();
                    textBox1.Text = dt.Rows[0]["Diagnosis_id"].ToString();
                }
                else
                {
                    MessageBox.Show("Diagnosis record not found!");
                    
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Diagnosis ID!");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }

        private void diagnosis_Load(object sender, EventArgs e)
        {
            label15.Text = Date;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Print(this.panel2);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
