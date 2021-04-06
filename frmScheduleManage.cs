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
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            frmScheduleAdd add = new frmScheduleAdd();
            add.ShowDialog();
        }

        private void btnUpdateSchedule_Click(object sender, EventArgs e)
        {
            frmScheduleUpdate update = new frmScheduleUpdate();
            update.ShowDialog();
        }

        private void btnRemoveSchedule_Click(object sender, EventArgs e)
        {
            frmScheduleRemove remove = new frmScheduleRemove();
            remove.ShowDialog();
        }

        private void btnRespond_Click(object sender, EventArgs e)
        {
            frmRespond respond = new frmRespond();
            respond.ShowDialog();
        }
    }
}
