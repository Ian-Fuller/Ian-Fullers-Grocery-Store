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
            string[] arrTimePeriods = new string[] { "Daily", "Weekly", "Monthly" };
            for(int intCurrentPeriod = 0; intCurrentPeriod < arrTimePeriods.Length; intCurrentPeriod++)
            {
                cbxTimePeriod.Items.Add(arrTimePeriods[intCurrentPeriod]);
            }
        }

        private void PrintReport(StringBuilder html, string strFileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(strFileName))
                {
                    writer.WriteLine(html);
                }
                System.Diagnostics.Process.Start(@strFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("You don't have write permissions", "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DateTime today = DateTime.Now;
            using (StreamWriter wr = new StreamWriter($"{today.ToString("yyyy-MM-dd-HHmmss")} - " + strFileName))
            {
                wr.WriteLine(html);
            }
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            PrintReport(DB.GenerateSalesReport(cbxTimePeriod.Text, DateTime.Now), cbxTimePeriod.Text + "SalesReport.html");
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
    }
}
