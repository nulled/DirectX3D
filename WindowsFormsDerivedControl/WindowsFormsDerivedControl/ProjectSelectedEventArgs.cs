using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsDerivedControl
{
    public class ProjectSelectedEventArgs
    {
        private Project project;
        public Project Project
        {
            get { return project; }
            set { project = value; }
        }

        public ProjectSelectedEventArgs(Project project)
        {
            Project = project;
        }
    }
}
