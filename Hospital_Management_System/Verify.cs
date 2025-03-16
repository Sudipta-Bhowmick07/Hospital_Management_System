using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class Verify: Form
    {
        String randomCode;
        public static String to;
        public Verify()
        {
            InitializeComponent();
        }

        private void Verify_Load(object sender, EventArgs e)
        {

        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            String from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (textBox1.Text).ToString();
            from = "sudiptabhowmick2004@gmail.com";
            pass = "jkrt rafk zkzb nrpq";
            messageBody = "Your OTP is " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Verification OTP";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Code Send Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (randomCode == (textBox2.Text).ToString())
            {
                to = textBox1.Text;
                Signin rp = new Signin();
                this.Hide();
                rp.Show();
            }
            else
            {
                MessageBox.Show("Wrong Code");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login jo = new Login();
            this.Hide();
            jo.Show();
        }
    }
}
