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


        #region FEES
        public void LoadUniform()
        {
            listUniform.Clear();
            dgvUniform.Rows.Clear();
            listUniform = uniform.Load();

            foreach (var item in listUniform)
            {
                dgvUniform.Rows.Add(item.Item_name, item.Price, "0");                
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
                if (Convert.ToInt32(dgvUniform.Rows[i].Cells[2].Value) > 0 )
                {                    
                    Total_1 = Convert.ToDouble(dgvUniform.Rows[i].Cells[1].Value) * Convert.ToDouble(dgvUniform.Rows[i].Cells[2].Value);            
                    total_all += Total_1;                    
                }                              
            }   
            lblTotalUniformFee.Text = total_all.ToString("n");
        }

        private void txtDP_TextChanged(object sender, EventArgs e)
        {
            PassToCompute();
            util.ValidateTextBoxDP(txtDP);
        }

        private void txtDP_Click(object sender, EventArgs e)
        {
            txtDP.SelectAll();
        }

        private void txtDP_Leave(object sender, EventArgs e)
        {
            //if (txtDP.Text.Equals("") || Convert.ToDouble(txtDP.Text) < 1000)
            //{
            //    txtDP.Text = "0.00";
            //}
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
            TotalFee = TotalMiscFee + TotalOtherFee + TotalTuition;
            dgvAssessment.Rows.Clear();
            dgvAssessment.Rows.Add("TUTION FEES", "");
            dgvAssessment.Rows.Add("SHS Tuititon Fee", TotalFee);
            dgvAssessment.Rows.Add("Less: "+ lblVoucher.Text, Convert.ToDouble(VoucherAmount));
            dgvAssessment.Rows.Add("Downpayment", Convert.ToDouble(txtDP.Text));
            dgvAssessment.Rows.Add("Remaining Balance", TotalFee - (Convert.ToDouble(VoucherAmount) + Convert.ToDouble(txtDP.Text)));
            dgvAssessment.Rows.Add("", "");
            dgvAssessment.Rows.Add("OTHER FEES", "");
            dgvAssessment.Rows.Add("Uniform Fee", total_all);
            dgvAssessment.Rows.Add("Book Fee", TotalBooks);
            dgvAssessment.Rows.Add("Total Fee", total_all + TotalBooks);
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
