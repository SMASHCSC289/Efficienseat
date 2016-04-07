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

        private void cbxTableShape_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxTableShape.Text == "Rectangle")
            {
                cbEndSeats.Enabled = true;
            }
            else
            {
                cbEndSeats.Enabled = false;
            }

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            ValidData();
        }

        private void TableCreateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSave.DialogResult != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        #endregion

        private void ValidData()
        {
            btnSave.DialogResult = DialogResult.OK;

            if (tableNames.IndexOf(txtName.Text.Trim().ToString()) > -1)
            {
                MessageBox.Show("Table Name already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                txtName.SelectAll();
                btnSave.DialogResult = DialogResult.No;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
