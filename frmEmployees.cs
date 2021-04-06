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
        public frmEmployees()
        {
            InitializeComponent();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            lblTask.Text = DB.GetSchedule(frmLogin.strCurrentUser, dgvSchedule);
        }

        private StringBuilder GenerateReport()
        {
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

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

            html.Append($"<td>" + dgvSchedule.Rows[0].Cells[0].Value.ToString() + "</td>");
            html.Append($"<td>" + dgvSchedule.Rows[0].Cells[1].Value.ToString() + "</td>");
            html.Append($"<td>" + dgvSchedule.Rows[0].Cells[2].Value.ToString() + "</td>");
            html.Append($"<td>" + dgvSchedule.Rows[0].Cells[3].Value.ToString() + "</td>");
            html.Append($"<td>" + dgvSchedule.Rows[0].Cells[4].Value.ToString() + "</td>");
            html.Append($"<td>" + dgvSchedule.Rows[0].Cells[5].Value.ToString() + "</td>");
            html.Append($"<td>" + dgvSchedule.Rows[0].Cells[6].Value.ToString() + "</td>");

            html.Append("<tr><td colspan=7><hr/></td></tr>");
            html.Append("</table>");
            html.Append("</body></html>");

            return html;
        }

        private void PrintReport(StringBuilder html)
        {
            try
            {
                using (StreamWriter wr = new StreamWriter("Schedule.html"))
                {
                    wr.WriteLine(html);
                }
                System.Diagnostics.Process.Start(@"Schedule.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show("You don't have write permissions", "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DateTime today = DateTime.Now;
            using (StreamWriter wr = new StreamWriter($"{today.ToString("yyyy-MM-dd-HHmmss")} - Schedule.html"))
            {
                wr.WriteLine(html);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintReport(GenerateReport());
        }

        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            frmUpdateEmployee update = new frmUpdateEmployee();
            update.ShowDialog();
        }

        private void btnRequestTrade_Click(object sender, EventArgs e)
        {

        }

        private void btnRequestDayOff_Click(object sender, EventArgs e)
        {
            frmRequestDayOff dayoff = new frmRequestDayOff();
            dayoff.ShowDialog();
        }
    }
}
