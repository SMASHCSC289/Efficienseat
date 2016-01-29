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
    public partial class TableAssignments : Form
    {
        Graphics Table;

        public TableAssignments()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int rectSide = panel1.Width - (panel1.Width / 2);
            

            Table = panel1.CreateGraphics();
            Pen p = new Pen(Color.Black);
            Table.DrawEllipse(p, (panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide / 2), rectSide, rectSide);
        }
    }
}
