namespace App_UI
{
    partial class InstantGenerationTask
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerLabel = new System.Windows.Forms.Label();
            this.header2Label = new System.Windows.Forms.Label();
            this.serverInfoDataLabel = new System.Windows.Forms.Label();
            this.gernerationOptionLabel = new System.Windows.Forms.Label();
            this.fromDateLabel = new System.Windows.Forms.Label();
            this.fromDateCalendar = new System.Windows.Forms.MonthCalendar();
            this.toDateLabel = new System.Windows.Forms.Label();
            this.toDateCalendar = new System.Windows.Forms.MonthCalendar();
            this.selectFieldLabel = new System.Windows.Forms.Label();
            this.outputLoactionLabel = new System.Windows.Forms.Label();
            this.generateBtn = new System.Windows.Forms.Button();
            this.filePathDataLabel = new System.Windows.Forms.Label();
            this.getFileExplorerBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.selectedColListBox = new System.Windows.Forms.ListBox();
            this.header3Label = new System.Windows.Forms.Label();
            this.statusUpdateLabel = new System.Windows.Forms.Label();
            this.quickSelectLabel = new System.Windows.Forms.Label();
            this.past30Btn = new System.Windows.Forms.Button();
            this.past60Btn = new System.Windows.Forms.Button();
            this.past90Btn = new System.Windows.Forms.Button();
            this.spaceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AccessibleName = "headerLabel";
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.Location = new System.Drawing.Point(40, -293);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(319, 46);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Instant Generation";
            // 
            // header2Label
            // 
            this.header2Label.AccessibleName = "header2Label";
            this.header2Label.AutoSize = true;
            this.header2Label.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.header2Label.Location = new System.Drawing.Point(67, -222);
            this.header2Label.Name = "header2Label";
            this.header2Label.Size = new System.Drawing.Size(222, 31);
            this.header2Label.TabIndex = 1;
            this.header2Label.Text = "Server Information: ";
            // 
            // serverInfoDataLabel
            // 
            this.serverInfoDataLabel.AccessibleName = "serverInfoDataLabel";
            this.serverInfoDataLabel.AutoSize = true;
            this.serverInfoDataLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.serverInfoDataLabel.Location = new System.Drawing.Point(295, -222);
            this.serverInfoDataLabel.Name = "serverInfoDataLabel";
            this.serverInfoDataLabel.Size = new System.Drawing.Size(170, 28);
            this.serverInfoDataLabel.TabIndex = 2;
            this.serverInfoDataLabel.Text = "<Server Address>";
            // 
            // gernerationOptionLabel
            // 
            this.gernerationOptionLabel.AccessibleName = "gernerationOptionLabel";
            this.gernerationOptionLabel.AutoSize = true;
            this.gernerationOptionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.gernerationOptionLabel.Location = new System.Drawing.Point(67, -165);
            this.gernerationOptionLabel.Name = "gernerationOptionLabel";
            this.gernerationOptionLabel.Size = new System.Drawing.Size(229, 31);
            this.gernerationOptionLabel.TabIndex = 3;
            this.gernerationOptionLabel.Text = "Generation Options: ";
            // 
            // fromDateLabel
            // 
            this.fromDateLabel.AccessibleName = "fromDateLabel";
            this.fromDateLabel.AutoSize = true;
            this.fromDateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fromDateLabel.Location = new System.Drawing.Point(93, -84);
            this.fromDateLabel.Name = "fromDateLabel";
            this.fromDateLabel.Size = new System.Drawing.Size(62, 28);
            this.fromDateLabel.TabIndex = 4;
            this.fromDateLabel.Text = "From:";
            // 
            // fromDateCalendar
            // 
            this.fromDateCalendar.AccessibleName = "fromDateCal";
            this.fromDateCalendar.Location = new System.Drawing.Point(153, -83);
            this.fromDateCalendar.MaxSelectionCount = 1;
            this.fromDateCalendar.Name = "fromDateCalendar";
            this.fromDateCalendar.TabIndex = 5;
            // 
            // toDateLabel
            // 
            this.toDateLabel.AccessibleName = "toDateLabel";
            this.toDateLabel.AutoSize = true;
            this.toDateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toDateLabel.Location = new System.Drawing.Point(430, -84);
            this.toDateLabel.Name = "toDateLabel";
            this.toDateLabel.Size = new System.Drawing.Size(36, 28);
            this.toDateLabel.TabIndex = 6;
            this.toDateLabel.Text = "To:";
            // 
            // toDateCalendar
            // 
            this.toDateCalendar.AccessibleName = "toDateCal";
            this.toDateCalendar.Location = new System.Drawing.Point(466, -83);
            this.toDateCalendar.MaxSelectionCount = 1;
            this.toDateCalendar.Name = "toDateCalendar";
            this.toDateCalendar.TabIndex = 7;
            // 
            // selectFieldLabel
            // 
            this.selectFieldLabel.AccessibleName = "selectFieldLabel";
            this.selectFieldLabel.AutoSize = true;
            this.selectFieldLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectFieldLabel.Location = new System.Drawing.Point(93, 144);
            this.selectFieldLabel.Name = "selectFieldLabel";
            this.selectFieldLabel.Size = new System.Drawing.Size(142, 28);
            this.selectFieldLabel.TabIndex = 8;
            this.selectFieldLabel.Text = "Selected Field: ";
            // 
            // outputLoactionLabel
            // 
            this.outputLoactionLabel.AccessibleName = "outputLoactionLabel";
            this.outputLoactionLabel.AutoSize = true;
            this.outputLoactionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.outputLoactionLabel.Location = new System.Drawing.Point(93, 186);
            this.outputLoactionLabel.Name = "outputLoactionLabel";
            this.outputLoactionLabel.Size = new System.Drawing.Size(164, 28);
            this.outputLoactionLabel.TabIndex = 10;
            this.outputLoactionLabel.Text = "Output Location: ";
            // 
            // generateBtn
            // 
            this.generateBtn.AccessibleName = "generateBtn";
            this.generateBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.generateBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.generateBtn.Location = new System.Drawing.Point(265, 235);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(120, 48);
            this.generateBtn.TabIndex = 12;
            this.generateBtn.Text = "Generate";
            this.generateBtn.UseVisualStyleBackColor = false;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // filePathDataLabel
            // 
            this.filePathDataLabel.AccessibleName = "filePathLabel";
            this.filePathDataLabel.AutoSize = true;
            this.filePathDataLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filePathDataLabel.Location = new System.Drawing.Point(417, 191);
            this.filePathDataLabel.Name = "filePathDataLabel";
            this.filePathDataLabel.Size = new System.Drawing.Size(183, 25);
            this.filePathDataLabel.TabIndex = 13;
            this.filePathDataLabel.Text = "<Select Default Path>";
            // 
            // getFileExplorerBtn
            // 
            this.getFileExplorerBtn.AccessibleName = "getFileExplorerBtn";
            this.getFileExplorerBtn.Location = new System.Drawing.Point(263, 189);
            this.getFileExplorerBtn.Name = "getFileExplorerBtn";
            this.getFileExplorerBtn.Size = new System.Drawing.Size(134, 29);
            this.getFileExplorerBtn.TabIndex = 14;
            this.getFileExplorerBtn.Text = "Open Folder";
            this.getFileExplorerBtn.UseVisualStyleBackColor = true;
            this.getFileExplorerBtn.Click += new System.EventHandler(this.getFileExplorerBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.AccessibleName = "cancelBtn";
            this.cancelBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelBtn.Location = new System.Drawing.Point(432, 235);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(120, 48);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Back";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // selectedColListBox
            // 
            this.selectedColListBox.AccessibleName = "selectedColListBox";
            this.selectedColListBox.FormattingEnabled = true;
            this.selectedColListBox.ItemHeight = 20;
            this.selectedColListBox.Location = new System.Drawing.Point(241, 148);
            this.selectedColListBox.MultiColumn = true;
            this.selectedColListBox.Name = "selectedColListBox";
            this.selectedColListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.selectedColListBox.Size = new System.Drawing.Size(217, 24);
            this.selectedColListBox.TabIndex = 37;
            // 
            // header3Label
            // 
            this.header3Label.AccessibleName = "header3Label";
            this.header3Label.AutoSize = true;
            this.header3Label.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.header3Label.Location = new System.Drawing.Point(67, 300);
            this.header3Label.Name = "header3Label";
            this.header3Label.Size = new System.Drawing.Size(174, 31);
            this.header3Label.TabIndex = 38;
            this.header3Label.Text = "Process Status: ";
            // 
            // statusUpdateLabel
            // 
            this.statusUpdateLabel.AccessibleName = "statusUpdateLabel";
            this.statusUpdateLabel.AutoSize = true;
            this.statusUpdateLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusUpdateLabel.Location = new System.Drawing.Point(247, 305);
            this.statusUpdateLabel.Name = "statusUpdateLabel";
            this.statusUpdateLabel.Size = new System.Drawing.Size(147, 25);
            this.statusUpdateLabel.TabIndex = 39;
            this.statusUpdateLabel.Text = "<Status Update>";
            // 
            // quickSelectLabel
            // 
            this.quickSelectLabel.AccessibleName = "quickSelectLabel";
            this.quickSelectLabel.AutoSize = true;
            this.quickSelectLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.quickSelectLabel.Location = new System.Drawing.Point(93, -125);
            this.quickSelectLabel.Name = "quickSelectLabel";
            this.quickSelectLabel.Size = new System.Drawing.Size(123, 28);
            this.quickSelectLabel.TabIndex = 40;
            this.quickSelectLabel.Text = "Quick Select:";
            // 
            // past30Btn
            // 
            this.past30Btn.AccessibleName = "past30Btn";
            this.past30Btn.Location = new System.Drawing.Point(222, -122);
            this.past30Btn.Name = "past30Btn";
            this.past30Btn.Size = new System.Drawing.Size(111, 29);
            this.past30Btn.TabIndex = 41;
            this.past30Btn.Text = "Past 30 Days";
            this.past30Btn.UseVisualStyleBackColor = true;
            this.past30Btn.Click += new System.EventHandler(this.past30Btn_Click);
            // 
            // past60Btn
            // 
            this.past60Btn.AccessibleName = "past60Btn";
            this.past60Btn.Location = new System.Drawing.Point(354, -122);
            this.past60Btn.Name = "past60Btn";
            this.past60Btn.Size = new System.Drawing.Size(111, 29);
            this.past60Btn.TabIndex = 42;
            this.past60Btn.Text = "Past 60 Days";
            this.past60Btn.UseVisualStyleBackColor = true;
            this.past60Btn.Visible = false;
            this.past60Btn.Click += new System.EventHandler(this.past60Btn_Click);
            // 
            // past90Btn
            // 
            this.past90Btn.AccessibleName = "past90Btn";
            this.past90Btn.Location = new System.Drawing.Point(487, -122);
            this.past90Btn.Name = "past90Btn";
            this.past90Btn.Size = new System.Drawing.Size(111, 29);
            this.past90Btn.TabIndex = 43;
            this.past90Btn.Text = "Past 90 Days";
            this.past90Btn.UseVisualStyleBackColor = true;
            this.past90Btn.Visible = false;
            this.past90Btn.Click += new System.EventHandler(this.past90Btn_Click);
            // 
            // spaceLabel
            // 
            this.spaceLabel.AccessibleName = "spaceLabel";
            this.spaceLabel.AutoSize = true;
            this.spaceLabel.Location = new System.Drawing.Point(230, 662);
            this.spaceLabel.Name = "spaceLabel";
            this.spaceLabel.Size = new System.Drawing.Size(21, 20);
            this.spaceLabel.TabIndex = 36;
            this.spaceLabel.Text = "   ";
            // 
            // InstantGenerationTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 684);
            this.Controls.Add(this.past90Btn);
            this.Controls.Add(this.past60Btn);
            this.Controls.Add(this.past30Btn);
            this.Controls.Add(this.quickSelectLabel);
            this.Controls.Add(this.statusUpdateLabel);
            this.Controls.Add(this.header3Label);
            this.Controls.Add(this.selectedColListBox);
            this.Controls.Add(this.spaceLabel);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.getFileExplorerBtn);
            this.Controls.Add(this.filePathDataLabel);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.outputLoactionLabel);
            this.Controls.Add(this.selectFieldLabel);
            this.Controls.Add(this.toDateCalendar);
            this.Controls.Add(this.toDateLabel);
            this.Controls.Add(this.fromDateCalendar);
            this.Controls.Add(this.fromDateLabel);
            this.Controls.Add(this.gernerationOptionLabel);
            this.Controls.Add(this.serverInfoDataLabel);
            this.Controls.Add(this.header2Label);
            this.Controls.Add(this.headerLabel);
            this.Name = "InstantGenerationTask";
            this.Text = "InstantGenerationOptionForm";
            this.Load += new System.EventHandler(this.InstantGenerationOptionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label headerLabel;
        private Label header2Label;
        private Label serverInfoDataLabel;
        private Label gernerationOptionLabel;
        private Label fromDateLabel;
        private MonthCalendar fromDateCalendar;
        private Label toDateLabel;
        private MonthCalendar toDateCalendar;
        private Label selectFieldLabel;
        private Label outputLoactionLabel;
        private Button generateBtn;
        private Label filePathDataLabel;
        private Button getFileExplorerBtn;
        private Button cancelBtn;
        private ListBox selectedColListBox;
        private Label header3Label;
        private Label statusUpdateLabel;
        private Label quickSelectLabel;
        private Button past30Btn;
        private Button past60Btn;
        private Button past90Btn;
        private Label spaceLabel;
    }
}