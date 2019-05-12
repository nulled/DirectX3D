using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace WindowsFormsOwnerDrawn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            ListBox list = (ListBox)sender;
            FormattedListItemWrapper item = list.Items[e.Index] as FormattedListItemWrapper;

            if (item == null || item.Font == null)
            {
                e.ItemHeight = 15;
            }
            else
            {
                Font font = item.Font;
                e.ItemHeight = font.Height;
            }
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox list = (ListBox)sender;
            FormattedListItemWrapper item = list.Items[e.Index] as FormattedListItemWrapper;

            Font font = null;
            Color foreColor = Color.Empty;
            Color backColor = Color.Empty;
            if (item != null)
            {
                font = item.Font;
                foreColor = item.ForeColor;
                backColor = item.BackColor;
            }

            if (font == null)
            {
                font = list.Font;
            }

            Brush brush;
            if (foreColor == Color.Empty)
            {
                brush = Brushes.Black;
            }
            else
            {
                brush = new SolidBrush(item.ForeColor);
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                brush = Brushes.White;
            }
            
            if (backColor == Color.Empty)
            {
                e.DrawBackground();
            }
            else
            {
                Brush brushBackground = new SolidBrush(item.BackColor);
                e.Graphics.FillRectangle(brushBackground, e.Bounds);
            }

            string text = list.Items[e.Index].ToString();
            e.Graphics.DrawString(text, font, brush, e.Bounds.X, e.Bounds.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.MeasureItem += new MeasureItemEventHandler(listBox1_MeasureItem);
            listBox1.DrawItem += new DrawItemEventHandler(listBox1_DrawItem);

            InstalledFontCollection families = new InstalledFontCollection();

            foreach (FontFamily family in families.Families)
            {
                try
                {
                    Font font = new Font(family.Name, 11);
                    FormattedListItemWrapper item = new FormattedListItemWrapper(family.Name, font);
                    listBox1.Items.Add(item);
                }
                catch (ArgumentException err)
                {
                    // ignore this font
                }
            }
        }
    }
}
