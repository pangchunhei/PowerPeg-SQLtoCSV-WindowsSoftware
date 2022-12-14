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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace App_UI
{
    public partial class UpdateTaskSetting : Form
    {
        private string selectedTaskName;
        private SearchTask task;

        public UpdateTaskSetting(string selectedTaskName)
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
            //TODO-- getTrigger
            //this.triggerDateTimePicker.Value = task.getMode().getTriggerDateTime();

            /*
            TODO-- Select specific device
            List<string> col = MainFunction.getDatabaseColumnName();
            
            
            selectedColListBox.Items.Add("-- All --");
            foreach (string s in col)
            {
                selectedColListBox.Items.Add(s);
            }
            
            List<string> col2 = task.getMode().getSelectColumn();
            foreach (string s in col2)
            {
                if (s.Equals("*"))
                {
                    
                    selectedColListBox.SelectedItems.Add("-- All --");
                }
                selectedColListBox.SelectedItems.Add(s);
            }
            */

            selectedColListBox.Items.Add("-- All --");
            selectedColListBox.SelectedItems.Add("-- All --");

            GlobalFunction.createModeTypeDropDown(this.frequencyCoboBox);
            frequencyCoboBox.SelectedItem = task.getTaskInfo()[2];

            GlobalFunction.createMonthModeWeekOfDayDropDown(this.triggerWeekDayComboBox);
            if (task.getTaskInfo()[2].Equals("MonthMode"))
            {
                DayOfWeek selectDay = GlobalFunction.convertDayOfWeekfromString(task.getTaskInfo()[3]);
                int num = Convert.ToInt32(task.getTaskInfo()[4]);
                this.triggerWeekDayComboBox.SelectedIndex = ((int)selectDay);
                this.triggerHourUpDown.Value = num;
            }
            filePathDataLabel.Text = task.getTaskInfo()[1];

            GlobalFunction.statusUpdate(statusUpdateLabel, "User creating form", false);
        }

        private void getFileExplorerBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.exploreFilePath(filePathDataLabel);
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Updating " + TypeDescriptor.GetClassName(this), false);

            string filepath = GlobalFunction.valildateFilepath(frequencyCoboBox.Text, this.filePathDataLabel.Text);
            List<string> selectCol = GlobalFunction.convertListBoxSelected_to_List(selectedColListBox.SelectedItems);
            DayOfWeek dayOfWeek = ((KeyValuePair<string, DayOfWeek>)this.triggerWeekDayComboBox.SelectedItem).Value;
            int hour = Convert.ToInt32(Math.Round(this.triggerHourUpDown.Value, 0));

            MainFunction.updateTaskSetting(this.task, filepath, this.frequencyCoboBox.Text, selectCol, dayOfWeek, hour, this.triggerDateTimePicker.Value);
            GlobalFunction.statusUpdate(statusUpdateLabel, $"Update finished, the following are the new settings: \r\n{this.task}", true);

            closePage();

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (GlobalFunction.userCheckTaskDetail("Do you want to delete the folloing task: ", task))
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "User confirm to delete task.", false);
                MainFunction.removeScheduleTask(task);
                GlobalFunction.statusUpdate(statusUpdateLabel, "Schedule Task delated.", true);
                closePage();
            }
            else
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "User deline the deletion, schedule Task not deleted.", true);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            closePage();
        }

        private void frequencyCoboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalFunction.updateModeSettingOption(this.frequencyCoboBox.Text, this.monthGroupBox, this.testGroupBox);
        }

        private void closePage()
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Back to previous page.", false);
            this.Close();
        }
    }
}
