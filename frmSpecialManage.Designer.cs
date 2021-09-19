
namespace SP21_Final_Project
{
    partial class frmSpecialManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpecialManage));
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdateSpecial = new System.Windows.Forms.Button();
            this.btnRemoveSpecial = new System.Windows.Forms.Button();
            this.btnAddNewSpecial = new System.Windows.Forms.Button();
            this.mnuReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuBar.Location = new System.Drawing.Point(0, 0);
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(230, 24);
            this.mnuBar.TabIndex = 0;
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
            // btnUpdateSpecial
            // 
            this.btnUpdateSpecial.Location = new System.Drawing.Point(12, 85);
            this.btnUpdateSpecial.Name = "btnUpdateSpecial";
            this.btnUpdateSpecial.Size = new System.Drawing.Size(206, 23);
            this.btnUpdateSpecial.TabIndex = 3;
            this.btnUpdateSpecial.Text = "&Update special";
            this.btnUpdateSpecial.UseVisualStyleBackColor = true;
            this.btnUpdateSpecial.Click += new System.EventHandler(this.btnUpdateSpecial_Click);
            // 
            // btnRemoveSpecial
            // 
            this.btnRemoveSpecial.Location = new System.Drawing.Point(12, 56);
            this.btnRemoveSpecial.Name = "btnRemoveSpecial";
            this.btnRemoveSpecial.Size = new System.Drawing.Size(206, 23);
            this.btnRemoveSpecial.TabIndex = 2;
            this.btnRemoveSpecial.Text = "&Remove special";
            this.btnRemoveSpecial.UseVisualStyleBackColor = true;
            this.btnRemoveSpecial.Click += new System.EventHandler(this.btnRemoveSpecial_Click);
            // 
            // btnAddNewSpecial
            // 
            this.btnAddNewSpecial.Location = new System.Drawing.Point(12, 27);
            this.btnAddNewSpecial.Name = "btnAddNewSpecial";
            this.btnAddNewSpecial.Size = new System.Drawing.Size(206, 23);
            this.btnAddNewSpecial.TabIndex = 1;
            this.btnAddNewSpecial.Text = "&Add new special";
            this.btnAddNewSpecial.UseVisualStyleBackColor = true;
            this.btnAddNewSpecial.Click += new System.EventHandler(this.btnAddNewSpecial_Click);
            // 
            // mnuReturn
            // 
            this.mnuReturn.Name = "mnuReturn";
            this.mnuReturn.Size = new System.Drawing.Size(180, 22);
            this.mnuReturn.Text = "Return to &Main";
            this.mnuReturn.Click += new System.EventHandler(this.mnuReturn_Click);
            // 
            // frmSpecialManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 126);
            this.Controls.Add(this.btnUpdateSpecial);
            this.Controls.Add(this.btnRemoveSpecial);
            this.Controls.Add(this.btnAddNewSpecial);
            this.Controls.Add(this.mnuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuBar;
            this.Name = "frmSpecialManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSpecialManage";
            this.Load += new System.EventHandler(this.frmSpecialManage_Load);
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.Button btnUpdateSpecial;
        private System.Windows.Forms.Button btnRemoveSpecial;
        private System.Windows.Forms.Button btnAddNewSpecial;
        private System.Windows.Forms.ToolStripMenuItem mnuReturn;
    }
}