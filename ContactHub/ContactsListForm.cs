using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactHub
{
    public partial class ContactsListForm : Form
    {
        int i;
        public ContactsListForm()
        {
            InitializeComponent();
        }
        public ContactsListForm(int iny)
        {
            InitializeComponent();
            i = iny;
        }

        private void ContactsListForm_Load(object sender, EventArgs e)
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
            if(i == 0)
            {
                Form3.instance.tb1.Text = listBox1.SelectedItem.ToString().Split(' ')[1];
            }
            if(i == 1)
            {
                Form3.instance.tb2.Text = listBox1.SelectedItem.ToString().Split(' ')[1];
            }
            this.Visible = false;
        }
    }
}
