//Programmer: Ian Fuller
//Course: INEW 2332.10z1
//Program purpose: Application that will allow the user to make purchases from a grocery store

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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Instantiates 6 test panels
            ProductPanel panel1 = new ProductPanel(this, 20, 20, "Apples");
            ProductPanel panel2 = new ProductPanel(this, 140, 20, "Apples");
            ProductPanel panel3 = new ProductPanel(this, 260, 20, "Apples");

            ProductPanel panel4 = new ProductPanel(this, 20, 200, "Apples");
            ProductPanel panel5 = new ProductPanel(this, 140, 200, "Apples");
            ProductPanel panel6 = new ProductPanel(this, 260, 200, "Apples");
        }
    }

    public class ProductPanel
    {
        public Label lblProductName;
        PictureBox pbxProductImage;
        Button btnMoreInfo;
        Button btnAdd;

        public ProductPanel(Form frm, int panelLeft, int panelTop, string productName)
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
            frm.Controls.Add(lblProductName);

            //Image
            Bitmap tempBitmap = new Bitmap("PLACEHOLDER_IMAGE.png");
            pbxProductImage = new PictureBox();
            pbxProductImage.Image = (Image)tempBitmap;
            pbxProductImage.Left = panelLeft;
            pbxProductImage.Top = panelTop + 20;
            pbxProductImage.Width = 100;
            pbxProductImage.Height = 100;
            frm.Controls.Add(pbxProductImage);

            //More info button
            btnMoreInfo = new Button();
            btnMoreInfo.Text = "More Info";
            btnMoreInfo.Left = panelLeft;
            btnMoreInfo.Top = panelTop + 120;
            btnMoreInfo.Width = 100;
            btnMoreInfo.Height = 20;
            frm.Controls.Add(btnMoreInfo);

            //Add to Cart button
            btnAdd = new Button();
            btnAdd.Text = "Add to Cart";
            btnAdd.Left = panelLeft;
            btnAdd.Top = panelTop + 140;
            btnAdd.Width = 100;
            btnAdd.Height = 20;
            frm.Controls.Add(btnAdd);
        }
    }
}
