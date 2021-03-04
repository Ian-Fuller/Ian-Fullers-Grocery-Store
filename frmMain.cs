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

            List<ProductPanel> lstPanels = new List<ProductPanel>();
            int intRowsCount = DB.GetRowsCount();
            
            for(int i = 0; i < intRowsCount; i++)
            {
                DB.FillPanel(i + 1, lstPanels, i * 120 + 20, 20);
            }

            for(int i = 0; i < lstPanels.Count; i++)
            {
                lstPanels[i].ShowPanel(this);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.CloseDatabase();
        }
    }
}
