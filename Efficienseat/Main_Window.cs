using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace Efficienseat
{
    public partial class Main_Window : Form
    {
        //global variables for MainWindow
        Attendee_List al;
        TableAssignments ta;
        DataTable AttendeeDT;
        DataTable TableDT;
        DataTable wedDT;
        SQLiteConnection DBConnection;
        SQLiteDataAdapter sdaAttendee;
        SQLiteDataAdapter sdaTable;
        SQLiteDataAdapter wedAdapter;
        SQLiteCommandBuilder cmdBuilder;
        int wed_id;

        private int loadedWedID = 0;

        #region Main Window events

        //  Constructor
        public Main_Window()
        {
            InitializeComponent();
        }

        //<summary>
        //  Event handler for the main window load
        //  -open DB and populate data via LoadForm
        //</summary>
        private void Main_Window_Shown(object sender, EventArgs e)
        {
            OpenDatabase();
            GetWeddingParty();
        }

        //<summary>
        //  Event handler for the main window closing
        //  -close local database connection
        //</summary>
        private void Main_Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Close DBConnection here
            DBConnection.Close();
        }

        //<summary>
        //  Event handler for resizing the main window
        //</summary>
        private void Main_Window_Resize(object sender, EventArgs e)
        {
            // Get the client rectangle for the MDI workspace
            MdiClient client = null;
            foreach (Control c in this.Controls)
            {
                client = c as MdiClient;
                if (client != null)
                {
                    break;
                }
            }

            //resize child windows on parent change
            if(al != null)
                al.Height = client.Height - 5;
            if(ta != null)
                ta.Height = client.Height - 5;
        }

        #endregion Main Window events

        #region Methods

        //<summary>
        //  Open database connection to local DB
        //</summary>
        private void OpenDatabase()
        {
            try
            {
                DBConnection = new SQLiteConnection(@"Data Source=|DataDirectory|\Efficienseat.sqlite;Version=3;");
                DBConnection.Open();
            }
            catch (SQLiteException Error)
            {
                MessageBox.Show("Error opening SQLite DB.\n" + Error.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //<summary>
        //  Instantiates LoadForm to open a wedding and populate main with the active data
        //</summary>
        private void GetWeddingParty()
        {
            //open data table and populate with weddings from the DB
            string weddingQuery = "SELECT * FROM WED_PARTY ORDER BY WED_ID";
            SQLiteCommand command = new SQLiteCommand(weddingQuery, DBConnection);
            wedDT = new DataTable();
            wedAdapter = new SQLiteDataAdapter(command);
            wedAdapter.Fill(wedDT);

            //handlers for row/data changes
            wedDT.RowDeleted += Party_Row_Deleted;
            wedDT.RowChanged += Party_Row_Changed;

            //instantiate load form and set data table
            LoadForm lf = new LoadForm();
            lf.wedDT = wedDT;

            //on LoadForm event OK
            if (lf.ShowDialog(this) == DialogResult.OK)
            {
                foreach (Form frm in this.MdiChildren)
                {
                    frm.Close();
                }

                //load AttendeeList window 
                loadAttendeeList();

                //set active wedding ID and populate data table
                wed_id = lf.WedID;
                GetData(lf.WedID);
                loadedWedID = lf.WedID;
                al.Show();
            }
        }

        //<summary>
        //  Populate data tables using the active wedding ID
        //</summary>
        private void GetData(int weddingNumber)
        {
            //query and populate attendee data table
            string attendeeSQL = "SELECT * FROM WED_GUEST WHERE WED_ID = " + weddingNumber + " ORDER BY LAST_NAME, FIRST_NAME";
            SQLiteCommand command = new SQLiteCommand(attendeeSQL, DBConnection);
            sdaAttendee = new SQLiteDataAdapter(command);
            AttendeeDT = new DataTable();
            sdaAttendee.Fill(AttendeeDT);

            //handlers for data change events
            AttendeeDT.RowDeleted += Row_Deleted;
            AttendeeDT.RowChanged += Row_Changed;

            //query and populate table data table
            string tableSQL = "SELECT * FROM WED_TABLES WHERE WED_ID = " + weddingNumber;
            SQLiteCommand tableCommand = new SQLiteCommand(tableSQL, DBConnection);
            sdaTable = new SQLiteDataAdapter(tableCommand);
            TableDT = new DataTable();
            sdaTable.Fill(TableDT);

            //handlers for data change events
            TableDT.RowDeleted += Table_Row_Deleted;
            TableDT.RowChanged += Table_Row_Changed;

            //set attendee list data tables and active ID
            al.AttendeeDT = AttendeeDT;
            al.TableDT = TableDT;
            al.WedID = weddingNumber;
            al.LoadTableNames();
            al.LoadListView();
        }

        //<summary>
        //  Loads the AttendeeList window into main
        //</summary>
        private void loadAttendeeList()
        {
            // Get the client rectangle for the MDI workspace
            MdiClient client = null;
            foreach (Control c in this.Controls)
            {
                client = c as MdiClient;
                if (client != null)
                {
                    break;
                }
            }

            al = new Attendee_List();

            //sets the database connection to the active DBConnection
            al.DBConnection = this.DBConnection;

            //sets parent window to main
            al.MdiParent = this;

            //set window position
            al.Size = new Size(508, client.Height - 5);
            al.StartPosition = FormStartPosition.Manual;
            al.Location = new Point(0, 0);
        }

        //<summary>
        //  Edit the wedding party name via EditWedding form
        //</summary>
        private void editWeddingInfo()
        {
            //instantiate form
            using (EditWedding ew = new EditWedding())
            {
                //pull name for active wedding from database
                string query = "SELECT WED_PARTY_NAME FROM WED_PARTY WHERE WED_ID = " + loadedWedID;
                SQLiteCommand command = new SQLiteCommand(query, DBConnection);
                string description = command.ExecuteScalar().ToString();

                //list for month parse
                string[] month = { "JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER" };
                int monthPos = -1;

                //iterate through month values
                for (int i = 0; i < 12; i++)
                {
                    //on find of month, save position and break
                    monthPos = description.IndexOf(month[i]);
                    if (monthPos != -1)
                        break;
                }

                if (monthPos != -1)
                {
                    //parse substring of month and year from wedding name
                    string monthCB = description.Substring(monthPos);
                    int yearPos = monthCB.IndexOf("-") + 1;
                    string yearCB = monthCB.Substring(yearPos);

                    //trim month and year from wedding name
                    description = description.Substring(0, monthPos - 1);

                    //trim year from month
                    monthCB = monthCB.Substring(0, (yearPos - 1));

                    //set name field to wedding name
                    ew.WeddingName = description;

                    //set combo boxes for month and year to parsed data
                    ew.WeddingMonth = monthCB;
                    ew.WeddingYear = yearCB;
                }
                else
                {
                    ew.WeddingName = description;

                    //set combo boxes to month and year to default values
                    ew.WeddingMonth = "JANUARY";
                    ew.WeddingYear = "2017";
                }

                //on EditWedding closure
                if (ew.ShowDialog(this) == DialogResult.OK)
                {
                    //push updated wedding name to database
                    SQLiteCommand cmd = new SQLiteCommand("UPDATE WED_PARTY SET WED_PARTY_NAME = @wedPartyName WHERE WED_ID = @loadedID", DBConnection);

                    //concatenate data back to single string
                    string wedPartyName = ew.WeddingName + " " + ew.WeddingMonth + "-" + ew.WeddingYear;

                    //pass data into query with parameters to prevent injection
                    cmd.Parameters.AddWithValue("@wedPartyName", wedPartyName);
                    cmd.Parameters.AddWithValue("@loadedID", loadedWedID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion Methods

        #region DB Events

        //<summary>
        //  
        //</summary>
        private void Party_Row_Deleted(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                cmdBuilder = new SQLiteCommandBuilder(wedAdapter);
                wedAdapter.Update(wedDT);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //<summary>
        //
        //</summary>
        private void Party_Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                cmdBuilder = new SQLiteCommandBuilder(wedAdapter);
                wedAdapter.Update(wedDT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //<summary>
        //  
        //</summary>
        private void Row_Deleted(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                cmdBuilder = new SQLiteCommandBuilder(sdaAttendee);
                sdaAttendee.Update(AttendeeDT);
                al.LoadListView();
                if (ta != null && ta.Visible)
                    ta.loadListView();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //<summary>
        //
        //</summary>
        private void Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                cmdBuilder = new SQLiteCommandBuilder(sdaAttendee);
                sdaAttendee.Update(AttendeeDT);
                al.LoadListView();
                if (ta != null && ta.Visible)
                    ta.loadListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //<summary>
        //
        //</summary>
        private void Table_Row_Deleted(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                cmdBuilder = new SQLiteCommandBuilder(sdaTable);
                sdaTable.Update(TableDT);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //<summary>
        //
        //</summary>
        private void Table_Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                cmdBuilder = new SQLiteCommandBuilder(sdaTable);
                sdaTable.Update(TableDT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion DB Events

        #region Tool Strip Event Handlers

        //<summary>
        //  Event handler for the show table editor action from the tool strip
        //</summary>
        private void showTableEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Attendee_List al = (Attendee_List)this.MdiChildren[0];

            //instantiate table editor and set position
            ta = new TableAssignments();
            ta.MdiParent = this;
            ta.StartPosition = FormStartPosition.Manual;
            ta.Location = new Point(al.Location.X + al.Width + 5,
                                    al.Location.Y);

            //set data tables for TableAssignments
            ta.AttendeeDT = AttendeeDT;
            ta.TableDT = TableDT;

            //set active weddingID and load attendees into the window
            ta.loadListView();
            ta.WeddingID = loadedWedID;

            ta.Show();
        }

        //<summary>
        //  Event handler for the edit wedding action from the tool strip
        //</summary>
        private void editWeddingInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editWeddingInfo();
        }

        //<summary>
        //  Event handler for the exit action from the tool strip
        //</summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        //<summary>
        //  Event handler for the New/Load action from the tool strip
        //</summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetWeddingParty();
        }

        //<summary>
        //  Event handler for the report action from the tool strip
        //</summary>
        private void guestPerTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm(wed_id);
            rf.Show();
        }

        //<summary>
        //  Event handler for the import text function from the tool strip
        //</summary>
        private void textFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendee_List al = (Attendee_List)this.MdiChildren[0];
            al.importAttendeesText();
        }

        //<summary>
        //  Event handler for the import excel function from the tool strip
        //</summary>
        private void excelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendee_List al = (Attendee_List)this.MdiChildren[0];
            al.importAttendeesExcel();
        }

        #endregion Tool Strip Event Handlers

    }
}
