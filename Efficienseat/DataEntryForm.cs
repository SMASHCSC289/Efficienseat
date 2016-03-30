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

        #region Properties
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

        #endregion


        #region Events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //button for cancel
            //  Sure there is an easier way to do this, wipe data fields and close window
            txtFirstName.Text = "";
            txtLastName.Text = "";
            cbFoodAllergy.Text = "";
            cbRSVP.Text = "";
            txtComments.Text = "";
            btnSave.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check if all required data is present. If not then cancel form close in FormClosing Event 
            ValidData();
        }

        private void DataEntryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSave.DialogResult != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        #endregion


        #region Methods

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
