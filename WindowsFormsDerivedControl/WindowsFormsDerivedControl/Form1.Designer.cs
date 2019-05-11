namespace WindowsFormsDerivedControl
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Unassigned", 0, 0);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("In Progress", 1, 1);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Closed", 3, 3);
            this.tree = new WindowsFormsDerivedControl.ProjectTree();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.Location = new System.Drawing.Point(13, 13);
            this.tree.Name = "tree";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "";
            treeNode1.SelectedImageIndex = 0;
            treeNode1.Text = "Unassigned";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Text = "In Progress";
            treeNode3.ImageIndex = 3;
            treeNode3.Name = "";
            treeNode3.SelectedImageIndex = 3;
            treeNode3.Text = "Closed";
            this.tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.tree.Size = new System.Drawing.Size(253, 330);
            this.tree.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tree);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ProjectTree tree;
    }
}

