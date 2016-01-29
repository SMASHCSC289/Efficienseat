using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Design
{
    public partial class Play_With_MDI : Form
    {
        public Play_With_MDI()
        {
            InitializeComponent();
        }

        private void Play_With_MDI_Load(object sender, EventArgs e)
        {
            Attendee_List al = new Attendee_List();
            al.MdiParent = this;
            al.Show();

            TableAssignments ta = new TableAssignments();
            ta.MdiParent = this;
            ta.Show();
        }
    }
}
