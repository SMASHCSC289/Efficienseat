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
    public partial class EditWedding : Form
    {
        //  constructor
        public EditWedding()
        {
            InitializeComponent();
        }

        #region Event handler

        //<summary>
        //  Event handler for Ok button click
        //</summary>
        private void button1_Click(object sender, EventArgs e)
        {
            //check fields for data, if empty pop error and refocus appropriate field
            if (weddingNameTextBox.Text.ToString() == "")
            {
                MessageBox.Show("Please enter a Wedding Party Name", "Warning", MessageBoxButtons.OK);
                weddingNameTextBox.Focus();
            }
            else if (weddingMonthComboBox.Text.ToString() == "")
            {
                MessageBox.Show("Please choose the Wedding Month", "Warning", MessageBoxButtons.OK);
                weddingMonthComboBox.Focus();
            }
            else if (weddingYearComboBox.Text.ToString() == "")
            {
                MessageBox.Show("Please choose the Wedding Year", "Warning", MessageBoxButtons.OK);
                weddingYearComboBox.Focus();
            }
            //if valid, close window
            else
            {
                this.Close();
            }
        }

        #endregion Event handler

        #region Accessors

        //<summary>
        //  Accessor for wedding name
        //</summary>
        public string WeddingName
        {
            get
            {
                return weddingNameTextBox.Text;
            }
            set
            {
                weddingNameTextBox.Text = value;
            }
        }

        //<summary>
        //  Accessor for wedding month
        //</summary>
        public string WeddingMonth
        {
            get
            {
                return weddingMonthComboBox.Text;
            }
            set
            {
                weddingMonthComboBox.Text = value;
            }
        }

        //<summary>
        //  Accessor for wedding year
        //</summary>
        public string WeddingYear
        {
            get
            {
                return weddingYearComboBox.Text;
            }
            set
            {
                weddingYearComboBox.Text = value;
            }
        }

        #endregion Accessors
    }
}