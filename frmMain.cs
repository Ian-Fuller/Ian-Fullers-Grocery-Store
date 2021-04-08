//Programmer: Ian Fuller
//Course: INEW 2332.10z1
//Program purpose: Application that will allow the user to make purchases from a grocery store

//improve comments
//Specials loading may fail the same way the other products did (when ID skips a few numbers)
//Schedule update not working
//frmMain needs to be able to refresh
//Reduce product quantity when purchasing
//Add receipt printing when manager updating product
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
        //Panel variables
        public static List<ProductPanel> lstPanels = new List<ProductPanel>();
        int intGroupSize = 8;
        List<ProductPanel[]> lstPanelGroups = new List<ProductPanel[]>();
        int[,] arrPanelPositions = new int[8, 2]
        {
            { 40, 44 },
            { 160, 44 },
            { 280, 44 },
            { 400, 44 },
            { 40, 249 },
            { 160, 249 },
            { 280, 249 },
            { 400, 249 }
        };
        int intGroupIndex = 0;

        //Special variables
        public static List<SpecialPanel> lstSpecials = new List<SpecialPanel>();
        int intSGroupSize = 2;
        List<SpecialPanel[]> lstSpecialGroups = new List<SpecialPanel[]>();
        int[,] arrSpecialPositions = new int[2, 2]
        {
            { 26, 43 },
            { 26, 248 }
        };
        int intSGroupIndex = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                DB.OpenDatabase();

                int intRowsCount = DB.GetRowsCount("Products");

                //Creates panels
                int intIDOffset = 0;
                for (int intCurrentRow = 0; intCurrentRow < intRowsCount; intCurrentRow++)
                {
                    if(DB.FillPanel(intCurrentRow + 1 + intIDOffset, lstPanels, 0, 0) == 1)
                    {
                        intIDOffset++;
                        intCurrentRow--;
                    }
                }

                int intGroupCount = (int)Math.Ceiling((double)intRowsCount / (double)intGroupSize);
                int intPanelIndex = 0;
                for(int intCurrentGroup = 0; intCurrentGroup < intGroupCount; intCurrentGroup++)
                {
                    lstPanelGroups.Add(new ProductPanel[intGroupSize]);
                    for(int intIndexInGroup = 0; intIndexInGroup < intGroupSize; intIndexInGroup++)
                    {
                        if(intPanelIndex < lstPanels.Count)
                        {
                            lstPanelGroups[intCurrentGroup][intIndexInGroup] = lstPanels[intPanelIndex];
                            lstPanelGroups[intCurrentGroup][intIndexInGroup].SetPosition(arrPanelPositions[intIndexInGroup, 0], arrPanelPositions[intIndexInGroup, 1]);
                            intPanelIndex++;
                        }
                        else
                        {
                            lstPanelGroups[intCurrentGroup][intIndexInGroup] = new ProductPanel();
                            intPanelIndex++;
                        }
                    }
                }

                //Shows panels
                for (int intIndexInGroup = 0; intIndexInGroup < lstPanelGroups[intGroupIndex].Length; intIndexInGroup++)
                {
                    lstPanelGroups[intGroupIndex][intIndexInGroup].ShowPanel(this);
                }

                //SPECIALS---------------------------------------------------------------------------------------------------------------------------------

                int intSpecialsCount = DB.GetRowsCount("Specials");

                intIDOffset = 0;
                for (int intCurrentRow = 0; intCurrentRow < intSpecialsCount; intCurrentRow++)
                {
                    if (DB.FillSpecialPanel(intCurrentRow + 1 + intIDOffset, lstSpecials, 0, 0) == 1)
                    {
                        intIDOffset++;
                        intCurrentRow--;
                    }
                }

                int intSGroupCount = (int)Math.Ceiling((double)intSpecialsCount / (double)intSGroupSize);
                int intSpecialIndex = 0;
                for(int intCurrentGroup = 0; intCurrentGroup < intSGroupCount; intCurrentGroup++)
                {
                    lstSpecialGroups.Add(new SpecialPanel[intSGroupSize]);
                    for(int intIndexInGroup = 0; intIndexInGroup < intSGroupSize; intIndexInGroup++)
                    {
                        if(intSpecialIndex < lstSpecials.Count)
                        {
                            lstSpecialGroups[intCurrentGroup][intIndexInGroup] = lstSpecials[intSpecialIndex];
                            lstSpecialGroups[intCurrentGroup][intIndexInGroup].SetPosition(arrSpecialPositions[intIndexInGroup, 0], arrSpecialPositions[intIndexInGroup, 1]);
                            intSpecialIndex++;
                        }
                        else
                        {
                            lstSpecialGroups[intCurrentGroup][intIndexInGroup] = new SpecialPanel();
                            intSpecialIndex++;
                        }
                    }
                }

                for(int intIndexInGroup = 0; intIndexInGroup < lstSpecialGroups[intGroupIndex].Length; intIndexInGroup++)
                {
                    lstSpecialGroups[intSGroupIndex][intIndexInGroup].ShowPanel(this.pnlSpecials);
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
            for (int intIndexInGroup = 0; intIndexInGroup < lstPanelGroups[intGroupIndex].Length; intIndexInGroup++)
            {
                lstPanelGroups[intGroupIndex][intIndexInGroup].HidePanel(this);
            }

            //Shows previous page of panels
            intGroupIndex--;
            if(intGroupIndex < 0)
            {
                intGroupIndex = lstPanelGroups.Count - 1;
            }
            for (int intIndexInGroup = 0; intIndexInGroup < lstPanelGroups[intGroupIndex].Length; intIndexInGroup++)
            {
                lstPanelGroups[intGroupIndex][intIndexInGroup].ShowPanel(this);
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            //Hides current panels
            for (int intIndexInGroup = 0; intIndexInGroup < lstPanelGroups[intGroupIndex].Length; intIndexInGroup++)
            {
                lstPanelGroups[intGroupIndex][intIndexInGroup].HidePanel(this);
            }

            //Shows previous page of panels
            intGroupIndex++;
            if(intGroupIndex == lstPanelGroups.Count)
            {
                intGroupIndex = 0;
            }
            for (int intIndexInGroup = 0; intIndexInGroup < lstPanelGroups[intGroupIndex].Length; intIndexInGroup++)
            {
                lstPanelGroups[intGroupIndex][intIndexInGroup].ShowPanel(this);
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.ShowDialog();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            for (int intIndexInGroup = 0; intIndexInGroup < lstSpecialGroups[intSGroupIndex].Length; intIndexInGroup++)
            {
                lstSpecialGroups[intSGroupIndex][intIndexInGroup].HidePanel(this.pnlSpecials);
            }

            intSGroupIndex--;
            if (intSGroupIndex < 0)
            {
                intSGroupIndex = lstSpecialGroups.Count - 1;
            }
            for (int intIndexInGroup = 0; intIndexInGroup < lstSpecialGroups[intSGroupIndex].Length; intIndexInGroup++)
            {
                lstSpecialGroups[intSGroupIndex][intIndexInGroup].ShowPanel(this.pnlSpecials);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            //Hides current panels
            for (int intIndexInGroup = 0; intIndexInGroup < lstSpecialGroups[intSGroupIndex].Length; intIndexInGroup++)
            {
                lstSpecialGroups[intSGroupIndex][intIndexInGroup].HidePanel(this.pnlSpecials);
            }

            //Shows previous page of panels
            intSGroupIndex++;
            if (intSGroupIndex == lstSpecialGroups.Count)
            {
                intSGroupIndex = 0;
            }
            for (int intIndexInGroup = 0; intIndexInGroup < lstSpecialGroups[intSGroupIndex].Length; intIndexInGroup++)
            {
                lstSpecialGroups[intSGroupIndex][intIndexInGroup].ShowPanel(this.pnlSpecials);
            }
        }

        private void shoppingCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShoppingCart cart = new frmShoppingCart();
            cart.ShowDialog();
        }
    }
}
