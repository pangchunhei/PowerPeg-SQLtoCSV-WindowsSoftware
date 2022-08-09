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
            this.headerLabel = new System.Windows.Forms.Label();
            this.instantGenerationBtn = new System.Windows.Forms.Button();
            this.changeScheduleGenerationBtn = new System.Windows.Forms.Button();
            this.changeServerInfoBtn = new System.Windows.Forms.Button();
            this.scheduleOutputFolderBtn = new System.Windows.Forms.Button();
            this.checkLogFolderBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AccessibleName = "headerLabel";
            this.headerLabel.AutoSize = true;
            this.headerLabel.BackColor = System.Drawing.SystemColors.Control;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.Location = new System.Drawing.Point(161, 30);
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
            this.instantGenerationBtn.Location = new System.Drawing.Point(237, 196);
            this.instantGenerationBtn.Name = "instantGenerationBtn";
            this.instantGenerationBtn.Size = new System.Drawing.Size(327, 42);
            this.instantGenerationBtn.TabIndex = 1;
            this.instantGenerationBtn.Text = "Instant Generation";
            this.instantGenerationBtn.UseVisualStyleBackColor = true;
            // 
            // changeScheduleGenerationBtn
            // 
            this.changeScheduleGenerationBtn.AccessibleName = "changeScheduleGenerationBtn";
            this.changeScheduleGenerationBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.changeScheduleGenerationBtn.Location = new System.Drawing.Point(237, 271);
            this.changeScheduleGenerationBtn.Name = "changeScheduleGenerationBtn";
            this.changeScheduleGenerationBtn.Size = new System.Drawing.Size(327, 42);
            this.changeScheduleGenerationBtn.TabIndex = 2;
            this.changeScheduleGenerationBtn.Text = "Change Schedule Generation";
            this.changeScheduleGenerationBtn.UseVisualStyleBackColor = true;
            // 
            // changeServerInfoBtn
            // 
            this.changeServerInfoBtn.AccessibleName = "changeServerInfoBtn";
            this.changeServerInfoBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.changeServerInfoBtn.Location = new System.Drawing.Point(237, 123);
            this.changeServerInfoBtn.Name = "changeServerInfoBtn";
            this.changeServerInfoBtn.Size = new System.Drawing.Size(327, 42);
            this.changeServerInfoBtn.TabIndex = 3;
            this.changeServerInfoBtn.Text = "Change Server Information";
            this.changeServerInfoBtn.UseVisualStyleBackColor = true;
            // 
            // scheduleOutputFolderBtn
            // 
            this.scheduleOutputFolderBtn.AccessibleName = "scheduleOutputFolderBtn";
            this.scheduleOutputFolderBtn.Location = new System.Drawing.Point(237, 350);
            this.scheduleOutputFolderBtn.Name = "scheduleOutputFolderBtn";
            this.scheduleOutputFolderBtn.Size = new System.Drawing.Size(156, 52);
            this.scheduleOutputFolderBtn.TabIndex = 4;
            this.scheduleOutputFolderBtn.Text = "Schedule Output Folder";
            this.scheduleOutputFolderBtn.UseVisualStyleBackColor = true;
            // 
            // checkLogFolderBtn
            // 
            this.checkLogFolderBtn.AccessibleName = "checkLogFolderBtn";
            this.checkLogFolderBtn.Location = new System.Drawing.Point(408, 350);
            this.checkLogFolderBtn.Name = "checkLogFolderBtn";
            this.checkLogFolderBtn.Size = new System.Drawing.Size(156, 52);
            this.checkLogFolderBtn.TabIndex = 5;
            this.checkLogFolderBtn.Text = "Check Log Folder";
            this.checkLogFolderBtn.UseVisualStyleBackColor = true;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkLogFolderBtn);
            this.Controls.Add(this.scheduleOutputFolderBtn);
            this.Controls.Add(this.changeServerInfoBtn);
            this.Controls.Add(this.changeScheduleGenerationBtn);
            this.Controls.Add(this.instantGenerationBtn);
            this.Controls.Add(this.headerLabel);
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label headerLabel;
        private Button instantGenerationBtn;
        private Button changeScheduleGenerationBtn;
        private Button changeServerInfoBtn;
        private Button scheduleOutputFolderBtn;
        private Button checkLogFolderBtn;
    }
}