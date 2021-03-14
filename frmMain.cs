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
        //Class variables
        List<ProductPanel> lstPanels = new List<ProductPanel>();
        int intGroupSize = 8;
        List<ProductPanel[]> lstPanelGroups = new List<ProductPanel[]>();
        int[,] arrPanelPositions = new int[8, 2]
        {
            { 40, 20 },
            { 160, 20 },
            { 280, 20 },
            { 400, 20 },
            { 40, 225 },
            { 160, 225 },
            { 280, 225 },
            { 400, 225 }
        };
        int intGroupIndex = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                DB.OpenDatabase();

                int intRowsCount = DB.GetRowsCount();

                //Creates panels
                for (int i = 0; i < intRowsCount; i++)
                {
                    DB.FillPanel(i + 1, lstPanels, 0, 0);
                }

                int intGroupCount = intRowsCount / intGroupSize + 1;
                int intPanelIndex = 0;
                for(int i = 0; i < intGroupCount; i++)
                {
                    lstPanelGroups.Add(new ProductPanel[intGroupSize]);
                    for(int j = 0; j < intGroupSize; j++)
                    {
                        if(intPanelIndex < lstPanels.Count)
                        {
                            lstPanelGroups[i][j] = lstPanels[intPanelIndex];
                            lstPanelGroups[i][j].SetPosition(arrPanelPositions[j, 0], arrPanelPositions[j, 1]);
                            intPanelIndex++;
                        }
                        else
                        {
                            lstPanelGroups[i][j] = new ProductPanel();
                            intPanelIndex++;
                        }
                    }
                }

                //Shows panels
                for (int i = 0; i < lstPanelGroups[intGroupIndex].Length; i++)
                {
                    lstPanelGroups[intGroupIndex][i].ShowPanel(this);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading form.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.CloseDatabase();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            //Hides current panels
            for (int i = 0; i < lstPanelGroups[intGroupIndex].Length; i++)
            {
                lstPanelGroups[intGroupIndex][i].HidePanel(this);
            }

            //Shows previous page of panels
            intGroupIndex--;
            if(intGroupIndex < 0)
            {
                intGroupIndex = lstPanelGroups.Count - 1;
            }
            for (int i = 0; i < lstPanelGroups[intGroupIndex].Length; i++)
            {
                lstPanelGroups[intGroupIndex][i].ShowPanel(this);
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            //Hides current panels
            for (int i = 0; i < lstPanelGroups[intGroupIndex].Length; i++)
            {
                lstPanelGroups[intGroupIndex][i].HidePanel(this);
            }

            //Shows previous page of panels
            intGroupIndex++;
            if(intGroupIndex == lstPanelGroups.Count)
            {
                intGroupIndex = 0;
            }
            for (int i = 0; i < lstPanelGroups[intGroupIndex].Length; i++)
            {
                lstPanelGroups[intGroupIndex][i].ShowPanel(this);
            }
        }
    }
}
