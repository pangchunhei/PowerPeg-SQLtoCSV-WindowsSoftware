using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowerPeg_SQL_to_CSV;

namespace App_UI
{
    public partial class ChangeServerInfo : Form
    {
        public ChangeServerInfo()
        {
            InitializeComponent();
        }

        private bool validateForm()
        {
            int countPass = 0;

            if(addressTextbox.Text.Length > 0)
            {
                countPass++;
            }

            if(catalogTextbox.Text.Length > 0)
            {
                countPass++;
            }

            if(usernameTextbox.Text.Length > 0)
            {
                countPass++;
            }

            if(passwordTextbox.Text.Length > 0)
            {
                countPass++;
            }

            if(countPass >= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            Gateway g = Gateway.getInstance();
            string[] existingValue = g.getGatewayInfo();
            addressTextbox.Text = existingValue[0];
            catalogTextbox.Text = existingValue[1];
            usernameTextbox.Text = existingValue[2];
            passwordTextbox.Text = existingValue[3];
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
                Gateway g = Gateway.getInstance();
                g.updateGateway(addressTextbox.Text, catalogTextbox.Text, usernameTextbox.Text, passwordTextbox.Text);
                MessageBox.Show("New Setting Saved");
            }
            else
            {
                MessageBox.Show("Fill in all Field");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Gateway g = Gateway.getInstance();
            List<string> result = g.getDBTableColName();

            string s = "";
            foreach (var item in result)
            {
                s += item.ToString() + ", ";
            }

            Debug.WriteLine(s);

        }
    }
}
