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
    public partial class frmTheStudentList : Form
    {
        Register register = new Register();
        frmNewStudent frm = new frmNewStudent();

        frmAssess frm_assess = new frmAssess();
        frmPayment frm_payment = new frmPayment();

        List<Register> ListRegister = new List<Register>();
        Util_RequiredFields util = new Util_RequiredFields();

        public int id;

        public void CountStudent()
        {
           lblTotalStudent.Text =  dgvList.Rows.Count.ToString();
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
            dgvList.Columns["mop"].Visible = false;
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
            # endregion
        }

        public void PassToAssess()
        {
            //clear list
            ListRegister.Clear();
            //pass value

            register.Id = Convert.ToInt32(dgvList.CurrentRow.Cells[3].FormattedValue.ToString());
            frm_assess.id = Convert.ToInt32(dgvList.CurrentRow.Cells[3].FormattedValue.ToString());
            // MessageBox.Show(dgvList.CurrentRow.Cells[3].FormattedValue.ToString());

            ListRegister = register.GetById();

            foreach (var item in ListRegister)
            {
                frm_assess.RegNo = item.Reg_no;
                frm_assess.LRN = item.Lrn;
                frm_assess.StudNo = item.Stud_no;
                frm_assess.FName = item.First_name;
                frm_assess.LName = item.Last_name;
                frm_assess.MName = item.Middle_name;
                frm_assess.GLevel = item.Grade_level;
                frm_assess.Section = item.Section;
                frm_assess.Strand = item.Strand;
                frm_assess.Voucher = item.Voucher_type;
            }

            frm_assess.ToAssess();

            frm_assess.UnifOrders();
            util.AddImageDataGridDelete(frm_assess.dgvUniform2);

            frm_assess.FilterStrand(frm_assess.Strand);
            frm_assess.FilterBook(frm_assess.Strand,frm_assess.GLevel);
            frm_assess.FilterVoucher(frm_assess.Voucher);

            frm_assess.LoadOtherFee();
            frm_assess.LoadTuition();
            frm_assess.PassToCompute();
            
           

            #region Call Form       
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
            mainwin.pnlAllContainer.Controls.Clear();

            frm_assess.TopLevel = false;
            frm_assess.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(frm_assess);
           // frm_assess.formToMaxSize();
            frm_assess.Show();
            #endregion
        }

        public void PassToEdit()
        {
            //clear list
            ListRegister.Clear();
            //pass value

            register.Id = Convert.ToInt32(dgvList.CurrentRow.Cells[3].FormattedValue.ToString());
            frm.id = Convert.ToInt32(dgvList.CurrentRow.Cells[3].FormattedValue.ToString());
            // MessageBox.Show(dgvList.CurrentRow.Cells[3].FormattedValue.ToString());

            ListRegister = register.GetById();

            foreach (var item in ListRegister)
            {

                //pass variable to form Assesment
                frm.toUpdate = true;
                frm.toSave = false;
                
                frm.lrn = item.Lrn;
                frm.studNo = item.Stud_no;                                
                frm.last_name = item.Last_name;
                frm.first_name = item.First_name;
                frm.middle_name = item.Middle_name;
                frm.grade_level = item.Grade_level;
                frm.department = item.Department;             
                frm.section = item.Section;               
                frm.semester = item.Semester;
              
                frm.date_of_birth = item.Date_of_birth;
                frm.place_of_birth = item.Place_of_birth;
                frm.religion = item.Religion;
                frm.nationality = item.Nationality;
                frm.sex = item.Sex;
                frm.address = item.Address;
                frm.mother_name = item.Mother_name;
                frm.mother_contact = item.Mother_contact;
                frm.mother_work = item.Mother_work;
                frm.father_name = item.Father_name;
                frm.father_contact = item.Father_contact;
                frm.father_work = item.Father_work;
                frm.cperson_name = item.Cperson_name;
                frm.cperson_contact = item.Cperson_contact;
                frm.cperson_relationship = item.Cperson_relationship;
                frm.cp_address = item.Cperson_address;
                frm.previous_school = item.Previous_school;
                frm.previous_school_address = item.Previous_school_address;
                frm.track = item.Track;
                frm.voucher = item.Voucher_type;
                frm.strand = item.Strand;

                if (item.Psa.Equals("1"))
                {
                    frm.chkPSA.Checked = true;
                }

                if (item.PsaCopy.Equals("1"))
                {
                    frm.chkPSACopy.Checked = true;
                }

                if (item.Report_card.Equals("1"))
                {
                    frm.chkCard.Checked = true;
                }

                if (item.Form_137.Equals("1"))
                {
                    frm.chk137.Checked = true;
                }             

                if (item.Good_moral.Equals("1"))
                {
                    frm.chkGoodMoral.Checked = true;
                }

                if (item.Med_certificate.Equals("1"))
                {
                    frm.chkMedCert.Checked = true;
                }

                if (item.Ncae.Equals("1"))
                {
                    frm.chckNCAE.Checked = true;
                }

                if (item.Esc_voucher.Equals("1"))
                {
                    frm.chkESC.Checked = true;
                }

                if (item.Entrance_exam.Equals("1"))
                {
                    frm.chkExam.Checked = true;
                }

                if (item.Student_Type.Equals("New Student"))
                {
                    frm.optNewStudent.Checked = true;
                }

                if (item.Student_Type.Equals("Transferee"))
                {
                    frm.optTransferee.Checked = true;
                }

                if (item.Student_Type.Equals("Old Student"))
                {
                    frm.optOldStudent.Checked = true;
                }
            }

            frm.ToEdit();         

            #region Call Form       
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
            mainwin.pnlAllContainer.Controls.Clear();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(frm);
            frm.formToMaxSize();
            frm.Show();
            #endregion

        }

        public frmTheStudentList()
        {
            InitializeComponent();
            register.LoadDataTable(dgvList);
            CountStudent();
            HeaderName();
            register.AutoComplete(txtSearchMe);
            util.AssessOrBilling(dgvList);
        }
     
        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            string message = "Do you want to modify the Student information?";
            string title = "Enrollment System";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                PassToEdit();
            }
            else
            {
                return;
            }
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                id = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[3].Value.ToString());//for editing criteria

                ////pass value to edit mode               
                //txtDiscountName.Text = dgvDiscount.Rows[e.RowIndex].Cells[3].Value.ToString(); //Name     
                //txtValue.Text = dgvDiscount.Rows[e.RowIndex].Cells[4].Value.ToString(); //Name    

                //btnAdd.Text = "&Update";//set button to Update    

                string message = "Do you want to proceed to Assessment?";
                string title = "Enrollment System";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    PassToAssess();
                }
                else
                {
                    return;
                }
            }

            else if (e.ColumnIndex == 1)
            {
                string message = "Do you want to proceed to Billing?";
                string title = "Enrollment System";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                         
                //clear list
                ListRegister.Clear();
                //pass value

                register.Id = Convert.ToInt32(dgvList.CurrentRow.Cells[3].FormattedValue.ToString());
                frm_payment.id = Convert.ToInt32(dgvList.CurrentRow.Cells[3].FormattedValue.ToString());
                // MessageBox.Show(dgvList.CurrentRow.Cells[3].FormattedValue.ToString());

                ListRegister = register.GetById();

                foreach (var item in ListRegister)
                {
                    frm_payment.RegNo = item.Reg_no;
                    frm_payment.LRN = item.Lrn;
                    frm_payment.StudNo = item.Stud_no;
                    frm_payment.FName = item.First_name;
                    frm_payment.LName = item.Last_name;
                    frm_payment.MName = item.Middle_name;
                    frm_payment.GLevel = item.Grade_level;
                    frm_payment.Section = item.Section;
                    frm_payment.Strand = item.Strand;
                    frm_payment.Voucher = item.Voucher_type;
                }

                    frm_payment.ToPay();
                    frm_payment.FilterStrand(frm_payment.Strand);
                    //frm_payment.FilterBook(frm_assess.Strand, frm_assess.GLevel);
                    frm_payment.FilterVoucher(frm_payment.Voucher);

                    frm_payment.LoadOtherFee();
                    frm_payment.LoadTuition();
                    frm_payment.PassToCompute();
                    frm_payment.LoadMiscFee();
                    #region Call Form       
                    frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
                    mainwin.pnlAllContainer.Controls.Clear();

                    frm_payment.TopLevel = false;
                    frm_payment.AutoScroll = true;
                    mainwin.pnlAllContainer.Controls.Add(frm_payment);
                    // frm_assess.formToMaxSize();
                    frm_payment.Show();
                    #endregion
                }
                else
                {
                    return;
                }
            }

            else if (e.ColumnIndex == 2)
            {
                string message = "Do you want to promote the Student?";
                string title = "Enrollment System";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //Discount discount = new Discount();
                    //discount.Id = Convert.ToInt32(dgvDiscount.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria
                    //discount.Delete();

                    //discount.LoadDataTable(dgvDiscount);
                    MessageBox.Show("Enrollment");
                }
                else
                {
                    return;
                }
            }
        }

        private void txtSearchMe_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = txtSearchMe.Text.ToString();
            register.SearchData(valueToSearch, dgvList);
        }

    }
}



