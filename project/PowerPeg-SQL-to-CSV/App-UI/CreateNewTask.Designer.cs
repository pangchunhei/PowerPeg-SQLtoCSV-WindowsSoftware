﻿namespace App_UI
{
    partial class CreateNewTask
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.triggerDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.triggerDateLabel = new System.Windows.Forms.Label();
            this.selectFieldLabel = new System.Windows.Forms.Label();
            this.gernerationOptionLabel = new System.Windows.Forms.Label();
            this.header2Label = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.getFileExplorerBtn = new System.Windows.Forms.Button();
            this.filePathDataLabel = new System.Windows.Forms.Label();
            this.generateBtn = new System.Windows.Forms.Button();
            this.outputLoactionLabel = new System.Windows.Forms.Label();
            this.selectedColListBox = new System.Windows.Forms.ListBox();
            this.statusUpdateLabel = new System.Windows.Forms.Label();
            this.header3Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(223, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(416, 34);
            this.textBox1.TabIndex = 62;
            // 
            // triggerDateTimePicker
            // 
            this.triggerDateTimePicker.AccessibleName = "triggerDateTimePicker";
            this.triggerDateTimePicker.CustomFormat = "MM/dd/yyyy HH:mm";
            this.triggerDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.triggerDateTimePicker.Location = new System.Drawing.Point(247, 212);
            this.triggerDateTimePicker.Name = "triggerDateTimePicker";
            this.triggerDateTimePicker.Size = new System.Drawing.Size(250, 27);
            this.triggerDateTimePicker.TabIndex = 61;
            // 
            // triggerDateLabel
            // 
            this.triggerDateLabel.AccessibleName = "triggerDateLabel";
            this.triggerDateLabel.AutoSize = true;
            this.triggerDateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.triggerDateLabel.Location = new System.Drawing.Point(118, 210);
            this.triggerDateLabel.Name = "triggerDateLabel";
            this.triggerDateLabel.Size = new System.Drawing.Size(123, 28);
            this.triggerDateLabel.TabIndex = 60;
            this.triggerDateLabel.Text = "Trigger Date:";
            // 
            // selectFieldLabel
            // 
            this.selectFieldLabel.AccessibleName = "selectFieldLabel";
            this.selectFieldLabel.AutoSize = true;
            this.selectFieldLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectFieldLabel.Location = new System.Drawing.Point(118, 259);
            this.selectFieldLabel.Name = "selectFieldLabel";
            this.selectFieldLabel.Size = new System.Drawing.Size(120, 28);
            this.selectFieldLabel.TabIndex = 58;
            this.selectFieldLabel.Text = "Select Field: ";
            // 
            // gernerationOptionLabel
            // 
            this.gernerationOptionLabel.AccessibleName = "gernerationOptionLabel";
            this.gernerationOptionLabel.AutoSize = true;
            this.gernerationOptionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.gernerationOptionLabel.Location = new System.Drawing.Point(74, 163);
            this.gernerationOptionLabel.Name = "gernerationOptionLabel";
            this.gernerationOptionLabel.Size = new System.Drawing.Size(221, 31);
            this.gernerationOptionLabel.TabIndex = 56;
            this.gernerationOptionLabel.Text = "Generation Setting: ";
            // 
            // header2Label
            // 
            this.header2Label.AccessibleName = "header2Label";
            this.header2Label.AutoSize = true;
            this.header2Label.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.header2Label.Location = new System.Drawing.Point(74, 99);
            this.header2Label.Name = "header2Label";
            this.header2Label.Size = new System.Drawing.Size(143, 31);
            this.header2Label.TabIndex = 55;
            this.header2Label.Text = "Task Name: ";
            // 
            // headerLabel
            // 
            this.headerLabel.AccessibleName = "headerLabel";
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.Location = new System.Drawing.Point(34, 28);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(281, 46);
            this.headerLabel.TabIndex = 54;
            this.headerLabel.Text = "Create New Task";
            // 
            // deleteBtn
            // 
            this.deleteBtn.AccessibleName = "deleteBtn";
            this.deleteBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.deleteBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.deleteBtn.Location = new System.Drawing.Point(369, 648);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(120, 48);
            this.deleteBtn.TabIndex = 68;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = false;
            // 
            // cancelBtn
            // 
            this.cancelBtn.AccessibleName = "cancelBtn";
            this.cancelBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelBtn.Location = new System.Drawing.Point(518, 648);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(120, 48);
            this.cancelBtn.TabIndex = 67;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            // 
            // getFileExplorerBtn
            // 
            this.getFileExplorerBtn.AccessibleName = "getFileExplorerBtn";
            this.getFileExplorerBtn.Location = new System.Drawing.Point(288, 595);
            this.getFileExplorerBtn.Name = "getFileExplorerBtn";
            this.getFileExplorerBtn.Size = new System.Drawing.Size(134, 29);
            this.getFileExplorerBtn.TabIndex = 66;
            this.getFileExplorerBtn.Text = "Open Folder";
            this.getFileExplorerBtn.UseVisualStyleBackColor = true;
            // 
            // filePathDataLabel
            // 
            this.filePathDataLabel.AccessibleName = "filePathLabel";
            this.filePathDataLabel.AutoSize = true;
            this.filePathDataLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filePathDataLabel.Location = new System.Drawing.Point(443, 595);
            this.filePathDataLabel.Name = "filePathDataLabel";
            this.filePathDataLabel.Size = new System.Drawing.Size(70, 25);
            this.filePathDataLabel.TabIndex = 65;
            this.filePathDataLabel.Text = "<Path>";
            // 
            // generateBtn
            // 
            this.generateBtn.AccessibleName = "generateBtn";
            this.generateBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.generateBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.generateBtn.Location = new System.Drawing.Point(214, 648);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(120, 48);
            this.generateBtn.TabIndex = 64;
            this.generateBtn.Text = "Generate";
            this.generateBtn.UseVisualStyleBackColor = false;
            // 
            // outputLoactionLabel
            // 
            this.outputLoactionLabel.AccessibleName = "outputLoactionLabel";
            this.outputLoactionLabel.AutoSize = true;
            this.outputLoactionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.outputLoactionLabel.Location = new System.Drawing.Point(118, 594);
            this.outputLoactionLabel.Name = "outputLoactionLabel";
            this.outputLoactionLabel.Size = new System.Drawing.Size(164, 28);
            this.outputLoactionLabel.TabIndex = 63;
            this.outputLoactionLabel.Text = "Output Location: ";
            // 
            // selectedColListBox
            // 
            this.selectedColListBox.AccessibleName = "selectedColListBox";
            this.selectedColListBox.FormattingEnabled = true;
            this.selectedColListBox.ItemHeight = 20;
            this.selectedColListBox.Location = new System.Drawing.Point(244, 259);
            this.selectedColListBox.MultiColumn = true;
            this.selectedColListBox.Name = "selectedColListBox";
            this.selectedColListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.selectedColListBox.Size = new System.Drawing.Size(488, 324);
            this.selectedColListBox.TabIndex = 70;
            // 
            // statusUpdateLabel
            // 
            this.statusUpdateLabel.AccessibleName = "statusUpdateLabel";
            this.statusUpdateLabel.AutoSize = true;
            this.statusUpdateLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusUpdateLabel.Location = new System.Drawing.Point(254, 723);
            this.statusUpdateLabel.Name = "statusUpdateLabel";
            this.statusUpdateLabel.Size = new System.Drawing.Size(147, 25);
            this.statusUpdateLabel.TabIndex = 73;
            this.statusUpdateLabel.Text = "<Status Update>";
            // 
            // header3Label
            // 
            this.header3Label.AccessibleName = "header3Label";
            this.header3Label.AutoSize = true;
            this.header3Label.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.header3Label.Location = new System.Drawing.Point(74, 718);
            this.header3Label.Name = "header3Label";
            this.header3Label.Size = new System.Drawing.Size(174, 31);
            this.header3Label.TabIndex = 72;
            this.header3Label.Text = "Process Status: ";
            // 
            // label1
            // 
            this.label1.AccessibleName = "spaceLabel";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 749);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 71;
            this.label1.Text = "   ";
            // 
            // CreateNewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusUpdateLabel);
            this.Controls.Add(this.header3Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectedColListBox);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.getFileExplorerBtn);
            this.Controls.Add(this.filePathDataLabel);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.outputLoactionLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.triggerDateTimePicker);
            this.Controls.Add(this.triggerDateLabel);
            this.Controls.Add(this.selectFieldLabel);
            this.Controls.Add(this.gernerationOptionLabel);
            this.Controls.Add(this.header2Label);
            this.Controls.Add(this.headerLabel);
            this.Name = "CreateNewTask";
            this.Text = "CreateNewTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private DateTimePicker triggerDateTimePicker;
        private Label triggerDateLabel;
        private Label selectFieldLabel;
        private Label gernerationOptionLabel;
        private Label header2Label;
        private Label headerLabel;
        private Button deleteBtn;
        private Button cancelBtn;
        private Button getFileExplorerBtn;
        private Label filePathDataLabel;
        private Button generateBtn;
        private Label outputLoactionLabel;
        private ListBox selectedColListBox;
        private Label statusUpdateLabel;
        private Label header3Label;
        private Label label1;
    }
}