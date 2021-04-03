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
    public partial class frmProductManage : Form
    {
        public frmProductManage()
        {
            InitializeComponent();
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            frmProductAdd add = new frmProductAdd();
            add.ShowDialog();
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            frmProductRemove remove = new frmProductRemove();
            remove.ShowDialog();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            frmProductUpdate update = new frmProductUpdate();
            update.ShowDialog();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
