using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using VeryPrettyClicker.Utilities;

namespace VeryPrettyClicker
{
    public partial class WindowForm : Form
    {
        public GameWindow gameWindow;
        private System.Timers.Timer positionTimer;

        public WindowForm()
        {
            InitializeComponent();
        }

        private void WindowForm_Load(object sender, EventArgs e)
        {
            positionTimer = new System.Timers.Timer(1000);
            positionTimer.Elapsed += PositionTimer_Elapsed;
            //positionTimer.Start();
        }

        private void PositionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Rectangle bounds = gameWindow.Bounds;
            Invoke(new Action(() => { Location = new Point(bounds.Right - Width, bounds.Top); }));
        }

        private void WindowForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            positionTimer.Stop();
        }
    }
}
