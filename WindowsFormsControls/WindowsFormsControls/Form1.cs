using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            numericUpDown1.Value++;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            progressBar1.Value++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string value = textBox2.Text;
            Button button = new Button();
            button.Name = name;
            button.Text = value;

            flowLayoutPanel1.Controls.Add(button);
        }
    }
}
