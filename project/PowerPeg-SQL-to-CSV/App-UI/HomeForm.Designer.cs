namespace App_UI
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.headerLabel = new System.Windows.Forms.Label();
            this.instantGenerationBtn = new System.Windows.Forms.Button();
            this.changeScheduleGenerationBtn = new System.Windows.Forms.Button();
            this.showServerInfoBtn = new System.Windows.Forms.Button();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.header2Label = new System.Windows.Forms.Label();
            this.statusUpdateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AccessibleName = "headerLabel";
            this.headerLabel.AutoSize = true;
            this.headerLabel.BackColor = System.Drawing.SystemColors.Control;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.Location = new System.Drawing.Point(161, 23);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(482, 62);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "SQL to CSV Software";
            this.headerLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // instantGenerationBtn
            // 
            this.instantGenerationBtn.AccessibleName = "instantGenerationBtn";
            this.instantGenerationBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.instantGenerationBtn.Location = new System.Drawing.Point(237, 173);
            this.instantGenerationBtn.Name = "instantGenerationBtn";
            this.instantGenerationBtn.Size = new System.Drawing.Size(327, 42);
            this.instantGenerationBtn.TabIndex = 1;
            this.instantGenerationBtn.Text = "Instant Generation";
            this.instantGenerationBtn.UseVisualStyleBackColor = true;
            this.instantGenerationBtn.Click += new System.EventHandler(this.instantGenerationBtn_Click);
            // 
            // changeScheduleGenerationBtn
            // 
            this.changeScheduleGenerationBtn.AccessibleName = "changeScheduleGenerationBtn";
            this.changeScheduleGenerationBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.changeScheduleGenerationBtn.Location = new System.Drawing.Point(237, 232);
            this.changeScheduleGenerationBtn.Name = "changeScheduleGenerationBtn";
            this.changeScheduleGenerationBtn.Size = new System.Drawing.Size(327, 42);
            this.changeScheduleGenerationBtn.TabIndex = 2;
            this.changeScheduleGenerationBtn.Text = "Change Schedule Generation";
            this.changeScheduleGenerationBtn.UseVisualStyleBackColor = true;
            this.changeScheduleGenerationBtn.Click += new System.EventHandler(this.changeScheduleGenerationBtn_Click);
            // 
            // showServerInfoBtn
            // 
            this.showServerInfoBtn.AccessibleName = "showServerInfoBtn";
            this.showServerInfoBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.showServerInfoBtn.Location = new System.Drawing.Point(237, 116);
            this.showServerInfoBtn.Name = "showServerInfoBtn";
            this.showServerInfoBtn.Size = new System.Drawing.Size(327, 42);
            this.showServerInfoBtn.TabIndex = 3;
            this.showServerInfoBtn.Text = "Show Server Information";
            this.showServerInfoBtn.UseVisualStyleBackColor = true;
            this.showServerInfoBtn.Click += new System.EventHandler(this.showServerInfoBtn_Click);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.AccessibleName = "minimizeBtn";
            this.minimizeBtn.Location = new System.Drawing.Point(237, 293);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(156, 52);
            this.minimizeBtn.TabIndex = 4;
            this.minimizeBtn.Text = "Minimize to System-Tray";
            this.minimizeBtn.UseVisualStyleBackColor = true;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.AccessibleName = "checkLogFolderBtn";
            this.exitBtn.Location = new System.Drawing.Point(408, 293);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(156, 52);
            this.exitBtn.TabIndex = 5;
            this.exitBtn.Text = "Exit Program";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "PowerPeg";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // header2Label
            // 
            this.header2Label.AccessibleName = "header2Label";
            this.header2Label.AutoSize = true;
            this.header2Label.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.header2Label.Location = new System.Drawing.Point(70, 377);
            this.header2Label.Name = "header2Label";
            this.header2Label.Size = new System.Drawing.Size(174, 31);
            this.header2Label.TabIndex = 43;
            this.header2Label.Text = "Process Status: ";
            // 
            // statusUpdateLabel
            // 
            this.statusUpdateLabel.AccessibleName = "statusUpdateLabel";
            this.statusUpdateLabel.AutoSize = true;
            this.statusUpdateLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusUpdateLabel.Location = new System.Drawing.Point(297, 429);
            this.statusUpdateLabel.Name = "statusUpdateLabel";
            this.statusUpdateLabel.Size = new System.Drawing.Size(147, 25);
            this.statusUpdateLabel.TabIndex = 47;
            this.statusUpdateLabel.Text = "<Status Update>";
            // 
            // label1
            // 
            this.label1.AccessibleName = "spaceLabel";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 762);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 72;
            this.label1.Text = "   ";
            // 
            // txtConsole
            // 
            this.txtConsole.Location = new System.Drawing.Point(70, 411);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(669, 359);
            this.txtConsole.TabIndex = 73;
            this.txtConsole.WordWrap = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 793);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusUpdateLabel);
            this.Controls.Add(this.header2Label);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.showServerInfoBtn);
            this.Controls.Add(this.changeScheduleGenerationBtn);
            this.Controls.Add(this.instantGenerationBtn);
            this.Controls.Add(this.headerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HomeForm_FormClosing);
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label headerLabel;
        private Button instantGenerationBtn;
        private Button changeScheduleGenerationBtn;
        private Button showServerInfoBtn;
        private Button minimizeBtn;
        private Button exitBtn;
        private NotifyIcon notifyIcon;
        private Label header2Label;
        private Label statusUpdateLabel;
        private Label label1;
        private TextBox txtConsole;
    }
}