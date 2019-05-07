using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDataBinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Product> products = StoreDB.GetProducts();

            listBox1.DataSource = products;
            listBox1.DisplayMember = "ModelName";
            customPictureBox1.Directory = @"C:\Users\nulled\Documents";
        }

        private void ListBox1_Click(object sender, EventArgs e)
        {
            Product product = (Product)listBox1.SelectedItem;
            MessageBox.Show(String.Format("Costs {0:C}", product.UnitCost));
        }

        private void CustomPictureBox1_PictureSelected(object sender, PictureSelectedEventArgs e)
        {
            MessageBox.Show("You Chose " + e.FileName);
        }
    }
}
