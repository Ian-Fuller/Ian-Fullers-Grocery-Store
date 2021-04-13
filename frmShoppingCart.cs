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
    public partial class frmShoppingCart : Form
    {
        public static List<ProductPanel> lstCart = new List<ProductPanel>();
        public static List<int> lstQuantities = new List<int>();

        public frmShoppingCart()
        {
            InitializeComponent();
        }

        private void frmShoppingCart_Load(object sender, EventArgs e)
        {
            try
            {
                MaximizeBox = false;

                if (lstCart.Count > 0)
                {
                    for (int intCurrentItem = 0; intCurrentItem < lstCart.Count; intCurrentItem++)
                    {
                        lbxItemsInCart.Items.Add(lstCart[intCurrentItem].strProductName + " x" + lstQuantities[intCurrentItem]);
                    }

                    pbxProductImage.Image = lstCart[0].pbxProductImage.Image;
                    lblProductName.Text = lstCart[0].strProductName;
                    lblProductPrice.Text = ProductPanel.FormatCurrency(lstCart[0].dblPrice);
                    lblAmountOrdered.Text = "x" + lstQuantities[0];
                    if (lstCart[0].GetDiscount() > 0)
                    {
                        lblDiscount.Text = "-" + lstCart[0].GetDiscount() + "%";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading shopping cart", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbxItemsInCart.SelectedIndex >= 0)
                {
                    lstCart.RemoveAt(lbxItemsInCart.SelectedIndex);
                    lstQuantities.RemoveAt(lbxItemsInCart.SelectedIndex);
                    lbxItemsInCart.Items.RemoveAt(lbxItemsInCart.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("Select an item in the list before removing.", "Select an Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbxItemsInCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbxItemsInCart.SelectedIndex >= 0)
                {
                    pbxProductImage.Image = lstCart[lbxItemsInCart.SelectedIndex].pbxProductImage.Image;
                    lblProductName.Text = lstCart[lbxItemsInCart.SelectedIndex].strProductName;
                    lblProductPrice.Text = ProductPanel.FormatCurrency(lstCart[lbxItemsInCart.SelectedIndex].dblPrice);
                    lblAmountOrdered.Text = "x" + lstQuantities[lbxItemsInCart.SelectedIndex];
                    if (lstCart[lbxItemsInCart.SelectedIndex].GetDiscount() > 0)
                    {
                        lblDiscount.Text = "-" + lstCart[lbxItemsInCart.SelectedIndex].GetDiscount() + "%";
                    }
                    else
                    {
                        lblDiscount.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxCity.Text.Length <= 100 && tbxAddress.Text.Length <= 100)
                {
                    if (DB.ReduceProductQuantity(lstCart, lstQuantities))
                    {
                        DB.CreateInvoice(tbxCity.Text, tbxAddress.Text, lstCart, lstQuantities);

                        MessageBox.Show("Purchase successful.", "Purchase", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("City and address can only be 100 characters long.", "Error Making Purchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error making purchase", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuShoppingCart_Click(object sender, EventArgs e)
        {
            Help.HelpShoppingCart();
        }
    }
}
