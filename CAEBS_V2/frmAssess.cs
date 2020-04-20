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
        public string LRN, StudNo, FName, LName, MName, GLevel, Section, Strand;
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

        private double TotalMiscFee;
        private double TotalOtherFee;
        private string LabFeeStatus;
        private double TotalTuition;

        #region FEES
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

        #endregion

        public void ToAssess()
        {
            lblLRN.Text = LRN;
            lblStudNo.Text = StudNo;
            lblFullName.Text = LName + ". " + FName + " " + MName;
            lblGLevel.Text = GLevel;
            lblSection.Text = Section;
            lblStrand.Text = Strand;
        }

        public frmAssess()
        {
            InitializeComponent();

            LoadMiscFee();
        }


        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
