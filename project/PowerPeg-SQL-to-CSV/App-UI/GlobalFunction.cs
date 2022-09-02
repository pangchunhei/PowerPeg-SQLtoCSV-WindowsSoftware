using log4net;
using PowerPeg_SQL_to_CSV;
using PowerPeg_SQL_to_CSV.Log;
using PowerPeg_SQL_to_CSV.Mode;
using System.Configuration;
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
            return t.ToString();
        }

        public static bool userCheckTaskDetail(string question, SearchTask task)
        {
            string msg = question + "\n" + GlobalFunction.searchTaskDetail_to_string(task);

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

        public static string getDefaultFilePath(string mode)
        {
            string path;

            if (mode.Equals("InstantMode"))
            {
                path = ConfigurationManager.AppSettings["InstantGenPath"] + "\\";
            }
            else
            {
                path = ConfigurationManager.AppSettings["AutoGenPath"] + "\\";
            }

            try
            {
                FileInfo file = new FileInfo(path);
                file.Directory.Create();
                return path;
            }
            catch (IOException ex)
            {
                path = AppDomain.CurrentDomain.BaseDirectory + "\\output\\";

                FileInfo file = new FileInfo(path);
                file.Directory.Create();

                return path;
            }

        }
    }
}
