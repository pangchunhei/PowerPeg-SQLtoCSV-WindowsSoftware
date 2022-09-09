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
            this.triggerDateTimePicker.Value = task.getMode().getTriggerDateTime();

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

            List<string> col3 = MainFunction.getGenerationScheduledModeName();

            foreach (string s in col3)
            {
                frequencyCoboBox.Items.Add(s);
            }
            frequencyCoboBox.SelectedItem = task.getTaskInfo()[2];

            GlobalFunction.setFrequencyDurationDetailOptionList(this.frequencyCoboBox, this.selectThisCoboBox);

            if (task.getTaskInfo()[2] == "MonthMode")
            {
                if (Convert.ToBoolean(task.getTaskInfo()[task.getTaskInfo().Length - 1]))
                {
                    selectThisCoboBox.SelectedIndex = 0;
                }
                else
                {
                    selectThisCoboBox.SelectedIndex = 1;
                }
            }
            else
            {
                selectThisCoboBox.SelectedIndex = 0;
            }

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

            //TODO--Filepath
            string filepath = GlobalFunction.getDefaultFilePath(this.task.getTaskInfo()[2], this.filePathDataLabel.Text);

            List<string> selectCol = GlobalFunction.convertListBoxSelected_to_List(selectedColListBox.SelectedItems);
            MainFunction.updateTaskSetting(this.task, this.frequencyCoboBox.Text, filepath, this.triggerDateTimePicker.Value, selectCol, ((KeyValuePair<string, bool?>)this.selectThisCoboBox.SelectedItem).Value);
            GlobalFunction.statusUpdate(statusUpdateLabel, $"Update finished, the following are the new settings: \r\n{task}", true);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (GlobalFunction.userCheckTaskDetail("Do you want to delete the folloing task: ", task))
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "User confirm to delete task.", false);
                MainFunction.removeScheduleTask(task);
                GlobalFunction.statusUpdate(statusUpdateLabel, "Schedule Task delated.", true);
                this.Close();
            }
            else
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "User deline the deletion, schedule Task not deleted.", true);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Back to previous page.", false);
            this.Close();
        }

        private void frequencyCoboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalFunction.setFrequencyDurationDetailOptionList(this.frequencyCoboBox, this.selectThisCoboBox);
        }

        private void AdjustWidthComboBox_DropDown(object sender, EventArgs e)
        {
            GlobalFunction.adjustCoboBoxDropdownWidth((ComboBox)sender);
        }

        //TODO-- CHnage the quick select for the previous month
    }
}
