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
    public partial class StartupForm : Form
    {
        Timer timeToLoad = new Timer();

        public StartupForm()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {
            timeToLoad.Interval = 3000;
            timeToLoad.Start();

            timeToLoad.Tick += new EventHandler(TimerEventProcessor);
        }

        private void TimerEventProcessor(Object myObject,
                                           EventArgs myEventArgs)
        {
            timeToLoad.Stop();
            loadMain();
            this.Close();
        }

        private void loadMain()
        {
            Main_Window mw = new Main_Window();
            mw.Show();
        }


    }
}
