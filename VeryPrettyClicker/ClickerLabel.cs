using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeryPrettyClicker;

namespace System.Windows.Forms
{
    public class ClickerLabel : Label
    {
        #region interval + activation toggle
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                if (!value)
                {
                    Image = VeryPrettyClicker.Properties.Resources.stroke;
                }
                else
                {
                    Image = null;
                }
                checkActive();
            }
        }

        private decimal _interval;
        public decimal Interval 
        { 
            get { return _interval; } 
            set 
            { 
                _interval = value; 
                Text = _interval.ToString();
                timer.Interval = (double)_interval * 1000;
                checkActive();
            } 
        }

        public void checkActive()
        {
            if (Interval > 0 && IsActive)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }
        #endregion

        private System.Timers.Timer timer = new Timers.Timer();
        public event Timers.ElapsedEventHandler Elapsed;

        protected override void InitLayout()
        {
            base.InitLayout();
            timer.Elapsed += timer_Elapsed;
        }

        void timer_Elapsed(object sender, Timers.ElapsedEventArgs e)
        {
            Elapsed(this, e);
        }

        
        #region interval selection
        void ip_FormClosing(object sender, FormClosingEventArgs e)
        {
            IntervalPicker ip = sender as IntervalPicker;
            Interval = ip.Interval;
        }

        protected override void OnClick(EventArgs e)
        {
            MouseEventArgs ev = e as MouseEventArgs;
            if (ev.Button == Forms.MouseButtons.Right && ev.Clicks == 1)
            {
                IntervalPicker ip = new IntervalPicker();
                ip.FormClosing += ip_FormClosing;
                ip.Location = new Drawing.Point(Parent.Location.X + Location.X + ev.X - 150, Parent.Location.Y + Location.Y + ev.Y - ip.Height / 2);
                ip.Interval = Interval;
                ip.ShowDialog();
            }
            if (ev.Button == MouseButtons.Left && ev.Clicks == 1)
                IsActive = !IsActive;
            base.OnClick(e);
        }
        #endregion
    }
}
