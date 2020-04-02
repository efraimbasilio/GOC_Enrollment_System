using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAEBS_V2
{
    public partial class frmNewStudent : Form
    {
        Register r = new Register();
        List<Register> ListRegister = new List<Register>();
        ZCtr ctr = new ZCtr();
        List<ZCtr> ctrs = new List<ZCtr>();
        Util_RequiredFields util = new Util_RequiredFields();
        frmDashboard dash_info = new frmDashboard();

        public string student_type, department, cp_address ,lrn, last_name, first_name, middle_name, grade_level, section, term, semester, date_of_birth, place_of_birth, religion, nationality, sex, address, mother_name, mother_contact, mother_work, father_name, father_contact, father_work, cperson_name, cperson_contact, cperson_relationship, previous_school, previous_school_address, psa, pic_child, pic_guardian, med_certificate, report_card, form_137, good_moral;
        public string voucher, track, strand,psa_copy,ncae,exam,studNo;
        public bool toSave, toUpdate;
        public int id;
        public int i = 0, x = 0;

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            this.Dispose();
            frm.ShowDialog();
        }
       
        public frmNewStudent()
        {
            InitializeComponent();           
            #region Data input Validations
            this.txtFirstName.KeyPress += new KeyPressEventHandler(KeypressedLettersOnly);
            this.txtLastName.KeyPress += new KeyPressEventHandler(KeypressedLettersOnly);
            this.txtMiddleName.KeyPress += new KeyPressEventHandler(KeypressedLettersOnly);
            this.txtNationality.KeyPress += new KeyPressEventHandler(KeypressedLettersOnly);
            this.txtReligion.KeyPress += new KeyPressEventHandler(KeypressedLettersOnly);
            this.txtMother.KeyPress += new KeyPressEventHandler(KeypressedLettersOnly);
            this.txtFather.KeyPress += new KeyPressEventHandler(KeypressedLettersOnly);
            this.txtCPName.KeyPress += new KeyPressEventHandler(KeypressedLettersOnly);
            this.txtCPRelation.KeyPress += new KeyPressEventHandler(KeypressedLettersOnly);

            this.txtLRN.KeyPress += new KeyPressEventHandler(KeypressedNumberOnly);
            this.txtFContact.KeyPress += new KeyPressEventHandler(KeypressedNumberOnly);
            this.txtMContact.KeyPress += new KeyPressEventHandler(KeypressedNumberOnly);
            this.txtCPContact.KeyPress += new KeyPressEventHandler(KeypressedNumberOnly);
            #endregion                        
        }    
          
        #region KEYPRESS VALIDATION

        /// <summary>
        /// Allow Only Numbers in Keypress
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void KeypressedLettersOnly(Object o, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        /// <summary>
        /// Allow Only Letters
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void KeypressedNumberOnly(Object o, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        #endregion

        #region Functions

        public void formToMaxSize()
        {
            this.Top = 0;
            this.Left = 0;


            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 10);
        }

        public void Generate_StudNo()
        {
            if (r.save_halt == false)
            {
                ctrs.Clear();
                ctrs = ctr.Load();
                foreach (var item in ctrs)
                {
                    i = Convert.ToInt32(item.Ctr_number) + 1;
                    x = item.Id;
                }
                ctr.Id = x;
                ctr.Ctr_number = i.ToString();
                ctr.Update();

                string str = DateTime.Today.ToString("yyyy");
                string a = str.Substring(2);
                string output = a + "-" + (i).ToString("0000");
                txtStudNo.Text = output;

                r.Lrn = txtLRN.Text;
                r.Stud_no = output;
                r.Update_For_StudentNo();
            }
            else
            {
                return;
            }
            
        }

        public void PassToEdit()
        {
            //clear list
            ListRegister.Clear();
            //pass value

            r.Id = id;
            //MessageBox.Show(dgvAssessment.CurrentRow.Cells[3].FormattedValue.ToString());
            ListRegister = r.GetById();

            foreach (var item in ListRegister)
            {

                //pass variable to form Assesment
                this.lrn = item.Lrn;
                //frmNewStudent.last_name = item.Last_name;
                //frmNewStudent.first_name = item.First_name;
                //frmNewStudent.middle_name = item.Middle_name;
                //frmNewStudent.grade_level = item.Grade_level;
                //frmNewStudent.section = item.Section;
                //frmNewStudent.term = item.Term;
                //frmNewStudent.semester = item.Semester;
                //frmNewStudent.date_of_birth = item.Date_of_birth;
                //frmNewStudent.place_of_birth = item.Place_of_birth;
                //frmNewStudent.religion = item.Religion;
                //frmNewStudent.nationality = item.Nationality;
                //frmNewStudent.sex = item.Sex;
                //frmNewStudent.address = item.Address;
                //frmNewStudent.mother_name = item.Mother_name;
                //frmNewStudent.mother_contact = item.Mother_contact;
                //frmNewStudent.mother_work = item.Mother_work;
                //frmNewStudent.father_name = item.Father_name;
                //frmNewStudent.father_contact = item.Father_contact;
                //frmNewStudent.father_work = item.Father_work;
                //frmNewStudent.cperson_name = item.Cperson_name;
                //frmNewStudent.cperson_contact = item.Cperson_contact;
                //frmNewStudent.cperson_relationship = item.Cperson_relationship;
                //frmNewStudent.cp_address = item.Cperson_address;
                //frmNewStudent.previous_school = item.Previous_school;
                //frmNewStudent.previous_school_address = item.Previous_school_address;
                //frmNewStudent.psa = item.Psa;
                //frmNewStudent.pic_child = item.Pic_child;
                //frmNewStudent.pic_guardian = item.Pic_guardian;
                //frmNewStudent.med_certificate = item.Med_certificate;
                //frmNewStudent.report_card = item.Report_card;
                //frmNewStudent.form_137 = item.Form_137;
                //frmNewStudent.good_moral = item.Good_moral;

            }
        }

        public void FillEmpty()
        {
            if (util.readyToSave ==1)
            {
               // MessageBox.Show(util.readyToSave.ToString());
                foreach (Control child in panel3.Controls)
                {
                    if (child is TextBox)
                    {
                        TextBox tb = child as TextBox;
                        if (string.IsNullOrEmpty(tb.Text))
                        {
                            tb.Text = @"N A";
                        }
                    }
                }
            }
            else
            {
                return;
            }
           
        }

        public  void Requirements()
        {
            if (chkExam.Checked == true)
            {
                r.Entrance_exam = "1";

            }

            if (chkPSACopy.Checked == true)
            {
                r.PsaCopy = "1";

            }

            if (chkPSA.Checked == true)
            {
                r.Psa = "1";
               
            }

            if (chkCard.Checked == true)
            {
                r.Report_card = "1";
               
            }

            if (chk137.Checked == true)
            {
                r.Form_137 = "1";
                
            }

            if (chkMedCert.Checked == true)
            {
                r.Med_certificate = "1";
               
            }

                      
            if (chkGoodMoral.Checked == true)
            {
                r.Good_moral = "1";
               
            }

            if (chckNCAE.Checked == true)
            {
                r.Ncae = "1";

            }


            if (chkESC.Checked == true)
            {
                r.Esc_voucher = "1";

            }
        }

        public void NoRequirements()
        {
            if (chkExam.Checked == false)
            {
                r.Entrance_exam = "0";

            }

            if (chkPSACopy.Checked == false)
            {
                r.PsaCopy = "0";

            }

            if (chkPSA.Checked == false)
            {
                r.Psa = "0";

            }

            if (chkCard.Checked == false)
            {
                r.Report_card = "0";

            }

            if (chk137.Checked == false)
            {
                r.Form_137 = "0";

            }

            if (chkMedCert.Checked == false)
            {
                r.Med_certificate = "0";

            }


            if (chkGoodMoral.Checked == false)
            {
                r.Good_moral = "0";

            }

            if (chckNCAE.Checked == false)
            {
                r.Ncae = "0";

            }


            if (chkESC.Checked == false)
            {
                r.Esc_voucher = "0";

            }
        }

        public void ToEdit()
        {
            txtStudNo.Text = studNo;
            txtLRN.Text = lrn;
            txtLastName.Text = last_name;
            txtFirstName.Text = first_name;
            txtMiddleName.Text = middle_name;
            cmbGradeLevel.Text = grade_level;
            
            dtpBirthdate.Text = date_of_birth;
            txtBirthPlace.Text = place_of_birth;
            txtReligion.Text = religion;
            txtNationality.Text = nationality;
            cmbSex.Text = sex;
            txtAddress.Text = address;
            txtMother.Text = mother_name;
            txtMContact.Text = mother_contact;
            txtMOccupation.Text = mother_work;
            txtFather.Text = father_name;
            txtFContact.Text = father_contact;
            txtFOccupation.Text = father_work;
            txtCPName.Text = cperson_name;
            txtCPContact.Text = cperson_contact;
            txtCPAddress.Text = cp_address;
            txtCPRelation.Text = cperson_relationship;
            txtPrevSchool.Text = previous_school;
            txtPrevSchAddress.Text = previous_school_address;
            cmbDept.Text = department;
            cmbGradeLevel.Text = grade_level;

            cmbTrack.Text = track;
            cmbVoucher.Text = voucher;
            cmbStrand.Text = strand;
            

            //if (psa.Equals("1"))
            //{
            //    chkPSA.Checked = true;
            //}

            //if (psa_copy.Equals("1"))
            //{
            //    chkPSACopy.Checked = true;
            //}

            //if (report_card.Equals("1"))
            //{
            //    chkCard.Checked = true;
            //}

            //if (form_137.Equals("1"))
            //{
            //    chk137.Checked = true;
            //}

            //if (good_moral.Equals("1"))
            //{
            //    chkGoodMoral.Checked = true;
            //}

            //if (med_certificate.Equals("1"))
            //{
            //    chkMedCert.Checked = true;
            //}

            //if (ncae.Equals("1"))
            //{
            //    chckNCAE.Checked = true;
            //}

            //if (voucher.Equals("1"))
            //{
            //    chkESC.Checked = true;
            //}

            //if (exam.Equals("1"))
            //{
            //    chkExam.Checked = true;
            //}
        }

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        } //Close Form
                
        private void btnNewStudent_Click(object sender, EventArgs e)
        {                            
            if (toSave == true)
            {
                #region Requirements To Pass                      
                Requirements();
                NoRequirements();
                #endregion

                #region Set Student Type
                if (optNewStudent.Checked == true)
                {
                    r.Student_Type = "New Student";
                }
                else if (optTransferee.Checked == true)
                {
                    r.Student_Type = "Transferee";
                }
                else if (optOldStudent.Checked == true)
                {
                    r.Student_Type = "Old Student";
                }
                else
                {
                    MessageBox.Show("ERROR : Please select student Type.", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion                

                util.ValidateTextBox8(txtLRN, txtLastName, txtFirstName, txtMiddleName, txtBirthPlace, txtReligion, txtNationality, txtAddress);
                util.ValidateCombobox5(cmbDept,cmbGradeLevel,cmbStrand,cmbVoucher,cmbTrack);
                FillEmpty();

                #region Set Data To Save
                //set Value to Save                       
                r.Stud_no = txtStudNo.Text;
                r.Lrn = txtLRN.Text;

                r.Last_name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtLastName.Text);
                r.First_name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtFirstName.Text);
                r.Middle_name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtMiddleName.Text);
                r.Grade_level = cmbGradeLevel.Text;
                r.Department = cmbDept.Text;
                r.Section = "NA";

                //r.Term = dash_info.lblQuarter.Text;
                r.Semester = dash_info.lblSemester.Text;
                r.Date_of_birth = dtpBirthdate.Text;
                r.Place_of_birth = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtBirthPlace.Text);
                r.Religion = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtReligion.Text);
                r.Nationality = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNationality.Text);
                r.Sex = cmbSex.Text;
                r.Address = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtAddress.Text);

                r.Mother_name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtMother.Text);
                r.Mother_contact = txtMContact.Text;
                r.Mother_work = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtMOccupation.Text);
                r.Father_name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtFather.Text);
                r.Father_contact = txtFContact.Text;
                r.Father_work = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtFOccupation.Text);
                r.Cperson_name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCPName.Text);
                r.Cperson_contact = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCPContact.Text);
                r.Cperson_relationship = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCPRelation.Text);
                r.Cperson_address = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCPAddress.Text);
                r.Previous_school = txtPrevSchool.Text;
                r.Previous_school_address = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPrevSchAddress.Text);
                r.Enrollee_status = "NA";

                r.Voucher_type = cmbVoucher.Text;
                r.Track = cmbTrack.Text;
                r.Strand = cmbStrand.Text;

                #endregion

                if (util.readyToSave == 1)
                {                         
                    r.Save();
                    Generate_StudNo();

                    frmReports rpt = new frmReports();
                    rpt.LRN = txtLRN.Text;
                    rpt.PrintRegForm();
                    rpt.ShowDialog();

                    //#region Call Dashboard Form       
                    //frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
                    //    frmDashboard frm = new frmDashboard();

                    //    mainwin.pnlAllContainer.Controls.Clear();
                    //    frm.TopLevel = false;
                    //    frm.AutoScroll = true;
                    //    mainwin.pnlAllContainer.Controls.Add(frm);

                    //    frm.Show();
                    //#endregion

                }
            }

            else if (toUpdate == true && toSave == false)
            {
                #region Requirements To Pass                      
                Requirements();
                NoRequirements();
                #endregion

                #region Set Student Type
                if (optNewStudent.Checked == true)
                {
                    r.Student_Type = "New Student";
                }
                else if (optTransferee.Checked == true)
                {
                    r.Student_Type = "Transferee";
                }
                else if (optOldStudent.Checked == true)
                {
                    r.Student_Type = "Old Student";
                }
                else
                {
                    MessageBox.Show("ERROR : Please select student Type.", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion                

                util.ValidateTextBox8(txtLRN, txtLastName, txtFirstName, txtMiddleName, txtBirthPlace, txtReligion, txtNationality, txtAddress);
                util.ValidateCombobox5(cmbDept, cmbGradeLevel, cmbStrand, cmbVoucher, cmbTrack);
                FillEmpty();

                #region Set Data To Save
                //set Value to Save                       
                r.Stud_no = txtStudNo.Text;
                r.Lrn = txtLRN.Text;

                r.Last_name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtLastName.Text);
                r.First_name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtFirstName.Text);
                r.Middle_name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtMiddleName.Text);
                r.Grade_level = cmbGradeLevel.Text;
                r.Department = cmbDept.Text;
                r.Section = "NA";

                //r.Term = dash_info.lblQuarter.Text;
                r.Semester = dash_info.lblSemester.Text;
                r.Date_of_birth = dtpBirthdate.Text;
                r.Place_of_birth = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtBirthPlace.Text);
                r.Religion = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtReligion.Text);
                r.Nationality = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNationality.Text);
                r.Sex = cmbSex.Text;
                r.Address = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtAddress.Text);

                r.Mother_name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtMother.Text);
                r.Mother_contact = txtMContact.Text;
                r.Mother_work = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtMOccupation.Text);
                r.Father_name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtFather.Text);
                r.Father_contact = txtFContact.Text;
                r.Father_work = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtFOccupation.Text);
                r.Cperson_name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCPName.Text);
                r.Cperson_contact = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCPContact.Text);
                r.Cperson_relationship = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCPRelation.Text);
                r.Cperson_address = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCPAddress.Text);
                r.Previous_school = txtPrevSchool.Text;
                r.Previous_school_address = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtPrevSchAddress.Text);
                r.Enrollee_status = "NA";

                r.Voucher_type = cmbVoucher.Text;
                r.Track = cmbTrack.Text;
                r.Strand = cmbStrand.Text;

                #endregion

                if (util.readyToSave == 1)
                {
                    r.Id = id;
                    r.Update();

                    frmReports rpt = new frmReports();
                    rpt.LRN = txtLRN.Text;
                    rpt.PrintRegForm();
                    rpt.ShowDialog();

                    //#region Call Dashboard Form       
                    //frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
                    //frmDashboard frm = new frmDashboard();

                    //mainwin.pnlAllContainer.Controls.Clear();
                    //frm.TopLevel = false;
                    //frm.AutoScroll = true;
                    //mainwin.pnlAllContainer.Controls.Add(frm);

                    //frm.Show();
                    //#endregion
                }
            }

            else
            {
                MessageBox.Show("REMINDER: Please check the required fields", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        } //SAVE and UPDATE Working
    }
}
