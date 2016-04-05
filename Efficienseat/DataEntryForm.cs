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
            if (btnSave.DialogResult != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Methods

        //<summary>
        //  Validate data fields
        //</summary>
        private void ValidData()
        {
            btnSave.DialogResult = DialogResult.OK;

            if (txtFirstName.Text.ToString() == "")
            {
                MessageBox.Show("First Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                btnSave.DialogResult = DialogResult.No;
            }
            else if (txtLastName.Text.ToString() == "")
            {
                MessageBox.Show("Last Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                btnSave.DialogResult = DialogResult.No;
            }
            else if (cbFoodAllergy.Text.ToString() == "")
            {
                MessageBox.Show("Please choose a Food Allergy option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbFoodAllergy.Focus();
                btnSave.DialogResult = DialogResult.No;
            }
            else if (cbRSVP.Text.ToString() == "")
            {
                MessageBox.Show("Please choose a RSVP option.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbRSVP.Focus();
                btnSave.DialogResult = DialogResult.No;
            }
        }


        #endregion
    }
}
