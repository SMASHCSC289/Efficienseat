﻿using System;
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
        SQLiteDataAdapter sdaAttendee;
        SQLiteDataAdapter sdaTable;
        SQLiteCommandBuilder cmdBuilder;
        private int loadedWedID = 0;
        private char selection;

        public Main_Window(SQLiteConnection c, int w, char s)
        {
            InitializeComponent();
            loadedWedID = w;
            selection = s;
            DBConnection = c;
        }

        private void Play_With_MDI_Load(object sender, EventArgs e)
        {

            loadAttendeeList();

        }

        private void LoadLoadForm()
        {   
            
           
        }

        private void loadAttendeeList()
        {
            al = new Attendee_List();
            al.MdiParent = this;
            al.StartPosition = FormStartPosition.Manual;
            al.Location = new Point(0, 0);
            if (selection == 'C')
            {
                
            }
            else if (selection == 'L')
            {
                GetData(loadedWedID);
            }

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
            al.LoadTableNames();
            al.LoadListView();

            loadedWedID = weddingNumber;
        }
        #endregion

        #region Events

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
        
        #endregion
    }
}
