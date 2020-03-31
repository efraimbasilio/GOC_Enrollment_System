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
    public partial class frmNewStudent : Form
    {
        Register r = new Register();
        List<Register> ListRegister = new List<Register>();
        Util_RequiredFields util = new Util_RequiredFields();

        frmDashboard dash_info = new frmDashboard();

        public string student_type, department, cp_address ,lrn, last_name, first_name, middle_name, grade_level, section, term, semester, date_of_birth, place_of_birth, religion, nationality, sex, address, mother_name, mother_contact, mother_work, father_name, father_contact, father_work, cperson_name, cperson_contact, cperson_relationship, previous_school, previous_school_address, psa, pic_child, pic_guardian, med_certificate, report_card, form_137, good_moral;          
        public bool toSave,toUpdate;       
        public int id;
        
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

            #region Generate STUDNO
                r.Count_DATA();
                r.count_data = r.count_data + 1;
                txtStudNo.Text = "CAEBS-" + DateTime.Today.ToString("yyyy") + "-" + (r.count_data).ToString("0000");
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
            foreach (Control child in panel3.Controls)
            {
                if (child is TextBox)
                {
                    TextBox tb = child as TextBox;
                    if (string.IsNullOrEmpty(tb.Text))
                    {
                        tb.Text = @"NA";
                    }
                }
            }
        }

        public  void Requirements()
        {

            if (chkPSACopy.Checked == true)
            {
                r.PsaCopy = "1";

            }

            if (chkPSA.Checked == true)
            {
                r.Psa = "1";
               
            }

            if (chkPicChild.Checked == true)
            {
                r.Pic_child = "1";
               
            }

            if (chkpicParent.Checked == true)
            {
                r.Pic_guardian = "1";
                
            }

            if (chkMedCert.Checked == true)
            {
                r.Med_certificate = "1";
               
            }

            if (chkCardTransferee.Checked == true)
            {
                r.Report_card = "1";
                
            }

            if (chk137.Checked == true)
            {
                r.Form_137 = "1";
                
            }

            if (chkGoodMoral.Checked == true)
            {
                r.Good_moral = "1";
               
            }          
        }

        public void NoRequirements()
        {
            if (chkPSACopy.Checked == false)
            {
                r.PsaCopy = "0";

            }

            if (chkPSA.Checked == false)
            {
                r.Psa = "0";

            }

            if (chkPicChild.Checked == false)
            {
                r.Pic_child = "0";

            }

            if (chkpicParent.Checked == false)
            {
                r.Pic_guardian = "0";

            }

            if (chkMedCert.Checked == false)
            {
                r.Med_certificate = "0";

            }

            if (chkCardTransferee.Checked == false)
            {
                r.Report_card = "0";

            }

            if (chk137.Checked == false)
            {
                r.Form_137 = "0";

            }

            if (chkGoodMoral.Checked == false)
            {
                r.Good_moral = "0";

            }
        }

        public void ToEdit()
        {
            
            txtLRN.Text = lrn;
            txtLastName.Text = last_name;
            txtFirstName.Text = first_name;
            txtMiddleName.Text = middle_name;
            cmbGradeLevel.Text = grade_level;
            //section
            //cmbTerm
            //semester
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


            //if (psa.Equals("1"))
            //{
            //    chkPSA.Checked = true;
            //}

            //if (pic_child.Equals("1"))
            //{
            //    chkPicChild.Checked = true;
            //}

            //if (pic_guardian.Equals("1"))
            //{
            //    chkpicParent.Checked = true;
            //}

            //if (med_certificate.Equals("1"))
            //{
            //    chkMedCert.Checked = true;
            //}

            //if (report_card.Equals("1"))
            //{
            //    chk137.Checked = true;
            //}

            //if (good_moral.Equals("1"))
            //{
            //    chkGoodMoral.Checked = true;
            //}


        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        } //Close Form
                
        private void btnNewStudent_Click(object sender, EventArgs e)
        {
            #region Required Requirements
            if (cmbDept.Text == "Pre Elementary")
            {
                util.Validate_Pre_Elementary(chkPSA);
               
            }
            else if (cmbDept.Text == "Elementary")
            {
                util.Validate_Elementary(chkCardTransferee);
                
            }
            else
            {
                MessageBox.Show("Please check the requirements", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                return;
            }
            #endregion
            FillEmpty();
            if (util.toSave == true && toSave == true)
            {               
                //Pass Values
                #region data_to_save
                //set Value to Save                       
                r.Stud_no = txtStudNo.Text;
                r.Lrn = txtLRN.Text;
                
                r.Last_name = txtLastName.Text;
                r.First_name = txtFirstName.Text;
                r.Middle_name = txtMiddleName.Text;
                r.Grade_level = cmbGradeLevel.Text;
                r.Department = cmbDept.Text;
                r.Section = "NA";

                r.Term = dash_info.lblQuarter.Text;
                r.Semester = dash_info.lblSemester.Text;

                //r.Semester = cmb
                r.Date_of_birth = dtpBirthdate.Text;
                r.Place_of_birth = txtBirthPlace.Text;
                r.Religion = txtReligion.Text;
                r.Nationality = txtNationality.Text;
                r.Sex = cmbSex.Text;
                r.Address = txtAddress.Text;

                r.Mother_name = txtMother.Text;
                r.Mother_contact = txtMother.Text;
                r.Mother_work = txtMOccupation.Text;
                r.Father_name = txtFather.Text;
                r.Father_contact = txtFContact.Text;
                r.Father_work = txtFOccupation.Text;
                r.Cperson_name = txtCPName.Text;
                r.Cperson_contact = txtCPContact.Text;
                r.Cperson_relationship = txtCPRelation.Text;
                r.Cperson_address = txtCPAddress.Text;
                r.Previous_school = txtPrevSchool.Text;
                r.Previous_school_address = txtPrevSchAddress.Text;
                r.Enrollee_status = "NA";
                #endregion
             
                Requirements();//Required to pass
                NoRequirements();
                //Mode of payment 
                #region MOP                            
                if (optFullPay.Checked == true)
                {
                    r.Mode_of_payment = "Fullpayment";
                }
                else if (optPartial.Checked == true)
                {
                    r.Mode_of_payment = "Partial";
                }
                else
                {
                    MessageBox.Show("ERROR : Please select the Mode of Payment.", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion

                #region Student Type
                if (optNewStudent.Checked == true)
                {
                    r.Student_Type = "New Student";
                }
                else if (optTransferee.Checked == true)
                {
                    r.Mode_of_payment = "Transferee";
                }
                else
                {
                    MessageBox.Show("ERROR : Please select student Type.", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #endregion

                
                util.ValidateTextBox8(txtLRN, txtLastName, txtFirstName, txtMiddleName, txtBirthPlace, txtReligion, txtNationality, txtAddress);
                if (util.readyToSave == 1)
                {                  
                    r.Save();

                    #region For Billing
                    if (r.save_halt != true)
                    {
                        DialogResult result = MessageBox.Show("Proceed to billing?", "Enrollment System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            frmPayment pay = new frmPayment();
                            pay.ShowDialog();
                        }
                        else
                        {
                            return;
                        }
                    }
                    #endregion

                }
            }
            else if(toUpdate == true && toSave == false)
            {
                //Pass Values
                #region data_to_save
                //set Value to Save                       
                r.Stud_no = txtStudNo.Text;
                r.Lrn = txtLRN.Text;

                r.Last_name = txtLastName.Text;
                r.First_name = txtFirstName.Text;
                r.Middle_name = txtMiddleName.Text;
                r.Grade_level = cmbGradeLevel.Text;
                r.Department = cmbDept.Text;
                r.Section = "NA";

                r.Term = dash_info.lblQuarter.Text;
                r.Semester = dash_info.lblSemester.Text;

                //r.Semester = cmb
                r.Date_of_birth = dtpBirthdate.Text;
                r.Place_of_birth = txtBirthPlace.Text;
                r.Religion = txtReligion.Text;
                r.Nationality = txtNationality.Text;
                r.Sex = cmbSex.Text;
                r.Address = txtAddress.Text;

                r.Mother_name = txtMother.Text;
                r.Mother_contact = txtMother.Text;
                r.Mother_work = txtMOccupation.Text;
                r.Father_name = txtFather.Text;
                r.Father_contact = txtFContact.Text;
                r.Father_work = txtFOccupation.Text;
                r.Cperson_name = txtCPName.Text;
                r.Cperson_contact = txtCPContact.Text;
                r.Cperson_relationship = txtCPRelation.Text;
                r.Cperson_address = txtCPAddress.Text;
                r.Previous_school = txtPrevSchool.Text;
                r.Previous_school_address = txtPrevSchAddress.Text;
                r.Enrollee_status = "NA";
                #endregion

                Requirements();//Required to pass
                NoRequirements();
                //Mode of payment 
                #region MOP                            
                if (optFullPay.Checked == true)
                {
                    r.Mode_of_payment = "Fullpayment";
                }
                else if (optPartial.Checked == true)
                {
                    r.Mode_of_payment = "Partial";
                }
                else
                {
                    MessageBox.Show("ERROR : Please select the Mode of Payment.", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion

                #region Student Type
                if (optNewStudent.Checked == true)
                {
                    r.Student_Type = "New Student";
                }
                else if (optTransferee.Checked == true)
                {
                    r.Mode_of_payment = "Transferee";
                }
                else
                {
                    MessageBox.Show("ERROR : Please select student Type.", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #endregion


                util.ValidateTextBox8(txtLRN, txtLastName, txtFirstName, txtMiddleName, txtBirthPlace, txtReligion, txtNationality, txtAddress);
                if (util.readyToSave == 1)
                {
                    r.Id = id;
                    r.Update();
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
