using PowerPeg_SQL_to_CSV;

namespace App_UI
{
    public partial class ChangeServerInfo : Form
    {
        public ChangeServerInfo()
        {
            InitializeComponent();
            this.ControlBox = false;

            GlobalFunction.statusUpdate(statusUpdateLabel, "Loading ChangeServerInfo.", false);
        }

        private bool validateForm()
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Validate input.", false);
            if (addressTextbox.Text.Length == 0 || catalogTextbox.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void ChangeServerInfo_Load(object sender, EventArgs e)
        {
            string[] existingValue = MainFunction.getDatabaseInformation();

            addressTextbox.Text = existingValue[0];
            catalogTextbox.Text = existingValue[1];
            usernameTextbox.Text = existingValue[2];
            passwordTextbox.Text = existingValue[3];

            GlobalFunction.statusUpdate(statusUpdateLabel, "User updating form", false);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            if (validateForm())
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "Trying to update.........", false);

                if (MainFunction.updateDatabaseGateway(addressTextbox.Text, catalogTextbox.Text, usernameTextbox.Text, passwordTextbox.Text))
                {
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

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            GlobalFunction.statusUpdate(statusUpdateLabel, "Closing ChangeServerInfo and Go back to previous page..", false);
            this.Close();
        }
    }
}
