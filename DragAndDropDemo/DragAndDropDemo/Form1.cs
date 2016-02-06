using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragAndDropDemo
{
    public partial class Form1 : Form
    {
        Label newLabel;
        Graphics Table;
        int previousSeats;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbGuest_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbGuest.Items.Count == 0)
                return;

            int index = lbGuest.IndexFromPoint(e.X, e.Y);
            string s = lbGuest.Items[index].ToString();
            DragDropEffects dde1 = DoDragDrop(s,
                DragDropEffects.All);

            if (dde1 == DragDropEffects.All)
            {
                lbGuest.Items.RemoveAt(lbGuest.IndexFromPoint(e.X, e.Y));
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawEllipse(Pens.Red, 100, 50, 200, 200);
            // e.Graphics.DrawEllipse(Pens.Red, 190, 15, 25, 25);
            Table = panel1.CreateGraphics();
            //Seat = panel1.CreateGraphics();
            Pen p = new Pen(Color.Black);

            Table.DrawEllipse(p, 100, 50, 200, 200);
            //Seat.DrawEllipse(p, 190, 15, 25, 25);
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
        }

        private void SeatLabel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            int X = p.X;
            int Y = p.Y;
            MessageBox.Show(X + "," + Y);
        }

        private void cbNumOfSeats_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveExistingSeats();
            AddSeats();
        }

        private void AddSeats()
        {
            int seats = Convert.ToInt32(cbNumOfSeats.Text);
            switch (seats)
            {
                case 1:
                    CreateSeatLabel(1, 160, 15);
                    break;
                case 2:
                    CreateSeatLabel(1, 160, 15);
                    CreateSeatLabel(2, 312, 146);
                    break;
                case 3:
                    CreateSeatLabel(1, 160, 15);
                    CreateSeatLabel(2, 312, 146);
                    CreateSeatLabel(3, 160, 263);
                    break;
                case 4:
                    CreateSeatLabel(1, 160, 15);
                    CreateSeatLabel(2, 312, 146);
                    CreateSeatLabel(3, 160, 263);
                    CreateSeatLabel(4, 5, 146);
                    break;
            }
        }

        private void CreateSeatLabel(int seatNumber, int X, int Y)
        {
            newLabel = new Label();
            newLabel.Location = new Point(X, Y);
            newLabel.Name = "lbSeat" + seatNumber.ToString();
            newLabel.Text = "Empty";
            newLabel.BorderStyle = BorderStyle.FixedSingle;
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            newLabel.AllowDrop = true;
            newLabel.DragEnter += SeatLabel_DragEnter;
            newLabel.DragDrop += SeatLabel_DragDrop;
            newLabel.Visible = true;
            newLabel.Show();
            panel1.Controls.Add(newLabel);
        }

        private void SeatLabel_DragDrop(object sender, DragEventArgs e)
        {
            (sender as Label).Text = e.Data.GetData(DataFormats.Text).ToString();
        }

        private void RemoveExistingSeats()
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is Label)
                {
                    panel1.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }
        }

        private void cbNumOfSeats_Enter(object sender, EventArgs e)
        {
        
        }
    }
}
