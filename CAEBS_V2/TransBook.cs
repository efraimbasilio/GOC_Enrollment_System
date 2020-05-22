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
    class TransBook
    {
        protected int id;
        protected string reg_no;
        protected string or_no;
        protected string book_id;
        protected string order_status;
        
        public int Id { get { return id; } set { id = value; } }
        public string Reg_no { get { return reg_no; } set { reg_no = value; } }
        public string Or_no { get { return or_no; } set { or_no = value; } }
        public string Book_id { get { return book_id; } set { book_id = value; } }
        public string Order_status { get { return order_status; } set { order_status = value; } }
        

        List<TransBook> listTransBook = new List<TransBook>();

        public void LoadDataTable(DataGridView dgv)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();
                    string sql = "SELECT * FROM  trans_book_fee";

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

                    string sql = "INSERT INTO trans_book_fee(reg_no, or_no, book_id, order_status) " +
                                    " VALUES (@reg_no, @or_no, @book_id, @order_status);";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("reg_no", reg_no);
                    cmd.Parameters.AddWithValue("or_no", or_no);
                    cmd.Parameters.AddWithValue("amount_given", book_id);
                    cmd.Parameters.AddWithValue("order_status", order_status);
                    

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "GOCINFOSYS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Update_Order_Status()
        {
            try
            {
                //prepare connection string 
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {

                    //try to open connection
                    con.Open();

                    string sql = "UPDATE trans_book_fee SET order_status=@order_status ,or_no=@or_no " +
                                    " WHERE id=@id;";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("order_status", order_status);
                    cmd.Parameters.AddWithValue("or_no", or_no);

                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Recorde Updated!", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



    }
}


