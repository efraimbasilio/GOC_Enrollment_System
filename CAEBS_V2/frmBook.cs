using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAEBS_V2
{
    public partial class frmBook : Form
    {
        Book book = new Book();
        private int id;
        List<Book> listBook = new List<Book>();

        Strand strand = new Strand();
        List<Strand> listStrand = new List<Strand>();

        Util_RequiredFields util = new Util_RequiredFields();
        private void LoadStrand()
        {
            listStrand.Clear();
            cmbStrand.Items.Clear();
            listStrand = strand.Load();
            foreach (var item in listStrand)
            {
                cmbStrand.Items.Add(item.Strand_name);
            }
        }

        public frmBook()
        {
            InitializeComponent();
            book.LoadDataTable(dgvBooks);
            AddImageDataGrid(dgvBooks);
            HeaderFix(dgvBooks);
            LoadStrand();
        }

        public void AddImageDataGrid(DataGridView dgv)
        {
            DataGridViewImageColumn dimg = new DataGridViewImageColumn();
            dimg.Image = Properties.Resources.edit;
            dimg.HeaderText = "Edit";
            dimg.ImageLayout = DataGridViewImageCellLayout.Normal;
            dimg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns.Add(dimg);


            DataGridViewImageColumn dimgDelete = new DataGridViewImageColumn();
            dimgDelete.Image = Properties.Resources.delete;
            dimgDelete.HeaderText = "Delete";
            dimgDelete.ImageLayout = DataGridViewImageCellLayout.Normal;
            dimgDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns.Add(dimgDelete);
        }

        public void HeaderFix(DataGridView dgv)
        {
            #region Header Name
            dgv.Columns["id"].Visible = false;

            DataGridViewColumn FillSize = dgv.Columns[1];
            FillSize.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            #endregion
        }
        public void Reset()
        {
            txtBookId.Text = "";
            txtBookTitle.Text = "";
            btnAdd.Text = "&Add New";
            txtPrice.Text = "";
            cmbGLevel.Text = "";
            cmbStrand.Text = "";
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                id = Convert.ToInt32(dgvBooks.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria

                //pass value to edit mode               
                txtBookId.Text = dgvBooks.Rows[e.RowIndex].Cells[3].Value.ToString(); //Name     
                txtBookTitle.Text = dgvBooks.Rows[e.RowIndex].Cells[4].Value.ToString(); //Name    
                cmbGLevel.Text = dgvBooks.Rows[e.RowIndex].Cells[5].Value.ToString(); //Name  
                txtPrice.Text = dgvBooks.Rows[e.RowIndex].Cells[6].Value.ToString(); //Name  
                cmbStrand.Text = dgvBooks.Rows[e.RowIndex].Cells[7].Value.ToString(); //Name  
                btnAdd.Text = "&Update";//set button to Update                
            }

            else if (e.ColumnIndex == 1)
            {
                string message = "Do you want to delete this record?";
                string title = "Enrollment System";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    book.Id = Convert.ToInt32(dgvBooks.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria
                    //book.Delete();

                    book.LoadDataTable(dgvBooks);
                }
                else
                {
                    return;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "&Update")
            {
                util.ValidateTextBox3(txtBookId, txtBookTitle, txtPrice);// Validation before Updating
                util.ValidateCombobox2(cmbGLevel, cmbStrand);
                if (util.readyToSave == 1)
                {
                    #region UPDATE DISCOUNT
                    book.Id = id;
                    book.Book_id = txtBookId.Text;
                    book.Title = txtBookTitle.Text;
                    book.Price = txtPrice.Text;
                    book.Strand = cmbStrand.Text;
                    book.Grade_level = cmbGLevel.Text;

                    book.Update();
                    Reset();
                    #endregion              
                }
                else
                {
                    Reset();
                    return;
                }
            }
            else
            {
                util.ValidateTextBox3(txtBookId, txtBookTitle, txtPrice);// Validation before Updating
                util.ValidateCombobox2(cmbGLevel, cmbStrand);
                if (util.readyToSave == 1)
                {
                    #region UPDATE DISCOUNT
                    book.Id = id;
                    book.Book_id = txtBookId.Text;
                    book.Title = txtBookTitle.Text;
                    book.Price = txtPrice.Text;
                    book.Strand = cmbStrand.Text;
                    book.Grade_level = cmbGLevel.Text;

                    book.Save();
                    Reset();
                    #endregion   
                }
                else
                {
                    Reset();
                    return;
                }
            }
            book.LoadDataTable(dgvBooks);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmMaintenance frm = new frmMaintenance();
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
            mainwin.pnlAllContainer.Controls.Clear();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(frm);
            frm.Show();
        }
    }
}
