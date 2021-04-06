
namespace SP21_Final_Project
{
    partial class frmReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSalesReport = new System.Windows.Forms.Button();
            this.btnScheduleReport = new System.Windows.Forms.Button();
            this.btnInventoryReport = new System.Windows.Forms.Button();
            this.cbxTimePeriod = new System.Windows.Forms.ComboBox();
            this.mnuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuBar.Location = new System.Drawing.Point(0, 0);
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(218, 24);
            this.mnuBar.TabIndex = 0;
            this.mnuBar.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClose});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuClose
            // 
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.Size = new System.Drawing.Size(180, 22);
            this.mnuClose.Text = "&Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // btnSalesReport
            // 
            this.btnSalesReport.Location = new System.Drawing.Point(13, 28);
            this.btnSalesReport.Name = "btnSalesReport";
            this.btnSalesReport.Size = new System.Drawing.Size(122, 23);
            this.btnSalesReport.TabIndex = 1;
            this.btnSalesReport.Text = "&Sales Totals";
            this.btnSalesReport.UseVisualStyleBackColor = true;
            this.btnSalesReport.Click += new System.EventHandler(this.btnSalesReport_Click);
            // 
            // btnScheduleReport
            // 
            this.btnScheduleReport.Location = new System.Drawing.Point(13, 57);
            this.btnScheduleReport.Name = "btnScheduleReport";
            this.btnScheduleReport.Size = new System.Drawing.Size(124, 23);
            this.btnScheduleReport.TabIndex = 2;
            this.btnScheduleReport.Text = "&Employee Schedules";
            this.btnScheduleReport.UseVisualStyleBackColor = true;
            this.btnScheduleReport.Click += new System.EventHandler(this.btnScheduleReport_Click);
            // 
            // btnInventoryReport
            // 
            this.btnInventoryReport.Location = new System.Drawing.Point(13, 86);
            this.btnInventoryReport.Name = "btnInventoryReport";
            this.btnInventoryReport.Size = new System.Drawing.Size(124, 23);
            this.btnInventoryReport.TabIndex = 3;
            this.btnInventoryReport.Text = "&Current Inventory";
            this.btnInventoryReport.UseVisualStyleBackColor = true;
            this.btnInventoryReport.Click += new System.EventHandler(this.btnInventoryReport_Click);
            // 
            // cbxTimePeriod
            // 
            this.cbxTimePeriod.FormattingEnabled = true;
            this.cbxTimePeriod.Location = new System.Drawing.Point(141, 30);
            this.cbxTimePeriod.Name = "cbxTimePeriod";
            this.cbxTimePeriod.Size = new System.Drawing.Size(62, 21);
            this.cbxTimePeriod.TabIndex = 4;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 125);
            this.Controls.Add(this.cbxTimePeriod);
            this.Controls.Add(this.btnInventoryReport);
            this.Controls.Add(this.btnScheduleReport);
            this.Controls.Add(this.btnSalesReport);
            this.Controls.Add(this.mnuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuBar;
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Report";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.Button btnSalesReport;
        private System.Windows.Forms.Button btnScheduleReport;
        private System.Windows.Forms.Button btnInventoryReport;
        private System.Windows.Forms.ComboBox cbxTimePeriod;
    }
}