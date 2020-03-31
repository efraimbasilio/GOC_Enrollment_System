using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;


namespace CAEBS_V2
{
    public partial class frmAssessment : Form
    {
        Register register = new Register();
        List<Register> ListRegister = new List<Register>();
        frmNewStudent frmNewStudent = new frmNewStudent();
        Util_RequiredFields util = new Util_RequiredFields();

        public int id;
        public string lrn, last_name, first_name, middle_name, grade_level, section, term, semester, date_of_birth, place_of_birth, religion, nationality, sex, address, mother_name, mother_contact, mother_work, father_name, father_contact, father_work, cperson_name, cperson_contact, cperson_relationship, previous_school, previous_school_address, psa, pic_child, pic_guardian, med_certificate, report_card, form_137, good_moral;
        

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void HeaderName()
        {
            #region Header Name
            dgvAssessment.Columns["id"].HeaderText = "#";
            dgvAssessment.Columns["stud_no"].HeaderText = "Student No.";
            dgvAssessment.Columns["lrn"].HeaderText = "LRN";
            dgvAssessment.Columns["first_name"].HeaderText = "First Name";
            dgvAssessment.Columns["middle_name"].HeaderText = "Middle Name";
            dgvAssessment.Columns["last_name"].HeaderText = "Last Name";
            dgvAssessment.Columns["grade_level"].HeaderText = "Grade Level";
            dgvAssessment.Columns["section"].HeaderText = "Section";

            #region To Hide           
            dgvAssessment.Columns["term"].Visible = false;
            dgvAssessment.Columns["semester"].Visible = false;
            dgvAssessment.Columns["date_of_birth"].Visible = false;
            dgvAssessment.Columns["place_of_birth"].Visible = false;
            dgvAssessment.Columns["religion"].Visible = false;
            dgvAssessment.Columns["nationality"].Visible = false;
            dgvAssessment.Columns["sex"].Visible = false;
            dgvAssessment.Columns["address"].Visible = false;
            dgvAssessment.Columns["mother_name"].Visible = false;

            dgvAssessment.Columns["mother_contact"].Visible = false;
            dgvAssessment.Columns["mother_work"].Visible = false;
            dgvAssessment.Columns["father_name"].Visible = false;
            dgvAssessment.Columns["father_contact"].Visible = false;
            dgvAssessment.Columns["father_work"].Visible = false;
            dgvAssessment.Columns["cperson_name"].Visible = false;
            dgvAssessment.Columns["cperson_contact"].Visible = false;
            dgvAssessment.Columns["cperson_relationship"].Visible = false;
            dgvAssessment.Columns["previous_school"].Visible = false;
            dgvAssessment.Columns["previous_school_address"].Visible = false;

            dgvAssessment.Columns["psa"].Visible = false;
            dgvAssessment.Columns["pic_child"].Visible = false;
            dgvAssessment.Columns["pic_guardian"].Visible = false;
            dgvAssessment.Columns["med_certificate"].Visible = false;
            dgvAssessment.Columns["report_card"].Visible = false;
            dgvAssessment.Columns["form_137"].Visible = false;
            dgvAssessment.Columns["good_moral"].Visible = false;
            dgvAssessment.Columns["mode_of_payment"].Visible = false;
            dgvAssessment.Columns["enrollee_status"].Visible = false;
            #endregion

            DataGridViewColumn toFill = dgvAssessment.Columns[4];
            toFill.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvAssessment.Columns[0].Width = 50;
            dgvAssessment.Columns[1].Width = 120;
            dgvAssessment.Columns[2].Width = 120;
            dgvAssessment.Columns[3].Width = 175;
            # endregion
        }

