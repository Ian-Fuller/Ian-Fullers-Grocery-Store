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
    public partial class frmSpecialUpdate : Form
    {
        List<string> lstNames = new List<string>();
        List<int> lstDiscounts = new List<int>();

        public frmSpecialUpdate()
        {
            InitializeComponent();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSpecialUpdate_Load(object sender, EventArgs e)
        {
            for(int intCurrentSpecial = 0; intCurrentSpecial < frmMain.lstSpecials.Count; intCurrentSpecial++)
            {
                lstNames.Add(frmMain.lstSpecials[intCurrentSpecial].strProductName);
                lstDiscounts.Add(frmMain.lstSpecials[intCurrentSpecial].intDiscount);
                cbxSpecials.Items.Add(lstNames[intCurrentSpecial] + ", -" + lstDiscounts[intCurrentSpecial] + "%");
            }

            string[] arrColumns = new string[] { "Product", "PriceDiscounted", "ExtraDetails" };
            for (int intCurrentColumn = 0; intCurrentColumn < arrColumns.Length; intCurrentColumn++)
            {
                cbxColumnName.Items.Add(arrColumns[intCurrentColumn]);
            }

            for (int intCurrentPanel = 0; intCurrentPanel < frmMain.lstPanels.Count; intCurrentPanel++)
            {
                cbxProduct.Items.Add(frmMain.lstPanels[intCurrentPanel].strProductName);
            }
        }

        private void cbxColumnName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxColumnName.Text == "Product")
            {
                cbxProduct.Visible = true;
            }
            else
            {
                cbxProduct.Visible = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(cbxColumnName.Text == "Product")
            {
                DB.UpdateSpecial(lstNames[cbxSpecials.SelectedIndex], lstDiscounts[cbxSpecials.SelectedIndex], cbxColumnName.Text, cbxProduct.Text);
            }
            else
            {
                DB.UpdateSpecial(lstNames[cbxSpecials.SelectedIndex], lstDiscounts[cbxSpecials.SelectedIndex], cbxColumnName.Text, tbxNewValue.Text);
            }
        }
    }
}
