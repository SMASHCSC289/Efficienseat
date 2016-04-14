using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Efficienseat
{
    public partial class TableAssignments : Form
    {
        //private
        private int shapeType = -1;
        private int wedID;
        private int rectSide, rectSide2;
        private int cbxtableID;
        
        //public
        public DataTable TableDT;
        public DataTable AttendeeDT;

        Graphics Table;
        Image image = new Bitmap(Efficienseat.Properties.Resources.Tablecloth);
        Mysource dragSource = new Mysource();
        List<ListView> listSeats;
        ListViewItem empty = new ListViewItem("Empty");
        

        // Applies custom UI settings by making various 
        #region Custom_UI


        // Window Resize Variables
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        // Window Border Method - Overload paint method to draw a border on the form
        private void LoadForm_Paint(object sender, PaintEventArgs e)
        {
            // Rectangle formBorder = this.DisplayRectangle;
            Rectangle formBorder = new Rectangle(0, 0, this.DisplayRectangle.Width - 1, this.DisplayRectangle.Height - 1);
            e.Graphics.DrawRectangle(new Pen(Color.DarkSlateGray, 1),
                                     formBorder);
        }

        ///// <summary>
        /////  Custom Form Controls
        ///// </summary>

        // Event Handler for Form Move.  Comment out code to disable movement.
        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // Window Resize and Draw Shadow Method - utilize Win32 interoperability to manage.
        protected override void WndProc(ref Message m)
        {
            const int wmNcHitTest = 0x84;

            // Comment out section to disable resize on specified border
            if (m.Msg == wmNcHitTest)
            {
                int x = (int)(m.LParam.ToInt64() & 0xFFFF);
                int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point pt = PointToClient(new Point(x, y));
                Size clientSize = ClientSize;
            }

            switch (m.Msg)
            {
                // Create Aero-style shadow
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            // Handle dragging the form
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
                m.Result = (IntPtr)HTCAPTION;

            //base.WndProc(ref m);
        }

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // Custom Close button
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Custom Close button hover highlight
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.Image = Efficienseat.Properties.Resources.Close_Light;
        }

        // Custom Close button return to default color
        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = Efficienseat.Properties.Resources.Close_Dark;
        }

        #endregion Custom_UI

        /// <summary>
        /// Public Properties
        /// </summary>
        public int WeddingID
        {
            set { wedID = value; }
        }

        /// <summary>
        /// Constructor
        /// 
        ///  - Uses panelWorkspace to determine side length
        ///  - Sets image to use for "Empty" seats
        ///  - initializes list of "Seats"
        ///  - Sets event handler to handle custom border code
        ///  - Sets event handler to handle custom window drag
        ///  
        /// </summary>
        public TableAssignments()
        {
            InitializeComponent();

            rectSide = pnlWorkspace.Width - (pnlWorkspace.Width / 2);
            rectSide2 = rectSide;

            empty.ImageIndex = 2;

            listSeats = new List<ListView>() { lvwSeat1, lvwSeat2, lvwSeat3, lvwSeat4, lvwSeat5, lvwSeat6, lvwSeat7, lvwSeat8, lvwSeat9, lvwSeat10 };
            foreach (ListView view in listSeats)
            {
                //view.Enabled = false;
                view.Visible = false;
            }

            // border code
            this.Paint += new PaintEventHandler(LoadForm_Paint);
            this.ResizeRedraw = true;

            // movement code                  
            label_Title.MouseDown += new MouseEventHandler(Form1_MouseDown);
        }

        private void TableAssignments_Load(object sender, EventArgs e)
        {
            primeSeats();
            loadTableComobBox();
        }

        /// <summary>
        /// DrawTable Methods
        /// 
        ///  - Calculates in-form location of the "Table"
        ///  - Calculates in-form location of the "Seats"
        ///  - Draws "Table" filled with chosen texture
        ///  - Places "Seats" around the table
        ///  
        /// </summary>
        #region DrawTable

        // Hijack Paint event for the panel
        private void pnlWorkspace_Paint(object sender, PaintEventArgs e)
        {
            drawShape(shapeType, (int)numericUpDown1.Value);
        }

        // Draw the table in the panel
        private void drawShape(int num, int numPoints)
        {
            // Circle
            if (shapeType == 0)
            {
                // Draw the table graphic in the panel
                rectSide2 = rectSide;
                Table = pnlWorkspace.CreateGraphics();
                TextureBrush tbrush = new TextureBrush(image);
                Table.FillEllipse(tbrush, new Rectangle((pnlWorkspace.Width / 2) - (rectSide / 2), (pnlWorkspace.Height / 2) - (rectSide2 / 2), rectSide, rectSide2));

                // Shape handles max of 10 "Seats"
                numericUpDown1.Maximum = 10;

                // Determine location of "Seats" in the panel
                calcPoints(numPoints, rectSide);
            }

            // Square
            if (shapeType == 1)
            {
                // Draw the table graphic in the panel
                rectSide2 = rectSide;
                Table = pnlWorkspace.CreateGraphics();
                TextureBrush tbrush = new TextureBrush(image);
                Table.FillRectangle(tbrush, new Rectangle((pnlWorkspace.Width / 2) - (rectSide / 2), (pnlWorkspace.Height / 2) - (rectSide2 / 2), rectSide, rectSide2));

                // Shape handles max of 8 "Seats"
                numericUpDown1.Maximum = 8;

                // Determine location of "Seats" in the panel
                calcPoints(numPoints, rectSide);
            }

            // Rectangle
            if (shapeType == 2)
            {
                // Draw the table graphic in the panel
                rectSide2 = pnlWorkspace.Height - ((listSeats[0].Height + 10));
                Table = pnlWorkspace.CreateGraphics();
                TextureBrush tbrush = new TextureBrush(image);
                Table.FillRectangle(tbrush, new Rectangle((pnlWorkspace.Width / 2) - (rectSide / 2), (pnlWorkspace.Height / 2) - (rectSide2 / 2), rectSide, rectSide2));

                // Shape handles max of 8 "Seats"
                numericUpDown1.Maximum = 8;

                // Determine location of "Seats" in the panel
                calcPoints(numPoints, rectSide);
            }
        }

        // Calculate "Seat" positions in the panel
        private void calcPoints(int numPoints, int side)
        {
            Pen p = new Pen(Color.Black);
            Pen p2 = new Pen(Color.Red);

            // Circle
            if (shapeType == 0)
            {
                // Extra distance from the "Table" graphic
                int additionalRad = 60;
                double angle = 360 / numPoints;

                for (int i = 0; i < numPoints; i++)
                {
                    double x = (pnlWorkspace.Width / 2) + ((side / 2) + additionalRad) * Math.Cos(degToRad(angle * i));
                    double y = (pnlWorkspace.Height / 2) + ((side / 2) + additionalRad) * Math.Sin(degToRad(angle * i));

                    Table.DrawRectangle(p2, (float)x, (float)y, 2, 2);

                    listSeats[i].Location = new Point((int)x - (listSeats[i].Width / 2), (int)y - (listSeats[i].Height / 2));
                    listSeats[i].Visible = true;
                }
            }

            // Square
            else if (shapeType == 1)
            {
                // Extra distance from the "Table" graphic
                int additionalSide = 50;

                // Create larger shape to place "Seats"
                Rectangle rectSeating = new Rectangle((pnlWorkspace.Width / 2) - (rectSide / 2) - additionalSide,
                                        (pnlWorkspace.Height / 2) - (rectSide2 / 2) - additionalSide,
                                        rectSide + (additionalSide * 2),
                                        rectSide2 + (additionalSide * 2)
                                    );

                List<Point> sqSeatsLessThanFive = new List<Point>() {
                                                                        new Point(rectSeating.Left + (rectSeating.Width / 2), rectSeating.Top),
                                                                        new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 2)),
                                                                        new Point(rectSeating.Left + (rectSeating.Width / 2), rectSeating.Bottom),
                                                                        new Point(rectSeating.Left, rectSeating.Top + (rectSeating.Height / 2))
                                                                    };

                List<Point> sqSeatsFive = new List<Point>() {
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3), rectSeating.Top),         // 1
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3) * 2, rectSeating.Top),     // 2
                                                                new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 2)),       // 3
                                                                new Point(rectSeating.Left + (rectSeating.Width / 2), rectSeating.Bottom),      // 4
                                                                new Point(rectSeating.Left, rectSeating.Top + (rectSeating.Height / 2))         // 5
                                                            };

                List<Point> sqSeatsSix = new List<Point>() {
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3), rectSeating.Top),         // 1
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3) * 2, rectSeating.Top),     // 2
                                                                new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 3)),       // 3
                                                                new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 3)*2),     // 4
                                                                new Point(rectSeating.Left + (rectSeating.Width / 2), rectSeating.Bottom),      // 5
                                                                new Point(rectSeating.Left, rectSeating.Top + (rectSeating.Height / 2))         // 6
                                                            };

                List<Point> sqSeatsSeven = new List<Point>() {
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3), rectSeating.Top),         // 1
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3) * 2, rectSeating.Top),     // 2
                                                                new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 3)),       // 3
                                                                new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 3)*2),     // 4
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3), rectSeating.Bottom),      // 5
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3) * 2, rectSeating.Bottom),  // 6
                                                                new Point(rectSeating.Left, rectSeating.Top + (rectSeating.Height / 2))         // 7
                                                            };

                List<Point> sqSeatsEight = new List<Point>() {
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3), rectSeating.Top),         // 1
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3) * 2, rectSeating.Top),     // 2
                                                                new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 3)),       // 3
                                                                new Point(rectSeating.Right, rectSeating.Top + (rectSeating.Height / 3)*2),     // 4
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3), rectSeating.Bottom),      // 5
                                                                new Point(rectSeating.Left + (rectSeating.Width / 3) * 2, rectSeating.Bottom),  // 6
                                                                new Point(rectSeating.Left, rectSeating.Top + (rectSeating.Height / 3) * 2),    // 7
                                                                new Point(rectSeating.Left, rectSeating.Top + (rectSeating.Height / 3))         // 8
                                                                
                                                            };

                // if the number of seats is less than or equal to 4
                // there is one seat per side
                if (numPoints <= 4)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        Table.DrawRectangle(p2, sqSeatsLessThanFive[i].X, sqSeatsLessThanFive[i].Y, 2, 2);
                        listSeats[i].Location = new Point(sqSeatsLessThanFive[i].X - (listSeats[i].Width / 2),
                                                          sqSeatsLessThanFive[i].Y - (listSeats[i].Height / 2));
                        listSeats[i].Visible = true;
                    }
                }

                // once the number goes beyond 4
                // 5 = 2 seats on side 1
                else if (numPoints == 5)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        Table.DrawRectangle(p2, sqSeatsFive[i].X, sqSeatsFive[i].Y, 2, 2);
                        listSeats[i].Location = new Point(sqSeatsFive[i].X - (listSeats[i].Width / 2),
                                                          sqSeatsFive[i].Y - (listSeats[i].Height / 2));
                        listSeats[i].Visible = true;
                    }
                }
                // 6 = 2 seats on side 1, 2
                else if (numPoints == 6)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        Table.DrawRectangle(p2, sqSeatsSix[i].X, sqSeatsSix[i].Y, 2, 2);
                        listSeats[i].Location = new Point(sqSeatsSix[i].X - (listSeats[i].Width / 2),
                                                          sqSeatsSix[i].Y - (listSeats[i].Height / 2));
                        listSeats[i].Visible = true;
                    }
                }
                // 7 = 2 seats on side 1, 2, 3
                else if (numPoints == 7)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        Table.DrawRectangle(p2, sqSeatsSeven[i].X, sqSeatsSeven[i].Y, 2, 2);
                        listSeats[i].Location = new Point(sqSeatsSeven[i].X - (listSeats[i].Width / 2),
                                                          sqSeatsSeven[i].Y - (listSeats[i].Height / 2));
                        listSeats[i].Visible = true;
                    }
                }
                // 8 = 2 seats on side 1, 2, 3, 4
                else if (numPoints == 8)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        Table.DrawRectangle(p2, sqSeatsEight[i].X, sqSeatsEight[i].Y, 2, 2);
                        listSeats[i].Location = new Point(sqSeatsEight[i].X - (listSeats[i].Width / 2),
                                                          sqSeatsEight[i].Y - (listSeats[i].Height / 2));
                        listSeats[i].Visible = true;
                    }
                }
            }

            // Rectangle
            else if (shapeType == 2)
            {
                // Extra distance from the "Table" graphic
                int additionalSide = 50;

                // Create larger shape to place "Seats"
                Rectangle rectSeating = new Rectangle((pnlWorkspace.Width / 2) - (rectSide / 2) - additionalSide,
                                                      (pnlWorkspace.Height / 2) - (rectSide2 / 2),
                                                      rectSide + (additionalSide * 2),
                                                      rectSide2);

                List<Point> rctSeatsLessThanFive = new List<Point>() {
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 3)),
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 3) * 2),
                                                                        new Point(rectSeating.Right, rectSeating.Top + 5 + (rectSeating.Height / 3)),
                                                                        new Point(rectSeating.Right, rectSeating.Top + 5 + (rectSeating.Height / 3) * 2)
                                                                    };

                List<Point> rctSeatsFive = new List<Point>() {
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 4)),
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 4) * 2),
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 4) * 3),
                                                                        new Point(rectSeating.Right, rectSeating.Top + 5 + (rectSeating.Height / 3) * 2),
                                                                        new Point(rectSeating.Right, rectSeating.Top + 5 + (rectSeating.Height / 3))

                                                                    };

                List<Point> rctSeatsSix = new List<Point>() {
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 4)),
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 4) * 2),
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 4) * 3),
                                                                        new Point(rectSeating.Right, rectSeating.Top + 5 + (rectSeating.Height / 4) * 3),
                                                                        new Point(rectSeating.Right, rectSeating.Top + 5 + (rectSeating.Height / 4) * 2),
                                                                        new Point(rectSeating.Right, rectSeating.Top + 5 + (rectSeating.Height / 4))
                                                                    };

                List<Point> rctSeatsSeven = new List<Point>() {
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 5)),
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 5) * 2),
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 5) * 3),
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 5) * 4),
                                                                        new Point(rectSeating.Right, rectSeating.Top + 5 + (rectSeating.Height / 4) * 3),
                                                                        new Point(rectSeating.Right, rectSeating.Top + 5 + (rectSeating.Height / 4) * 2),
                                                                        new Point(rectSeating.Right, rectSeating.Top + 5 + (rectSeating.Height / 4))
                                                                    };

                List<Point> rctSeatsEight = new List<Point>() {
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 5)),
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 5) * 2),
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 5) * 3),
                                                                        new Point(rectSeating.Left, rectSeating.Top + 5 + (rectSeating.Height / 5) * 4),
                                                                        new Point(rectSeating.Right, rectSeating.Top + 5 + (rectSeating.Height / 5) * 4),
                                                                        new Point(rectSeating.Right, rectSeating.Top + 5 + (rectSeating.Height / 5) * 3),
                                                                        new Point(rectSeating.Right, rectSeating.Top + 5 + (rectSeating.Height / 5) * 2),
                                                                        new Point(rectSeating.Right, rectSeating.Top + 5 + (rectSeating.Height / 5)),
                                                                    };

                // if the number of seats is less than or equal to 4
                // there is one seat per side
                if (numPoints <= 4)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        Table.DrawRectangle(p2, rctSeatsLessThanFive[i].X, rctSeatsLessThanFive[i].Y, 2, 2);
                        listSeats[i].Location = new Point(rctSeatsLessThanFive[i].X - (listSeats[i].Width / 2),
                                                          rctSeatsLessThanFive[i].Y - (listSeats[i].Height / 2));
                        listSeats[i].Visible = true;
                    }
                }
                // once the number goes beyond 4
                // 5 : 3 left, 2 right
                else if (numPoints == 5)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        Table.DrawRectangle(p2, rctSeatsFive[i].X, rctSeatsFive[i].Y, 2, 2);
                        listSeats[i].Location = new Point(rctSeatsFive[i].X - (listSeats[i].Width / 2),
                                                          rctSeatsFive[i].Y - (listSeats[i].Height / 2));
                        listSeats[i].Visible = true;
                    }
                }
                // 6 : 3 each
                else if (numPoints == 6)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        Table.DrawRectangle(p2, rctSeatsSix[i].X, rctSeatsSix[i].Y, 2, 2);
                        listSeats[i].Location = new Point(rctSeatsSix[i].X - (listSeats[i].Width / 2),
                                                          rctSeatsSix[i].Y - (listSeats[i].Height / 2));
                        listSeats[i].Visible = true;
                    }
                }
                // 7 : 4 left, 3 right
                else if (numPoints == 7)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        Table.DrawRectangle(p2, rctSeatsSeven[i].X, rctSeatsSeven[i].Y, 2, 2);
                        listSeats[i].Location = new Point(rctSeatsSeven[i].X - (listSeats[i].Width / 2),
                                                          rctSeatsSeven[i].Y - (listSeats[i].Height / 2));
                        listSeats[i].Visible = true;
                    }
                }
                // 8 : 4 each
                else if (numPoints == 8)
                {
                    for (int i = 0; i < numPoints; i++)
                    {
                        Table.DrawRectangle(p2, rctSeatsEight[i].X, rctSeatsEight[i].Y, 2, 2);
                        listSeats[i].Location = new Point(rctSeatsEight[i].X - (listSeats[i].Width / 2),
                                                          rctSeatsEight[i].Y - (listSeats[i].Height / 2));
                        listSeats[i].Visible = true;
                    }
                }
            }
        }

        // Convert degrees to radians for circle calculations
        private double degToRad(double degrees)
        {
            return Math.PI * (degrees - 90) / 180.0;
        }

        // Force redraw of "Table" and "Seats" to re-center on form resize (POSSIBLY DEPRECATED)
        private void TableAssignments_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        // Make "Seats" visible / invisible when number of seats is changed
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            updateSeatListViews();
        }

        // When choosing a different table shape, redraw the "Table" and reposition the "Seats"
        private void cbxTableShape_SelectionChangeCommitted(object sender, EventArgs e)
        {
            doTableStuff();
        }

        // Set shapeType and refresh the panel
        private void doTableStuff()
        {
            shapeType = cbxTableShape.SelectedIndex;
            Refresh();
        }

        #endregion DrawTable

        // ListView Methods
        #region ListViewHandling

        // holds the last item moved
        public class Mysource
        {
            public object source { get; set; }
            Control control { get; set; }
        }

        // triggered when a listview item drag first enters a listview
        private void listView_DragEnter(object sender, DragEventArgs e)
        {
            // Check for the custom DataFormat ListViewItem array.

            {
                if (e.Data.GetDataPresent("ListViewItem"))
                {
                    e.Effect = DragDropEffects.Move;
                }
                else {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void listView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ListView lv = sender as ListView;
            ListViewItem myItem = lv.SelectedItems[0]/*.Clone()*/ as ListViewItem;

            lv.DoDragDrop(new DataObject("ListViewItem", myItem), DragDropEffects.Move);
        }

        // triggered when mouse button is released
        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            ListView lv = (ListView)sender;
            ListViewItem myItem = e.Data.GetData("ListViewItem") as ListViewItem;
            ListView lvOld = dragSource.source as ListView;

            //MessageBox.Show(lvOld.Name.ToString() + " ---> " + lv.Name.ToString());

            if (cbxTableName.SelectedIndex != -1 && cbxTableShape.SelectedIndex != -1)
            {
                // always accept dragged items into unseated listview
                if (lv == lvwUnseated)
                {
                    if (myItem.Text != "Empty")
                    {
                        // Insert drag item
                        removeItemFromAll(myItem);
                        lv.Items.Add(myItem);
                        lvwUnseated.Sort();
                    }

                    updateAttendee(Convert.ToInt32(myItem.SubItems[3].Text));

                    updateSeatListViews();
                }
                // If it's not the unseated listview, and it's empty
                else if (lv != lvwUnseated && lv.Items[0].Text == "Empty")
                {
                    // Remove empty item
                    lv.Items[0].Remove();

                    // Insert drag item
                    removeItemFromAll(myItem);
                    lv.Items.Add(myItem);

                    updateAttendee(Convert.ToInt32(myItem.SubItems[3].Text), Convert.ToInt32(lv.Tag), cbxtableID);

                    updateSeatListViews();
                }
                // If the seat listview is already filled, ask if user wants to swap
                else
                {
                    if (MessageBox.Show("This seat is already filled.  Replace?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        // Move current item back to unassigned
                        ListViewItem lvi = lv.Items[0];
                        removeItemFromAll(lvi);
                        lvwUnseated.Items.Add(lvi);
                        lvwUnseated.Sort();
                        updateAttendee(Convert.ToInt32(lvi.SubItems[3].Text));

                        // Insert drag item
                        removeItemFromAll(myItem);
                        lv.Items.Add(myItem);
                        updateAttendee(Convert.ToInt32(myItem.SubItems[3].Text), Convert.ToInt32(lv.Tag), cbxtableID);

                        updateSeatListViews();
                    }
                }

                Refresh();
            }
            else if (cbxTableName.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if (cbxTableShape.SelectedIndex == -1)
            {
                MessageBox.Show("Please set the shape of the table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            if (lv.Items.Count == 0 && lv != lvwUnseated)
            {
                ListViewItem emp = empty.Clone() as ListViewItem;
                lvOld.Items.Add(emp);
            }

            dragSource.source = null;
        }

        // triggered when listviewitem is drug out of the listview
        private void listView_DragLeave(object sender, EventArgs e)
        {
            dragSource.source = sender;
        }

        // remove specific listview item from all listviews in the form
        private void removeItemFromAll(ListViewItem _li)
        {
            foreach (Control c in pnlWorkspace.Controls)
            {
                if (c is ListView)
                {
                    ListView _lv = c as ListView;
                    _lv.Items.Remove(_li);
                }
            }

            lvwUnseated.Items.Remove(_li);
        }

        // update all seat listview
        private void updateSeatListViews()
        {
            for (int i = 0; i < 10; i++)
            {
                //MessageBox.Show(listviews[i].Name + " : " + listviews[i].Items.Count.ToString());

                listSeats[i].Location = new Point(3, 3);
                listSeats[i].Visible = false;

                if (i >= (int)numericUpDown1.Value && listSeats[i].Items.Count > 0 && listSeats[i].Items[0].Text != "Empty")
                {
                    ListViewItem lvi = listSeats[i].Items[0];
                    updateAttendee(Convert.ToInt32(lvi.SubItems[3].Text));
                    removeItemFromAll(lvi);
                    //lvwUnseated.Items.Add(lvi);
                    lvwUnseated.Refresh();

                    ListViewItem emp = empty.Clone() as ListViewItem;
                    listSeats[i].Items.Add(emp);
                }
                else if (listSeats[i].Items.Count == 0)
                {
                    //MessageBox.Show("Updating " + listviews[i].Name);

                    ListViewItem emp = empty.Clone() as ListViewItem;
                    listSeats[i].Items.Add(emp);
                }
            }

            Refresh();
        }

        // Load unseated attendees in main list
        public void loadListView()
        {
            lvwUnseated.Clear();
            lvwUnseated.BeginUpdate();

            // Iterate through all attendees that have accepted and are not seated
            // Add them to the unseated list
            foreach (DataRow dr in AttendeeDT.Rows)
            {
                ListViewItem li = new ListViewItem();

                if (dr["RSVP"].ToString() == "Accept" && dr["TABLE_ID"] == DBNull.Value)
                {
                    li.Text = dr["LAST_NAME"] + ", " + dr["FIRST_NAME"];
                    li.SubItems.Add(dr["RSVP"].ToString());

                    if (dr["FOOD_ALLERGY"].ToString() == "Y" && dr["COMMENTS"].ToString() != "")
                    {
                        li.ImageIndex = 3;
                        li.SubItems.Add(dr["COMMENTS"].ToString());
                        li.ToolTipText = dr["COMMENTS"].ToString();
                    }
                    else if (dr["FOOD_ALLERGY"].ToString() == "N" && dr["COMMENTS"].ToString() != "")
                    {
                        li.ImageIndex = 2;
                        li.SubItems.Add(dr["COMMENTS"].ToString());
                        li.ToolTipText = dr["COMMENTS"].ToString();
                    }

                    else if (dr["FOOD_ALLERGY"].ToString() == "Y" && dr["COMMENTS"].ToString() == "")
                    {
                        li.ImageIndex = 1;
                        li.SubItems.Add("");
                    }
                    else if (dr["FOOD_ALLERGY"].ToString() == "N" && dr["COMMENTS"].ToString() == "")
                    {
                        li.ImageIndex = 0;
                        li.SubItems.Add("");
                    }

                    li.SubItems.Add(dr["GUEST_ID"].ToString());

                    lvwUnseated.Items.Add(li);
                }
            }

            lvwUnseated.EndUpdate();
        }

        private void removeAllAttendees()
        {
            foreach (ListView lv in listSeats)
            {
                // Find some way to see if the item is invalid
                if (lv.Enabled == true)
                {
                    if (lv.Items[0].Text != "Empty")
                    {
                        //MessageBox.Show(lv.Items[0].SubItems[3].Text);
                        updateAttendee(Convert.ToInt32(lv.Items[0].SubItems[3].Text));

                        //var result = from DataRow row in AttendeeDT.Rows
                        //             where Convert.ToInt32(row[0]) == wedID && Convert.ToInt32(row[1]) == Convert.ToInt32(lv.Items[0].SubItems[3].Text)
                        //             select row;

                        lv.Items.Clear();
                        ListViewItem emp = empty.Clone() as ListViewItem;
                        lv.Items.Add(emp);
                    }
                }
            }
        }

        private void loadTableComobBox()
        {
            // Load tables from DB
            cbxTableName.Items.Clear();
            foreach (DataRow row in TableDT.Rows)
            {
                cbxTableName.Items.Add(row.Field<string>("TABLE_NAME"));
            }
        }

        private void primeSeats()
        {
            // Prime all "Seats" with empty items
            foreach (ListView l in listSeats)
            {
                ListViewItem emp = empty.Clone() as ListViewItem;
                l.Items.Add(emp);
            }
        }

        // Load attendees in their assigned seats
        public void loadSeats()
        {
            // On each load, clear out all seats replace them with empty chairs.
            foreach (ListView lv in listSeats)
            {
                lv.Items.Clear();
                ListViewItem emp = empty.Clone() as ListViewItem;
                lv.Items.Add(emp);
            }

            // Get list of all seated attendees for the selected table
            var result = from DataRow row in AttendeeDT.Rows
                         where Convert.ToInt32(row[0]) == wedID && row[7] != DBNull.Value && Convert.ToInt32(row[7]) == (cbxtableID)
                         select row;



            // Iterate through the list to create attendee items and seat them
            foreach (DataRow dr in result)
            {
                ListViewItem li = new ListViewItem();

                li.Text = dr["LAST_NAME"] + ", " + dr["FIRST_NAME"];
                li.SubItems.Add(dr["RSVP"].ToString());

                if (dr["FOOD_ALLERGY"].ToString() == "Y" && dr["COMMENTS"].ToString() != "")
                {
                    li.ImageIndex = 4;
                    li.SubItems.Add(dr["COMMENTS"].ToString());
                    li.ToolTipText = dr["COMMENTS"].ToString();
                }
                else if (dr["FOOD_ALLERGY"].ToString() == "N" && dr["COMMENTS"].ToString() != "")
                {
                    li.ImageIndex = 3;
                    li.SubItems.Add(dr["COMMENTS"].ToString());
                    li.ToolTipText = dr["COMMENTS"].ToString();
                }

                else if (dr["FOOD_ALLERGY"].ToString() == "Y" && dr["COMMENTS"].ToString() == "")
                {
                    li.ImageIndex = 1;
                    li.SubItems.Add("");
                }
                else if (dr["FOOD_ALLERGY"].ToString() == "N" && dr["COMMENTS"].ToString() == "")
                {
                    li.ImageIndex = 0;
                    li.SubItems.Add("");
                }

                li.SubItems.Add(dr["GUEST_ID"].ToString());

                // Have to use SEAT_NUM - 1 to account for 0 indexed list.
                if (dr["SEAT_NUM"].ToString() != "")
                {
                    listSeats[Convert.ToInt32(dr["SEAT_NUM"]) - 1].Items.Clear();
                    listSeats[Convert.ToInt32(dr["SEAT_NUM"]) - 1].Items.Add(li);
                }
            }
        }

        #endregion ListViewHandling

        // Update DB record with new attendee seat assignment
        public void updateAttendee(int attendeeNum, int seatNumber = 0, int tableNumber = 0)
        {
            // Determine DataRow that holds the Attendee
            var result = from DataRow row in AttendeeDT.Rows
                         where Convert.ToInt32(row[1]) == attendeeNum
                         select row;

            // Update attendee seating information
            foreach (DataRow row in result)
            {
                // Unseated
                if (seatNumber == 0 && tableNumber == 0)
                {
                    row.SetField("TABLE_ID", DBNull.Value);
                    row.SetField("SEAT_NUM", DBNull.Value);
                }
                // Seated
                else
                {
                    row.SetField("TABLE_ID", tableNumber);
                    row.SetField("SEAT_NUM", seatNumber);
                }
            }
        }

        // Update Table attributes in the DB
        // Implemented due to broken real-time edit changes.
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            updateTable(cbxtableID, cbxTableShape.Text, (int)numericUpDown1.Value);
        }

        // Open TableCreateForm to add a table to the database
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            List<string> taTableNames = new List<string>();
            for (int i = 0; i < cbxTableName.Items.Count; i++)
            {
                taTableNames.Add(cbxTableName.Items[i].ToString());
            }

            using (TableCreateForm tcf = new TableCreateForm())
            {
                tcf.tableNames = taTableNames;
                if (tcf.ShowDialog(this) == DialogResult.OK)
                {
                    if (tcf.Name != null || tcf.Shape != null)
                    {
                        addTable(tcf.Name, tcf.Shape, tcf.NumberOfSeats);
                    }
                    else if (tcf.Name == null)
                    {
                        MessageBox.Show("Table name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else if (tcf.Shape == null)
                    {
                        MessageBox.Show("Table must have a shape.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }

            if (TableDT.Rows.Count == 10)
                btnAddTable.Enabled = false;
        }

        // Add new table to the wedding
        private void addTable(string tableName, string tableShape, int numSeats)
        {
            int newTableID;

            if (TableDT.Rows.Count == 0)
            {
                newTableID = 1;
            }
            else
            {
                newTableID = Convert.ToInt32(TableDT.Compute("max(TABLE_ID)", string.Empty)) + 1;
            }

            // MessageBox.Show(newTableID.ToString());

            //Create and fill a new DataRow based on TableDT
            DataRow row = TableDT.NewRow();
            row.SetField("WED_ID", wedID);
            row.SetField("TABLE_ID", newTableID);
            row.SetField("TABLE_NAME", tableName);
            row.SetField("NUM_OF_SEATS", numSeats);
            row.SetField("TABLE_TYPE", tableShape);

            //Add newly created row to TableDT
            TableDT.Rows.Add(row);

            //Add table to cbxTableName
            cbxTableName.Items.Add(tableName);
        }

        // Save changes to the table in the DB
        private void updateTable(int tableID, string tableShape, int numSeats)
        {
            var result = from row in TableDT.AsEnumerable()
                         where Convert.ToInt32(row[0]) == wedID && Convert.ToInt32(row[1]) == tableID
                         select row;

            foreach (DataRow row in result)
            {
                row.SetField("TABLE_TYPE", tableShape);
                row.SetField("NUM_OF_SEATS", numSeats);
            }
        }

        // Load all elements of the newly selected table
        private void cbxTableName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbxtableID = GetTableID(cbxTableName.Text.ToString());
            loadTable(cbxtableID);
            cbxTableShape.Enabled = true;
            numericUpDown1.Enabled = true;
            btnSaveChanges.Enabled = true;
            loadSeats();
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (cbxTableName.Text.ToString() != "")
            {
                if (MessageBox.Show("Do you really want to delete table " + cbxTableName.Text + "?", "Delete Table?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    removeAllAttendees();
                    deleteTable();
                    primeSeats();
                    loadTableComobBox();
                    clearPanel();
                }
            }
        }

        public void clearPanel()
        {
            for (int i = 0; i < 10; i++)
            {
                listSeats[i].Visible = false;
            }

            //Table.Clear(Color.White);
            cbxTableShape.SelectedIndex = -1;
            cbxTableShape.Enabled = false;
           // numericUpDown1.ResetText();
            numericUpDown1.Enabled = false;
            shapeType = -1;
            Refresh();
            
        }
        // Get table from DB and set form controls
        private void loadTable(int index)
        {
            var result = from row in TableDT.AsEnumerable()
                         where Convert.ToInt32(row[0]) == wedID && Convert.ToInt32(row[1]) == index
                         select row;

            foreach (DataRow row in result)
            {
                cbxTableShape.SelectedIndex = cbxTableShape.Items.IndexOf(row[4]);
                numericUpDown1.Value = Convert.ToDecimal(row[3]);
            }

            doTableStuff();
        }

        private void deleteTable()
        {
            DataRow[] removeRow = TableDT.Select("TABLE_ID = " + cbxtableID.ToString());
            if (removeRow.Length > 0)
            {
                int SelectedIndex = TableDT.Rows.IndexOf(removeRow[0]);
                TableDT.Rows.RemoveAt(SelectedIndex);
            }

            if (TableDT.Rows.Count < 10)
                btnAddTable.Enabled = true;
        }

        private int GetTableID(string tableName)
        {
            cbxtableID = -1;
            DataRow[] returnRow = TableDT.Select("TABLE_NAME = '" + tableName + "'");
            if (returnRow.Length > 0)
            {
                cbxtableID = Convert.ToInt32(returnRow[0]["TABLE_ID"].ToString());
            }

            return cbxtableID;
        }
    }
}