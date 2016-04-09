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
        bool result;

        //  Constructor
        public DataEntryForm()
        {
            InitializeComponent();
        }

        #region Properties

        //<summary>
        //  Accessor for first name
        //</summary>
        public string FirstName
        {
            get { return txtFirstName.Text; }

            set { txtFirstName.Text = value; }
        }

        //<summary>
        //  Accessor for last name
        //</summary>
        public string LastName
        {
            get { return txtLastName.Text; }

            set { txtLastName.Text = value; }
        }

        //<summary>
        //  Accessor for RSVP
        //</summary>
        public string RSVP
        {
            get { return cbRSVP.Text; }

            set { cbRSVP.Text = value; }
        }

        //<summary>
        //  Accessor for food allergy
        //</summary>
        public string FoodAllergy
        {
            get { return cbFoodAllergy.Text; }

            set { cbFoodAllergy.Text = value; }
        }

        //<summary>
        //  Accessor for comments
        //</summary>
        public string Comments
        {
            get { return txtComments.Text; }

            set { txtComments.Text = value; }
        }

        #endregion

        #region Events

        //<summary>
        //  Event handler for cancel button click
        //</summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            result = true;
            Close();
        }

        //<summary>
        //  Event Handler for save button click
        //</summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check if all required data is present. If not then cancel form close in FormClosing Event 
            ValidData();
        }

        //<summary>
        //  Event handler for form closure
        //</summary>
        private void DataEntryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!result)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        #endregion

        #region Methods

        //<summary>
        //  Validate data fields
        //</summary>
        private void ValidData()
        {
            result = true;

            if (txtFirstName.Text.ToString() == "")
            {
                MessageBox.Show("First Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                result = false;
            }
            else if (txtLastName.Text.ToString() == "")
            {
                MessageBox.Show("Last Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                result = false;
            }
            else if (cbFoodAllergy.Text.ToString() == "")
            {
                MessageBox.Show("Please choose a Food Allergy option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbFoodAllergy.Focus();
                result = false;
            }
            else if (cbRSVP.Text.ToString() == "")
            {
                MessageBox.Show("Please choose a RSVP option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbRSVP.Focus();
                result = false;
            }
        }


        #endregion
    }
}
