
namespace SP21_Final_Project
{
    partial class frmRecoverPassword
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
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.tbxEmailAddress = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblHelp = new System.Windows.Forms.Label();
            this.lblHelp2 = new System.Windows.Forms.Label();
            this.lblHelp3 = new System.Windows.Forms.Label();
            this.lblHelp4 = new System.Windows.Forms.Label();
            this.mnuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(78, 153);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(75, 23);
            this.btnSendEmail.TabIndex = 0;
            this.btnSendEmail.Text = "&Send Email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuBar.Location = new System.Drawing.Point(0, 0);
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(294, 24);
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
            this.mnuClose.Size = new System.Drawing.Size(180, 22);
            this.mnuClose.Text = "&Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // tbxUsername
            // 
            this.tbxUsername.Location = new System.Drawing.Point(78, 27);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(182, 20);
            this.tbxUsername.TabIndex = 2;
            // 
            // tbxEmailAddress
            // 
            this.tbxEmailAddress.Location = new System.Drawing.Point(78, 53);
            this.tbxEmailAddress.Name = "tbxEmailAddress";
            this.tbxEmailAddress.Size = new System.Drawing.Size(182, 20);
            this.tbxEmailAddress.TabIndex = 3;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 30);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(38, 56);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email";
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Location = new System.Drawing.Point(43, 86);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(218, 13);
            this.lblHelp.TabIndex = 6;
            this.lblHelp.Text = "The account will have its password changed";
            // 
            // lblHelp2
            // 
            this.lblHelp2.AutoSize = true;
            this.lblHelp2.Location = new System.Drawing.Point(43, 99);
            this.lblHelp2.Name = "lblHelp2";
            this.lblHelp2.Size = new System.Drawing.Size(236, 13);
            this.lblHelp2.TabIndex = 7;
            this.lblHelp2.Text = "to a randomly-generated number. Open the email";
            // 
            // lblHelp3
            // 
            this.lblHelp3.AutoSize = true;
            this.lblHelp3.Location = new System.Drawing.Point(43, 112);
            this.lblHelp3.Name = "lblHelp3";
            this.lblHelp3.Size = new System.Drawing.Size(237, 13);
            this.lblHelp3.TabIndex = 8;
            this.lblHelp3.Text = "and log in with the new password. The password";
            // 
            // lblHelp4
            // 
            this.lblHelp4.AutoSize = true;
            this.lblHelp4.Location = new System.Drawing.Point(43, 125);
            this.lblHelp4.Name = "lblHelp4";
            this.lblHelp4.Size = new System.Drawing.Size(160, 13);
            this.lblHelp4.TabIndex = 9;
            this.lblHelp4.Text = "can be changed after logging in.";
            // 
            // frmRecoverPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 192);
            this.Controls.Add(this.lblHelp4);
            this.Controls.Add(this.lblHelp3);
            this.Controls.Add(this.lblHelp2);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.tbxEmailAddress);
            this.Controls.Add(this.tbxUsername);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.mnuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuBar;
            this.Name = "frmRecoverPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Recovery";
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.TextBox tbxEmailAddress;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Label lblHelp2;
        private System.Windows.Forms.Label lblHelp3;
        private System.Windows.Forms.Label lblHelp4;
    }
}