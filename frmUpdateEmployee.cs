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
    public partial class frmUpdateEmployee : Form
    {
        public frmUpdateEmployee()
        {
            InitializeComponent();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdateEmployee_Load(object sender, EventArgs e)
        {
            try
            {
                MaximizeBox = false;

                string[] arrInfo = DB.GetEmployeeInformation(frmLogin.strCurrentUser);

                tbxFirstName.Text = arrInfo[0];
                tbxLastName.Text = arrInfo[1];
                tbxAddress.Text = arrInfo[2];
                tbxUsername.Text = arrInfo[3];
                tbxPassword.Text = arrInfo[4];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DB.UpdateEmployeeInformation(frmLogin.strCurrentUser, tbxFirstName.Text, tbxLastName.Text, tbxAddress.Text, tbxUsername.Text, tbxPassword.Text);
        }
    }
}
