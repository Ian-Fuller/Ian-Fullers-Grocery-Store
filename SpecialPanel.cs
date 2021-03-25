using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SP21_Final_Project
{
    class SpecialPanel : ProductPanel
    {
        //Unique variables
        int intDiscount;
        string strExtraDetails;

        //Form objects
        Label lblDiscount;
        Label lblExtraDetails;

        public SpecialPanel()
        {

        }
        public SpecialPanel(int intProductID, string strProductName, double dblPrice, string strSize, int intUnitsInStock, byte[] arrImageBytes, int intLeft, int intTop, int intDiscount, string strExtraDetails) : base(intProductID, strProductName, dblPrice, strSize, intUnitsInStock, arrImageBytes, intLeft, intTop)
        {
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

        }

        public void ShowPanel(Panel pnlSpecials)
        {
            pnlSpecials.Controls.Add(pnlParentPanel);
        }

        public void HidePanel(Panel pnlSpecials)
        {
            pnlSpecials.Controls.Remove(pnlParentPanel);
        }
    }
}
