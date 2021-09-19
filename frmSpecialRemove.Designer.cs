﻿
namespace SP21_Final_Project
{
    partial class frmSpecialRemove
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpecialRemove));
            this.btnRemove = new System.Windows.Forms.Button();
            this.cboToRemove = new System.Windows.Forms.ComboBox();
            this.lblRemove = new System.Windows.Forms.Label();
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveSpecial = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(12, 67);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(204, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // cboToRemove
            // 
            this.cboToRemove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToRemove.FormattingEnabled = true;
            this.cboToRemove.Location = new System.Drawing.Point(12, 40);
            this.cboToRemove.Name = "cboToRemove";
            this.cboToRemove.Size = new System.Drawing.Size(204, 21);
            this.cboToRemove.TabIndex = 1;
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.Location = new System.Drawing.Point(9, 24);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(126, 13);
            this.lblRemove.TabIndex = 4;
            this.lblRemove.Text = "Select special to remove:";
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
            this.mnuBar.Location = new System.Drawing.Point(0, 0);
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(232, 24);
            this.mnuBar.TabIndex = 7;
            this.mnuBar.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClose,
            this.mnuReturn});
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
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRemoveSpecial});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuRemoveSpecial
            // 
            this.mnuRemoveSpecial.Name = "mnuRemoveSpecial";
            this.mnuRemoveSpecial.Size = new System.Drawing.Size(157, 22);
            this.mnuRemoveSpecial.Text = "&Remove Special";
            this.mnuRemoveSpecial.Click += new System.EventHandler(this.mnuRemoveSpecial_Click);
            // 
            // mnuReturn
            // 
            this.mnuReturn.Name = "mnuReturn";
            this.mnuReturn.Size = new System.Drawing.Size(180, 22);
            this.mnuReturn.Text = "Return to &Main";
            this.mnuReturn.Click += new System.EventHandler(this.mnuReturn_Click);
            // 
            // frmSpecialRemove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 106);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.cboToRemove);
            this.Controls.Add(this.lblRemove);
            this.Controls.Add(this.mnuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuBar;
            this.Name = "frmSpecialRemove";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remove Special";
            this.Load += new System.EventHandler(this.frmSpecialRemove_Load);
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ComboBox cboToRemove;
        private System.Windows.Forms.Label lblRemove;
        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveSpecial;
        private System.Windows.Forms.ToolStripMenuItem mnuReturn;
    }
}