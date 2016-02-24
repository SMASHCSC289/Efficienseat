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
    public partial class TableAssignments : Form
    {
        Graphics Table;
        private int shapeType = -1;
        int rectSide, rectSide2;
        Image image = new Bitmap(Efficienseat.Properties.Resources.Tablecloth);
        public DataTable AttendeeDT;

        Mysource dragSource = new Mysource();

        List<CustomPanel> panels = new List<CustomPanel>();
        List<ListView> listviews;

        ListViewItem empty = new ListViewItem("Empty");        

        public TableAssignments()
        {
            InitializeComponent();

            

            rectSide = panel1.Width - (panel1.Width / 2);
            rectSide2 = rectSide;

            empty.ImageIndex = 2;

            listviews = new List<ListView>() { lvwSeat1, lvwSeat2, lvwSeat3, lvwSeat4, lvwSeat5, lvwSeat6, lvwSeat7, lvwSeat8, lvwSeat9, lvwSeat10 };
            foreach (ListView view in listviews)
            {
                //view.Enabled = false;
                view.Visible = false;
            }
        }

        private void TableAssignments_Load(object sender, EventArgs e)
        {
            foreach (ListView l in listviews)
            {
                ListViewItem emp = empty.Clone() as ListViewItem;
                l.Items.Add(emp);
            }

            //ListViewItem lvTest = new ListViewItem(new string[] { "Dan Stabler", "Accept", "123 Birch Ln.", "", "12" });
            //lvTest.ToolTipText = "I don't have a comment. :(";
            //lvTest.ImageIndex = 0;
            //lvwUnseated.Items.Add(lvTest);

            //ListViewItem lvTest2 = new ListViewItem(new string[] { "Mark Harriett", "Accept", "123 Birch Ln.", "I have a comment! :)", "34" });
            //lvTest2.ToolTipText = "I have a comment! :)";
            //lvTest2.ImageIndex = 1;
            //lvwUnseated.Items.Add(lvTest2);

            //ListViewItem lvTest3 = new ListViewItem(new string[] { "Diane Mayes", "Accept", "123 Birch Ln.", "", "56" });
            //lvTest3.ToolTipText = "I don't have a comment. :(";
            //lvTest3.ImageIndex = 0;
            //lvwUnseated.Items.Add(lvTest3);

            //ListViewItem lvTest4 = new ListViewItem(new string[] { "Jonathan Sobota", "Accept", "123 Birch Ln.", "I have a comment!", "78" });
            //lvTest4.ToolTipText = "I have a comment! :)";
            //lvTest4.ImageIndex = 1;
            //lvwUnseated.Items.Add(lvTest4);

            //ListViewItem lvTest5 = new ListViewItem(new string[] { "Nema Abachizadeh", "Accept", "123 Birch Ln.", "", "90" });
            //lvTest5.ToolTipText = "I don't have a comment. :(";
            //lvTest5.ImageIndex = 0;
            //lvwUnseated.Items.Add(lvTest5);

            dataGridView1.DataSource = AttendeeDT;

            foreach (DataRow dr in AttendeeDT.Rows)
            {
                ListViewItem li = new ListViewItem();
                                
                if (dr["RSVP"].ToString() == "Accept")
                {
                    li.Text = dr["FIRST_NAME"] + " " + dr["LAST_NAME"];
                    li.SubItems.Add(dr["RSVP"].ToString());

                    if (dr["COMMENTS"].ToString() != "")
                    {
                        li.ImageIndex = 1;
                        li.SubItems.Add(dr["COMMENTS"].ToString());
                        li.ToolTipText = dr["COMMENTS"].ToString();
                    }
                    else
                    {
                        li.ImageIndex = 0;
                        li.SubItems.Add("");
                    }

                    li.SubItems.Add(dr["GUEST_ID"].ToString());

                    lvwUnseated.Items.Add(li);
                }
            }

            AttendeeDT.RowDeleted += new DataRowChangeEventHandler(Row_Deleted);
            AttendeeDT.RowChanged += new DataRowChangeEventHandler(Row_Changed);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            drawShape(shapeType, (int) numericUpDown1.Value);            
        }

        private void cbxTableShape_SelectionChangeCommitted(object sender, EventArgs e)
        {
            shapeType = cbxTableShape.SelectedIndex;
            if (cbxTableShape.Text == "Rectangle")
            {
                cbEndSeats.Enabled = true;
            }
            else
            {
                cbEndSeats.Enabled = false;
            }
            Refresh();
        }

        private void cbEndSeats_CheckedChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void drawShape(int num, int numPoints)
        {
            // Circle
            if (shapeType == 0)
            {
                rectSide2 = rectSide;
                Table = panel1.CreateGraphics();
                TextureBrush tbrush = new TextureBrush(image);                
                Table.FillEllipse(tbrush, new Rectangle((panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2));
                //Pen p = new Pen(Color.Black);
                //Table.DrawEllipse(p, (panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2);
                numericUpDown1.Maximum = 10;
                drawPoints(numPoints, rectSide);                
            }

            // Square
            if (shapeType == 1)
            {
                rectSide2 = rectSide;
                Table = panel1.CreateGraphics();
                TextureBrush tbrush = new TextureBrush(image);
                Table.FillRectangle(tbrush, new Rectangle((panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2));
                //Pen p = new Pen(Color.Black);
                //Table.DrawRectangle(p, (panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2);
                numericUpDown1.Maximum = 8;
                drawPoints(numPoints, rectSide);
            }

            // Rectangle
            if (shapeType == 2)
            {
                if (cbEndSeats.Checked)
                {
                    rectSide2 = panel1.Height - ((listviews[0].Height + 10) * 2);
                }
                else
                {
                    rectSide2 = panel1.Height - 20;
                }
                Table = panel1.CreateGraphics();
                TextureBrush tbrush = new TextureBrush(image);
                Table.FillRectangle(tbrush, new Rectangle((panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2));
                //Pen p = new Pen(Color.Black);
                //Table.DrawRectangle(p, (panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2);
            }

            // Oval
            if (shapeType == 3)
            {
                rectSide2 = 2 * rectSide;
                Table = panel1.CreateGraphics();
                TextureBrush tbrush = new TextureBrush(image);
                Table.FillEllipse(tbrush, new Rectangle((panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2));
                //Pen p = new Pen(Color.Black);
                //Table.DrawEllipse(p, (panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2);
            }
        }

        private void drawPoints(int numPoints, int side)
        {
            Pen p = new Pen(Color.Black);
            Pen p2 = new Pen(Color.Red);

            // Circle
            if (shapeType == 0)
            {
                int additionalRad = 60;
                double angle = 360 / numPoints;

                //Table.DrawEllipse(  p,
                //                    (panel1.Width / 2) - (rectSide / 2) - additionalRad,
                //                    (panel1.Height / 2) - (rectSide2 / 2) - additionalRad,
                //                    rectSide + (additionalRad * 2), 
                //                    rectSide2 + (additionalRad * 2)
                //                 );            

                for (int i = 0; i < numPoints; i++)
                {
                    double x = (panel1.Width / 2) + ((side / 2) + additionalRad) * Math.Cos(degToRad(angle * i));
                    double y = (panel1.Height / 2) + ((side / 2) + additionalRad) * Math.Sin(degToRad(angle * i));

                    Table.DrawRectangle(p2, (float)x, (float)y, 2, 2);

                    listviews[i].Location = new Point((int)x - (listviews[i].Width / 2), (int)y - (listviews[i].Height / 2));
                    listviews[i].Visible = true;

                    //MessageBox.Show(  "Point : (" + x.ToString() + "," + y.ToString() + ")" + Environment.NewLine +
                    //                 "Angle : " + (angle * i) + " Degrees | " + degToRad((angle * i)) + " Radians" 
                    //               ); 
                }
            }
            // Square
            else if (shapeType == 1)
            {
                int additionalSide = 50;

                Rectangle rectSeating = new Rectangle((panel1.Width / 2) - (rectSide / 2) - additionalSide,
                                        (panel1.Height / 2) - (rectSide2 / 2) - additionalSide,
                                        rectSide + (additionalSide * 2),
                                        rectSide2 + (additionalSide * 2)
                                    );

                //Table.DrawRectangle( p, rectSeating );

                List<Point> sqSeatsLessThanFive = new List<Point>() {
                                                                        new Point(rectSeating.Left + (rectSeating.Width / 2), rectSeating.Top),
                                                                        new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 2)),
                                                                        new Point(rectSeating.Left + (rectSeating.Width / 2), rectSeating.Bottom),
                                                                        new Point(rectSeating.Left, rectSeating.Top + (rectSeating.Height / 2))
                                                                    };

                List<Point> sqSeatsFive = new List<Point>() {
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3), rectSeating.Top),         // 1
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3) * 2, rectSeating.Top),     // 2
                                                                new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 2)),       // 3
                                                                new Point(rectSeating.Left + (rectSeating.Width / 2), rectSeating.Bottom),      // 4
                                                                new Point(rectSeating.Left, rectSeating.Top + (rectSeating.Height / 2))         // 5
                                                            };

                List<Point> sqSeatsSix = new List<Point>() {
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3), rectSeating.Top),         // 1
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3) * 2, rectSeating.Top),     // 2
                                                                new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 3)),       // 3
                                                                new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 3)*2),     // 4
                                                                new Point(rectSeating.Left + (rectSeating.Width / 2), rectSeating.Bottom),      // 5
                                                                new Point(rectSeating.Left, rectSeating.Top + (rectSeating.Height / 2))         // 6
                                                            };

                List<Point> sqSeatsSeven = new List<Point>() {
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3), rectSeating.Top),         // 1
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3) * 2, rectSeating.Top),     // 2
                                                                new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 3)),       // 3
                                                                new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 3)*2),     // 4
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3), rectSeating.Bottom),      // 5
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3) * 2, rectSeating.Bottom),  // 6
                                                                new Point(rectSeating.Left, rectSeating.Top + (rectSeating.Height / 2))         // 7
                                                            };

                List<Point> sqSeatsEight = new List<Point>() {
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3), rectSeating.Top),         // 1
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3) * 2, rectSeating.Top),     // 2
                                                                new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 3)),       // 3
                                                                new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 3)*2),     // 4
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3), rectSeating.Bottom),      // 5
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3) * 2, rectSeating.Bottom),  // 6
                                                                new Point(rectSeating.Left, rectSeating.Top + (rectSeating.Height / 3) * 2),
                                                                new Point(rectSeating.Left, rectSeating.Top + (rectSeating.Height / 3))
                                                                
                                                            };

                // if the number of seats is less than or equal to 4
                // there is one seat per side
                if (numPoints <= 4)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        Table.DrawRectangle(p2, sqSeatsLessThanFive[i].X, sqSeatsLessThanFive[i].Y, 2, 2);
                        listviews[i].Location = new Point(sqSeatsLessThanFive[i].X - (listviews[i].Width / 2),
                                                          sqSeatsLessThanFive[i].Y - (listviews[i].Height / 2));
                        listviews[i].Visible = true;
                    } 
                }
                
                // once the number goes beyond 4
                // 5 = 2 seats on side 1
                else if (numPoints == 5)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        Table.DrawRectangle(p2, sqSeatsFive[i].X, sqSeatsFive[i].Y, 2, 2);
                        listviews[i].Location = new Point(sqSeatsFive[i].X - (listviews[i].Width / 2),
                                                          sqSeatsFive[i].Y - (listviews[i].Height / 2));
                        listviews[i].Visible = true;
                    }
                }
                // 6 = 2 seats on side 1, 2
                else if (numPoints == 6)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        Table.DrawRectangle(p2, sqSeatsSix[i].X, sqSeatsSix[i].Y, 2, 2);
                        listviews[i].Location = new Point(sqSeatsSix[i].X - (listviews[i].Width / 2),
                                                          sqSeatsSix[i].Y - (listviews[i].Height / 2));
                        listviews[i].Visible = true;
                    }
                }

                // 7 = 2 seats on side 1, 2, 3
                else if (numPoints == 7)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        Table.DrawRectangle(p2, sqSeatsSeven[i].X, sqSeatsSeven[i].Y, 2, 2);
                        listviews[i].Location = new Point(sqSeatsSeven[i].X - (listviews[i].Width / 2),
                                                          sqSeatsSeven[i].Y - (listviews[i].Height / 2));
                        listviews[i].Visible = true;
                    }
                }
                // 8 = 2 seats on side 1, 2, 3, 4
                else if (numPoints == 8)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        Table.DrawRectangle(p2, sqSeatsEight[i].X, sqSeatsEight[i].Y, 2, 2);
                        listviews[i].Location = new Point(sqSeatsEight[i].X - (listviews[i].Width / 2),
                                                          sqSeatsEight[i].Y - (listviews[i].Height / 2));
                        listviews[i].Visible = true;
                    }
                }
            }
        }

        private double degToRad(double degrees)
        {
            return Math.PI * (degrees - 90) / 180.0;
        }

        private void TableAssignments_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            updateSeatListViews();           
        }

        // 
        #region ListViewHandling
        
        // holds the last item moved
        public class Mysource
        {
            public object source { get; set; }
            Control control { get; set; }
        }

        // triggered when a listview item drag first enters a listview
        private void listView_DragEnter(object sender, DragEventArgs e)
        {
            // Check for the custom DataFormat ListViewItem array.

            {
                if (e.Data.GetDataPresent("ListViewItem"))
                {
                    e.Effect = DragDropEffects.Move;
                }
                else {
                    e.Effect = DragDropEffects.None;
                }
            }
        }


        private void listView_ItemDrag(object sender, ItemDragEventArgs e)
        {            
            ListView lv = sender as ListView;
            ListViewItem myItem = lv.SelectedItems[0]/*.Clone()*/ as ListViewItem;

            lv.DoDragDrop(new DataObject("ListViewItem", myItem), DragDropEffects.Move);         
        }

        // triggered when mouse button is released
        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            ListView lv = (ListView) sender;
            ListViewItem myItem = e.Data.GetData("ListViewItem") as ListViewItem;
            ListView lvOld = dragSource.source as ListView;

            //MessageBox.Show(lvOld.Name.ToString() + " ---> " + lv.Name.ToString());

            // always accept dragged items into unseated listview
            if (lv == lvwUnseated)
            {
                if (myItem.Text != "Empty")
                {
                    // Insert drag item
                    removeItemFromAll(myItem);
                    lv.Items.Add(myItem);
                    lvwUnseated.Sort();
                }

                updateSeatListViews();
            }
            // If it's not the unseated listview, and it's empty
            else if (lv != lvwUnseated && lv.Items[0].Text == "Empty")
            {
                // Remove empty item
                lv.Items[0].Remove();

                // Insert drag item
                removeItemFromAll(myItem);
                lv.Items.Add(myItem);
                
                updateSeatListViews();

                //TESTING
                //MessageBox.Show("I'm " + myItem.Text + ", attendee number " + myItem.SubItems[4].Text);
            }
            // If the seat listview is already filled, ask if user wants to swap
            else
            {
                if (MessageBox.Show("This seat is already filled.  Replace?","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
                { 
                    // Move current item back to unassigned
                    ListViewItem lvi = lv.Items[0];
                    removeItemFromAll(lvi);
                    lvwUnseated.Items.Add(lvi);
                    lvwUnseated.Sort();                  

                    // Insert drag item
                    removeItemFromAll(myItem);
                    lv.Items.Add(myItem);

                    updateSeatListViews();                                       
                }
            }

            if (lv.Items.Count == 0 && lv != lvwUnseated)
            {
                ListViewItem emp = empty.Clone() as ListViewItem;
                lvOld.Items.Add(emp);
            }

            dragSource.source = null;     
        }

        // triggered when listviewitem is drug out of the listview
        private void listView_DragLeave(object sender, EventArgs e)
        {
            dragSource.source = sender;
        }

        // remove specific listview item from all listviews in the form
        private void removeItemFromAll(ListViewItem _li)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is ListView)
                {
                    ListView _lv = c as ListView;
                    _lv.Items.Remove(_li);
                }
            }

            lvwUnseated.Items.Remove(_li);
        }
        
        // update all seat listview
        private void updateSeatListViews()
        {
            for (int i = 0; i < 10; i++)
            {
                //MessageBox.Show(listviews[i].Name + " : " + listviews[i].Items.Count.ToString());

                listviews[i].Location = new Point(3, 3);
                listviews[i].Visible = false;

                if (i >= (int)numericUpDown1.Value && listviews[i].Items.Count > 0 && listviews[i].Items[0].Text != "Empty")
                {
                    ListViewItem lvi = listviews[i].Items[0];
                    removeItemFromAll(lvi);
                    lvwUnseated.Items.Add(lvi);

                    ListViewItem emp = empty.Clone() as ListViewItem;
                    listviews[i].Items.Add(emp);
                }
                else if (listviews[i].Items.Count == 0)
                {
                    //MessageBox.Show("Updating " + listviews[i].Name);

                    ListViewItem emp = empty.Clone() as ListViewItem;
                    listviews[i].Items.Add(emp);
                }
            }

            Refresh();
        }

        #endregion ListViewHandling

        public void LoadListView()
        {
          // Implement code here to Load the ListView from the DataTable

        }

        private void Row_Deleted(object sender, DataRowChangeEventArgs e)
        {

        }

        private void Row_Changed(object sender, DataRowChangeEventArgs e)
        {

        }
        
        private void saveSeating()
        {
            // TEST OUTPUT
            string testOutput = "";

            for (int i = 0; i < (int)numericUpDown1.Value; i++)
            {
                int seat = i + 1;

                if (!listviews[i].Items[0].Text.ToUpper().Contains("EMPTY"))
                {
                    testOutput += String.Format("{0}\tAttendee {1}\tSeat {2}", listviews[i].Items[0].Text,
                        listviews[i].Items[0].SubItems[3].Text, seat.ToString()) + Environment.NewLine;

                    //listviews[i].Items[0].Text + 
                    //        " | Attendee " + listviews[i].Items[0].SubItems[4].Text +
                    //        " | Seat " + seat.ToString() + Environment.NewLine;
                }

            }

            MessageBox.Show(testOutput);
            // END TEST OUTPUT
        }

        private void resetSeating()
        {
            foreach (ListView lv in listviews)
            {
                if (!lv.Items[0].Text.ToUpper().Contains("EMPTY"))
                {
                    ListViewItem lvi = lv.Items[0];
                    removeItemFromAll(lvi);
                    lvwUnseated.Items.Add(lvi);
                }
            }

            updateSeatListViews();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetSeating();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveSeating();
        }
    }
}
