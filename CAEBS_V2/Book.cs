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
    class Book
    {
        protected int id;
        protected string book_id;
        protected string title;
        protected string grade_level;
        protected string price;
        protected string strand;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Book_id
        {
            get { return book_id; }
            set { book_id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Grade_level
        {
            get { return grade_level; }
            set { grade_level = value; }
        }

        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Strand
        {
            get { return strand; }
            set { strand = value; }
        }

        List<Book> books = new List<Book>();

        public void LoadDataTable(DataGridView dgv)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();
                    string sql = "SELECT * FROM book_item";
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

        public List<Book> Load()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(CAEBS_V2.Config.GetConnectionString()))
                {
                    con.Open();

                    string sql = "SELECT * FROM book_item";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    //loop while have record
                    while (reader.Read())
                    {
                        //instantiate model
                        Book book = new Book();

                        //prepare properties
                        book.id = Convert.ToInt32(reader["id"].ToString());
                        book.book_id = reader["book_id"].ToString();
                        book.title = reader["title"].ToString();
                        book.grade_level = reader["grade_level"].ToString();
                        book.price = reader["price"].ToString();
                        book.strand = reader["strand"].ToString();
                        books.Add(book);
                    }
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("ERROR : " + ex.ToString(), "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return books;
        }
    }
}