        public void PassToEdit()
        {
            //clear list
            ListRegister.Clear();
            //pass value
          
            register.Id = Convert.ToInt32(dgvAssessment.CurrentRow.Cells[3].FormattedValue.ToString());
            MessageBox.Show(dgvAssessment.CurrentRow.Cells[3].FormattedValue.ToString());
            ListRegister = register.GetById();

            foreach (var item in ListRegister)
            {
               
                //pass variable to form Assesment
                frmNewStudent.lrn = item.Lrn;
                frmNewStudent.last_name = item.Last_name;
                frmNewStudent.first_name = item.First_name;
                frmNewStudent.middle_name = item.Middle_name;
                frmNewStudent.grade_level = item.Grade_level;
                frmNewStudent.section = item.Section;
                frmNewStudent.term = item.Term;
                frmNewStudent.semester = item.Semester;
                frmNewStudent.date_of_birth = item.Date_of_birth;
                frmNewStudent.place_of_birth = item.Place_of_birth;
                frmNewStudent.religion = item.Religion;
                frmNewStudent.nationality = item.Nationality;
                frmNewStudent.sex = item.Sex;
                frmNewStudent.address = item.Address;
                frmNewStudent.mother_name = item.Mother_name;
                frmNewStudent.mother_contact = item.Mother_contact;
                frmNewStudent.mother_work = item.Mother_work;
                frmNewStudent.father_name = item.Father_name;
                frmNewStudent.father_contact = item.Father_contact;
                frmNewStudent.father_work = item.Father_work;
                frmNewStudent.cperson_name = item.Cperson_name;
                frmNewStudent.cperson_contact = item.Cperson_contact;
                frmNewStudent.cperson_relationship = item.Cperson_relationship;
                frmNewStudent.cp_address = item.Cperson_address;
                frmNewStudent.previous_school = item.Previous_school;
                frmNewStudent.previous_school_address = item.Previous_school_address;
                frmNewStudent.psa = item.Psa;
                frmNewStudent.pic_child = item.Pic_child;
                frmNewStudent.pic_guardian = item.Pic_guardian;
                frmNewStudent.med_certificate = item.Med_certificate;
                frmNewStudent.report_card = item.Report_card;
                frmNewStudent.form_137 = item.Form_137;
                frmNewStudent.good_moral = item.Good_moral;

            }

            frmNewStudent.ToEdit();
            //frmMain mainwin = new frmMain();
            //mainwin.dispanel.Controls.Clear();
            //frmNewStudent.TopLevel = false;
            //frmNewStudent.AutoScroll = true;
            //mainwin.dispanel.Controls.Add(frmNewStudent);
            //frmNewStudent.Show();

            #region Call Form
                frmNewStudent frm = new frmNewStudent();
                frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
                mainwin.pnlAllContainer.Controls.Clear();
                frm.TopLevel = false;
                frm.AutoScroll = true;
                mainwin.pnlAllContainer.Controls.Add(frm);
                frm.Show();
            #endregion

        }
       
        public frmAssessment()
        {
            InitializeComponent();
            register.LoadDataTable(dgvAssessment);
            HeaderName();
            register.AutoComplete(txtSearchMe);
            util.AssessOrBilling(dgvAssessment);            
        }             

        private void txtSearchMe_TextChanged(object sender, EventArgs e)
        {
            string valueToSearch = txtSearchMe.Text.ToString();
            register.SearchData(valueToSearch,dgvAssessment);
        }

        private void dgvAssessment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                id = Convert.ToInt32(dgvAssessment.Rows[e.RowIndex].Cells[3].Value.ToString());//for editing criteria

                ////pass value to edit mode               
                //txtDiscountName.Text = dgvDiscount.Rows[e.RowIndex].Cells[3].Value.ToString(); //Name     
                //txtValue.Text = dgvDiscount.Rows[e.RowIndex].Cells[4].Value.ToString(); //Name    

                //btnAdd.Text = "&Update";//set button to Update    

                MessageBox.Show("Assess"+ id);            
            }

            else if (e.ColumnIndex == 1)
            {
                string message = "Do you want to proceed to Billing?";
                string title = "Enrollment System";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    //Discount discount = new Discount();
                    //discount.Id = Convert.ToInt32(dgvDiscount.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria
                    //discount.Delete();

                    //discount.LoadDataTable(dgvDiscount);
                    MessageBox.Show("Billing");
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
                    MessageBox.Show("Enrollement");
                }
                else
                {
                    return;
                }
            }
        }

       

        private void dgvAssessment_DoubleClick(object sender, EventArgs e)
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
    }
}


