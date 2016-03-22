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
using System.Runtime.InteropServices;

namespace Efficienseat
{
    public partial class LoadForm : Form
    {
        public DataTable wedDT;
        private int wedID;
        private string wedName;
        bool dataValid = true;

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
            //if (e.Button == MouseButtons.Left)
            //{
            //    ReleaseCapture();
            //    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            //}
        }

        // Window Resize and Draw Shadow Method - utilize Win32 interoperability to manage.
        protected override void WndProc(ref Message m)
        {
            const int wmNcHitTest = 0x84;
            const int htLeft = 10;
            const int htRight = 11;
            const int htTop = 12;
            const int htTopLeft = 13;
            const int htTopRight = 14;
            const int htBottom = 15;
            const int htBottomLeft = 16;
            const int htBottomRight = 17;

            // Comment out section to disable resize on specified border
            if (m.Msg == wmNcHitTest)
            {
                int x = (int)(m.LParam.ToInt64() & 0xFFFF);
                int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point pt = PointToClient(new Point(x, y));
                Size clientSize = ClientSize;
                /////allow resize on the lower right corner
                //if (pt.X >= clientSize.Width - 5 && pt.Y >= clientSize.Height - 5 && clientSize.Height >= 16)
                //{
                //    m.Result = (IntPtr)(IsMirrored ? htBottomLeft : htBottomRight);
                //    return;
                //}
                /////allow resize on the lower left corner
                //if (pt.X <= 5 && pt.Y >= clientSize.Height - 5 && clientSize.Height >= 16)
                //{
                //    m.Result = (IntPtr)(IsMirrored ? htBottomRight : htBottomLeft);
                //    return;
                //}
                /////allow resize on the upper right corner
                //if (pt.X <= 5 && pt.Y <= 5 && clientSize.Height >= 16)
                //{
                //    m.Result = (IntPtr)(IsMirrored ? htTopRight : htTopLeft);
                //    return;
                //}
                /////allow resize on the upper left corner
                //if (pt.X >= clientSize.Width - 5 && pt.Y <= 5 && clientSize.Height >= 16)
                //{
                //    m.Result = (IntPtr)(IsMirrored ? htTopLeft : htTopRight);
                //    return;
                //}
                /////allow resize on the top border
                //if (pt.Y <= 5 && clientSize.Height >= 16)
                //{
                //    m.Result = (IntPtr)(htTop);
                //    return;
                //}
                /////allow resize on the bottom border
                //if (pt.Y >= clientSize.Height - 5 && clientSize.Height >= 16)
                //{
                //    m.Result = (IntPtr)(htBottom);
                //    return;
                //}
                /////allow resize on the left border
                //if (pt.X <= 5 && clientSize.Height >= 16)
                //{
                //    m.Result = (IntPtr)(htLeft);
                //    return;
                //}
                /////allow resize on the right border
                //if (pt.X >= clientSize.Width - 5 && clientSize.Height >= 16)
                //{
                //    m.Result = (IntPtr)(htRight);
                //    return;
                //}
            }

            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
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

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;

            //base.WndProc(ref m);
        }        

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion Custom_UI

        public LoadForm()
        {
            InitializeComponent();

            // border code
            this.Paint += new PaintEventHandler(LoadForm_Paint);
            this.ResizeRedraw = true;

            // movement code                  
            label_Title.MouseDown += new MouseEventHandler(Form1_MouseDown);
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
        
        public string WedName
        {
            get { return wedName; }
            set { wedName = value; }
        }

        private void CreateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCreate.Checked)
            {
                WeddingComboBox.Enabled = false;
                txtPartyName.Enabled = true;
                cbMonth.Enabled = true;
                cbYear.Enabled = true;
                rbtnLoad.Checked = false;
            }

            btnOK.Enabled = true;
        }
        
        private void LoadRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnLoad.Checked)
            {
                if (WeddingComboBox.Items.Count != 0)
                {
                    WeddingComboBox.Enabled = true;
                    txtPartyName.Enabled = false;
                    cbMonth.Enabled = false;
                    cbYear.Enabled = false;
                    rbtnCreate.Checked = false;
                }
                else if (rbtnLoad.Checked == true)
                {
                    MessageBox.Show("No existing weddings found, please select Create");
                    rbtnLoad.Checked = false;
                }
            }

            btnOK.Enabled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbtnCreate.Checked)
            {
                if (txtPartyName.Text.ToString() == "")
                {
                    MessageBox.Show("Please enter a Wedding Party Name", "Warning", MessageBoxButtons.OK);
                    txtPartyName.Focus();
                    dataValid = false;
                }
                else if (cbMonth.Text.ToString() == "")
                {
                    MessageBox.Show("Please choose the Wedding Month", "Warning", MessageBoxButtons.OK);
                    cbMonth.Focus();
                    dataValid = false;
                }
                else if (cbYear.Text.ToString() == "")
                {
                    MessageBox.Show("Please choose the Wedding Year", "Warning", MessageBoxButtons.OK);
                    cbYear.Focus();
                    dataValid = false;
                }
                else
                {
                    DataRow newRow = wedDT.NewRow();
                    if (wedDT.Rows.Count == 0)
                        newRow["WED_ID"] = 1;
                    else
                        newRow["WED_ID"] = Convert.ToInt32(wedDT.Compute("max(WED_ID)", string.Empty)) + 1;
                    wedName = txtPartyName.Text.ToString() + " " + cbMonth.Text.ToString() + "-" + cbYear.Text.ToString();
                    newRow["WED_PARTY_NAME"] = wedName;
                    wedDT.Rows.Add(newRow);
                    wedID = Convert.ToInt32(newRow["WED_ID"].ToString());
                    this.Close();
                }
            }
            else
            {
                //set wedName to wedPartyName from selected wedID
                wedName = WeddingComboBox.Text + "JANUARY-2017";
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

        private void LoadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check to see if data validation was successful
            if (!dataValid)
            {
                e.Cancel = true;
            }

            dataValid = true;
        }
    }


}
