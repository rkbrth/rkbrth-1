using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using VeryPrettyClicker.Utilities;

namespace VeryPrettyClicker
{
    public partial class MainForm : Form
    {
        private ProcessWatcher watcher;
        private OrderedDictionary forms = new OrderedDictionary();
        private GlobalKeyboardHook hook;
        WinEventDelegate dele = null;

        public MainForm()
        {
            InitializeComponent();
            Hide();
            dele = new WinEventDelegate(WinEventProc);
            IntPtr m_hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, dele, 0, 0, WINEVENT_OUTOFCONTEXT);
        }

        /// <summary>
        /// Prevent window from Alt+Tab switch
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var Params = base.CreateParams;
                Params.ExStyle |= 0x80;
                return Params;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Location = new Point(-Width, -Height);
            watcher = new ProcessWatcher();
            watcher.Add += Watcher_Add;
            watcher.Remove += Watcher_Remove;
            watcher.Init("l2.bin");
            hook = new GlobalKeyboardHook();
            hook.addCombo(new KeyCombo(new Keys[] { Keys.LShiftKey, Keys.Q })).ComboPressed += ComboPressed_ShiftQ;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop all watchers
            watcher.Stop();

            // Remove notify icon
            if (notifyIcon != null)
            {
                notifyIcon.Visible = false;
                notifyIcon.Icon = null;
                notifyIcon.Dispose();
            }
        }

        private void ComboPressed_ShiftQ(object sender, KeyEventArgs e)
        {
            IntPtr active = GetForegroundWindow();
            foreach (WindowForm form in forms.Values)
            {
                if (form.gameWindow.MainWindowHandle == active || form.Handle == active)
                {
                    form.HotkeyActivated = !form.HotkeyActivated;
                }
            }
        }

        public void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            IntPtr active = GetForegroundWindow();
            foreach (WindowForm form in forms.Values)
            {
                form.WindowActivated = form.gameWindow.MainWindowHandle == active || form.Handle == active;
            }
        }

        private void Watcher_Add(object sender, int updated_item)
        {
            Invoke(new Action(() => { // Create new form for window
                WindowForm winForm = new WindowForm();
                // Attach window to form
                winForm.gameWindow = new GameWindow(updated_item);
                winForm.ShowInTaskbar = false;
                winForm.TopMost = true;
                

                // Set deafult start position
                winForm.StartPosition = FormStartPosition.Manual;
                Rectangle bounds = winForm.gameWindow.Bounds;
                winForm.Location = new Point(bounds.Right - winForm.Width, bounds.Top);
                // Show form
                winForm.Show();
                //winForm.Hide();
                // Add to forms collection
                forms.Add(updated_item, winForm);
            }));
        }


        private void Watcher_Remove(object sender, int updated_item)
        {
            WindowForm form = forms[(object)updated_item] as WindowForm;
            try
            {
                form.Invoke(new Action(() => { form.Dispose(); }));
            }
            catch (Exception e)
            {
                form.Dispose();
            }
            
            forms.Remove(updated_item);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const uint EVENT_SYSTEM_FOREGROUND = 3;
    }
}
