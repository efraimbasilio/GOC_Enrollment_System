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
    public partial class frmOldStudent : Form
    {
        Register register = new Register();
        frmNewStudent frm = new frmNewStudent();
        List<Register> ListRegister = new List<Register>();
        Util_RequiredFields util = new Util_RequiredFields();

        public int id;

        public void CountStudent()
        {
            lblTotalStudent.Text = dgvList.Rows.Count.ToString();
        }

        public void HeaderName()
        {
            #region Header Name
            dgvList.Columns["id"].HeaderText = "#";
            dgvList.Columns["stud_no"].HeaderText = "Student No.";
            dgvList.Columns["lrn"].HeaderText = "LRN";
            dgvList.Columns["first_name"].HeaderText = "First Name";
            dgvList.Columns["middle_name"].HeaderText = "Middle Name";
            dgvList.Columns["last_name"].HeaderText = "Last Name";
            dgvList.Columns["grade_level"].HeaderText = "Grade Level";
            dgvList.Columns["section"].HeaderText = "Section";
            dgvList.Columns["enrollee_status"].HeaderText = "Status";


            #region To Hide           
            dgvList.Columns["student_type"].Visible = false;
            // dgvList.Columns["term"].Visible = false;
            dgvList.Columns["semester"].Visible = false;
            dgvList.Columns["date_of_birth"].Visible = false;
            dgvList.Columns["place_of_birth"].Visible = false;
            dgvList.Columns["religion"].Visible = false;
            dgvList.Columns["nationality"].Visible = false;
            dgvList.Columns["sex"].Visible = false;
            dgvList.Columns["address"].Visible = false;
            dgvList.Columns["mother_name"].Visible = false;

            dgvList.Columns["mother_contact"].Visible = false;
            dgvList.Columns["mother_work"].Visible = false;
            dgvList.Columns["father_name"].Visible = false;
            dgvList.Columns["father_contact"].Visible = false;
            dgvList.Columns["father_work"].Visible = false;
            dgvList.Columns["cperson_name"].Visible = false;
            dgvList.Columns["cperson_contact"].Visible = false;
            dgvList.Columns["cperson_relationship"].Visible = false;
            dgvList.Columns["cperson_address"].Visible = false;
            dgvList.Columns["previous_school"].Visible = false;
            dgvList.Columns["previous_school_address"].Visible = false;

            dgvList.Columns["psa"].Visible = false;
            dgvList.Columns["psa_copy"].Visible = false;
            dgvList.Columns["voucher_type"].Visible = false;
            dgvList.Columns["strand"].Visible = false;
            dgvList.Columns["med_certificate"].Visible = false;
            dgvList.Columns["report_card"].Visible = false;
            dgvList.Columns["form_137"].Visible = false;
            dgvList.Columns["good_moral"].Visible = false;
            dgvList.Columns["track"].Visible = false;
            dgvList.Columns["date_of_enrollment"].Visible = false;
            dgvList.Columns["department"].Visible = false;
            dgvList.Columns["esc_voucher"].Visible = false;
            dgvList.Columns["ncae"].Visible = false;
            dgvList.Columns["entrance_exam"].Visible = false;
            #endregion

            DataGridViewColumn toFill = dgvList.Columns[4];
            toFill.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvList.Columns[0].Width = 50;
            dgvList.Columns[1].Width = 120;
            dgvList.Columns[2].Width = 120;
            dgvList.Columns[3].Width = 175;
            // dgvList.Columns[4].Width = 175;
            #endregion
        }

        public frmOldStudent()
        {
            InitializeComponent();
            register.LoadDataTable(dgvList);

        }
    }
}
