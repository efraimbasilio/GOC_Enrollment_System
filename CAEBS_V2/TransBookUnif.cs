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
    class TransBookUnif
    {
        protected int id;
        protected string lrn;
        protected string reg_no;
        protected string or_no;        
        protected string unif_code;      
        protected string unif_qty;
        protected string unif_size;
        protected string order_status;

        public int Id { get { return id; } set { id = value; } }
        public string LRN { get { return lrn; } set { lrn = value; } }
        public string Reg_no { get { return reg_no; } set { reg_no = value; } }
        public string OR_no { get { return or_no; } set { or_no = value; } }
        public string Unif_code { get { return unif_code; } set { unif_code = value; } }      
        public string Unif_qty { get { return unif_qty; } set { unif_qty = value; } }
        public string Unif_size { get { return unif_size; } set { unif_size = value; } }
        public string Order_status { get { return order_status; } set { order_status = value; } }



        List<TransBookUnif> transBokUnifs = new List<TransBookUnif>();
       

        public void LoadDataTable(DataGridView dgv)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();
                    string sql = "SELECT * FROM  trans_unif_fee";
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

        public List<TransBookUnif> Load()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();

                    string sql = "SELECT * FROM  trans_unif_fee";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //loop while have record
                    while (reader.Read())
                    {
                        //instantiate model
                        TransBookUnif trans = new TransBookUnif();

                        //prepare properties
                        trans.id = Convert.ToInt32(reader["id"].ToString());
                        trans.lrn = reader["lrn"].ToString();
                        trans.reg_no = reader["reg_no"].ToString();
                        trans.or_no = reader["or_no"].ToString();
                        trans.unif_code = reader["unif_code"].ToString();                      
                        trans.unif_qty = reader["unif_qty"].ToString();
                        trans.unif_size = reader["unif_size"].ToString();
                        trans.order_status = reader["order_status"].ToString();
                        transBokUnifs.Add(trans);

                    }
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("ERROR : " + ex.ToString(), "GOCINFOSYS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return transBokUnifs;
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

                    string sql = "INSERT INTO trans_unif_fee(reg_no,lrn,or_no,unif_code,unif_qty,unif_size,order_status) " +
                                   " VALUES (@reg_no,@lrn,@or_no,@unif_code,@unif_qty,@unif_size,order_status);";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("lrn", lrn);
                    cmd.Parameters.AddWithValue("reg_no", reg_no);
                    cmd.Parameters.AddWithValue("or_no", or_no);
                    cmd.Parameters.AddWithValue("unif_code", unif_code);
                    cmd.Parameters.AddWithValue("unif_qty", unif_qty);
                    cmd.Parameters.AddWithValue("unif_size", unif_size);
                    cmd.Parameters.AddWithValue("order_status", order_status);

                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Record Saved!", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
