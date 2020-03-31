namespace CAEBS_V2
{
    partial class frmDiscount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiscount));
            this.dgvDiscount = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtDiscountName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.optPercent = new System.Windows.Forms.RadioButton();
            this.optAmount = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscount)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDiscount
            // 
            this.dgvDiscount.AllowUserToAddRows = false;
            this.dgvDiscount.AllowUserToDeleteRows = false;
            this.dgvDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDiscount.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiscount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiscount.Location = new System.Drawing.Point(346, 42);
            this.dgvDiscount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvDiscount.Name = "dgvDiscount";
            this.dgvDiscount.ReadOnly = true;
            this.dgvDiscount.RowHeadersVisible = false;
            this.dgvDiscount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiscount.Size = new System.Drawing.Size(773, 680);
            this.dgvDiscount.TabIndex = 7804;
            this.dgvDiscount.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiscount_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 36);
            this.button1.TabIndex = 7829;
            this.button1.Text = "&Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(121, 71);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(176, 23);
            this.txtValue.TabIndex = 7828;
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDiscountName
            // 
            this.txtDiscountName.Location = new System.Drawing.Point(121, 42);
            this.txtDiscountName.Name = "txtDiscountName";
            this.txtDiscountName.Size = new System.Drawing.Size(176, 23);
            this.txtDiscountName.TabIndex = 7827;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label3.Font = new System.Drawing.Font("Roboto Cn", 9.75F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(76, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 7826;
            this.label3.Text = "Value:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.optPercent);
            this.panel2.Controls.Add(this.optAmount);
            this.panel2.Location = new System.Drawing.Point(121, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 35);
            this.panel2.TabIndex = 7825;
            // 
            // optPercent
            // 
            this.optPercent.AutoSize = true;
            this.optPercent.Location = new System.Drawing.Point(91, 7);
            this.optPercent.Name = "optPercent";
            this.optPercent.Size = new System.Drawing.Size(82, 19);
            this.optPercent.TabIndex = 1;
            this.optPercent.TabStop = true;
            this.optPercent.Text = "Percentage";
            this.optPercent.UseVisualStyleBackColor = true;
            // 
            // optAmount
            // 
            this.optAmount.AutoSize = true;
            this.optAmount.Location = new System.Drawing.Point(8, 7);
            this.optAmount.Name = "optAmount";
            this.optAmount.Size = new System.Drawing.Size(64, 19);
            this.optAmount.TabIndex = 0;
            this.optAmount.TabStop = true;
            this.optAmount.Text = "Amount";
            this.optAmount.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(121, 173);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 36);
            this.btnAdd.TabIndex = 7824;
            this.btnAdd.Text = "&Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label4.Font = new System.Drawing.Font("Roboto Cn", 9.75F);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(26, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 7823;
            this.label4.Text = "Discount Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Roboto Cn", 9.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(71, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 7830;
            this.label1.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbStatus.Location = new System.Drawing.Point(121, 144);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(176, 23);
            this.cmbStatus.TabIndex = 7831;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1099, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7872;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 734);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtDiscountName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvDiscount);
            this.Font = new System.Drawing.Font("Roboto Cn", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discount";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscount)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDiscount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtDiscountName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton optPercent;
        private System.Windows.Forms.RadioButton optAmount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}