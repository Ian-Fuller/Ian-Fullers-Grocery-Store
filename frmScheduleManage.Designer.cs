
namespace SP21_Final_Project
{
    partial class frmScheduleManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScheduleManage));
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageSchedules = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.btnUpdateSchedule = new System.Windows.Forms.Button();
            this.btnRemoveSchedule = new System.Windows.Forms.Button();
            this.dgvSchedules = new System.Windows.Forms.DataGridView();
            this.lblRequests = new System.Windows.Forms.Label();
            this.btnRespond = new System.Windows.Forms.Button();
            this.mnuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
            this.mnuBar.Location = new System.Drawing.Point(0, 0);
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(800, 24);
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
            this.mnuManageSchedules});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuManageSchedules
            // 
            this.mnuManageSchedules.Name = "mnuManageSchedules";
            this.mnuManageSchedules.Size = new System.Drawing.Size(173, 22);
            this.mnuManageSchedules.Text = "&Manage Schedules";
            this.mnuManageSchedules.Click += new System.EventHandler(this.mnuManageSchedules_Click);
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Location = new System.Drawing.Point(13, 28);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(120, 23);
            this.btnAddSchedule.TabIndex = 1;
            this.btnAddSchedule.Text = "&Add Schedule";
            this.btnAddSchedule.UseVisualStyleBackColor = true;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // btnUpdateSchedule
            // 
            this.btnUpdateSchedule.Location = new System.Drawing.Point(12, 57);
            this.btnUpdateSchedule.Name = "btnUpdateSchedule";
            this.btnUpdateSchedule.Size = new System.Drawing.Size(121, 23);
            this.btnUpdateSchedule.TabIndex = 2;
            this.btnUpdateSchedule.Text = "&Update Schedule";
            this.btnUpdateSchedule.UseVisualStyleBackColor = true;
            this.btnUpdateSchedule.Click += new System.EventHandler(this.btnUpdateSchedule_Click);
            // 
            // btnRemoveSchedule
            // 
            this.btnRemoveSchedule.Location = new System.Drawing.Point(13, 86);
            this.btnRemoveSchedule.Name = "btnRemoveSchedule";
            this.btnRemoveSchedule.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveSchedule.TabIndex = 3;
            this.btnRemoveSchedule.Text = "&Remove Schedule";
            this.btnRemoveSchedule.UseVisualStyleBackColor = true;
            this.btnRemoveSchedule.Click += new System.EventHandler(this.btnRemoveSchedule_Click);
            // 
            // dgvSchedules
            // 
            this.dgvSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedules.Location = new System.Drawing.Point(140, 44);
            this.dgvSchedules.Name = "dgvSchedules";
            this.dgvSchedules.Size = new System.Drawing.Size(648, 394);
            this.dgvSchedules.TabIndex = 4;
            // 
            // lblRequests
            // 
            this.lblRequests.AutoSize = true;
            this.lblRequests.Location = new System.Drawing.Point(140, 28);
            this.lblRequests.Name = "lblRequests";
            this.lblRequests.Size = new System.Drawing.Size(90, 13);
            this.lblRequests.TabIndex = 5;
            this.lblRequests.Text = "Change requests:";
            // 
            // btnRespond
            // 
            this.btnRespond.Location = new System.Drawing.Point(13, 116);
            this.btnRespond.Name = "btnRespond";
            this.btnRespond.Size = new System.Drawing.Size(120, 23);
            this.btnRespond.TabIndex = 6;
            this.btnRespond.Text = "&Respond to Requests";
            this.btnRespond.UseVisualStyleBackColor = true;
            this.btnRespond.Click += new System.EventHandler(this.btnRespond_Click);
            // 
            // frmScheduleManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRespond);
            this.Controls.Add(this.lblRequests);
            this.Controls.Add(this.dgvSchedules);
            this.Controls.Add(this.btnRemoveSchedule);
            this.Controls.Add(this.btnUpdateSchedule);
            this.Controls.Add(this.btnAddSchedule);
            this.Controls.Add(this.mnuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuBar;
            this.Name = "frmScheduleManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Schedules";
            this.Load += new System.EventHandler(this.frmSheduleManage_Load);
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Button btnUpdateSchedule;
        private System.Windows.Forms.Button btnRemoveSchedule;
        private System.Windows.Forms.DataGridView dgvSchedules;
        private System.Windows.Forms.Label lblRequests;
        private System.Windows.Forms.Button btnRespond;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuManageSchedules;
    }
}