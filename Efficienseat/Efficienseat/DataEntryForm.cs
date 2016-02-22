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

        public string FirstName
        {
            get { return txtFirstName.Text; }

            set { txtFirstName.Text = value; }
        }

        public string LastName
        {
            get { return txtLastName.Text; }

            set { txtLastName.Text = value; }
        }

        public string RSVP
        {
            get { return cbRSVP.Text; }

            set { cbRSVP.Text = value; }
        }

        public string FoodAllergy
        {
            get { return cbFoodAllergy.Text; }

            set { cbFoodAllergy.Text = value; }
        }

        public string Comments
        {
            get { return txtComments.Text; }

            set { txtComments.Text = value; }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            //button for cancel
            //  Sure there is an easier way to do this, wipe data fields and close window
            txtFirstName.Text = "";
            txtLastName.Text = "";
            cbFoodAllergy.Text = "";
            cbRSVP.Text = "";
            txtComments.Text = "";
            Close();
        }
    }
}
