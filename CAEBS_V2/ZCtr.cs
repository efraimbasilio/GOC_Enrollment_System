﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAEBS_V2
{
    class ZCtr
    {
        protected int id;
        protected string ctr_number;
        protected string ctr_goc_no;

        public int Id { get { return id; } set { id = value; } }
        public string Ctr_number { get { return ctr_number; } set { ctr_number = value; } }
        public string Ctr_goc_no { get { return ctr_goc_no; } set { ctr_goc_no = value; } }

        List<ZCtr> ctrs = new List<ZCtr>();
        public List<ZCtr> Load()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();

                    string sql = "SELECT * FROM z_ctr";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //loop while have record
                    while (reader.Read())
                    {
                        //instantiate model
                        ZCtr ctr = new ZCtr();

                        //prepare properties
                        ctr.id = Convert.ToInt32(reader["id"].ToString());
                        ctr.ctr_number = reader["ctr"].ToString();
                        ctr.ctr_number = reader["ctr_goc_no"].ToString();
                        ctrs.Add(ctr);
                    }
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ctrs;
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

                    string sql = "UPDATE z_ctr SET ctr=@ctr_number " +
                                    " WHERE id=@id;";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("ctr_number", ctr_number);         

                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Recorde Updated!", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Update_CTR_GOC_NO()
        {
            try
            {
                //prepare connection string 
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {

                    //try to open connection
                    con.Open();

                    string sql = "UPDATE z_ctr SET ctr_goc_no=@ctr_goc_no " +
                                    " WHERE id=@id;";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("ctr_goc_no", ctr_goc_no);

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
