namespace OrganizeMyPhotos
{
    partial class SetFolderDialog
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
            this.uxOk = new System.Windows.Forms.Button();
            this.uxCancel = new System.Windows.Forms.Button();
            this.uxFolderPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // uxOk
            // 
            this.uxOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uxOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxOk.Location = new System.Drawing.Point(124, 38);
            this.uxOk.Name = "uxOk";
            this.uxOk.Size = new System.Drawing.Size(75, 23);
            this.uxOk.TabIndex = 0;
            this.uxOk.Text = "OK";
            this.uxOk.UseVisualStyleBackColor = true;
            // 
            // uxCancel
            // 
            this.uxCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uxCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxCancel.Location = new System.Drawing.Point(205, 38);
            this.uxCancel.Name = "uxCancel";
            this.uxCancel.Size = new System.Drawing.Size(75, 23);
            this.uxCancel.TabIndex = 1;
            this.uxCancel.Text = "Cancel";
            this.uxCancel.UseVisualStyleBackColor = true;
            // 
            // uxFolderPath
            // 
            this.uxFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxFolderPath.Location = new System.Drawing.Point(12, 12);
            this.uxFolderPath.Name = "uxFolderPath";
            this.uxFolderPath.Size = new System.Drawing.Size(268, 20);
            this.uxFolderPath.TabIndex = 2;
            // 
            // SetFolderDialog
            // 
            this.AcceptButton = this.uxOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.uxCancel;
            this.ClientSize = new System.Drawing.Size(292, 73);
            this.Controls.Add(this.uxFolderPath);
            this.Controls.Add(this.uxCancel);
            this.Controls.Add(this.uxOk);
            this.MaximumSize = new System.Drawing.Size(1000, 100);
            this.MinimumSize = new System.Drawing.Size(300, 100);
            this.Name = "SetFolderDialog";
            this.Text = "Set Folder Manually";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxOk;
        private System.Windows.Forms.Button uxCancel;
        private System.Windows.Forms.TextBox uxFolderPath;
    }
}