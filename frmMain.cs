//Programmer: Ian Fuller
//Course: INEW 2332.10z1
//Program purpose: Application that will allow the user to make purchases from a grocery store

//improve comments
//continue adding try/catch at frmProductManage
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
        static int intGroupSize = 8;
        static List<ProductPanel[]> lstPanelGroups = new List<ProductPanel[]>();
        static int[,] arrPanelPositions = new int[8, 2]
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
        static int intGroupIndex = 0;

        //Special variables
        public static List<SpecialPanel> lstSpecials = new List<SpecialPanel>();
        static int intSGroupSize = 2;
        static List<SpecialPanel[]> lstSpecialGroups = new List<SpecialPanel[]>();
        static int[,] arrSpecialPositions = new int[2, 2]
        {
            { 26, 43 },
            { 26, 248 }
        };
        static int intSGroupIndex = 0;

        //Static reference to frmMain
        public static frmMain MainForm;
        //Static reference to Specials panel
        public static Panel SpecialsPanel;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                MaximizeBox = false;

                MainForm = this;
                SpecialsPanel = pnlSpecials;

                DB.OpenDatabase();

                FillRefreshPanelData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading form.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.CloseDatabase();
        }

        //Function that is called upon the form loading, after data is changed, or if the refresh button is pressed
        public static void FillRefreshPanelData()
        {
            try
            {
                //Clears lists and removes panels from the form
                lstPanels.Clear();
                for (int intCurrentGroup = 0; intCurrentGroup < lstPanelGroups.Count; intCurrentGroup++)
                {
                    for (int intCurrentPanel = 0; intCurrentPanel < lstPanelGroups[intCurrentGroup].Length; intCurrentPanel++)
                    {
                        lstPanelGroups[intCurrentGroup][intCurrentPanel].RemoveFromParent(MainForm);
                    }
                }
                lstPanelGroups.Clear();
                lstSpecials.Clear();
                for (int intCurrentGroup = 0; intCurrentGroup < lstSpecialGroups.Count; intCurrentGroup++)
                {
                    for (int intCurrentPanel = 0; intCurrentPanel < lstSpecialGroups[intCurrentGroup].Length; intCurrentPanel++)
                    {
                        lstSpecialGroups[intCurrentGroup][intCurrentPanel].RemoveFromParent(SpecialsPanel);
                    }
                }
                lstSpecialGroups.Clear();

                //REGULAR PANELS START---------------------------------------------------------------------------------------------------------------------------------------
                DB.FillRefreshPanels(lstPanels);
                //Separates panels into groups and gives them positions
                int intGroupCount = (int)Math.Ceiling((double)lstPanels.Count / (double)intGroupSize);
                int intPanelIndex = 0;
                for (int intCurrentGroup = 0; intCurrentGroup < intGroupCount; intCurrentGroup++)
                {
                    lstPanelGroups.Add(new ProductPanel[intGroupSize]);
                    for (int intIndexInGroup = 0; intIndexInGroup < intGroupSize; intIndexInGroup++)
                    {
                        if (intPanelIndex < lstPanels.Count)
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
                    lstPanelGroups[intGroupIndex][intIndexInGroup].ShowPanel(MainForm);
                }
                //REGULAR PANELS END---------------------------------------------------------------------------------------------------------------------------------------

                //SPECIAL PANELS START---------------------------------------------------------------------------------------------------------------------------------------
                DB.FillRefreshSpecialPanels(lstSpecials);
                int intSGroupCount = (int)Math.Ceiling((double)lstSpecials.Count / (double)intSGroupSize);
                int intSpecialIndex = 0;
                for (int intCurrentGroup = 0; intCurrentGroup < intSGroupCount; intCurrentGroup++)
                {
                    lstSpecialGroups.Add(new SpecialPanel[intSGroupSize]);
                    for (int intIndexInGroup = 0; intIndexInGroup < intSGroupSize; intIndexInGroup++)
                    {
                        if (intSpecialIndex < lstSpecials.Count)
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

                for (int intIndexInGroup = 0; intIndexInGroup < lstSpecialGroups[intGroupIndex].Length; intIndexInGroup++)
                {
                    lstSpecialGroups[intSGroupIndex][intIndexInGroup].ShowPanel(SpecialsPanel);
                }
                //SPECIAL PANELS END---------------------------------------------------------------------------------------------------------------------------------------
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error refreshing data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //PAGE MOVEMENT START-------------------------------------------------------------------------------------------------------------------------------------------------
        //Goes to previous page of products
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            try
            {
                //Hides current panels
                for (int intIndexInGroup = 0; intIndexInGroup < lstPanelGroups[intGroupIndex].Length; intIndexInGroup++)
                {
                    lstPanelGroups[intGroupIndex][intIndexInGroup].HidePanel(this);
                }

                //Shows previous page of panels
                intGroupIndex--;
                if (intGroupIndex < 0)
                {
                    intGroupIndex = lstPanelGroups.Count - 1;
                }
                for (int intIndexInGroup = 0; intIndexInGroup < lstPanelGroups[intGroupIndex].Length; intIndexInGroup++)
                {
                    lstPanelGroups[intGroupIndex][intIndexInGroup].ShowPanel(this);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error changing page", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Goes to next page of products
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                //Hides current panels
                for (int intIndexInGroup = 0; intIndexInGroup < lstPanelGroups[intGroupIndex].Length; intIndexInGroup++)
                {
                    lstPanelGroups[intGroupIndex][intIndexInGroup].HidePanel(this);
                }

                //Shows previous page of panels
                intGroupIndex++;
                if (intGroupIndex == lstPanelGroups.Count)
                {
                    intGroupIndex = 0;
                }
                for (int intIndexInGroup = 0; intIndexInGroup < lstPanelGroups[intGroupIndex].Length; intIndexInGroup++)
                {
                    lstPanelGroups[intGroupIndex][intIndexInGroup].ShowPanel(this);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error changing page", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //Goes to previous page of specials
        private void btnUp_Click(object sender, EventArgs e)
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show("Error changing page", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Goes to next page of specials
        private void btnDown_Click(object sender, EventArgs e)
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show("Error changing page", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //PAGE MOVEMENT END-------------------------------------------------------------------------------------------------------------------------------------------------

        //MENU BAR BUTTONS START-------------------------------------------------------------------------------------------------------------------------------------------------
        //Brings up login menu
        private void mnuLogin_Click(object sender, EventArgs e)
        {
            try
            {
                frmLogin login = new frmLogin();
                login.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error opening login screen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Opens Shopping Cart
        private void mnuShoppingCart_Click(object sender, EventArgs e)
        {
            try
            {
                frmShoppingCart cart = new frmShoppingCart();
                cart.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error opening shopping cart", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //refreshes Product and Specials data
        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            FillRefreshPanelData();
        }
        //MENU BAR BUTTONS END-------------------------------------------------------------------------------------------------------------------------------------------------

        //CUSTOMERS HELP FILES START-------------------------------------------------------------------------------------------------------------------------------------------
        private void mnuProducts_Click(object sender, EventArgs e)
        {
            Help.HelpProducts();
        }

        private void mnuSpecials_Click(object sender, EventArgs e)
        {
            Help.HelpSpecials();
        }

        private void mnuRefreshHelp_Click(object sender, EventArgs e)
        {
            Help.HelpRefresh();
        }
        //CUSTOMERS HELP FILES END-------------------------------------------------------------------------------------------------------------------------------------------

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
