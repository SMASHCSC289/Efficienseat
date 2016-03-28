using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Efficienseat
{
    public partial class Attendee_List : Form
    {
        public DataTable AttendeeDT;
        public DataTable TableDT;
        public SQLiteConnection DBConnection;
        int wedID;

        #region Custom_UI

        //[DllImport("user32.dll")]
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        //private void MainForm_Resize(object sender, EventArgs e)
        //{
        //    label_Title.Width = this.Width - 2;
        //    menuStrip1.Width = this.Width - 2;
        //}

        ///// <summary>
        ///// Window Border Method 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Rectangle formBorder = this.DisplayRectangle;
            Rectangle formBorder = new Rectangle(0, 0, this.DisplayRectangle.Width - 1, this.DisplayRectangle.Height - 1);
            e.Graphics.DrawRectangle(new Pen(Color.DarkSlateGray, 1),
                                     formBorder);
        }

        ///// <summary>
        /////  Custom Form Controls
        ///// </summary>

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    ReleaseCapture();
            //    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            //}
        }

        /// <summary>
        /// Window Resize Method
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int wmNcHitTest = 0x84;
            const int htLeft = 10;
            const int htRight = 11;
            const int htTop = 12;
            const int htTopLeft = 13;
            const int htTopRight = 14;
            const int htBottom = 15;
            const int htBottomLeft = 16;
            const int htBottomRight = 17;

            if (m.Msg == wmNcHitTest)
            {
                int x = (int)(m.LParam.ToInt64() & 0xFFFF);
                int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point pt = PointToClient(new Point(x, y));
                Size clientSize = ClientSize;
                /////allow resize on the lower right corner
                //if (pt.X >= clientSize.Width - 5 && pt.Y >= clientSize.Height - 5 && clientSize.Height >= 16)
                //{
                //    m.Result = (IntPtr)(IsMirrored ? htBottomLeft : htBottomRight);
                //    return;
                //}
                /////allow resize on the lower left corner
                //if (pt.X <= 5 && pt.Y >= clientSize.Height - 5 && clientSize.Height >= 16)
                //{
                //    m.Result = (IntPtr)(IsMirrored ? htBottomRight : htBottomLeft);
                //    return;
                //}
                /////allow resize on the upper right corner
                //if (pt.X <= 5 && pt.Y <= 5 && clientSize.Height >= 16)
                //{
                //    m.Result = (IntPtr)(IsMirrored ? htTopRight : htTopLeft);
                //    return;
                //}
                /////allow resize on the upper left corner
                //if (pt.X >= clientSize.Width - 5 && pt.Y <= 5 && clientSize.Height >= 16)
                //{
                //    m.Result = (IntPtr)(IsMirrored ? htTopLeft : htTopRight);
                //    return;
                //}
                /////allow resize on the top border
                //if (pt.Y <= 5 && clientSize.Height >= 16)
                //{
                //    m.Result = (IntPtr)(htTop);
                //    return;
                //}
                /////allow resize on the bottom border
                //if (pt.Y >= clientSize.Height - 5 && clientSize.Height >= 16)
                //{
                //    m.Result = (IntPtr)(htBottom);
                //    return;
                //}
                /////allow resize on the left border
                //if (pt.X <= 5 && clientSize.Height >= 16)
                //{
                //    m.Result = (IntPtr)(htLeft);
                //    return;
                //}

                ///allow resize on the right border
                if (pt.X >= clientSize.Width - 5 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(htRight);
                    return;
                }
            }

            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;

            //base.WndProc(ref m);
        }

        ///// <summary>
        ///// Window Resize Variables
        ///// </summary>
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion Custom_UI

        public Attendee_List()
        {
            InitializeComponent();

            // border code
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.ResizeRedraw = true;

            // movement code
            // this.MouseDown += new MouseEventHandler(Form1_MouseDown);            
            //label_Title.MouseDown += new MouseEventHandler(Form1_MouseDown);

            flowLayoutPanel1.Width = this.Width - 2;

            lvwAttendee.Width = this.Width - 2;
            lvwAttendee.Height = this.Height - flowLayoutPanel1.Height - 3;
            lvwAttendee.Location = new Point(1, flowLayoutPanel1.Location.Y + flowLayoutPanel1.Height + 1);            
        }

        public int WedID
        {
            get { return wedID; }

            set { wedID = value; }
        }

        private void Attendee_List_Load(object sender, EventArgs e)
        {
           // Set list of images for listview
           // lvwAttendee.LargeImageList = imlTableNumbers;

        } //END Attendee_List_Load EVENT

        // BUTTONS
        #region FormButtons

        private void btnAddAttendee_Click(object sender, EventArgs e)
        {
            addAttendee();   
        } //END btnAddAttendee_Click EVENT

        private void btnChangeView_Click(object sender, EventArgs e)
        {
            changeView();
        } //END btnChangeView_Click EVENT

        private void btnEditEntry_Click(object sender, EventArgs e)
        {
            if (lvwAttendee.SelectedItems.Count == 1)
            {
                editAttendee(lvwAttendee.SelectedItems[0]);
            }
        } //END btnEditEntry_Click EVENT

        private void btnRemoveAttendee_Click(object sender, EventArgs e)
        {
            if (lvwAttendee.SelectedItems.Count == 1)
            {
                removeAttendee(lvwAttendee.SelectedItems[0]);
            }
        } //END btnRemoveAttendee_Click EVENT

        #endregion FormButtons

        // CONTEXT-SHORTCUT MENU
        #region ListViewContextMenu

        private void tmiRemoveAttendee_Click(object sender, EventArgs e)
        {
            // TODO: update to retrieve item under mouse
            removeAttendee(lvwAttendee.SelectedItems[0]);
        }

        private void tmiEdit_Click(object sender, EventArgs e)
        {
            if (lvwAttendee.SelectedItems.Count == 1)
            {
                editAttendee(lvwAttendee.SelectedItems[0]);
            }
        }

        private void tmiImport_Click(object sender, EventArgs e)
        {
            importAttendees();
        }

        #endregion ListViewContextMenu

        // METHODS
        #region Methods

        // Load attendees from DB

        public void LoadTableNames()
        {
            for (int i = 0; i < TableDT.Rows.Count; i++)
            {
                DataRow dr = TableDT.Rows[i];
                lvwAttendee.Groups[i+1].Header = dr["TABLE_NAME"].ToString();
            }
        }

        public void LoadListView()
        {
            lvwAttendee.Items.Clear();

            for (int i = 0; i < AttendeeDT.Rows.Count; i++)
            {
                DataRow dr = AttendeeDT.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["LAST_NAME"].ToString() + ", " + dr["FIRST_NAME"].ToString());
                if (dr["RSVP"] == null || dr["RSVP"].ToString() == "")
                {
                    listitem.SubItems.Add("Unknown");
                    listitem.ImageIndex = 0;
                    listitem.Group = lvwAttendee.Groups[0];
                }
                else if (dr["RSVP"].ToString() == "Accept" && dr["TABLE_ID"].ToString() == "")
                {
                    listitem.SubItems.Add(dr["RSVP"].ToString());
                    listitem.ImageIndex = 0;
                    listitem.Group = lvwAttendee.Groups[0];
                }
                else if (dr["RSVP"].ToString() == "Accept" && dr["TABLE_ID"].ToString() != "")
                {
                    int index = Convert.ToInt32(dr["TABLE_ID"]);
                    listitem.SubItems.Add(dr["RSVP"].ToString());
                    listitem.ImageIndex = index;
                    listitem.Group = lvwAttendee.Groups[index];
                }
                else
                {
                    listitem.SubItems.Add(dr["RSVP"].ToString());
                }

                listitem.SubItems.Add(dr["GUEST_ID"].ToString());                
                listitem.SubItems.Add(dr["FOOD_ALLERGY"].ToString());
                listitem.SubItems.Add(dr["COMMENTS"].ToString());
                lvwAttendee.Items.Add(listitem);
            }
        }

        // add item
        private void addAttendee()
        {
            //Create edit entry window for data population
            //  Pull data form form rather than passing through
            using (DataEntryForm data = new DataEntryForm())
            {
                if (data.ShowDialog(this) == DialogResult.OK)
                {
                    string name = data.LastName + "," + data.FirstName;
                    string rsvp = data.RSVP;
                    string allergy = data.FoodAllergy;
                    string comment = data.Comments;

                    //add new row to DataTable
                    DataRow newRow = AttendeeDT.NewRow();
                    newRow["FIRST_NAME"] = data.FirstName;
                    newRow["LAST_NAME"] = data.LastName;
                    if (data.RSVP.ToString() == "")
                        newRow["RSVP"] = "Unknown";
                    else
                        newRow["RSVP"] = data.RSVP;
                    if (AttendeeDT.Rows.Count == 0)
                        newRow["GUEST_ID"] = 1;
                    else
                        newRow["GUEST_ID"] = Convert.ToInt32(AttendeeDT.Compute("max(GUEST_ID)", string.Empty)) + 1;
                    newRow["WED_ID"] = wedID;
                    newRow["FOOD_ALLERGY"] = allergy;
                    if (comment == "")
                    {
                        newRow["COMMENTS"] = DBNull.Value;
                    }
                    else
                    {
                        newRow["COMMENTS"] = comment;
                    }
                    AttendeeDT.Rows.Add(newRow);


                    //ListViewItem [0] = NAME
                    //ListViewItem [1] = RSVP
                    //ListViewItem [2] = GUEST_ID
                    //ListViewItem [3] = FOOD_ALLERGY
                    //ListViewItem [4] = COMMENTS
                    ListViewItem newGuest = new ListViewItem(new string[] { name, rsvp, newRow["GUEST_ID"].ToString(), newRow["FOOD_ALLERGY"].ToString(), newRow["COMMENTS"].ToString() });
                    newGuest.ImageIndex = 0;
                    newGuest.Group = lvwAttendee.Groups[0];
                    lvwAttendee.Items.Add(newGuest);
                }
            }
        }

        // change listview visuals
        private void changeView()
        {
            if (lvwAttendee.View == View.Details)
            {
                lvwAttendee.View = View.Tile;
                lvwAttendee.ShowGroups = true;
            }
            else
            {
                lvwAttendee.View = View.Details;
                lvwAttendee.ShowGroups = false;
                lvwAttendee.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwAttendee.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
               // lvwAttendee.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwAttendee.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwAttendee.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
               // lvwAttendee.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        // change data in selected item
        private void editAttendee(ListViewItem lvi)
        {
            using (DataEntryForm data = new DataEntryForm())
            {
                DataRow[] updateRow = AttendeeDT.Select("GUEST_ID = " + lvi.SubItems[2].Text.ToString());
                if (updateRow.Length > 0)
                {
                    data.FirstName = updateRow[0]["FIRST_NAME"].ToString();
                    data.LastName = updateRow[0]["LAST_NAME"].ToString();
                    data.RSVP = updateRow[0]["RSVP"].ToString();
                    data.FoodAllergy = updateRow[0]["FOOD_ALLERGY"].ToString();
                    data.Comments = updateRow[0]["COMMENTS"].ToString();
                }
   

                if (data.ShowDialog(this) == DialogResult.OK)
                {
                    if (updateRow.Length > 0)
                    {
                        updateRow[0]["FIRST_NAME"] = data.FirstName;
                        updateRow[0]["LAST_NAME"] = data.LastName;
                        updateRow[0]["RSVP"] = data.RSVP;
                        updateRow[0]["FOOD_ALLERGY"] = data.FoodAllergy;
                        updateRow[0]["COMMENTS"] = data.Comments;
                        AttendeeDT.AcceptChanges();

                        lvi.Text = data.LastName + ", " + data.FirstName;
                        lvi.SubItems[1].Text = data.RSVP;
                        lvi.SubItems[2].Text = data.FoodAllergy;
                        lvi.SubItems[3].Text = data.Comments;

                        LoadListView();
                    }
                }
            }
        }

        // Remove selected item
        private void removeAttendee(ListViewItem lvi)
        {
            int guestID = Convert.ToInt32(lvi.SubItems[2].Text);
            lvi.Remove();

            // find row in Datatable using GUEST_ID
            DataRow[] removeRow = AttendeeDT.Select("GUEST_ID = " + guestID.ToString());
            if (removeRow.Length > 0)
            {
                int SelectedIndex = AttendeeDT.Rows.IndexOf(removeRow[0]);
                AttendeeDT.Rows.RemoveAt(SelectedIndex);
            }
        }

        //import attendees from text file
        public void importAttendees()
        {
            string absolutePath = null;
            string line = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //set options for open file menu
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            //if user selects file and hits confirms
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                absolutePath = openFileDialog.FileName;
                Cursor.Current = Cursors.WaitCursor;

                //open file and parse by line
                try
                {
                    StreamReader filestream = new StreamReader(absolutePath);

                    //iterate through file line by line
                    while ((line = filestream.ReadLine()) != null)
                    {
                        //control for item equality
                        bool equal = false;
                        string[] name;
                        char delimiter = ',';
                        var count = line.Count(c => c == ',');
                        if (count != 1)
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Line " + line + " has too many commas in the format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        //if name does not already exist, add item to ListView
                        if (!equal)
                        {
                            name = line.Split(delimiter);

                            string FirstName = name[1].ToString().Trim().ToUpper();
                            string LastName = name[0].ToString().Trim().ToUpper();

                            string FullName = LastName + ", " + FirstName;

                            //iterate through listviewitems to compare with current line from txt file
                            //  sloppy as it iterates through the entire listview for each line item
                            //  --Potentially faster to check txt file for duplicates first and then only
                            //      check existing listviewitems for equality?
                            foreach (ListViewItem lvi in lvwAttendee.Items)
                            {
                                //if names are equal, do not add and break from search
                                if (FullName.Equals(lvi.SubItems[0].Text))
                                {
                                    equal = true;
                                    break;
                                }
                            }
                            
                            if (!equal)
                            {
                                DataRow newRow = AttendeeDT.NewRow();
                                newRow["FIRST_NAME"] = FirstName;
                                newRow["LAST_NAME"] = LastName;
                                newRow["RSVP"] = "Unknown";
                                if (AttendeeDT.Rows.Count == 0)
                                    newRow["GUEST_ID"] = 1;
                                else
                                    newRow["GUEST_ID"] = Convert.ToInt32(AttendeeDT.Compute("max(GUEST_ID)", string.Empty)) + 1;
                                newRow["WED_ID"] = wedID;
                                AttendeeDT.Rows.Add(newRow);

                                //ListViewItem [0] = NAME
                                //ListViewItem [1] = RSVP
                                //ListViewItem [2] = GUEST_ID
                                //ListViewItem [3] = FOOD_ALLERGY
                                //ListViewItem [4] = COMMENTS
                                ListViewItem newGuest = new ListViewItem(new string[] { newRow["LAST_NAME"] + ", " + newRow["FIRST_NAME"], "Unknown", newRow["GUEST_ID"].ToString(), "", "" });
                                lvwAttendee.Items.Add(newGuest);
                            }
                        }
                    }
                    //close open stream
                    filestream.Dispose();

                }
                catch (Exception e)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Error: could not open file.\n Message: " + e.ToString());
                }
            }
            openFileDialog.Dispose();
            Cursor.Current = Cursors.Default;
        }

        #endregion Methods

        private void Attendee_List_Resize(object sender, EventArgs e)
        {
            int flowPanelHeight = 32;
            lvwAttendee.Width = this.Width - 2;
            flowLayoutPanel1.Width = this.Width - 2;           

            if (this.Width < 505)
            {
                flowLayoutPanel1.Height = (flowPanelHeight * 2);
                lvwAttendee.Location = new Point(1, flowLayoutPanel1.Location.Y + flowLayoutPanel1.Height + 1);
            }
            else if (this.Width >= 505)
            {
                flowLayoutPanel1.Height = flowPanelHeight;
                lvwAttendee.Location = new Point(1, flowLayoutPanel1.Location.Y + flowLayoutPanel1.Height + 1);
            }

            lvwAttendee.Height = this.Height - flowLayoutPanel1.Height - 2;
        }

        private void Attendee_List_Move(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
        }
    }
}
