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
        //Used to make generating new help files quicker
        public static StringBuilder HelpTemplate(string strHeader, string strBody)
        {
            try
            {
                StringBuilder html = new StringBuilder();
                StringBuilder css = new StringBuilder();

                css.Append("<style>");
                css.Append("td {padding:5px;text-align:center;font-weight:bold;text-align:conter;}");
                css.Append("h1{color: black;}");
                css.Append("</style>");

                html.Append("<html>");
                html.Append($"<head>{css}<title>{strHeader}</title></head>");
                html.Append("<body>");
                html.Append($"<h1>{strHeader}</h1>");

                html.Append($"<p>{strBody}</p>");

                html.Append("</body></html>");

                return html;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error writing help file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StringBuilder error = new StringBuilder();
                error.Append("Error writing help file");
                return error;
            }
        }

        //Prints the help file
        public static void PrintHelp(StringBuilder html, string strFileName)
        {
            try
            {
                using (StreamWriter swWriter = new StreamWriter(strFileName))
                {
                    swWriter.WriteLine(html);
                }
                System.Diagnostics.Process.Start(@strFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("You don't have write permissions", "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                DateTime dtToday = DateTime.Now;
                using (StreamWriter swWriter = new StreamWriter($"{dtToday.ToString("yyyy-MM-dd-HHmmss")} - " + strFileName))
                {
                    swWriter.WriteLine(html);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //CUSTOMERS START--------------------------------------------------------------------------------------------------------------------------------------------
        public static void HelpProducts()
        {
            string strHeader = "Products";
            string strBody = "Each product has a panel that shows basic information like the product's name and price, as well as an image of the product. Each panel also has a \"More Info\" button, which can be clicked to show more detailed information about the product. There is also an \"Add to Cart\" button which will add the product to your shopping cart. You can look at everything in the shopping cart by clicking the \"Shopping Cart\" button at the top of the form.";
            string strFileName = "ProductsHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpSpecials()
        {
            string strHeader = "Specials";
            string strBody = "Everything that applies to the products also applies to the specials, but the specials have a discounted price. Go to Help>Products if more information is needed.";
            string strFileName = "SpecialsHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpShoppingCart()
        {
            string strHeader = "Shopping Cart";
            string strBody = "The shopping cart shows you what products you have purchased, and the quantity in which you purchased them. You can select an item in the list to get more information about it, and if you decide that you don't want to purchase a specific product anymore, you can click \"Remove From Cart\" while it is selected. When you are ready to make a purchase, you can enter your city and address, then click \"Purchase\" to purchase the items that are currently in your cart.";
            string strFileName = "ShoppingCartHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpRefresh()
        {
            string strHeader = "Refresh";
            string strBody = "Use this button if you want to see updated product data in case you have had the form open for a while.";
            string strFileName = "RefreshHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }
        //CUSTOMERS END--------------------------------------------------------------------------------------------------------------------------------------------------

        //LOGIN START----------------------------------------------------------------------------------------------------------------------------------------------------
        public static void HelpLogin()
        {
            string strHeader = "Login";
            string strBody = "The login menu is meant for managers and employees only. If you are a customer, you only need to enter your information when checking out. If you are an employee or a manager, then you can enter your username and password to log in. If you forget your password, then you can click on the \"Forgot Password?\" button to get a new temporary password.";
            string strFileName = "LoginHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpForgotPassword()
        {
            string strHeader = "Forgot Password";
            string strBody = "Enter your username and your email, and your password will be set to a randomly-generated number. An email will be sent with this new password, and you can use it to log in to your account. You can change your password back to something different after logging in.";
            string strFileName = "ForgotPasswordHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }
        //LOGIN END----------------------------------------------------------------------------------------------------------------------------------------------------

        //MANAGERS START-----------------------------------------------------------------------------------------------------------------------------------------------
        public static void HelpManagersMenu()
        {
            string strHeader = "Managers Menu";
            string strBody = "As a manager, from this menu, you can manage products, specials, employee schedules, and print reports.";
            string strFileName = "ManagersMenuHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpAddProduct()
        {
            string strHeader = "Add Product";
            string strBody = "Enter the product's name, price per unit, wholesale price, unit size, units in stock, and select and image (preferably a 100x100 image),  then click \"Add to database\" to add the product. A report will be generated afterwards that will show all of the manager purchases.";
            string strFileName = "AddProductHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpRemoveProduct()
        {
            string strHeader = "Remove Product";
            string strBody = "Select the name of the product in the combo box, then click \"Remove\" to remove the product. All specials pertaining to that product will be removed as well.";
            string strFileName = "RemoveProductHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpUpdateProduct()
        {
            string strHeader = "Update Product";
            string strBody = "Select the product you want to update in the first combo box, then select the column you want to update in the second combo box. Type the new value in the textbox and click the \"Update\" button to update the product. If you choose to change the products image, a button will show up for you to select an image (preferably a 100x100 image). If you change the UnitsInStock column, a report will be generated that will show all of the manager purchases.";
            string strFileName = "UpdateProductHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpAddSpecial()
        {
            string strHeader = "Add Special";
            string strBody = "Select a product from the combo box to make a special for. After selecting a product, you can enter a discount in an integer format, and some extra details about the special. Click \"Add special\", and the special will be created.";
            string strFileName = "AddSpecialHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpRemoveSpecial()
        {
            string strHeader = "Remove Special";
            string strBody = "Select the name of the special in the combo box, then click \"Remove\" to remove the special.";
            string strFileName = "RemoveSpecialHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpUpdateSpecial()
        {
            string strHeader = "Update Special";
            string strBody = "Select the special you want to update in the first combo box, then select the column you want to update in the second combo box. Type the new value in the textbox and click the \"Update Special\" button to update the special. If you choose to update the product that the special is for, then a combo box will appear with a list of all the products";
            string strFileName = "UpdateSpecialHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpScheduleManage()
        {
            string strHeader = "Manage Schedules";
            string strBody = "As a manager, here is where you can add, update, and remove employee schedules. You can also see the changes your employees have requested in the table off to the right, and respond to them if any changes you have made relate to the requests.";
            string strFileName = "ManageScheduleHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpScheduleAdd()
        {
            string strHeader = "Add Schedule";
            string strBody = "When adding a schedule for an employee, you must first select the employee in the combo box. Afterwards, you can fill in a task, or multiple tasks, for each day of the week, and finally choose whether the schedule will be for this week or next week in the combo box near the bottom. Note that each employee may only have one schedule per week.";
            string strFileName = "AddScheduleHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpScheduleUpdate()
        {
            string strHeader = "Update Schedule";
            string strBody = "Updating a schedule is similar to adding a schedule. Select the employee's name, then select the date the schedule starts on (all schedules start on a sunday), then the tasks for the current schedule will be loaded in. Replace the tasks in the desired textboxes with the new tasks, then click the Update button.";
            string strFileName = "UpdateScheduleHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpScheduleRemove()
        {
            string strHeader = "Remove Schedule";
            string strBody = "To remove a schedule, choose the employee's name, and the date that the scedule starts on (all schedules start on a sunday), then click the Remove button.";
            string strFileName = "RemoveScheduleHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpRespond()
        {
            string strHeader = "Respond to Requests";
            string strBody = "To respond to an employee's request, select the request ID (you can see the request ID back on the schedule management form), then use the bottom combo box to change its status and click Respond.";
            string strFileName = "RequestResponseHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpReport()
        {
            string strHeader = "Print Report";
            string strBody = "From here, you can print sales reports for the day, week, and month, as well as print employee schedules and the current inventory.";
            string strFileName = "PrintReportHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }
        //MANAGERS END-------------------------------------------------------------------------------------------------------------------------------------------------

        //EMPLOYEES START-----------------------------------------------------------------------------------------------------------------------------------------------
        public static void HelpSchedule()
        {
            string strHeader = "Schedules and Schedule Printing";
            string strBody = "On the employees menu, you can see your schedules and print them. The one you are viewing and the one that will be printed are determined by the value in the combo box below the schedule.";
            string strFileName = "SchedulesPrintingHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpEmployeeSpecials()
        {
            string strHeader = "Specials";
            string strBody = "On the employees menu, you can see which products are currently specials, you should prioritize selling these.";
            string strFileName = "SpecialsHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }

        public static void HelpRequestChange()
        {
            string strHeader = "Request Schedule Change";
            string strBody = "By clicking on the \"Request work day change\" or \"Request day off\" button, you can request a change to your current of future schedules. Be sure to be specific by naming the day you would like to have off, and preferrably give a good reason. Work days can also be traded with other employees, be sure to say which day and which employee you would like to swap with.";
            string strFileName = "RequestScheduleChangeHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }
        
        public static void HelpChangeInformation()
        {
            string strHeader = "Change Information";
            string strBody = "Upon clicking the \"Change Information\" button, a form will be loaded with textboxes containing your information. If you change the text in these fields, and click the Update button, the changes will be saved.";
            string strFileName = "ChangeInformationHelp.html";

            PrintHelp(HelpTemplate(strHeader, strBody), strFileName);
        }
        //EMPLOYEES END-------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
