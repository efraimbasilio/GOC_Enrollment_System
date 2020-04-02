using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmReports : Form
    {
        public void Credential()
        {
            CrystalReport_Connection.HOST = CAEBS_V2.Config.DB_HOST;
            CrystalReport_Connection.DSN = CAEBS_V2.Config.DSN;
            CrystalReport_Connection.database = CAEBS_V2.Config.DB_NAME;
            CrystalReport_Connection.username = CAEBS_V2.Config.DB_USER;
            CrystalReport_Connection.password = CAEBS_V2.Config.DB_PASSWORD;
        }

        public frmReports()
        {
            InitializeComponent();
        }

        #region Registration Form Report
        public string LRN { get; set; }

        public void PrintRegForm()
        {
            //Report Connection
            Credential();
            ReportDocument reportData = new ReportDocument();
            reportData.Load(Application.StartupPath + "/rptAssesment.rpt");

            CrystalReport_Connection.Instance.SetConnection(ref reportData);
            //Report Parameter
            reportData.SetParameterValue("LRN", LRN);           
           
            MyReportViewer.ReportSource = reportData;
            MyReportViewer.Refresh();
        }
        #endregion



    }
}
