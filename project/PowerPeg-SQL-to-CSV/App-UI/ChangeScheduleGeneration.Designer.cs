namespace App_UI
{
    partial class ChangeScheduleGeneration
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
            this.serverInfoLabel = new System.Windows.Forms.Label();
            this.header2Label = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.changeTaskSettingLabel = new System.Windows.Forms.Label();
            this.selectTaskCoboBox = new System.Windows.Forms.ComboBox();
            this.selectBtn = new System.Windows.Forms.Button();
            this.selectTaskLabel = new System.Windows.Forms.Label();
            this.createNewTaskLabel = new System.Windows.Forms.Label();
            this.createBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverInfoLabel
            // 
            this.serverInfoLabel.AccessibleName = "serverInfoLabel";
            this.serverInfoLabel.AutoSize = true;
            this.serverInfoLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.serverInfoLabel.Location = new System.Drawing.Point(309, 107);
            this.serverInfoLabel.Name = "serverInfoLabel";
            this.serverInfoLabel.Size = new System.Drawing.Size(170, 28);
            this.serverInfoLabel.TabIndex = 5;
            this.serverInfoLabel.Text = "<Server Address>";
            this.serverInfoLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // header2Label
            // 
            this.header2Label.AccessibleName = "header2Label";
            this.header2Label.AutoSize = true;
            this.header2Label.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.header2Label.Location = new System.Drawing.Point(81, 107);
            this.header2Label.Name = "header2Label";
            this.header2Label.Size = new System.Drawing.Size(222, 31);
            this.header2Label.TabIndex = 4;
            this.header2Label.Text = "Server Information: ";
            this.header2Label.Click += new System.EventHandler(this.label2_Click);
            // 
            // headerLabel
            // 
            this.headerLabel.AccessibleName = "headerLabel";
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.Location = new System.Drawing.Point(41, 36);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(478, 46);
            this.headerLabel.TabIndex = 3;
            this.headerLabel.Text = "Change Schedule Generation";
            this.headerLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // changeTaskSettingLabel
            // 
            this.changeTaskSettingLabel.AccessibleName = "changeTaskSettingLabel";
            this.changeTaskSettingLabel.AutoSize = true;
            this.changeTaskSettingLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.changeTaskSettingLabel.Location = new System.Drawing.Point(81, 170);
            this.changeTaskSettingLabel.Name = "changeTaskSettingLabel";
            this.changeTaskSettingLabel.Size = new System.Drawing.Size(248, 31);
            this.changeTaskSettingLabel.TabIndex = 6;
            this.changeTaskSettingLabel.Text = "Change Tasks Setting: ";
            this.changeTaskSettingLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // selectTaskCoboBox
            // 
            this.selectTaskCoboBox.AccessibleName = "selectTaskCoboBox";
            this.selectTaskCoboBox.FormattingEnabled = true;
            this.selectTaskCoboBox.Location = new System.Drawing.Point(256, 215);
            this.selectTaskCoboBox.Name = "selectTaskCoboBox";
            this.selectTaskCoboBox.Size = new System.Drawing.Size(290, 28);
            this.selectTaskCoboBox.TabIndex = 7;
            // 
            // selectBtn
            // 
            this.selectBtn.AccessibleName = "selectBtn";
            this.selectBtn.Location = new System.Drawing.Point(571, 214);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(94, 29);
            this.selectBtn.TabIndex = 8;
            this.selectBtn.Text = "Select";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // selectTaskLabel
            // 
            this.selectTaskLabel.AccessibleName = "selectTaskLabel";
            this.selectTaskLabel.AutoSize = true;
            this.selectTaskLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectTaskLabel.Location = new System.Drawing.Point(136, 214);
            this.selectTaskLabel.Name = "selectTaskLabel";
            this.selectTaskLabel.Size = new System.Drawing.Size(114, 28);
            this.selectTaskLabel.TabIndex = 9;
            this.selectTaskLabel.Text = "Select Task: ";
            // 
            // createNewTaskLabel
            // 
            this.createNewTaskLabel.AccessibleName = "createNewTaskLabel";
            this.createNewTaskLabel.AutoSize = true;
            this.createNewTaskLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.createNewTaskLabel.Location = new System.Drawing.Point(81, 274);
            this.createNewTaskLabel.Name = "createNewTaskLabel";
            this.createNewTaskLabel.Size = new System.Drawing.Size(202, 31);
            this.createNewTaskLabel.TabIndex = 10;
            this.createNewTaskLabel.Text = "Create New Task: ";
            this.createNewTaskLabel.Click += new System.EventHandler(this.label6_Click);
            // 
            // createBtn
            // 
            this.createBtn.AccessibleName = "createBtn";
            this.createBtn.Location = new System.Drawing.Point(289, 276);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(94, 29);
            this.createBtn.TabIndex = 11;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.AccessibleName = "cancelBtn";
            this.cancelBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelBtn.Location = new System.Drawing.Point(340, 343);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(120, 48);
            this.cancelBtn.TabIndex = 16;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ChangeScheduleGeneration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.createNewTaskLabel);
            this.Controls.Add(this.selectTaskLabel);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.selectTaskCoboBox);
            this.Controls.Add(this.changeTaskSettingLabel);
            this.Controls.Add(this.serverInfoLabel);
            this.Controls.Add(this.header2Label);
            this.Controls.Add(this.headerLabel);
            this.Name = "ChangeScheduleGeneration";
            this.Text = "ChangeScheduleGeneration";
            this.Load += new System.EventHandler(this.ChangeScheduleGeneration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label serverInfoLabel;
        private Label header2Label;
        private Label headerLabel;
        private Label changeTaskSettingLabel;
        private ComboBox selectTaskCoboBox;
        private Button selectBtn;
        private Label selectTaskLabel;
        private Label createNewTaskLabel;
        private Button createBtn;
        private Button cancelBtn;
    }
}