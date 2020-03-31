﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace CAEBS_V2
{
    class MiscFee
    {        
        protected int id;
        protected string miscFeeName;
        protected double miscFeeAmount;
       
        public int Id
        {
            get { return id; }
            set { id = value; }
        }        

        public string MiscFeeName
        {
            get { return miscFeeName; }
            set { miscFeeName = value; }
        }

        public double MiscFeeAmount
        {
            get { return miscFeeAmount; }
            set { miscFeeAmount = value; }
        }
        
        List<MiscFee> miscFees = new List<MiscFee>();      

        public void LoadDataTable(DataGridView dgv)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();
                    string sql = "SELECT * FROM miscfee";
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

                    string sql = "INSERT INTO miscfee(miscfee_name,amount) " +
                                    " VALUES (@miscFeeName,@miscFeeAmount);";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("miscFeeName", miscFeeName);
                    cmd.Parameters.AddWithValue("miscFeeAmount", miscFeeAmount);                   
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Saved!", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public List<MiscFee> Load()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();

                    string sql = "SELECT * FROM miscfee";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //loop while have record
                    while (reader.Read())
                    {
                        //instantiate model
                        MiscFee miscFee = new MiscFee();

                        //prepare properties
                        miscFee.id = Convert.ToInt32(reader["id"].ToString());
                        miscFee.miscFeeName = reader["miscfee_name"].ToString();                       
                        miscFee.miscFeeAmount = Convert.ToDouble(reader["amount"]);
                        miscFees.Add(miscFee);

                    }
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return miscFees;
        }

        public List<MiscFee> GetMiscFeeById()
        {
            try
            {
                //prepare connection string 
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {

                    //try to open connection
                    con.Open();

                    //prepare sql query
                    string sql = "SELECT * FROM miscfee;";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("miscfee_name", miscFeeName);
                    cmd.Parameters.AddWithValue("amount", miscFeeAmount);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    //loop while have record
                    while (reader.Read())
                    {
                        //instantiate model
                        MiscFee miscFee = new MiscFee();

                        //prepare properties                        
                        miscFee.miscFeeName = reader["misc_fee_name"].ToString();                   
                        miscFee.miscFeeAmount = Convert.ToDouble(reader["misc_amount"]);

                        miscFees.Add(miscFee);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return miscFees;
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

                    string sql = "UPDATE miscfee SET miscfee_name=@miscFeeName,amount=@miscFeeAmount" +
                                    " WHERE id=@id;";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("miscFeeName", miscFeeName);
                    cmd.Parameters.AddWithValue("miscFeeAmount", miscFeeAmount);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Recorde Updated!", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
   
        public List<MiscFee> GetById()
        {
            try
            {
                //prepare connection string 
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {

                    //try to open connection
                    con.Open();

                    //prepare sql query
                    string sql = "SELECT * FROM miscfee WHERE id =@id;";


                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id", id);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //loop while have record
                    while (reader.Read())
                    {
                        //instantiate model
                        MiscFee miscFee = new MiscFee();

                        //prepare properties
                        miscFee.id = Convert.ToInt32(reader["id"].ToString());
                        miscFee.miscFeeName = reader["miscfee_name"].ToString();                       
                        miscFee.miscFeeAmount = Convert.ToDouble(reader["amount"]);
                        miscFees.Add(miscFee);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return miscFees;
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

                    string sql = "DELETE  FROM miscfee WHERE id=@id;";

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
