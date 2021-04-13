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
        public static string strCurrentUser;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxUsername.Text.Length <= 30 && tbxPassword.Text.Length <= 30)
                {
                    string strUserType = DB.Login(tbxUsername.Text, tbxPassword.Text);
                    if (strUserType == "Employee")
                    {
                        strCurrentUser = tbxUsername.Text;
                        frmEmployees employees = new frmEmployees();
                        employees.ShowDialog();
                    }
                    else if (strUserType == "Manager")
                    {
                        strCurrentUser = tbxUsername.Text;
                        frmManagers managers = new frmManagers();
                        managers.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Username and password can only be 30 characters long.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error logging in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            try
            {
                frmRecoverPassword recover = new frmRecoverPassword();
                recover.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing page", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuLoginHelp_Click(object sender, EventArgs e)
        {
            Help.HelpLogin();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
