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
    class Downpayment
    {
        protected int id;
        protected string dp_name;
        protected string dept;
        protected string grade_level;
        protected string amount;
        protected string monthly;
        protected string status;

        public int Id { get { return id; } set { id = value; } }
        public string Dp_name { get { return dp_name; } set { dp_name = value; } }
        public string Dept { get { return dept; } set { dept = value; } }
        public string Grade_level { get { return grade_level; } set { grade_level = value; } }
        public string Amount { get { return amount; } set { amount = value; } }
        public string Monthly { get { return monthly; } set { monthly = value; } }
        public string Status { get { return status; } set { status = value; } }

        List<Downpayment> dpLists = new List<Downpayment>();

        public void LoadDataTable(DataGridView dgv)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();
                    string sql = "SELECT * FROM down_payment";
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

        public List<Downpayment> Load()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();

                    string sql = "SELECT * FROM down_payment";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //loop while have record
                    while (reader.Read())
                    {
                        //instantiate model
                        Downpayment dp = new Downpayment();

                        //prepare properties
                        dp.id = Convert.ToInt32(reader["id"].ToString());
                        dp.dp_name = reader["dp_name"].ToString();
                        dp.dept = reader["dept"].ToString();
                        dp.grade_level = reader["grade_level"].ToString();
                        dp.amount = reader["amount"].ToString();
                        dp.monthly = reader["monthly"].ToString();
                        dp.status = reader["status"].ToString();
                       
                        dpLists.Add(dp);
                    }
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("ERROR : " + ex.ToString(), "GOCINFOSYS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dpLists;
        }//End of Load

        public void Save()
        {
            try
            {
                //prepare connection string 
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {

                    //try to open connection
                    con.Open();

                    string sql = "INSERT INTO down_payment(dp_name,dept,grade_level,amount,monthly,status) " +
                                   " VALUES (@dp_name,@dept,@grade_level,@amount,@monthly,@status);";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("dp_name", dp_name);
                    cmd.Parameters.AddWithValue("dept", dept);
                    cmd.Parameters.AddWithValue("grade_level", grade_level);
                    cmd.Parameters.AddWithValue("amount", amount);
                    cmd.Parameters.AddWithValue("monthly", monthly);
                    cmd.Parameters.AddWithValue("status", status);
                    
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

                    string sql = "UPDATE down_payment SET dp_name=@dp_name ,dept=@dept ,grade_level=@grade_level ,amount=@amount ,monthly=@monthly ,status=@status" +
                                    " WHERE id=@id;";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("dp_name", dp_name);
                    cmd.Parameters.AddWithValue("dept", dept);
                    cmd.Parameters.AddWithValue("grade_level", grade_level);
                    cmd.Parameters.AddWithValue("amount", amount);
                    cmd.Parameters.AddWithValue("monthly", monthly);
                    cmd.Parameters.AddWithValue("status", status);


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

                    string sql = "DELETE  FROM down_payment WHERE id=@id;";

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

    }
}
