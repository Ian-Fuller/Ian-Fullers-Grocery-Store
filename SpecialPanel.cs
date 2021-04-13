using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SP21_Final_Project
{
    public class SpecialPanel : ProductPanel
    {
        //Unique variables
        public int intDiscount;
        string strExtraDetails;

        //Form objects
        Label lblDiscount;
        Label lblExtraDetails;

        public SpecialPanel()
        {

        }
        public SpecialPanel(int intProductID, string strProductName, double dblPrice, string strSize, int intUnitsInStock, byte[] arrImageBytes, int intLeft, int intTop, int intDiscount, string strExtraDetails) : base(intProductID, strProductName, dblPrice, strSize, intUnitsInStock, arrImageBytes, intLeft, intTop)
        {
            strType = "Special";

            this.intDiscount = intDiscount;
            this.strExtraDetails = strExtraDetails;

            pnlParentPanel.Width = 212;

            lblDiscount = new Label();
            lblDiscount.Text = "-" + intDiscount + "%";
            lblDiscount.Font = new Font("Microsoft Sans Serif", 30);
            lblDiscount.ForeColor = Color.LightGreen;
            lblDiscount.Width = 112;
            lblDiscount.Height = 45;
            lblDiscount.Left = 100;
            pnlParentPanel.Controls.Add(lblDiscount);

            lblExtraDetails = new Label();
            lblExtraDetails.Text = strExtraDetails;
            lblExtraDetails.Width = 112;
            lblExtraDetails.Height = 100;
            lblExtraDetails.Left = 100;
            lblExtraDetails.Top = 45;
            pnlParentPanel.Controls.Add(lblExtraDetails);

            btnMoreInfo.Click -= new EventHandler(btnMoreInfo_Click);
            btnMoreInfo.Click += new EventHandler(btnMoreInfo_ClickSpecial);
        }

        //Overrides ShowPanel to use a panel as the paramater
        public void ShowPanel(Panel pnlParent)
        {
            pnlParent.Controls.Add(pnlParentPanel);
        }
        //Overrides HidePanel to use a panel as the paramater
        public void HidePanel(Panel pnlParent)
        {
            pnlParent.Controls.Remove(pnlParentPanel);
        }
        //Overrides the other function to add extra info to it
        void btnMoreInfo_ClickSpecial(object sender, EventArgs e)
        {
            frmMoreInfo moreInfo = new frmMoreInfo(pbxProductImage.Image,
                                                   "ID: " + intProductID + "\n" +
                                                   "Name: " + strProductName + "\n" +
                                                   "Price per unit: $" + dblPrice + " -" + intDiscount + "% ($" + Math.Round(dblPrice * (1f - (double)intDiscount / 100f), 2) + ")\n" +
                                                   "Unit size: " + strSize + "\n" +
                                                   "Units in stock: " + intUnitsInStock + "\n" +
                                                   "Extra details: " + strExtraDetails);
            moreInfo.ShowDialog();
        }
        //Returns discount
        public override int GetDiscount()
        {
            return intDiscount;
        }

        public void RemoveFromParent(Panel pnlSpecialsPanel)
        {
            pnlSpecialsPanel.Controls.Remove(pnlParentPanel);
        }
    }
}
