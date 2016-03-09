using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Efficienseat
{
    public partial class LoadForm : Form
    {
        public DataTable wedDT;
        private int wedID;

        public LoadForm()
        {
            InitializeComponent();
        }

        private void LoadForm_Load(object sender, EventArgs e)
        {
            WeddingComboBox.DataSource = wedDT;
            WeddingComboBox.DisplayMember = "WED_PARTY_NAME";
            WeddingComboBox.ValueMember = "WED_ID";
        }


        public int WedID
        {
            get { return wedID; }

            set { wedID = value; }
        }


        private void CreateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (CreateRadioButton.Checked)
            {
                WeddingComboBox.Enabled = false;
                txtPartyName.Enabled = true;
                cbMonth.Enabled = true;
                cbYear.Enabled = true;
                LoadRadioButton.Checked = false;
            }
        }


        private void LoadRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LoadRadioButton.Checked)
            {
                if (WeddingComboBox.Items.Count != 0)
                {
                    WeddingComboBox.Enabled = true;
                    txtPartyName.Enabled = false;
                    cbMonth.Enabled = false;
                    cbYear.Enabled = false;
                    CreateRadioButton.Checked = false;
                }
                else if (LoadRadioButton.Checked == true)
                {
                    MessageBox.Show("No existing weddings found, please select Create");
                    LoadRadioButton.Checked = false;
                }
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (CreateRadioButton.Checked)
            {
                if (txtPartyName.Text.ToString() == "")
                {
                    MessageBox.Show("Please enter a Wedding Party Name", "Warning", MessageBoxButtons.OK);
                    txtPartyName.Focus();
                }
                else if (cbMonth.Text.ToString() == "")
                {
                    MessageBox.Show("Please choose the Wedding Month", "Warning", MessageBoxButtons.OK);
                    cbMonth.Focus();
                }
                else if (cbYear.Text.ToString() == "")
                {
                    MessageBox.Show("Please choose the Wedding Year", "Warning", MessageBoxButtons.OK);
                    cbYear.Focus();
                }
                else
                {
                    DataRow newRow = wedDT.NewRow();
                    if (wedDT.Rows.Count == 0)
                        newRow["WED_ID"] = 1;
                    else
                        newRow["WED_ID"] = Convert.ToInt32(wedDT.Compute("max(WED_ID)", string.Empty)) + 1;
                    newRow["WED_PARTY_NAME"] = txtPartyName.Text.ToString() + " " + cbMonth.Text.ToString() + "-" + cbYear.Text.ToString();
                    wedDT.Rows.Add(newRow);
                    wedID = Convert.ToInt32(newRow["WED_ID"].ToString());
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void LoadForm_Shown(object sender, EventArgs e)
        {
            WeddingComboBox.SelectedIndexChanged += SelectedIndexChanged;
            if (wedDT.Rows.Count > 0)
            {
                wedID = Convert.ToInt32(wedDT.Rows[0]["WED_ID"].ToString());
            }
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            wedID = Convert.ToInt32(WeddingComboBox.SelectedValue.ToString());
        }
    }
}
