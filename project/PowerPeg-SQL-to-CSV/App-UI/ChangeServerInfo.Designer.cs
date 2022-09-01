namespace App_UI
{
    partial class ChangeServerInfo
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.connectionStrLabel = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.connectionStrTextbox = new System.Windows.Forms.TextBox();
            this.tableTextbox = new System.Windows.Forms.TextBox();
            this.statusUpdateLabel = new System.Windows.Forms.Label();
            this.header3Label = new System.Windows.Forms.Label();
            this.spaceLabel = new System.Windows.Forms.Label();
            this.tableLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AccessibleName = "headerLabel";
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.Location = new System.Drawing.Point(33, 24);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(453, 46);
            this.headerLabel.TabIndex = 1;
            this.headerLabel.Text = "Change Server Information";
            // 
            // connectionStrLabel
            // 
            this.connectionStrLabel.AccessibleName = "connectionStrLabel";
            this.connectionStrLabel.AutoSize = true;
            this.connectionStrLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.connectionStrLabel.Location = new System.Drawing.Point(82, 103);
            this.connectionStrLabel.Name = "connectionStrLabel";
            this.connectionStrLabel.Size = new System.Drawing.Size(211, 31);
            this.connectionStrLabel.TabIndex = 3;
            this.connectionStrLabel.Text = "Connection String: ";
            // 
            // saveBtn
            // 
            this.saveBtn.AccessibleName = "saveBtn";
            this.saveBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.saveBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saveBtn.Location = new System.Drawing.Point(278, 444);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(120, 46);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.AccessibleName = "cancelBtn";
            this.cancelBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelBtn.Location = new System.Drawing.Point(433, 444);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(120, 46);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // connectionStrTextbox
            // 
            this.connectionStrTextbox.AccessibleName = "connectionStrTextbox";
            this.connectionStrTextbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectionStrTextbox.Location = new System.Drawing.Point(287, 103);
            this.connectionStrTextbox.Multiline = true;
            this.connectionStrTextbox.Name = "connectionStrTextbox";
            this.connectionStrTextbox.Size = new System.Drawing.Size(419, 156);
            this.connectionStrTextbox.TabIndex = 9;
            // 
            // tableTextbox
            // 
            this.tableTextbox.AccessibleName = "tableTextbox";
            this.tableTextbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tableTextbox.Location = new System.Drawing.Point(254, 265);
            this.tableTextbox.Multiline = true;
            this.tableTextbox.Name = "tableTextbox";
            this.tableTextbox.ReadOnly = true;
            this.tableTextbox.Size = new System.Drawing.Size(452, 170);
            this.tableTextbox.TabIndex = 10;
            // 
            // statusUpdateLabel
            // 
            this.statusUpdateLabel.AccessibleName = "statusUpdateLabel";
            this.statusUpdateLabel.AutoSize = true;
            this.statusUpdateLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusUpdateLabel.Location = new System.Drawing.Point(251, 493);
            this.statusUpdateLabel.Name = "statusUpdateLabel";
            this.statusUpdateLabel.Size = new System.Drawing.Size(147, 25);
            this.statusUpdateLabel.TabIndex = 42;
            this.statusUpdateLabel.Text = "<Status Update>";
            // 
            // header3Label
            // 
            this.header3Label.AccessibleName = "header3Label";
            this.header3Label.AutoSize = true;
            this.header3Label.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.header3Label.Location = new System.Drawing.Point(82, 487);
            this.header3Label.Name = "header3Label";
            this.header3Label.Size = new System.Drawing.Size(174, 31);
            this.header3Label.TabIndex = 41;
            this.header3Label.Text = "Process Status: ";
            // 
            // spaceLabel
            // 
            this.spaceLabel.AccessibleName = "spaceLabel";
            this.spaceLabel.AutoSize = true;
            this.spaceLabel.Location = new System.Drawing.Point(237, 518);
            this.spaceLabel.Name = "spaceLabel";
            this.spaceLabel.Size = new System.Drawing.Size(21, 20);
            this.spaceLabel.TabIndex = 40;
            this.spaceLabel.Text = "   ";
            // 
            // tableLabel
            // 
            this.tableLabel.AccessibleName = "tableLabel";
            this.tableLabel.AutoSize = true;
            this.tableLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.tableLabel.Location = new System.Drawing.Point(82, 265);
            this.tableLabel.Name = "tableLabel";
            this.tableLabel.Size = new System.Drawing.Size(176, 31);
            this.tableLabel.TabIndex = 4;
            this.tableLabel.Text = "Selected Table: ";
            // 
            // ChangeServerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusUpdateLabel);
            this.Controls.Add(this.header3Label);
            this.Controls.Add(this.spaceLabel);
            this.Controls.Add(this.tableTextbox);
            this.Controls.Add(this.connectionStrTextbox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.tableLabel);
            this.Controls.Add(this.connectionStrLabel);
            this.Controls.Add(this.headerLabel);
            this.Name = "ChangeServerInfo";
            this.Text = "ChangeServerInfo";
            this.Load += new System.EventHandler(this.ChangeServerInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label headerLabel;
        private Label connectionStrLabel;
        private Button saveBtn;
        private Button cancelBtn;
        private TextBox connectionStrTextbox;
        private TextBox tableTextbox;
        private Label statusUpdateLabel;
        private Label header3Label;
        private Label spaceLabel;
        private Label tableLabel;
    }
}