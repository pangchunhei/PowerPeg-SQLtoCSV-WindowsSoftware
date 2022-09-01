using PowerPeg_SQL_to_CSV;

namespace App_UI
{
    public partial class ShowServerInfo : Form
    {
        public ShowServerInfo()
        {
            InitializeComponent();
            this.ControlBox = false;

            GlobalFunction.statusUpdate(statusUpdateLabel, "Loading ShowServerInfo.", false);
        }

        private bool validateForm()
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Validate input.", false);
            if (connectionStrTextbox.Text.Length == 0 || tableTextbox.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void ChangeServerInfo_Load(object sender, EventArgs e)
        {
            //TODO--No seeing
            connectionStrTextbox.Text = MainFunction.getDatabaseInformation()[0] + "\r\n" + MainFunction.getDatabaseInformation()[1];
            tableTextbox.Text = string.Join("\r\n",MainFunction.getDatabaseSelectedTable());

            GlobalFunction.statusUpdate(statusUpdateLabel, "User updating form", false);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            if (validateForm())
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "Trying to update.........", false);

                if (MainFunction.updateDatabaseGateway(connectionStrTextbox.Text))
                {
                    string[] str = tableTextbox.Text.Split("\r\n");
                    List<string> strList = new List<string>(str);

                    MainFunction.updateDatabaseSelectedTable(strList);
                    GlobalFunction.statusUpdate(statusUpdateLabel, "New Setting Saved.", true);
                }
                else
                {
                    GlobalFunction.statusUpdate(statusUpdateLabel, "Fail to connect.", true);
                }

            }
            else
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "Fill in Address and Catalog.", true);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Closing ShowServerInfo and Go back to previous page..", false);
            this.Close();
        }
    }
}
