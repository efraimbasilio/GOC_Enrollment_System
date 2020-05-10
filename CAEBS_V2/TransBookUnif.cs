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
        protected string stud_no;
        protected string or_no;
        protected string book_title;
        protected string book_order;
        protected string unif_desc;
        protected string unif_qty;
        protected string unif_size;
       
        public int Id { get { return id; } set { id = value; } }
        public string Stud_no { get { return stud_no; } set { stud_no = value; } }
        public string Or_no { get { return or_no; } set { or_no = value; } }
        public string Book_title { get { return book_title; } set { book_title = value; } }
        public string Book_order { get { return book_order; } set { book_order = value; } }
        public string Unif_desc { get { return unif_desc; } set { unif_desc = value; } }
        public string Unif_qty { get { return unif_qty; } set { unif_qty = value; } }
        public string Unif_size { get { return unif_size; } set { unif_size = value; } }

        List<TransBookUnif> transBokUnifs = new List<TransBookUnif>();

        public void LoadDataTable(DataGridView dgv)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();
                    string sql = "SELECT * FROM  trans_book_unif_fee";
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

                    string sql = "SELECT * FROM  trans_book_unif_fee";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //loop while have record
                    while (reader.Read())
                    {
                        //instantiate model
                        TransBookUnif trans = new TransBookUnif();

                        //prepare properties
                        trans.id = Convert.ToInt32(reader["id"].ToString());
                        trans.stud_no = reader["stud_no"].ToString();
                        trans.or_no = reader["or_no"].ToString();
                        trans.book_title = reader["book_title"].ToString();
                        trans.book_order = reader["book_order"].ToString();
                        trans.unif_desc = reader["unif_desc"].ToString();
                        trans.unif_qty = reader["unif_qty"].ToString();
                        trans.unif_size = reader["unif_size"].ToString();

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

                    string sql = "INSERT INTO trans_book_unif_fee(stud_no,or_no,book_title,book_order,unif_desc,unif_qty,unif_size) " +
                                   " VALUES (@stud_no,@or_no,@book_title,@book_order,@unif_desc,@unif_qty,@unif_size);";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("stud_no", stud_no);
                    cmd.Parameters.AddWithValue("or_no", or_no);
                    cmd.Parameters.AddWithValue("book_title", book_title);
                    cmd.Parameters.AddWithValue("book_order", book_order);
                    cmd.Parameters.AddWithValue("unif_desc", unif_desc);
                    cmd.Parameters.AddWithValue("unif_qty", unif_qty);
                    cmd.Parameters.AddWithValue("unif_size", unif_size);                    

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
