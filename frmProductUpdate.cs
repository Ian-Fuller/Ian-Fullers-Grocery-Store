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
                OpenFileDialog ofdImagePicker = new OpenFileDialog();
                ofdImagePicker.ValidateNames = true;
                ofdImagePicker.AddExtension = false;
                ofdImagePicker.Filter = "Image File|*.png|Image File|*.jpg";
                ofdImagePicker.Title = "File to Upload";

                if (ofdImagePicker.ShowDialog() == DialogResult.OK)
                {
                    pbxProductImage.Image = new Bitmap(ofdImagePicker.FileName);
                    strFileName = ofdImagePicker.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Uploading Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(cboColumnName.Text == "ProductImage")
                {
                    DB.UpdateProduct(cboColumnName.Text, strFileName, cboProduct.Text);
                }
                else
                {
                    DB.UpdateProduct(cboColumnName.Text, tbxNewValue.Text, cboProduct.Text);
                    frmMain.FillRefreshPanelData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmProductUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                MaximizeBox = false;

                //Fills first combo box with products from frmMain
                for (int intCurrentPanel = 0; intCurrentPanel < frmMain.lstPanels.Count; intCurrentPanel++)
                {
                    cboProduct.Items.Add(frmMain.lstPanels[intCurrentPanel].strProductName);
                }

                //Fills second combo box with the different columns that can be changed
                string[] arrColumns = new string[] { "ProductName", "Price", "Size", "UnitsInStock", "ProductImage" };
                for (int intCurrentColumn = 0; intCurrentColumn < arrColumns.Length; intCurrentColumn++)
                {
                    cboColumnName.Items.Add(arrColumns[intCurrentColumn]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxColumnName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Refreshes the input area based on what column is selected
                if (cboColumnName.Text == "ProductImage")
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

                if (cboColumnName.Text == "Price")
                {
                    lblTo.Text = "To: $";
                }
                else
                {
                    lblTo.Text = "To:";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing column", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUpdateProduct_Click(object sender, EventArgs e)
        {
            Help.HelpUpdateProduct();
        }
    }
}
