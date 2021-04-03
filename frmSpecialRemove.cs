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
            DB.RemoveSpecial(lstNames[cbxToRemove.SelectedIndex], lstDiscounts[cbxToRemove.SelectedIndex]);
        }

        private void frmSpecialRemove_Load(object sender, EventArgs e)
        {
            for (int intCurrentSpecial = 0; intCurrentSpecial < frmMain.lstSpecials.Count; intCurrentSpecial++)
            {
                lstNames.Add(frmMain.lstSpecials[intCurrentSpecial].strProductName);
                lstDiscounts.Add(frmMain.lstSpecials[intCurrentSpecial].intDiscount);
                cbxToRemove.Items.Add(lstNames[intCurrentSpecial] + ", -" + lstDiscounts[intCurrentSpecial] + "%");
            }
        }
    }
}
