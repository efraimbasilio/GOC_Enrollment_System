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
    public partial class frmChoosePayment : Form
    {
        public frmChoosePayment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPayment frm_payment = new frmPayment();
            frm_payment.grpPayment.Visible = true;
            #region Call Form       
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
            mainwin.pnlAllContainer.Controls.Clear();

            frm_payment.TopLevel = false;
            frm_payment.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(frm_payment);
            // frm_assess.formToMaxSize();
            frm_payment.Show();
            #endregion

            this.Close();
        }
    }
}
