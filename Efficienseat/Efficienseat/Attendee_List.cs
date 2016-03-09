using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Efficienseat
{
    public partial class Attendee_List : Form
    {
        public DataTable AttendeeDT;
        public DataTable TableDT;
        int wedID;

        public Attendee_List()
        {
            InitializeComponent();
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

            // Hide close button
            this.ControlBox = false;
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
                lvwAttendee.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwAttendee.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwAttendee.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwAttendee.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize);
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
                        //iterate through listviewitems to compare with current line from txt file
                        //  sloppy as it iterates through the entire listview for each line item
                        //  --Potentially faster to check txt file for duplicates first and then only
                        //      check existing listviewitems for equality?
                        foreach (ListViewItem lvi in lvwAttendee.Items)
                        {
                            //if names are equal, do not add and break from search
                            if (line.Equals(lvi.SubItems[0].Text))
                            {
                                equal = true;
                                break;
                            }
                        }
                        //if name does not already exist, add item to ListView
                        if (!equal)
                        {
                            name = line.Split(delimiter);

                            DataRow newRow = AttendeeDT.NewRow();
                            newRow["FIRST_NAME"] = name[1].ToString().Trim();
                            newRow["LAST_NAME"] = name[0].ToString().Trim();
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
                            ListViewItem newGuest = new ListViewItem(new string[] { name[1] + ", " + name[0], "Unknown", newRow["GUEST_ID"].ToString(), "", "" });
                            lvwAttendee.Items.Add(newGuest);
                        }
                    }
                    //close open stream
                    filestream.Dispose();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: could not open file.\n Message: " + e.ToString());
                }
            }
            openFileDialog.Dispose();
        }

        #endregion Methods

        private void lvwAttendee_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
           // System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            //messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item);
            //messageBoxCS.AppendLine();
            
        }
    }
}
