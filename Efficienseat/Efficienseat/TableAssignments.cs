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
        Image image = new Bitmap(Efficienseat.Properties.Resources.WrinklesHomogeneous0044_M2);

        Mysource dragSource = new Mysource();

        List<CustomPanel> panels = new List<CustomPanel>();
        List<ListView> listviews;

        public TableAssignments()
        {
            InitializeComponent();
            rectSide = panel1.Width - (panel1.Width / 2);
            rectSide2 = rectSide;

            listviews = new List<ListView>() { lvwSeat1, lvwSeat2, lvwSeat3, lvwSeat4, lvwSeat5, lvwSeat6, lvwSeat7, lvwSeat8, lvwSeat9, lvwSeat10 };
            foreach (ListView view in listviews)
            {
                view.Enabled = false;
                view.Visible = false;
            }
        }

        private void TableAssignments_Load(object sender, EventArgs e)
        {
            ListViewItem lvTest = new ListViewItem(new string[] { "Dan Stabler", "Accept", "123 Birch Ln.", "", "1" });
            lvTest.ToolTipText = "I don't have a comment. :(";
            lvTest.ImageIndex = 0;
            lvwUnseated.Items.Add(lvTest);

            ListViewItem lvTest2 = new ListViewItem(new string[] { "Mark Harriett", "Accept", "123 Birch Ln.", "I have a comment! :)", "2" });
            lvTest2.ToolTipText = "I have a comment! :)";
            lvTest2.ImageIndex = 1;
            lvwUnseated.Items.Add(lvTest2);

            ListViewItem lvTest3 = new ListViewItem(new string[] { "Diane Mayes", "Accept", "123 Birch Ln.", "", "3" });
            lvTest3.ToolTipText = "I don't have a comment. :(";
            lvTest3.ImageIndex = 0;
            lvwUnseated.Items.Add(lvTest3);

            ListViewItem lvTest4 = new ListViewItem(new string[] { "Jonathan Sobota", "Accept", "123 Birch Ln.", "I have a comment!", "4" });
            lvTest4.ToolTipText = "I have a comment! :)";
            lvTest4.ImageIndex = 1;
            lvwUnseated.Items.Add(lvTest4);

            ListViewItem lvTest5 = new ListViewItem(new string[] { "Nema Abachizadeh", "Accept", "123 Birch Ln.", "", "5" });
            lvTest5.ToolTipText = "I don't have a comment. :(";
            lvTest5.ImageIndex = 0;
            lvwUnseated.Items.Add(lvTest5);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            drawShape(shapeType, (int) numericUpDown1.Value);
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            shapeType = comboBox2.SelectedIndex;
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
            }

            // Rectangle
            if (shapeType == 2)
            {
                rectSide2 = 2 * rectSide;
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
            int additionalRad = 60;
            double angle = 360 / numPoints;

            Pen p = new Pen(Color.Black);
            Pen p2 = new Pen(Color.Red);

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

                Table.DrawRectangle(p2, (float) x, (float) y, 2, 2);

                listviews[i].Location = new Point((int) x - (listviews[i].Width / 2), (int) y - (listviews[i].Height / 2));
                listviews[i].Enabled = true;
                listviews[i].Visible = true;

                //MessageBox.Show(  "Point : (" + x.ToString() + "," + y.ToString() + ")" + Environment.NewLine +
                //                 "Angle : " + (angle * i) + " Degrees | " + degToRad((angle * i)) + " Radians" 
                //               );
            }

            for (int i = (int)numericUpDown1.Value; i < 10; i++)
            {
                listviews[i].Location = new Point(3, 3);
                listviews[i].Enabled = false;
                listviews[i].Visible = false;

                if (listviews[i].Items.Count > 0)
                {
                    ListViewItem lvi = listviews[i].Items[0];
                    removeItemFromAll(lvi);
                    lvwUnseated.Items.Add(lvi);
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
            Refresh();
        }
        
        #region ListViewHandling

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
            //lv.SelectedItems[0].Remove();
        }

        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            ListView lv = (ListView) sender;
            ListViewItem myItem = e.Data.GetData("ListViewItem") as ListViewItem;            

            // always accept dragged items into unseated listview
            if (lv == lvwUnseated)
            {
                // Insert drag item
                removeItemFromAll(myItem);
                lv.Items.Add(myItem);
                lvwUnseated.Sort();
            }
            // If it's not the unseated listview, and it's empty
            else if (lv != lvwUnseated && lv.Items.Count == 0)
            {
                // Insert drag item
                removeItemFromAll(myItem);
                lv.Items.Add(myItem);                                
            }
            // If the seat listview is already filled, ask if user wants to swap
            else
            {
                if (MessageBox.Show("This seat is already filled.  Replace?","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    ListView lvOld = dragSource.source as ListView;

                    // Move current item back to unassigned
                    ListViewItem lvi = lv.Items[0];
                    removeItemFromAll(lvi);
                    lvwUnseated.Items.Add(lvi);
                    lvwUnseated.Sort();                  

                    // Insert drag item
                    removeItemFromAll(myItem);
                    lv.Items.Add(myItem);
                }
            }

            dragSource.source = null;     
        }

        private void listView_DragLeave(object sender, EventArgs e)
        {
            dragSource.source = sender;
        }

        private void enableListViewSmall(ListView lv, int seatNumber)
        {

        }

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

        public class Mysource
        {
            public object source { get; set; }
            Control control { get; set; }
        }

        #endregion ListViewHandling
    }
}
