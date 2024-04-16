using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ContactHub
{
    public partial class Form3 : Form
    {
        public static Form3 instance;
        public System.Windows.Forms.TextBox tb1;
        public System.Windows.Forms.TextBox tb2;
        public Form3()
        {
            InitializeComponent();
            instance = this;
            tb1 = textBox1;
            tb2 = textBox2;
        }
        public Form3(string contact)
        {
            InitializeComponent();
            textBox2.Text = contact;
            instance = this;
            tb1 = textBox1;
            tb2 = textBox2;
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm f = new MainForm();
            f.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                listBox1.Items.Add(sFileName);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient mailServer = new SmtpClient(textBox5.Text, 587);
                mailServer.EnableSsl = true;

                mailServer.Credentials = new System.Net.NetworkCredential(textBox1.Text, "fmet mlpj dsji futr");

                string from = textBox1.Text;
                string to = textBox2.Text;
                MailMessage msg = new MailMessage(from, to);
                msg.Subject = textBox3.Text;
                msg.Body = textBox4.Text;
                foreach(var item in listBox1.Items)
                {
                    msg.Attachments.Add(new Attachment(item.ToString()));
                }
                
                mailServer.Send(msg);

                MessageBox.Show("Message was delivered successfully!");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                listBox1.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to send email. Error : " + ex);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ContactsListForm cf = new ContactsListForm(1);
            cf.Visible = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ContactsListForm cf = new ContactsListForm(0);
            cf.Visible = true;
        }
    }
}
