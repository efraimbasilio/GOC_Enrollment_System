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
    public partial class frmMaintenance : Form
    {
        public frmMaintenance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNewMiscFee f = new frmNewMiscFee();           
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
            mainwin.pnlAllContainer.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(f);
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmDiscount f = new frmDiscount();           
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
            mainwin.pnlAllContainer.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(f);
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmOtherFee f = new frmOtherFee();
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
            mainwin.pnlAllContainer.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(f);
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {            
            frmRoom room = new frmRoom();          
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
            mainwin.pnlAllContainer.Controls.Clear();
            room.TopLevel = false;
            room.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(room);
            room.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
            mainwin.pnlAllContainer.Controls.Clear();
            frmTeacher frm = new frmTeacher();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(frm);
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmSchoolYear frm = new frmSchoolYear();
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
            mainwin.pnlAllContainer.Controls.Clear();           
            frm.TopLevel = false;
            frm.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(frm);
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmTuition frm = new frmTuition();
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
            mainwin.pnlAllContainer.Controls.Clear();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(frm);
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSection frm = new frmSection();
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
            mainwin.pnlAllContainer.Controls.Clear();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(frm);
            frm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            frmGradeLevel frm = new frmGradeLevel();
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
            mainwin.pnlAllContainer.Controls.Clear();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(frm);
            frm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            frmDownpayments frm = new frmDownpayments();
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
            mainwin.pnlAllContainer.Controls.Clear();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(frm);
            frm.Show();
        }
    }
}
