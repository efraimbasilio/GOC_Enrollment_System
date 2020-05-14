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
    public partial class frmOrderUniform : Form
    {
        private bool toSave;
        TransBookUnif transBUnif = new TransBookUnif();
        List<TransBookUnif> transBUnifs = new List<TransBookUnif>();

        Uniform uniform = new Uniform();
        List<Uniform> listUniform = new List<Uniform>();
        public string LRN;

        public frmOrderUniform()
        {
            InitializeComponent();
        }

        public void LoadUniform()
        {
            listUniform.Clear();
            dgvUniform.Rows.Clear();
            listUniform = uniform.Load();

            foreach (var item in listUniform)
            {
                dgvUniform.Rows.Add(item.Unif_code, item.Item_name, item.Price, "0", "--");
            }
        }

        public void UnifOrders()
        {
            TransUniform trans = new TransUniform();
            trans.TransUnif(dgvUniform, LRN);

            #region Header Name
            dgvUniform.Columns["item_name"].HeaderText = "Description";
            dgvUniform.Columns["price"].HeaderText = "Price";
            dgvUniform.Columns["unif_qty"].HeaderText = "Qty";
            dgvUniform.Columns["unif_size"].HeaderText = "Size";

            DataGridViewColumn toFill = dgvUniform.Columns[0];
            toFill.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //dgvUnif.Columns[0].Width = 100;
            dgvUniform.Columns[1].Width = 100;
            dgvUniform.Columns[2].Width = 100;
            dgvUniform.Columns[3].Width = 100;
            // dgvList.Columns[4].Width = 175;
            #endregion
        }
        private void ValidateSizeOrder()
        {
            for (int i = 0; i < dgvUniform.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvUniform.Rows[i].Cells[3].Value) > 0 && dgvUniform.Rows[i].Cells[4].Value.Equals("--"))
                {
                    string message = "Please specify the size of the order.";
                    string title = "Enrollment System";

                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                    dgvUniform.CurrentCell = dgvUniform.Rows[i].Cells[4];
                    toSave = false;
                    break;

                }
                else
                {
                    toSave = true;
                }
            }
        }
        private void bntSubmitOrder_Click(object sender, EventArgs e)
        {
           
            ValidateSizeOrder();

            if (toSave == true)
            {
                // util.ValidateTextBoxDP(txtDP);                

                for (int i = 0; i < dgvUniform.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgvUniform.Rows[i].Cells[3].Value) > 0)
                    {
                        transBUnif.LRN = LRN;
                        transBUnif.OR_no = "0000";
                        transBUnif.Unif_code = dgvUniform.Rows[i].Cells[0].Value.ToString();
                        transBUnif.Unif_qty = dgvUniform.Rows[i].Cells[3].Value.ToString();
                        transBUnif.Unif_size = dgvUniform.Rows[i].Cells[4].Value.ToString();

                        transBUnif.Save();
                    }
                }
                string message = "Record Save";
                string title = "Enrollment System";

                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }

            //UnifOrders();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
         
        }

        private void frmOrderUniform_Load(object sender, EventArgs e)
        {

        }

        private void frmOrderUniform_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void frmOrderUniform_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
