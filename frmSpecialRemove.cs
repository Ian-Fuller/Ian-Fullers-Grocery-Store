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
    public partial class frmSpecialRemove : Form
    {
        List<string> lstNames = new List<string>();
        List<int> lstDiscounts = new List<int>();

        public frmSpecialRemove()
        {
            InitializeComponent();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DB.RemoveSpecial(lstNames[cboToRemove.SelectedIndex], lstDiscounts[cboToRemove.SelectedIndex]);
            frmMain.FillRefreshPanelData();

            //Refreshes combo box
            lstNames.Clear();
            lstDiscounts.Clear();
            cboToRemove.Items.Clear();
            for (int intCurrentSpecial = 0; intCurrentSpecial < frmMain.lstSpecials.Count; intCurrentSpecial++)
            {
                lstNames.Add(frmMain.lstSpecials[intCurrentSpecial].strProductName);
                lstDiscounts.Add(frmMain.lstSpecials[intCurrentSpecial].intDiscount);
                cboToRemove.Items.Add(lstNames[intCurrentSpecial] + ", -" + lstDiscounts[intCurrentSpecial] + "%");
            }

            cboToRemove.Text = lstNames[0] + ", -" + lstDiscounts[0] + "%";
        }

        private void frmSpecialRemove_Load(object sender, EventArgs e)
        {
            try
            {
                FormCloser.lstOpenedForms.Add(this);

                MaximizeBox = false;

                //Fills the combo box with the current specials
                for (int intCurrentSpecial = 0; intCurrentSpecial < frmMain.lstSpecials.Count; intCurrentSpecial++)
                {
                    lstNames.Add(frmMain.lstSpecials[intCurrentSpecial].strProductName);
                    lstDiscounts.Add(frmMain.lstSpecials[intCurrentSpecial].intDiscount);
                    cboToRemove.Items.Add(lstNames[intCurrentSpecial] + ", -" + lstDiscounts[intCurrentSpecial] + "%");
                }

                cboToRemove.Text = lstNames[0] + ", -" + lstDiscounts[0] + "%";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuRemoveSpecial_Click(object sender, EventArgs e)
        {
            Help.HelpRemoveSpecial();
        }

        private void mnuReturn_Click(object sender, EventArgs e)
        {
            FormCloser.returnToMain();
        }
    }
}
