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
        public DataTable TableDT;
        Graphics Table;
        private int shapeType = -1;
        int rectSide, rectSide2;
        Image image = new Bitmap(Efficienseat.Properties.Resources.Tablecloth);
        public DataTable AttendeeDT;
        Mysource dragSource = new Mysource();
        List<ListView> listviews;
        ListViewItem empty = new ListViewItem("Empty");
        private int wedID;

        public int WeddingID
        {
            set { wedID = value; }
        }

        public TableAssignments()
        {
            InitializeComponent();            

            rectSide = pnlWorkspace.Width - (pnlWorkspace.Width / 2);
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

            AttendeeDT.RowDeleted += new DataRowChangeEventHandler(Row_Deleted);
            AttendeeDT.RowChanged += new DataRowChangeEventHandler(Row_Changed);     
            
            // Load tables from DB
            foreach (DataRow row in TableDT.Rows)
            {
                cbxTableName.Items.Add(row.Field<string>("TABLE_NAME"));
            }       
        }

        // Hijack Paint event for the panel
        private void pnlWorkspace_Paint(object sender, PaintEventArgs e)
        {
            drawShape(shapeType, (int) numericUpDown1.Value);            
        }

        // Draw the table in the panel
        private void drawShape(int num, int numPoints)
        {
            // Circle
            if (shapeType == 0)
            {
                rectSide2 = rectSide;
                Table = pnlWorkspace.CreateGraphics();
                TextureBrush tbrush = new TextureBrush(image);                
                Table.FillEllipse(tbrush, new Rectangle((pnlWorkspace.Width / 2) - (rectSide / 2), (pnlWorkspace.Height / 2) - (rectSide2 / 2), rectSide, rectSide2));
                //Pen p = new Pen(Color.Black);
                //Table.DrawEllipse(p, (panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2);
                numericUpDown1.Maximum = 10;
                calcPoints(numPoints, rectSide);                
            }

            // Square
            if (shapeType == 1)
            {
                rectSide2 = rectSide;
                Table = pnlWorkspace.CreateGraphics();
                TextureBrush tbrush = new TextureBrush(image);
                Table.FillRectangle(tbrush, new Rectangle((pnlWorkspace.Width / 2) - (rectSide / 2), (pnlWorkspace.Height / 2) - (rectSide2 / 2), rectSide, rectSide2));
                //Pen p = new Pen(Color.Black);
                //Table.DrawRectangle(p, (panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2);
                numericUpDown1.Maximum = 8;
                calcPoints(numPoints, rectSide);
            }

            // Rectangle
            if (shapeType == 2)
            {
                if (cbEndSeats.Checked)
                {
                    rectSide2 = pnlWorkspace.Height - ((listviews[0].Height + 10) * 2);
                }
                else
                {
                    rectSide2 = pnlWorkspace.Height - 20;
                }
                Table = pnlWorkspace.CreateGraphics();
                TextureBrush tbrush = new TextureBrush(image);
                Table.FillRectangle(tbrush, new Rectangle((pnlWorkspace.Width / 2) - (rectSide / 2), (pnlWorkspace.Height / 2) - (rectSide2 / 2), rectSide, rectSide2));
                //Pen p = new Pen(Color.Black);
                //Table.DrawRectangle(p, (panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2);
            }

            // Oval
            if (shapeType == 3)
            {
                rectSide2 = 2 * rectSide;
                Table = pnlWorkspace.CreateGraphics();
                TextureBrush tbrush = new TextureBrush(image);
                Table.FillEllipse(tbrush, new Rectangle((pnlWorkspace.Width / 2) - (rectSide / 2), (pnlWorkspace.Height / 2) - (rectSide2 / 2), rectSide, rectSide2));
                //Pen p = new Pen(Color.Black);
                //Table.DrawEllipse(p, (panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2);
            }
        }

        // Calculate seating positions in the panel
        private void calcPoints(int numPoints, int side)
        {
            Pen p = new Pen(Color.Black);
            Pen p2 = new Pen(Color.Red);

            // Circle
            if (shapeType == 0)
            {
                int additionalRad = 60;
                double angle = 360 / numPoints;     

                for (int i = 0; i < numPoints; i++)
                {
                    double x = (pnlWorkspace.Width / 2) + ((side / 2) + additionalRad) * Math.Cos(degToRad(angle * i));
                    double y = (pnlWorkspace.Height / 2) + ((side / 2) + additionalRad) * Math.Sin(degToRad(angle * i));

                    Table.DrawRectangle(p2, (float)x, (float)y, 2, 2);

                    listviews[i].Location = new Point((int)x - (listviews[i].Width / 2), (int)y - (listviews[i].Height / 2));
                    listviews[i].Visible = true;
                }
            }

            // Square
            else if (shapeType == 1)
            {
                int additionalSide = 50;

                Rectangle rectSeating = new Rectangle((pnlWorkspace.Width / 2) - (rectSide / 2) - additionalSide,
                                        (pnlWorkspace.Height / 2) - (rectSide2 / 2) - additionalSide,
                                        rectSide + (additionalSide * 2),
                                        rectSide2 + (additionalSide * 2)
                                    );

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
                                                                new Point(rectSeating.Left, rectSeating.Top + (rectSeating.Height / 3) * 2),    // 7
                                                                new Point(rectSeating.Left, rectSeating.Top + (rectSeating.Height / 3))         // 8
                                                                
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

        // Convert degrees to radians for circle calculations
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

        private void cbxTableShape_SelectionChangeCommitted(object sender, EventArgs e)
        {
            doTableStuff();
        }

        // Set shapeType and refresh the panel
        private void doTableStuff()
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

        // ListView Methods
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

            if (cbxTableName.SelectedIndex != -1 && cbxTableShape.SelectedIndex != -1)
            {
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

                    updateAttendee(Convert.ToInt32(myItem.SubItems[3].Text));

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

                    //MessageBox.Show("'" + myItem.SubItems[3].Text + "'" + Environment.NewLine +
                    //                "'" + lv.Tag + "'" + Environment.NewLine +
                    //                "'" + cbxTableName.SelectedIndex + "'");

                    updateAttendee(Convert.ToInt32(myItem.SubItems[3].Text), Convert.ToInt32(lv.Tag), cbxTableName.SelectedIndex + 1);

                    updateSeatListViews();
                }
                // If the seat listview is already filled, ask if user wants to swap
                else
                {
                    if (MessageBox.Show("This seat is already filled.  Replace?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
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
            }
            else if (cbxTableName.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if (cbxTableShape.SelectedIndex == -1)
            {
                MessageBox.Show("Please set the shape of the table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
            foreach (Control c in pnlWorkspace.Controls)
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
                    //lvwUnseated.Items.Add(lvi);

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

        // Load unseated attendees in main list
        public void loadListView()
        {
            lvwUnseated.Clear();

            // Iterate through all attendees that have accepted and are not seated
            // Add them to the unseated list
            foreach (DataRow dr in AttendeeDT.Rows)
            {
                ListViewItem li = new ListViewItem();

                if (dr["RSVP"].ToString() == "Accept" && dr["TABLE_ID"] == DBNull.Value)
                {
                    li.Text = dr["LAST_NAME"] + ", " + dr["FIRST_NAME"];
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
        }

        // Load attendees in their assigned seats
        public void loadSeats()
        {
            // On each load, clear out all seats replace them with empty chairs.
            foreach (ListView lv in listviews)
            {
                lv.Items.Clear();
                ListViewItem emp = empty.Clone() as ListViewItem;
                lv.Items.Add(emp);
            }

            // Get list of all seated attendees for the selected table
            var result = from DataRow row in AttendeeDT.Rows
                         where Convert.ToInt32(row[0]) == wedID && row[7] != DBNull.Value && Convert.ToInt32(row[7]) == (cbxTableName.SelectedIndex + 1)
                         select row;

            // Iterate through the list to create attendee items and seat them
            foreach (DataRow dr in result)
            {
                ListViewItem li = new ListViewItem();

                li.Text = dr["LAST_NAME"] + ", " + dr["FIRST_NAME"];
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

                // Have to use SEAT_NUM - 1 to account for 0 indexed list.
                listviews[Convert.ToInt32(dr["SEAT_NUM"]) - 1].Items.Clear();
                listviews[Convert.ToInt32(dr["SEAT_NUM"]) - 1].Items.Add(li);
            }
        }

        #endregion ListViewHandling

        // Update DB record with new attendee seat assignment
        public void updateAttendee(int attendeeNum, int seatNumber = 0, int tableNumber = 0)
        {
            // write LINQ query to pull out user
            var result = from DataRow row in AttendeeDT.Rows
                         where Convert.ToInt32(row[1]) == attendeeNum
                         select row;

            // update user information (just table and seat)
            foreach (DataRow row in result)
            {
                // unseated
                if (seatNumber == 0 && tableNumber == 0)
                {
                    row.SetField("TABLE_ID", DBNull.Value);
                    row.SetField("SEAT_NUM", DBNull.Value);
                }
                // seated
                else
                {
                    row.SetField("TABLE_ID", tableNumber);
                    row.SetField("SEAT_NUM", seatNumber);
                }                
            }
        }
        
        // Update Table attributes in the DB
        // Implemented due to broken real-time edit changes.
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            updateTable(cbxTableName.SelectedIndex + 1, cbxTableShape.Text, (int)numericUpDown1.Value);
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            using (TableCreateForm tcf = new TableCreateForm())
            {
                if (tcf.ShowDialog(this) == DialogResult.OK)
                {
                    if (tcf.Name != null || tcf.Shape != null)
                    {
                        addTable(tcf.Name, tcf.Shape, tcf.NumberOfSeats);
                    }
                    else if (tcf.Name == null)
                    {
                        MessageBox.Show("Table name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else if (tcf.Shape == null)
                    {
                        MessageBox.Show("Table must have a shape.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }                
            }
        }

        // Add new table to the wedding
        private void addTable(string tableName, string tableShape, int numSeats)
        {
            int newTableID;

            if (TableDT.Rows.Count == 0)
            {
                newTableID = 1;
            }
            else
            {
                newTableID = Convert.ToInt32(TableDT.Compute("max(TABLE_ID)", string.Empty)) + 1;
            }

            MessageBox.Show(newTableID.ToString());

            //Create and fill a new DataRow based on TableDT
            DataRow row = TableDT.NewRow();
            row.SetField("WED_ID", wedID);
            row.SetField("TABLE_ID", newTableID);
            row.SetField("TABLE_NAME", tableName);
            row.SetField("NUM_OF_SEATS", numSeats);
            row.SetField("TABLE_TYPE", tableShape);

            //Add newly created row to TableDT
            TableDT.Rows.Add(row);

            //Add table to cbxTableName
            cbxTableName.Items.Add(tableName);
        }

        // Save changes to the table in the DB
        private void updateTable(int tableID, string tableShape, int numSeats)
        {
            var result = from row in TableDT.AsEnumerable()
                         where Convert.ToInt32(row[0]) == wedID && Convert.ToInt32(row[1]) == tableID
                         select row;

            foreach (DataRow row in result)
            {
                row.SetField("TABLE_TYPE", tableShape);
                row.SetField("NUM_OF_SEATS", numSeats);
            }
        }

        private void cbxTableName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadTable(cbxTableName.SelectedIndex + 1);
            loadSeats();
        }

        // Get table from DB and set form controls
        private void loadTable(int index)
        {
            var result = from row in TableDT.AsEnumerable()
                         where Convert.ToInt32(row[0]) == wedID && Convert.ToInt32(row[1]) == index
                         select row;

            foreach (DataRow row in result)
            {
                cbxTableShape.SelectedIndex = cbxTableShape.Items.IndexOf(row[4]);
                numericUpDown1.Value = Convert.ToDecimal(row[3]);
            }

            doTableStuff();
        }

        // Attendee DataTable Change Events
        private void Row_Deleted(object sender, DataRowChangeEventArgs e)
        {
            loadListView();
        }

        private void Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            loadListView();
        }
    }
}
