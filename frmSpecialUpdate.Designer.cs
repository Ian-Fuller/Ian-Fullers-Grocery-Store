
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
            this.cbxSpecials = new System.Windows.Forms.ComboBox();
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxNewValue = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.cbxColumnName = new System.Windows.Forms.ComboBox();
            this.lblSet = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbxProduct = new System.Windows.Forms.ComboBox();
            this.mnuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxSpecials
            // 
            this.cbxSpecials.FormattingEnabled = true;
            this.cbxSpecials.Location = new System.Drawing.Point(12, 27);
            this.cbxSpecials.Name = "cbxSpecials";
            this.cbxSpecials.Size = new System.Drawing.Size(171, 21);
            this.cbxSpecials.TabIndex = 0;
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
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
            // cbxColumnName
            // 
            this.cbxColumnName.FormattingEnabled = true;
            this.cbxColumnName.Location = new System.Drawing.Point(41, 68);
            this.cbxColumnName.Name = "cbxColumnName";
            this.cbxColumnName.Size = new System.Drawing.Size(121, 21);
            this.cbxColumnName.TabIndex = 11;
            this.cbxColumnName.SelectedIndexChanged += new System.EventHandler(this.cbxColumnName_SelectedIndexChanged);
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
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "&Update Special";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbxProduct
            // 
            this.cbxProduct.FormattingEnabled = true;
            this.cbxProduct.Location = new System.Drawing.Point(194, 67);
            this.cbxProduct.Name = "cbxProduct";
            this.cbxProduct.Size = new System.Drawing.Size(100, 21);
            this.cbxProduct.TabIndex = 15;
            this.cbxProduct.Visible = false;
            // 
            // frmSpecialUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 177);
            this.Controls.Add(this.cbxProduct);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbxNewValue);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.cbxColumnName);
            this.Controls.Add(this.lblSet);
            this.Controls.Add(this.cbxSpecials);
            this.Controls.Add(this.mnuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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

        private System.Windows.Forms.ComboBox cbxSpecials;
        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.TextBox tbxNewValue;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.ComboBox cbxColumnName;
        private System.Windows.Forms.Label lblSet;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cbxProduct;
    }
}