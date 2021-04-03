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
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.ValidateNames = true;
                openFile.AddExtension = false;
                openFile.Filter = "Image File|*.png|Image File|*.jpg";
                openFile.Title = "File to Upload";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    pbxProductImage.Image = new Bitmap(openFile.FileName);
                    arrBytes = File.ReadAllBytes(openFile.FileName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Uploading Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool bolNameValid = true;
            bool bolPriceValid = true;
            bool bolSizeValid = true;
            bool bolStockValid = true;
            bool bolHasImage = true;

            if(tbxName.Text == "" || tbxPrice.Text == "" || tbxSize.Text =="" || tbxStock.Text == "")
            {
                MessageBox.Show("Please put data in all boxes.", "Error Adding Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(tbxName.Text.Length > 50)
            {
                bolNameValid = false;
                MessageBox.Show("Product name can only be 50 characters long.", "Error Adding Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(!Double.TryParse(tbxPrice.Text, out double dblPrice))
            {
                bolPriceValid = false;
                MessageBox.Show("Product price must be a decimal value.", "Error Adding Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (bolNameValid && bolPriceValid && bolSizeValid && bolStockValid && bolHasImage)
            {
                DB.AddNewProduct(tbxName.Text, dblPrice, tbxSize.Text, intStock, arrBytes);
            }
        }
    }
}
