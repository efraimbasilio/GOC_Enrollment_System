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
    public partial class frmDiscount : Form
    {
        Discount discount = new Discount();
        List<Discount> listDiscount = new List<Discount>();

        Util_RequiredFields util = new Util_RequiredFields();

        public int id;

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
            txtDiscountName.Text = "";
            txtValue.Text = "";
            btnAdd.Text = "&Add New";
        }


        public frmDiscount()
        {
            InitializeComponent();
            discount.LoadDataTable(dgvDiscount);
            AddImageDataGrid(dgvDiscount);
            HeaderFix(dgvDiscount);
        }

        private void dgvDiscount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                id = Convert.ToInt32(dgvDiscount.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria

                //pass value to edit mode               
                txtDiscountName.Text = dgvDiscount.Rows[e.RowIndex].Cells[3].Value.ToString(); //Name     
                txtValue.Text = dgvDiscount.Rows[e.RowIndex].Cells[4].Value.ToString(); //Name    

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
                    Discount discount = new Discount();
                    discount.Id = Convert.ToInt32(dgvDiscount.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria
                    discount.Delete();

                    discount.LoadDataTable(dgvDiscount);
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
                util.ValidateTextBox2(txtDiscountName, txtValue);// Validation before Updating

                if (util.readyToSave == 1)
                {
                    #region UPDATE DISCOUNT
                    discount.Discount_name = txtDiscountName.Text;
                    if (optAmount.Checked == true)
                    {
                        discount.Id = id;
                        discount.Percentage = "0";
                        discount.Amount = txtValue.Text;
                        discount.Status = cmbStatus.Text;
                        discount.Update();
                        Reset();
                    }
                    else
                    {
                        if (Convert.ToInt32(txtValue.Text) > 100)//discount to tuition fee
                        {
                            MessageBox.Show("Percentage should be not morethan 100%");
                            txtValue.SelectAll();
                            return;
                        }
                        else
                        {
                            discount.Id = id;
                            discount.Percentage = txtValue.Text;
                            discount.Amount = "0";
                            discount.Status = cmbStatus.Text;
                            discount.Update();
                            Reset();
                        }
                    }
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
                util.ValidateTextBox2(txtDiscountName, txtValue);// Validation before saving


                if (util.readyToSave == 1)
                {
                    #region SAVE DISCOUNT
                    discount.Discount_name = txtDiscountName.Text;
                    if (optAmount.Checked == true)
                    {
                        discount.Amount = txtValue.Text;
                        discount.Percentage = "0";
                        discount.Status = cmbStatus.Text;
                        discount.Save();
                        Reset();
                    }
                    else
                    {
                        discount.Percentage = txtValue.Text;
                        if (Convert.ToInt32(txtValue.Text) > 100)//discount to tuition fee
                        {
                            MessageBox.Show("Percentage should be not morethan 100%");
                            txtValue.SelectAll();
                            return;
                        }
                        else
                        {
                            discount.Amount = "0";
                            discount.Percentage = txtValue.Text;
                            discount.Status = cmbStatus.Text;
                            discount.Save();
                            Reset();
                        }
                    }
                    #endregion
                }
                else
                {
                    Reset();
                    return;
                }
            }
            discount.LoadDataTable(dgvDiscount);
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
