namespace CAEBS_V2
{
    partial class frmReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MyReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // MyReportViewer
            // 
            this.MyReportViewer.ActiveViewIndex = -1;
            this.MyReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MyReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.MyReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyReportViewer.Location = new System.Drawing.Point(0, 0);
            this.MyReportViewer.Name = "MyReportViewer";
            this.MyReportViewer.Size = new System.Drawing.Size(1133, 716);
            this.MyReportViewer.TabIndex = 0;
            this.MyReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 716);
            this.Controls.Add(this.MyReportViewer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReports";
            this.Text = "frmReports";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer MyReportViewer;
    }
}