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
    public partial class frmRegistration : Form
    {
        //Register register = new Register();
        //List<Register> registerList = new List<Register>();

        //public void HeaderFix(DataGridView dgv)
        //{
        //    #region Header Name
        //    dgv.Columns["id"].Visible = false;

        //    DataGridViewColumn FillSize = dgv.Columns[1];
        //    FillSize.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //    #endregion
        //}

        public frmRegistration()
        {
            InitializeComponent();
            //register.LoadDataTable();
        }

        private void btnNewStudent_Click(object sender, EventArgs e)
        {
           
            frmNewStudent newStud = new frmNewStudent();
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];

            mainwin.pnlAllContainer.Controls.Clear();
            mainwin.pnlAllContainer.Visible = true;

            newStud.TopLevel = false;
            newStud.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(newStud);
            newStud.Show();
        }
    }
}
