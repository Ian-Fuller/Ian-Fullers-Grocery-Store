
namespace SP21_Final_Project
{
    partial class frmProductRemove
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductRemove));
            this.lblRemove = new System.Windows.Forms.Label();
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.cboToRemove = new System.Windows.Forms.ComboBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.mnuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.Location = new System.Drawing.Point(12, 32);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(129, 13);
            this.lblRemove.TabIndex = 0;
            this.lblRemove.Text = "Select product to remove:";
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
            this.mnuBar.Location = new System.Drawing.Point(0, 0);
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(228, 24);
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
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRemoveProduct});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuRemoveProduct
            // 
            this.mnuRemoveProduct.Name = "mnuRemoveProduct";
            this.mnuRemoveProduct.Size = new System.Drawing.Size(162, 22);
            this.mnuRemoveProduct.Text = "&Remove Product";
            this.mnuRemoveProduct.Click += new System.EventHandler(this.mnuRemoveProduct_Click);
            // 
            // cboToRemove
            // 
            this.cboToRemove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToRemove.FormattingEnabled = true;
            this.cboToRemove.Location = new System.Drawing.Point(12, 48);
            this.cboToRemove.Name = "cboToRemove";
            this.cboToRemove.Size = new System.Drawing.Size(204, 21);
            this.cboToRemove.TabIndex = 2;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(12, 76);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(204, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // frmProductRemove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 117);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.cboToRemove);
            this.Controls.Add(this.lblRemove);
            this.Controls.Add(this.mnuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuBar;
            this.Name = "frmProductRemove";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remove Product";
            this.Load += new System.EventHandler(this.frmProductRemove_Load);
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRemove;
        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.ComboBox cboToRemove;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveProduct;
    }
}