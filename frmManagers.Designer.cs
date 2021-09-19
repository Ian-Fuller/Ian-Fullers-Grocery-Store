
namespace SP21_Final_Project
{
    partial class frmManagers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagers));
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManagersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManageProducts = new System.Windows.Forms.Button();
            this.btnManageSpecials = new System.Windows.Forms.Button();
            this.btnEmployeeScheduling = new System.Windows.Forms.Button();
            this.btnPrintReports = new System.Windows.Forms.Button();
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
            this.mnuBar.Size = new System.Drawing.Size(219, 24);
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
            // mnuReturn
            // 
            this.mnuReturn.Name = "mnuReturn";
            this.mnuReturn.Size = new System.Drawing.Size(180, 22);
            this.mnuReturn.Text = "Return to &Main";
            this.mnuReturn.Click += new System.EventHandler(this.mnuReturn_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuManagersMenu});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuManagersMenu
            // 
            this.mnuManagersMenu.Name = "mnuManagersMenu";
            this.mnuManagersMenu.Size = new System.Drawing.Size(160, 22);
            this.mnuManagersMenu.Text = "&Managers Menu";
            this.mnuManagersMenu.Click += new System.EventHandler(this.mnuManagersMenu_Click);
            // 
            // btnManageProducts
            // 
            this.btnManageProducts.Location = new System.Drawing.Point(12, 27);
            this.btnManageProducts.Name = "btnManageProducts";
            this.btnManageProducts.Size = new System.Drawing.Size(195, 23);
            this.btnManageProducts.TabIndex = 7;
            this.btnManageProducts.Text = "&Product Management";
            this.btnManageProducts.UseVisualStyleBackColor = true;
            this.btnManageProducts.Click += new System.EventHandler(this.btnManageProducts_Click);
            // 
            // btnManageSpecials
            // 
            this.btnManageSpecials.Location = new System.Drawing.Point(12, 56);
            this.btnManageSpecials.Name = "btnManageSpecials";
            this.btnManageSpecials.Size = new System.Drawing.Size(195, 23);
            this.btnManageSpecials.TabIndex = 8;
            this.btnManageSpecials.Text = "&Specials Management";
            this.btnManageSpecials.UseVisualStyleBackColor = true;
            this.btnManageSpecials.Click += new System.EventHandler(this.btnManageSpecials_Click);
            // 
            // btnEmployeeScheduling
            // 
            this.btnEmployeeScheduling.Location = new System.Drawing.Point(12, 85);
            this.btnEmployeeScheduling.Name = "btnEmployeeScheduling";
            this.btnEmployeeScheduling.Size = new System.Drawing.Size(195, 23);
            this.btnEmployeeScheduling.TabIndex = 9;
            this.btnEmployeeScheduling.Text = "&Employee Scheduling";
            this.btnEmployeeScheduling.UseVisualStyleBackColor = true;
            this.btnEmployeeScheduling.Click += new System.EventHandler(this.btnEmployeeScheduling_Click);
            // 
            // btnPrintReports
            // 
            this.btnPrintReports.Location = new System.Drawing.Point(12, 114);
            this.btnPrintReports.Name = "btnPrintReports";
            this.btnPrintReports.Size = new System.Drawing.Size(195, 23);
            this.btnPrintReports.TabIndex = 10;
            this.btnPrintReports.Text = "&Print Reports";
            this.btnPrintReports.UseVisualStyleBackColor = true;
            this.btnPrintReports.Click += new System.EventHandler(this.btnPrintReports_Click);
            // 
            // frmManagers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 152);
            this.Controls.Add(this.btnPrintReports);
            this.Controls.Add(this.btnEmployeeScheduling);
            this.Controls.Add(this.btnManageSpecials);
            this.Controls.Add(this.btnManageProducts);
            this.Controls.Add(this.mnuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuBar;
            this.Name = "frmManagers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Managers Menu";
            this.Load += new System.EventHandler(this.frmManagers_Load);
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.Button btnManageProducts;
        private System.Windows.Forms.Button btnManageSpecials;
        private System.Windows.Forms.Button btnEmployeeScheduling;
        private System.Windows.Forms.Button btnPrintReports;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuManagersMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuReturn;
    }
}