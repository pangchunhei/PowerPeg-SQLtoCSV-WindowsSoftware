using ChoETL;
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
    public partial class CreateNewTask : Form
    {
        public CreateNewTask()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.filePathDataLabel.Visible = false;

            GlobalFunction.statusUpdate(statusUpdateLabel, "Loading CreateNewTask.", false);
        }

        public void resetForm()
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Resetting form CreateNewTask.", false);
            Form NewForm = new CreateNewTask();
            NewForm.Show();
            this.Dispose(false);
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Processing" + TypeDescriptor.GetClassName(this), false);

            string filepath = GlobalFunction.valildateFilepath(frequencyCoboBox.Text, this.filePathDataLabel.Text);
            List<string> selectCol = GlobalFunction.convertListBoxSelected_to_List(selectedColListBox.SelectedItems);
            DayOfWeek dayOfWeek = ((KeyValuePair<string, DayOfWeek>)this.triggerWeekDayComboBox.SelectedItem).Value;
            int hour = Convert.ToInt32(Math.Round(this.triggerHourUpDown.Value, 0));

            SearchTask t = MainFunction.CreateTask(frequencyCoboBox.Text, filepath, selectCol, m_triggerdayofweek: dayOfWeek, m_triggerhour: hour, t_triggerdatetime: this.triggerDateTimePicker.Value, taskname: taskNameDataLabel.Text);

            if (GlobalFunction.userCheckTaskDetail("Please check the task settings: ", t))
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "User confirm the settings, now run task.", false);

                try
                {
                    MainFunction.addScheduleTask(t);
                    GlobalFunction.statusUpdate(statusUpdateLabel, "Finished schedule task setup.", true);
                    closePage();
                }
                catch (Exception ex)
                {
                    GlobalFunction.statusUpdate(statusUpdateLabel, ex.Message, true);
                }
            }
            else
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "User deline the settings, discard task.", true);
                resetForm();
            }
        }

        private void CreateNewTask_Load(object sender, EventArgs e)
        {
            /*
            TODO-- Select specific device
            
            List<string> col = MainFunction.getDatabaseColumnName();

            selectedColListBox.Items.Add("-- All --");
            foreach (string s in col)
            {
                selectedColListBox.Items.Add(s);
            }
            selectedColListBox.SelectedItem = "-- All --";
            */

            //TODO--this.triggerDateTimePicker.Value = DateTime.Now;

            this.selectedColListBox.Items.Add("-- All --");
            this.selectedColListBox.SelectedItem = "-- All --";

            GlobalFunction.createModeTypeDropDown(this.frequencyCoboBox);
            this.frequencyCoboBox.SelectedIndex = 0;

            GlobalFunction.createMonthModeWeekOfDayDropDown(this.triggerWeekDayComboBox);
            this.triggerWeekDayComboBox.SelectedIndex = 0;

            GlobalFunction.statusUpdate(statusUpdateLabel, "User creating form", false);
        }

        private void getFileExplorerBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.exploreFilePath(filePathDataLabel);
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
            GlobalFunction.statusUpdate(statusUpdateLabel, "Cancel and back to previous page.", false);
            this.Close();
        }
    }
}
