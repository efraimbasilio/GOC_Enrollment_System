using MySqlX.XDevAPI.Relational;
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
    public partial class frmMain : Form
    {
        
        public frmMain()
        {
            InitializeComponent();
           

            #region LOAD Dashboard
            pnlAllContainer.Controls.Clear();
            pnlAllContainer.Visible = true;
            //load the form
            frmDashboard frm = new frmDashboard();
            frm.TopLevel = false;
            frm.AutoScroll = true;

            pnlAllContainer.Controls.Add(frm);
            frm.Show();
            #endregion
        }

       

        private void btnBilling_Click(object sender, EventArgs e)
        {
            #region To Billing Form
                pnlAllContainer.Controls.Clear();
                pnlAllContainer.Visible = true;

                //load the form
                frmBilling billing = new frmBilling();
                billing.TopLevel = false;
                billing.AutoScroll = true;

                pnlAllContainer.Controls.Add(billing);
                billing.Show();
            #endregion
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            #region To report Form
            pnlAllContainer.Controls.Clear();
            pnlAllContainer.Visible = true;

            //load the form
            frmReports report = new frmReports();
            report.TopLevel = false;
            report.AutoScroll = true;

            pnlAllContainer.Controls.Add(report);
            report.Show();
            #endregion
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            #region To Maintenance Form
            pnlAllContainer.Controls.Clear();
            pnlAllContainer.Visible = true;

            //load the form
            frmMaintenance maintenance = new frmMaintenance();
            maintenance.TopLevel = false;
            maintenance.AutoScroll = true;

            pnlAllContainer.Controls.Add(maintenance);
            maintenance.Show();
            #endregion
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            this.Dispose();
            frm.ShowDialog();
        }

        private void pnlAllContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistration_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            frmNewStudent newStud = new frmNewStudent();
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];

            mainwin.pnlAllContainer.Controls.Clear();
            mainwin.pnlAllContainer.Visible = true;

            newStud.TopLevel = false;
            newStud.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(newStud);
           
            newStud.toSave = true;
            newStud.formToMaxSize();
            newStud.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            #region To Maintenance Form
            pnlAllContainer.Controls.Clear();
            pnlAllContainer.Visible = true;

            //load the form
            frmMaintenance maintenance = new frmMaintenance();
            maintenance.TopLevel = false;
            maintenance.AutoScroll = true;

            pnlAllContainer.Controls.Add(maintenance);
            maintenance.Show();
            #endregion
        }

        private void button10_Click(object sender, EventArgs e)
        {
            #region To Settings Form
            pnlAllContainer.Controls.Clear();
            pnlAllContainer.Visible = true;

            //load the form
            frmSettings settings = new frmSettings();
            settings.TopLevel = false;
            settings.AutoScroll = true;

            pnlAllContainer.Controls.Add(settings);
            settings.Show();
            #endregion
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnlAllContainer.Controls.Clear();
            pnlAllContainer.Visible = true;

            //load the form
            frmTheStudentList assess = new frmTheStudentList();
            assess.TopLevel = false;
            assess.AutoScroll = true;

            pnlAllContainer.Controls.Add(assess);
            assess.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region To Assessment Form
            pnlAllContainer.Controls.Clear();
            pnlAllContainer.Visible = true;

            //load the form
            frmDashboard assess = new frmDashboard();
            assess.TopLevel = false;
            assess.AutoScroll = true;

            pnlAllContainer.Controls.Add(assess);
            assess.Show();
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           

        }

        System.Windows.Forms.Timer t = null;
        private void StartTimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblTime.Text = now.ToString("T");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            StartTimer();
            DateTime now = DateTime.Now;
            lblDate.Text = now.ToString("MMMM dd, yyyy");          
        }
    }
}
