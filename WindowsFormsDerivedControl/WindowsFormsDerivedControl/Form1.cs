using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDerivedControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Project projectA = new Project("Migration to .NET", "Change existing products to take advantage of new windows forms controls", Project.StatusType.InProgress);
            Project projectB = new Project("Revamp pricing site", "Enhance the pricing website with ASP.NET", Project.StatusType.Unassigned);

            tree.AddProject(projectA);
            tree.AddProject(projectB);
        }
    }
}
