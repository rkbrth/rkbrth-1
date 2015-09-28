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
            } 
        }

        public System.Timers.Timer Timer = new Timers.Timer();

        protected override void OnClick(EventArgs e)
        {
            MouseEventArgs ev = e as MouseEventArgs;
            if (ev.Button == Forms.MouseButtons.Right)
            {
                IntervalPicker ip = new IntervalPicker();
                ip.FormClosing += ip_FormClosing;
                ip.Location = new Drawing.Point(Parent.Location.X + Location.X + ev.X - 150, Parent.Location.Y + Location.Y + ev.Y - ip.Height / 2);
                ip.Interval = Interval;
                ip.ShowDialog();
            }
            base.OnClick(e);
        }

        void ip_FormClosing(object sender, FormClosingEventArgs e)
        {
            IntervalPicker ip = sender as IntervalPicker;
            Interval = ip.Interval;
        }
    }
}
