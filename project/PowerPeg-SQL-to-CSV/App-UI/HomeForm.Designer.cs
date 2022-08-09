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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleName = "headerLabel";
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(161, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(482, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "SQL to CSV Software";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.AccessibleName = "instantGenerationBtn";
            this.button1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(237, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(327, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Instant Generation";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.AccessibleName = "changeScheduleGenerationBtn";
            this.button2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(237, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(327, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "Change Schedule Generation";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.AccessibleName = "changeServerInfoBtn";
            this.button3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(237, 123);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(327, 42);
            this.button3.TabIndex = 3;
            this.button3.Text = "Change Server Information";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.AccessibleName = "scheduleOutputFolderBtn";
            this.button4.Location = new System.Drawing.Point(237, 350);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(156, 52);
            this.button4.TabIndex = 4;
            this.button4.Text = "Schedule Output Folder";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.AccessibleName = "checkLogFolderBtn";
            this.button5.Location = new System.Drawing.Point(408, 350);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(156, 52);
            this.button5.TabIndex = 5;
            this.button5.Text = "Check Log Folder";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}