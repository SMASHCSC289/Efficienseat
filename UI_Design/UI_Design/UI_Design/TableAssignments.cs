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
            drawShape(shapeType, (int) numericUpDown1.Value);
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            shapeType = comboBox2.SelectedIndex;
            this.Refresh();
        }

        private void drawShape(int num, int numPoints)
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
                drawPoints(numPoints, rectSide);
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

        private void drawPoints(int numPoints, int side)
        {
            int additionalRad = 60;
            double angle = 360 / numPoints;

            Pen p = new Pen(Color.Black);
            Pen p2 = new Pen(Color.Red);

            //Table.DrawEllipse(  p,
            //                    (panel1.Width / 2) - (rectSide / 2) - additionalRad,
            //                    (panel1.Height / 2) - (rectSide2 / 2) - additionalRad,
            //                    rectSide + (additionalRad * 2), 
            //                    rectSide2 + (additionalRad * 2)
            //                 );            

            for (int i = 0; i < numPoints; i++)
            {
                double x = (panel1.Width / 2) + ((side / 2) + additionalRad) * Math.Cos(degToRad(angle * i));
                double y = (panel1.Height / 2) + ((side / 2) + additionalRad) * Math.Sin(degToRad(angle * i));

                Table.DrawRectangle(p2, (float) x, (float) y, 2, 2);

                //MessageBox.Show(  "Point : (" + x.ToString() + "," + y.ToString() + ")" + Environment.NewLine +
                //                 "Angle : " + (angle * i) + " Degrees | " + degToRad((angle * i)) + " Radians" 
                //               );
            }
        }

        private double degToRad(double degrees)
        {
            return Math.PI * (degrees - 90) / 180.0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

    }
}
