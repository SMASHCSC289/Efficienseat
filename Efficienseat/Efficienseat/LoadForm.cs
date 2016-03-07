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
    public partial class LoadForm : Form
    {
        public char selection = 'Q';
        public int weddingID = 1;
        SQLiteConnection connection;
        Main_Window pmdi;
        DataTable wedDT;
        SQLiteDataAdapter wedAdapter;

        public LoadForm()
        {
            InitializeComponent();
        }

        private void LoadForm_Load(object sender, EventArgs e)
        {
            OpenDatabase();
           GetData();
        }


        private void CreateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            WeddingComboBox.Enabled = false;
            selection = 'C';
        }

        private void LoadRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(WeddingComboBox.Items.Count != 0)
            {
                WeddingComboBox.Enabled = true;
                selection = 'L';
            }
            else if(LoadRadioButton.Checked == true)
            {
                MessageBox.Show("No existing weddings found, please select Create or Import");
                LoadRadioButton.Checked = false;
            }
            

        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            //Here -> if creating new wedding, set weddingID to the current max WED_ID + 1

            if (selection == 'C')
            {
                EditWeddingForm editWedding = new EditWeddingForm();
                editWedding.ShowDialog();

                string description = editWedding.WeddingName + " " + editWedding.WeddingDate;

                editWedding.Dispose();

                string getMax = "SELECT MAX(WED_ID) FROM WED_PARTY";
                SQLiteCommand stmt = new SQLiteCommand(getMax, connection);
                
                weddingID = Convert.ToInt32(stmt.ExecuteScalar()) + 1;

                string createNewSQL = "INSERT INTO WED_PARTY (WED_ID, WED_PARTY_NAME) VALUES (" + weddingID + ", '" + description + "')";
                stmt = new SQLiteCommand(createNewSQL, connection);
                stmt.ExecuteScalar();
            }


            pmdi = new Main_Window(connection, weddingID, selection);
            pmdi.Show();
            connection.Close();
            this.Close();
        }

        private void WeddingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(WeddingComboBox.SelectedValue != null)
            {
                Int32.TryParse(WeddingComboBox.SelectedValue.ToString(), out weddingID);
            }

        }

        private void OpenDatabase()
        {
            try
            {
                connection = new SQLiteConnection(@"Data Source=|DataDirectory|\Efficienseat.sqlite;Version=3;");
                connection.Open();
            }
            catch (SQLiteException Error)
            {
                MessageBox.Show("Error opening SQLite DB.\n" + Error.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetData()
        {
            string weddingQuery = "SELECT * FROM WED_PARTY ORDER BY WED_ID";
            SQLiteCommand command = new SQLiteCommand(weddingQuery, connection);
            wedDT = new DataTable();
            wedAdapter = new SQLiteDataAdapter(command);
            wedAdapter.Fill(wedDT);
            WeddingComboBox.DataSource = wedDT;
            WeddingComboBox.DisplayMember = "WED_PARTY_NAME";
            WeddingComboBox.ValueMember = "WED_ID";
        }
    }
}
