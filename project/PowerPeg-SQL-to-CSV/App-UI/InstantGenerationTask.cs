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
            serverInfoDataLabel.Text = Gateway.getInstance().getGatewayInfo()[0];

            List<string> col = Gateway.getInstance().getDBTableColName();
            selectedColListBox.Items.Add("-- All --");
            foreach(string s in col)
            {
                selectedColListBox.Items.Add(s);
            }
            selectedColListBox.SelectedItem = "-- All --";

            GlobalFunction.statusUpdate(statusUpdateLabel, "User creating form", false);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fromDateCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void toDateCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void selectFieldListView_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void generateBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Processing " + TypeDescriptor.GetClassName(this), false);

            if (filePathDataLabel.Text.Equals("<Select Path>"))
            {
                MessageBox.Show("Please select output folder.");
            }
            else
            {
                Mode m = new InstantMode(fromDateCalendar.SelectionRange.Start, toDateCalendar.SelectionRange.Start, DateTime.Now, GlobalFunction.convertListBoxSelected_to_List(selectedColListBox.SelectedItems));
                SearchTask t = new SearchTask(filePathDataLabel.Text, m);

                if (GlobalFunction.userCheckTaskDetail(t))
                {
                    GlobalFunction.statusUpdate(statusUpdateLabel, "User confirm the settings, now run task.", false);
                    MainFunction.createTask(t);
                    GlobalFunction.statusUpdate(statusUpdateLabel, "Finished the task, please check the output csv.", true);
                }
                else
                {
                    GlobalFunction.statusUpdate(statusUpdateLabel, "User deline the settings, discard task.", true);
                    MainFunction.taskNotCreated();
                    resetForm();
                }

                //Task t = new Task();
                //Debug.WriteLine("[{0}]", string.Join(", ", yourArray);

                //Debug.WriteLine(fromDateCalendar.SelectionRange.Start.GetType() + " " + fromDateCalendar.SelectionRange.Start.ToString());
            }

            
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}