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
    public partial class frmDownpayments : Form
    {
        Downpayment dp = new Downpayment();
        List<Downpayment> dpLists = new List<Downpayment>();
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
        public void Reset()
        {
            txtDPName.Text = "";
            cmbDepartment.Text = "";
            cmbGradeLevel.Text = "";
            txtAmount.Text = "";
            txtMonthly.Text = "";
            cmbStatus.Text = "";

            btnAdd.Text = "&Add New";

        }

        public frmDownpayments()
        {
            InitializeComponent();
            dp.LoadDataTable(dgvDP);
            AddImageDataGrid(dgvDP);
            HeaderFix(dgvDP);
            GetGradeLevel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "&Update")
            {
                util.ValidateTextBox3(txtAmount,txtDPName,txtMonthly);// Validation before Updating
                util.ValidateCombobox3(cmbStatus,cmbGradeLevel,cmbDepartment);
                if (util.readyToSave == 1)
                {
                    #region UPDATE DISCOUNT
                    dp.Id = id;
                    dp.Dp_name = txtDPName.Text;
                    dp.Dept = cmbDepartment.Text;
                    dp.Grade_level = cmbGradeLevel.Text;
                    dp.Amount = txtAmount.Text;
                    dp.Monthly = txtMonthly.Text;
                    dp.Status = cmbStatus.Text;
                    
                    dp.Update();
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
                util.ValidateTextBox3(txtAmount, txtDPName, txtMonthly);// Validation before Updating   
                util.ValidateCombobox3(cmbStatus, cmbGradeLevel, cmbDepartment);
                if (util.readyToSave == 1)
                {

                    dp.Id = id;
                    dp.Dp_name = txtDPName.Text;
                    dp.Dept = cmbDepartment.Text;
                    dp.Grade_level = cmbGradeLevel.Text;
                    dp.Amount = txtAmount.Text;
                    dp.Monthly = txtMonthly.Text;
                    dp.Status = cmbStatus.Text;


                    dp.Save();
                    Reset();
                }
                else
                {
                    Reset();
                    return;
                }
            }
            dp.LoadDataTable(dgvDP);

        }

        private void dgvDP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                id = Convert.ToInt32(dgvDP.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria

                //pass value to edit mode               
                txtDPName.Text = dgvDP.Rows[e.RowIndex].Cells[3].Value.ToString(); //Name     
                cmbDepartment.Text = dgvDP.Rows[e.RowIndex].Cells[4].Value.ToString(); //Name                    
                cmbGradeLevel.Text = dgvDP.Rows[e.RowIndex].Cells[5].Value.ToString(); //Name                    
                txtAmount.Text = dgvDP.Rows[e.RowIndex].Cells[6].Value.ToString(); //Name                    
                txtMonthly.Text = dgvDP.Rows[e.RowIndex].Cells[7].Value.ToString(); //Name                    
                cmbStatus.Text = dgvDP.Rows[e.RowIndex].Cells[8].Value.ToString(); //Name                    
               

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
                    dp.Id = Convert.ToInt32(dgvDP.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria
                    dp.Delete();

                    dp.LoadDataTable(dgvDP);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
