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

            //TODO-- Update
            /*SearchTask t = MainFunction.CreateTask(frequencyCoboBox.Text, filepath, this.triggerDateTimePicker.Value, selectCol, selectThis: ((KeyValuePair<string, bool?>)this.selectThisCoboBox.SelectedItem).Value, taskname: taskNameDataLabel.Text);

            if (GlobalFunction.userCheckTaskDetail("Please check the task settings: ", t))
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "User confirm the settings, now run task.", false);

                try
                {
                    MainFunction.addScheduleTask(t);
                }
                catch (Exception ex)
                {
                    GlobalFunction.statusUpdate(statusUpdateLabel, ex.Message, true);
                }

                GlobalFunction.statusUpdate(statusUpdateLabel, "Finished schedule task setup.", true);
            }
            else
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "User deline the settings, discard task.", true);
                resetForm();
            }
            */
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

            this.triggerDateTimePicker.Value = DateTime.Now;

            this.selectedColListBox.Items.Add("-- All --");
            this.selectedColListBox.SelectedItem = "-- All --";

            List<string> col2 = MainFunction.getGenerationScheduledModeName();

            foreach (string s in col2)
            {
                frequencyCoboBox.Items.Add(s);
            }
            frequencyCoboBox.SelectedIndex = 0;

            GlobalFunction.statusUpdate(statusUpdateLabel, "User creating form", false);
        }

        private void getFileExplorerBtn_Click(object sender, EventArgs e)
        {
            filePathDataLabel.Text = GlobalFunction.exploreFilePath();
            this.filePathDataLabel.Visible = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Cancel and back to previous page.", false);
            this.Close();
        }

        private void frequencyCoboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void AdjustWidthComboBox_DropDown(object sender, EventArgs e)
        {
            GlobalFunction.adjustCoboBoxDropdownWidth((ComboBox)sender);
        }
    }
}
