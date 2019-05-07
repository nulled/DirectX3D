using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsDataBinding
{
    public partial class CustomPictureBox : UserControl
    {
        public CustomPictureBox()
        {
            InitializeComponent();
        }

        private string directory;
        private int dimension;
        private int border = 5;
        private int spacing;

        private List<NamedImage> images = new List<NamedImage>();

        private PictureBox picSelected;
        public delegate void PictureSelectedDelegate(object sender, PictureSelectedEventArgs e);
        public event PictureSelectedDelegate PictureSelected;

        public string Directory
        {
            get { return directory; }
            set
            {
                directory = value;
                GetImages();
                UpdateDisplay();
            }
        }

        public int Dimension
        {
            get { return dimension; }
            set
            {
                dimension = value;
                UpdateDisplay();
            }
        }

        public int Spacing
        {
            get { return spacing; }
            set
            {
                spacing = value;
                UpdateDisplay();
            }
        }

        private void GetImages()
        {
            if (directory.Length != 0)
            {
                images.Clear();
                DirectoryInfo dir = new DirectoryInfo(directory);
                foreach (FileInfo file in dir.GetFiles("*.jpg"))
                {
                    //MessageBox.Show(file.FullName);
                    images.Add(new NamedImage(Image.FromFile(file.FullName), file.FullName));
                }
            }
        }

        private void UpdateDisplay()
        {
            panel1.SuspendLayout();

            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }

            panel1.Controls.Clear();

            int row = border, col = border;

            foreach (NamedImage image in images)
            {
                PictureBox pic = new PictureBox();
                pic.Image = image.Image;
                pic.Tag = image.Filename;
                pic.Size = new Size(dimension, dimension);
                pic.Location = new Point(col, row);
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Click += new EventHandler(this.pic_Click);

                panel1.Controls.Add(pic);

                col += dimension + spacing;

                if ((col + dimension + spacing + border) > this.Width)
                {
                    col = border;
                    row += dimension + spacing;
                }
            }

            panel1.ResumeLayout();
        }

        public void RefreshImages()
        {
            GetImages();
            UpdateDisplay();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateDisplay();
            base.OnSizeChanged(e);
        }

        private void pic_Click(object sender, System.EventArgs e)
        {
            if (picSelected != null)
                picSelected.BorderStyle = BorderStyle.FixedSingle;

            picSelected = (PictureBox)sender;
            picSelected.BorderStyle = BorderStyle.Fixed3D;

            PictureSelectedEventArgs args = new PictureSelectedEventArgs((string)picSelected.Tag, picSelected.Image);
            if (PictureSelected != null)
                PictureSelected(this, args);
        }
    }
}
