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

        public List<ClickerLabel>[] buttons = new List<ClickerLabel>[3];

        public WindowForm()
        {
            InitializeComponent();
            InitControls();
        }

        private void WindowForm_Load(object sender, EventArgs e)
        {
            positionTimer = new System.Timers.Timer(500);
            positionTimer.Elapsed += PositionTimer_Elapsed;
            positionTimer.Start();
            ExpandState = 1;
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
            ControlsSettings s = new ControlsSettings();
            s.btnMargin = 3;
            s.startX = 21;
            s.btnSize = new Size(34, 34);
            s.parent = this;

            for (int i = 0; i < 3; i++)
            {
                s.startY = 7 + (46 * (2 - i));
                InitRow(i, s);
            }
        }

        private void InitRow(int index, ControlsSettings settings)
        {
            buttons[index] = new List<ClickerLabel>();
            for (int i = 0; i < 12; i++)
            {
                ClickerLabel l = new ClickerLabel();
                l.AutoSize = false;
                l.Size = settings.btnSize;
                l.Cursor = Cursors.Hand;
                l.BackColor = Color.Transparent;
                l.ForeColor = Color.FromArgb(220, 218, 202);
                l.TextAlign = ContentAlignment.BottomCenter;
                l.Font = new Font("Open Sans", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                string key = (index == 0 ? "F" : (index == 2 ? "NUMPAD" : "")) + (i + 1);
                int scanCode;
                SendWinKey.tryParse(key, out scanCode);
                l.Tag = scanCode;
                l.IsActive = true;
                l.Location = new Point(settings.startX + (settings.btnSize.Width + settings.btnMargin) * i + (int)Math.Floor((float)i / 4) * 5, (settings.startY));
                l.Elapsed += labelTimer_Elapsed;
                buttons[index].Add(l);
                settings.parent.Controls.Add(l);
            }
        }

        void labelTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int scanCode = int.Parse((sender as ClickerLabel).Tag.ToString());
            try
            {
                //SendWinKey.Send(gameWindow.pid, scanCode);
                //SendWinKey.Click(gameWindow.MainWindowHandle, new Point(100, 100));
                SendKeysR.Send("{4}", gameWindow.MainWindowHandle);
            }
            catch (Exception ex){ }
        }

        struct ControlsSettings
        {
            public int btnMargin;
            public int startX;
            public int startY;
            public Size btnSize;
            public Control parent;
        }

        #region Expand panels
        private int _expandState;
        private int ExpandState 
        {
            get { return _expandState; }
            set 
            { 
                value = (value - 1) % 3 + 1;
                _expandState = value;
                Height = 46 * value;
                for (int i = 0; i < 3; i++ )
                {
                    foreach (ClickerLabel l in buttons[i])
                    {
                        l.Location = new Point(l.Location.X, 7 + (46 * (_expandState - 3 + 2 - i)));
                    }
                }
            }
        }
        private void panelExpand_Click(object sender, EventArgs e)
        {
            ExpandState++;
        }
        #endregion
    }
}
