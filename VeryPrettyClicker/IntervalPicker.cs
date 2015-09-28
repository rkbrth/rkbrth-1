using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeryPrettyClicker
{
    public partial class IntervalPicker : Form
    {
        private decimal _interval;
        public decimal Interval 
        {
            get { return _interval; }
            set 
            { 
                _interval = value;
                try
                {
                    numericUpDown.Value = value;
                }
                catch { }
            }
        }

        public IntervalPicker()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(255, 50, 50, 50);
            StartPosition = FormStartPosition.Manual;
            ActiveControl = numericUpDown;
        }

        private void IntervalPicker_Load(object sender, EventArgs e)
        {
            numericUpDown.Focus();
            if (_interval <= numericUpDown.Minimum)
            {
                _interval = numericUpDown.Value;
            }
            else
            {
                numericUpDown.Value = _interval;
            }
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

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            _interval = numericUpDown.Value;
            Close();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _interval = (sender as NumericUpDown).Value;
        }
    }
}
