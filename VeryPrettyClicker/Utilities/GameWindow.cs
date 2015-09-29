using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace VeryPrettyClicker.Utilities
{
    public class GameWindow
    {
        public int pid;
        Process process;

        public GameWindow(int pid)
        {
            this.pid = pid;
            process = Process.GetProcessById(pid);
        }

        public Rectangle Bounds
        {
            get
            {
                User32.RECT bounds = new User32.RECT();
                User32.GetWindowRect(process.MainWindowHandle, ref bounds);
                return new Rectangle(bounds.left, bounds.top, bounds.right - bounds.left, bounds.bottom - bounds.top);
            }
        }

        public IntPtr MainWindowHandle { get { process = Process.GetProcessById(pid); return process.MainWindowHandle; } }
    }
}
