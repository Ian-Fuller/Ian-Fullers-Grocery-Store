using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace SP21_Final_Project
{
    public partial class frmRecoverPassword : Form
    {
        public frmRecoverPassword()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                //If proper input is entered, then an email will be generated and sent
                if (tbxUsername.Text == "" || tbxEmailAddress.Text == "")
                {
                    MessageBox.Show("Both fields must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int newPassword;
                    Random rand = new Random();
                    newPassword = rand.Next(10000, 100000);

                    DB.UpdatePassword(tbxUsername.Text.ToString(), newPassword.ToString());

                    MailMessage mail = new MailMessage();
                    SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("iansgrocerystore@gmail.com");
                    mail.To.Add(tbxEmailAddress.Text.ToString());
                    mail.Subject = "Password Recovery";
                    mail.Body = "Your new password is: " + newPassword.ToString();

                    smtpServer.Port = 587;
                    smtpServer.Credentials = new System.Net.NetworkCredential("iansgrocerystore@gmail.com", "onetwothreefour");
                    smtpServer.EnableSsl = true;

                    smtpServer.Send(mail);
                    MessageBox.Show("Email sent successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuPasswordRecovery_Click(object sender, EventArgs e)
        {
            Help.HelpForgotPassword();
        }

        private void frmRecoverPassword_Load(object sender, EventArgs e)
        {
            FormCloser.lstOpenedForms.Add(this);

            MaximizeBox = false;
        }

        private void mnuReturn_Click(object sender, EventArgs e)
        {
            FormCloser.returnToMain();
        }
    }
}
