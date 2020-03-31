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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
           
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            f.ShowDialog();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmNewStudent frm = new frmNewStudent();           
            frm.ShowDialog();
            this.Dispose();
        }
    }
}
