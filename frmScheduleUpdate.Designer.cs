
namespace SP21_Final_Project
{
    partial class frmScheduleUpdate
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
            this.btnUpdateSchedule = new System.Windows.Forms.Button();
            this.lblWeek = new System.Windows.Forms.Label();
            this.lblSaturday = new System.Windows.Forms.Label();
            this.lblFriday = new System.Windows.Forms.Label();
            this.lblThursday = new System.Windows.Forms.Label();
            this.lblWednesday = new System.Windows.Forms.Label();
            this.lblTuesday = new System.Windows.Forms.Label();
            this.lblMonday = new System.Windows.Forms.Label();
            this.lblSunday = new System.Windows.Forms.Label();
            this.cbxWeek = new System.Windows.Forms.ComboBox();
            this.tbxSaturday = new System.Windows.Forms.TextBox();
            this.tbxFriday = new System.Windows.Forms.TextBox();
            this.tbxThursday = new System.Windows.Forms.TextBox();
            this.tbxWednesday = new System.Windows.Forms.TextBox();
            this.tbxTuesday = new System.Windows.Forms.TextBox();
            this.tbxMonday = new System.Windows.Forms.TextBox();
            this.tbxSunday = new System.Windows.Forms.TextBox();
            this.cbxEmployee = new System.Windows.Forms.ComboBox();
            this.lblFor = new System.Windows.Forms.Label();
            this.mnuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuBar.Location = new System.Drawing.Point(0, 0);
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(351, 24);
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
            // btnUpdateSchedule
            // 
            this.btnUpdateSchedule.Location = new System.Drawing.Point(74, 273);
            this.btnUpdateSchedule.Name = "btnUpdateSchedule";
            this.btnUpdateSchedule.Size = new System.Drawing.Size(179, 23);
            this.btnUpdateSchedule.TabIndex = 38;
            this.btnUpdateSchedule.Text = "&Update";
            this.btnUpdateSchedule.UseVisualStyleBackColor = true;
            this.btnUpdateSchedule.Click += new System.EventHandler(this.btnUpdateSchedule_Click);
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Location = new System.Drawing.Point(73, 63);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(39, 13);
            this.lblWeek.TabIndex = 37;
            this.lblWeek.Text = "Week:";
            // 
            // lblSaturday
            // 
            this.lblSaturday.AutoSize = true;
            this.lblSaturday.Location = new System.Drawing.Point(61, 247);
            this.lblSaturday.Name = "lblSaturday";
            this.lblSaturday.Size = new System.Drawing.Size(52, 13);
            this.lblSaturday.TabIndex = 36;
            this.lblSaturday.Text = "Saturday:";
            // 
            // lblFriday
            // 
            this.lblFriday.AutoSize = true;
            this.lblFriday.Location = new System.Drawing.Point(74, 221);
            this.lblFriday.Name = "lblFriday";
            this.lblFriday.Size = new System.Drawing.Size(38, 13);
            this.lblFriday.TabIndex = 35;
            this.lblFriday.Text = "Friday:";
            // 
            // lblThursday
            // 
            this.lblThursday.AutoSize = true;
            this.lblThursday.Location = new System.Drawing.Point(58, 195);
            this.lblThursday.Name = "lblThursday";
            this.lblThursday.Size = new System.Drawing.Size(54, 13);
            this.lblThursday.TabIndex = 34;
            this.lblThursday.Text = "Thursday:";
            // 
            // lblWednesday
            // 
            this.lblWednesday.AutoSize = true;
            this.lblWednesday.Location = new System.Drawing.Point(45, 169);
            this.lblWednesday.Name = "lblWednesday";
            this.lblWednesday.Size = new System.Drawing.Size(67, 13);
            this.lblWednesday.TabIndex = 33;
            this.lblWednesday.Text = "Wednesday:";
            // 
            // lblTuesday
            // 
            this.lblTuesday.AutoSize = true;
            this.lblTuesday.Location = new System.Drawing.Point(61, 143);
            this.lblTuesday.Name = "lblTuesday";
            this.lblTuesday.Size = new System.Drawing.Size(51, 13);
            this.lblTuesday.TabIndex = 32;
            this.lblTuesday.Text = "Tuesday:";
            // 
            // lblMonday
            // 
            this.lblMonday.AutoSize = true;
            this.lblMonday.Location = new System.Drawing.Point(64, 117);
            this.lblMonday.Name = "lblMonday";
            this.lblMonday.Size = new System.Drawing.Size(48, 13);
            this.lblMonday.TabIndex = 31;
            this.lblMonday.Text = "Monday:";
            // 
            // lblSunday
            // 
            this.lblSunday.AutoSize = true;
            this.lblSunday.Location = new System.Drawing.Point(66, 91);
            this.lblSunday.Name = "lblSunday";
            this.lblSunday.Size = new System.Drawing.Size(46, 13);
            this.lblSunday.TabIndex = 30;
            this.lblSunday.Text = "Sunday:";
            // 
            // cbxWeek
            // 
            this.cbxWeek.FormattingEnabled = true;
            this.cbxWeek.Location = new System.Drawing.Point(118, 60);
            this.cbxWeek.Name = "cbxWeek";
            this.cbxWeek.Size = new System.Drawing.Size(107, 21);
            this.cbxWeek.TabIndex = 29;
            this.cbxWeek.SelectedIndexChanged += new System.EventHandler(this.cbxWeek_SelectedIndexChanged);
            // 
            // tbxSaturday
            // 
            this.tbxSaturday.Location = new System.Drawing.Point(118, 244);
            this.tbxSaturday.Name = "tbxSaturday";
            this.tbxSaturday.Size = new System.Drawing.Size(217, 20);
            this.tbxSaturday.TabIndex = 28;
            // 
            // tbxFriday
            // 
            this.tbxFriday.Location = new System.Drawing.Point(118, 218);
            this.tbxFriday.Name = "tbxFriday";
            this.tbxFriday.Size = new System.Drawing.Size(217, 20);
            this.tbxFriday.TabIndex = 27;
            // 
            // tbxThursday
            // 
            this.tbxThursday.Location = new System.Drawing.Point(118, 192);
            this.tbxThursday.Name = "tbxThursday";
            this.tbxThursday.Size = new System.Drawing.Size(217, 20);
            this.tbxThursday.TabIndex = 26;
            // 
            // tbxWednesday
            // 
            this.tbxWednesday.Location = new System.Drawing.Point(118, 166);
            this.tbxWednesday.Name = "tbxWednesday";
            this.tbxWednesday.Size = new System.Drawing.Size(217, 20);
            this.tbxWednesday.TabIndex = 25;
            // 
            // tbxTuesday
            // 
            this.tbxTuesday.Location = new System.Drawing.Point(118, 140);
            this.tbxTuesday.Name = "tbxTuesday";
            this.tbxTuesday.Size = new System.Drawing.Size(217, 20);
            this.tbxTuesday.TabIndex = 24;
            // 
            // tbxMonday
            // 
            this.tbxMonday.Location = new System.Drawing.Point(118, 114);
            this.tbxMonday.Name = "tbxMonday";
            this.tbxMonday.Size = new System.Drawing.Size(217, 20);
            this.tbxMonday.TabIndex = 23;
            // 
            // tbxSunday
            // 
            this.tbxSunday.Location = new System.Drawing.Point(118, 88);
            this.tbxSunday.Name = "tbxSunday";
            this.tbxSunday.Size = new System.Drawing.Size(217, 20);
            this.tbxSunday.TabIndex = 22;
            // 
            // cbxEmployee
            // 
            this.cbxEmployee.FormattingEnabled = true;
            this.cbxEmployee.Location = new System.Drawing.Point(118, 33);
            this.cbxEmployee.Name = "cbxEmployee";
            this.cbxEmployee.Size = new System.Drawing.Size(217, 21);
            this.cbxEmployee.TabIndex = 21;
            this.cbxEmployee.SelectedIndexChanged += new System.EventHandler(this.cbxEmployee_SelectedIndexChanged);
            // 
            // lblFor
            // 
            this.lblFor.AutoSize = true;
            this.lblFor.Location = new System.Drawing.Point(6, 36);
            this.lblFor.Name = "lblFor";
            this.lblFor.Size = new System.Drawing.Size(106, 13);
            this.lblFor.TabIndex = 20;
            this.lblFor.Text = "Update schedule for:";
            // 
            // frmScheduleUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 315);
            this.Controls.Add(this.btnUpdateSchedule);
            this.Controls.Add(this.lblWeek);
            this.Controls.Add(this.lblSaturday);
            this.Controls.Add(this.lblFriday);
            this.Controls.Add(this.lblThursday);
            this.Controls.Add(this.lblWednesday);
            this.Controls.Add(this.lblTuesday);
            this.Controls.Add(this.lblMonday);
            this.Controls.Add(this.lblSunday);
            this.Controls.Add(this.cbxWeek);
            this.Controls.Add(this.tbxSaturday);
            this.Controls.Add(this.tbxFriday);
            this.Controls.Add(this.tbxThursday);
            this.Controls.Add(this.tbxWednesday);
            this.Controls.Add(this.tbxTuesday);
            this.Controls.Add(this.tbxMonday);
            this.Controls.Add(this.tbxSunday);
            this.Controls.Add(this.cbxEmployee);
            this.Controls.Add(this.lblFor);
            this.Controls.Add(this.mnuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuBar;
            this.Name = "frmScheduleUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Schedule";
            this.Load += new System.EventHandler(this.frmScheduleUpdate_Load);
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.Button btnUpdateSchedule;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.Label lblSaturday;
        private System.Windows.Forms.Label lblFriday;
        private System.Windows.Forms.Label lblThursday;
        private System.Windows.Forms.Label lblWednesday;
        private System.Windows.Forms.Label lblTuesday;
        private System.Windows.Forms.Label lblMonday;
        private System.Windows.Forms.Label lblSunday;
        private System.Windows.Forms.ComboBox cbxWeek;
        private System.Windows.Forms.TextBox tbxSaturday;
        private System.Windows.Forms.TextBox tbxFriday;
        private System.Windows.Forms.TextBox tbxThursday;
        private System.Windows.Forms.TextBox tbxWednesday;
        private System.Windows.Forms.TextBox tbxTuesday;
        private System.Windows.Forms.TextBox tbxMonday;
        private System.Windows.Forms.TextBox tbxSunday;
        private System.Windows.Forms.ComboBox cbxEmployee;
        private System.Windows.Forms.Label lblFor;
    }
}