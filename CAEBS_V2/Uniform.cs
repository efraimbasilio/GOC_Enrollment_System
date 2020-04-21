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
    class Uniform
    {
        protected int id;
        protected string unif_code;
        protected string item_name;
        protected string price;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Unif_code
        {
            get { return unif_code; }
            set { unif_code = value; }
        }

        public string Item_name
        {
            get { return item_name; }
            set { item_name = value; }
        }
        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        List<Uniform> listUniform = new List<Uniform>();

        public void LoadDataTable(DataGridView dgv)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();
                    string sql = "SELECT * FROM unif_item";
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
        public List<Uniform> Load()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();

                    string sql = "SELECT * FROM unif_item";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //loop while have record
                    while (reader.Read())
                    {
                        //instantiate model
                        Uniform unif = new Uniform();

                        //prepare properties
                        unif.id = Convert.ToInt32(reader["id"].ToString());
                        unif.unif_code = reader["unif_code"].ToString();
                        unif.item_name = reader["item_name"].ToString();
                        unif.price = reader["price"].ToString();
                        

                        listUniform.Add(unif);

                    }
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listUniform;
        }
    }
}
