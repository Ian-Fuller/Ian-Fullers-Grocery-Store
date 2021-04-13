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
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            try
            {
                MaximizeBox = false;

                string[] arrTimePeriods = new string[] { "Daily", "Weekly", "Monthly" };
                for (int intCurrentPeriod = 0; intCurrentPeriod < arrTimePeriods.Length; intCurrentPeriod++)
                {
                    cboTimePeriod.Items.Add(arrTimePeriods[intCurrentPeriod]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintReport(StringBuilder html, string strFileName)
        {
            try
            {
                using (StreamWriter swWriter = new StreamWriter(strFileName))
                {
                    swWriter.WriteLine(html);
                }
                System.Diagnostics.Process.Start(@strFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("You don't have write permissions", "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                DateTime dtToday = DateTime.Now;
                using (StreamWriter swWriter = new StreamWriter($"{dtToday.ToString("yyyy-MM-dd-HHmmss")} - " + strFileName))
                {
                    swWriter.WriteLine(html);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            PrintReport(DB.GenerateSalesReport(cboTimePeriod.Text, DateTime.Now), cboTimePeriod.Text + "SalesReport.html");
        }

        private void btnScheduleReport_Click(object sender, EventArgs e)
        {
            PrintReport(DB.GenerateScheduleReport(), "EmployeeScheduleReport.html");
        }

        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            PrintReport(DB.GenerateInventoryReport(), "CurrentInventoryReport.html");
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuReport_Click(object sender, EventArgs e)
        {
            Help.HelpReport();
        }
    }
}
