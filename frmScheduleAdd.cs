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
                lstEmployeeNames = DB.GetEmployeeNames();
                for (int intCurrentName = 0; intCurrentName < lstEmployeeNames.Count; intCurrentName++)
                {
                    cbxEmployee.Items.Add(lstEmployeeNames[intCurrentName][0] + " " + lstEmployeeNames[intCurrentName][1]);
                }

                DateTime today = DateTime.Now;
                switch (DateTime.Now.DayOfWeek.ToString())
                {
                    case "Sunday":
                        today = DateTime.Now;
                        break;
                    case "Monday":
                        today = DateTime.Now.AddDays(-1);
                        break;
                    case "Tuesday":
                        today = DateTime.Now.AddDays(-2);
                        break;
                    case "Wednesday":
                        today = DateTime.Now.AddDays(-3);
                        break;
                    case "Thursday":
                        today = DateTime.Now.AddDays(-4);
                        break;
                    case "Friday":
                        today = DateTime.Now.AddDays(-5);
                        break;
                    case "Saturday":
                        today = DateTime.Now.AddDays(-6);
                        break;
                }
                DateTime nextWeek = today.AddDays(7);
                arrDates[0] = $"{today.Year.ToString()}-{DB.FormatDayOrMonth(today.Month.ToString())}-{DB.FormatDayOrMonth(today.Day.ToString())}";
                arrDates[1] = $"{nextWeek.Year.ToString()}-{DB.FormatDayOrMonth(nextWeek.Month.ToString())}-{DB.FormatDayOrMonth(nextWeek.Day.ToString())}";
                //strStartDate = "'" + today.Year.ToString() + "-" + FormatDayOrMonth(today.Month.ToString()) + "-" + FormatDayOrMonth(today.Day.ToString()) + "'";

                cbxWeek.Items.Add($"This Week ({arrDates[0]})");
                cbxWeek.Items.Add($"Next Week ({arrDates[1]})");
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
                if (cbxEmployee.Text != "" && tbxSunday.Text != "" && tbxMonday.Text != "" && tbxTuesday.Text != "" && tbxWednesday.Text != "" && tbxThursday.Text != "" && tbxFriday.Text != "" && tbxSaturday.Text != "" && cbxWeek.Text != "")
                {
                    if (tbxSunday.Text.Length <= 100 && tbxMonday.Text.Length <= 100 && tbxTuesday.Text.Length <= 100 && tbxWednesday.Text.Length <= 100 && tbxThursday.Text.Length <= 100 && tbxFriday.Text.Length <= 100 && tbxSaturday.Text.Length <= 100)
                    {
                        DB.AddSchedule(lstEmployeeNames[cbxEmployee.SelectedIndex][0], lstEmployeeNames[cbxEmployee.SelectedIndex][1], tbxSunday.Text, tbxMonday.Text, tbxTuesday.Text, tbxWednesday.Text, tbxThursday.Text, tbxFriday.Text, tbxSaturday.Text, arrDates[cbxWeek.SelectedIndex]);
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
    }
}
