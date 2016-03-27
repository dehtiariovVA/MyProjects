using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ContactManager_Core;

namespace ContactManager_UI
{
    public partial class Form1 : Form
    {
        List<Contact> listOfContacts;
        List<PictureBox> listOfpictures = new List<PictureBox>();
        XDocument doc;
        public Form1()
        {
            listOfContacts = new List<Contact>();
            InitializeComponent();
            doc = XDocument.Load("ContactsStore.xml");
        }

        private void btn_AddContact_Click(object sender, EventArgs e)
        {
            string path;
            if (tb_forPhoto.Text == "")
            {
                path = "no_photo.jpg";
            }
            else
            {
                path = @tb_forPhoto.Text;
            }
            if (tbForFName.Text != "")
            {
                Contact contact = new Contact(tbForFName.Text, tbForLName.Text,
                                                tbForGroup.Text, tbForHomeNumber.Text,
                                                tbForMobileNumber.Text, path);
                listOfContacts.Add(contact);
                treeView1.Nodes.Add(contact.ToString());
                PictureBox p = new PictureBox();
                p.Location = new Point(295, 286);
                p.Size = new Size(141, 116);
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                p.Image = new Bitmap(path);
                this.Controls.Add(p);
                listOfpictures.Add(p);

                ClearFilds();
            }
            else
            {
                MessageBox.Show("Field first name can't be empty");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LinqToXmlModel.ContactsFromXmlToList(doc, listOfContacts);
            int i = 0;
            foreach (Contact c in listOfContacts)
            {
                treeView1.Nodes.Add(c.ToString());
                PictureBox p = new PictureBox();
                p.Location = new Point(295, 286);
                p.Size = new Size(141, 116);
                p.Load(c.Photo);
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(p);
                listOfpictures.Add(p);
                i++;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LinqToXmlModel.ContactsFromListToXml(listOfContacts, doc);
        }

        private void btn_RemoveContact_Click(object sender, EventArgs e)
        {
            listOfContacts.RemoveAt(treeView1.SelectedNode.Index);
            treeView1.Nodes.RemoveAt(treeView1.SelectedNode.Index);

            ClearFilds();
        }

        private void btn_SaveChanges_Click(object sender, EventArgs e)
        {
            if (tbForFName.Text != "")
            {
                Contact contact = listOfContacts[treeView1.SelectedNode.Index];
                contact.FirstName = tbForFName.Text;
                contact.LastName = tbForLName.Text;
                contact.Group = tbForGroup.Text;
                contact.HomeNumber = tbForHomeNumber.Text;
                contact.MobileNumber = tbForMobileNumber.Text;
                treeView1.Nodes[treeView1.SelectedNode.Index].Text = contact.ToString();

                if (tb_forPhoto.Text != "")
                {
                    contact.Photo = @tb_forPhoto.Text;
                    treeView1.SelectedNode.Text = contact.ToString();
                    PictureBox p = listOfpictures[treeView1.SelectedNode.Index];
                    p.Load(@tb_forPhoto.Text);
                }
            }
            else
            {
                MessageBox.Show("Field first name can't be empty");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ClearFilds();
            tb_forFiltering.Enabled = false;
            btn_AddContact.Enabled = false;
            btn_RemoveContact.Enabled = false;
            btn_SaveChanges.Enabled = false;
            treeView1.AfterSelect -=
                new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            treeView1.Nodes.Clear();
            if (cb_GroupOrNot.Checked == true)
            {
                var quary = listOfContacts.GroupBy(contact => contact.Group);
                int i = 0;
                foreach (var grouping in quary)
                {
                    treeView1.Nodes.Add(new TreeNode(grouping.Key));
                    foreach (var contact in grouping)
                    {
                        treeView1.Nodes[i].Nodes.Add(new TreeNode(contact.ToString()));
                    }
                    i++;
                }
            }
            else
            {
                tb_forFiltering.Enabled = true;
                btn_AddContact.Enabled = true;
                btn_RemoveContact.Enabled = true;
                btn_SaveChanges.Enabled = true;
                treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
                foreach (Contact contact in listOfContacts)
                {
                    treeView1.Nodes.Add(contact.ToString());
                }
            }
        }

        private void tb_forFiltering_TextChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            var quary = from contact in listOfContacts
                        where (contact.ToString().ToLower().Contains(tb_forFiltering.Text.ToLower()))
                        select contact;
            foreach (var contact in quary)
            {
                treeView1.Nodes.Add(contact.ToString());
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Contact contact = listOfContacts[treeView1.SelectedNode.Index];
            tbForFName.Text = contact.FirstName;
            tbForLName.Text = contact.LastName;
            tbForGroup.Text = contact.Group;
            tbForHomeNumber.Text = contact.HomeNumber;
            tbForMobileNumber.Text = contact.MobileNumber;
            if (contact.Photo != "")
            {
                PictureBox p = listOfpictures[treeView1.SelectedNode.Index];
                p.BringToFront();
            }
        }
        private void ClearFilds()
        {
            this.Invoke((Action)delegate
            {
                tbForFName.Text = "";
                tbForLName.Text = "";
                tbForGroup.Text = "";
                tbForHomeNumber.Text = "";
                tbForMobileNumber.Text = "";
            });
        }

        private void tbForHomeNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar)) & (!Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void tbForMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar)) & (!Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
