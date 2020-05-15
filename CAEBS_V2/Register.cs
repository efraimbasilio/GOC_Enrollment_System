using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace CAEBS_V2
{
    class Register
    {
        #region Variables and Properties
        public bool save_halt;
        public int count_data;

        protected int id;
        protected string reg_no;
        protected string stud_no;
        protected string lrn;
        protected string last_name;
        protected string first_name;
        protected string middle_name;
        protected string grade_level;
        protected string department;
        protected string section;
        //protected string term;
        protected string semester;
        protected string date_of_birth;
        protected string place_of_birth;
        protected string religion;
        protected string nationality;
        protected string sex;
        protected string address;
        protected string mother_name;
        protected string mother_contact;
        protected string mother_work;
        protected string father_name;
        protected string father_contact;
        protected string father_work;
        protected string cperson_name;
        protected string cperson_contact;
        protected string cperson_address;
        protected string cperson_relationship;
        protected string previous_school;
        protected string previous_school_address;

        protected string psa;
        protected string psa_copy;

        protected string esc_voucher;
        protected string entrance_exam;
        protected string ncae;
        protected string track;
        protected string strand;
        protected string voucher_type;

       

        protected string med_certificate;
        protected string report_card;
        protected string form_137;
        protected string good_moral;

        protected string mop;
        protected string enrollee_status;
        protected string student_type;



        


        public int Id { get { return id; } set { id = value; } }
        public string Reg_no { get { return reg_no; } set { reg_no = value; } }
        public string Stud_no { get { return stud_no; } set { stud_no = value; } }
        public string Lrn { get { return lrn; } set { lrn = value; } }
        public string Last_name { get { return last_name; } set { last_name = value; } }
        public string First_name { get { return first_name; } set { first_name = value; } }
        public string Middle_name { get { return middle_name; } set { middle_name = value; } }
        public string Grade_level { get { return grade_level; } set { grade_level = value; } }
        public string Department { get { return department; } set { department = value; } }
        public string Section { get { return section; } set { section = value; } }
        //public string Term { get { return term; } set { term = value; } }
        public string Semester { get { return semester; } set { semester = value; } }
        public string Date_of_birth { get { return date_of_birth; } set { date_of_birth = value; } }
        public string Place_of_birth { get { return place_of_birth; } set { place_of_birth = value; } }
        public string Religion { get { return religion; } set { religion = value; } }
        public string Nationality { get { return nationality; } set { nationality = value; } }
        public string Sex { get { return sex; } set { sex = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Mother_name { get { return mother_name; } set { mother_name = value; } }
        public string Mother_contact { get { return mother_contact; } set { mother_contact = value; } }
        public string Mother_work { get { return mother_work; } set { mother_work = value; } }
        public string Father_name { get { return father_name; } set { father_name = value; } }
        public string Father_contact { get { return father_contact; } set { father_contact = value; } }
        public string Father_work { get { return father_work; } set { father_work = value; } }
        public string Cperson_name { get { return cperson_name; } set { cperson_name = value; } }
        public string Cperson_contact { get { return cperson_contact; } set { cperson_contact = value; } }
        public string Cperson_address { get { return cperson_address; } set { cperson_address = value; } }
        public string Cperson_relationship { get { return cperson_relationship; } set { cperson_relationship = value; } }
        public string Previous_school { get { return previous_school; } set { previous_school = value; } }
        public string Previous_school_address { get { return previous_school_address; } set { previous_school_address = value; } }

        public string Psa { get { return psa; } set { psa = value; } }
        public string PsaCopy { get { return psa_copy; } set { psa_copy = value; } }
        public string Esc_voucher { get { return esc_voucher; } set { esc_voucher = value; } }
        public string Entrance_exam { get { return entrance_exam; } set { entrance_exam = value; } }
        public string Ncae { get { return ncae; } set { ncae = value; } }
        public string Track { get { return track; } set { track = value; } }
        public string Strand { get { return strand; } set { strand = value; } }
        public string Voucher_type { get { return voucher_type; } set { voucher_type = value; } }


        public string Med_certificate { get { return med_certificate; } set { med_certificate = value; } }
        public string Report_card { get { return report_card; } set { report_card = value; } }
        public string Form_137 { get { return form_137; } set { form_137 = value; } }
        public string Good_moral { get { return good_moral; } set { good_moral = value; } }
        public string MOP { get { return mop; } set { mop = value; } }
        public string Enrollee_status { get { return enrollee_status; } set { enrollee_status = value; } }
        public string Student_Type { get { return student_type; } set { student_type = value; } }

        #endregion

        List<Register> registerList = new List<Register>();

        public void LoadDataTable(DataGridView dgv)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();
                    string sql = "SELECT * FROM student_profile";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;

                    //initialize new datatable
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                    
                }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.Message.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Count_DATA()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();
                    string sql = "SELECT * FROM student_profile";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;

                    //initialize new datatable
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //dgv.DataSource = dt;
                    count_data = dt.Rows.Count;
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.Message.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //int totalRows = dt.rows.Count;

        public void AutoComplete(TextBox txt)
        {

            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    //string sql = "SELECT * FROM grading WHERE CONCAT(`full_name`,) LIKE '%" + valueToSearch + "%'";
                    string sql = "SELECT last_name FROM student_profile";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));
                    }
                    txt.AutoCompleteCustomSource = MyCollection;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.Message.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SearchData(string valueToSearch, DataGridView dgv)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();

                    string sql = "SELECT * FROM student_profile WHERE CONCAT(`last_name`, `first_name`,`lrn`) LIKE '%" + valueToSearch + "%'";
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    //initialize new datatable
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.Message.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Save()
        {
            try
            {
                //prepare connection string 
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {

                    //try to open connection
                    con.Open();
                    
                    //string sql = "INSERT INTO student_profile(lrn,last_name,first_name,middle_name,grade_level)" +
                    //             "VALUES(@lrn,@last_name,@first_name,@middle_name,@grade_level);";

                    string sql = "INSERT INTO student_profile(reg_no,mop,esc_voucher,entrance_exam,ncae,track,strand,voucher_type,stud_no,lrn,last_name,first_name,middle_name,grade_level,department,section,student_type,semester,date_of_birth,place_of_birth,religion,nationality,sex,address,mother_name,mother_contact,mother_work,father_name,father_contact,father_work,cperson_name,cperson_contact,cperson_address,cperson_relationship,previous_school,previous_school_address,psa,psa_copy,med_certificate,report_card,form_137,good_moral,enrollee_status)" +
                                 "VALUES(@reg_no,@mop,@esc_voucher,@entrance_exam,@ncae,@track,@strand,@voucher_type,@stud_no,@lrn,@last_name,@first_name,@middle_name,@grade_level,@department,@section,@student_type,@semester,@date_of_birth,@place_of_birth,@religion,@nationality,@sex,@address,@mother_name,@mother_contact,@mother_work,@father_name,@father_contact,@father_work,@cperson_name,@cperson_contact,@cperson_address,@cperson_relationship,@previous_school,@previous_school_address,@psa,@psa_copy,@med_certificate,@report_card,@form_137,@good_moral,@enrollee_status);";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("reg_no", reg_no);
                    cmd.Parameters.AddWithValue("stud_no", stud_no);
                    cmd.Parameters.AddWithValue("lrn", lrn);
                    cmd.Parameters.AddWithValue("last_name", last_name);
                    cmd.Parameters.AddWithValue("first_name", first_name);
                    cmd.Parameters.AddWithValue("middle_name", middle_name);
                    cmd.Parameters.AddWithValue("grade_level", grade_level);
                    cmd.Parameters.AddWithValue("department", department);
                    cmd.Parameters.AddWithValue("section", section);
                    //cmd.Parameters.AddWithValue("term", term);
                    cmd.Parameters.AddWithValue("semester", semester);
                    cmd.Parameters.AddWithValue("student_type", student_type);
                    cmd.Parameters.AddWithValue("date_of_birth", date_of_birth);
                    cmd.Parameters.AddWithValue("place_of_birth", place_of_birth);
                    cmd.Parameters.AddWithValue("religion", religion);
                    cmd.Parameters.AddWithValue("nationality", nationality);
                    cmd.Parameters.AddWithValue("sex", sex);
                    cmd.Parameters.AddWithValue("address", address);
                    cmd.Parameters.AddWithValue("mother_name", mother_name);
                    cmd.Parameters.AddWithValue("mother_contact", mother_contact);
                    cmd.Parameters.AddWithValue("mother_work", mother_work);
                    cmd.Parameters.AddWithValue("father_name", father_name);
                    cmd.Parameters.AddWithValue("father_contact", father_contact);
                    cmd.Parameters.AddWithValue("father_work", father_work);
                    cmd.Parameters.AddWithValue("cperson_name", cperson_name);
                    cmd.Parameters.AddWithValue("cperson_address", cperson_address);
                    cmd.Parameters.AddWithValue("cperson_contact", cperson_contact);
                    cmd.Parameters.AddWithValue("cperson_relationship", cperson_relationship);
                    cmd.Parameters.AddWithValue("previous_school", previous_school);
                    cmd.Parameters.AddWithValue("previous_school_address", previous_school_address);
                    cmd.Parameters.AddWithValue("psa", psa);
                    cmd.Parameters.AddWithValue("psa_copy", psa_copy);                    
                    cmd.Parameters.AddWithValue("esc_voucher", esc_voucher);
                    cmd.Parameters.AddWithValue("entrance_exam", entrance_exam);
                    cmd.Parameters.AddWithValue("ncae", ncae);
                    cmd.Parameters.AddWithValue("track", track);
                    cmd.Parameters.AddWithValue("strand", strand);
                    cmd.Parameters.AddWithValue("voucher_type", voucher_type);      
                    cmd.Parameters.AddWithValue("med_certificate", med_certificate);
                    cmd.Parameters.AddWithValue("report_card", report_card);
                    cmd.Parameters.AddWithValue("form_137", form_137);
                    cmd.Parameters.AddWithValue("good_moral", good_moral);                   
                    cmd.Parameters.AddWithValue("enrollee_status", enrollee_status);

                    cmd.Parameters.AddWithValue("mop", mop);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Saved!", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    save_halt = false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.Message, "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                save_halt = true;
            }
        }

        public void Update()
        {
            try
            {
                //prepare connection string 
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    //try to open connection
                    con.Open();

                    string sql = "UPDATE student_profile SET esc_voucher=@esc_voucher,entrance_exam=@entrance_exam,ncae=@ncae,track=@track,strand=@strand,voucher_type=@voucher_type, lrn=@lrn,last_name=@last_name,first_name=@first_name,middle_name=@middle_name,grade_level=@grade_level,department=@department,section=@section,student_type=@student_type,semester=@semester,date_of_birth=@date_of_birth,place_of_birth=@place_of_birth,religion=@religion, nationality = @nationality,sex = @sex,address = @address,mother_name = @mother_name,mother_contact = @mother_contact,mother_work = @mother_work,father_name = @father_name,father_contact = @father_contact,father_work = @father_work,cperson_name = @cperson_name,cperson_address=@cperson_address,cperson_contact = @cperson_contact,cperson_relationship = @cperson_relationship,previous_school = @previous_school, previous_school_address = @previous_school_address, psa = @psa,psa_copy = @psa_copy,med_certificate = @med_certificate,report_card = @report_card,form_137 = @form_137,good_moral = @good_moral,enrollee_status = @enrollee_status" +
                                   " WHERE id=@id;";
                    //psa = @psa,psa_copy = @psa_copy,esc_voucher = @esc_voucher,entrance_exam = @entrance_exam,ncae = @ncae,med_certificate = @med_certificate
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("lrn", lrn);
                    cmd.Parameters.AddWithValue("last_name", last_name);
                    cmd.Parameters.AddWithValue("first_name", first_name);
                    cmd.Parameters.AddWithValue("middle_name", middle_name);
                    cmd.Parameters.AddWithValue("grade_level", grade_level);
                    cmd.Parameters.AddWithValue("department", department);
                    cmd.Parameters.AddWithValue("section", section);
                    //cmd.Parameters.AddWithValue("term", term);
                    cmd.Parameters.AddWithValue("semester", semester);
                    cmd.Parameters.AddWithValue("student_type", student_type);
                    cmd.Parameters.AddWithValue("date_of_birth", date_of_birth);
                    cmd.Parameters.AddWithValue("place_of_birth", place_of_birth);
                    cmd.Parameters.AddWithValue("religion", religion);
                    cmd.Parameters.AddWithValue("nationality", nationality);
                    cmd.Parameters.AddWithValue("sex", sex);
                    cmd.Parameters.AddWithValue("address", address);
                    cmd.Parameters.AddWithValue("mother_name", mother_name);
                    cmd.Parameters.AddWithValue("mother_contact", mother_contact);
                    cmd.Parameters.AddWithValue("mother_work", mother_work);
                    cmd.Parameters.AddWithValue("father_name", father_name);
                    cmd.Parameters.AddWithValue("father_contact", father_contact);
                    cmd.Parameters.AddWithValue("father_work", father_work);
                    cmd.Parameters.AddWithValue("cperson_name", cperson_name);
                    cmd.Parameters.AddWithValue("cperson_contact", cperson_contact);
                    cmd.Parameters.AddWithValue("cperson_relationship", cperson_relationship);
                    cmd.Parameters.AddWithValue("cperson_address", cperson_address);
                    cmd.Parameters.AddWithValue("previous_school", previous_school);
                    cmd.Parameters.AddWithValue("previous_school_address", previous_school_address);


                    cmd.Parameters.AddWithValue("psa", psa);
                    cmd.Parameters.AddWithValue("psa_copy", psa_copy);
                    cmd.Parameters.AddWithValue("esc_voucher", esc_voucher);
                    cmd.Parameters.AddWithValue("entrance_exam", entrance_exam);
                    cmd.Parameters.AddWithValue("ncae", ncae);
                    cmd.Parameters.AddWithValue("track", track);
                    cmd.Parameters.AddWithValue("strand", strand);
                    cmd.Parameters.AddWithValue("voucher_type", voucher_type);
                    cmd.Parameters.AddWithValue("med_certificate", med_certificate);
                    cmd.Parameters.AddWithValue("report_card", report_card);
                    cmd.Parameters.AddWithValue("form_137", form_137);
                    cmd.Parameters.AddWithValue("good_moral", good_moral);
                    //cmd.Parameters.AddWithValue("mop", mop);
                    cmd.Parameters.AddWithValue("enrollee_status", enrollee_status);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Update!", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public List<Register> GetById()
        {
            try
            {
                //prepare connection string 
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {

                    //try to open connection
                    con.Open();

                    //prepare sql query
                    string sql = "SELECT * FROM student_profile WHERE id =@id;";


                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id", id);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //loop while have record
                    while (reader.Read())
                    {
                        //instantiate model
                        Register register = new Register();

                        //prepare properties
                        //register.id = Convert.ToInt32(reader["id"].ToString());    

                        register.stud_no = reader["stud_no"].ToString();
                        register.lrn = reader["lrn"].ToString();
                        register.last_name = reader["last_name"].ToString();
                        register.first_name = reader["first_name"].ToString();
                        register.middle_name = reader["middle_name"].ToString();
                        register.grade_level = reader["grade_level"].ToString();
                        register.department = reader["department"].ToString(); //FOR DEPARTMENT
                        register.section = reader["section"].ToString();
                        //register.term = reader["term"].ToString();
                        register.semester = reader["semester"].ToString();
                        register.student_type = reader["student_type"].ToString();

                        register.voucher_type = reader["voucher_type"].ToString();
                        register.strand = reader["strand"].ToString();
                        register.track = reader["track"].ToString();


                        register.date_of_birth = reader["date_of_birth"].ToString();
                        register.place_of_birth = reader["place_of_birth"].ToString();
                        register.religion = reader["religion"].ToString();
                        register.nationality = reader["nationality"].ToString();
                        register.sex = reader["sex"].ToString();
                        register.address = reader["address"].ToString();
                        register.mother_name = reader["mother_name"].ToString();
                        register.mother_contact = reader["mother_contact"].ToString();
                        register.mother_work = reader["mother_work"].ToString();
                        register.father_name = reader["father_name"].ToString();
                        register.father_contact = reader["father_contact"].ToString();
                        register.father_work = reader["father_work"].ToString();
                        register.cperson_name = reader["cperson_name"].ToString();
                        register.cperson_contact = reader["cperson_contact"].ToString();
                        register.Cperson_address = reader["cperson_address"].ToString();
                        register.cperson_relationship = reader["cperson_relationship"].ToString();
                        register.previous_school = reader["previous_school"].ToString();
                        register.previous_school_address = reader["previous_school_address"].ToString();

                        register.psa = reader["psa"].ToString();
                        register.psa_copy = reader["psa_copy"].ToString();

                        register.esc_voucher = reader["esc_voucher"].ToString();
                        register.entrance_exam = reader["entrance_exam"].ToString();
                        register.ncae = reader["ncae"].ToString();
                        register.track = reader["track"].ToString();
                        register.strand = reader["strand"].ToString();
                        register.voucher_type = reader["voucher_type"].ToString();

                        register.med_certificate = reader["med_certificate"].ToString();
                        register.report_card = reader["report_card"].ToString();
                        register.form_137 = reader["form_137"].ToString();
                        register.good_moral = reader["good_moral"].ToString();

                        register.mop = reader["mop"].ToString();
                        register.enrollee_status = reader["enrollee_status"].ToString();

                        registerList.Add(register);
                    }
                }
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show( "\nMessage-- -\n{ 0}", ex.Message);
                MessageBox.Show("ERROR : " + ex.Message, "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return registerList;
        }

        public void Update_For_StudentNo()
        {
            try
            {
                //prepare connection string 
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    //try to open connection
                    con.Open();

                    string sql = "UPDATE student_profile SET stud_no = @stud_no" +
                                   " WHERE lrn=@lrn;";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("lrn", lrn);
                    cmd.Parameters.AddWithValue("stud_no", stud_no);
                   
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("StudNo Update!", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Update_For_RegNo()
        {
            try
            {
                //prepare connection string 
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    //try to open connection
                    con.Open();

                    string sql = "UPDATE student_profile SET reg_no = @reg_no" +
                                   " WHERE lrn=@lrn;";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("lrn", lrn);
                    cmd.Parameters.AddWithValue("reg_no", reg_no);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student Registered Successfully!", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void UpdateMOP()
        {
            try
            {
                //prepare connection string 
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    //try to open connection
                    con.Open();

                    string sql = "UPDATE student_profile SET mop=@mop" +
                                   " WHERE lrn=@lrn;";
                  
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("lrn", lrn);                   
                    cmd.Parameters.AddWithValue("mop", mop);

                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Record Update!", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }
}

