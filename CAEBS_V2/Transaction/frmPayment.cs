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
        public string RegNo, LRN, StudNo, FName, LName, MName, GLevel, Section, Strand, Voucher;      
        public int id;

        PaymentLog pay = new PaymentLog();
        List<PaymentLog> payLogs = new List<PaymentLog>();


        Util_RequiredFields util = new Util_RequiredFields();
        TransUniform trans = new TransUniform();

        Register register = new Register();
        List<Register> ListRegister = new List<Register>();

        MiscFee misc = new MiscFee();
        List<MiscFee> listMiscFee = new List<MiscFee>();

        OtherFee otherFee = new OtherFee();
        List<OtherFee> listOtherFee = new List<OtherFee>();

        Strand strand = new Strand();
        List<Strand> strands = new List<Strand>();

        Tuition tuition = new Tuition();
        List<Tuition> listTuition = new List<Tuition>();

        Uniform uniform = new Uniform();
        List<Uniform> listUniform = new List<Uniform>();

        Voucher voucher = new Voucher();
        List<Voucher> vouchers = new List<Voucher>();

        Book book = new Book();
        List<Book> books = new List<Book>();

        TransBookUnif transBUnif = new TransBookUnif();
        List<TransBookUnif> transBUnifs = new List<TransBookUnif>();    

        private double TotalMiscFee;
        private double TotalOtherFee;
        private string LabFeeStatus;
        private double TotalTuition;
        private double TotalFee;
        private double TotalUniformFee;
        private double Total_1;
        private double Total_sum;
        private double total_all;
        private string VoucherAmount;
        private double DP;
        private double BOOK_FEE;
        private string BookTitle;
        private string Price;
        private double TotalBooks;
        private double totSum;
        private double TutionPAY;
        private string sizeOrder;
        private bool toSave;
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
           
            lblRegNo.Text = RegNo;
            lblLRN.Text = LRN;
            lblStudNo.Text = StudNo;
            lblFullName.Text = LName + ". " + FName + " " + MName;
            lblGLevel.Text = GLevel;
            lblSection.Text = Section;
            lblStrand.Text = Strand;
            lblVoucher.Text = Voucher;       

            trans.TransUnif(dgvUnif, RegNo);

            #region Header Name
            dgvUnif.Columns["id"].Visible = false;
            dgvUnif.Columns["item_name"].HeaderText = "Description";
            dgvUnif.Columns["price"].HeaderText = "Price";
            dgvUnif.Columns["unif_qty"].HeaderText = "Qty";
            dgvUnif.Columns["unif_size"].HeaderText = "Size";

            DataGridViewColumn toFill = dgvUnif.Columns[1];
            toFill.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //dgvUnif.Columns[0].Width = 100;
            dgvUnif.Columns[2].Width = 100;
            dgvUnif.Columns[3].Width = 100;
            dgvUnif.Columns[4].Width = 100;
            // dgvUnif.Columns[4].Width = 175;
            #endregion

        }

        public void LoadOtherFee()
        {
            listOtherFee.Clear();
            dgvOtherFee.Rows.Clear();
            listOtherFee = otherFee.Load();

            foreach (var item in listOtherFee)
            {
                if (item.Lab_fee.Equals("0") && LabFeeStatus.Equals("0"))
                {
                    dgvOtherFee.Rows.Add(item.Amount);
                }
                else if (LabFeeStatus.Equals("1"))
                {
                    dgvOtherFee.Rows.Add(item.Amount);
                }
            }

            for (int i = 0; i < dgvOtherFee.Rows.Count; i++)
            {
                TotalOtherFee += (Convert.ToDouble(dgvOtherFee.Rows[i].Cells[0].Value));
            }
            lblOtherFee.Text = TotalOtherFee.ToString("n");
        }
        public void LoadMiscFee()
        {
            misc.LoadDataTable(dgvMiscFee);
            for (int i = 0; i < dgvMiscFee.Rows.Count; i++)
            {
                TotalMiscFee += (Convert.ToDouble(dgvMiscFee.Rows[i].Cells[2].Value));
            }
            lblTotalMisc.Text = TotalMiscFee.ToString("n");
        }
        public void LoadTuition()
        {
            listTuition.Clear();
            dgvTuition.Rows.Clear();
            listTuition = tuition.Load();

            foreach (var item in listTuition)
            {
                if (item.Dept.Equals("SHS"))
                {
                    dgvTuition.Rows.Add(item.Amount);
                }
            }
            for (int i = 0; i < dgvTuition.Rows.Count; i++)
            {
                TotalTuition += (Convert.ToDouble(dgvTuition.Rows[i].Cells[0].Value));
            }
            lblTuition.Text = TotalTuition.ToString("n");
        }

        public void FilterVoucher(string Voucher)
        {
            vouchers.Clear();
            vouchers = voucher.Load();
            foreach (var item in vouchers)
            {
                if (item.Voucher_from.Equals(Voucher))
                {
                    VoucherAmount = item.Voucher_amount;
                }
            }
        }

        public void PassToCompute()
        {
            if (cmbMOP.Text.Equals("Partial Payment"))
            {
                //txtDP.Enabled = true;
                TotalFee = TotalMiscFee + TotalOtherFee + TotalTuition;
                dgvBillAssess.Rows.Clear();
                dgvBillAssess.Rows.Add("TUTION FEES", "");
                dgvBillAssess.Rows.Add("SHS Tuititon Fee", TotalFee);
                dgvBillAssess.Rows.Add("Less: " + lblVoucher.Text, Convert.ToDouble(VoucherAmount));
                dgvBillAssess.Rows.Add("          Downpayment", Convert.ToDouble(txtDP.Text));

                TutionPAY = TotalFee - (Convert.ToDouble(VoucherAmount) + Convert.ToDouble(txtDP.Text));
                dgvBillAssess.Rows.Add("Balance", TutionPAY);
                dgvBillAssess.Rows.Add("Per Month", TutionPAY / 10);

                dgvBillAssess.Rows.Add("", "");
                dgvBillAssess.Rows.Add("OTHER FEES", "");
                dgvBillAssess.Rows.Add("Uniform Fee", total_all);
                dgvBillAssess.Rows.Add("Book Fee", TotalBooks);
                dgvBillAssess.Rows.Add("Total Fee", total_all + TotalBooks);
                dgvBillAssess.Rows.Add("", "");
                dgvBillAssess.Rows.Add("", "");
                dgvBillAssess.Rows[0].DefaultCellStyle.BackColor = Color.Navy;
                dgvBillAssess.Rows[0].DefaultCellStyle.ForeColor = Color.White;

                dgvBillAssess.Rows[7].DefaultCellStyle.BackColor = Color.Navy;
                dgvBillAssess.Rows[7].DefaultCellStyle.ForeColor = Color.White;

                dgvBillAssess.DefaultCellStyle.SelectionBackColor = Color.Navy;
                util.DisableSort_DataGrid(dgvBillAssess);
                //util.DisableSort_DataGrid(dgvBooks);
                //util.DisableSort_DataGrid(dgvUniform);

                totSum = (total_all + TotalBooks + Convert.ToDouble(txtDP.Text));
                //lblTotalPayment.Text = totSum.ToString("n");
                dgvBillAssess.Rows.Add("Total Fees", totSum);
                dgvBillAssess.Rows[12].DefaultCellStyle.BackColor = Color.Navy;
                dgvBillAssess.Rows[12].DefaultCellStyle.ForeColor = Color.White;

            }
            else if (cmbMOP.Text.Equals("Fullpayment"))
            {
                //txtDP.Text = "0.00";
                //txtDP.Enabled = false;
                TotalFee = TotalMiscFee + TotalOtherFee + TotalTuition;
                dgvBillAssess.Rows.Clear();
                dgvBillAssess.Rows.Add("TUTION FEES", "");
                dgvBillAssess.Rows.Add("SHS Tuititon Fee", TotalFee);
                dgvBillAssess.Rows.Add("Less: " + lblVoucher.Text, Convert.ToDouble(VoucherAmount));
                dgvBillAssess.Rows.Add("          Downpayment", Convert.ToDouble(txtDP.Text));
                dgvBillAssess.Rows.Add("", "");

                TutionPAY = TotalFee - (Convert.ToDouble(VoucherAmount) + Convert.ToDouble(txtDP.Text));
                dgvBillAssess.Rows.Add("Balance", TutionPAY);

                dgvBillAssess.Rows.Add("", "");
                dgvBillAssess.Rows.Add("OTHER FEES", "");
                dgvBillAssess.Rows.Add("Uniform Fee", total_all);
                dgvBillAssess.Rows.Add("Book Fee", TotalBooks);
                dgvBillAssess.Rows.Add("Total Fee", total_all + TotalBooks);
                dgvBillAssess.Rows.Add("", "");
                dgvBillAssess.Rows.Add("", "");
                dgvBillAssess.Rows[0].DefaultCellStyle.BackColor = Color.Navy;
                dgvBillAssess.Rows[0].DefaultCellStyle.ForeColor = Color.White;

                dgvBillAssess.Rows[6].DefaultCellStyle.BackColor = Color.Navy;
                dgvBillAssess.Rows[6].DefaultCellStyle.ForeColor = Color.White;

                dgvBillAssess.DefaultCellStyle.SelectionBackColor = Color.Navy;
                util.DisableSort_DataGrid(dgvBillAssess);
                //util.DisableSort_DataGrid(dgvBooks);
                //util.DisableSort_DataGrid(dgvUniform);

                totSum = (total_all + TotalBooks + Convert.ToDouble(TutionPAY));
                //lblTotalPayment.Text = totSum.ToString("n");
                dgvBillAssess.Rows.Add("Total Fees", totSum);
                dgvBillAssess.Rows[12].DefaultCellStyle.BackColor = Color.Navy;
                dgvBillAssess.Rows[12].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        public void FilterStrand(string Strand)
        {
            strands.Clear();
            strands = strand.Load();
            foreach (var item in strands)
            {
                if (item.Strand_name.Equals(Strand))
                {
                    LabFeeStatus = item.Lab_fee;
                }
            }
        }
        //#####################################################################################################################################################//

        public frmPayment()
        {
            InitializeComponent();
            

        }

        //#####################################################################################################################################################//
        private void cmbMOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            total_all = 0;

            //for (int i = 0; i < dgvUniform2.Rows.Count; i++)
            //{
            //    if (Convert.ToInt32(dgvUniform2.Rows[i].Cells[4].Value) > 0)
            //    {
            //        Total_1 = Convert.ToDouble(dgvUniform2.Rows[i].Cells[3].Value) * Convert.ToDouble(dgvUniform2.Rows[i].Cells[4].Value);
            //        total_all += Total_1;
            //    }
            //}
            //lblTotalUniformFee.Text = total_all.ToString("n");

            PassToCompute();
        }

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
