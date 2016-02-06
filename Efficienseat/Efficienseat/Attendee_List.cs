using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Efficienseat
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



        private void button1_Click(object sender, EventArgs e)
        {
            //button for add entry
            //Create edit entry window for data population
            //  Pull data form form rather than passing through
            using (DataEntryForm data = new DataEntryForm())
            {
                data.ShowDialog();

                //could use better check for cancel --maybe basic bool value in DataEntryForm?
                if (data.getFirstName != "")
                {
                    string name = data.getFirstName + " " + data.getLastName;
                    string RSVP = data.getRSVP;
                    string address = data.getAddress1 + " " + data.getAddress2 + " " + data.getCity + ", " + data.getState + " " + data.getZIP;
                    
                    ListViewItem newGuest = new ListViewItem(new string[] { name, RSVP, address, "" });
                    newGuest.ImageIndex = 0;
                    newGuest.Group = listView1.Groups[0];
                    listView1.Items.Add(newGuest);
                }
            }


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
            //should populate with selected user data
            //check for a user selection from listView prior to instantiating window
            if (listView1.SelectedItems.Count == 1)
            {
                //DataEntryForm will need a parameterized constructor to account for pushed data
                DataEntryForm def = new DataEntryForm();
                def.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //button for remove entry
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if(item.Name == "editEntryToolStripMenuItem")
            {
                //example, should redirect to button3_Click
                button3_Click(new object(), new EventArgs());
            }
            else if(item.Name == "changeViewToolStripMenuItem")
            {
                //change view code  -- button2_Click
                button2_Click(new object(), new EventArgs());
            }
            else if (item.Name == "removeAttendeeToolStripMenuItem")
            {
                //remove attendee code  -- button4_Click
                button4_Click(new object(), new EventArgs());
            }
            else
            {
                //add attendee code  --button1_Click
                button1_Click(new object(), new EventArgs());
            }
        }

    }
}
