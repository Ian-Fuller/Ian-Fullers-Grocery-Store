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
            try
            {
                frmSpecialAdd add = new frmSpecialAdd();
                add.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveSpecial_Click(object sender, EventArgs e)
        {
            try
            {
                frmSpecialRemove remove = new frmSpecialRemove();
                remove.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateSpecial_Click(object sender, EventArgs e)
        {
            try
            {
                frmSpecialUpdate update = new frmSpecialUpdate();
                update.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSpecialManage_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
