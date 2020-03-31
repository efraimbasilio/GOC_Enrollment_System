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
    public partial class frmTuition : Form
    {
        Tuition tuition = new Tuition();
        List<Tuition> listTuition = new List<Tuition>();
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
            txtTuitionName.Text = "";
            txtAmount.Text = "";
            btnAdd.Text = "&Add New";
            
            cmbStatus.Text = "";
            cmbDepartment.Text = "";
            cmbGradeLevel.Text = "";
        }

        public void GetGradeLevel()
        {
            cmbGradeLevel.Items.Clear();
            glevels.Clear();
            glevels = glevel.Load();
            foreach (var item in glevels)
            {
                cmbGradeLevel.Items.Add(item.Level);
            }    
        }

        public frmTuition()
        {
            InitializeComponent();
            tuition.LoadDataTable(dgvTuition);
            AddImageDataGrid(dgvTuition);
            HeaderFix(dgvTuition);
            GetGradeLevel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "&Update")
            {
                util.ValidateTextBox2(txtAmount, txtTuitionName);// Validation before Updating
                util.ValidateCombobox3(cmbGradeLevel, cmbStatus, cmbDepartment);
                if (util.readyToSave == 1)
                {
                    #region UPDATE DISCOUNT
                    tuition.Id = id;
                    tuition.Tuition_name = txtTuitionName.Text;
                    tuition.Amount = txtAmount.Text;                   
                    tuition.Status = cmbStatus.Text;
                    tuition.Grade_level = cmbGradeLevel.Text;
                    tuition.Dept = cmbDepartment.Text;

                    tuition.Update();
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
                util.ValidateTextBox2(txtAmount, txtTuitionName);// Validation before Updating
                util.ValidateCombobox3(cmbGradeLevel, cmbStatus, cmbDepartment);
                if (util.readyToSave == 1)
                {
                  
                    tuition.Tuition_name = txtTuitionName.Text;
                    tuition.Amount = txtAmount.Text;
                    tuition.Status = cmbStatus.Text;
                    tuition.Grade_level = cmbGradeLevel.Text;
                    tuition.Dept = cmbDepartment.Text;
                  
                    tuition.Save();
                    Reset();
                }
                else
                {
                    Reset();
                    return;
                }
            }
            tuition.LoadDataTable(dgvTuition);
        }

        private void dgvSY_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                id = Convert.ToInt32(dgvTuition.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria

                //pass value to edit mode               
                txtTuitionName.Text = dgvTuition.Rows[e.RowIndex].Cells[3].Value.ToString(); //Name     
                txtAmount.Text = dgvTuition.Rows[e.RowIndex].Cells[4].Value.ToString(); //Name                    
                cmbGradeLevel.Text = dgvTuition.Rows[e.RowIndex].Cells[5].Value.ToString(); //Name  
                cmbStatus.Text = dgvTuition.Rows[e.RowIndex].Cells[6].Value.ToString(); //Name  
                cmbDepartment.Text = dgvTuition.Rows[e.RowIndex].Cells[7].Value.ToString(); //Name  
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
                    tuition.Id = Convert.ToInt32(dgvTuition.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria
                    tuition.Delete();

                    tuition.LoadDataTable(dgvTuition);
                }
                else
                {
                    return;
                }
            }
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
