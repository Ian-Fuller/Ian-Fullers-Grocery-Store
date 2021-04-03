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
            for(int intCurrentPanel = 0; intCurrentPanel < frmMain.lstPanels.Count; intCurrentPanel++)
            {
                cbxToRemove.Items.Add(frmMain.lstPanels[intCurrentPanel].strProductName);
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DB.RemoveProduct(cbxToRemove.Text);
        }
    }
}
