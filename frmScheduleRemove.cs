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
                //Puts employee FirstName and LastName into combo box
                lstEmployeeNames = DB.GetEmployeeNames();
                for (int intCurrentName = 0; intCurrentName < lstEmployeeNames.Count; intCurrentName++)
                {
                    cbxEmployee.Items.Add(lstEmployeeNames[intCurrentName][0] + " " + lstEmployeeNames[intCurrentName][1]);
                }
                cbxEmployee.Text = (string)cbxEmployee.Items[0];

                //Puts schedule dates into combo box
                lstScheduleDates = DB.GetScheduleDates();
                for (int intCurrentDate = 0; intCurrentDate < lstScheduleDates.Count; intCurrentDate++)
                {
                    cbxWeek.Items.Add(lstScheduleDates[intCurrentDate]);
                }
                cbxWeek.Text = (string)cbxWeek.Items[0];
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
                if (cbxEmployee.Text != "" && cbxWeek.Text != "")
                {
                    DB.RemoveSchedule(lstEmployeeNames[cbxEmployee.SelectedIndex][0], lstEmployeeNames[cbxEmployee.SelectedIndex][1], cbxWeek.Text);
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
    }
}
