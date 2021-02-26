//Programmer: Ian Fuller
//Course: INEW 2332.10z1
//Program purpose: Application that will allow the user to make purchases from a grocery store

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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DB.OpenDatabase();

            //Instantiates 6 test panels - will be removed later
            ProductPanel panel1 = new ProductPanel(this, 20, 20, "Apples");
            ProductPanel panel2 = new ProductPanel(this, 140, 20, "Apples");
            ProductPanel panel3 = new ProductPanel(this, 260, 20, "Apples");

            ProductPanel panel4 = new ProductPanel(this, 20, 200, "Apples");
            ProductPanel panel5 = new ProductPanel(this, 140, 200, "Apples");
            ProductPanel panel6 = new ProductPanel(this, 260, 200, "Apples");
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.CloseDatabase();
        }
    }
}
