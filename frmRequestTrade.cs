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
    public partial class frmRequestTrade : Form
    {
        public frmRequestTrade()
        {
            InitializeComponent();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            DB.MakeRequest(frmLogin.strCurrentUser, "(Trade)", tbxRequest.Text);
        }

        private void frmRequestTrade_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
