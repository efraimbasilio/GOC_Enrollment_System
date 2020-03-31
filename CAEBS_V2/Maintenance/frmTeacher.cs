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
    public partial class frmTeacher : Form
    {
        Teacher teacher = new Teacher();
        List<Teacher> listTeacher = new List<Teacher>();

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
            txtFName.Text = "";
            txtLName.Text = "";
            txtSpecialization.Text = "";
            txtMI.Text = "";
            cmbSections.Text = "";
            btnAdd.Text = "&Add New";
        }

        public frmTeacher()
        {
            InitializeComponent();
            teacher.LoadDataTable(dgvTeacher);
            AddImageDataGrid(dgvTeacher);
            HeaderFix(dgvTeacher);
        }

        private void frmTeacher_Load(object sender, EventArgs e)
        {

        }

        private void dgvTeacher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                id = Convert.ToInt32(dgvTeacher.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria

                //pass value to edit mode               
                txtFName.Text = dgvTeacher.Rows[e.RowIndex].Cells[3].Value.ToString(); //Name     
                txtLName.Text = dgvTeacher.Rows[e.RowIndex].Cells[4].Value.ToString(); //Name    
                txtMI.Text = dgvTeacher.Rows[e.RowIndex].Cells[5].Value.ToString(); //Name 
                txtSpecialization.Text = dgvTeacher.Rows[e.RowIndex].Cells[6].Value.ToString(); //Name 
                cmbSections.Text = dgvTeacher.Rows[e.RowIndex].Cells[7].Value.ToString(); //Name 

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
                    discount.Id = Convert.ToInt32(dgvTeacher.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria
                    discount.Delete();

                    discount.LoadDataTable(dgvTeacher);
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
                util.ValidateTextBox4(txtSpecialization, txtMI, txtLName,txtFName);// Validation before Updating
                util.ValidateCombobox1(cmbSections);
                if (util.readyToSave == 1)
                {                  
                    teacher.Id = id;
                    teacher.Fname = txtFName.Text;
                    teacher.Mname = txtLName.Text;
                    teacher.Lname = txtMI.Text;
                    teacher.Specialization = txtSpecialization.Text;
                    teacher.Adviser_of = cmbSections.Text;
                    teacher.Update();
                    Reset();
                }
                else
                {
                    Reset();
                    return;
                }

            }
            else
            {
                util.ValidateTextBox4(txtSpecialization, txtMI, txtLName, txtFName);// Validation before Updating
                util.ValidateCombobox1(cmbSections);
                if (util.readyToSave == 1)
                {
                    //teacher.Id = id;
                    teacher.Fname = txtFName.Text;
                    teacher.Mname = txtLName.Text;
                    teacher.Lname = txtMI.Text;
                    teacher.Specialization = txtSpecialization.Text;
                    teacher.Adviser_of = cmbSections.Text;
                    teacher.Save();
                    Reset();
                }
                else
                {
                    Reset();
                    return;
                }
            }
            teacher.LoadDataTable(dgvTeacher);
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
