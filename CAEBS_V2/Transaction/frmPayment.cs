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
        PaymentLog pay = new PaymentLog();
        List<PaymentLog> payLogs = new List<PaymentLog>();

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
                    txtAmountGiven.Focus();
                    return;
                }
            } 
                
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
