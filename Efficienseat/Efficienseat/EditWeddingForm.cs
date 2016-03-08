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
    public partial class EditWeddingForm : Form
    {
        private string weddingName = "";
        private string weddingDate = "";

        public EditWeddingForm()
        {
            InitializeComponent();
        }

        public EditWeddingForm(string description)
        {
            InitializeComponent();
            textBox1.Text = description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            weddingName = textBox1.Text;
            weddingDate = textBox2.Text;
        }

        private void EditWeddingForm_Load(object sender, EventArgs e)
        {

        }

        public string WeddingName
        {
            get
            {
                return weddingName;
            }
            set
            {
                weddingName = value;
            }
        }

        public string WeddingDate
        {
            get
            {
                return weddingDate;
            }
            set
            {
                weddingDate = value;
            }
        }
    }
}
