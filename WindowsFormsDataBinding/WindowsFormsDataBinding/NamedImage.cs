using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsDataBinding
{
    public class NamedImage
    {
        private Image image;
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        private string filename;
        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }

        public NamedImage(Image image, string filename)
        {
            Image = image;
            Filename = filename;
        }
    }
}
