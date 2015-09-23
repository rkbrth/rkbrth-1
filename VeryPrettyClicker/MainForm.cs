using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;
using VeryPrettyClicker.Utilities;

namespace VeryPrettyClicker
{
    public partial class MainForm : Form
    {
        private ProcessWatcher watcher;
        private OrderedDictionary forms = new OrderedDictionary();

        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            watcher = new ProcessWatcher();
            watcher.Add += Watcher_Add;
            watcher.Remove += Watcher_Remove;
            watcher.Init("l2.bin");
        }

        private void Watcher_Remove(object sender, int updated_item)
        {
            WindowForm form = forms[(object)updated_item] as WindowForm;
            form.Invoke(new Action(() => { form.Close(); }));
            forms.Remove(updated_item);
        }

        private void Watcher_Add(object sender, int updated_item)
        {
            // Create new form for window
            WindowForm winForm = new WindowForm();
            // Attach window to form
            winForm.gameWindow = new GameWindow(updated_item);
            winForm.StartPosition = FormStartPosition.Manual;
            // Set deafult start position
            Rectangle bounds = winForm.gameWindow.Bounds;
            winForm.Location = new Point(bounds.Right - winForm.Width, bounds.Top);
            // Show form
            winForm.Show();
            // Add to forms collection
            forms.Add(updated_item, winForm);
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
    }
}
