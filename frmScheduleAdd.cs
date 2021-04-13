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
        string[] arrDates = new string[2];

        public frmScheduleAdd()
        {
            InitializeComponent();
        }

        private void frmScheduleAdd_Load(object sender, EventArgs e)
        {
            try
            {
                MaximizeBox = false;

                //Fills the first combo box with the names of the employees
                lstEmployeeNames = DB.GetEmployeeNames();
                for (int intCurrentName = 0; intCurrentName < lstEmployeeNames.Count; intCurrentName++)
                {
                    cboEmployee.Items.Add(lstEmployeeNames[intCurrentName][0] + " " + lstEmployeeNames[intCurrentName][1]);
                }

                //Generates dates for the start (sunday) of this week, and next week
                DateTime dtToday = DateTime.Now;
                switch (DateTime.Now.DayOfWeek.ToString())
                {
                    case "Sunday":
                        dtToday = DateTime.Now;
                        break;
                    case "Monday":
                        dtToday = DateTime.Now.AddDays(-1);
                        break;
                    case "Tuesday":
                        dtToday = DateTime.Now.AddDays(-2);
                        break;
                    case "Wednesday":
                        dtToday = DateTime.Now.AddDays(-3);
                        break;
                    case "Thursday":
                        dtToday = DateTime.Now.AddDays(-4);
                        break;
                    case "Friday":
                        dtToday = DateTime.Now.AddDays(-5);
                        break;
                    case "Saturday":
                        dtToday = DateTime.Now.AddDays(-6);
                        break;
                }
                DateTime dtNextWeek = dtToday.AddDays(7);
                arrDates[0] = $"{dtToday.Year.ToString()}-{DB.FormatDayOrMonth(dtToday.Month.ToString())}-{DB.FormatDayOrMonth(dtToday.Day.ToString())}";
                arrDates[1] = $"{dtNextWeek.Year.ToString()}-{DB.FormatDayOrMonth(dtNextWeek.Month.ToString())}-{DB.FormatDayOrMonth(dtNextWeek.Day.ToString())}";
                //strStartDate = "'" + today.Year.ToString() + "-" + FormatDayOrMonth(today.Month.ToString()) + "-" + FormatDayOrMonth(today.Day.ToString()) + "'";

                //Fills the second combo box with the options for this week and next week
                cboWeek.Items.Add($"This Week ({arrDates[0]})");
                cboWeek.Items.Add($"Next Week ({arrDates[1]})");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error retrieving data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                //Creates the schedule as long as none of the fields are left blank, and none of them are too long
                if (cboEmployee.Text != "" && tbxSunday.Text != "" && tbxMonday.Text != "" && tbxTuesday.Text != "" && tbxWednesday.Text != "" && tbxThursday.Text != "" && tbxFriday.Text != "" && tbxSaturday.Text != "" && cboWeek.Text != "")
                {
                    if (tbxSunday.Text.Length <= 100 && tbxMonday.Text.Length <= 100 && tbxTuesday.Text.Length <= 100 && tbxWednesday.Text.Length <= 100 && tbxThursday.Text.Length <= 100 && tbxFriday.Text.Length <= 100 && tbxSaturday.Text.Length <= 100)
                    {
                        DB.AddSchedule(lstEmployeeNames[cboEmployee.SelectedIndex][0], lstEmployeeNames[cboEmployee.SelectedIndex][1], tbxSunday.Text, tbxMonday.Text, tbxTuesday.Text, tbxWednesday.Text, tbxThursday.Text, tbxFriday.Text, tbxSaturday.Text, arrDates[cboWeek.SelectedIndex]);
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
                MessageBox.Show("Cannot add schedule", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuCreateSchedules_Click(object sender, EventArgs e)
        {
            Help.HelpScheduleAdd();
        }
    }
}
