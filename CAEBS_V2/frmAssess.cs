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
    public partial class frmAssess : Form
    {
        public string LRN, StudNo, FName, LName, MName, GLevel, Section, Strand;
        public int id;
        Register register = new Register();
        List<Register> ListRegister = new List<Register>();
       
       public void ToAssess()
        {
            lblLRN.Text = LRN;
            lblStudNo.Text = StudNo;
            lblFullName.Text = LName + ". " + FName + " " + MName;
            lblGLevel.Text = GLevel;
            lblSection.Text = Section;
            lblStrand.Text = Strand;
        }

        public frmAssess()
        {
            InitializeComponent();
        }


        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
