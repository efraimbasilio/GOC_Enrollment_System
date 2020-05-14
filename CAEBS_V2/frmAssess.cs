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
    public partial class frmAssess : Form
    {
        public string LRN, StudNo, FName, LName, MName, GLevel, Section, Strand, Voucher;
        public int id;

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


        Util_RequiredFields util = new Util_RequiredFields();

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

        #region Validation DGV
        private void ValidateSizeOrder()
        {
            for (int i = 0; i < dgvUniform.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvUniform.Rows[i].Cells[3].Value) > 0 && dgvUniform.Rows[i].Cells[4].Value.Equals("--"))
                {
                    string message = "Please specify the size of the order.";
                    string title = "Enrollment System";

                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                    dgvUniform.CurrentCell = dgvUniform.Rows[i].Cells[4];
                    toSave = false;
                    break;

                }
                else
                {
                    toSave = true;
                }
            }
        }
        #endregion

        #region FEES
        public void LoadUniform()
        {
            listUniform.Clear();
            dgvUniform.Rows.Clear();
            listUniform = uniform.Load();

            foreach (var item in listUniform)
            {
                dgvUniform.Rows.Add(item.Unif_code,item.Item_name, item.Price, "0","--");                
            }            
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

        public void FilterBook(string Strand, string Level)
        {
            books.Clear();
            books = book.Load();
            foreach (var item in books)
            {
                if (item.Strand.Equals(Strand) && item.Grade_level.Equals(Level))
                {                   
                    dgvBooks.Rows.Add(item.Title, item.Price);
                }
            }

            for (int i = 0; i < dgvBooks.Rows.Count; i++)
            {
                TotalBooks += (Convert.ToDouble(dgvBooks.Rows[i].Cells[1].Value));
            }

            lblBooks.Text = TotalBooks.ToString("n");
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
                else if (LabFeeStatus.Equals("1") )
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

        private void btnCompute_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvUniform.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvUniform.Rows[i].Cells[3].Value) > 0 )
                {                    
                    Total_1 = Convert.ToDouble(dgvUniform.Rows[i].Cells[2].Value) * Convert.ToDouble(dgvUniform.Rows[i].Cells[3].Value);            
                    total_all += Total_1;                    
                }                              
            }   
            lblTotalUniformFee.Text = total_all.ToString("n");
        }

        private void txtDP_TextChanged(object sender, EventArgs e)
        {            
            //PassToCompute();          
        }

        private void txtDP_Click(object sender, EventArgs e)
        {
            txtDP.SelectAll();
        }

        private void txtDP_Leave(object sender, EventArgs e)
        {
           
        }

        private void dgvAssessment_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
          
               
        }

        private void chkOrderUniform_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOrderUniform.Checked == true)
            {
                string message = "Please input how many order and size?";
                string title = "Enrollment System";

                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                dgvUniform.Enabled = true;
                LoadUniform();               
            }
            else
            {
                string message = "Do you want to cancel the order?";
                string title = "Enrollment System";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //MessageBox.Show("Disabled");
                    total_all = 0;
                    LoadUniform();
                    btnCompute.PerformClick();
                    PassToCompute();
                    dgvUniform.Enabled = false;
                }
                else
                {
                    return;
                }
               

            }
        }

        private void chkOrderBook_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOrderBook.Checked == true)
            {
                dgvBooks.Enabled = false;
                dgvBooks.Rows.Clear();
                FilterBook(Strand, GLevel);
                PassToCompute();
            }
            else
            {               
                dgvBooks.Enabled = true;
                TotalBooks = 0;
                PassToCompute();
            }
        }

        private void txtDP_Enter(object sender, EventArgs e)
        {
            PassToCompute();
        }

        private void txtToBilling_Click(object sender, EventArgs e)
        {
            ValidateSizeOrder();

            if (toSave == true)
            {
               // util.ValidateTextBoxDP(txtDP);

                for (int i = 0; i < dgvBooks.Rows.Count; i++)
                {
                    //MessageBox.Show(dgvBooks.Rows[i].Cells[0].Value.ToString() + " " + dgvBooks.Rows[i].Cells[1].Value.ToString());
                    //transBUnif.Book_title = dgvBooks.Rows[i].Cells[0].Value.ToString();
                    //transBUnif.Book_order = dgvBooks.Rows[i].Cells[1].Value.ToString();
                }

                for (int i = 0; i < dgvUniform.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgvUniform.Rows[i].Cells[3].Value) > 0)
                    {
                        transBUnif.LRN = lblLRN.Text;
                        transBUnif.OR_no = "0000";                      
                        transBUnif.Unif_code = dgvUniform.Rows[i].Cells[0].Value.ToString();
                        transBUnif.Unif_qty = dgvUniform.Rows[i].Cells[3].Value.ToString();
                        transBUnif.Unif_size = dgvUniform.Rows[i].Cells[4].Value.ToString();

                        transBUnif.Save();
                    }
                }
                string message = "Record Save";
                string title = "Enrollment System";

                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }
           
        }

        private void dgvUniform_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            total_all = 0;
            btnCompute.PerformClick();
            PassToCompute();           
        }

        private void dgvUniform_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            total_all = 0;
            btnCompute.PerformClick();
            PassToCompute();                                
        }

        private void cmbMOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            total_all = 0;
            btnCompute.PerformClick();
            PassToCompute();
        }

        private void txtDP_MouseLeave(object sender, EventArgs e)
        {
            PassToCompute();
        }

        private void dgvUniform_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            total_all = 0;
            btnCompute.PerformClick();
            PassToCompute();
        }

        private void dgvUnif_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
        
        public void PassToCompute()
        {
            if (cmbMOP.Text.Equals("Partial Payment"))
            {              
                txtDP.Enabled = true;
                TotalFee = TotalMiscFee + TotalOtherFee + TotalTuition;
                dgvAssessment.Rows.Clear();
                dgvAssessment.Rows.Add("TUTION FEES", "");
                dgvAssessment.Rows.Add("SHS Tuititon Fee", TotalFee);
                dgvAssessment.Rows.Add("Less: " + lblVoucher.Text, Convert.ToDouble(VoucherAmount));
                dgvAssessment.Rows.Add("          Downpayment", Convert.ToDouble(txtDP.Text));

                TutionPAY = TotalFee - (Convert.ToDouble(VoucherAmount) + Convert.ToDouble(txtDP.Text));
                dgvAssessment.Rows.Add("Balance", TutionPAY);
                dgvAssessment.Rows.Add("Per Month", TutionPAY / 10);

                dgvAssessment.Rows.Add("", "");
                dgvAssessment.Rows.Add("OTHER FEES", "");
                dgvAssessment.Rows.Add("Uniform Fee", total_all);
                dgvAssessment.Rows.Add("Book Fee", TotalBooks);
                dgvAssessment.Rows.Add("Total Fee", total_all + TotalBooks);
                dgvAssessment.Rows.Add("", "");
                dgvAssessment.Rows.Add("", "");
                dgvAssessment.Rows[0].DefaultCellStyle.BackColor = Color.Navy;
                dgvAssessment.Rows[0].DefaultCellStyle.ForeColor = Color.White;

                dgvAssessment.Rows[7].DefaultCellStyle.BackColor = Color.Navy;
                dgvAssessment.Rows[7].DefaultCellStyle.ForeColor = Color.White;

                dgvAssessment.DefaultCellStyle.SelectionBackColor = Color.Navy;
                util.DisableSort_DataGrid(dgvAssessment);
                util.DisableSort_DataGrid(dgvBooks);
                util.DisableSort_DataGrid(dgvUniform);

                totSum = (total_all + TotalBooks + Convert.ToDouble(txtDP.Text));
                lblTotalPayment.Text = totSum.ToString("n");
                dgvAssessment.Rows.Add("Total Fees", totSum);
                dgvAssessment.Rows[12].DefaultCellStyle.BackColor = Color.Navy;
                dgvAssessment.Rows[12].DefaultCellStyle.ForeColor = Color.White;

            }
            else if (cmbMOP.Text.Equals("Fullpayment"))
            {
                txtDP.Text = "0.00";
                txtDP.Enabled = false;
                TotalFee = TotalMiscFee + TotalOtherFee + TotalTuition;
                dgvAssessment.Rows.Clear();
                dgvAssessment.Rows.Add("TUTION FEES", "");
                dgvAssessment.Rows.Add("SHS Tuititon Fee", TotalFee);
                dgvAssessment.Rows.Add("Less: " + lblVoucher.Text, Convert.ToDouble(VoucherAmount));
                //dgvAssessment.Rows.Add("          Downpayment", Convert.ToDouble(txtDP.Text));
                dgvAssessment.Rows.Add("", "");

                TutionPAY = TotalFee - (Convert.ToDouble(VoucherAmount) + Convert.ToDouble(txtDP.Text));
                dgvAssessment.Rows.Add("Balance", TutionPAY);                

                dgvAssessment.Rows.Add("", "");
                dgvAssessment.Rows.Add("OTHER FEES", "");
                dgvAssessment.Rows.Add("Uniform Fee", total_all);
                dgvAssessment.Rows.Add("Book Fee", TotalBooks);
                dgvAssessment.Rows.Add("Total Fee", total_all + TotalBooks);
                dgvAssessment.Rows.Add("", "");
                dgvAssessment.Rows.Add("", "");
                dgvAssessment.Rows[0].DefaultCellStyle.BackColor = Color.Navy;
                dgvAssessment.Rows[0].DefaultCellStyle.ForeColor = Color.White;

                dgvAssessment.Rows[6].DefaultCellStyle.BackColor = Color.Navy;
                dgvAssessment.Rows[6].DefaultCellStyle.ForeColor = Color.White;

                dgvAssessment.DefaultCellStyle.SelectionBackColor = Color.Navy;
                util.DisableSort_DataGrid(dgvAssessment);
                util.DisableSort_DataGrid(dgvBooks);
                util.DisableSort_DataGrid(dgvUniform);

                totSum = (total_all + TotalBooks + Convert.ToDouble(TutionPAY));
                lblTotalPayment.Text = totSum.ToString("n");
                dgvAssessment.Rows.Add("Total Fees", totSum);
                dgvAssessment.Rows[12].DefaultCellStyle.BackColor = Color.Navy;
                dgvAssessment.Rows[12].DefaultCellStyle.ForeColor = Color.White;
            }
        }
        #endregion

        public void ToAssess()
        {
            lblLRN.Text = LRN;
            lblStudNo.Text = StudNo;
            lblFullName.Text = LName + ". " + FName + " " + MName;
            lblGLevel.Text = GLevel;
            lblSection.Text = Section;
            lblStrand.Text = Strand;
            lblVoucher.Text = Voucher;
        }
     
        public frmAssess()
        {
            InitializeComponent();
            LoadMiscFee();
            LoadUniform();           
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
