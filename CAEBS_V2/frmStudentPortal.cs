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
    public partial class frmStudentPortal : Form
    {
        public frmStudentPortal()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmNewStudent frm = new frmNewStudent();
            frm.pnlRequirements.Visible = false;
            frm.optOldStudent.Enabled = false;
            frm.optTransferee.Enabled = false;
            this.Dispose();
            frm.ShowDialog();
                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNewStudent frm = new frmNewStudent();
            frm.pnlRequirements.Visible = false;
            frm.optOldStudent.Enabled = true;
            frm.optOldStudent.Checked = true;
            frm.optTransferee.Enabled = false;
            frm.optNewStudent.Enabled = false;
            this.Dispose();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmNewStudent frm = new frmNewStudent();
            frm.pnlRequirements.Visible = false;
            frm.optOldStudent.Enabled = false;
            frm.optTransferee.Enabled = true;
            frm.optTransferee.Checked = true;
            frm.optNewStudent.Enabled = false;
            this.Dispose();
            frm.ShowDialog();
        }
    }
}
