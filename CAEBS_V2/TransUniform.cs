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
    class TransUniform
    {
        protected int id;
        protected string stud_no;

        public int Id { get { return id; } set { id = value; } }
        public string Stud_no { get { return stud_no; } set { stud_no = value; } }

      
        List<TransUniform> listTransUnif = new List<TransUniform>();

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

        public void TransUnif(DataGridView dgv,String LRN)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                  
                    con.Open();                    
                    string sql = "SELECT unif_item.item_name,unif_item.price,trans_unif_fee.unif_qty,trans_unif_fee.unif_size FROM  trans_unif_fee INNER JOIN unif_item ON trans_unif_fee.unif_code = unif_item.unif_code WHERE trans_unif_fee.lrn =" + LRN +"";                    
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

        //public List<TransUniform> Load()
        //{
        //    try
        //    {
        //        using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
        //        {
        //            con.Open();

        //            string sql = "SELECT * FROM  trans_unif_fee";

        //            MySqlCommand cmd = new MySqlCommand(sql, con);

        //            MySqlDataReader reader = cmd.ExecuteReader();

        //            //loop while have record
        //            while (reader.Read())
        //            {
        //                //instantiate model
        //                TransUniform transUnif = new TransUniform();

        //                //prepare properties
        //                transUnif.id = Convert.ToInt32(reader["id"].ToString());
        //                transUnif.stud_no = reader["stud_no"].ToString();
        //                transUnif.or_no = reader["or_no"].ToString();
        //                transUnif.book_title = reader["book_title"].ToString();
        //                transUnif.book_order = reader["book_order"].ToString();
        //                transUnif.unif_desc = reader["unif_desc"].ToString();
        //                transUnif.unif_qty = reader["unif_qty"].ToString();
        //                transUnif.unif_size = reader["unif_size"].ToString();

        //                listTransUnif.Add(transUnif);

        //            }
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {

        //        MessageBox.Show("ERROR : " + ex.ToString(), "GOCINFOSYS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return listTransUnif;
        //}//End of Load

    }
}
