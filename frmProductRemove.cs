using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SP21_Final_Project
{
    public partial class frmProductRemove : Form
    {
        public frmProductRemove()
        {
            InitializeComponent();
        }

        private void frmProductRemove_Load(object sender, EventArgs e)
        {
            try
            {
                MaximizeBox = false;

                //Adds proucts of frmMain to the combo box
                for (int intCurrentPanel = 0; intCurrentPanel < frmMain.lstPanels.Count; intCurrentPanel++)
                {
                    cboToRemove.Items.Add(frmMain.lstPanels[intCurrentPanel].strProductName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot retrieve data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DB.RemoveProduct(cboToRemove.Text);
            frmMain.FillRefreshPanelData();

            //Refreshes combo box
            cboToRemove.Items.Clear();
            for (int intCurrentPanel = 0; intCurrentPanel < frmMain.lstPanels.Count; intCurrentPanel++)
            {
                cboToRemove.Items.Add(frmMain.lstPanels[intCurrentPanel].strProductName);
            }
        }

        private void mnuRemoveProduct_Click(object sender, EventArgs e)
        {
            Help.HelpRemoveProduct();
        }
    }
}
