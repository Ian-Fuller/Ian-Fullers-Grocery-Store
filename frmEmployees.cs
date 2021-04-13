using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SP21_Final_Project
{
    public partial class frmEmployees : Form
    {
        //Info for panels that are taken from frmMain
        static List<SpecialPanel> lstSpecials = new List<SpecialPanel>();
        int intSGroupSize = 3;
        List<SpecialPanel[]> lstSpecialGroups = new List<SpecialPanel[]>();
        int[,] arrSpecialPositions = new int[3, 2]
        {
            { 165, 216 },
            { 405, 216 },
            { 645, 216 },
        };
        int intSGroupIndex = 0;

        public frmEmployees()
        {
            InitializeComponent();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            frmMain.FillRefreshPanelData();
            this.Close();
        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            try
            {
                MaximizeBox = false;

                //Fills combo box with options
                cboWeek.Items.Add("All Previous Weeks");
                cboWeek.Items.Add("This Week");
                cboWeek.Items.Add("Next Week");
                cboWeek.Text = "This Week";

                lblTask.Text = DB.GetSchedule(frmLogin.strCurrentUser, dgvSchedule, cboWeek.Text);

                lstSpecials = frmMain.lstSpecials;

                //Disables buttons on SpecialPanels since employees dont need them
                for (int intCurrentPanel = 0; intCurrentPanel < lstSpecials.Count; intCurrentPanel++)
                {
                    lstSpecials[intCurrentPanel].SetButtonVisibility(false);
                }

                //Places panels into their groups
                int intSGroupCount = (int)Math.Ceiling((double)lstSpecials.Count / (double)intSGroupSize);
                int intSpecialIndex = 0;
                for (int intCurrentGroup = 0; intCurrentGroup < intSGroupCount; intCurrentGroup++)
                {
                    lstSpecialGroups.Add(new SpecialPanel[intSGroupSize]);
                    for (int intIndexInGroup = 0; intIndexInGroup < intSGroupSize; intIndexInGroup++)
                    {
                        if (intSpecialIndex < lstSpecials.Count)
                        {
                            lstSpecialGroups[intCurrentGroup][intIndexInGroup] = lstSpecials[intSpecialIndex];
                            lstSpecialGroups[intCurrentGroup][intIndexInGroup].SetPosition(arrSpecialPositions[intIndexInGroup, 0], arrSpecialPositions[intIndexInGroup, 1]);
                            intSpecialIndex++;
                        }
                        else
                        {
                            lstSpecialGroups[intCurrentGroup][intIndexInGroup] = new SpecialPanel();
                            intSpecialIndex++;
                        }
                    }
                }

                //Shows panels
                for (int intIndexInGroup = 0; intIndexInGroup < lstSpecialGroups[intSGroupIndex].Length; intIndexInGroup++)
                {
                    lstSpecialGroups[intSGroupIndex][intIndexInGroup].ShowPanel(this);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error retrieving data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Prints employee's schedule
        private StringBuilder GenerateReport()
        {
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

            try
            {
                css.Append("<style>");
                css.Append("td {padding:5px;text-align:center;font-weight:bold;text-align:conter;}");
                css.Append("h1{color: black;}");
                css.Append("</style>");

                html.Append("<html>");
                html.Append($"<head>{css}<title>Employee Schedule</title></head>");
                html.Append("<body>");
                html.Append("<h1>" + frmLogin.strCurrentUser + "'s Schedule</h1>");

                html.Append("<table>");
                html.Append("<tr><td colspan=7><hr/></td></tr>");
                html.Append($"<td>" + "Sunday" + "</td>");
                html.Append($"<td>" + "Monday" + "</td>");
                html.Append($"<td>" + "Tuesday" + "</td>");
                html.Append($"<td>" + "Wednesday" + "</td>");
                html.Append($"<td>" + "Thursday" + "</td>");
                html.Append($"<td>" + "Friday" + "</td>");
                html.Append($"<td>" + "Saturday" + "</td>");
                html.Append("</tr>");

                html.Append("<tr><td colspan=7><hr/></td></tr>");
                for (int intCurrentRow = 0; intCurrentRow < dgvSchedule.Rows.Count - 1; intCurrentRow++)
                {
                    html.Append("<tr><td colspan=7></td></tr>");
                    html.Append($"<td>" + dgvSchedule.Rows[intCurrentRow].Cells[0].Value.ToString() + "</td>");
                    html.Append($"<td>" + dgvSchedule.Rows[intCurrentRow].Cells[1].Value.ToString() + "</td>");
                    html.Append($"<td>" + dgvSchedule.Rows[intCurrentRow].Cells[2].Value.ToString() + "</td>");
                    html.Append($"<td>" + dgvSchedule.Rows[intCurrentRow].Cells[3].Value.ToString() + "</td>");
                    html.Append($"<td>" + dgvSchedule.Rows[intCurrentRow].Cells[4].Value.ToString() + "</td>");
                    html.Append($"<td>" + dgvSchedule.Rows[intCurrentRow].Cells[5].Value.ToString() + "</td>");
                    html.Append($"<td>" + dgvSchedule.Rows[intCurrentRow].Cells[6].Value.ToString() + "</td>");
                    html.Append("<tr><td colspan=7></td></tr>");
                }
                html.Append("<tr><td colspan=7><hr/></td></tr>");

                html.Append("</table>");
                html.Append("</body></html>");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cannot print schedule", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                html.Append("<html><body><h1>Error</h1></body></html>");
            }

            return html;
        }

        //Function to print the schedule
        private void PrintReport(StringBuilder html)
        {
            try
            {
                using (StreamWriter swWriter = new StreamWriter("Schedule.html"))
                {
                    swWriter.WriteLine(html);
                }
                System.Diagnostics.Process.Start(@"Schedule.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show("You don't have write permissions", "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DateTime dtToday = DateTime.Now;
            using (StreamWriter swWriter = new StreamWriter($"{dtToday.ToString("yyyy-MM-dd-HHmmss")} - Schedule.html"))
            {
                swWriter.WriteLine(html);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintReport(GenerateReport());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error printing schedule", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            try
            {
                frmUpdateEmployee update = new frmUpdateEmployee();
                update.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error opening form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRequestTrade_Click(object sender, EventArgs e)
        {
            try
            {
                frmRequestTrade trade = new frmRequestTrade();
                trade.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error opening form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRequestDayOff_Click(object sender, EventArgs e)
        {
            try
            {
                frmRequestDayOff dayoff = new frmRequestDayOff();
                dayoff.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error opening form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblTask.Text = DB.GetSchedule(frmLogin.strCurrentUser, dgvSchedule, cboWeek.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error retrieving schedule", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            try
            {
                for (int intIndexInGroup = 0; intIndexInGroup < lstSpecialGroups[intSGroupIndex].Length; intIndexInGroup++)
                {
                    lstSpecialGroups[intSGroupIndex][intIndexInGroup].HidePanel(this);
                }

                intSGroupIndex--;
                if (intSGroupIndex < 0)
                {
                    intSGroupIndex = lstSpecialGroups.Count - 1;
                }
                for (int intIndexInGroup = 0; intIndexInGroup < lstSpecialGroups[intSGroupIndex].Length; intIndexInGroup++)
                {
                    lstSpecialGroups[intSGroupIndex][intIndexInGroup].ShowPanel(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing page", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                //Hides current panels
                for (int intIndexInGroup = 0; intIndexInGroup < lstSpecialGroups[intSGroupIndex].Length; intIndexInGroup++)
                {
                    lstSpecialGroups[intSGroupIndex][intIndexInGroup].HidePanel(this);
                }

                //Shows previous page of panels
                intSGroupIndex++;
                if (intSGroupIndex == lstSpecialGroups.Count)
                {
                    intSGroupIndex = 0;
                }
                for (int intIndexInGroup = 0; intIndexInGroup < lstSpecialGroups[intSGroupIndex].Length; intIndexInGroup++)
                {
                    lstSpecialGroups[intSGroupIndex][intIndexInGroup].ShowPanel(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing page", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuSchedulesPrinting_Click(object sender, EventArgs e)
        {
            Help.HelpSchedule();
        }

        private void mnuSpecials_Click(object sender, EventArgs e)
        {
            Help.HelpEmployeeSpecials();
        }

        private void mnuDayOffAndTrade_Click(object sender, EventArgs e)
        {
            Help.HelpRequestChange();
        }

        private void mnuChangeInformation_Click(object sender, EventArgs e)
        {
            Help.HelpChangeInformation();
        }
    }
}
