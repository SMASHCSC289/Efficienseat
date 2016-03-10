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
        public EditWedding()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            else
            {
                this.Close();
            }
        }

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
    }
}