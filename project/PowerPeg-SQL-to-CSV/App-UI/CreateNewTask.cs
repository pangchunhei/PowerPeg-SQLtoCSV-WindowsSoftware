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
    public partial class CreateNewTask : Form
    {
        public CreateNewTask()
        {
            InitializeComponent();
            this.ControlBox = false;
            GlobalFunction.statusUpdate(statusUpdateLabel, "Loading CreateNewTask.", false);
        }

        public void resetForm()
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Resetting form CreateNewTask.", false);
            Form NewForm = new CreateNewTask();
            NewForm.Show();
            this.Dispose(false);
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Processing" + TypeDescriptor.GetClassName(this), false);

            if (filePathDataLabel.Text.Equals("<Select Path>"))
            {
                MessageBox.Show("Please select output folder.");
            }
            else
            {
                List<string> selectCol = GlobalFunction.convertListBoxSelected_to_List(selectedColListBox.SelectedItems);

                SearchTask t = MainFunction.CreateTask(frequencyCoboBox.Text, filePathDataLabel.Text, DateTime.Now, selectCol, selectThis: Convert.ToBoolean(selectThisCoboBox.SelectedItem), taskname: taskNameDataLabel.Text);

                if (GlobalFunction.userCheckTaskDetail("Please check the task settings: ", t))
                {
                    GlobalFunction.statusUpdate(statusUpdateLabel, "User confirm the settings, now run task.", false);
                    MainFunction.addScheduleTask(t);
                    GlobalFunction.statusUpdate(statusUpdateLabel, "Finished schedule task setup.", true);
                }
                else
                {
                    GlobalFunction.statusUpdate(statusUpdateLabel, "User deline the settings, discard task.", true);
                    resetForm();
                }
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

            selectedColListBox.Items.Add("-- All --");
            selectedColListBox.SelectedItem = "-- All --";
            
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
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Cancel and back to previous page.", false);
            this.Close();
        }

        private void frequencyCoboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frequencyCoboBox.Text.Equals("MonthMode")){
                this.selectThisCoboBox.Visible = true;

                this.selectThisCoboBox.Items.Clear();
                //True
                this.selectThisCoboBox.Items.Insert(Convert.ToInt32(true), "Use trigger month's day as month duration");
                //False
                this.selectThisCoboBox.Items.Insert(Convert.ToInt32(false), "Use trigger month's previrous's month's day as month duration");
                this.selectThisCoboBox.SelectedIndex = 0;
            }
            else
            {
                this.selectThisCoboBox.Visible = false;
                this.selectThisCoboBox.Items.Clear();
            }
        }
    }
}
