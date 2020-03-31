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
    class Teacher
    {
        protected int id;
        protected string fname;
        protected string lname;
        protected string mname;
        protected string specialization;
        protected string adviser_of;

        public int Id { get { return id; } set { id = value; } }
        public string Fname { get { return fname; } set { fname = value; } }
        public string Lname { get { return lname; } set { lname = value; } }
        public string Mname { get { return mname; } set { mname = value; } }
        public string Specialization { get { return specialization; } set { specialization = value; } }
        public string Adviser_of { get { return adviser_of; } set { adviser_of = value; } }
        
        //instantiate model
        
        List<Teacher> teachers = new List<Teacher>();

        public void LoadDataTable(DataGridView dgv)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();
                    string sql = "SELECT * FROM teacher";
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

                    string sql = "INSERT INTO teacher(fname,lname,mname,specialization,adviser_of) " +
                                   " VALUES (@fname,@lname,@mname,@specialization,@adviser_of);";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("fname", fname);
                    cmd.Parameters.AddWithValue("lname", lname);
                    cmd.Parameters.AddWithValue("mname", mname);
                    cmd.Parameters.AddWithValue("specialization", specialization);
                    cmd.Parameters.AddWithValue("adviser_of", adviser_of);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Saved!", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    string sql = "UPDATE teacher SET fname=@fname, lname=@lname ,mname=@mname ,specialization=@specialization,adviser_of=@adviser_of  " +
                                    " WHERE id=@id;";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("fname", fname);
                    cmd.Parameters.AddWithValue("lname", lname);
                    cmd.Parameters.AddWithValue("mname", mname);
                    cmd.Parameters.AddWithValue("specialization", specialization);
                    cmd.Parameters.AddWithValue("adviser_of", adviser_of);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Recorde Updated!", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Delete()
        {
            try
            {
                //prepare connection string 
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {

                    //try to open connection
                    con.Open();

                    string sql = "DELETE  FROM teacher WHERE id=@id;";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record deleted!", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public List<Teacher> Load()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();

                    string sql = "SELECT * FROM teacher";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //loop while have record
                    while (reader.Read())
                    {
                        Teacher teacher = new Teacher();
                        //prepare properties
                        teacher.id = Convert.ToInt32(reader["id"].ToString());
                        teacher.fname = reader["fname"].ToString();
                        teacher.lname = reader["lname"].ToString();
                        teacher.mname = reader["mname"].ToString();
                        teacher.specialization = reader["specialization"].ToString();
                        teacher.adviser_of = reader["adviser_of"].ToString();

                        teachers.Add(teacher);
                    }
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return teachers;
        }
        
    }
}
