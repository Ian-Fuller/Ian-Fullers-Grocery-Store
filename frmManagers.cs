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
    public partial class frmManagers : Form
    {
        public frmManagers()
        {
            InitializeComponent();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            frmProductManage product = new frmProductManage();
            product.ShowDialog();
        }

        private void btnManageSpecials_Click(object sender, EventArgs e)
        {
            frmSpecialManage special = new frmSpecialManage();
            special.ShowDialog();
        }

        private void btnEmployeeScheduling_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintReports_Click(object sender, EventArgs e)
        {

        }
    }
}
