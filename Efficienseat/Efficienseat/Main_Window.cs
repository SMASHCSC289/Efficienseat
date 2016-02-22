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
        DataTable DT;
        SQLiteConnection DBConnection;
        SQLiteDataAdapter sda;
        SQLiteCommandBuilder cmdBuilder;


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
            //al.Height = this.ClientSize.Height - (al.Height - al.ClientSize.Height);

            al.Show();

            //TableAssignments ta = new TableAssignments();
            //ta.MdiParent = this;
            //ta.StartPosition = FormStartPosition.Manual;
            //ta.Location = new Point(al.Location.X + al.Width + 5,
            //                        al.Location.Y);

            //ta.Show();

            OpenDatabase();
            GetData();
        }

        private void showTableEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendee_List al = (Attendee_List) this.MdiChildren[0];

            TableAssignments ta = new TableAssignments();
            ta.MdiParent = this;
            ta.StartPosition = FormStartPosition.Manual;
            ta.Location = new Point(al.Location.X + al.Width + 5,
                                    al.Location.Y);

            ta.AttendeeDT = DT;
            ta.LoadListView();

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
                DBConnection = new SQLiteConnection("Data Source=D:\\Mark\\School\\CSC 289\\SQLite DB\\Efficienseat.sqlite;Version=3;");
                DBConnection.Open();
            }
            catch (SQLiteException Error)
            {
                MessageBox.Show("Error opening SQLite DB.\n" + Error.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetData()
        {
            string sql = "SELECT * FROM WED_GUEST WHERE WED_ID = 54321";
            SQLiteCommand command = new SQLiteCommand(sql, DBConnection);
            sda = new SQLiteDataAdapter(command);
            DT = new DataTable();
            sda.Fill(DT);

            DT.RowDeleted += Row_Deleted;
            DT.RowChanged += Row_Changed;

            al.AttendeeDT = DT;
            al.LoadListView();
        }
        #endregion

        #region Events

        private void Row_Deleted(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                cmdBuilder = new SQLiteCommandBuilder(sda);
                sda.Update(DT);
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
                sda.Update(DT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
