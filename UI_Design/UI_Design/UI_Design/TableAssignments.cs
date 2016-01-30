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
        private int shapeType = 0;
        int rectSide, rectSide2;
        Image image = new Bitmap(UI_Design.Properties.Resources.WrinklesHomogeneous0044_M2);

        public TableAssignments()
        {
            InitializeComponent();
            rectSide = panel1.Width - (panel1.Width / 2);
            rectSide2 = rectSide;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            drawShape(shapeType);
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            shapeType = comboBox2.SelectedIndex;
            this.Refresh();
        }

        private void drawShape(int num)
        {
            

            // Circle
            if (shapeType == 0)
            {
                rectSide2 = rectSide;
                Table = panel1.CreateGraphics();
                TextureBrush tbrush = new TextureBrush(image);                
                Table.FillEllipse(tbrush, new Rectangle((panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2));
                //Pen p = new Pen(Color.Black);
                //Table.DrawEllipse(p, (panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2);
            }

            // Square
            if (shapeType == 1)
            {
                rectSide2 = rectSide;
                Table = panel1.CreateGraphics();
                TextureBrush tbrush = new TextureBrush(image);
                Table.FillRectangle(tbrush, new Rectangle((panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2));
                //Pen p = new Pen(Color.Black);
                //Table.DrawRectangle(p, (panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2);
            }

            // Rectangle
            if (shapeType == 2)
            {
                rectSide2 = 2 * rectSide;
                Table = panel1.CreateGraphics();
                TextureBrush tbrush = new TextureBrush(image);
                Table.FillRectangle(tbrush, new Rectangle((panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2));
                //Pen p = new Pen(Color.Black);
                //Table.DrawRectangle(p, (panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2);
            }

            // Oval
            if (shapeType == 3)
            {
                rectSide2 = 2 * rectSide;
                Table = panel1.CreateGraphics();
                TextureBrush tbrush = new TextureBrush(image);
                Table.FillEllipse(tbrush, new Rectangle((panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2));
                //Pen p = new Pen(Color.Black);
                //Table.DrawEllipse(p, (panel1.Width / 2) - (rectSide / 2), (panel1.Height / 2) - (rectSide2 / 2), rectSide, rectSide2);
            }
        }


    }
}
