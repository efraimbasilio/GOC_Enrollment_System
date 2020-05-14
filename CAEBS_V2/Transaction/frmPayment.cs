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
    public partial class frmPayment : Form
    {
        public string LRN, StudNo, FName, LName, MName, GLevel, Section, Strand, Voucher;
        public int id;

        PaymentLog pay = new PaymentLog();
        List<PaymentLog> payLogs = new List<PaymentLog>();

        TransUniform trans = new TransUniform();

        //#####################################################################################################################################################//

        public void reservation(string amountGiven)
        {
            if (amountGiven.Equals("1000"))
            {
                DialogResult result = MessageBox.Show("Payment will serve as a reservation fee, Do you want to continue?", "Enrollment System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //process reservation fee
                    MessageBox.Show("Reserved!");
                }
                else
                {
                   // txtAmountGiven.Focus();
                    return;
                }
            } 
                
        }

        public void ToPay()
        {
            lblLRN.Text = LRN;
            lblStudNo.Text = StudNo;
            lblFullName.Text = LName + ". " + FName + " " + MName;
            lblGLevel.Text = GLevel;
            lblSection.Text = Section;
            lblStrand.Text = Strand;
            lblVoucher.Text = Voucher;


            //SELECT unif_item.item_name, unif_item.price,trans_unif_fee.unif_qty,trans_unif_fee.unif_size
            //FROM unif_item u1
            //INNER JOIN trans_unif_fee u2
            //ON u1.unif_code = u2.unif_code
            //WHERE u2.lrn = "LRN";

            trans.TransUnif(dgvUnif, LRN);


        }


        //#####################################################################################################################################################//

        public frmPayment()
        {
            InitializeComponent();
            

        }

        //#####################################################################################################################################################//


        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Do you want to print the COR?";
            string title = "Enrollment System";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //Discount discount = new Discount();
                //discount.Id = Convert.ToInt32(dgvDiscount.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria
                //discount.Delete();

                //discount.LoadDataTable(dgvDiscount);
                MessageBox.Show("Printed");

                #region Call the Dashboard
                frmDashboard dashboard = new frmDashboard();
                frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];

                mainwin.pnlAllContainer.Controls.Clear();
                mainwin.pnlAllContainer.Visible = true;

                dashboard.TopLevel = false;
                dashboard.AutoScroll = true;
                mainwin.pnlAllContainer.Controls.Add(dashboard);
                dashboard.Show();
                #endregion 

                //Generate StudNo
                //Break down of Fees
                //Books 
                //Uniforms
            }
            else
            {
                return;
            }
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {

        }
    }
}
