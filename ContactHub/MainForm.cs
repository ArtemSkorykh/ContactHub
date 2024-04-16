using System.Windows.Forms;
namespace ContactHub
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ContactForm form = new ContactForm();
            form.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 form = new Form3();
            form.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<string> ls = new List<string>();

            ls = Contact.UploadShortContacts();

            foreach (var item in ls)
            {
                listBox1.Items.Add(item.ToString());
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = listBox1.SelectedItem.ToString();
            ContactForm contactForm = new ContactForm(str);
            contactForm.Visible = true;
            this.Visible = false;
        }
    }
}
