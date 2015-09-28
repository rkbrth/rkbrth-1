using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using VeryPrettyClicker.Utilities;

namespace VeryPrettyClicker
{
    public partial class WindowForm : Form
    {
        public GameWindow gameWindow;
        private System.Timers.Timer positionTimer;
        private Rectangle _bounds;

        public List<Label>[] buttons = new List<Label>[3];

        public WindowForm()
        {
            InitializeComponent();
        }

        private void WindowForm_Load(object sender, EventArgs e)
        {
            positionTimer = new System.Timers.Timer(500);
            positionTimer.Elapsed += PositionTimer_Elapsed;
            positionTimer.Start();
        }

        #region Follow main window
        private void PositionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Rectangle bounds = gameWindow.Bounds;
            if (!bounds.Equals(_bounds))
            {
                _bounds = bounds;
                try
                {
                    Invoke(new Action(() => { Location = new Point(_bounds.Right - Width, _bounds.Top); positionTimer.Interval = 1000.0/60; }));
                }
                catch { }
            }
            else
            {
                double interval = Math.Min(positionTimer.Interval + 100, 400);
                try
                {
                    Invoke(new Action(() => { positionTimer.Interval = interval; }));
                }
                catch { }
            }
            

        }

        private void WindowForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            positionTimer.Stop();
        }
        #endregion

        #region Show/close with hotkey/main window
        bool _hotkeyActivated;
        public bool HotkeyActivated
        {
            get
            {
                return _hotkeyActivated;
            }
            set
            {
                _hotkeyActivated = value;
                Visible = value && WindowActivated;
                Text = value.ToString() + " " + WindowActivated.ToString();
            }
        }

        bool _windowActivated;
        private object btnHeight;

        public bool WindowActivated
        {
            get
            {
                return _windowActivated;
            }
            set
            {
                _windowActivated = value;
                Visible = value && HotkeyActivated;
                Text = value.ToString() + " " + HotkeyActivated.ToString();
            }
        }
        #endregion

        #region Prevent window from Alt+Tab switch
        protected override CreateParams CreateParams
        {
            get
            {
                var Params = base.CreateParams;
                Params.ExStyle |= 0x80;
                return Params;
            }
        }
        #endregion

        private void InitControls()
        {
            InitRow1();
        }

        private void InitRow1()
        {
            ControlsSettings s = new ControlsSettings();
            s.btnMargin = 0;
            s.startX = 0;
            s.startY = 0;
            s.btnWidth = 40;
            s.btnHeight = 40;
            s.parent = this;
            s.index = 0;
            InitRow(s);
        }

        private void InitRow2()
        {

        }

        private void InitRow3()
        {

        }

        private void InitRow(ControlsSettings settings)
        {
            buttons[settings.index].Clear();

        }

        struct ControlsSettings
        {
            public int btnMargin;
            public int startX;
            public int startY;
            public int btnWidth;
            public int btnHeight;
            public int index;
            public Control parent;
        }
    }
}
