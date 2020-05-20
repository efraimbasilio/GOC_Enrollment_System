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
    public partial class frmPayBill : Form
    {
        private double a;
        private double b;

        public frmPayBill()
        {
            InitializeComponent();
        }

        private void txtAmountTender_Leave(object sender, EventArgs e)
        {
            a = Convert.ToDouble(txtAmountTender.Text);
            txtAmountTender.Text = a.ToString("n");

            if (Convert.ToDouble(txtAmountTender.Text) < Convert.ToDouble(lblAmount.Text))
            {
                string message = "Please pay the exact amount.";
                string title = "Enrollment System";

                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                b =   Convert.ToDouble(txtAmountTender.Text) - Convert.ToDouble(lblAmount.Text);
                txtChange.Text = b.ToString("n");
            }            
        }

        private void txtAmountTender_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
