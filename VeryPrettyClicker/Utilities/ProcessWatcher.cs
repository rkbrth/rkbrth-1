using System;
using System.Data;
using System.Linq;
using System.Management;
using System.Diagnostics;
using System.Collections.Specialized;

namespace VeryPrettyClicker.Utilities
{
    public class ProcessWatcher
    {
        public event WatcherHandler Add;
        public event WatcherHandler Remove;
        public delegate void WatcherHandler(object sender, int updated_item);

        private ManagementEventWatcher startWatch;
        private ManagementEventWatcher stopWatch;
        private string process_name;

        public void Init(string process_name)
        {
            this.process_name = process_name;

            foreach (Process process in Process.GetProcessesByName(process_name))
            {
                if (Add != null)
                    Add(this, process.Id);
            }

            startWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
            startWatch.EventArrived += new EventArrivedEventHandler(startWatch_EventArrived);
            startWatch.Start();

            stopWatch = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
            stopWatch.EventArrived += new EventArrivedEventHandler(stopWatch_EventArrived);
            stopWatch.Start();
        }

        public void Stop()
        {
            if (startWatch != null)
                startWatch.Stop();
            if (stopWatch != null)
                stopWatch.Stop();
        }

        public bool Exists(int pid)
        {
            Process test;
            try
            {
                test = Process.GetProcessById(pid);
            } 
            catch
            {
                return false;
            }
            return test.MainWindowHandle != IntPtr.Zero && test.ProcessName.ToLower() == process_name.ToLower();
        }

        private void stopWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            if (e.NewEvent.Properties["ProcessName"].Value.ToString().ToLower() == this.process_name.ToLower())
            {
                int pid = int.Parse(e.NewEvent.Properties["ProcessID"].Value.ToString());
                if (Remove != null)
                    Remove(this, pid);
            }
        }

        private void startWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            if (e.NewEvent.Properties["ProcessName"].Value.ToString().ToLower() == this.process_name.ToLower())
            {
                int key = int.Parse(e.NewEvent.Properties["ProcessID"].Value.ToString());
                if (Add != null)
                    Add(this, key);
            }
        }
    }
}