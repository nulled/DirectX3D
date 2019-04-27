using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                MessageBox.Show("Checked");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "Test input";
            textBox1.ReadOnly = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Contacts.txt");
            sw.WriteLine("Matthew Kukowski1");
            sw.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Contacts.txt");
            sw.WriteLine("Matthew Kukowski2");
            sw.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Contacts.txt", true);
            sw.WriteLine("Matthew Kukowski3");
            sw.Close();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
