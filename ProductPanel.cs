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
        int intProductID;
        string strProductName;
        double dblPrice;
        string strSize;
        int intUnitsInStock;

        //Extra data for specials
        double dblDiscount;
        string strExtraDetails;

        //Panel Opbject
        Panel pnlParentPanel;
        Label lblProductName;
        PictureBox pbxProductImage;
        Button btnMoreInfo;
        Button btnAdd;

        public ProductPanel()
        {

        }
        public ProductPanel(int intProductID, string strProductName, double dblPrice, string strSize, int intUnitsInStock, byte[] arrImageBytes, int intLeft, int intTop, double dblDiscount, string strExtraDetails)
        {
            //Data
            this.intProductID = intProductID;
            this.strProductName = strProductName;
            this.dblPrice = dblPrice;
            this.strSize = strSize;
            this.intUnitsInStock = intUnitsInStock;
            this.dblDiscount = dblDiscount;
            this.strExtraDetails = strExtraDetails;

            //Parent Panel
            pnlParentPanel = new Panel();
            pnlParentPanel.Width = 100;
            pnlParentPanel.Height = 185;
            pnlParentPanel.Left = intLeft;
            pnlParentPanel.Top = intTop;

            //Label
            lblProductName = new Label();
            lblProductName.Text = strProductName + "\n$" + dblPrice;
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
            btnMoreInfo.Text = "More Info";
            btnMoreInfo.Width = 100;
            btnMoreInfo.Height = 20;
            btnMoreInfo.Top = 145;
            pnlParentPanel.Controls.Add(btnMoreInfo);

            //Add to Cart button
            btnAdd = new Button();
            btnAdd.Text = "Add to Cart";
            btnAdd.Width = 100;
            btnAdd.Height = 20;
            btnAdd.Top = 165;
            pnlParentPanel.Controls.Add(btnAdd);
        }

        public void SetPosition(int intLeft, int intTop)
        {
            pnlParentPanel.Left = intLeft;
            pnlParentPanel.Top = intTop;
        }

        public void ShowPanel(Form frmMain)
        {
            frmMain.Controls.Add(pnlParentPanel);
        }

        public void HidePanel(Form frmMain)
        {
            frmMain.Controls.Remove(pnlParentPanel);
        }
    }
}
