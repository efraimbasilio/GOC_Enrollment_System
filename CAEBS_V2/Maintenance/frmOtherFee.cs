﻿using System;
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
    public partial class frmOtherFee : Form
    {
        OtherFee otherFee = new OtherFee();
        List<OtherFee> listOtherFee = new List<OtherFee>();

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
            txtFeeName.Text = "";
            txtValue.Text = "";
            btnAdd.Text = "&Add New";
            cmbDept.Text = "";
            cmbStatus.Text = "";
        }

        public frmOtherFee()
        {
            InitializeComponent();
            otherFee.LoadDataTable(dgvOtherFee);
            AddImageDataGrid(dgvOtherFee);
            HeaderFix(dgvOtherFee);
        }

        private void dgvOtherFee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                id = Convert.ToInt32(dgvOtherFee.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria

                //pass value to edit mode               
                txtFeeName.Text = dgvOtherFee.Rows[e.RowIndex].Cells[3].Value.ToString(); //Name     
                txtValue.Text = dgvOtherFee.Rows[e.RowIndex].Cells[4].Value.ToString(); //Name    
                cmbStatus.Text = dgvOtherFee.Rows[e.RowIndex].Cells[5].Value.ToString(); //Name  
                cmbDept.Text = dgvOtherFee.Rows[e.RowIndex].Cells[6].Value.ToString(); //Name  
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
                    otherFee.Id = Convert.ToInt32(dgvOtherFee.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria
                    otherFee.Delete();

                    otherFee.LoadDataTable(dgvOtherFee);
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
                util.ValidateTextBox2(txtValue, txtFeeName);// Validation before Updating
                util.ValidateCombobox2(cmbDept, cmbStatus);
                if (util.readyToSave == 1)
                {
                    #region UPDATE DISCOUNT
                    otherFee.Id = id;
                    otherFee.Otherfee_name = txtFeeName.Text;
                    otherFee.Amount =txtValue.Text;
                    otherFee.Status = cmbStatus.Text;
                    otherFee.Dept = cmbDept.Text;

                    otherFee.Update();
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
                util.ValidateTextBox2(txtValue, txtFeeName);// Validation before Updating
                util.ValidateCombobox2(cmbDept, cmbStatus);
                if (util.readyToSave == 1)
                {
                    #region UPDATE DISCOUNT
                    otherFee.Id = id;
                    otherFee.Otherfee_name = txtFeeName.Text;
                    otherFee.Amount = txtValue.Text;
                    otherFee.Status = cmbStatus.Text;
                    otherFee.Dept = cmbDept.Text;
                    otherFee.Save();
                    Reset();
                    #endregion   
                }
                else
                {
                    Reset();
                    return;
                }
            }
            otherFee.LoadDataTable(dgvOtherFee);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
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
