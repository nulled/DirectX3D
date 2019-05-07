using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsDataBinding
{
    public class PictureSelectedEventArgs : EventArgs
    {
        public Image Image { get; set; }

        public string FileName { get; set; }

        public PictureSelectedEventArgs(string fileName, Image image)
        {
            FileName = fileName;
            Image = image;
        }
    }
}
