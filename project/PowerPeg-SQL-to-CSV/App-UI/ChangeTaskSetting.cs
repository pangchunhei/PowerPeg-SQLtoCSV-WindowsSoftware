using PowerPeg_SQL_to_CSV;
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
    public partial class ChangeTaskSetting : Form
    {
        private string selectedTaskName;
        private SearchTask task;

        public ChangeTaskSetting(string selectedTaskName)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.selectedTaskName = selectedTaskName;
            GlobalFunction.statusUpdate(statusUpdateLabel, "Loading ChangeTaskSetting.", false);
        }

        private void ChangeTaskSetting_Load(object sender, EventArgs e)
        {
            this.task = MainFunction.findTaskObject(selectedTaskName);

            this.taskNameDataLabel.Text = task.getTaskInfo()[0];
            this.triggerDateTimePicker.Value = task.getMode().getTriggerDateTime();

            List<string> col = MainFunction.getDatabaseColumnName();
            List<string> col2 = task.getMode().getSelectColumn();
            
            selectedColListBox.Items.Add("-- All --");
            foreach (string s in col)
            {
                selectedColListBox.Items.Add(s);
            }

            foreach (string s in col2)
            {
                if (s.Equals("*"))
                {
                    
                    selectedColListBox.SelectedItems.Add("-- All --");
                }
                selectedColListBox.SelectedItems.Add(s);
            }

            List<string> col3 = MainFunction.getGenerationScheduledModeName();

            foreach (string s in col3)
            {
                frequencyCoboBox.Items.Add(s);
            }
            frequencyCoboBox.SelectedIndex = 0;

            GlobalFunction.statusUpdate(statusUpdateLabel, "User creating form", false);

            filePathDataLabel.Text = task.getTaskInfo()[1];

            GlobalFunction.statusUpdate(statusUpdateLabel, "User creating form", false);
        }

        private void getFileExplorerBtn_Click(object sender, EventArgs e)
        {
            filePathDataLabel.Text = GlobalFunction.exploreFilePath();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Updating " + TypeDescriptor.GetClassName(this), false);
            if (filePathDataLabel.Text.Equals("<Select Path>"))
            {
                MessageBox.Show("Please select output folder.");
            }
            else
            {
                List<string> selectCol = GlobalFunction.convertListBoxSelected_to_List(selectedColListBox.SelectedItems);
                //Test
                MainFunction.updateTaskSetting(this.task, "Minute", filePathDataLabel.Text, this.triggerDateTimePicker.Value, selectCol);
                //MainFunction.updateTaskSetting(this.task, "Month", filePathDataLabel.Text, this.triggerDateTimePicker.Value, selectCol);
                GlobalFunction.statusUpdate(statusUpdateLabel, "Update finished.", true);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            MainFunction.removeScheduleTask(task);
            GlobalFunction.statusUpdate(statusUpdateLabel, "Schedule Task delated.", true);
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Cancel and back to previous page.", false);
            this.Close();
        }

        private void filePathDataLabel_Click(object sender, EventArgs e)
        {

        }

        private void outputLoactionLabel_Click(object sender, EventArgs e)
        {

        }

        private void triggerDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void triggerDateLabel_Click(object sender, EventArgs e)
        {

        }

        private void selectFieldLabel_Click(object sender, EventArgs e)
        {

        }

        private void header3Label_Click(object sender, EventArgs e)
        {

        }

        private void statusUpdateLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
