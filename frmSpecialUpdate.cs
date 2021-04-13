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
            try
            {
                MaximizeBox = false;

                for (int intCurrentSpecial = 0; intCurrentSpecial < frmMain.lstSpecials.Count; intCurrentSpecial++)
                {
                    lstNames.Add(frmMain.lstSpecials[intCurrentSpecial].strProductName);
                    lstDiscounts.Add(frmMain.lstSpecials[intCurrentSpecial].intDiscount);
                    cboSpecials.Items.Add(lstNames[intCurrentSpecial] + ", -" + lstDiscounts[intCurrentSpecial] + "%");
                }

                string[] arrColumns = new string[] { "Product", "PriceDiscounted", "ExtraDetails" };
                for (int intCurrentColumn = 0; intCurrentColumn < arrColumns.Length; intCurrentColumn++)
                {
                    cboColumnName.Items.Add(arrColumns[intCurrentColumn]);
                }

                for (int intCurrentPanel = 0; intCurrentPanel < frmMain.lstPanels.Count; intCurrentPanel++)
                {
                    cboProduct.Items.Add(frmMain.lstPanels[intCurrentPanel].strProductName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxColumnName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboColumnName.Text == "Product")
                {
                    cboProduct.Visible = true;
                }
                else
                {
                    cboProduct.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboColumnName.Text == "Product")
                {
                    DB.UpdateSpecial(lstNames[cboSpecials.SelectedIndex], lstDiscounts[cboSpecials.SelectedIndex], cboColumnName.Text, cboProduct.Text);
                    frmMain.FillRefreshPanelData();
                }
                else
                {
                    DB.UpdateSpecial(lstNames[cboSpecials.SelectedIndex], lstDiscounts[cboSpecials.SelectedIndex], cboColumnName.Text, tbxNewValue.Text);
                    frmMain.FillRefreshPanelData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUpdateSpecial_Click(object sender, EventArgs e)
        {
            Help.HelpUpdateSpecial();
        }
    }
}
