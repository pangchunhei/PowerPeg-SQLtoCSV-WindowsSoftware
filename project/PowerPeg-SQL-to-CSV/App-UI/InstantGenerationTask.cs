using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowerPeg_SQL_to_CSV;

namespace App_UI
{
    public partial class InstantGenerationTask : Form
    {
        public InstantGenerationTask()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void InstantGenerationOptionForm_Load(object sender, EventArgs e)
        {
            string[] info = MainFunction.getDatabaseInformation();
            serverInfoDataLabel.Text = info[0] + " - " + info[1];

            /*
            TODO-- Select specific device
            List<string> col = MainFunction.getDatabaseColumnName();
            selectedColListBox.Items.Add("-- All --");
            foreach(string s in col)
            {
                selectedColListBox.Items.Add(s);
            }
            */

            selectedColListBox.Items.Add("-- All --");
            selectedColListBox.SelectedItem = "-- All --";

            GlobalFunction.statusUpdate(statusUpdateLabel, "User creating form", false);
        }

        private void getFileExplorerBtn_Click(object sender, EventArgs e)
        {
            filePathDataLabel.Text = GlobalFunction.exploreFilePath();

        }

        public void resetForm()
        {
            Form NewForm = new InstantGenerationTask();
            NewForm.Show();
            this.Dispose(false);
        }

        private bool validate()
        {
            string filepath = this.filePathDataLabel.Text;

            if (filepath.Equals("<Select Default Path>"))
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "System will select the default path.", true);
                filepath = GlobalFunction.getDefaultFilePath("InstantMode");
            }

            if (!(fromDateCalendar.SelectionRange.Start < toDateCalendar.SelectionRange.Start))
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "From date need to be earlier than To date.", true);
                return false;
            }

            return true;
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Processing " + TypeDescriptor.GetClassName(this), false);

            if (!(fromDateCalendar.SelectionRange.Start < toDateCalendar.SelectionRange.Start))
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "From date need to be earlier than To date.", true);
            }
            else
            {
                string filepath = this.filePathDataLabel.Text;

                if (filepath.Equals("<Select Default Path>"))
                {
                    GlobalFunction.statusUpdate(statusUpdateLabel, "System will select the default path.", true);
                    filepath = GlobalFunction.getDefaultFilePath("InstantMode");
                }

                List<string> selectCol = GlobalFunction.convertListBoxSelected_to_List(selectedColListBox.SelectedItems);
                SearchTask t = MainFunction.CreateTask("InstantMode", filepath, DateTime.Now, selectCol, fromDateCalendar.SelectionRange.Start, toDateCalendar.SelectionRange.Start);

                if (GlobalFunction.userCheckTaskDetail("Please check the task settings: ", t))
                {
                    GlobalFunction.statusUpdate(statusUpdateLabel, "User confirm the settings, now run task.", false);
                    MainFunction.runTaskNow(t);
                    GlobalFunction.statusUpdate(statusUpdateLabel, "Finished the task, please check the output csv.", true);
                }
                else
                {
                    GlobalFunction.statusUpdate(statusUpdateLabel, "User deline the settings, discard task.", true);
                    resetForm();
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Back to previous page.", false);
            this.Close();
        }

        private void past30Btn_Click(object sender, EventArgs e)
        {
            fromDateCalendar.SetDate(DateTime.Now.AddDays(-30));
            toDateCalendar.SetDate(DateTime.Now);
        }

        private void past60Btn_Click(object sender, EventArgs e)
        {
            fromDateCalendar.SetDate(DateTime.Now.AddDays(-60));
            toDateCalendar.SetDate(DateTime.Now);
        }

        private void past90Btn_Click(object sender, EventArgs e)
        {
            fromDateCalendar.SetDate(DateTime.Now.AddDays(-90));
            toDateCalendar.SetDate(DateTime.Now);
        }
    }
}