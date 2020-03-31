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
    public partial class frmRoom : Form
    {
        Room room = new Room();
        List<Room> listRoom = new List<Room>();

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
            txtCeiling.Text = "";
            txtLocation.Text = "";
            btnAdd.Text = "&Add New";
            txtMax.Text = "";
            txtRoomName.Text = "";
        }

        public frmRoom()
        {
            InitializeComponent();
            room.LoadDataTable(dgvRoom);
            AddImageDataGrid(dgvRoom);
            HeaderFix(dgvRoom);
        }

        private void dgvRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                id = Convert.ToInt32(dgvRoom.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria

                //pass value to edit mode               
                txtRoomName.Text = dgvRoom.Rows[e.RowIndex].Cells[3].Value.ToString(); //Name     
                txtLocation.Text = dgvRoom.Rows[e.RowIndex].Cells[4].Value.ToString(); //Name    
                txtMax.Text = dgvRoom.Rows[e.RowIndex].Cells[5].Value.ToString(); //Name  
                txtCeiling.Text = dgvRoom.Rows[e.RowIndex].Cells[6].Value.ToString(); //Name  
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
                    room.Id = Convert.ToInt32(dgvRoom.Rows[e.RowIndex].Cells[2].Value.ToString());//for editing criteria
                    room.Delete();

                    room.LoadDataTable(dgvRoom);
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
                util.ValidateTextBox4(txtCeiling, txtLocation,txtMax,txtRoomName);// Validation before Updating
                
                if (util.readyToSave == 1)
                {
                    #region UPDATE DISCOUNT
                    room.Id = id;
                    room.Room_name = txtRoomName.Text;
                    room.Room_ceiling = txtCeiling.Text;
                    room.Location = txtLocation.Text;
                    room.Capacity = txtMax.Text;                    

                    room.Update();
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
                util.ValidateTextBox4(txtCeiling, txtLocation, txtMax, txtRoomName);
                if (util.readyToSave == 1)
                {
                    #region UPDATE DISCOUNT
                    room.Id = id;
                    room.Room_name = txtRoomName.Text;
                    room.Room_ceiling = txtCeiling.Text;
                    room.Location = txtLocation.Text;
                    room.Capacity = txtMax.Text;
                    room.Save();
                    Reset();
                    #endregion   
                }
                else
                {
                    Reset();
                    return;
                }
            }
            room.LoadDataTable(dgvRoom);
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
