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
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

namespace Efficienseat
{
    public partial class Attendee_List : Form
    {
        //private 
        private int wedID;

        //public
        public DataTable AttendeeDT;
        public DataTable TableDT;
        public SQLiteConnection DBConnection;
        

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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Rectangle formBorder = this.DisplayRectangle;
            Rectangle formBorder = new Rectangle(0, 0, this.DisplayRectangle.Width - 1, this.DisplayRectangle.Height - 1);
            e.Graphics.DrawRectangle(new Pen(Color.DarkSlateGray, 1),
                                     formBorder);
        }


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

            lvwAttendee.Height = this.Height - flowLayoutPanel1.Height - pnlGuestCount.Height - 2;
        }

        #endregion Custom_UI

        #region Constructor 

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

        #endregion

        #region Properties

        public int WedID
        {
            get { return wedID; }

            set { wedID = value; }
        }
        #endregion


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
                if (MessageBox.Show("Are you sure you want to remove: " + lvwAttendee.SelectedItems[0].Text + "?", "Remove Guest", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 removeAttendee(lvwAttendee.SelectedItems[0]);
            }
            //else if (lvwAttendee.SelectedItems.Count > 1)
            //{
            //    if (MessageBox.Show("Are you sure you want to remove all selected guest?", "Remove Guest", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        for (int i = 0; i < lvwAttendee.SelectedItems.Count; i++)
            //        {
            //            removeAttendee(lvwAttendee.SelectedItems[i]);
            //        }
            //    }
            //}
        } //END btnRemoveAttendee_Click EVENT

        #endregion FormButtons

        // CONTEXT-SHORTCUT MENU
        #region ListViewContextMenu

        private void tmiRemoveAttendee_Click(object sender, EventArgs e)
        {
            // TODO: update to retrieve item under mouse
            if (lvwAttendee.SelectedItems.Count == 1)
            {
                removeAttendee(lvwAttendee.SelectedItems[0]);
            }
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
            importAttendeesText();
        }

        private void importExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importAttendeesExcel();
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
                lvwAttendee.Groups[i+3].Header = dr["TABLE_NAME"].ToString();
            }
        }

        public void LoadListView()
        {
            lvwAttendee.Items.Clear();
            try
            {
                lvwAttendee.BeginUpdate();
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
                    else if (dr["RSVP"].ToString() == "Unknown")
                    {
                        listitem.SubItems.Add(dr["RSVP"].ToString());
                        listitem.ImageIndex = 0;
                        listitem.Group = lvwAttendee.Groups[0];
                    }
                    else if (dr["RSVP"].ToString() == "Decline")
                    {
                        listitem.SubItems.Add(dr["RSVP"].ToString());
                        listitem.ImageIndex = 0;
                        listitem.Group = lvwAttendee.Groups[1];
                    }
                    else if (dr["RSVP"].ToString() == "Accept" && dr["TABLE_ID"].ToString() == "")
                    {
                        listitem.SubItems.Add(dr["RSVP"].ToString());
                        listitem.ImageIndex = 0;
                        listitem.Group = lvwAttendee.Groups[2];
                    }
                    else if (dr["RSVP"].ToString() == "Accept" && dr["TABLE_ID"].ToString() != "")
                    {
                        int index = Convert.ToInt32(dr["TABLE_ID"]);
                        listitem.SubItems.Add(dr["RSVP"].ToString());
                        listitem.ImageIndex = index;
                        listitem.Group = lvwAttendee.Groups[index + 2];
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
            finally
            {
                lvwAttendee.EndUpdate();
                updateGuestCount();
                CheckGuestCount();
            }
        }

        // add item
        private void addAttendee()
        {
            bool equal = false;
            //Create edit entry window for data population
            //  Pull data form form rather than passing through
            using (DataEntryForm data = new DataEntryForm())
            {
                if (data.ShowDialog(this) == DialogResult.OK)
                {

                    string name = data.LastName + ", " + data.FirstName;
                    string rsvp = data.RSVP;
                    string allergy = data.FoodAllergy;
                    string comment = data.Comments;


                    foreach (ListViewItem lvi in lvwAttendee.Items)
                    {
                        //if names are equal, do not add and break from search
                        if (name.Equals(lvi.SubItems[0].Text))
                        {
                            equal = true;
                            break;
                        }
                    }

                    if (!equal)
                    {
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

                        updateGuestCount();
                    }
                    else
                    {
                        MessageBox.Show(name + " already is listed as a guest", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //ListViewItem [0] = NAME
                    //ListViewItem [1] = RSVP
                    //ListViewItem [2] = GUEST_ID
                    //ListViewItem [3] = FOOD_ALLERGY
                    //ListViewItem [4] = COMMENTS
                    //ListViewItem newGuest = new ListViewItem(new string[] { name, rsvp, newRow["GUEST_ID"].ToString(), newRow["FOOD_ALLERGY"].ToString(), newRow["COMMENTS"].ToString() });
                    //newGuest.ImageIndex = 0;
                    //newGuest.Group = lvwAttendee.Groups[0];
                    //lvwAttendee.Items.Add(newGuest);
                }
            }

            CheckGuestCount();
        }

        private void updateGuestCount()
        {
            lblGuestCount.Text = lvwAttendee.Items.Count.ToString();
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
                //lvwAttendee.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwAttendee.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwAttendee.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                // lvwAttendee.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            lvwAttendee.Refresh();
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
                        //AttendeeDT.AcceptChanges();
                        if (updateRow[0]["RSVP"].ToString() != "Accept")
                        {
                            updateRow[0]["TABLE_ID"] = DBNull.Value;
                            updateRow[0]["SEAT_NUM"] = DBNull.Value;
                        }

                        lvi.Text = data.LastName + ", " + data.FirstName;
                        lvi.SubItems[1].Text = data.RSVP;
                        lvi.SubItems[2].Text = data.FoodAllergy;
                        lvi.SubItems[3].Text = data.Comments;

                        //LoadListView();
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
                updateGuestCount();
            }

            CheckGuestCount();
        }

        //import attendees from text file
        public void importAttendeesText()
        {
            string absolutePath = null;
            string line = null;
            string FirstName = "";
            string LastName = "";
            string FullName = "";

            MessageBox.Show("Import file must be of extension type *.txt. \n" +
                            "File format must consist of: \n    Last Name, First Name \nto be valid for import.", "Import File Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                            FirstName = name[1].ToString().Trim().ToUpper();
                            LastName = name[0].ToString().Trim().ToUpper();

                            FullName = LastName + ", " + FirstName;

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
                                //ListViewItem newGuest = new ListViewItem(new string[] { newRow["LAST_NAME"] + ", " + newRow["FIRST_NAME"], "Unknown", newRow["GUEST_ID"].ToString(), "N", "" });
                                //lvwAttendee.Items.Add(newGuest);

                            }
                        }

                        updateGuestCount();
                        if (AttendeeDT.Rows.Count == 100)
                        {
                            MessageBox.Show("You have reached your 100 guest limit.\nNo more names will be added." +
                                            "\nThe last name added was: " + FullName.ToString(), "Name Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            CheckGuestCount();
                            break;
                        }
                    }
                    //close open stream
                    filestream.Dispose();

                }
                catch (Exception e)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Error during Import.\n Message: " + e.ToString());
                }
            }
            openFileDialog.Dispose();
            Cursor.Current = Cursors.Default;
        }


        public void importAttendeesExcel()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            string absolutePath = null;
            string FirstName = "";
            string LastName = "";
            string FullName = "";

            MessageBox.Show("Excel file must have the following format:\n" +
                                "Column A, Row 1 value must = 'LASTNAME'\n" +
                                "Column B, Row 1 value must = 'FIRSTNAME'\n", "Import File Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //"Worksheet name must = 'Sheet1'", "Import File Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


            try
            {                
                //set options for open file menu
                openFileDialog.DefaultExt = "txt";
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"; 
                openFileDialog.FilterIndex = 1;
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;

                //if user selects file and hits confirms
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    absolutePath = openFileDialog.FileName;
                    Cursor.Current = Cursors.WaitCursor;

                    //Get Data From Excel File
                    OleDbConnection MyConnection;
                    DataSet DtSet;
                    OleDbDataAdapter MyCommand;
                    string extension = Path.GetExtension(absolutePath);
                    if (extension == ".xls")
                        MyConnection = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + absolutePath + "';Extended Properties=Excel 12.0;");
                    else
                        MyConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + absolutePath + "';Extended Properties=Excel 8.0;");


                    MyConnection.Open();

                    DataTable sheetTable = MyConnection.GetSchema("Tables");
                    string strSHeetName = Convert.ToString(sheetTable.Rows[0]["TABLE_NAME"]);

                    //MyCommand = new OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
                    MyCommand = new OleDbDataAdapter("select * from [" + strSHeetName + "]", MyConnection);
                    MyCommand.TableMappings.Add("Table", "Names");
                    DtSet = new DataSet();
                    MyCommand.Fill(DtSet);
                    DataTable NameTable = DtSet.Tables[0];
                    MyConnection.Close();

                    lvwAttendee.BeginUpdate();
                    for (int i = 0; i < NameTable.Rows.Count; i++)
                    {
                        DataRow dr = NameTable.Rows[i];
                        FirstName = dr["LASTNAME"].ToString().Trim().ToUpper();
                        LastName = dr["FIRSTNAME"].ToString().Trim().ToUpper();

                        FullName = LastName + ", " + FirstName;

                        bool equal = false;
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
                            //ListViewItem newGuest = new ListViewItem(new string[] { newRow["LAST_NAME"] + ", " + newRow["FIRST_NAME"], "Unknown", newRow["GUEST_ID"].ToString(), "N", "" });
                            //lvwAttendee.Items.Add(newGuest);

                        }

                        updateGuestCount();
                        lvwAttendee.Refresh();
                        if (AttendeeDT.Rows.Count == 100)
                        {
                            MessageBox.Show("You have reached your 100 guest limit.\nNo more names will be added." +
                                            "\nThe last name added was: " + FullName.ToString(), "Name Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            CheckGuestCount();
                            break;
                        }
                    }

                    lvwAttendee.EndUpdate();

                }
            }
            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error during Import.\n Message: " + e.ToString());
            }
            finally
            {
                openFileDialog.Dispose();
                Cursor.Current = Cursors.Default;
            }
        }


        // Check to see if Guest Count is at 100 (maximum). If so disable Add button, otherwise enable Add button. 
        private void CheckGuestCount()
        {
            if (AttendeeDT.Rows.Count == 100)
                btnAddAtendee.Enabled = false;
            else
                btnAddAtendee.Enabled = true;
        }

        #endregion Methods

    }
}
