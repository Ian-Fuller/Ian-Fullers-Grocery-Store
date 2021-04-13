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
    public partial class frmMoreInfo : Form
    {
        public frmMoreInfo(Image imgProductImage, string strInfo)
        {
            InitializeComponent();

            try
            {
                pbxProductImage.Image = imgProductImage;
                lblInfo.Text = strInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMoreInfo_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
