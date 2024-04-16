namespace ContactHub
{
    public partial class ContactForm : Form
    {
        public static Contact ContactForChange;
        public void SetForm(string contact)
        {
            List<Contact> lc = new List<Contact>();

            lc = Contact.UploadContacts();

            string[] ls = contact.Split(' ');

            Contact contact1 = new Contact();

            foreach(var item in lc)
            {
                if(item.Email == ls[1])
                {
                    contact1 = item;
                }
            }

            textBox1.Text = contact1.FirstName; 
            textBox2.Text = contact1.LastName; 
            textBox3.Text = contact1.PhoneNumber;
            textBox4.Text = contact1.Email;
            if(contact1.Desription != "")
                textBox5.Text = contact1.Desription;
            button1.Visible = false;
            ContactForChange = contact1;
        }
        public ContactForm()
        {
            InitializeComponent();
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }

        public ContactForm(string contact)
        {
            InitializeComponent();
            SetForm(contact);
        }

        private void ContactForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm f = new MainForm();
            f.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(   !string.IsNullOrWhiteSpace(textBox1.Text) 
              && !string.IsNullOrWhiteSpace(textBox2.Text) 
              && !string.IsNullOrWhiteSpace(textBox3.Text) 
              && !string.IsNullOrWhiteSpace(textBox4.Text))
           {
                Contact contact = new Contact();

                contact.FirstName = textBox1.Text;
                contact.LastName = textBox2.Text;
                contact.PhoneNumber = textBox3.Text;
                contact.Email = textBox4.Text;
                if(!string.IsNullOrWhiteSpace(textBox5.Text))
                    contact.Desription = textBox5.Text;
                
                List<Contact> ls = new List<Contact>();
                ls = Contact.UploadContacts();
                bool t = true;
                foreach(var item in ls)
                {
                    if(contact.Email == item.Email)
                    {
                        t = false;
                    }
                }
                if(t)
                {
                    ls.Add(contact);
                    Contact.SaveContacts(ls);

                    MessageBox.Show("Contact was added succsesfuly");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                else
                {
                    MessageBox.Show("Contact already exists");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text)
              && !string.IsNullOrWhiteSpace(textBox2.Text)
              && !string.IsNullOrWhiteSpace(textBox3.Text)
              && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                Contact contact = new Contact();

                contact.FirstName = textBox1.Text;
                contact.LastName = textBox2.Text;
                contact.PhoneNumber = textBox3.Text;
                contact.Email = textBox4.Text;
                if (!string.IsNullOrWhiteSpace(textBox5.Text))
                    contact.Desription = textBox5.Text;

                List<Contact> ls = new List<Contact>();
                ls = Contact.UploadContacts();

                bool t = false;
                foreach (var item in ls)
                {
                    if (contact.Email == item.Email)
                    {
                        t = true;

                    }
                }
                if (t)
                {
                    List<Contact> LC = new List<Contact>();
                    foreach (var item in ls)
                    {
                        if (contact.Email != item.Email)
                        {
                            LC.Add(item);

                        }
                    }
                    
                    Contact.SaveContacts(LC);

                    MessageBox.Show("Contact was deleted succsesfuly");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                else
                {
                    MessageBox.Show("Contact wasn't found");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text)
              && !string.IsNullOrWhiteSpace(textBox2.Text)
              && !string.IsNullOrWhiteSpace(textBox3.Text)
              && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                Contact contact = new Contact();

                contact.FirstName = textBox1.Text;
                contact.LastName = textBox2.Text;
                contact.PhoneNumber = textBox3.Text;
                contact.Email = textBox4.Text;
                if (!string.IsNullOrWhiteSpace(textBox5.Text))
                    contact.Desription = textBox5.Text;

                List<Contact> ls = new List<Contact>();
                ls = Contact.UploadContacts();

                bool t = false;
                foreach (var item in ls)
                {
                    if (item.Email == ContactForChange.Email)
                    {
                        t = true;

                    }
                }
                List<Contact> LC = new List<Contact>();
                if (t)
                {
                    foreach (var item in ls)
                    {
                        if (item.Email != ContactForChange.Email)
                        {
                            LC.Add(item);
                        }
                    }

                    LC.Add(contact);

                    Contact.SaveContacts(LC);

                    MessageBox.Show("Contact was saved succsesfuly");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(textBox4.Text);
            form3.Visible = true;
            this.Visible = false;
        }
    }
}
