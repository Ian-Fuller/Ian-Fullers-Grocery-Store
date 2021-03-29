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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strUserType = DB.Login(tbxUsername.Text, tbxPassword.Text);
            if (strUserType == "Employee")
            {
                frmEmployees employees = new frmEmployees();
                employees.ShowDialog();
            }
            else if(strUserType == "Manager")
            {
                frmManagers managers = new frmManagers();
                managers.ShowDialog();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
