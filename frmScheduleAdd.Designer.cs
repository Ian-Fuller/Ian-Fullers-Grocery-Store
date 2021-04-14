
namespace SP21_Final_Project
{
    partial class frmScheduleAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScheduleAdd));
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateSchedules = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFor = new System.Windows.Forms.Label();
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.tbxSunday = new System.Windows.Forms.TextBox();
            this.tbxMonday = new System.Windows.Forms.TextBox();
            this.tbxTuesday = new System.Windows.Forms.TextBox();
            this.tbxWednesday = new System.Windows.Forms.TextBox();
            this.tbxThursday = new System.Windows.Forms.TextBox();
            this.tbxFriday = new System.Windows.Forms.TextBox();
            this.tbxSaturday = new System.Windows.Forms.TextBox();
            this.cboWeek = new System.Windows.Forms.ComboBox();
            this.lblSunday = new System.Windows.Forms.Label();
            this.lblMonday = new System.Windows.Forms.Label();
            this.lblTuesday = new System.Windows.Forms.Label();
            this.lblWednesday = new System.Windows.Forms.Label();
            this.lblThursday = new System.Windows.Forms.Label();
            this.lblFriday = new System.Windows.Forms.Label();
            this.lblSaturday = new System.Windows.Forms.Label();
            this.lblWeek = new System.Windows.Forms.Label();
            this.btnCreateSchedule = new System.Windows.Forms.Button();
            this.mnuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
            this.mnuBar.Location = new System.Drawing.Point(0, 0);
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(349, 24);
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
            this.mnuClose.Size = new System.Drawing.Size(103, 22);
            this.mnuClose.Text = "&Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreateSchedules});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuCreateSchedules
            // 
            this.mnuCreateSchedules.Name = "mnuCreateSchedules";
            this.mnuCreateSchedules.Size = new System.Drawing.Size(164, 22);
            this.mnuCreateSchedules.Text = "&Create Schedules";
            this.mnuCreateSchedules.Click += new System.EventHandler(this.mnuCreateSchedules_Click);
            // 
            // lblFor
            // 
            this.lblFor.AutoSize = true;
            this.lblFor.Location = new System.Drawing.Point(12, 36);
            this.lblFor.Name = "lblFor";
            this.lblFor.Size = new System.Drawing.Size(102, 13);
            this.lblFor.TabIndex = 1;
            this.lblFor.Text = "Create schedule for:";
            // 
            // cboEmployee
            // 
            this.cboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployee.FormattingEnabled = true;
            this.cboEmployee.Location = new System.Drawing.Point(120, 33);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Size = new System.Drawing.Size(217, 21);
            this.cboEmployee.TabIndex = 1;
            // 
            // tbxSunday
            // 
            this.tbxSunday.Location = new System.Drawing.Point(120, 61);
            this.tbxSunday.Name = "tbxSunday";
            this.tbxSunday.Size = new System.Drawing.Size(217, 20);
            this.tbxSunday.TabIndex = 2;
            // 
            // tbxMonday
            // 
            this.tbxMonday.Location = new System.Drawing.Point(120, 87);
            this.tbxMonday.Name = "tbxMonday";
            this.tbxMonday.Size = new System.Drawing.Size(217, 20);
            this.tbxMonday.TabIndex = 3;
            // 
            // tbxTuesday
            // 
            this.tbxTuesday.Location = new System.Drawing.Point(120, 113);
            this.tbxTuesday.Name = "tbxTuesday";
            this.tbxTuesday.Size = new System.Drawing.Size(217, 20);
            this.tbxTuesday.TabIndex = 4;
            // 
            // tbxWednesday
            // 
            this.tbxWednesday.Location = new System.Drawing.Point(120, 139);
            this.tbxWednesday.Name = "tbxWednesday";
            this.tbxWednesday.Size = new System.Drawing.Size(217, 20);
            this.tbxWednesday.TabIndex = 5;
            // 
            // tbxThursday
            // 
            this.tbxThursday.Location = new System.Drawing.Point(120, 165);
            this.tbxThursday.Name = "tbxThursday";
            this.tbxThursday.Size = new System.Drawing.Size(217, 20);
            this.tbxThursday.TabIndex = 6;
            // 
            // tbxFriday
            // 
            this.tbxFriday.Location = new System.Drawing.Point(120, 191);
            this.tbxFriday.Name = "tbxFriday";
            this.tbxFriday.Size = new System.Drawing.Size(217, 20);
            this.tbxFriday.TabIndex = 7;
            // 
            // tbxSaturday
            // 
            this.tbxSaturday.Location = new System.Drawing.Point(120, 217);
            this.tbxSaturday.Name = "tbxSaturday";
            this.tbxSaturday.Size = new System.Drawing.Size(217, 20);
            this.tbxSaturday.TabIndex = 8;
            // 
            // cboWeek
            // 
            this.cboWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeek.FormattingEnabled = true;
            this.cboWeek.Location = new System.Drawing.Point(120, 243);
            this.cboWeek.Name = "cboWeek";
            this.cboWeek.Size = new System.Drawing.Size(148, 21);
            this.cboWeek.TabIndex = 9;
            // 
            // lblSunday
            // 
            this.lblSunday.AutoSize = true;
            this.lblSunday.Location = new System.Drawing.Point(68, 64);
            this.lblSunday.Name = "lblSunday";
            this.lblSunday.Size = new System.Drawing.Size(46, 13);
            this.lblSunday.TabIndex = 11;
            this.lblSunday.Text = "Sunday:";
            // 
            // lblMonday
            // 
            this.lblMonday.AutoSize = true;
            this.lblMonday.Location = new System.Drawing.Point(66, 90);
            this.lblMonday.Name = "lblMonday";
            this.lblMonday.Size = new System.Drawing.Size(48, 13);
            this.lblMonday.TabIndex = 12;
            this.lblMonday.Text = "Monday:";
            // 
            // lblTuesday
            // 
            this.lblTuesday.AutoSize = true;
            this.lblTuesday.Location = new System.Drawing.Point(63, 116);
            this.lblTuesday.Name = "lblTuesday";
            this.lblTuesday.Size = new System.Drawing.Size(51, 13);
            this.lblTuesday.TabIndex = 13;
            this.lblTuesday.Text = "Tuesday:";
            // 
            // lblWednesday
            // 
            this.lblWednesday.AutoSize = true;
            this.lblWednesday.Location = new System.Drawing.Point(47, 142);
            this.lblWednesday.Name = "lblWednesday";
            this.lblWednesday.Size = new System.Drawing.Size(67, 13);
            this.lblWednesday.TabIndex = 14;
            this.lblWednesday.Text = "Wednesday:";
            // 
            // lblThursday
            // 
            this.lblThursday.AutoSize = true;
            this.lblThursday.Location = new System.Drawing.Point(60, 168);
            this.lblThursday.Name = "lblThursday";
            this.lblThursday.Size = new System.Drawing.Size(54, 13);
            this.lblThursday.TabIndex = 15;
            this.lblThursday.Text = "Thursday:";
            // 
            // lblFriday
            // 
            this.lblFriday.AutoSize = true;
            this.lblFriday.Location = new System.Drawing.Point(76, 194);
            this.lblFriday.Name = "lblFriday";
            this.lblFriday.Size = new System.Drawing.Size(38, 13);
            this.lblFriday.TabIndex = 16;
            this.lblFriday.Text = "Friday:";
            // 
            // lblSaturday
            // 
            this.lblSaturday.AutoSize = true;
            this.lblSaturday.Location = new System.Drawing.Point(63, 220);
            this.lblSaturday.Name = "lblSaturday";
            this.lblSaturday.Size = new System.Drawing.Size(52, 13);
            this.lblSaturday.TabIndex = 17;
            this.lblSaturday.Text = "Saturday:";
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Location = new System.Drawing.Point(73, 246);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(41, 13);
            this.lblWeek.TabIndex = 18;
            this.lblWeek.Text = "Set for:";
            // 
            // btnCreateSchedule
            // 
            this.btnCreateSchedule.Location = new System.Drawing.Point(76, 273);
            this.btnCreateSchedule.Name = "btnCreateSchedule";
            this.btnCreateSchedule.Size = new System.Drawing.Size(179, 23);
            this.btnCreateSchedule.TabIndex = 10;
            this.btnCreateSchedule.Text = "&Create";
            this.btnCreateSchedule.UseVisualStyleBackColor = true;
            this.btnCreateSchedule.Click += new System.EventHandler(this.btnCreateSchedule_Click);
            // 
            // frmScheduleAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 311);
            this.Controls.Add(this.btnCreateSchedule);
            this.Controls.Add(this.lblWeek);
            this.Controls.Add(this.lblSaturday);
            this.Controls.Add(this.lblFriday);
            this.Controls.Add(this.lblThursday);
            this.Controls.Add(this.lblWednesday);
            this.Controls.Add(this.lblTuesday);
            this.Controls.Add(this.lblMonday);
            this.Controls.Add(this.lblSunday);
            this.Controls.Add(this.cboWeek);
            this.Controls.Add(this.tbxSaturday);
            this.Controls.Add(this.tbxFriday);
            this.Controls.Add(this.tbxThursday);
            this.Controls.Add(this.tbxWednesday);
            this.Controls.Add(this.tbxTuesday);
            this.Controls.Add(this.tbxMonday);
            this.Controls.Add(this.tbxSunday);
            this.Controls.Add(this.cboEmployee);
            this.Controls.Add(this.lblFor);
            this.Controls.Add(this.mnuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuBar;
            this.Name = "frmScheduleAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Schedule";
            this.Load += new System.EventHandler(this.frmScheduleAdd_Load);
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.Label lblFor;
        private System.Windows.Forms.ComboBox cboEmployee;
        private System.Windows.Forms.TextBox tbxSunday;
        private System.Windows.Forms.TextBox tbxMonday;
        private System.Windows.Forms.TextBox tbxTuesday;
        private System.Windows.Forms.TextBox tbxWednesday;
        private System.Windows.Forms.TextBox tbxThursday;
        private System.Windows.Forms.TextBox tbxFriday;
        private System.Windows.Forms.TextBox tbxSaturday;
        private System.Windows.Forms.ComboBox cboWeek;
        private System.Windows.Forms.Label lblSunday;
        private System.Windows.Forms.Label lblMonday;
        private System.Windows.Forms.Label lblTuesday;
        private System.Windows.Forms.Label lblWednesday;
        private System.Windows.Forms.Label lblThursday;
        private System.Windows.Forms.Label lblFriday;
        private System.Windows.Forms.Label lblSaturday;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.Button btnCreateSchedule;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateSchedules;
    }
}