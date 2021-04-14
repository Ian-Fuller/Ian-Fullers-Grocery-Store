
namespace SP21_Final_Project
{
    partial class frmSpecialUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpecialUpdate));
            this.cboSpecials = new System.Windows.Forms.ComboBox();
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdateSpecial = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxNewValue = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.cboColumnName = new System.Windows.Forms.ComboBox();
            this.lblSet = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.mnuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSpecials
            // 
            this.cboSpecials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSpecials.FormattingEnabled = true;
            this.cboSpecials.Location = new System.Drawing.Point(12, 27);
            this.cboSpecials.Name = "cboSpecials";
            this.cboSpecials.Size = new System.Drawing.Size(171, 21);
            this.cboSpecials.TabIndex = 1;
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
            this.mnuBar.Location = new System.Drawing.Point(0, 0);
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(317, 24);
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
            this.mnuUpdateSpecial});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuUpdateSpecial
            // 
            this.mnuUpdateSpecial.Name = "mnuUpdateSpecial";
            this.mnuUpdateSpecial.Size = new System.Drawing.Size(152, 22);
            this.mnuUpdateSpecial.Text = "&Update Special";
            this.mnuUpdateSpecial.Click += new System.EventHandler(this.mnuUpdateSpecial_Click);
            // 
            // tbxNewValue
            // 
            this.tbxNewValue.Location = new System.Drawing.Point(194, 68);
            this.tbxNewValue.Name = "tbxNewValue";
            this.tbxNewValue.Size = new System.Drawing.Size(100, 20);
            this.tbxNewValue.TabIndex = 13;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(168, 71);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 12;
            this.lblTo.Text = "To";
            // 
            // cboColumnName
            // 
            this.cboColumnName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColumnName.FormattingEnabled = true;
            this.cboColumnName.Location = new System.Drawing.Point(41, 68);
            this.cboColumnName.Name = "cboColumnName";
            this.cboColumnName.Size = new System.Drawing.Size(121, 21);
            this.cboColumnName.TabIndex = 2;
            this.cboColumnName.SelectedIndexChanged += new System.EventHandler(this.cbxColumnName_SelectedIndexChanged);
            // 
            // lblSet
            // 
            this.lblSet.AutoSize = true;
            this.lblSet.Location = new System.Drawing.Point(12, 71);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(23, 13);
            this.lblSet.TabIndex = 10;
            this.lblSet.Text = "Set";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(86, 113);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(128, 43);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "&Update Special";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cboProduct
            // 
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(194, 67);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(100, 21);
            this.cboProduct.TabIndex = 3;
            this.cboProduct.Visible = false;
            // 
            // frmSpecialUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 177);
            this.Controls.Add(this.cboProduct);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbxNewValue);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.cboColumnName);
            this.Controls.Add(this.lblSet);
            this.Controls.Add(this.cboSpecials);
            this.Controls.Add(this.mnuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuBar;
            this.Name = "frmSpecialUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSpecialUpdate";
            this.Load += new System.EventHandler(this.frmSpecialUpdate_Load);
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSpecials;
        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.TextBox tbxNewValue;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.ComboBox cboColumnName;
        private System.Windows.Forms.Label lblSet;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdateSpecial;
    }
}