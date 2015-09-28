using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VeryPrettyClicker.Utilities
{
    public class KeyCombo
    {
        private Keys[] keys;
        private int level = 0;

        public event KeyEventHandler ComboPressed;
        public KeyCombo(Keys[] keys)
        {
            this.keys = keys;
        }

        public void KeyDown(Keys key)
        {
            if (level == keys.Count())
                return;

            if (keys[level] == key)
                level++;
            else
                level = 0;

            if (level == keys.Count())
                ComboPressed(this, new KeyEventArgs(keys.Last()));
        }

        public void KeyUp(Keys k)
        {
            if (level > 0)
                level--;
        }
    }
}
