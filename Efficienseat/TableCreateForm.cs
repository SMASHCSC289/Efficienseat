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
    public partial class TableCreateForm : Form
    {
        //private
        private string tableName = null;
        private string tableShape = null;
        private int numSeats = 0;
        private DialogResult formDR;  

        //public
        public List<string> tableNames;

        #region Properties
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        public string Shape
        {
            get { return tableShape; }
            set { tableShape = value; }
        }

        public int NumberOfSeats
        {
            get { return numSeats; }
            set { numSeats = value; }
        }

        public TableCreateForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void TableCreateForm_Load(object sender, EventArgs e)
        {
            formDR = DialogResult.None;
        }

        private void cbxTableShape_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Shape = cbxTableShape.Text;
            //Refresh();
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            Name = txtName.Text;
        }

        private void nudNumSeats_ValueChanged(object sender, EventArgs e)
        {
            NumberOfSeats = (int) nudNumSeats.Value;
        }

        private void TableCreateForm_Shown(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        #endregion

        private DialogResult ValidData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter a table name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DialogResult.None;
            }            

            if (cbxTableShape.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter a table shape.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DialogResult.None;
            }

            if (tableNames.IndexOf(txtName.Text.Trim().ToString()) > -1)
            {
                MessageBox.Show("Table Name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                txtName.SelectAll();
                return DialogResult.None;
            }

            return DialogResult.OK;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NumberOfSeats = (int)nudNumSeats.Value;
            
            // Set override value
            formDR = ValidData();

            this.Close();
        }

        private void TableCreateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Override native "Cancel" status
            this.DialogResult = formDR;

            // - MessageBox.Show(this.DialogResult.ToString());

            if (this.DialogResult != DialogResult.OK && this.DialogResult != DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Set override value
            formDR = DialogResult.Cancel;
            this.Close();
        }
    }
}
