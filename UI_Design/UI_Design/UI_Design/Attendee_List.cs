using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Design
{
    public partial class Attendee_List : Form
    {
        public Attendee_List()
        {
            InitializeComponent();
        }

        private void Attendee_List_Load(object sender, EventArgs e)
        {
            listView1.LargeImageList = imageList1;

            ListViewItem lv = new ListViewItem(new string[] { "Dan Stabler","Accept","123 Birch Ln.",""});
            lv.ImageIndex = 2;
            lv.Group = listView1.Groups[2];

            ListViewItem lv2 = new ListViewItem(new string[] { "Mark Harriett","Decline","456 Mickey Ln.",""});
            lv2.ImageIndex = 0;
            lv2.Group = listView1.Groups[0];

            ListViewItem lv3 = new ListViewItem(new string[] { "Diane Mayes", "Accept", "789 Ash Ln.", "" });
            lv3.ImageIndex = 1;
            lv3.Group = listView1.Groups[1];

            ListViewItem lv4 = new ListViewItem(new string[] { "Nema Abachizadeh", "Decline", "1011 Elm Ln.", "" });
            lv4.ImageIndex = 0;
            lv4.Group = listView1.Groups[0];

            ListViewItem lv5 = new ListViewItem(new string[] { "Jonathan Sobota", "Accept", "1213 Oak Ln.", "" });
            lv5.ImageIndex = 1;
            lv5.Group = listView1.Groups[1];

            listView1.Items.Add(lv);
            listView1.Items.Add(lv2);
            listView1.Items.Add(lv3);
            listView1.Items.Add(lv4);
            listView1.Items.Add(lv5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.View == View.Details)
            {
                listView1.View = View.Tile;
                listView1.ShowGroups = true;
            }
            else
            {
                listView1.View = View.Details;
                listView1.ShowGroups = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataEntryForm def = new DataEntryForm();
            def.ShowDialog();
        }
    }
}
