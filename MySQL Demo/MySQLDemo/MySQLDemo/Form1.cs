using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySQLDemo
{
    public partial class Form1 : Form
    {
        MySQLConnection DB;
        //MySqlConnection conn;
        MySqlDataAdapter myDA;
        MySqlCommandBuilder cmb;
        DataTable myDT;
        DataTable myWedDT;
        string wed_id;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DB = new MySQLConnection();
            string sQuery = "SELECT * FROM WED_PARTY";
            MySqlDataAdapter wedDA = new MySqlDataAdapter(sQuery, DB.Connection);
            MySqlCommandBuilder wedCMB = new MySqlCommandBuilder(wedDA);
            myWedDT = new DataTable();
            wedDA.Fill(myWedDT);
            cbWeddingParty.DataSource = myWedDT;

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            wed_id = cbWeddingParty.SelectedValue.ToString();
            string sQuery = "SELECT * FROM WED_GUEST WHERE WED_ID = " + wed_id;

            /* if not using the class I created (MySQLConnection), this is how to make a MySqlConnection with
               a connection string */
            //conn = new MySqlConnection(DB.ConnectionString);
            myDA = new MySqlDataAdapter(sQuery, DB.Connection);
            cmb = new MySqlCommandBuilder(myDA);

            myDT = new DataTable();
            myDA.Fill(myDT);

            dgvGuests.DataSource = myDT;

            txtFirstName.Text = myDT.Rows[0]["FIRST_NAME"].ToString();
            txtLastName.Text = myDT.Rows[0]["LAST_NAME"].ToString();
            txtRSVP.Text = myDT.Rows[0]["RSVP"].ToString();
            txtComments.Text = myDT.Rows[0]["COMMENTS"].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            myDT.Rows[0]["FIRST_NAME"] = txtFirstName.Text;
            myDT.Rows[0]["LAST_NAME"] = txtLastName.Text;
            myDT.Rows[0]["RSVP"] = txtRSVP.Text;
            myDT.Rows[0]["COMMENTS"] = txtComments.Text;

            myDA.Update(myDT);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtRSVP.Clear();
            txtComments.Clear();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DataRow newRow = myDT.NewRow();
            newRow["FIRST_NAME"] = txtFirstName.Text;
            newRow["LAST_NAME"] = txtLastName.Text;
            newRow["RSVP"] = txtRSVP.Text;
            newRow["COMMENTS"] = txtComments.Text;
            newRow["WED_ID"] = 12345;
            myDT.Rows.Add(newRow);
            myDA.Update(myDT);

        }
    }
}
