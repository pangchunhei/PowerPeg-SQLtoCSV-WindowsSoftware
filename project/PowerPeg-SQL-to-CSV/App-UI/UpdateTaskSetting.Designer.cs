﻿namespace App_UI
{
    partial class UpdateTaskSetting
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
            this.taskNameDataLabel = new System.Windows.Forms.Label();
            this.header2Label = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.statusUpdateLabel = new System.Windows.Forms.Label();
            this.header3Label = new System.Windows.Forms.Label();
            this.selectedColListBox = new System.Windows.Forms.ListBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.getFileExplorerBtn = new System.Windows.Forms.Button();
            this.filePathDataLabel = new System.Windows.Forms.Label();
            this.updateBtn = new System.Windows.Forms.Button();
            this.outputLoactionLabel = new System.Windows.Forms.Label();
            this.triggerDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.triggerDateLabel = new System.Windows.Forms.Label();
            this.selectFieldLabel = new System.Windows.Forms.Label();
            this.gernerationOptionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.frequencyCoboBox = new System.Windows.Forms.ComboBox();
            this.frequenceLabel = new System.Windows.Forms.Label();
            this.selectThisCoboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // taskNameDataLabel
            // 
            this.taskNameDataLabel.AccessibleName = "taskNameDataLabel";
            this.taskNameDataLabel.AutoSize = true;
            this.taskNameDataLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.taskNameDataLabel.Location = new System.Drawing.Point(299, 90);
            this.taskNameDataLabel.Name = "taskNameDataLabel";
            this.taskNameDataLabel.Size = new System.Drawing.Size(133, 28);
            this.taskNameDataLabel.TabIndex = 18;
            this.taskNameDataLabel.Text = "<Task Name>";
            // 
            // header2Label
            // 
            this.header2Label.AccessibleName = "header2Label";
            this.header2Label.AutoSize = true;
            this.header2Label.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.header2Label.Location = new System.Drawing.Point(58, 89);
            this.header2Label.Name = "header2Label";
            this.header2Label.Size = new System.Drawing.Size(245, 31);
            this.header2Label.TabIndex = 17;
            this.header2Label.Text = "Selected Task Setting: ";
            // 
            // headerLabel
            // 
            this.headerLabel.AccessibleName = "headerLabel";
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.Location = new System.Drawing.Point(18, 18);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(341, 46);
            this.headerLabel.TabIndex = 16;
            this.headerLabel.Text = "Change Task Setting";
            // 
            // statusUpdateLabel
            // 
            this.statusUpdateLabel.AccessibleName = "statusUpdateLabel";
            this.statusUpdateLabel.AutoSize = true;
            this.statusUpdateLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusUpdateLabel.Location = new System.Drawing.Point(238, 440);
            this.statusUpdateLabel.Name = "statusUpdateLabel";
            this.statusUpdateLabel.Size = new System.Drawing.Size(147, 25);
            this.statusUpdateLabel.TabIndex = 86;
            this.statusUpdateLabel.Text = "<Status Update>";
            // 
            // header3Label
            // 
            this.header3Label.AccessibleName = "header3Label";
            this.header3Label.AutoSize = true;
            this.header3Label.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.header3Label.Location = new System.Drawing.Point(58, 435);
            this.header3Label.Name = "header3Label";
            this.header3Label.Size = new System.Drawing.Size(174, 31);
            this.header3Label.TabIndex = 85;
            this.header3Label.Text = "Process Status: ";
            // 
            // selectedColListBox
            // 
            this.selectedColListBox.AccessibleName = "selectedColListBox";
            this.selectedColListBox.FormattingEnabled = true;
            this.selectedColListBox.ItemHeight = 20;
            this.selectedColListBox.Location = new System.Drawing.Point(238, 276);
            this.selectedColListBox.MultiColumn = true;
            this.selectedColListBox.Name = "selectedColListBox";
            this.selectedColListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.selectedColListBox.Size = new System.Drawing.Size(259, 24);
            this.selectedColListBox.TabIndex = 84;
            // 
            // deleteBtn
            // 
            this.deleteBtn.AccessibleName = "deleteBtn";
            this.deleteBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.deleteBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.deleteBtn.Location = new System.Drawing.Point(343, 365);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(120, 48);
            this.deleteBtn.TabIndex = 83;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.AccessibleName = "cancelBtn";
            this.cancelBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelBtn.Location = new System.Drawing.Point(492, 365);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(120, 48);
            this.cancelBtn.TabIndex = 82;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // getFileExplorerBtn
            // 
            this.getFileExplorerBtn.AccessibleName = "getFileExplorerBtn";
            this.getFileExplorerBtn.Location = new System.Drawing.Point(272, 319);
            this.getFileExplorerBtn.Name = "getFileExplorerBtn";
            this.getFileExplorerBtn.Size = new System.Drawing.Size(134, 29);
            this.getFileExplorerBtn.TabIndex = 81;
            this.getFileExplorerBtn.Text = "Open Folder";
            this.getFileExplorerBtn.UseVisualStyleBackColor = true;
            this.getFileExplorerBtn.Click += new System.EventHandler(this.getFileExplorerBtn_Click);
            // 
            // filePathDataLabel
            // 
            this.filePathDataLabel.AccessibleName = "filePathLabel";
            this.filePathDataLabel.AutoSize = true;
            this.filePathDataLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filePathDataLabel.Location = new System.Drawing.Point(427, 319);
            this.filePathDataLabel.Name = "filePathDataLabel";
            this.filePathDataLabel.Size = new System.Drawing.Size(183, 25);
            this.filePathDataLabel.TabIndex = 80;
            this.filePathDataLabel.Text = "<Select Default Path>";
            // 
            // updateBtn
            // 
            this.updateBtn.AccessibleName = "updateBtn";
            this.updateBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.updateBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.updateBtn.Location = new System.Drawing.Point(188, 365);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(120, 48);
            this.updateBtn.TabIndex = 79;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // outputLoactionLabel
            // 
            this.outputLoactionLabel.AccessibleName = "outputLoactionLabel";
            this.outputLoactionLabel.AutoSize = true;
            this.outputLoactionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.outputLoactionLabel.Location = new System.Drawing.Point(102, 318);
            this.outputLoactionLabel.Name = "outputLoactionLabel";
            this.outputLoactionLabel.Size = new System.Drawing.Size(164, 28);
            this.outputLoactionLabel.TabIndex = 78;
            this.outputLoactionLabel.Text = "Output Location: ";
            // 
            // triggerDateTimePicker
            // 
            this.triggerDateTimePicker.AccessibleName = "triggerDateTimePicker";
            this.triggerDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.triggerDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.triggerDateTimePicker.Location = new System.Drawing.Point(231, 231);
            this.triggerDateTimePicker.Name = "triggerDateTimePicker";
            this.triggerDateTimePicker.Size = new System.Drawing.Size(250, 27);
            this.triggerDateTimePicker.TabIndex = 77;
            // 
            // triggerDateLabel
            // 
            this.triggerDateLabel.AccessibleName = "triggerDateLabel";
            this.triggerDateLabel.AutoSize = true;
            this.triggerDateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.triggerDateLabel.Location = new System.Drawing.Point(102, 229);
            this.triggerDateLabel.Name = "triggerDateLabel";
            this.triggerDateLabel.Size = new System.Drawing.Size(123, 28);
            this.triggerDateLabel.TabIndex = 76;
            this.triggerDateLabel.Text = "Trigger Date:";
            // 
            // selectFieldLabel
            // 
            this.selectFieldLabel.AccessibleName = "selectFieldLabel";
            this.selectFieldLabel.AutoSize = true;
            this.selectFieldLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectFieldLabel.Location = new System.Drawing.Point(102, 272);
            this.selectFieldLabel.Name = "selectFieldLabel";
            this.selectFieldLabel.Size = new System.Drawing.Size(142, 28);
            this.selectFieldLabel.TabIndex = 75;
            this.selectFieldLabel.Text = "Selected Field: ";
            // 
            // gernerationOptionLabel
            // 
            this.gernerationOptionLabel.AccessibleName = "gernerationOptionLabel";
            this.gernerationOptionLabel.AutoSize = true;
            this.gernerationOptionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.gernerationOptionLabel.Location = new System.Drawing.Point(58, 142);
            this.gernerationOptionLabel.Name = "gernerationOptionLabel";
            this.gernerationOptionLabel.Size = new System.Drawing.Size(221, 31);
            this.gernerationOptionLabel.TabIndex = 74;
            this.gernerationOptionLabel.Text = "Generation Setting: ";
            // 
            // label1
            // 
            this.label1.AccessibleName = "spaceLabel";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 465);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 87;
            this.label1.Text = "   ";
            // 
            // frequencyCoboBox
            // 
            this.frequencyCoboBox.AccessibleName = "frequencyCoboBox";
            this.frequencyCoboBox.FormattingEnabled = true;
            this.frequencyCoboBox.Location = new System.Drawing.Point(231, 188);
            this.frequencyCoboBox.Name = "frequencyCoboBox";
            this.frequencyCoboBox.Size = new System.Drawing.Size(151, 28);
            this.frequencyCoboBox.TabIndex = 89;
            this.frequencyCoboBox.SelectedIndexChanged += new System.EventHandler(this.frequencyCoboBox_SelectedIndexChanged);
            // 
            // frequenceLabel
            // 
            this.frequenceLabel.AccessibleName = "frequenceLabel";
            this.frequenceLabel.AutoSize = true;
            this.frequenceLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.frequenceLabel.Location = new System.Drawing.Point(102, 188);
            this.frequenceLabel.Name = "frequenceLabel";
            this.frequenceLabel.Size = new System.Drawing.Size(106, 28);
            this.frequenceLabel.TabIndex = 88;
            this.frequenceLabel.Text = "Frequency:";
            // 
            // selectThisCoboBox
            // 
            this.selectThisCoboBox.AccessibleName = "selectThisCoboBox";
            this.selectThisCoboBox.FormattingEnabled = true;
            this.selectThisCoboBox.Location = new System.Drawing.Point(388, 188);
            this.selectThisCoboBox.Name = "selectThisCoboBox";
            this.selectThisCoboBox.Size = new System.Drawing.Size(340, 28);
            this.selectThisCoboBox.TabIndex = 90;
            this.selectThisCoboBox.Visible = false;
            // 
            // UpdateTaskSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.selectThisCoboBox);
            this.Controls.Add(this.frequencyCoboBox);
            this.Controls.Add(this.frequenceLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusUpdateLabel);
            this.Controls.Add(this.header3Label);
            this.Controls.Add(this.selectedColListBox);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.getFileExplorerBtn);
            this.Controls.Add(this.filePathDataLabel);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.outputLoactionLabel);
            this.Controls.Add(this.triggerDateTimePicker);
            this.Controls.Add(this.triggerDateLabel);
            this.Controls.Add(this.selectFieldLabel);
            this.Controls.Add(this.gernerationOptionLabel);
            this.Controls.Add(this.taskNameDataLabel);
            this.Controls.Add(this.header2Label);
            this.Controls.Add(this.headerLabel);
            this.Name = "UpdateTaskSetting";
            this.Text = "ChangeTaskSetting";
            this.Load += new System.EventHandler(this.ChangeTaskSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label taskNameDataLabel;
        private Label header2Label;
        private Label headerLabel;
        private Label statusUpdateLabel;
        private Label header3Label;
        private ListBox selectedColListBox;
        private Button deleteBtn;
        private Button cancelBtn;
        private Button getFileExplorerBtn;
        private Label filePathDataLabel;
        private Button updateBtn;
        private Label outputLoactionLabel;
        private DateTimePicker triggerDateTimePicker;
        private Label triggerDateLabel;
        private Label selectFieldLabel;
        private Label gernerationOptionLabel;
        private Label label1;
        private ComboBox frequencyCoboBox;
        private Label frequenceLabel;
        private ComboBox selectThisCoboBox;
    }
}