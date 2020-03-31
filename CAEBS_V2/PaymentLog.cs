using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAEBS_V2
{
    class PaymentLog
    {
        List<PaymentLog> payLogs = new List<PaymentLog>();

        protected int id;
        protected string stud_no;
        protected string lrn_no;
        protected string or_no;
        protected string amount_given;
        protected string payment_no;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Stud_No
        {
            get { return stud_no; }
            set { stud_no = value; }
        }

        public string LRN_No
        {
            get { return lrn_no; }
            set { lrn_no = value; }
        }

        public string OR_No
        {
            get { return or_no; }
            set { or_no = value; }
        }
        public string Amount_Given
        {
            get { return amount_given; }
            set { amount_given = value; }
        }
        public string Payment_No
        {
            get { return payment_no; }
            set { payment_no = value; }
        }

        public List<PaymentLog> Load()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();

                    string sql = "SELECT * FROM payment_log";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //loop while have record
                    while (reader.Read())
                    {
                        //instantiate model
                        PaymentLog payment = new PaymentLog();

                        //prepare properties
                        payment.id = Convert.ToInt32(reader["id"].ToString());
                        payment.stud_no = reader["stud_no"].ToString();
                        payment.or_no = reader["or_no"].ToString();
                        payment.amount_given = reader["amount_given"].ToString();
                        payment.payment_no = reader["payment_no"].ToString();                        
                       
                        payLogs.Add(payment);

                    }
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("ERROR : " + ex.ToString(), "GOCINFOSYS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return payLogs;
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

                    string sql = "INSERT INTO payment_log(stud_no,or_no,amount_given,payment_no,lrn_no) " +
                                    " VALUES (@stud_no,@or_no,@amount_given,@payment_no,@lrn_no);";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("stud_no", stud_no);
                    cmd.Parameters.AddWithValue("or_no", or_no);
                    cmd.Parameters.AddWithValue("amount_given", amount_given);
                    cmd.Parameters.AddWithValue("payment_no", payment_no);
                    cmd.Parameters.AddWithValue("lrn_no", lrn_no);
                    
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "GOCINFOSYS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public List<PaymentLog> GetPaymentNo() //LRN as the key
        {
            try
            {
                //prepare connection string 
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {

                    //try to open connection
                    con.Open();

                    //prepare sql query
                    string sql = "SELECT * FROM payment_log WHERE lrn_no=@lrn_no;";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("lrn_no", lrn_no);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //loop while have record
                    while (reader.Read())
                    {
                        //instantiate model
                        PaymentLog payment = new PaymentLog();
                        //prepare properties
                        payment.payment_no = reader["payment_no"].ToString();
                        payLogs.Add(payment);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return payLogs;
        }


    }
}
