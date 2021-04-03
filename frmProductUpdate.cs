using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP21_Final_Project
{
    public partial class frmProductUpdate : Form
    {
        string strFileName;

        public frmProductUpdate()
        {
            InitializeComponent();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.ValidateNames = true;
                openFile.AddExtension = false;
                openFile.Filter = "Image File|*.png|Image File|*.jpg";
                openFile.Title = "File to Upload";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    pbxProductImage.Image = new Bitmap(openFile.FileName);
                    strFileName = openFile.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Uploading Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(cbxColumnName.Text == "ProductImage")
            {
                DB.UpdateProduct(cbxColumnName.Text, strFileName, cbxProduct.Text);
            }
            else
            {
                DB.UpdateProduct(cbxColumnName.Text, tbxNewValue.Text, cbxProduct.Text);
            }
        }

        private void frmProductUpdate_Load(object sender, EventArgs e)
        {
            for (int intCurrentPanel = 0; intCurrentPanel < frmMain.lstPanels.Count; intCurrentPanel++)
            {
                cbxProduct.Items.Add(frmMain.lstPanels[intCurrentPanel].strProductName);
            }

            string[] arrColumns = new string[] { "ProductName", "Price", "Size", "UnitsInStock", "ProductImage" };
            for(int intCurrentColumn = 0; intCurrentColumn < arrColumns.Length; intCurrentColumn++)
            {
                cbxColumnName.Items.Add(arrColumns[intCurrentColumn]);
            }
        }

        private void cbxColumnName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxColumnName.Text == "ProductImage")
            {
                tbxNewValue.Visible = false;
                pbxProductImage.Visible = true;
                btnSelectImage.Visible = true;
            }
            else
            {
                tbxNewValue.Visible = true;
                pbxProductImage.Visible = false;
                btnSelectImage.Visible = false;
            }
        }
    }
}
