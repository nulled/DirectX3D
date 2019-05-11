using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDerivedControl
{
    public class ProjectTree : TreeView
    {
        private ImageList imagesTree;
        private System.ComponentModel.IContainer components;
        public delegate void ProjectSelectedEventHandler(object sender, ProjectSelectedEventArgs e);
        public event ProjectSelectedEventHandler ProjectSelected;

        private enum NodeImages
        {
            UnassignedGroup = 0, InProgressGroup = 1, ClosedGroup = 3,
            NormalProject = 4, SelectedProject = 5
        }

        private TreeNode nodeUnassigned;
        public TreeNode UnassignedProjectNode
        {
            get { return nodeUnassigned; }
        }

        private TreeNode nodeInProgress;
        public TreeNode InProgressProjectNode
        {
            get { return nodeInProgress; }
        }

        private TreeNode nodeClosed;
        public TreeNode ClosedProjectNode
        {
            get { return nodeClosed; }
        }

        public ProjectTree() : base()
        {
            ImageList = imagesTree;

            nodeUnassigned = new TreeNode("Unassigned", (int)NodeImages.UnassignedGroup, (int)NodeImages.UnassignedGroup);
            nodeInProgress = new TreeNode("In Progress", (int)NodeImages.InProgressGroup, (int)NodeImages.InProgressGroup);
            nodeClosed = new TreeNode("Closed", (int)NodeImages.ClosedGroup, (int)NodeImages.ClosedGroup);

            Nodes.Add(nodeUnassigned);
            Nodes.Add(nodeInProgress);
            Nodes.Add(nodeClosed);
        }

        public void AddProject(Project project)
        {
            TreeNode nodeNew = new TreeNode(project.Name, (int)NodeImages.NormalProject, (int)NodeImages.SelectedProject);

            nodeNew.Tag = project;

            switch (project.Status)
            {
                case Project.StatusType.Unassigned:
                    nodeUnassigned.Nodes.Add(nodeNew);
                    break;
                case Project.StatusType.InProgress:
                    nodeInProgress.Nodes.Add(nodeNew);
                    break;
                case Project.StatusType.Closed:
                    nodeClosed.Nodes.Add(nodeNew);
                    break;
            }
        }

        public Project GetProject(string name, Project.StatusType status)
        {
            TreeNodeCollection nodes = null;

            switch (status)
            {
                case Project.StatusType.Unassigned:
                    nodes = nodeUnassigned.Nodes;
                    break;
                case Project.StatusType.InProgress:
                    nodes = nodeInProgress.Nodes;
                    break;
                case Project.StatusType.Closed:
                    nodes = nodeClosed.Nodes;
                    break;
            }

            foreach (TreeNode node in nodes)
            {
                if (node.Text == name)
                {
                    Project project = node.Tag as Project;
                    if (project != null) return project;
                }
            }

            return null;
        }

        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            base.OnAfterSelect(e);

            if (ProjectSelected != null)
            {
                if (e.Node.Level == 1)
                {
                    Project project = (Project)e.Node.Tag;
                    ProjectSelectedEventArgs arg = new ProjectSelectedEventArgs(project);
                    ProjectSelected(this, arg);
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imagesTree = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imagesTree
            // 
            this.imagesTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imagesTree.ImageSize = new System.Drawing.Size(16, 16);
            this.imagesTree.TransparentColor = System.Drawing.Color.Transparent;
            this.ResumeLayout(false);

        }
    }
}
