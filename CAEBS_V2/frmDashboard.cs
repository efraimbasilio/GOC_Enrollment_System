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
    public partial class frmDashboard : Form
    {
        SY sy = new SY();
        List<SY> sy_list = new List<SY>();
        public frmDashboard()
        {
            InitializeComponent();
            Call_School_Year();
        }
        //#####################################################################################################################################################//
        public void Call_School_Year()
        {
            sy_list.Clear();
            sy_list = sy.Load();

            foreach (var item in sy_list)
            {
                lblStart.Text = item.Start;
                lblEnd.Text = item.End;
                lblSemester.Text = item.Semester;
                lblQuarter.Text = item.Quarter;

            }
        }

        //#####################################################################################################################################################//

        private void frmDashboard_Load(object sender, EventArgs e)
        {

        }

        private void frmDashboard_Resize(object sender, EventArgs e)
        {
            panel1.Left = (this.Width - panel1.Width) / 2;
        }
    }
}
