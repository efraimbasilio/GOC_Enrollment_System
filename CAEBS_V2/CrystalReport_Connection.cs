using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Windows.Forms;

namespace CAEBS_V2
{
    class CrystalReport_Connection
    {
        public static string DSN = null;
        public static string HOST = null;
        public static string database = null;
        public static string username = null;
        public static string password = null;

        private static CrystalReport_Connection instance = null;
        private static readonly object padlock = new object();

        public static CrystalReport_Connection Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CrystalReport_Connection();
                    }
                    return instance;
                }
            }
        }
        
        public void SetConnection(ref ReportDocument rpt)
        {
            // MessageBox.Show(DSN + " " + HOST + " " + database + " " + username + " " + password);
            try
            {
                //create connection info
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;

                //update connection string base on  database config
                crConnectionInfo.ServerName = DSN;
                crConnectionInfo.DatabaseName = database;
                crConnectionInfo.UserID = username;
                crConnectionInfo.Password = password;
                CrTables = rpt.Database.Tables;

                //CrTables = rpt.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }
            }

            catch (CrystalReportsException ex)
            {
                MessageBox.Show("Error: Cannot connect to server" + ex.Message.ToString(), "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
