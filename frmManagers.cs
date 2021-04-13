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
            try
            {
                frmProductManage product = new frmProductManage();
                product.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManageSpecials_Click(object sender, EventArgs e)
        {
            try
            {
                frmSpecialManage special = new frmSpecialManage();
                special.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEmployeeScheduling_Click(object sender, EventArgs e)
        {
            try
            {
                frmScheduleManage schedule = new frmScheduleManage();
                schedule.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintReports_Click(object sender, EventArgs e)
        {
            try
            {
                frmReports reports = new frmReports();
                reports.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuManagersMenu_Click(object sender, EventArgs e)
        {
            Help.HelpManagersMenu();
        }

        private void frmManagers_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
