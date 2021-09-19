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
            try
            {
                frmProductAdd add = new frmProductAdd();
                add.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to open form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            try
            {
                frmProductRemove remove = new frmProductRemove();
                remove.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                frmProductUpdate update = new frmProductUpdate();
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

        private void frmProductManage_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;

            FormCloser.lstOpenedForms.Add(this);
        }

        private void mnuReturn_Click(object sender, EventArgs e)
        {
            FormCloser.returnToMain();
        }
    }
}
