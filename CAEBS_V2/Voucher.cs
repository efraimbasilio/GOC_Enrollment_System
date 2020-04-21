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
    class Voucher
    {
        protected int id;
        protected string voucher_from;
        protected string voucher_amount;
        protected string dp_Amount;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Voucher_from
        {
            get { return voucher_from; }
            set { voucher_from = value; }
        }

        public string Voucher_amount
        {
            get { return voucher_amount; }
            set { voucher_amount = value; }
        }

        public string DP_Amount
        {
            get { return dp_Amount; }
            set { dp_Amount = value; }
        }

        List<Voucher> vouchers = new List<Voucher>();

        public void LoadDataTable(DataGridView dgv)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();
                    string sql = "SELECT * FROM voucher";
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

        public List<Voucher> Load()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();

                    string sql = "SELECT * FROM voucher";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //loop while have record
                    while (reader.Read())
                    {
                        //instantiate model
                        Voucher voucher = new Voucher();

                        //prepare properties
                        voucher.id = Convert.ToInt32(reader["id"].ToString());
                        voucher.voucher_from = reader["voucher_from"].ToString();
                        voucher.voucher_amount = reader["voucher_amount"].ToString();
                        voucher.dp_Amount = reader["dp_Amount"].ToString();
                        vouchers.Add(voucher);

                    }
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return vouchers;
        }
    }
}

