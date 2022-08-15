using System.Diagnostics;
using System.Windows.Forms;
using PowerPeg_SQL_to_CSV;

namespace App_UI
{
    public partial class InstantGenerationOptionForm : Form
    {
        public InstantGenerationOptionForm()
        {
            InitializeComponent();
        }

        private void InstantGenerationOptionForm_Load(object sender, EventArgs e)
        {
            serverInfoDataLabel.Text = Gateway.getInstance().getGatewayInfo()[0];

            Gateway g = Gateway.getInstance();
            List<string> col = g.getDBTableColName();
            selectedColListBox.Items.Add("-- All --");
            foreach(string s in col)
            {
                selectedColListBox.Items.Add(s);
            }
            selectedColListBox.SelectedItem = "-- All --";

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

        private string exploreFilePath()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    return fbd.SelectedPath;

                    //System.Windows.Forms.MessageBox.Show("Files found: " + fbd.SelectedPath, "Message");
                }
            }

            return null;
        }

        private void getFileExplorerBtn_Click(object sender, EventArgs e)
        {
            filePathDataLabel.Text = exploreFilePath();

        }

        private List<string> convertListBoxSelected_to_List(ListBox.SelectedObjectCollection listBoxList)
        {
            List<string> output = new List<string>();

            foreach(var s in listBoxList)
            {
                if(s.ToString().Equals("-- All --"))
                {
                    output.Clear();
                    output.Add("*");
                    return output;
                }
                else
                {
                    output.Add(s.ToString());
                }
            }

            return output;
        }

        private string searchTaskDetail_to_string(SearchTask t)
        {
            string msg = "";
            string[] title = { "Task Name", "Output Location", "Mode Name", "Trigger DateTime", "Start Search Date", "End Search Date", "Selected Column List" };
            int i = 0;
            foreach (var s in t.getTaskInfo())
            {
                msg += title[i] + ": " + s + "\n";
                i++;
            }

            return msg;
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            if(filePathDataLabel.Text.Equals("<Select Path>"))
            {
                MessageBox.Show("Please select output folder.");
            }
            else
            {
                Mode m = new InstantMode(fromDateCalendar.SelectionRange.Start, toDateCalendar.SelectionRange.Start, DateTime.Now, convertListBoxSelected_to_List(selectedColListBox.SelectedItems));
                SearchTask t = new SearchTask(filePathDataLabel.Text, m);

                string msg = "Please check the task settings: \n" + searchTaskDetail_to_string(t);

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(msg, "Confirm", buttons);
                if (result == DialogResult.Yes)
                {
                    //Trigger the task
                    MessageBox.Show("Task created, now processing.");
                    t.toRun();
                    MessageBox.Show("Finished output.");
                }
                else
                {
                    MessageBox.Show("Task not created, please re enter.");
                    Form NewForm = new InstantGenerationOptionForm();
                    NewForm.Show();
                    this.Dispose(false);
                }

                //Task t = new Task();
                //Debug.WriteLine("[{0}]", string.Join(", ", yourArray);

                //Debug.WriteLine(fromDateCalendar.SelectionRange.Start.GetType() + " " + fromDateCalendar.SelectionRange.Start.ToString());
            }

            
        }
    }
}