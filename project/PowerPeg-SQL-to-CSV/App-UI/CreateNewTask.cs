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
        }

        public void resetForm()
        {
            Form NewForm = new CreateNewTask();
            NewForm.Show();
            this.Dispose(false);
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Processing" + TypeDescriptor.GetClassName(this), false);
            //TODO-- Gen
            if (filePathDataLabel.Text.Equals("<Select Path>"))
            {
                MessageBox.Show("Please select output folder.");
            }
            else
            {
                List<string> selectCol = GlobalFunction.convertListBoxSelected_to_List(selectedColListBox.SelectedItems);
                SearchTask t = MainFunction.CreateTask("Month", filePathDataLabel.Text, DateTime.Now, selectCol, taskname: taskNameDataLabel.Text);

                if (GlobalFunction.userCheckTaskDetail(t))
                {
                    GlobalFunction.statusUpdate(statusUpdateLabel, "User confirm the settings, now run task.", false);
                    MainFunction.addScheduleTask(t);
                    GlobalFunction.statusUpdate(statusUpdateLabel, "Finished schedule task setup.", true);
                }
                else
                {
                    GlobalFunction.statusUpdate(statusUpdateLabel, "User deline the settings, discard task.", true);
                    MainFunction.taskNotCreated();
                    resetForm();
                }
            }
        }

        private void CreateNewTask_Load(object sender, EventArgs e)
        {
            List<string> col = MainFunction.getDatabaseColumnName();

            selectedColListBox.Items.Add("-- All --");
            foreach (string s in col)
            {
                selectedColListBox.Items.Add(s);
            }
            selectedColListBox.SelectedItem = "-- All --";

            GlobalFunction.statusUpdate(statusUpdateLabel, "User creating form", false);
        }

        private void getFileExplorerBtn_Click(object sender, EventArgs e)
        {
            filePathDataLabel.Text = GlobalFunction.exploreFilePath();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
