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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital_Management_System
{
    public partial class bill: Form
    {
        private string Date;
        public bill()
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
        private void button1_Click(object sender, EventArgs e)
        {
            ABill w = new ABill();
            w.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int billId))
            {
                DataTable dt = DatabaseHelper.GetBillById(billId);

                if (dt.Rows.Count > 0)
                {
                    textBox7.Text = dt.Rows[0]["Patient_Name"].ToString();
                    textBox5.Text = dt.Rows[0]["Treatment"].ToString();
                    textBox4.Text = dt.Rows[0]["Charge"].ToString();
                    textBox2.Text = dt.Rows[0]["status"].ToString();
                    textBox1.Text = dt.Rows[0]["bill_id"].ToString();
                }
                else
                {
                    MessageBox.Show("Bill record not found!");

                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Bill ID!");
            }
        }

        private void bill_Load(object sender, EventArgs e)
        {
            label12.Text = Date;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Print(this.panel2);
        }
    }
}
