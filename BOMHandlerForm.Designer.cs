namespace BOM_Handler
{
    partial class BOMHandlerForm
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
            this.productTreeView = new System.Windows.Forms.TreeView();
            this.buttonListTree = new System.Windows.Forms.Button();
            this.buttonExpandAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // productTreeView
            // 
            this.productTreeView.Location = new System.Drawing.Point(21, 12);
            this.productTreeView.Name = "productTreeView";
            this.productTreeView.Size = new System.Drawing.Size(288, 426);
            this.productTreeView.TabIndex = 0;
            // 
            // buttonListTree
            // 
            this.buttonListTree.Location = new System.Drawing.Point(315, 12);
            this.buttonListTree.Name = "buttonListTree";
            this.buttonListTree.Size = new System.Drawing.Size(75, 23);
            this.buttonListTree.TabIndex = 1;
            this.buttonListTree.Text = "Get Product";
            this.buttonListTree.UseVisualStyleBackColor = true;
            this.buttonListTree.Click += new System.EventHandler(this.buttonListTree_Click);
            // 
            // buttonExpandAll
            // 
            this.buttonExpandAll.Location = new System.Drawing.Point(396, 12);
            this.buttonExpandAll.Name = "buttonExpandAll";
            this.buttonExpandAll.Size = new System.Drawing.Size(24, 23);
            this.buttonExpandAll.TabIndex = 2;
            this.buttonExpandAll.Text = "E";
            this.buttonExpandAll.UseVisualStyleBackColor = true;
            this.buttonExpandAll.Click += new System.EventHandler(this.buttonExpandAll_Click);
            // 
            // BOMHandlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 450);
            this.Controls.Add(this.buttonExpandAll);
            this.Controls.Add(this.buttonListTree);
            this.Controls.Add(this.productTreeView);
            this.Name = "BOMHandlerForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.BOMHandlerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView productTreeView;
        private System.Windows.Forms.Button buttonListTree;
        private System.Windows.Forms.Button buttonExpandAll;
    }
}

