using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SP21_Final_Project
{
    class Help
    {
        public static void OpenHelp(string strFileName)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\HelpFiles\\" + strFileName + ".html");
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //DATABASE PERMISSIONS
        public static void HelpDatabasePermissions()
        {
            OpenHelp("DatabasePermissionsHelp");
        }

        //CUSTOMERS START--------------------------------------------------------------------------------------------------------------------------------------------
        public static void HelpProducts()//
        {
            OpenHelp("ProductsHelp");
        }

        public static void HelpSpecials()//
        {
            OpenHelp("SpecialsHelp");
        }

        public static void HelpShoppingCart()
        {
            OpenHelp("ShoppingCartHelp");
        }

        public static void HelpRefresh()
        {
            OpenHelp("RefreshHelp");
        }
        //CUSTOMERS END--------------------------------------------------------------------------------------------------------------------------------------------------

        //LOGIN START----------------------------------------------------------------------------------------------------------------------------------------------------
        public static void HelpLogin()
        {
            OpenHelp("LoginHelp");
        }

        public static void HelpForgotPassword()
        {
            OpenHelp("ForgotPasswordHelp");
        }
        //LOGIN END----------------------------------------------------------------------------------------------------------------------------------------------------

        //MANAGERS START-----------------------------------------------------------------------------------------------------------------------------------------------
        public static void HelpManagersMenu()
        {
            OpenHelp("ManagersMenuHelp");
        }

        public static void HelpAddProduct()
        {
            OpenHelp("AddProductsHelp");
        }

        public static void HelpRemoveProduct()
        {
            OpenHelp("RemoveProductHelp");
        }

        public static void HelpUpdateProduct()
        {
            OpenHelp("UpdateProductHelp");
        }

        public static void HelpAddSpecial()
        {
            OpenHelp("AddSpecialHelp");
        }

        public static void HelpRemoveSpecial()
        {
            OpenHelp("RemoveSpecialHelp");
        }

        public static void HelpUpdateSpecial()
        {
            OpenHelp("UpdateSpecialHelp");
        }

        public static void HelpScheduleManage()
        {
            OpenHelp("ScheduleManageHelp");
        }

        public static void HelpScheduleAdd()
        {
            OpenHelp("ScheduleAddHelp");
        }

        public static void HelpScheduleUpdate()
        {
            OpenHelp("ScheduleUpdateHelp");
        }

        public static void HelpScheduleRemove()
        {
            OpenHelp("ScheduleRemoveHelp");
        }

        public static void HelpRespond()
        {
            OpenHelp("RespondHelp");
        }

        public static void HelpReport()
        {
            OpenHelp("ReportHelp");
        }
        //MANAGERS END-------------------------------------------------------------------------------------------------------------------------------------------------

        //EMPLOYEES START-----------------------------------------------------------------------------------------------------------------------------------------------
        public static void HelpSchedule()
        {
            OpenHelp("ScheduleHelp");
        }

        public static void HelpEmployeeSpecials()
        {
            OpenHelp("EmployeeSpecialsHelp");
        }

        public static void HelpRequestChange()
        {
            OpenHelp("RequestChangeHelp");
        }
        
        public static void HelpChangeInformation()
        {
            OpenHelp("ChangeInformationHelp");
        }
        //EMPLOYEES END-------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
