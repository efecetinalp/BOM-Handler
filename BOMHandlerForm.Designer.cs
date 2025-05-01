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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BOMHandlerForm));
            this.productTreeView = new System.Windows.Forms.TreeView();
            this.buttonListTree = new System.Windows.Forms.Button();
            this.buttonExpandAll = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.productTreeImages = new System.Windows.Forms.ImageList(this.components);
            this.buttonExportToExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // productTreeView
            // 
            this.productTreeView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productTreeView.Location = new System.Drawing.Point(12, 60);
            this.productTreeView.Name = "productTreeView";
            this.productTreeView.Size = new System.Drawing.Size(358, 520);
            this.productTreeView.TabIndex = 0;
            // 
            // buttonListTree
            // 
            this.buttonListTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonListTree.Location = new System.Drawing.Point(229, 31);
            this.buttonListTree.Name = "buttonListTree";
            this.buttonListTree.Size = new System.Drawing.Size(75, 23);
            this.buttonListTree.TabIndex = 1;
            this.buttonListTree.Text = "Get Product";
            this.buttonListTree.UseVisualStyleBackColor = true;
            this.buttonListTree.Click += new System.EventHandler(this.buttonListTree_Click);
            // 
            // buttonExpandAll
            // 
            this.buttonExpandAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExpandAll.Location = new System.Drawing.Point(310, 31);
            this.buttonExpandAll.Name = "buttonExpandAll";
            this.buttonExpandAll.Size = new System.Drawing.Size(24, 23);
            this.buttonExpandAll.TabIndex = 2;
            this.buttonExpandAll.Text = "E";
            this.buttonExpandAll.UseVisualStyleBackColor = true;
            this.buttonExpandAll.Click += new System.EventHandler(this.buttonExpandAll_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.FlatAppearance.BorderSize = 0;
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuit.Image = ((System.Drawing.Image)(resources.GetObject("buttonQuit.Image")));
            this.buttonQuit.Location = new System.Drawing.Point(362, 4);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.buttonQuit.Size = new System.Drawing.Size(16, 16);
            this.buttonQuit.TabIndex = 3;
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // productTreeImages
            // 
            this.productTreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("productTreeImages.ImageStream")));
            this.productTreeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.productTreeImages.Images.SetKeyName(0, "part_s.png");
            this.productTreeImages.Images.SetKeyName(1, "product_s.png");
            // 
            // buttonExportToExcel
            // 
            this.buttonExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExportToExcel.Location = new System.Drawing.Point(346, 31);
            this.buttonExportToExcel.Name = "buttonExportToExcel";
            this.buttonExportToExcel.Size = new System.Drawing.Size(24, 23);
            this.buttonExportToExcel.TabIndex = 4;
            this.buttonExportToExcel.Text = "E";
            this.buttonExportToExcel.UseVisualStyleBackColor = true;
            this.buttonExportToExcel.Click += new System.EventHandler(this.buttonExportToExcel_Click);
            // 
            // BOMHandlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(382, 592);
            this.Controls.Add(this.buttonExportToExcel);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonExpandAll);
            this.Controls.Add(this.buttonListTree);
            this.Controls.Add(this.productTreeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BOMHandlerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.BOMHandlerForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BOMHandlerForm_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView productTreeView;
        private System.Windows.Forms.Button buttonListTree;
        private System.Windows.Forms.Button buttonExpandAll;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.ImageList productTreeImages;
        private System.Windows.Forms.Button buttonExportToExcel;
    }
}

