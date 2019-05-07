namespace WindowsFormsDataBinding
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.customPictureBox1 = new WindowsFormsDataBinding.CustomPictureBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(311, 147);
            this.listBox1.TabIndex = 0;
            this.listBox1.Click += new System.EventHandler(this.ListBox1_Click);
            // 
            // customPictureBox1
            // 
            this.customPictureBox1.Dimension = 100;
            this.customPictureBox1.Directory = "";
            this.customPictureBox1.Location = new System.Drawing.Point(13, 194);
            this.customPictureBox1.Name = "customPictureBox1";
            this.customPictureBox1.Size = new System.Drawing.Size(529, 214);
            this.customPictureBox1.Spacing = 1;
            this.customPictureBox1.TabIndex = 1;
            this.customPictureBox1.PictureSelected += new WindowsFormsDataBinding.CustomPictureBox.PictureSelectedDelegate(this.CustomPictureBox1_PictureSelected);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customPictureBox1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private CustomPictureBox customPictureBox1;
    }
}

