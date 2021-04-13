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
    public partial class frmScheduleManage : Form
    {
        public frmScheduleManage()
        {
            InitializeComponent();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSheduleManage_Load(object sender, EventArgs e)
        {
            DB.GetRequests(dgvSchedules);

            MaximizeBox = false;
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                frmScheduleAdd add = new frmScheduleAdd();
                add.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                frmScheduleUpdate update = new frmScheduleUpdate();
                update.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                frmScheduleRemove remove = new frmScheduleRemove();
                remove.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRespond_Click(object sender, EventArgs e)
        {
            try
            {
                frmRespond respond = new frmRespond();
                respond.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuManageSchedules_Click(object sender, EventArgs e)
        {
            Help.HelpScheduleManage();
        }
    }
}
