
namespace SP21_Final_Project
{
    partial class frmProductUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductUpdate));
            this.mnuBar = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.heloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdateProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.lblProduct = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.lblSet = new System.Windows.Forms.Label();
            this.cboColumnName = new System.Windows.Forms.ComboBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.tbxNewValue = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pbxProductImage = new System.Windows.Forms.PictureBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.mnuReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProductImage)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuBar
            // 
            this.mnuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.heloToolStripMenuItem});
            this.mnuBar.Location = new System.Drawing.Point(0, 0);
            this.mnuBar.Name = "mnuBar";
            this.mnuBar.Size = new System.Drawing.Size(322, 24);
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
            // heloToolStripMenuItem
            // 
            this.heloToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUpdateProduct});
            this.heloToolStripMenuItem.Name = "heloToolStripMenuItem";
            this.heloToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.heloToolStripMenuItem.Text = "&Help";
            // 
            // mnuUpdateProduct
            // 
            this.mnuUpdateProduct.Name = "mnuUpdateProduct";
            this.mnuUpdateProduct.Size = new System.Drawing.Size(157, 22);
            this.mnuUpdateProduct.Text = "&Update Product";
            this.mnuUpdateProduct.Click += new System.EventHandler(this.mnuUpdateProduct_Click);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(12, 34);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(95, 13);
            this.lblProduct.TabIndex = 1;
            this.lblProduct.Text = "Product to update:";
            // 
            // cboProduct
            // 
            this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(113, 31);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(121, 21);
            this.cboProduct.TabIndex = 1;
            // 
            // lblSet
            // 
            this.lblSet.AutoSize = true;
            this.lblSet.Location = new System.Drawing.Point(13, 71);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(23, 13);
            this.lblSet.TabIndex = 3;
            this.lblSet.Text = "Set";
            // 
            // cboColumnName
            // 
            this.cboColumnName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColumnName.FormattingEnabled = true;
            this.cboColumnName.Location = new System.Drawing.Point(42, 68);
            this.cboColumnName.Name = "cboColumnName";
            this.cboColumnName.Size = new System.Drawing.Size(121, 21);
            this.cboColumnName.TabIndex = 2;
            this.cboColumnName.SelectedIndexChanged += new System.EventHandler(this.cbxColumnName_SelectedIndexChanged);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(169, 71);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "To:";
            // 
            // tbxNewValue
            // 
            this.tbxNewValue.Location = new System.Drawing.Point(199, 68);
            this.tbxNewValue.Name = "tbxNewValue";
            this.tbxNewValue.Size = new System.Drawing.Size(100, 20);
            this.tbxNewValue.TabIndex = 3;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(77, 218);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(157, 57);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "&Update Product";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pbxProductImage
            // 
            this.pbxProductImage.Location = new System.Drawing.Point(199, 95);
            this.pbxProductImage.Name = "pbxProductImage";
            this.pbxProductImage.Size = new System.Drawing.Size(100, 100);
            this.pbxProductImage.TabIndex = 8;
            this.pbxProductImage.TabStop = false;
            this.pbxProductImage.Visible = false;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(199, 68);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(100, 23);
            this.btnSelectImage.TabIndex = 3;
            this.btnSelectImage.Text = "&Select Image";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Visible = false;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // mnuReturn
            // 
            this.mnuReturn.Name = "mnuReturn";
            this.mnuReturn.Size = new System.Drawing.Size(180, 22);
            this.mnuReturn.Text = "Return to &Main";
            this.mnuReturn.Click += new System.EventHandler(this.mnuReturn_Click);
            // 
            // frmProductUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 295);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.pbxProductImage);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbxNewValue);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.cboColumnName);
            this.Controls.Add(this.lblSet);
            this.Controls.Add(this.cboProduct);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.mnuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuBar;
            this.Name = "frmProductUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Product";
            this.Load += new System.EventHandler(this.frmProductUpdate_Load);
            this.mnuBar.ResumeLayout(false);
            this.mnuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProductImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuBar;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.Label lblSet;
        private System.Windows.Forms.ComboBox cboColumnName;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox tbxNewValue;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.PictureBox pbxProductImage;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.ToolStripMenuItem heloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdateProduct;
        private System.Windows.Forms.ToolStripMenuItem mnuReturn;
    }
}