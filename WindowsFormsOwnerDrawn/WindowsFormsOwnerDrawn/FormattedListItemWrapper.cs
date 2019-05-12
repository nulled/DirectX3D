using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsOwnerDrawn
{
    public class FormattedListItemWrapper
    {
        private object item;
        public object Item
        {
            get { return item; }
            set { item = value; }
        }

        private Color foreColor;
        public Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }

        private Color backColor;
        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }

        private Font font;
        public Font Font
        {
            get { return font; }
            set { font = value; }
        }

        public FormattedListItemWrapper(string fontName, Font font)
        {
            Item = fontName;
            Font = font;
        }

        public override string ToString()
        {
            if (item == null)
            {
                return string.Empty;
            }
            else
            {
                return item.ToString();
            }
        }
    }
}
