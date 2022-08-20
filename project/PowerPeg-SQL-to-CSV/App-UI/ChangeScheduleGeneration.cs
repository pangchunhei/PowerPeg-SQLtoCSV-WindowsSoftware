using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowerPeg_SQL_to_CSV;

namespace App_UI
{
    public partial class ChangeScheduleGeneration : Form
    {
        public ChangeScheduleGeneration()
        {
            InitializeComponent();
            this.ControlBox = false;
            GlobalFunction.statusUpdate(statusUpdateLabel, "Loading ChangeScheduleGeneration.", false);
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            string selectedName = selectTaskCoboBox.Text;

            if(selectedName.Equals("-- No Scheduled Task --"))
            {
                createNew();
            }
            else
            {
                changeTaskSetting(selectedName);
            }
        }

        private void ChangeScheduleGeneration_Load(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Loading Database information.", false);
            serverInfoLabel.Text = MainFunction.getDatabaseInformation()[0];

            updateTasklistName();
        }

        private void updateTasklistName()
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Loading current scheduled tasklist.", false);

            List<string> currentTaskName = MainFunction.getCurrentTaskListName();

            selectTaskCoboBox.Items.Clear();
            selectTaskCoboBox.Sorted = true;

            if (currentTaskName.Count == 0)
            {
                selectTaskCoboBox.Items.Add("-- No Scheduled Task --");
            }
            else
            {
                foreach (string s in currentTaskName)
                {
                    selectTaskCoboBox.Items.Add(s);
                }
            }

            selectTaskCoboBox.SelectedIndex = 0;
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            createNew();
        }

        private void createNew()
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Requesting to create new schedule task.", false);

            this.Hide();
            CreateNewTask createNewTask = new CreateNewTask();
            createNewTask.ShowDialog();

            this.Show();
            updateTasklistName();
        }

        private void changeTaskSetting(string selectedTaskName)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Requesting to update existing schedule task setting.", false);

            this.Hide();
            ChangeTaskSetting changeTaskSetting = new ChangeTaskSetting(selectedTaskName);
            changeTaskSetting.ShowDialog();

            this.Show();
            updateTasklistName();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Close ChnageSchedukeGeneration and Go back to previous page.", false);
            this.Close();
        }
    }
}
