
namespace SP21_Final_Project
{
    partial class frmEmployees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployees));
            this.btnRequestTrade = new System.Windows.Forms.Button();
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSchedulesPrinting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSpecials = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDayOffAndTrade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangeInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRequestDayOff = new System.Windows.Forms.Button();
            this.btnChangeInfo = new System.Windows.Forms.Button();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.lblToday = new System.Windows.Forms.Label();
            this.lblTask = new System.Windows.Forms.Label();
            this.lblThisWeek = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cboWeek = new System.Windows.Forms.ComboBox();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.lblSpecials = new System.Windows.Forms.Label();
            this.mnuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRequestTrade
            // 
            this.btnRequestTrade.Location = new System.Drawing.Point(12, 27);
            this.btnRequestTrade.Name = "btnRequestTrade";
            this.btnRequestTrade.Size = new System.Drawing.Size(143, 23);
            this.btnRequestTrade.TabIndex = 1;
            this.btnRequestTrade.Text = "Request work day &trade";
            this.btnRequestTrade.UseVisualStyleBackColor = true;
            this.btnRequestTrade.Click += new System.EventHandler(this.btnRequestTrade_Click);
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
            this.mnuBar.Location = new System.Drawing.Point(0, 0);
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(964, 24);
            this.mnuBar.TabIndex = 1;
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
            this.mnuClose.Size = new System.Drawing.Size(103, 22);
            this.mnuClose.Text = "&Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSchedulesPrinting,
            this.mnuSpecials,
            this.mnuDayOffAndTrade,
            this.mnuChangeInformation});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuSchedulesPrinting
            // 
            this.mnuSchedulesPrinting.Name = "mnuSchedulesPrinting";
            this.mnuSchedulesPrinting.Size = new System.Drawing.Size(258, 22);
            this.mnuSchedulesPrinting.Text = "&Schedules and Schedule Printing";
            this.mnuSchedulesPrinting.Click += new System.EventHandler(this.mnuSchedulesPrinting_Click);
            // 
            // mnuSpecials
            // 
            this.mnuSpecials.Name = "mnuSpecials";
            this.mnuSpecials.Size = new System.Drawing.Size(258, 22);
            this.mnuSpecials.Text = "&Specials";
            this.mnuSpecials.Click += new System.EventHandler(this.mnuSpecials_Click);
            // 
            // mnuDayOffAndTrade
            // 
            this.mnuDayOffAndTrade.Name = "mnuDayOffAndTrade";
            this.mnuDayOffAndTrade.Size = new System.Drawing.Size(258, 22);
            this.mnuDayOffAndTrade.Text = "&Request Day Off and Request Trade";
            this.mnuDayOffAndTrade.Click += new System.EventHandler(this.mnuDayOffAndTrade_Click);
            // 
            // mnuChangeInformation
            // 
            this.mnuChangeInformation.Name = "mnuChangeInformation";
            this.mnuChangeInformation.Size = new System.Drawing.Size(258, 22);
            this.mnuChangeInformation.Text = "&Change Information";
            this.mnuChangeInformation.Click += new System.EventHandler(this.mnuChangeInformation_Click);
            // 
            // btnRequestDayOff
            // 
            this.btnRequestDayOff.Location = new System.Drawing.Point(12, 56);
            this.btnRequestDayOff.Name = "btnRequestDayOff";
            this.btnRequestDayOff.Size = new System.Drawing.Size(143, 23);
            this.btnRequestDayOff.TabIndex = 2;
            this.btnRequestDayOff.Text = "Request &day off";
            this.btnRequestDayOff.UseVisualStyleBackColor = true;
            this.btnRequestDayOff.Click += new System.EventHandler(this.btnRequestDayOff_Click);
            // 
            // btnChangeInfo
            // 
            this.btnChangeInfo.Location = new System.Drawing.Point(12, 85);
            this.btnChangeInfo.Name = "btnChangeInfo";
            this.btnChangeInfo.Size = new System.Drawing.Size(143, 23);
            this.btnChangeInfo.TabIndex = 3;
            this.btnChangeInfo.Text = "&Change Information";
            this.btnChangeInfo.UseVisualStyleBackColor = true;
            this.btnChangeInfo.Click += new System.EventHandler(this.btnChangeInfo_Click);
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Location = new System.Drawing.Point(165, 77);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.Size = new System.Drawing.Size(787, 83);
            this.dgvSchedule.TabIndex = 4;
            this.dgvSchedule.TabStop = false;
            // 
            // lblToday
            // 
            this.lblToday.AutoSize = true;
            this.lblToday.Location = new System.Drawing.Point(162, 27);
            this.lblToday.Name = "lblToday";
            this.lblToday.Size = new System.Drawing.Size(74, 13);
            this.lblToday.TabIndex = 5;
            this.lblToday.Text = "Today\'s Task:";
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTask.Location = new System.Drawing.Point(165, 40);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(24, 15);
            this.lblTask.TabIndex = 6;
            this.lblTask.Text = "[   ]";
            // 
            // lblThisWeek
            // 
            this.lblThisWeek.AutoSize = true;
            this.lblThisWeek.Location = new System.Drawing.Point(162, 61);
            this.lblThisWeek.Name = "lblThisWeek";
            this.lblThisWeek.Size = new System.Drawing.Size(62, 13);
            this.lblThisWeek.TabIndex = 7;
            this.lblThisWeek.Text = "This Week:";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(165, 166);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(143, 23);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "&Print Schedule";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cboWeek
            // 
            this.cboWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeek.FormattingEnabled = true;
            this.cboWeek.Location = new System.Drawing.Point(314, 167);
            this.cboWeek.Name = "cboWeek";
            this.cboWeek.Size = new System.Drawing.Size(121, 21);
            this.cboWeek.TabIndex = 5;
            this.cboWeek.SelectedIndexChanged += new System.EventHandler(this.cbxWeek_SelectedIndexChanged);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Location = new System.Drawing.Point(165, 371);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(383, 20);
            this.btnPrevPage.TabIndex = 6;
            this.btnPrevPage.Text = "&<";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(569, 371);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(383, 20);
            this.btnNextPage.TabIndex = 7;
            this.btnNextPage.Text = "&>";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // lblSpecials
            // 
            this.lblSpecials.AutoSize = true;
            this.lblSpecials.Location = new System.Drawing.Point(165, 196);
            this.lblSpecials.Name = "lblSpecials";
            this.lblSpecials.Size = new System.Drawing.Size(50, 13);
            this.lblSpecials.TabIndex = 13;
            this.lblSpecials.Text = "Specials:";
            // 
            // frmEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 406);
            this.Controls.Add(this.lblSpecials);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPrevPage);
            this.Controls.Add(this.cboWeek);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblThisWeek);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.lblToday);
            this.Controls.Add(this.dgvSchedule);
            this.Controls.Add(this.btnChangeInfo);
            this.Controls.Add(this.btnRequestDayOff);
            this.Controls.Add(this.btnRequestTrade);
            this.Controls.Add(this.mnuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuBar;
            this.Name = "frmEmployees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employees Menu";
            this.Load += new System.EventHandler(this.frmEmployees_Load);
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRequestTrade;
        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.Button btnRequestDayOff;
        private System.Windows.Forms.Button btnChangeInfo;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.Label lblToday;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Label lblThisWeek;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cboWeek;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Label lblSpecials;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuSchedulesPrinting;
        private System.Windows.Forms.ToolStripMenuItem mnuSpecials;
        private System.Windows.Forms.ToolStripMenuItem mnuDayOffAndTrade;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeInformation;
    }
}