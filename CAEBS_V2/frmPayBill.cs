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

        Register r = new Register();
        List<Register> ListRegister = new List<Register>();
        ZCtr ctr = new ZCtr();
        List<ZCtr> ctrs = new List<ZCtr>();
        Util_RequiredFields util = new Util_RequiredFields();
        frmDashboard dash_info = new frmDashboard();
        public int i = 0, x = 0;
        public string reg_no;

        public frmPayBill()
        {
            InitializeComponent();
        }

        public void Generate_StudNo()
        {
            if (r.save_halt == false)
            {
                ctrs.Clear();
                ctrs = ctr.Load();
                foreach (var item in ctrs)
                {
                    i = Convert.ToInt32(item.Ctr_goc_no) + 1;
                    x = item.Id;
                }
                ctr.Id = x;
                ctr.Ctr_goc_no = i.ToString();
                ctr.Update_CTR_GOC_NO();

                string str = DateTime.Today.ToString("yyyy");
                string a = str.Substring(2);
                string output = a +"-"+ (i).ToString("0000");
                //txtRegNo.Text = output;

                r.Reg_no = reg_no;
                r.Stud_no = output;
                r.Update_For_StudentNo();
            }
            else
            {
                return;
            }

        }
        private void txtAmountTender_Leave(object sender, EventArgs e)
        {
            //a = Convert.ToDouble(txtAmountTender.Text);
            //txtAmountTender.Text = a.ToString("n");

            //if (Convert.ToDouble(txtAmountTender.Text) < Convert.ToDouble(lblAmount.Text))
            //{
            //    string message = "Please pay the exact amount.";
            //    string title = "Enrollment System";

            //    MessageBoxButtons buttons = MessageBoxButtons.OK;
            //    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            //    txtAmountTender.Focus();
            //    return;
               
            //}
            //else
            //{
            //    b =   Convert.ToDouble(txtAmountTender.Text) - Convert.ToDouble(lblAmount.Text);
            //    txtChange.Text = b.ToString("n");
            //}            
        }

        private void txtAmountTender_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPay_Click(object sender, EventArgs e)
        {
           Generate_StudNo();
        }

        private void txtAmountTender_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtAmountTender.Text.Equals(""))
            {
                txtAmountTender.Text = "0.00";
                txtChange.Text = "0.00";
            }

            if (e.KeyCode == Keys.Enter)
            {
                a = Convert.ToDouble(txtAmountTender.Text);
                txtAmountTender.Text = a.ToString("n");

                if (Convert.ToDouble(txtAmountTender.Text) < Convert.ToDouble(lblAmount.Text))
                {
                    string message = "Please pay the exact amount.";
                    string title = "Enrollment System";

                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    txtAmountTender.Focus();
                    txtChange.Text = "0.00";
                    return;

                }
                else
                {
                    b = Convert.ToDouble(txtAmountTender.Text) - Convert.ToDouble(lblAmount.Text);
                    txtChange.Text = b.ToString("n");
                    btnPay.Focus();
                }
            }
           
        }
    }
}
