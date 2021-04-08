﻿using System;
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
    public partial class frmScheduleUpdate : Form
    {
        List<string[]> lstEmployeeNames;
        string strStartWeek = "This Week";

        public frmScheduleUpdate()
        {
            InitializeComponent();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleUpdate_Load(object sender, EventArgs e)
        {
            lstEmployeeNames = DB.GetEmployeeNames();

            for (int intCurrentName = 0; intCurrentName < lstEmployeeNames.Count; intCurrentName++)
            {
                cbxEmployee.Items.Add(lstEmployeeNames[intCurrentName][0] + " " + lstEmployeeNames[intCurrentName][1]);
            }

            cbxWeek.Items.Add("This Week");
            cbxWeek.Items.Add("Next Week");
            cbxWeek.Items.Add("Previous Week");
            cbxWeek.Text = "This Week";
        }

        private void cbxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] arrTasks = DB.GetEmployeeTasks(lstEmployeeNames[cbxEmployee.SelectedIndex][0], lstEmployeeNames[cbxEmployee.SelectedIndex][1], strStartWeek);
            if (arrTasks != null)
            {
                btnUpdateSchedule.Enabled = true;
                tbxSunday.Text = arrTasks[0];
                tbxMonday.Text = arrTasks[1];
                tbxTuesday.Text = arrTasks[2];
                tbxWednesday.Text = arrTasks[3];
                tbxThursday.Text = arrTasks[4];
                tbxFriday.Text = arrTasks[5];
                tbxSaturday.Text = arrTasks[6];
            }
            else
            {
                btnUpdateSchedule.Enabled = false;
                tbxSunday.Text = "";
                tbxMonday.Text = "";
                tbxTuesday.Text = "";
                tbxWednesday.Text = "";
                tbxThursday.Text = "";
                tbxFriday.Text = "";
                tbxSaturday.Text = "";
            }
        }

        private void btnUpdateSchedule_Click(object sender, EventArgs e)
        {
            if (cbxEmployee.Text != "" && tbxSunday.Text != "" && tbxMonday.Text != "" && tbxTuesday.Text != "" && tbxWednesday.Text != "" && tbxThursday.Text != "" && tbxFriday.Text != "" && tbxSaturday.Text != "" && cbxWeek.Text != "")
            {
                if (tbxSunday.Text.Length <= 100 && tbxMonday.Text.Length <= 100 && tbxTuesday.Text.Length <= 100 && tbxWednesday.Text.Length <= 100 && tbxThursday.Text.Length <= 100 && tbxFriday.Text.Length <= 100 && tbxSaturday.Text.Length <= 100)
                {
                    DB.UpdateSchedule(lstEmployeeNames[cbxEmployee.SelectedIndex][0], lstEmployeeNames[cbxEmployee.SelectedIndex][1], tbxSunday.Text, tbxMonday.Text, tbxTuesday.Text, tbxWednesday.Text, tbxThursday.Text, tbxFriday.Text, tbxSaturday.Text, cbxWeek.Text);
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

        private void cbxWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            strStartWeek = cbxWeek.Text;
            string[] arrTasks = DB.GetEmployeeTasks(lstEmployeeNames[cbxEmployee.SelectedIndex][0], lstEmployeeNames[cbxEmployee.SelectedIndex][1], strStartWeek);
            if (arrTasks != null)
            {
                btnUpdateSchedule.Enabled = true;
                tbxSunday.Text = arrTasks[0];
                tbxMonday.Text = arrTasks[1];
                tbxTuesday.Text = arrTasks[2];
                tbxWednesday.Text = arrTasks[3];
                tbxThursday.Text = arrTasks[4];
                tbxFriday.Text = arrTasks[5];
                tbxSaturday.Text = arrTasks[6];
            }
            else
            {
                btnUpdateSchedule.Enabled = false;
                tbxSunday.Text = "";
                tbxMonday.Text = "";
                tbxTuesday.Text = "";
                tbxWednesday.Text = "";
                tbxThursday.Text = "";
                tbxFriday.Text = "";
                tbxSaturday.Text = "";
            }
        }
    }
}
