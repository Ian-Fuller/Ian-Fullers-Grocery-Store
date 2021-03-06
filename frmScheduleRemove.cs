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
        List<string> lstScheduleDates;

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
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error retrieving data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboEmployee.Text != "" && cboWeek.Text != "")
                {
                    DB.RemoveSchedule(lstEmployeeNames[cboEmployee.SelectedIndex][0], lstEmployeeNames[cboEmployee.SelectedIndex][1], cboWeek.Text);

                    //Refreshes employees
                    lstEmployeeNames.Clear();
                    lstEmployeeNames = DB.GetEmployeeNames();
                    cboEmployee.Items.Clear();
                    for (int intCurrentName = 0; intCurrentName < lstEmployeeNames.Count; intCurrentName++)
                    {
                        cboEmployee.Items.Add(lstEmployeeNames[intCurrentName][0] + " " + lstEmployeeNames[intCurrentName][1]);
                    }
                    cboEmployee.Text = (string)cboEmployee.Items[0];

                    //Refreshes dates
                    lstScheduleDates.Clear();
                    lstScheduleDates = DB.GetScheduleDates();
                    cboWeek.Items.Clear();
                    for (int intCurrentDate = 0; intCurrentDate < lstScheduleDates.Count; intCurrentDate++)
                    {
                        cboWeek.Items.Add(lstScheduleDates[intCurrentDate]);
                    }
                    cboWeek.Text = (string)cboWeek.Items[0];
                }
                else
                {
                    MessageBox.Show("One or more combo boxes is blank.", "Input Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cannot remove schedule", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuRemoveSchedule_Click(object sender, EventArgs e)
        {
            Help.HelpScheduleRemove();
        }

        private void mnuReturn_Click(object sender, EventArgs e)
        {
            FormCloser.returnToMain();
        }
    }
}
