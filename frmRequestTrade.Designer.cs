
namespace SP21_Final_Project
{
    partial class frmRequestTrade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRequestTrade));
            this.btnRequest = new System.Windows.Forms.Button();
            this.tbxRequest = new System.Windows.Forms.TextBox();
            this.lblRequest = new System.Windows.Forms.Label();
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(64, 53);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(100, 35);
            this.btnRequest.TabIndex = 7;
            this.btnRequest.Text = "&Request";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // tbxRequest
            // 
            this.tbxRequest.Location = new System.Drawing.Point(64, 27);
            this.tbxRequest.Name = "tbxRequest";
            this.tbxRequest.Size = new System.Drawing.Size(524, 20);
            this.tbxRequest.TabIndex = 6;
            // 
            // lblRequest
            // 
            this.lblRequest.AutoSize = true;
            this.lblRequest.Location = new System.Drawing.Point(11, 30);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(50, 13);
            this.lblRequest.TabIndex = 5;
            this.lblRequest.Text = "Request:";
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuBar.Location = new System.Drawing.Point(0, 0);
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(602, 24);
            this.mnuBar.TabIndex = 4;
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
            // frmRequestTrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 105);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.tbxRequest);
            this.Controls.Add(this.lblRequest);
            this.Controls.Add(this.mnuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRequestTrade";
            this.Text = "Request Trade";
            this.Load += new System.EventHandler(this.frmRequestTrade_Load);
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.TextBox tbxRequest;
        private System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
    }
}