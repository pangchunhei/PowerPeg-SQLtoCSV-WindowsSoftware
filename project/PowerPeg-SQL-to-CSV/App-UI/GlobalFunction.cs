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

            return "<Select Default Path>";
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

        /// <summary>
        /// Get check the user input path is correct and get the default path if necessary
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inputPath"></param>
        /// <returns></returns>
        public static string valildateFilepath(string mode, string inputPath)
        {
            string path;

            if (inputPath.Equals("<Select Default Path>"))
            {
                log.Debug("System get the default path info.");

                MessageBox.Show("No folder path selected, sytem will use the default.");

                if (mode.Equals("InstantMode"))
                {
                    path = ConfigurationManager.AppSettings["InstantGenPath"] + "\\";
                }
                else
                {
                    path = ConfigurationManager.AppSettings["AutoGenPath"] + "\\";
                }
            }
            else
            {
                log.Debug("Use user input path.");
                path = inputPath;
            }

            try
            {
                log.Debug("Try path info.");

                FileInfo file = new FileInfo(path);
                file.Directory.Create();
                return path;
            }
            catch (IOException ex)
            {
                log.Error($"Problem in default file path, now store in application output folder. {ex.ToString()}");

                MessageBox.Show("Problem in path, now store in application output folder.");

                path = AppDomain.CurrentDomain.BaseDirectory + "\\output\\";

                FileInfo file = new FileInfo(path);
                file.Directory.Create();

                return path;
            }
        }

        /// <summary>
        /// To change the dropdown size to show whole sentance
        /// </summary>
        /// <param name="sender">The combobox that want to change size</param>
        public static void adjustCoboBoxDropdownWidth(ComboBox sender)
        {
            ComboBox selectThisCoboBox = sender;
            int width = selectThisCoboBox.DropDownWidth;
            Graphics g = selectThisCoboBox.CreateGraphics();
            Font font = selectThisCoboBox.Font;
            int vertScrollBarWidth =
                (selectThisCoboBox.Items.Count > selectThisCoboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (var displayItem in sender.Items)
            {
                string s = ((KeyValuePair<string, bool?>)displayItem).Key;

                newWidth = (int)g.MeasureString(s, font).Width + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            selectThisCoboBox.DropDownWidth = width;
        }
    }
}
