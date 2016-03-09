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

namespace Efficienseat
{
    public partial class Main_Window : Form
    {
        Attendee_List al;
        DataTable AttendeeDT;
        DataTable TableDT;
        DataTable wedDT;
        SQLiteConnection DBConnection;
        SQLiteDataAdapter sdaAttendee;
        SQLiteDataAdapter sdaTable;
        SQLiteDataAdapter wedAdapter;
        SQLiteCommandBuilder cmdBuilder;

        private int loadedWedID = 0;

        public Main_Window()
        {
            InitializeComponent();
        }

        private void Play_With_MDI_Load(object sender, EventArgs e)
        {
            loadAttendeeList();
        }


        private void loadAttendeeList()
        {
            al = new Attendee_List();
            al.MdiParent = this;
            al.StartPosition = FormStartPosition.Manual;
            al.Location = new Point(0, 0);
            al.Show();
            
        }

        private void showTableEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendee_List al = (Attendee_List) this.MdiChildren[0];

            TableAssignments ta = new TableAssignments();
            ta.MdiParent = this;
            ta.StartPosition = FormStartPosition.Manual;
            ta.Location = new Point(al.Location.X + al.Width + 5,
                                    al.Location.Y);

            ta.AttendeeDT = AttendeeDT;
            ta.TableDT = TableDT;
            ta.loadListView();
            ta.WeddingID = loadedWedID;

            ta.Show();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendee_List al = (Attendee_List) this.MdiChildren[0];
            al.importAttendees();
        }

        #region Methods

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

        private void GetWeddingParty()
        {
            string weddingQuery = "SELECT * FROM WED_PARTY ORDER BY WED_ID";
            SQLiteCommand command = new SQLiteCommand(weddingQuery, DBConnection);
            wedDT = new DataTable();
            wedAdapter = new SQLiteDataAdapter(command);
            wedAdapter.Fill(wedDT);

            wedDT.RowDeleted += Party_Row_Deleted;
            wedDT.RowChanged += Party_Row_Changed;

            LoadForm lf = new LoadForm();
            lf.wedDT = wedDT;
            if (lf.ShowDialog(this) == DialogResult.OK)
            {
                GetData(lf.WedID);
                loadedWedID = lf.WedID;
            }

        }

        private void GetData(int weddingNumber)
        {
            string attendeeSQL = "SELECT * FROM WED_GUEST WHERE WED_ID = " + weddingNumber + " ORDER BY LAST_NAME, FIRST_NAME";
            SQLiteCommand command = new SQLiteCommand(attendeeSQL, DBConnection);
            sdaAttendee = new SQLiteDataAdapter(command);
            AttendeeDT = new DataTable();
            sdaAttendee.Fill(AttendeeDT);

            AttendeeDT.RowDeleted += Row_Deleted;
            AttendeeDT.RowChanged += Row_Changed;

            string tableSQL = "SELECT * FROM WED_TABLES WHERE WED_ID = " + weddingNumber;
            SQLiteCommand tableCommand = new SQLiteCommand(tableSQL, DBConnection);
            sdaTable = new SQLiteDataAdapter(tableCommand);
            TableDT = new DataTable();
            sdaTable.Fill(TableDT);

            TableDT.RowDeleted += Table_Row_Deleted;
            TableDT.RowChanged += Table_Row_Changed;

            al.AttendeeDT = AttendeeDT;
            al.TableDT = TableDT;
            al.WedID = weddingNumber;
            al.LoadTableNames();
            al.LoadListView();
        }
        
        #endregion Methods

        #region Events

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

        private void Row_Deleted(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                cmdBuilder = new SQLiteCommandBuilder(sdaAttendee);
                sdaAttendee.Update(AttendeeDT);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                cmdBuilder = new SQLiteCommandBuilder(sdaAttendee);
                sdaAttendee.Update(AttendeeDT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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

        #endregion Events

        private void Main_Window_Shown(object sender, EventArgs e)
        {
            OpenDatabase();
            GetWeddingParty();
        }
    }
}
