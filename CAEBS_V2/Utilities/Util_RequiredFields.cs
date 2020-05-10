using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAEBS_V2
{
    class Util_RequiredFields
    {

        public void DisableSort_DataGrid(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }           
        }

        #region For Validation

        public int readyToSave;
        public bool toSave;//validation Requirements

        public void ValidateCombobox(ComboBox one)
        {
            ComboBox[] newTextBox = { one };
            for (int inti = 0; inti < newTextBox.Length; inti++)
            {
                if (newTextBox[inti].Text == string.Empty)
                {
                    MessageBox.Show("Please fill the required drop down list");
                    newTextBox[inti].Focus();
                    return;
                }
                readyToSave = 1;
            }
        }

        public void ValidateCombobox1(ComboBox one)
        {
            ComboBox[] newTextBox = { one };
            for (int inti = 0; inti < newTextBox.Length; inti++)
            {
                if (newTextBox[inti].Text == string.Empty)
                {
                    MessageBox.Show("Please fill the required drop down list");
                    newTextBox[inti].Focus();
                    readyToSave = 0;
                    return;
                }
                readyToSave = 1;
            }
        }

        public void ValidateCombobox2(ComboBox one, ComboBox two)
        {
            ComboBox[] newTextBox = { one, two };
            for (int inti = 0; inti < newTextBox.Length; inti++)
            {
                if (newTextBox[inti].Text == string.Empty)
                {
                    MessageBox.Show("Please fill the required drop down list");
                    newTextBox[inti].Focus();
                    readyToSave = 0;
                    return;
                }
                readyToSave = 1;
            }
        }

        public void ValidateCombobox3(ComboBox one, ComboBox two, ComboBox three)
        {
            ComboBox[] newTextBox = { one, two, three };
            for (int inti = 0; inti < newTextBox.Length; inti++)
            {
                if (newTextBox[inti].Text == string.Empty)
                {
                    MessageBox.Show("Please fill the required drop down list");
                    newTextBox[inti].Focus();
                    readyToSave = 0;
                    return;
                }
                readyToSave = 1;
            }
        }

        public void ValidateCombobox5(ComboBox one, ComboBox two, ComboBox three, ComboBox four, ComboBox five)
        {
            ComboBox[] newTextBox = { one, two, three, four, five };
            for (int inti = 0; inti < newTextBox.Length; inti++)
            {
                if (newTextBox[inti].Text == string.Empty)
                {
                    MessageBox.Show("Please fill the required drop down list", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    newTextBox[inti].Focus();
                    readyToSave = 0;
                    return;
                }
                readyToSave = 1;
            }
        }

        public void ValidateTextBoxDP(TextBox one)
        {
            TextBox[] newTextBox = { one};
            for (int inti = 0; inti < newTextBox.Length; inti++)
            {
                if (newTextBox[inti].Text == string.Empty || Convert.ToDouble(newTextBox[inti].Text) < 1000 )
                {
                    MessageBox.Show("Downpayment is required,\nMinimun Downpayment is: 1,000 Pesos ", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    newTextBox[inti].Focus();

                    readyToSave = 0;
                    return;
                }
                readyToSave = 1;
            }
        }

        public void ValidateTextBox2(TextBox one, TextBox two)
        {
            TextBox[] newTextBox = { one, two };
            for (int inti = 0; inti < newTextBox.Length; inti++)
            {
                if (newTextBox[inti].Text == string.Empty)
                {
                    MessageBox.Show("Please fill the required Text");
                    newTextBox[inti].Focus();

                    readyToSave = 0;
                    return;
                }
                readyToSave = 1;
            }
        }

        public void ValidateTextBox3(TextBox one, TextBox two, TextBox third)
        {
            TextBox[] newTextBox = { one, two, third };
            for (int inti = 0; inti < newTextBox.Length; inti++)
            {
                if (newTextBox[inti].Text == string.Empty)
                {
                    MessageBox.Show("Please fill the required Text");
                    newTextBox[inti].Focus();

                    readyToSave = 0;
                    return;
                }
                readyToSave = 1;
            }
        }

        public void ValidateTextBox4(TextBox one, TextBox two, TextBox three, TextBox four)
        {
            TextBox[] newTextBox = { one, two, three, four };
            for (int inti = 0; inti < newTextBox.Length; inti++)
            {
                if (newTextBox[inti].Text == string.Empty)
                {
                    MessageBox.Show("Please fill the required Text");
                    newTextBox[inti].Focus();

                    readyToSave = 0;
                    return;
                }
                readyToSave = 1;
            }
        }

        //public void Validate_MOP(RadioButton one, RadioButton two)
        //{
        //    RadioButton[] newTextBox = { one, two};
        //    for (int inti = 0; inti < newTextBox.Length; inti++)
        //    {
        //        if (newTextBox[inti].Checked == false)
        //        {
        //            MessageBox.Show("ERROR : Please select the Mode of Payment.", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            newTextBox[inti].Focus();

        //            readyToSave = 0;
        //            return;
        //        }
        //        readyToSave = 1;
        //    }
        //}

        //public void checkKeypress(Form frm)
        //{
        //    foreach (Control c in frm) //this must be the container of the textboxes,(form,panel,groupbox)
        //    {
        //        if (c is TextBox)
        //        {
        //            c.KeyPress += new KeyPressEventHandler(textboxes_KeyPress);
        //        }
        //    }
        //}

        public void Validate_Pre_Elementary(CheckBox one)
        {
            CheckBox[] newTextBox = { one };
            for (int inti = 0; inti < newTextBox.Length; inti++)
            {
                if (newTextBox[inti].Checked == false)
                {
                    MessageBox.Show("REMINDER : For Pre Elementary Department /nPSA - Birth Certificate is Required.", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    newTextBox[inti].Focus();

                    readyToSave = 0;
                    return;
                }
                readyToSave = 1;
                toSave = true;
            }
        }

        public void Validate_Elementary(CheckBox one)
        {
            CheckBox[] newTextBox = { one };
            for (int inti = 0; inti < newTextBox.Length; inti++)
            {
                if (newTextBox[inti].Checked == false)
                {
                    MessageBox.Show("REMINDER : For Elementary Department /nFORM 138 / REPORT CARD is Required.", "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    newTextBox[inti].Focus();

                    readyToSave = 0;
                    return;
                }
                readyToSave = 1;
                toSave = true;
            }
        }

        public void ValidateTextBox8(TextBox one, TextBox two, TextBox three, TextBox four, TextBox five, TextBox six, TextBox seven, TextBox eight)
        {
            TextBox[] newTextBox = { one, two, three, four, five, six, seven, eight };
            for (int inti = 0; inti < newTextBox.Length; inti++)
            {
                if (newTextBox[inti].Text == string.Empty)
                {                 
                    MessageBox.Show("ERROR : Please fill the required fields." , "Enrollment System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    newTextBox[inti].Focus();

                    readyToSave = 0;
                    return;
                }
                readyToSave = 1;
            }
        }
        #endregion


        #region Datagrid Util
        public void AddImageDataGrid(DataGridView dgv)
        {
            DataGridViewImageColumn dimg = new DataGridViewImageColumn();
            dimg.Image = Properties.Resources.edit;
            dimg.HeaderText = "Edit";
            dimg.ImageLayout = DataGridViewImageCellLayout.Normal;
            dimg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns.Add(dimg);


            DataGridViewImageColumn dimgDelete = new DataGridViewImageColumn();
            dimgDelete.Image = Properties.Resources.delete;
            dimgDelete.HeaderText = "Delete";
            dimgDelete.ImageLayout = DataGridViewImageCellLayout.Normal;
            dimgDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns.Add(dimgDelete);
        }

        public void AssessOrBilling(DataGridView dgv)
        {
           
            DataGridViewImageColumn dimg = new DataGridViewImageColumn();
            dimg.Image = Properties.Resources.edit;
            dimg.HeaderText = "Assess";
            dimg.ImageLayout = DataGridViewImageCellLayout.Normal;
            dimg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns.Add(dimg);


            DataGridViewImageColumn dimgDelete = new DataGridViewImageColumn();
            dimgDelete.Image = Properties.Resources.delete;
            dimgDelete.HeaderText = "Billing";
            dimgDelete.ImageLayout = DataGridViewImageCellLayout.Normal;
            dimgDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns.Add(dimgDelete);

            DataGridViewImageColumn dimgEnroll = new DataGridViewImageColumn();
            dimgEnroll.Image = Properties.Resources.search;
            dimgEnroll.HeaderText = "Enroll";
            dimgEnroll.ImageLayout = DataGridViewImageCellLayout.Normal;
            dimgEnroll.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns.Add(dimgEnroll);
        }

        #endregion

        #region Call Form
        public void ShowForm(Form theForm)
        {       
                
            frmMain mainwin = (frmMain)Application.OpenForms["frmMain"];
            mainwin.pnlAllContainer.Controls.Clear();
            theForm.TopLevel = false;
            theForm.AutoScroll = true;
            mainwin.pnlAllContainer.Controls.Add(theForm);
            theForm.Show();
        }
        
        #endregion
    }
}
