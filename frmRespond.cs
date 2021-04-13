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
            try
            {
                MaximizeBox = false;

                lstRequests = DB.GetRequests();

                //Fills the first combo box with the requests
                for (int intCurrentID = 0; intCurrentID < lstRequests.Count; intCurrentID++)
                {
                    cboID.Items.Add(lstRequests[intCurrentID][0]);
                }
                cboID.Text = lstRequests[0][0];

                tbxRequest.Text = lstRequests[0][1];

                //Fills the second combo box with responses
                cboStatus.Items.Add("Unread");
                cboStatus.Items.Add("Accepted");
                cboStatus.Items.Add("Declined");
                cboStatus.Text = lstRequests[0][2];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //fills the textbox and second combo box with new data when the first combo box is changed
                tbxRequest.Text = lstRequests[cboID.SelectedIndex][1];
                cboStatus.Text = lstRequests[cboID.SelectedIndex][2];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting request", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRespond_Click(object sender, EventArgs e)
        {
            Int32.TryParse(cboID.Text, out int intRequestID);
            DB.UpdateRequest(intRequestID, cboStatus.Text);
        }

        private void mnuRespond_Click(object sender, EventArgs e)
        {
            Help.HelpRespond();
        }
    }
}
