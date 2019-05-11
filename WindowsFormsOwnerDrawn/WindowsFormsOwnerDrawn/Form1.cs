using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            e.ItemHeight = 25;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            Brush brush;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                brush = Brushes.Red;
            }
            else
            {
                brush = Brushes.Black;
            }

            string text = ((ListBox)sender).Items[e.Index].ToString();

            e.Graphics.DrawString(text, ((Control)sender).Font, brush, e.Bounds.X, e.Bounds.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.MeasureItem += new MeasureItemEventHandler(listBox1_MeasureItem);
            listBox1.DrawItem += new DrawItemEventHandler(listBox1_DrawItem);

            listBox1.BeginUpdate();
            listBox1.Items.Add("One");
            listBox1.Items.Add("Two");
            listBox1.Items.Add("Three");
            listBox1.EndUpdate();
        }
    }
}
