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
    public partial class frmScheduleAdd : Form
    {
        List<string[]> lstEmployeeNames;

        public frmScheduleAdd()
        {
            InitializeComponent();
        }

        private void frmScheduleAdd_Load(object sender, EventArgs e)
        {
            lstEmployeeNames = DB.GetEmployeeNames();

            for(int intCurrentName = 0; intCurrentName < lstEmployeeNames.Count; intCurrentName++)
            {
                cbxEmployee.Items.Add(lstEmployeeNames[intCurrentName][0] + " " + lstEmployeeNames[intCurrentName][1]);
            }

            cbxWeek.Items.Add("This Week");
            cbxWeek.Items.Add("Next Week");
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateSchedule_Click(object sender, EventArgs e)
        {
            if(cbxEmployee.Text != "" && tbxSunday.Text != "" && tbxMonday.Text != "" && tbxTuesday.Text != "" && tbxWednesday.Text != "" && tbxThursday.Text != "" && tbxFriday.Text != "" && tbxSaturday.Text != "" && cbxWeek.Text != "")
            {
                if(tbxSunday.Text.Length <= 100 && tbxMonday.Text.Length <= 100 && tbxTuesday.Text.Length <= 100 && tbxWednesday.Text.Length <= 100 && tbxThursday.Text.Length <= 100 && tbxFriday.Text.Length <= 100 && tbxSaturday.Text.Length <= 100)
                {
                    DB.AddSchedule(lstEmployeeNames[cbxEmployee.SelectedIndex][0], lstEmployeeNames[cbxEmployee.SelectedIndex][1], tbxSunday.Text, tbxMonday.Text, tbxTuesday.Text, tbxWednesday.Text, tbxThursday.Text, tbxFriday.Text, tbxSaturday.Text, cbxWeek.Text);
                }
                else
                {
                    MessageBox.Show("Tasks for each day of the week can only be 100 characters long.", "Input invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("A text box or combo box was left blank", "Input invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
