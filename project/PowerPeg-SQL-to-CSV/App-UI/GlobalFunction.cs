using log4net;
using PowerPeg_SQL_to_CSV;
using PowerPeg_SQL_to_CSV.Log;
using System.Text;

namespace App_UI
{
    public static class GlobalFunction
    {
        private static readonly ILog log = LogHelper.getLogger();

        public static void statusUpdate(Label updateLabel, string msg, bool needAlertBox)
        {
            updateLabel.Text = msg;
            updateLabel.Refresh();

            if (needAlertBox)
            {
                MessageBox.Show(msg);
            }

            log.Info(msg);
        }

        public static string exploreFilePath()
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

            return "<Select Path>";
        }

        public static List<string> convertListBoxSelected_to_List(ListBox.SelectedObjectCollection listBoxList)
        {
            List<string> output = new List<string>();

            foreach (var s in listBoxList)
            {
                if (s.ToString().Equals("-- All --"))
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
        
        public static string searchTaskDetail_to_string(SearchTask t)
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
        
        public static bool userCheckTaskDetail(SearchTask task)
        {
            string msg = "Please check the task settings: \n" + GlobalFunction.searchTaskDetail_to_string(task);

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(msg, "Confirm", buttons);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
