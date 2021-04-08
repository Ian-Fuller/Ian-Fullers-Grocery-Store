using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP21_Final_Project
{
    public partial class frmSpecialAdd : Form
    {
        public frmSpecialAdd()
        {
            InitializeComponent();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSpecialAdd_Load(object sender, EventArgs e)
        {
            for (int intCurrentPanel = 0; intCurrentPanel < frmMain.lstPanels.Count; intCurrentPanel++)
            {
                cbxProducts.Items.Add(frmMain.lstPanels[intCurrentPanel].strProductName);
            }
        }

        private void btnAddSpecial_Click(object sender, EventArgs e)
        {
            bool bolDiscountValid = true;
            bool bolExtraDetailsValid = true;

            if(!Int32.TryParse(tbxDiscount.Text, out int intDiscount))
            {
                MessageBox.Show("Input discount as integer format.", "Add Special Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bolDiscountValid = false;
            }
            if(tbxExtraDetails.Text.Length > 50)
            {
                MessageBox.Show("Extra details can only be 50 characters long.", "Add Special Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bolExtraDetailsValid = false;
            }

            if(intDiscount < 0)
            {
                intDiscount *= -1;
            }

            if (bolDiscountValid && bolExtraDetailsValid)
            {
                try
                {
                    DB.AddSpecial(cbxProducts.Text, intDiscount, tbxExtraDetails.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add special.", "Add Special Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
