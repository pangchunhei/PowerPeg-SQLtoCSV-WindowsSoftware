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
            this.addressLabel = new System.Windows.Forms.Label();
            this.catalogLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.addressTextbox = new System.Windows.Forms.TextBox();
            this.catalogTextbox = new System.Windows.Forms.TextBox();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.passordMaskBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AccessibleName = "headerLabel";
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.Location = new System.Drawing.Point(33, 35);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(453, 46);
            this.headerLabel.TabIndex = 1;
            this.headerLabel.Text = "Change Server Information";
            this.headerLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // addressLabel
            // 
            this.addressLabel.AccessibleName = "addressLabel";
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.addressLabel.Location = new System.Drawing.Point(82, 114);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(108, 31);
            this.addressLabel.TabIndex = 3;
            this.addressLabel.Text = "Address: ";
            // 
            // catalogLabel
            // 
            this.catalogLabel.AccessibleName = "catalogLabel";
            this.catalogLabel.AutoSize = true;
            this.catalogLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.catalogLabel.Location = new System.Drawing.Point(82, 172);
            this.catalogLabel.Name = "catalogLabel";
            this.catalogLabel.Size = new System.Drawing.Size(108, 31);
            this.catalogLabel.TabIndex = 4;
            this.catalogLabel.Text = "Catalog: ";
            this.catalogLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AccessibleName = "usernameLabel";
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.usernameLabel.Location = new System.Drawing.Point(82, 230);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(131, 31);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "Username: ";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AccessibleName = "passwordLabel";
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.passwordLabel.Location = new System.Drawing.Point(82, 290);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(125, 31);
            this.passwordLabel.TabIndex = 6;
            this.passwordLabel.Text = "Password: ";
            // 
            // saveBtn
            // 
            this.saveBtn.AccessibleName = "saveBtn";
            this.saveBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.saveBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saveBtn.Location = new System.Drawing.Point(247, 371);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(120, 46);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            // 
            // cancelBtn
            // 
            this.cancelBtn.AccessibleName = "cancelBtn";
            this.cancelBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelBtn.Location = new System.Drawing.Point(436, 371);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(120, 46);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            // 
            // addressTextbox
            // 
            this.addressTextbox.AccessibleName = "addressTextbox";
            this.addressTextbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addressTextbox.Location = new System.Drawing.Point(219, 114);
            this.addressTextbox.Name = "addressTextbox";
            this.addressTextbox.Size = new System.Drawing.Size(452, 34);
            this.addressTextbox.TabIndex = 9;
            // 
            // catalogTextbox
            // 
            this.catalogTextbox.AccessibleName = "catalogTextbox";
            this.catalogTextbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.catalogTextbox.Location = new System.Drawing.Point(219, 171);
            this.catalogTextbox.Name = "catalogTextbox";
            this.catalogTextbox.Size = new System.Drawing.Size(452, 34);
            this.catalogTextbox.TabIndex = 10;
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.AccessibleName = "usernameTextbox";
            this.usernameTextbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usernameTextbox.Location = new System.Drawing.Point(219, 229);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(452, 34);
            this.usernameTextbox.TabIndex = 11;
            // 
            // passordMaskBox
            // 
            this.passordMaskBox.AccessibleName = "passordMaskBox";
            this.passordMaskBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passordMaskBox.Location = new System.Drawing.Point(219, 287);
            this.passordMaskBox.Name = "passordMaskBox";
            this.passordMaskBox.Size = new System.Drawing.Size(452, 34);
            this.passordMaskBox.TabIndex = 12;
            // 
            // ChangeServerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.passordMaskBox);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.catalogTextbox);
            this.Controls.Add(this.addressTextbox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.catalogLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.headerLabel);
            this.Name = "ChangeServerInfo";
            this.Text = "ChangeServerInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label headerLabel;
        private Label addressLabel;
        private Label catalogLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private Button saveBtn;
        private Button cancelBtn;
        private TextBox addressTextbox;
        private TextBox catalogTextbox;
        private TextBox usernameTextbox;
        private MaskedTextBox passordMaskBox;
    }
}