using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace SP21_Final_Project
{
    public class ProductPanel
    {
        //Product Data
        public int intProductID;
        public string strProductName;
        public double dblPrice;
        public string strSize;
        public int intUnitsInStock;

        //Panel Object
        public string strType;
        public Panel pnlParentPanel;
        Label lblProductName;
        public PictureBox pbxProductImage;
        public Button btnMoreInfo;
        public Button btnAdd;

        public ProductPanel()
        {

        }
        public ProductPanel(int intProductID, string strProductName, double dblPrice, string strSize, int intUnitsInStock, byte[] arrImageBytes, int intLeft, int intTop)
        {
            strType = "Regular";

            //Data
            this.intProductID = intProductID;
            this.strProductName = strProductName;
            this.dblPrice = dblPrice;
            this.strSize = strSize;
            this.intUnitsInStock = intUnitsInStock;

            //Parent Panel
            pnlParentPanel = new Panel();
            pnlParentPanel.Width = 100;
            pnlParentPanel.Height = 185;
            pnlParentPanel.Left = intLeft;
            pnlParentPanel.Top = intTop;

            //Label
            lblProductName = new Label();
            lblProductName.Text = strProductName + "\n" + FormatCurrency(dblPrice);
            lblProductName.Width = 100;
            lblProductName.Height = 45;
            lblProductName.BackColor = Color.White;
            lblProductName.BorderStyle = BorderStyle.FixedSingle;
            pnlParentPanel.Controls.Add(lblProductName);

            //Image
            try
            {
                pbxProductImage = new PictureBox();
                MemoryStream ms = new MemoryStream(arrImageBytes);
                Image imgProductImage = Image.FromStream(ms);
                pbxProductImage.Image = imgProductImage;
                pbxProductImage.Width = 100;
                pbxProductImage.Height = 100;
                pbxProductImage.Top = 45;
                pnlParentPanel.Controls.Add(pbxProductImage);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //More info button
            btnMoreInfo = new Button();
            btnMoreInfo.Text = "&More Info";
            btnMoreInfo.Width = 100;
            btnMoreInfo.Height = 20;
            btnMoreInfo.Top = 145;
            btnMoreInfo.Click += new EventHandler(btnMoreInfo_Click);
            pnlParentPanel.Controls.Add(btnMoreInfo);

            //Add to Cart button
            btnAdd = new Button();
            btnAdd.Text = "&Add to Cart";
            btnAdd.Width = 100;
            btnAdd.Height = 20;
            btnAdd.Top = 165;
            btnAdd.Click += new EventHandler(btnAdd_Click);
            pnlParentPanel.Controls.Add(btnAdd);
        }

        //Sets the left and top position of the panel
        public void SetPosition(int intLeft, int intTop)
        {
            pnlParentPanel.Left = intLeft;
            pnlParentPanel.Top = intTop;
        }
        //Adds the panels to the parent
        public void ShowPanel(Form frmParentForm)
        {
            frmParentForm.Controls.Add(pnlParentPanel);
        }
        //Removes the panels from the parent
        public void HidePanel(Form frmParentForm)
        {
            frmParentForm.Controls.Remove(pnlParentPanel);
        }
        //Creates a new frmMoreInfo based on the panel's information and hidden information
        public void btnMoreInfo_Click(object sender, EventArgs e)
        {
            frmMoreInfo moreInfo = new frmMoreInfo(pbxProductImage.Image,
                                                   "ID: " + intProductID + "\n" +
                                                   "Name: " + strProductName + "\n" +
                                                   "Price per unit: $" + dblPrice + "\n" +
                                                   "Unit size: " + strSize + "\n" +
                                                   "Units in stock: " + intUnitsInStock);
            moreInfo.ShowDialog();
        }
        //Adds the product to the cart
        public void btnAdd_Click(object sender, EventArgs e)
        {
            bool inCart = false;

            for(int intCurrentItem = 0; intCurrentItem < frmShoppingCart.lstCart.Count; intCurrentItem++)
            {
                if(this.strProductName == frmShoppingCart.lstCart[intCurrentItem].strProductName && this.GetDiscount() == frmShoppingCart.lstCart[intCurrentItem].GetDiscount())
                {
                    frmShoppingCart.lstQuantities[intCurrentItem]++;
                    inCart = true;
                }
            }

            if(!inCart)
            {
                frmShoppingCart.lstCart.Add(this);
                frmShoppingCart.lstQuantities.Add(1);
            }
        }
        //This is more important for the SpecialPanel class, but I am inexperienced with polymorphism in C#
        public virtual int GetDiscount()
        {
            return 0;
        }
        //Removes the buttons in case the product only needs to be shown
        public void SetButtonVisibility(bool bolOnOff)
        {
            btnAdd.Visible = bolOnOff;
            btnMoreInfo.Visible = bolOnOff;
        }
        //Like the hide panel function, but gets rid of the panel
        public void RemoveFromParent(Form frmParentForm)
        {
            frmParentForm.Controls.Remove(pnlParentPanel);
        }
        //Formats currency to $X.XX
        public static string FormatCurrency(double dblPrice)
        {
            try
            {
                string strPrice = "$" + dblPrice.ToString();
                string[] arrHalves = strPrice.Split('.');
                if (arrHalves[1].Length < 2)
                {
                    strPrice += "0";
                }
                return strPrice;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error formatting currency", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "$X.XX";
            }
        }
    }
}
