
namespace SP21_Final_Project
{
    partial class frmRespond
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRespond));
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRespond = new System.Windows.Forms.ToolStripMenuItem();
            this.lblID = new System.Windows.Forms.Label();
            this.cboID = new System.Windows.Forms.ComboBox();
            this.tbxRequest = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblRequest = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRespond = new System.Windows.Forms.Button();
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
            this.mnuBar.Size = new System.Drawing.Size(404, 24);
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
            this.mnuRespond});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuRespond
            // 
            this.mnuRespond.Name = "mnuRespond";
            this.mnuRespond.Size = new System.Drawing.Size(184, 22);
            this.mnuRespond.Text = "&Respond to Requests";
            this.mnuRespond.Click += new System.EventHandler(this.mnuRespond_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(38, 31);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(64, 13);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "Request ID:";
            // 
            // cboID
            // 
            this.cboID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboID.FormattingEnabled = true;
            this.cboID.Location = new System.Drawing.Point(108, 28);
            this.cboID.Name = "cboID";
            this.cboID.Size = new System.Drawing.Size(43, 21);
            this.cboID.TabIndex = 2;
            this.cboID.SelectedIndexChanged += new System.EventHandler(this.cbxID_SelectedIndexChanged);
            // 
            // tbxRequest
            // 
            this.tbxRequest.Location = new System.Drawing.Point(108, 55);
            this.tbxRequest.Name = "tbxRequest";
            this.tbxRequest.Size = new System.Drawing.Size(277, 20);
            this.tbxRequest.TabIndex = 3;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(108, 81);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(92, 21);
            this.cboStatus.TabIndex = 4;
            // 
            // lblRequest
            // 
            this.lblRequest.AutoSize = true;
            this.lblRequest.Location = new System.Drawing.Point(52, 58);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(50, 13);
            this.lblRequest.TabIndex = 5;
            this.lblRequest.Text = "Request:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 84);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(90, 13);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Change status to:";
            // 
            // btnRespond
            // 
            this.btnRespond.Location = new System.Drawing.Point(108, 109);
            this.btnRespond.Name = "btnRespond";
            this.btnRespond.Size = new System.Drawing.Size(170, 23);
            this.btnRespond.TabIndex = 7;
            this.btnRespond.Text = "&Respond";
            this.btnRespond.UseVisualStyleBackColor = true;
            this.btnRespond.Click += new System.EventHandler(this.btnRespond_Click);
            // 
            // frmRespond
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 148);
            this.Controls.Add(this.btnRespond);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblRequest);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.tbxRequest);
            this.Controls.Add(this.cboID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.mnuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuBar;
            this.Name = "frmRespond";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Respond to Request";
            this.Load += new System.EventHandler(this.frmRespond_Load);
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ComboBox cboID;
        private System.Windows.Forms.TextBox tbxRequest;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRespond;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuRespond;
    }
}