using System.Diagnostics;
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
            List<string> result = g.getDBTableColName();

            foreach(string s in result)
            {
                selectedColListBox.Items.Add(s);
            }
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

        }

        private void filePathDataLabel_Click(object sender, EventArgs e)
        {

        }

        private List<string> convertListBoxSelected_to_List(ListBox.SelectedObjectCollection listBoxList)
        {
            List<string> output = new List<string>();

            foreach(var s in listBoxList)
            {
                output.Add(s.ToString());
            }

            return output;
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {

            Mode m = new InstantMode(fromDateCalendar.SelectionRange.Start, toDateCalendar.SelectionRange.Start, DateTime.Now, convertListBoxSelected_to_List(selectedColListBox.SelectedItems));

            SearchTask t = new SearchTask("./C", m);

            foreach(var s in t.getTaskInfo())
            {
                Debug.WriteLine(s);
            }
            
            //Task t = new Task();
            //Debug.WriteLine("[{0}]", string.Join(", ", yourArray);

            //Debug.WriteLine(fromDateCalendar.SelectionRange.Start.GetType() + " " + fromDateCalendar.SelectionRange.Start.ToString());
        }
    }
}