using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_UI
{
    public partial class HomeForm : Form
    {
        private ChangeServerInfo changeServerInfo;
        private InstantGenerationOptionForm instantGeneration;
        
        public HomeForm()
        {
            InitializeComponent();

            changeServerInfo = new ChangeServerInfo();
            instantGeneration = new InstantGenerationOptionForm();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void changeServerInfoBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            changeServerInfo.ShowDialog();
            this.Show();
        }

        private void instantGenerationBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            instantGeneration.ShowDialog();
            this.Show();
        }

        private void changeScheduleGenerationBtn_Click(object sender, EventArgs e)
        {

        }

        private void scheduleOutputFolderBtn_Click(object sender, EventArgs e)
        {

        }

        private void checkLogFolderBtn_Click(object sender, EventArgs e)
        {

        }

        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
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
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }
    }
}
