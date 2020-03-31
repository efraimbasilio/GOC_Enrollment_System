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
    public partial class frmGradeLevel : Form
    {
        GradeLevel glevel = new GradeLevel();
        List<GradeLevel> glevels = new List<GradeLevel>();

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
            txtGradeLevel.Text = "";
            txtDesc.Text = "";
            btnAdd.Text = "&Add New";
           
        }

        public frmGradeLevel()
        {
            InitializeComponent();
            glevel.LoadDataTable(dgvGradeLevel);
            AddImageDataGrid(dgvGradeLevel);
            HeaderFix(dgvGradeLevel);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "&Update")
            {
                util.ValidateTextBox2(txtDesc, txtGradeLevel);// Validation before Updating
                
                if (util.readyToSave == 1)
                {
                    #region UPDATE DISCOUNT
                    glevel.Id = id;
                    glevel.Level = txtGradeLevel.Text;
                    glevel.Descp = txtDesc.Text;

                    glevel.Update();
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
                util.ValidateTextBox2(txtDesc, txtGradeLevel);// Validation before Updating   
                if (util.readyToSave == 1)
                {

                    glevel.Id = id;
                    glevel.Level = txtGradeLevel.Text;
                    glevel.Descp = txtDesc.Text;

                    glevel.Save();
                    Reset();
                }
                else
                {
                    Reset();
                    return;
                }
            }
            glevel.LoadDataTable(dgvGradeLevel);
        }

        private void dgvGradeLevel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                id = Convert.ToInt32(dgvGradeLevel.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria

                //pass value to edit mode               
                txtGradeLevel.Text = dgvGradeLevel.Rows[e.RowIndex].Cells[3].Value.ToString(); //Name     
                txtDesc.Text = dgvGradeLevel.Rows[e.RowIndex].Cells[4].Value.ToString(); //Name                    
               
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
                    glevel.Id = Convert.ToInt32(dgvGradeLevel.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria
                    glevel.Delete();

                    glevel.LoadDataTable(dgvGradeLevel);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
