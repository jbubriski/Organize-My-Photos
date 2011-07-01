namespace OrganizeMyPhotos
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
            this.uxFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.uxSelectFolder = new System.Windows.Forms.Button();
            this.uxSelectedFolder = new System.Windows.Forms.Label();
            this.uxOrganize = new System.Windows.Forms.Button();
            this.uxOrganizeByDay = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uxDebugMode = new System.Windows.Forms.CheckBox();
            this.uxDebugOutput = new System.Windows.Forms.TextBox();
            this.uxOrganizeByMonth = new System.Windows.Forms.RadioButton();
            this.uxHowToOrganizeOptions = new System.Windows.Forms.GroupBox();
            this.uxOrganizeByYearThenMonthThenDay = new System.Windows.Forms.RadioButton();
            this.uxOrganizeByMonthThenDay = new System.Windows.Forms.RadioButton();
            this.uxOrganizeByYear = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uxFindPhotos = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.uxHowToOrganizeOptions.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxSelectFolder
            // 
            this.uxSelectFolder.Location = new System.Drawing.Point(6, 19);
            this.uxSelectFolder.Name = "uxSelectFolder";
            this.uxSelectFolder.Size = new System.Drawing.Size(99, 23);
            this.uxSelectFolder.TabIndex = 0;
            this.uxSelectFolder.Text = "Select Folder...";
            this.uxSelectFolder.UseVisualStyleBackColor = true;
            this.uxSelectFolder.Click += new System.EventHandler(this.uxSelectFolder_Click);
            // 
            // uxSelectedFolder
            // 
            this.uxSelectedFolder.AutoSize = true;
            this.uxSelectedFolder.Location = new System.Drawing.Point(6, 45);
            this.uxSelectedFolder.Name = "uxSelectedFolder";
            this.uxSelectedFolder.Size = new System.Drawing.Size(93, 13);
            this.uxSelectedFolder.TabIndex = 1;
            this.uxSelectedFolder.Text = "No folder selected";
            // 
            // uxOrganize
            // 
            this.uxOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uxOrganize.Location = new System.Drawing.Point(91, 460);
            this.uxOrganize.Name = "uxOrganize";
            this.uxOrganize.Size = new System.Drawing.Size(75, 23);
            this.uxOrganize.TabIndex = 2;
            this.uxOrganize.Text = "Organize!";
            this.uxOrganize.UseVisualStyleBackColor = true;
            this.uxOrganize.Click += new System.EventHandler(this.uxOrganize_Click);
            // 
            // uxOrganizeByDay
            // 
            this.uxOrganizeByDay.AutoSize = true;
            this.uxOrganizeByDay.Location = new System.Drawing.Point(7, 19);
            this.uxOrganizeByDay.Name = "uxOrganizeByDay";
            this.uxOrganizeByDay.Size = new System.Drawing.Size(104, 17);
            this.uxOrganizeByDay.TabIndex = 3;
            this.uxOrganizeByDay.Text = "Organize By Day";
            this.uxOrganizeByDay.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uxDebugMode);
            this.groupBox1.Location = new System.Drawing.Point(10, 275);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 52);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // uxDebugMode
            // 
            this.uxDebugMode.AutoSize = true;
            this.uxDebugMode.Checked = true;
            this.uxDebugMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uxDebugMode.Location = new System.Drawing.Point(7, 20);
            this.uxDebugMode.Name = "uxDebugMode";
            this.uxDebugMode.Size = new System.Drawing.Size(88, 17);
            this.uxDebugMode.TabIndex = 0;
            this.uxDebugMode.Text = "Debug Mode";
            this.uxDebugMode.UseVisualStyleBackColor = true;
            // 
            // uxDebugOutput
            // 
            this.uxDebugOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxDebugOutput.Location = new System.Drawing.Point(241, 12);
            this.uxDebugOutput.Multiline = true;
            this.uxDebugOutput.Name = "uxDebugOutput";
            this.uxDebugOutput.Size = new System.Drawing.Size(725, 471);
            this.uxDebugOutput.TabIndex = 5;
            // 
            // uxOrganizeByMonth
            // 
            this.uxOrganizeByMonth.AutoSize = true;
            this.uxOrganizeByMonth.Location = new System.Drawing.Point(7, 42);
            this.uxOrganizeByMonth.Name = "uxOrganizeByMonth";
            this.uxOrganizeByMonth.Size = new System.Drawing.Size(115, 17);
            this.uxOrganizeByMonth.TabIndex = 6;
            this.uxOrganizeByMonth.Text = "Organize By Month";
            this.uxOrganizeByMonth.UseVisualStyleBackColor = true;
            // 
            // uxHowToOrganizeOptions
            // 
            this.uxHowToOrganizeOptions.Controls.Add(this.uxOrganizeByYearThenMonthThenDay);
            this.uxHowToOrganizeOptions.Controls.Add(this.uxOrganizeByMonthThenDay);
            this.uxHowToOrganizeOptions.Controls.Add(this.uxOrganizeByYear);
            this.uxHowToOrganizeOptions.Controls.Add(this.uxOrganizeByDay);
            this.uxHowToOrganizeOptions.Controls.Add(this.uxOrganizeByMonth);
            this.uxHowToOrganizeOptions.Location = new System.Drawing.Point(10, 130);
            this.uxHowToOrganizeOptions.Name = "uxHowToOrganizeOptions";
            this.uxHowToOrganizeOptions.Size = new System.Drawing.Size(225, 139);
            this.uxHowToOrganizeOptions.TabIndex = 5;
            this.uxHowToOrganizeOptions.TabStop = false;
            this.uxHowToOrganizeOptions.Text = "How to Organize";
            // 
            // uxOrganizeByYearThenMonthThenDay
            // 
            this.uxOrganizeByYearThenMonthThenDay.AutoSize = true;
            this.uxOrganizeByYearThenMonthThenDay.Checked = true;
            this.uxOrganizeByYearThenMonthThenDay.Location = new System.Drawing.Point(7, 111);
            this.uxOrganizeByYearThenMonthThenDay.Name = "uxOrganizeByYearThenMonthThenDay";
            this.uxOrganizeByYearThenMonthThenDay.Size = new System.Drawing.Size(216, 17);
            this.uxOrganizeByYearThenMonthThenDay.TabIndex = 9;
            this.uxOrganizeByYearThenMonthThenDay.TabStop = true;
            this.uxOrganizeByYearThenMonthThenDay.Text = "Organize By Year, then Month, then Day";
            this.uxOrganizeByYearThenMonthThenDay.UseVisualStyleBackColor = true;
            // 
            // uxOrganizeByMonthThenDay
            // 
            this.uxOrganizeByMonthThenDay.AutoSize = true;
            this.uxOrganizeByMonthThenDay.Location = new System.Drawing.Point(7, 88);
            this.uxOrganizeByMonthThenDay.Name = "uxOrganizeByMonthThenDay";
            this.uxOrganizeByMonthThenDay.Size = new System.Drawing.Size(164, 17);
            this.uxOrganizeByMonthThenDay.TabIndex = 8;
            this.uxOrganizeByMonthThenDay.Text = "Organize By Month, then Day";
            this.uxOrganizeByMonthThenDay.UseVisualStyleBackColor = true;
            // 
            // uxOrganizeByYear
            // 
            this.uxOrganizeByYear.AutoSize = true;
            this.uxOrganizeByYear.Location = new System.Drawing.Point(7, 65);
            this.uxOrganizeByYear.Name = "uxOrganizeByYear";
            this.uxOrganizeByYear.Size = new System.Drawing.Size(107, 17);
            this.uxOrganizeByYear.TabIndex = 7;
            this.uxOrganizeByYear.Text = "Organize By Year";
            this.uxOrganizeByYear.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uxSelectFolder);
            this.groupBox2.Controls.Add(this.uxSelectedFolder);
            this.groupBox2.Location = new System.Drawing.Point(10, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 112);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Folders";
            // 
            // uxFindPhotos
            // 
            this.uxFindPhotos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uxFindPhotos.Location = new System.Drawing.Point(10, 460);
            this.uxFindPhotos.Name = "uxFindPhotos";
            this.uxFindPhotos.Size = new System.Drawing.Size(75, 23);
            this.uxFindPhotos.TabIndex = 7;
            this.uxFindPhotos.Text = "Find photos!";
            this.uxFindPhotos.UseVisualStyleBackColor = true;
            this.uxFindPhotos.Click += new System.EventHandler(this.uxFindPhotos_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 495);
            this.Controls.Add(this.uxFindPhotos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.uxHowToOrganizeOptions);
            this.Controls.Add(this.uxDebugOutput);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.uxOrganize);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.uxHowToOrganizeOptions.ResumeLayout(false);
            this.uxHowToOrganizeOptions.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog uxFolderBrowserDialog;
        private System.Windows.Forms.Button uxSelectFolder;
        private System.Windows.Forms.Label uxSelectedFolder;
        private System.Windows.Forms.Button uxOrganize;
        private System.Windows.Forms.RadioButton uxOrganizeByDay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox uxDebugMode;
        private System.Windows.Forms.TextBox uxDebugOutput;
        private System.Windows.Forms.RadioButton uxOrganizeByMonth;
        private System.Windows.Forms.GroupBox uxHowToOrganizeOptions;
        private System.Windows.Forms.RadioButton uxOrganizeByYearThenMonthThenDay;
        private System.Windows.Forms.RadioButton uxOrganizeByMonthThenDay;
        private System.Windows.Forms.RadioButton uxOrganizeByYear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button uxFindPhotos;
    }
}

