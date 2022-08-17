using PowerPeg_SQL_to_CSV;

namespace App_UI
{
    public partial class ChangeServerInfo : Form
    {
        public ChangeServerInfo()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private bool validateForm()
        {

            if (addressTextbox.Text.Length == 0 || catalogTextbox.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void addressTextbox_TextChanged(object sender, EventArgs e)
        {

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

        private void catalogTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            if (validateForm())
            {
                GlobalFunction.statusUpdate(statusUpdateLabel, "Trying to update.........", false);

                if (DatabaseGateway.getInstance().updateGateway(addressTextbox.Text, catalogTextbox.Text, usernameTextbox.Text, passwordTextbox.Text))
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
            this.Close();
        }
    }
}
