
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
            this.btnRequestTrade = new System.Windows.Forms.Button();
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRequestDayOff = new System.Windows.Forms.Button();
            this.btnChangeInfo = new System.Windows.Forms.Button();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.lblToday = new System.Windows.Forms.Label();
            this.lblTask = new System.Windows.Forms.Label();
            this.lblThisWeek = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.mnuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRequestTrade
            // 
            this.btnRequestTrade.Location = new System.Drawing.Point(12, 27);
            this.btnRequestTrade.Name = "btnRequestTrade";
            this.btnRequestTrade.Size = new System.Drawing.Size(143, 23);
            this.btnRequestTrade.TabIndex = 0;
            this.btnRequestTrade.Text = "Request work day &trade";
            this.btnRequestTrade.UseVisualStyleBackColor = true;
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
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
            // btnRequestDayOff
            // 
            this.btnRequestDayOff.Location = new System.Drawing.Point(12, 56);
            this.btnRequestDayOff.Name = "btnRequestDayOff";
            this.btnRequestDayOff.Size = new System.Drawing.Size(143, 23);
            this.btnRequestDayOff.TabIndex = 2;
            this.btnRequestDayOff.Text = "Request &day off";
            this.btnRequestDayOff.UseVisualStyleBackColor = true;
            // 
            // btnChangeInfo
            // 
            this.btnChangeInfo.Location = new System.Drawing.Point(12, 85);
            this.btnChangeInfo.Name = "btnChangeInfo";
            this.btnChangeInfo.Size = new System.Drawing.Size(143, 23);
            this.btnChangeInfo.TabIndex = 3;
            this.btnChangeInfo.Text = "&Change Information";
            this.btnChangeInfo.UseVisualStyleBackColor = true;
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Location = new System.Drawing.Point(165, 77);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.Size = new System.Drawing.Size(787, 83);
            this.dgvSchedule.TabIndex = 4;
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
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "&Print Schedule";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 450);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblThisWeek);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.lblToday);
            this.Controls.Add(this.dgvSchedule);
            this.Controls.Add(this.btnChangeInfo);
            this.Controls.Add(this.btnRequestDayOff);
            this.Controls.Add(this.btnRequestTrade);
            this.Controls.Add(this.mnuBar);
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
    }
}