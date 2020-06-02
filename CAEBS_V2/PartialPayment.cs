using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAEBS_V2
{
    class PartialPayment
    {       
        protected int id;
        protected string or_no;
        protected string stud_no;
        protected string lrn_no;
        protected string full_name;
        protected string downp;
        protected string p1;
        protected string p2;
        protected string p3;
        protected string p4;
        protected string p5;
        protected string p6;
        protected string p7;
        protected string p8;
        protected string p9;
        protected string p10; 
        protected string balance;
        protected string enrollment_status;

        public int Id { get { return id; } set { id = value; } }
        public string OR_no { get { return or_no; } set { or_no = value; } }
        public string Stud_no { get { return stud_no; } set { stud_no = value; } }
        public string LRN_no { get { return lrn_no; } set { lrn_no = value; } }
        public string Full_name { get { return full_name; } set { full_name = value; } }
        public string DP { get { return downp; } set { downp = value; } }
        public string P1 { get { return p1; } set { p1 = value; } }
        public string P2 { get { return p2; } set { p2 = value; } }
        public string P3 { get { return p3; } set { p3 = value; } }
        public string P4 { get { return p4; } set { p4 = value; } }
        public string P5 { get { return p5; } set { p5 = value; } }
        public string P6 { get { return p6; } set { p6 = value; } }
        public string P7 { get { return p7; } set { p7 = value; } }
        public string P8 { get { return p8; } set { p8 = value; } }
        public string P9 { get { return p9; } set { p9 = value; } }
        public string P10 { get { return p10; } set { p10 = value; } }
        public string Balance { get { return balance; } set { balance = value; } }
        public string Enrollment_status { get { return enrollment_status; } set { enrollment_status = value; } }


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


        public void Save()
        {
            try
            {
                //prepare connection string 
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {

                    //try to open connection
                    con.Open();                    
                    string sql = "INSERT INTO billing_partial(or_no,stud_no,lrn_no,full_name,DP,p1,p2,p3,p4,p5,p6,p7,p8,p9,p10c)" +
                                 "VALUES(@or_no);";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("or_no", or_no);
                    cmd.Parameters.AddWithValue("stud_no", stud_no);
                    cmd.Parameters.AddWithValue("lrn", lrn_no);
                    cmd.Parameters.AddWithValue("full_name", full_name);
                    cmd.Parameters.AddWithValue("DP", DP);
                    cmd.Parameters.AddWithValue("p1", p1);
                    cmd.Parameters.AddWithValue("p2", p2);
                    cmd.Parameters.AddWithValue("p3", p3);
                    cmd.Parameters.AddWithValue("p4", p4);
                    cmd.Parameters.AddWithValue("p5", p5);
                    cmd.Parameters.AddWithValue("p6", p6);
                    cmd.Parameters.AddWithValue("p7", p7);
                    cmd.Parameters.AddWithValue("p8", p8);
                    cmd.Parameters.AddWithValue("p9", p9);
                    cmd.Parameters.AddWithValue("p10", p10);
                    cmd.Parameters.AddWithValue("balance", balance);
                    cmd.Parameters.AddWithValue("enrollment_status", enrollment_status);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Saved!", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //save_halt = false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.Message, "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //save_halt = true;
            }
        }
    }
}

