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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

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
            serverInfoLabel.Text = MainFunction.getDatabaseInformation()[0];

            updateTaskListName();
            
        }

        private void updateTaskListName()
        {
            List<string> currentTaskName = MainFunction.getCurrentTaskListName();

            selectTaskCoboBox.Items.Clear();

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
            this.Hide();
            CreateNewTask createNewTask = new CreateNewTask();
            createNewTask.ShowDialog();

            this.Show();
            updateTaskListName();
        }

        private void changeTaskSetting(string selectedTaskName)
        {
            this.Hide();
            ChangeTaskSetting changeTaskSetting = new ChangeTaskSetting(selectedTaskName);
            changeTaskSetting.ShowDialog();

            this.Show();
            updateTaskListName();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
