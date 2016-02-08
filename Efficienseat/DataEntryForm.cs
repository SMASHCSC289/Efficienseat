using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Efficienseat
{
    public partial class DataEntryForm : Form
    {
        public DataEntryForm()
        {
            InitializeComponent();
        }

        public DataEntryForm(string firstName, string lastName, string address1, string address2, string city, string state, string zip, string RSVP)
        {
            //parse first from last: first->textBox1 , last->textBox2

            //parse address: street->textBox3, second line->textBox4, city->textBox5, state->comboBox1, zip->textBox6

            //RSVP->comboBox2
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //button for save data
            //  Simple close as data is pulled via AttendeeList
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //button for cancel
            //  Sure there is an easier way to do this, wipe data fields and close window
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            Close();
        }

        public string getFirstName
        {
            get { return textBox1.Text; }
        }

        public string getLastName
        {
            get { return textBox2.Text; }
        }

        public string getAddress1
        {
            get {  return textBox3.Text; }
        }

        public string getAddress2
        {
            get { return textBox4.Text; }
        }

        public string getCity
        {
            get { return textBox5.Text; }
        }

        public string getState
        {
            get { return comboBox1.Text; }
        }

        public string getZIP
        {
            get { return textBox6.Text; }
        }

        public string getRSVP
        {
            //check for data, ensure validity
            //  Some way to lock comboBox to prevent manual entry?
            get { return comboBox2.Text; }
        }

    }
}
