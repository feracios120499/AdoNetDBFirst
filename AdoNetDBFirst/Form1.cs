using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDBFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using(var db=new LibraryDZ2Entities())
            {
                listBox2.Items.AddRange(db.Authors.ToArray());
            }
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            if (tbFind.Text.Length > 0)
            {
                btFind.Enabled = true;
            }
            else
            {
                btFind.Enabled = false;
            }
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var db=new LibraryDZ2Entities())
            {

                foreach(var books in db.Authors.Where(p => p.Name.Contains(tbFind.Text)).ToList().Select(p=>p.Books))
                {
                    listBox1.Items.AddRange(books.ToArray());
                }
            }
        }
    }
}
