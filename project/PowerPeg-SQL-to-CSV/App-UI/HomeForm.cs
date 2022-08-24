using PowerPeg_SQL_to_CSV;
using PowerPeg_SQL_to_CSV.ProcessTask;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_UI
{
    public partial class HomeForm : Form
    {
        
        public HomeForm()
        {
            InitializeComponent();

            GlobalFunction.statusUpdate(statusUpdateLabel, "Initializing UI Application.", false);
            GlobalFunction.statusUpdate(statusUpdateLabel, "Loading HomeForm.", false);

            GlobalFunction.statusUpdate(statusUpdateLabel, "Starting background task.", false);
            //TODO-- no comment
            //MainFunction.startBackgroundJob();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void changeServerInfoBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeServerInfo changeServerInfo = new ChangeServerInfo();
            changeServerInfo.ShowDialog();
            this.Show();
        }

        private void instantGenerationBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            InstantGenerationTask instantGeneration = new InstantGenerationTask();
            instantGeneration.ShowDialog();
            this.Show();
        }

        private void changeScheduleGenerationBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Stopping background task.", false);
            MainFunction.stopBackgroundJob();

            GlobalFunction.statusUpdate(statusUpdateLabel, "Starting background task.", false);
            this.Hide();
            ChangeScheduleGeneration changeScheduleGeneration = new ChangeScheduleGeneration();
            changeScheduleGeneration.ShowDialog();

            GlobalFunction.statusUpdate(statusUpdateLabel, "Showing background task.", false);
            this.Show();
            
            //Update time gap for sync
            Thread.Sleep(500);

            GlobalFunction.statusUpdate(statusUpdateLabel, "Restarting background task.", false);
            MainFunction.startBackgroundJob();
        }

        private void reStartProgramBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Restarting background task.", false);
            MainFunction.reStartBackgroundJob();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Closing background task.", false);
            MainFunction.stopBackgroundJob();
            //Giving time to close
            Thread.Sleep(3000);

            GlobalFunction.statusUpdate(statusUpdateLabel, "Appication closing.", false);
            Application.Exit();
        }

        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "Putting HomeForm to System Tray.", false);
                notifyIcon.Visible = true;
                this.Hide();

                notifyIcon.BalloonTipText = "PowerPeg SQL to CSV Application";
                notifyIcon.BalloonTipTitle = "Application is Running in background.";
                notifyIcon.ShowBalloonTip(5000);

                e.Cancel = true;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Opening HomeForm from System Tray.", false);
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }
    }
}
