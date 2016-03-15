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
        TableAssignments ta;
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
            
        }

        private void loadAttendeeList()
        {
            al = new Attendee_List();
            al.MdiParent = this;
            al.StartPosition = FormStartPosition.Manual;
            al.Location = new Point(0, 0);            
        }

        private void showTableEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendee_List al = (Attendee_List) this.MdiChildren[0];

            ta = new TableAssignments();
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
                loadAttendeeList();
                GetData(lf.WedID);
                loadedWedID = lf.WedID;
                al.Show();
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

        private void editWeddingInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editWeddingInfo();
        }

        private void editWeddingInfo()
        {
            using (EditWedding ew = new EditWedding())
            {
                //pull data from database
                string query = "SELECT WED_PARTY_NAME FROM WED_PARTY WHERE WED_ID = " + loadedWedID;
                SQLiteCommand command = new SQLiteCommand(query, DBConnection);
                string description = command.ExecuteScalar().ToString();


                //parse name, month and year then assign
                string[] month = { "JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER" };
                int monthPos = -1;
                for(int i = 0; i < 12; i++)
                {
                    monthPos = description.IndexOf(month[i]);
                    if (monthPos != -1)
                        break;
                }

                string monthCB = description.Substring(monthPos); 
                int yearPos = monthCB.IndexOf("-") + 1;
                string yearCB = monthCB.Substring(yearPos);

                description = description.Substring(0, monthPos - 1);

                MessageBox.Show(monthPos.ToString() + " " + yearPos.ToString(), "Error", MessageBoxButtons.OK);
                monthCB = monthCB.Substring(0, (yearPos - 1));


                ew.WeddingName = description;

                //SelectedIndex = ComboBox.FindStringExact(month/year/etc)
                ew.WeddingMonth = monthCB;
                ew.WeddingYear = yearCB;

                if(ew.ShowDialog(this) == DialogResult.OK)
                {
                    //push update here
                    string wedPartyName = ew.WeddingName + " " + ew.WeddingMonth + "-" + ew.WeddingYear;
                    query = "UPDATE WED_PARTY SET WED_PARTY_NAME = '" + wedPartyName + "' WHERE WED_ID = " + loadedWedID;
                    command = new SQLiteCommand(query, DBConnection);
                    command.ExecuteScalar();
                }
            }
        }

        private void Main_Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Close DBConnection here
            DBConnection.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            al.Close();
            if (ta != null)
                ta.Close();
            GetWeddingParty();
        }
    }
}
