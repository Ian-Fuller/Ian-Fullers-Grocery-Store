using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SP21_Final_Project
{
    public partial class frmProductAdd : Form
    {
        byte[] arrBytes;

        public frmProductAdd()
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
                    arrBytes = File.ReadAllBytes(ofdImagePicker.FileName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Uploading Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool bolNameValid = true;
                bool bolPriceValid = true;
                bool bolSizeValid = true;
                bool bolStockValid = true;
                bool bolHasImage = true;
                bool bolWholesaleValid = true;

                if (tbxName.Text == "" || tbxPrice.Text == "" || tbxSize.Text == "" || tbxStock.Text == "")
                {
                    MessageBox.Show("Please put data in all boxes.", "Error Adding Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (tbxName.Text.Length > 50)
                {
                    bolNameValid = false;
                    MessageBox.Show("Product name can only be 50 characters long.", "Error Adding Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (!Double.TryParse(tbxPrice.Text, out double dblPrice) && !tbxPrice.Text.Contains('-'))
                {
                    bolPriceValid = false;
                    MessageBox.Show("Product price must be a positive decimal value.", "Error Adding Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (tbxSize.Text.Length > 20)
                {
                    bolSizeValid = false;
                    MessageBox.Show("Product size can only be 20 characters long.", "Error Adding Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (!Int32.TryParse(tbxStock.Text, out int intStock))
                {
                    bolStockValid = false;
                    MessageBox.Show("Product units in stock must be an integer value.", "Error Adding Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (pbxProductImage == null)
                {
                    bolHasImage = false;
                    MessageBox.Show("Product must have an an image", "Error Adding Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (!Double.TryParse(tbxWholesalePrice.Text, out double dblWholesalePrice) && !tbxPrice.Text.Contains('-'))
                {
                    bolWholesaleValid = false;
                    MessageBox.Show("Wholesale price must be a positive decimal value.", "Error Adding Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (bolNameValid && bolPriceValid && bolSizeValid && bolStockValid && bolHasImage && bolWholesaleValid)
                {
                    DB.AddNewProduct(tbxName.Text, dblPrice, tbxSize.Text, intStock, arrBytes);
                    frmMain.FillRefreshPanelData();
                    PrintReport(DB.GenerateManagerPurchaseReceipt(tbxName.Text, intStock, dblPrice), "ManagerPurchaseReceipt.html");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintReport(StringBuilder html, string strFileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(strFileName))
                {
                    writer.WriteLine(html);
                }
                System.Diagnostics.Process.Start(@strFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("You don't have write permissions", "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DateTime today = DateTime.Now;
            using (StreamWriter wr = new StreamWriter($"{today.ToString("yyyy-MM-dd-HHmmss")} - " + strFileName))
            {
                wr.WriteLine(html);
            }
        }

        private void mnuAddProduct_Click(object sender, EventArgs e)
        {
            Help.HelpAddProduct();
        }

        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
