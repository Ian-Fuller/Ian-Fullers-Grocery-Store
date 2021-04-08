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
    public partial class frmRespond : Form
    {
        List<string[]> lstRequests;

        public frmRespond()
        {
            InitializeComponent();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRespond_Load(object sender, EventArgs e)
        {
            lstRequests = DB.GetRequests();

            for(int intCurrentID = 0; intCurrentID < lstRequests.Count; intCurrentID++)
            {
                cbxID.Items.Add(lstRequests[intCurrentID][0]);
            }
            cbxID.Text = lstRequests[0][0];

            tbxRequest.Text = lstRequests[0][1];

            cbxStatus.Items.Add("Unread");
            cbxStatus.Items.Add("Accepted");
            cbxStatus.Items.Add("Declined");
            cbxStatus.Text = lstRequests[0][2];
        }

        private void cbxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxRequest.Text = lstRequests[cbxID.SelectedIndex][1];
            cbxStatus.Text = lstRequests[cbxID.SelectedIndex][2];
        }

        private void btnRespond_Click(object sender, EventArgs e)
        {
            Int32.TryParse(cbxID.Text, out int intRequestID);
            DB.UpdateRequest(intRequestID, cbxStatus.Text);
        }
    }
}
