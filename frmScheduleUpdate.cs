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
    public partial class frmScheduleUpdate : Form
    {
        List<string[]> lstEmployeeNames;
        List<string> lstScheduleDates;

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
            try
            {
                FormCloser.lstOpenedForms.Add(this);

                MaximizeBox = false;

                //Puts employee FirstName and LastName into combo box
                lstEmployeeNames = DB.GetEmployeeNames();
                for (int intCurrentName = 0; intCurrentName < lstEmployeeNames.Count; intCurrentName++)
                {
                    cboEmployee.Items.Add(lstEmployeeNames[intCurrentName][0] + " " + lstEmployeeNames[intCurrentName][1]);
                }
                cboEmployee.Text = (string)cboEmployee.Items[0];

                //Puts schedule dates into combo box
                lstScheduleDates = DB.GetScheduleDates();
                for (int intCurrentDate = 0; intCurrentDate < lstScheduleDates.Count; intCurrentDate++)
                {
                    cboWeek.Items.Add(lstScheduleDates[intCurrentDate]);
                }
                cboWeek.Text = (string)cboWeek.Items[0];

                //Fills tasks upon loading
                string[] arrTasks = DB.GetEmployeeTasks(lstEmployeeNames[cboEmployee.SelectedIndex][0], lstEmployeeNames[cboEmployee.SelectedIndex][1], lstScheduleDates[cboWeek.SelectedIndex]);
                tbxSunday.Text = arrTasks[0];
                tbxMonday.Text = arrTasks[1];
                tbxTuesday.Text = arrTasks[2];
                tbxWednesday.Text = arrTasks[3];
                tbxThursday.Text = arrTasks[4];
                tbxFriday.Text = arrTasks[5];
                tbxSaturday.Text = arrTasks[6];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Gets proper data when selected name changes
        private void cbxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] arrTasks = DB.GetEmployeeTasks(lstEmployeeNames[cboEmployee.SelectedIndex][0], lstEmployeeNames[cboEmployee.SelectedIndex][1], cboWeek.Text);
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
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Gets proper data when selected date changes
        private void cbxWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] arrTasks = DB.GetEmployeeTasks(lstEmployeeNames[cboEmployee.SelectedIndex][0], lstEmployeeNames[cboEmployee.SelectedIndex][1], cboWeek.Text);
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
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxSunday.Text != "" && tbxMonday.Text != "" && tbxTuesday.Text != "" && tbxWednesday.Text != "" && tbxThursday.Text != "" && tbxFriday.Text != "" && tbxSaturday.Text != "")
                {
                    if (tbxSunday.Text.Length <= 100 && tbxMonday.Text.Length <= 100 && tbxTuesday.Text.Length <= 100 && tbxWednesday.Text.Length <= 100 && tbxThursday.Text.Length <= 100 && tbxFriday.Text.Length <= 100 && tbxSaturday.Text.Length <= 100)
                    {
                        DB.UpdateSchedule(lstEmployeeNames[cboEmployee.SelectedIndex][0], lstEmployeeNames[cboEmployee.SelectedIndex][1], tbxSunday.Text, tbxMonday.Text, tbxTuesday.Text, tbxWednesday.Text, tbxThursday.Text, tbxFriday.Text, tbxSaturday.Text, cboWeek.Text);
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
            catch(Exception ex)
            {
                MessageBox.Show("Cannot update schedule.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUpdateSchedule_Click(object sender, EventArgs e)
        {
            Help.HelpScheduleUpdate();
        }

        private void mnuReturn_Click(object sender, EventArgs e)
        {
            FormCloser.returnToMain();
        }
    }
}
