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
    public partial class frmSpecialManage : Form
    {
        public frmSpecialManage()
        {
            InitializeComponent();
        }

        private void btnAddNewSpecial_Click(object sender, EventArgs e)
        {
            frmSpecialAdd add = new frmSpecialAdd();
            add.ShowDialog();
        }

        private void btnRemoveSpecial_Click(object sender, EventArgs e)
        {
            frmSpecialRemove remove = new frmSpecialRemove();
            remove.ShowDialog();
        }

        private void btnUpdateSpecial_Click(object sender, EventArgs e)
        {
            frmSpecialUpdate update = new frmSpecialUpdate();
            update.ShowDialog();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
