using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAEBS_V2
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }
        private void GetServerSettings()
        {
            txtDSN.Text = CAEBS_V2.Config.DSN;
            txtHost.Text = CAEBS_V2.Config.DB_HOST;
            txtName.Text = CAEBS_V2.Config.DB_NAME;
            txtUser.Text = CAEBS_V2.Config.DB_USER;
            txtPassword.Text = CAEBS_V2.Config.DB_PASSWORD;
        }

        private bool CheckRequiredFields()
        {
            if (txtDSN.Text == "")
            {
                return false;
            }

            if (txtHost.Text == "")
            {
                return false;
            }

            if (txtName.Text == "")
            {
                return false;
            }

            if (txtUser.Text == "")
            {
                return false;
            }

            return true;
        }
        public void setThis()
        {
            if (this.CheckRequiredFields() == true)
            {
                //set properties
                CAEBS_V2.Config.DSN = txtDSN.Text;
                CAEBS_V2.Config.DB_HOST = txtHost.Text;
                CAEBS_V2.Config.DB_NAME = txtName.Text;
                CAEBS_V2.Config.DB_USER = txtUser.Text;
                CAEBS_V2.Config.DB_PASSWORD = txtPassword.Text;

                //save settings
                CAEBS_V2.Config.saveSettings();

                if (CAEBS_V2.Config.TestConnection())
                {
                    MessageBox.Show("Successfully Connected to Database", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                }
            }
            else
            {
                MessageBox.Show("Please fill out all required fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnSaveConfiguration_Click(object sender, EventArgs e)
        {
            setThis();
        }

        private void frmSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
               
                this.Dispose();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnSaveConfiguration.PerformClick();
            }
        }
    }
}
