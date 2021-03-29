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
            
            pbxProductImage.Image = imgProductImage;
            lblInfo.Text = strInfo;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
