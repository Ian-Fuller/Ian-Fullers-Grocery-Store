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
    public partial class frmScheduleRemove : Form
    {
        List<string[]> lstEmployeeNames;
        string strStartWeek = "This Week";

        public frmScheduleRemove()
        {
            InitializeComponent();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleRemove_Load(object sender, EventArgs e)
        {
            lstEmployeeNames = DB.GetEmployeeNames();

            for (int intCurrentName = 0; intCurrentName < lstEmployeeNames.Count; intCurrentName++)
            {
                cbxEmployee.Items.Add(lstEmployeeNames[intCurrentName][0] + " " + lstEmployeeNames[intCurrentName][1]);
            }

            cbxWeek.Items.Add("This Week");
            cbxWeek.Items.Add("Next Week");
            cbxWeek.Items.Add("All Previous Weeks");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(cbxEmployee.Text != "" && cbxWeek != null)
            {
                DB.RemoveSchedule(lstEmployeeNames[cbxEmployee.SelectedIndex][0], lstEmployeeNames[cbxEmployee.SelectedIndex][1], cbxWeek.Text);
            }
            else
            {
                MessageBox.Show("One or more combo boxes is blank.", "Input Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
