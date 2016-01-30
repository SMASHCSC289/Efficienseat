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
            al.StartPosition = FormStartPosition.Manual;
            al.Location = new Point(0, 0);
            //al.Height = this.ClientSize.Height - (al.Height - al.ClientSize.Height);
            
            al.Show();

            //TableAssignments ta = new TableAssignments();
            //ta.MdiParent = this;
            //ta.StartPosition = FormStartPosition.Manual;
            //ta.Location = new Point(al.Location.X + al.Width + 5,
            //                        al.Location.Y);

            //ta.Show();
        }

        private void showTableEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendee_List al = (Attendee_List) this.MdiChildren[0];

            TableAssignments ta = new TableAssignments();
            ta.MdiParent = this;
            ta.StartPosition = FormStartPosition.Manual;
            ta.Location = new Point(al.Location.X + al.Width + 5,
                                    al.Location.Y);

            ta.Show();
        }
    }
}
