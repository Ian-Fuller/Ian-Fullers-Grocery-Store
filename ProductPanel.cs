using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SP21_Final_Project
{
    public class ProductPanel
    {
        public Label lblProductName;
        PictureBox pbxProductImage;
        Button btnMoreInfo;
        Button btnAdd;

        public ProductPanel(Form frmMain, int panelLeft, int panelTop, string productName)
        {
            //Label
            lblProductName = new Label();
            lblProductName.Text = productName;
            lblProductName.Left = panelLeft;
            lblProductName.Top = panelTop;
            lblProductName.Width = 100;
            lblProductName.Height = 20;
            lblProductName.BackColor = Color.White;
            lblProductName.BorderStyle = BorderStyle.FixedSingle;
            frmMain.Controls.Add(lblProductName);

            //Image
            Bitmap tempBitmap = new Bitmap("PLACEHOLDER_IMAGE.png");
            pbxProductImage = new PictureBox();
            pbxProductImage.Image = (Image)tempBitmap;
            pbxProductImage.Left = panelLeft;
            pbxProductImage.Top = panelTop + 20;
            pbxProductImage.Width = 100;
            pbxProductImage.Height = 100;
            frmMain.Controls.Add(pbxProductImage);

            //More info button
            btnMoreInfo = new Button();
            btnMoreInfo.Text = "More Info";
            btnMoreInfo.Left = panelLeft;
            btnMoreInfo.Top = panelTop + 120;
            btnMoreInfo.Width = 100;
            btnMoreInfo.Height = 20;
            frmMain.Controls.Add(btnMoreInfo);

            //Add to Cart button
            btnAdd = new Button();
            btnAdd.Text = "Add to Cart";
            btnAdd.Left = panelLeft;
            btnAdd.Top = panelTop + 140;
            btnAdd.Width = 100;
            btnAdd.Height = 20;
            frmMain.Controls.Add(btnAdd);
        }
    }
}
