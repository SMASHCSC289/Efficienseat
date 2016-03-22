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
        private string tableName = null;
        private string tableShape = null;
        private int numSeats = 0;

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
    }
}
