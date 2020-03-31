using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace CAEBS_V2
{
    class Room
    {
        protected int id;
        protected string room_name;
        protected string location;
        protected string capacity;
        protected string room_ceiling;

        public int Id { get { return id; } set { id = value; } }
        public string Room_name { get { return room_name; } set { room_name = value; } }
        public string Location { get { return location; } set { location = value; } }
        public string Capacity { get { return capacity; } set { capacity = value; } }
        public string Room_ceiling { get { return room_ceiling; } set { room_ceiling = value; } }

        List<Room> rooms = new List<Room> ();

        public void LoadDataTable(DataGridView dgv)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();
                    string sql = "SELECT * FROM room";
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

                    //string sql = "INSERT INTO room(room_name,location,capacity,room_ceiling)) " +
                    //               " VALUES (@room_name,@location,@capacity,@room_ceiling);";
                    string sql = "INSERT INTO room(room_name,location,capacity,room_ceiling) " +
                                   " VALUES (@room_name,@location,@capacity,@room_ceiling);";
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("room_name", room_name);
                    cmd.Parameters.AddWithValue("location", location);
                    cmd.Parameters.AddWithValue("capacity", capacity);
                    cmd.Parameters.AddWithValue("room_ceiling", room_ceiling);
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

                    string sql = "UPDATE room SET room_name=@room_name, location=@location ,capacity=@capacity ,room_ceiling=@room_ceiling " +
                                    " WHERE id=@id;";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("room_name", room_name);
                    cmd.Parameters.AddWithValue("location", location);
                    cmd.Parameters.AddWithValue("capacity", capacity);
                    cmd.Parameters.AddWithValue("room_ceiling", room_ceiling);

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

                    string sql = "DELETE  FROM room WHERE id=@id;";

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
