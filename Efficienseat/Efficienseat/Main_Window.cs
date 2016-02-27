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
        SQLiteConnection DBConnection;
        SQLiteDataAdapter sda;
        SQLiteCommandBuilder cmdBuilder;
        private int loadedWedID = 0;

        public Main_Window()
        {
            InitializeComponent();
        }

        private void Play_With_MDI_Load(object sender, EventArgs e)
        {
            al = new Attendee_List();
            al.MdiParent = this;
            al.StartPosition = FormStartPosition.Manual;
            al.Location = new Point(0, 0);
            al.Show();

            OpenDatabase();
            GetData(54321);
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
            ta.LoadListView();
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

        private void GetData(int weddingNumber)
        {
            string attendeeSQL = "SELECT * FROM WED_GUEST WHERE WED_ID = " + weddingNumber;
            SQLiteCommand command = new SQLiteCommand(attendeeSQL, DBConnection);
            sda = new SQLiteDataAdapter(command);
            AttendeeDT = new DataTable();
            sda.Fill(AttendeeDT);

            AttendeeDT.RowDeleted += Row_Deleted;
            AttendeeDT.RowChanged += Row_Changed;

            string tableSQL = "SELECT * FROM WED_TABLES WHERE WED_ID = " + weddingNumber;
            SQLiteCommand tableCommand = new SQLiteCommand(tableSQL, DBConnection);
            sda = new SQLiteDataAdapter(tableCommand);
            TableDT = new DataTable();
            sda.Fill(TableDT);

            TableDT.RowDeleted += Table_Row_Deleted;
            TableDT.RowChanged += Table_Row_Changed;

            al.AttendeeDT = AttendeeDT;
            al.LoadListView();

            loadedWedID = weddingNumber;
        }
        #endregion

        #region Events

        private void Row_Deleted(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                cmdBuilder = new SQLiteCommandBuilder(sda);
                sda.Update(AttendeeDT);
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
                cmdBuilder = new SQLiteCommandBuilder(sda);
                sda.Update(AttendeeDT);
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
                cmdBuilder = new SQLiteCommandBuilder(sda);
                sda.Update(TableDT);
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
                cmdBuilder = new SQLiteCommandBuilder(sda);
                sda.Update(TableDT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        #endregion
    }
}
