//Programmer: Ian Fuller
//Course: INEW 2332.10z1
//Program purpose: Application that will allow the user to make purchases from a grocery store

//This class is used for database interaction
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace SP21_Final_Project
{
    class DB
    {
        //Connection string
        private const string strConnection = @"Server = cstnt.tstc.edu; Database = inew2332sp21; User Id = FullerIsp212332; Password = 1756605";
        private static SqlConnection _cntDatabase = new SqlConnection(strConnection);

        //CLASS OBEJCTS
        //CLASS OBJECTS

        //Open/Close functions
        public static void OpenDatabase()
        {
            try
            {
                _cntDatabase.Open();
                MessageBox.Show("Connection successful.", "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Connection unsuccessful.\n" + ex.Message, "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void CloseDatabase()
        {
            try
            {
                _cntDatabase.Close();
                MessageBox.Show("Closed successfully.", "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection could not be closed.\n" + ex.Message, "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Easy way to show SQL exception
        public static void ShowSQLException(SqlException ex, string errorMessage)
        {
            StringBuilder errorMessages = new StringBuilder();
            if (ex is SqlException)
            {
                for (int intCurrentError = 0; intCurrentError < ex.Errors.Count; intCurrentError++)
                {
                    errorMessages.Append("Index #" + intCurrentError + "\n" +
                        "Message: " + ex.Errors[intCurrentError].Message + "\n" +
                        "LineNumber: " + ex.Errors[intCurrentError].LineNumber + "\n" +
                        "Source: " + ex.Errors[intCurrentError].Source + "\n" +
                        "Procedure: " + ex.Errors[intCurrentError].Procedure + "\n");
                }
                MessageBox.Show(errorMessages.ToString(), errorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(ex.Message, errorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //PANELS START-----------------------------------------------------------------------------------------------------------------------------------------------------

        //Gets count of rows for filling product panels
        public static int GetRowsCount(String strTable)
        {
            try
            {
                string strQuery = "SELECT COUNT(*) FROM FullerIsp212332." + strTable;
                SqlCommand cmd = new SqlCommand(strQuery, _cntDatabase);
                return (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                ShowSQLException(ex, "Could not get number of rows in requested table.");
                return 0;
            }
        }

        //Gets data from a row in the database, then fills a newly-created panel with that data
        public static int FillPanel(int intCurrentRow, List<ProductPanel> lstPanels, int intLeft, int intTop)
        {
            string strProductName;
            double dblPrice;
            string strSize;
            int intUnitsInStock = 0;
            byte[] arrImageBytes = null;

            try
            {
                string strNameQuery = "SELECT ProductName FROM FullerIsp212332.Products WHERE ProductID = " + intCurrentRow;
                SqlCommand nameCommand = new SqlCommand(strNameQuery, _cntDatabase);
                strProductName = (string)nameCommand.ExecuteScalar();

                if(strProductName == null)
                {
                    return 1;
                }

                string strPriceQuery = "SELECT Price FROM FullerIsp212332.Products WHERE ProductID = " + intCurrentRow;
                SqlCommand priceCommand = new SqlCommand(strPriceQuery, _cntDatabase);
                dblPrice = Convert.ToDouble(priceCommand.ExecuteScalar());

                string strSizeQuery = "SELECT Size FROM FullerIsp212332.Products WHERE ProductID = " + intCurrentRow;
                SqlCommand sizeCommand = new SqlCommand(strSizeQuery, _cntDatabase);
                strSize = (string)sizeCommand.ExecuteScalar();

                string strUnitsQuery = "SELECT UnitsInStock FROM FullerIsp212332.Products WHERE ProductID = " + intCurrentRow;
                SqlCommand unitsCommand = new SqlCommand(strUnitsQuery, _cntDatabase);
                intUnitsInStock = (int)unitsCommand.ExecuteScalar();

                string strImageQuery = "SELECT ProductImage FROM FullerIsp212332.Products WHERE ProductID = " + intCurrentRow;
                SqlCommand imageCommand = new SqlCommand(strImageQuery, _cntDatabase);
                arrImageBytes = (byte[])imageCommand.ExecuteScalar();

                lstPanels.Add(new ProductPanel(intCurrentRow, strProductName, dblPrice, strSize, intUnitsInStock, arrImageBytes, intLeft, intTop));
            }
            catch (SqlException ex)
            {
                ShowSQLException(ex, "Failed to fill a product panel.");
            }

            return 0;
        }

        public static int FillSpecialPanel(int intCurrentRow, List<SpecialPanel> lstPanels, int intLeft, int intTop)
        {
            int intID;

            string strProductName;
            double dblPrice;
            string strSize;
            int intUnitsInStock;
            byte[] arrImageBytes;
            int intDiscount;
            string strExtraDetails;

            try
            {
                string strIDQuery = "SELECT ProductID FROM FullerIsp212332.Specials WHERE SpecialID = " + intCurrentRow;
                SqlCommand IDCommand = new SqlCommand(strIDQuery, _cntDatabase);
                if(IDCommand.ExecuteScalar() == null)
                {
                    return 1;
                }
                else
                {
                    intID = (int)IDCommand.ExecuteScalar();
                }

                string strNameQuery = "SELECT ProductName FROM FullerIsp212332.Products WHERE ProductID = " + intID;
                SqlCommand nameCommand = new SqlCommand(strNameQuery, _cntDatabase);
                strProductName = (string)nameCommand.ExecuteScalar();

                string strPriceQuery = "SELECT Price FROM FullerIsp212332.Products WHERE ProductID = " + intID;
                SqlCommand priceCommand = new SqlCommand(strPriceQuery, _cntDatabase);
                dblPrice = Convert.ToDouble(priceCommand.ExecuteScalar());

                string strSizeQuery = "SELECT Size FROM FullerIsp212332.Products WHERE ProductID = " + intID;
                SqlCommand sizeCommand = new SqlCommand(strSizeQuery, _cntDatabase);
                strSize = (string)sizeCommand.ExecuteScalar();

                string strUnitsQuery = "SELECT UnitsInStock FROM FullerIsp212332.Products WHERE ProductID = " + intID;
                SqlCommand unitsCommand = new SqlCommand(strUnitsQuery, _cntDatabase);
                intUnitsInStock = (int)unitsCommand.ExecuteScalar();

                string strImageQuery = "SELECT ProductImage FROM FullerIsp212332.Products WHERE ProductID = " + intID;
                SqlCommand imageCommand = new SqlCommand(strImageQuery, _cntDatabase);
                arrImageBytes = (byte[])imageCommand.ExecuteScalar();

                string strDiscountQuery = "SELECT PriceDiscounted FROM FullerIsp212332.Specials WHERE SpecialID = " + intCurrentRow;
                SqlCommand discountCommand = new SqlCommand(strDiscountQuery, _cntDatabase);
                intDiscount = (int)discountCommand.ExecuteScalar();

                string strDetailsQuery = "SELECT ExtraDetails FROM FullerIsp212332.Specials WHERE SpecialID = " + intCurrentRow;
                SqlCommand detailsCommand = new SqlCommand(strDetailsQuery, _cntDatabase);
                strExtraDetails = (string)detailsCommand.ExecuteScalar();

                lstPanels.Add(new SpecialPanel(intCurrentRow, strProductName, dblPrice, strSize, intUnitsInStock, arrImageBytes, intLeft, intTop, intDiscount, strExtraDetails));
            }
            catch (SqlException ex)
            {
                ShowSQLException(ex, "Failed to fill a product panel.");
            }

            return 0;
        }

        //PANELS END---------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static void InsertImage(string productName)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ValidateNames = true;
            openFile.AddExtension = false;
            openFile.Filter = "Image File|*.png|Image File|*.jpg";
            openFile.Title = "File to Upload";

            if(openFile.ShowDialog() == DialogResult.OK)
            {
                byte[] image = File.ReadAllBytes(openFile.FileName);
                try
                {
                    string query = $"UPDATE FullerIsp212332.Products SET ProductImage = @Image WHERE ProductName = '" + productName + "'";
                    SqlCommand cmd = new SqlCommand(query, _cntDatabase);
                    SqlParameter param = cmd.Parameters.AddWithValue("@Image", image);
                    param.DbType = System.Data.DbType.Binary;
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error During Upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static string Login(string strUsername, string strPassword)
        {
            string strEmployeeQuery = "SELECT Password FROM FullerIsp212332.Employees WHERE Username = '" + strUsername + "'";
            SqlCommand employeeCommand = new SqlCommand(strEmployeeQuery, _cntDatabase);
            if((string)employeeCommand.ExecuteScalar() == strPassword)
            {
                return "Employee";
            }

            string strManagerQuery = "SELECT Password FROM FullerIsp212332.Managers WHERE Username = '" + strUsername + "'";
            SqlCommand managerCommand = new SqlCommand(strManagerQuery, _cntDatabase);
            if((string)managerCommand.ExecuteScalar() == strPassword)
            {
                return "Manager";
            }

            return "";
        }

        public static void CreateInvoice(string strCity, string strAddress, List<ProductPanel> lstProducts, List<int> lstQuantities)
        {
            try
            {
                int intNewID;

                if (GetRowsCount("Customers") == 0)
                {
                    intNewID = 1;
                }
                else
                {
                    string strGetHighestID = "SELECT MAX(CustomerID) FROM FullerIsp212332.Customers";
                    SqlCommand idCommand = new SqlCommand(strGetHighestID, _cntDatabase);
                    intNewID = (int)idCommand.ExecuteScalar() + 1;
                }

                string strInsert = "INSERT INTO FullerIsp212332.Customers(CustomerID, City, Address) VALUES(" + intNewID + ", '" + strCity + "', '" + strAddress + "')";
                SqlCommand insertCommand = new SqlCommand(strInsert, _cntDatabase);
                insertCommand.ExecuteNonQuery();

                for (int intCurrentProduct = 0; intCurrentProduct < lstProducts.Count; intCurrentProduct++)
                {
                    string strOrderDate = "'" + DateTime.Now.Year.ToString() + "-" + FormatDayOrMonth(DateTime.Now.Month.ToString()) + "-" + FormatDayOrMonth(DateTime.Now.Day.ToString()) + "'";
                    string strNewInvoice = "INSERT INTO FullerIsp212332.Invoices(CustomerID, ProductID, Discount, Quantity, TotalPrice, OrderDate) VALUES(" + intNewID + ", " + lstProducts[intCurrentProduct].intProductID + ", " + lstProducts[intCurrentProduct].GetDiscount() + ", " + lstQuantities[intCurrentProduct] + ", " + (Math.Round(lstProducts[intCurrentProduct].dblPrice * (1f - (double)lstProducts[intCurrentProduct].GetDiscount() / 100f), 2)) * lstQuantities[intCurrentProduct] + ", " + strOrderDate + ")";
                    SqlCommand invoiceCommand = new SqlCommand(strNewInvoice, _cntDatabase);
                    invoiceCommand.ExecuteNonQuery();

                    MessageBox.Show("Purchase successful.", "Purchase", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Making Purchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Formats 1 digit day/month to a 2 digit day/month
        public static string FormatDayOrMonth(string strDayMonth)
        {
            if(strDayMonth.Length == 1)
            {
                strDayMonth = "0" + strDayMonth;
            }

            return strDayMonth;
        }

        //PRODUCTS ADD, UPDATE, DELETE START--------------------------------------------------------------------------------------------------------------------------------------------

        public static void AddNewProduct(string strName, double dblPrice, string strSize, int intStock, byte[] arrBytes)
        {
            try
            {
                string strInsertQuery = $"INSERT INTO FullerIsp212332.Products(ProductName, Price, Size, UnitsInStock, ProductImage) VALUES('" + strName + "', " + dblPrice + ", '" + strSize + "', " + intStock + ", @Image)";
                SqlCommand cmdInsertCommand = new SqlCommand(strInsertQuery, _cntDatabase);
                SqlParameter param = cmdInsertCommand.Parameters.AddWithValue("@Image", arrBytes);
                param.DbType = System.Data.DbType.Binary;
                cmdInsertCommand.ExecuteNonQuery();

                MessageBox.Show("Product successfully added to database.", "Product Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowSQLException(ex, "Failed to add product");
            }
        }

        public static void RemoveProduct(string strProductName)
        {
            try
            {
                string strGetProductID = "SELECT ProductID FROM FullerIsp212332.Products WHERE ProductName = '" + strProductName + "'";
                SqlCommand cmdGetProductID = new SqlCommand(strGetProductID, _cntDatabase);
                int intProductID = (int)cmdGetProductID.ExecuteScalar();

                string strRemoveSpecials = "DELETE FROM FullerIsp212332.Specials WHERE ProductID = " + intProductID;
                SqlCommand cmdRemoveSpecials = new SqlCommand(strRemoveSpecials, _cntDatabase);
                cmdRemoveSpecials.ExecuteNonQuery();

                string strRemoveProduct = "DELETE FROM FullerIsp212332.Products WHERE ProductID = " + intProductID;
                SqlCommand cmdRemoveProduct = new SqlCommand(strRemoveProduct, _cntDatabase);
                cmdRemoveProduct.ExecuteNonQuery();

                MessageBox.Show("Product successfully removed from database.", "Product Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowSQLException(ex, "Failed to remove product");
            }
        }

        public static void UpdateProduct(string strColumnName, string strNewValue, string strProductName)
        {
            try
            {
                if(strColumnName == "ProductName")
                {
                    if (strNewValue.Length <= 50)
                    {
                        string strUpdateQuery = "UPDATE FullerIsp212332.Products SET " + strColumnName + " = " + strNewValue + " WHERE ProductName = '" + strProductName + "'";
                        SqlCommand cmdUpdateQuery = new SqlCommand(strUpdateQuery, _cntDatabase);
                        cmdUpdateQuery.ExecuteNonQuery();
                        MessageBox.Show("Product successfully updated.", "Product Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Product name can only be 50 characters long.", "Error Updating Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if(strColumnName == "Price")
                {
                    if (Double.TryParse(strNewValue, out double dblPrice) && !strNewValue.Contains('-'))
                    {
                        string strUpdateQuery = "UPDATE FullerIsp212332.Products SET " + strColumnName + " = " + dblPrice + " WHERE ProductName = '" + strProductName + "'";
                        SqlCommand cmdUpdateQuery = new SqlCommand(strUpdateQuery, _cntDatabase);
                        cmdUpdateQuery.ExecuteNonQuery();
                        MessageBox.Show("Product successfully updated.", "Product Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Product price must be a positive decimal value.", "Error Updating Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if(strColumnName == "Size")
                {
                    if (strNewValue.Length <= 20)
                    {
                        string strUpdateQuery = "UPDATE FullerIsp212332.Products SET " + strColumnName + " = " + strNewValue + " WHERE ProductName = '" + strProductName + "'";
                        SqlCommand cmdUpdateQuery = new SqlCommand(strUpdateQuery, _cntDatabase);
                        cmdUpdateQuery.ExecuteNonQuery();
                        MessageBox.Show("Product successfully updated.", "Product Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Product size can only be 20 characters long.", "Error Updating Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if(strColumnName == "UnitsInStock")
                {
                    if (Int32.TryParse(strNewValue, out int intStock))
                    {
                        string strGetOldQuantity = $"SELECT UnitsInStock FROM FullerIsp212332.Products WHERE ProductName = '{strProductName}'";
                        SqlCommand cmdGetOldQuantity = new SqlCommand(strGetOldQuantity, _cntDatabase);
                        int intOldQuantity = (int)cmdGetOldQuantity.ExecuteScalar();

                        string strGetPrice = $"SELECT Price FROM FullerIsp212332.Products WHERE ProductName = '{strProductName}'";
                        SqlCommand cmdGetPrice = new SqlCommand(strGetPrice, _cntDatabase);
                        double dblPrice = (double)(decimal)cmdGetPrice.ExecuteScalar();

                        string strUpdateQuery = "UPDATE FullerIsp212332.Products SET " + strColumnName + " = " + intStock + " WHERE ProductName = '" + strProductName + "'";
                        SqlCommand cmdUpdateQuery = new SqlCommand(strUpdateQuery, _cntDatabase);
                        cmdUpdateQuery.ExecuteNonQuery();

                        StringBuilder html = GenerateManagerPurchaseReceipt(strProductName, intStock - intOldQuantity, dblPrice);

                        string strFileName = "ManagerPurchaseReceipt.html";
                        try
                        {
                            using (StreamWriter writer = new StreamWriter(strFileName))
                            {
                                writer.WriteLine(html);
                            }
                            System.Diagnostics.Process.Start(@strFileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("You don't have write permissions", "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        DateTime today = DateTime.Now;
                        using (StreamWriter wr = new StreamWriter($"{today.ToString("yyyy-MM-dd-HHmmss")} - " + strFileName))
                        {
                            wr.WriteLine(html);
                        }

                        MessageBox.Show("Product successfully updated.", "Product Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Product units in stock must be an integer value.", "Error Updating Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if(strColumnName == "ProductImage")
                {
                    byte[] arrBytes = File.ReadAllBytes(strNewValue);
                    string strUpdateQuery = "UPDATE FullerIsp212332.Products SET " + strColumnName + " = @Image WHERE ProductName = '" + strProductName + "'";
                    SqlCommand cmdUpdateQuery = new SqlCommand(strUpdateQuery, _cntDatabase);
                    SqlParameter param = cmdUpdateQuery.Parameters.AddWithValue("@Image", arrBytes);
                    param.DbType = System.Data.DbType.Binary;
                    cmdUpdateQuery.ExecuteNonQuery();
                    MessageBox.Show("Product successfully updated.", "Product Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                ShowSQLException(ex, "Failed to update product");
            }
        }

        //PRODUCTS ADD, UPDATE, DELETE END----------------------------------------------------------------------------------------------------------------------------------------------

        //SPECIALS ADD, UPDATE, DELETE START----------------------------------------------------------------------------------------------------------------------------------------------

        public static void AddSpecial(string strProductName, int intDiscount, string strExtraDetails)
        {
            string strGetProductID = "SELECT ProductID FROM FullerIsp212332.Products WHERE ProductName = '" + strProductName + "'";
            SqlCommand cmdGetProductID = new SqlCommand(strGetProductID, _cntDatabase);
            int intProductID = (int)cmdGetProductID.ExecuteScalar();

            string strInsertCommand = "INSERT INTO FullerIsp212332.Specials VALUES(" + intProductID + ", " + intDiscount + ", '" + strExtraDetails + "')";
            SqlCommand cmdInsertCommand = new SqlCommand(strInsertCommand, _cntDatabase);
            cmdInsertCommand.ExecuteNonQuery();

            MessageBox.Show("Special successfully added.", "Special Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void RemoveSpecial(string strName, int intDiscount)
        {
            try
            {
                string strGetOldProductID = "SELECT ProductID FROM FullerIsp212332.Products WHERE ProductName = '" + strName + "'";
                SqlCommand cmdGetOldProductID = new SqlCommand(strGetOldProductID, _cntDatabase);
                int intOldProductID = (int)cmdGetOldProductID.ExecuteScalar();

                string strDeleteQuery = "DELETE FROM FullerIsp212332.Specials WHERE ProductID = " + intOldProductID + " AND PriceDiscounted = " + intDiscount;
                SqlCommand cmdDeleteQuery = new SqlCommand(strDeleteQuery, _cntDatabase);
                cmdDeleteQuery.ExecuteNonQuery();

                MessageBox.Show("Special successfully removed from database.", "Special Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowSQLException(ex, "Failed to remove special");
            }
        }

        public static void UpdateSpecial(string strName, int intDiscount, string strColumnName, string strNewValue)
        {
            try
            {
                if (strColumnName == "Product")
                {
                    string strGetOldProductID = "SELECT ProductID FROM FullerIsp212332.Products WHERE ProductName = '" + strName + "'";
                    SqlCommand cmdGetOldProductID = new SqlCommand(strGetOldProductID, _cntDatabase);
                    int intOldProductID = (int)cmdGetOldProductID.ExecuteScalar();

                    string strGetNewProductID = "SELECT ProductID FROM FullerIsp212332.Products WHERE ProductName = '" + strNewValue + "'";
                    SqlCommand cmdGetNewProductID = new SqlCommand(strGetNewProductID, _cntDatabase);
                    int intNewProductID = (int)cmdGetNewProductID.ExecuteScalar();

                    string strUpdateQuery = "UPDATE FullerIsp212332.Specials SET ProductID = " + intNewProductID + " WHERE ProductID = " + intOldProductID + " AND PriceDiscounted = " + intDiscount;
                    SqlCommand cmdUpdateQuery = new SqlCommand(strUpdateQuery, _cntDatabase);
                    cmdUpdateQuery.ExecuteNonQuery();

                    MessageBox.Show("Special successfully updated.", "Special Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (strColumnName == "PriceDiscounted")
                {
                    if (Int32.TryParse(strNewValue, out int intNewDiscount))
                    {
                        if(intNewDiscount < 0)
                        {
                            intNewDiscount *= -1;
                        }

                        string strGetOldProductID = "SELECT ProductID FROM FullerIsp212332.Products WHERE ProductName = '" + strName + "'";
                        SqlCommand cmdGetOldProductID = new SqlCommand(strGetOldProductID, _cntDatabase);
                        int intOldProductID = (int)cmdGetOldProductID.ExecuteScalar();

                        string strUpdateQuery = "UPDATE FullerIsp212332.Specials SET " + strColumnName + " = " + intNewDiscount + " WHERE ProductID = " + intOldProductID + " AND PriceDiscounted = " + intDiscount;
                        SqlCommand cmdUpdateQuery = new SqlCommand(strUpdateQuery, _cntDatabase);
                        cmdUpdateQuery.ExecuteNonQuery();

                        MessageBox.Show("Special successfully updated.", "Special Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Input discount as integer format.", "Error Updating Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (strColumnName == "ExtraDetails")
                {
                    if (strNewValue.Length <= 50)
                    {
                        string strGetOldProductID = "SELECT ProductID FROM FullerIsp212332.Products WHERE ProductName = '" + strName + "'";
                        SqlCommand cmdGetOldProductID = new SqlCommand(strGetOldProductID, _cntDatabase);
                        int intOldProductID = (int)cmdGetOldProductID.ExecuteScalar();

                        string strUpdateQuery = "UPDATE FullerIsp212332.Specials SET " + strColumnName + " = '" + strNewValue + "' WHERE ProductID = " + intOldProductID + " AND PriceDiscounted = " + intDiscount;
                        SqlCommand cmdUpdateQuery = new SqlCommand(strUpdateQuery, _cntDatabase);
                        cmdUpdateQuery.ExecuteNonQuery();

                        MessageBox.Show("Special successfully updated.", "Special Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Extra details can only be 50 characters long.", "Error Updating Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex)
            {
                ShowSQLException(ex, "Failed to update special");
            }
        }

        //SPECIALS ADD, UPDATE, DELETE END----------------------------------------------------------------------------------------------------------------------------------------------

        public static string GetSchedule(string strUsername, DataGridView dgvSchedule, string strWeek)
        {
            try
            {
                string strGetID = "SELECT EmployeeID FROM FullerIsp212332.Employees WHERE Username ='" + strUsername + "'";
                SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
                int intEmployeeID = (int)cmdGetID.ExecuteScalar();

                string strStartDate = "";
                if (strWeek == "This Week")
                {
                    DateTime tempDate = DateTime.Now;

                    switch (DateTime.Now.DayOfWeek.ToString())
                    {
                        case "Sunday":
                            tempDate = DateTime.Now;
                            break;
                        case "Monday":
                            tempDate = DateTime.Now.AddDays(-1);
                            break;
                        case "Tuesday":
                            tempDate = DateTime.Now.AddDays(-2);
                            break;
                        case "Wednesday":
                            tempDate = DateTime.Now.AddDays(-3);
                            break;
                        case "Thursday":
                            tempDate = DateTime.Now.AddDays(-4);
                            break;
                        case "Friday":
                            tempDate = DateTime.Now.AddDays(-5);
                            break;
                        case "Saturday":
                            tempDate = DateTime.Now.AddDays(-6);
                            break;
                    }

                    strStartDate = "'" + tempDate.Year.ToString() + "-" + FormatDayOrMonth(tempDate.Month.ToString()) + "-" + FormatDayOrMonth(tempDate.Day.ToString()) + "'";

                    string strGetSchedule = "SELECT Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday FROM FullerIsp212332.Schedules WHERE EmployeeID = " + intEmployeeID + " AND StartDate = " + strStartDate;
                    SqlCommand cmdGetSchedule = new SqlCommand(strGetSchedule, _cntDatabase);
                    SqlDataAdapter sdaGetSchedule = new SqlDataAdapter();
                    DataTable dtbGetSchedule = new DataTable();

                    sdaGetSchedule.SelectCommand = cmdGetSchedule;
                    sdaGetSchedule.Fill(dtbGetSchedule);
                    dgvSchedule.DataSource = dtbGetSchedule;

                    string strToday = DateTime.Now.DayOfWeek.ToString();
                    string strGetToday = "SELECT " + strToday + " FROM FullerIsp212332.Schedules WHERE EmployeeID = " + intEmployeeID;
                    SqlCommand cmdGetToday = new SqlCommand(strGetToday, _cntDatabase);
                    return (string)cmdGetToday.ExecuteScalar();
                }
                else if (strWeek == "Next Week")
                {
                    DateTime tempDate = DateTime.Now;

                    switch (DateTime.Now.DayOfWeek.ToString())
                    {
                        case "Sunday":
                            tempDate = DateTime.Now;
                            break;
                        case "Monday":
                            tempDate = DateTime.Now.AddDays(-1);
                            break;
                        case "Tuesday":
                            tempDate = DateTime.Now.AddDays(-2);
                            break;
                        case "Wednesday":
                            tempDate = DateTime.Now.AddDays(-3);
                            break;
                        case "Thursday":
                            tempDate = DateTime.Now.AddDays(-4);
                            break;
                        case "Friday":
                            tempDate = DateTime.Now.AddDays(-5);
                            break;
                        case "Saturday":
                            tempDate = DateTime.Now.AddDays(-6);
                            break;
                    }

                    tempDate = tempDate.AddDays(7);

                    strStartDate = "'" + tempDate.Year.ToString() + "-" + FormatDayOrMonth(tempDate.Month.ToString()) + "-" + FormatDayOrMonth(tempDate.Day.ToString()) + "'";

                    string strGetSchedule = "SELECT Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday FROM FullerIsp212332.Schedules WHERE EmployeeID = " + intEmployeeID + " AND StartDate = " + strStartDate;
                    SqlCommand cmdGetSchedule = new SqlCommand(strGetSchedule, _cntDatabase);
                    SqlDataAdapter sdaGetSchedule = new SqlDataAdapter();
                    DataTable dtbGetSchedule = new DataTable();

                    sdaGetSchedule.SelectCommand = cmdGetSchedule;
                    sdaGetSchedule.Fill(dtbGetSchedule);
                    dgvSchedule.DataSource = dtbGetSchedule;

                    string strToday = DateTime.Now.DayOfWeek.ToString();
                    string strGetToday = "SELECT " + strToday + " FROM FullerIsp212332.Schedules WHERE EmployeeID = " + intEmployeeID;
                    SqlCommand cmdGetToday = new SqlCommand(strGetToday, _cntDatabase);
                    return (string)cmdGetToday.ExecuteScalar();
                }
                else if (strWeek == "All Previous Weeks")
                {
                    DateTime tempDate = DateTime.Now;

                    switch (DateTime.Now.DayOfWeek.ToString())
                    {
                        case "Sunday":
                            tempDate = DateTime.Now;
                            break;
                        case "Monday":
                            tempDate = DateTime.Now.AddDays(-1);
                            break;
                        case "Tuesday":
                            tempDate = DateTime.Now.AddDays(-2);
                            break;
                        case "Wednesday":
                            tempDate = DateTime.Now.AddDays(-3);
                            break;
                        case "Thursday":
                            tempDate = DateTime.Now.AddDays(-4);
                            break;
                        case "Friday":
                            tempDate = DateTime.Now.AddDays(-5);
                            break;
                        case "Saturday":
                            tempDate = DateTime.Now.AddDays(-6);
                            break;
                    }

                    strStartDate = "'" + tempDate.Year.ToString() + "-" + FormatDayOrMonth(tempDate.Month.ToString()) + "-" + FormatDayOrMonth(tempDate.Day.ToString()) + "'";

                    string strGetSchedule = "SELECT Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday FROM FullerIsp212332.Schedules WHERE EmployeeID = " + intEmployeeID + " AND StartDate < " + strStartDate;
                    SqlCommand cmdGetSchedule = new SqlCommand(strGetSchedule, _cntDatabase);
                    SqlDataAdapter sdaGetSchedule = new SqlDataAdapter();
                    DataTable dtbGetSchedule = new DataTable();

                    sdaGetSchedule.SelectCommand = cmdGetSchedule;
                    sdaGetSchedule.Fill(dtbGetSchedule);
                    dgvSchedule.DataSource = dtbGetSchedule;

                    string strToday = DateTime.Now.DayOfWeek.ToString();
                    string strGetToday = "SELECT " + strToday + " FROM FullerIsp212332.Schedules WHERE EmployeeID = " + intEmployeeID;
                    SqlCommand cmdGetToday = new SqlCommand(strGetToday, _cntDatabase);
                    return (string)cmdGetToday.ExecuteScalar();
                }
                else
                {
                    MessageBox.Show("Invalid Date.", "Error Creating Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Not found";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cannot get schedule", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "Not found";
        }

        public static void GetRequests(DataGridView dgvRequests)
        {
            try
            {
                string strGetRequests = "SELECT RequestID, FirstName, LastName, Request, Status FROM FullerIsp212332.Requests JOIN FullerIsp212332.Employees ON Requests.EmployeeID = Employees.EmployeeID";
                SqlCommand cmdGetRequests = new SqlCommand(strGetRequests, _cntDatabase);
                SqlDataAdapter sdaGetRequests = new SqlDataAdapter();
                DataTable dtbGetRequests = new DataTable();

                sdaGetRequests.SelectCommand = cmdGetRequests;
                sdaGetRequests.Fill(dtbGetRequests);
                dgvRequests.DataSource = dtbGetRequests;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot get requests", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //REPORTS START---------------------------------------------------------------------------------------------------------------------------------------------------------

        public static StringBuilder GenerateInventoryReport()
        {
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

            css.Append("<style>");
            css.Append("td {padding:5px;text-align:center;font-weight:bold;text-align:conter;}");
            css.Append("h1{color: black;}");
            css.Append("</style>");

            html.Append("<html>");
            html.Append($"<head>{css}<title>{"Current Inventory"}</title></head>");
            html.Append("<body>");
            html.Append($"<h1>{"Current Inventory"}</h1>");

            SqlDataReader reader;
            SqlCommand cmd;
            cmd = _cntDatabase.CreateCommand();
            cmd.CommandText = "SELECT ProductID, ProductName, Price, Size, UnitsInStock FROM FullerIsp212332.Products";
            reader = cmd.ExecuteReader();

            html.Append("<table>");
            html.Append("<tr><td colspan=5><hr/></td></tr>");
            html.Append($"<td>{"Product ID"}</td>");
            html.Append($"<td>{"Product Name"}</td>");
            html.Append($"<td>{"Price Per Unit"}</td>");
            html.Append($"<td>{"Unit Size"}</td>");
            html.Append($"<td>{"Units in Stock"}</td>");
            html.Append("</tr>");
            html.Append("<tr><td colspan=5><hr/></td></tr>");

            while (reader.Read())
            {
                html.Append($"<td>{reader.GetInt32(0)}</td>");
                html.Append($"<td>{reader.GetString(1)}</td>");
                html.Append($"<td>{reader.GetDecimal(2)}</td>");
                html.Append($"<td>{reader.GetString(3)}</td>");
                html.Append($"<td>{reader.GetInt32(4)}</td>");
                html.Append("</tr>");
            }
            html.Append("<tr><td colspan=5><hr/></td></tr>");
            html.Append("</table>");
            html.Append("</body></html>");

            reader.Close();
            return html;
        }

        public static StringBuilder GenerateScheduleReport()
        {
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

            css.Append("<style>");
            css.Append("td {padding:5px;text-align:center;font-weight:bold;text-align:conter;}");
            css.Append("h1{color: black;}");
            css.Append("</style>");

            html.Append("<html>");
            html.Append($"<head>{css}<title>{"Employee Schedules"}</title></head>");
            html.Append("<body>");
            html.Append($"<h1>{"Employee Schedules"}</h1>");

            SqlDataReader reader;
            SqlCommand cmd;
            cmd = _cntDatabase.CreateCommand();
            cmd.CommandText = "SELECT Employees.EmployeeID, FirstName, LastName, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday FROM FullerIsp212332.Employees JOIN FullerIsp212332.Schedules ON Employees.EmployeeID = Schedules.EmployeeID";
            reader = cmd.ExecuteReader();

            html.Append("<table>");
            html.Append("<tr><td colspan=10><hr/></td></tr>");
            html.Append($"<td>{"Employee ID"}</td>");
            html.Append($"<td>{"First Name"}</td>");
            html.Append($"<td>{"Last name"}</td>");
            html.Append($"<td>{"Sunday"}</td>");
            html.Append($"<td>{"Monday"}</td>");
            html.Append($"<td>{"Tuesday"}</td>");
            html.Append($"<td>{"Wednesday"}</td>");
            html.Append($"<td>{"Thursday"}</td>");
            html.Append($"<td>{"Friday"}</td>");
            html.Append($"<td>{"Saturday"}</td>");
            html.Append("</tr>");
            html.Append("<tr><td colspan=10><hr/></td></tr>");

            while (reader.Read())
            {
                html.Append($"<td>{reader.GetInt32(0)}</td>");
                html.Append($"<td>{reader.GetString(1)}</td>");
                html.Append($"<td>{reader.GetString(2)}</td>");
                html.Append($"<td>{reader.GetString(3)}</td>");
                html.Append($"<td>{reader.GetString(4)}</td>");
                html.Append($"<td>{reader.GetString(5)}</td>");
                html.Append($"<td>{reader.GetString(6)}</td>");
                html.Append($"<td>{reader.GetString(7)}</td>");
                html.Append($"<td>{reader.GetString(8)}</td>");
                html.Append($"<td>{reader.GetString(9)}</td>");
                html.Append("</tr>");
            }
            html.Append("<tr><td colspan=10><hr/></td></tr>");
            html.Append("</table>");
            html.Append("</body></html>");

            reader.Close();
            return html;
        }

        public static StringBuilder GenerateSalesReport(string strPeriod, DateTime today)
        {
            string strStartDate = "";
            string strEndDate = "";
            double dblTotalSales = 0;

            if(strPeriod == "Weekly")
            {
                strStartDate = today.AddDays(-7).Year.ToString() + "-" + today.AddDays(-7).Month.ToString() + "-" + today.AddDays(-7).Day.ToString();
                strEndDate = today.Year.ToString() + "-" + today.Month.ToString() + "-" + today.Day.ToString();
            }
            else if(strPeriod == "Monthly")
            {
                strStartDate = today.AddDays(-30).Year.ToString() + "-" + today.AddDays(-30).Month.ToString() + "-" + today.AddDays(-30).Day.ToString();
                strEndDate = today.Year.ToString() + "-" + today.Month.ToString() + "-" + today.Day.ToString();
            }
            else //Daily
            {
                strStartDate = today.Year.ToString() + "-" + today.Month.ToString() + "-" + today.Day.ToString();
                strEndDate = today.Year.ToString() + "-" + today.Month.ToString() + "-" + today.Day.ToString();
            }

            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

            css.Append("<style>");
            css.Append("td {padding:5px;text-align:center;font-weight:bold;text-align:conter;}");
            css.Append("h1{color: black;}");
            css.Append("</style>");

            html.Append("<html>");
            html.Append($"<head>{css}<title>" + strPeriod + " Sales</title></head>");
            html.Append("<body>");
            html.Append($"<h1>" + strPeriod + " Sales</h1>");

            SqlDataReader reader;
            SqlCommand cmd;
            cmd = _cntDatabase.CreateCommand();
            cmd.CommandText = "SELECT ProductName, TotalPrice, OrderDate FROM FullerIsp212332.Products JOIN FullerIsp212332.Invoices ON Products.ProductID = Invoices.ProductID WHERE OrderDate BETWEEN '" + strStartDate + "' AND '" + strEndDate +"'";
            reader = cmd.ExecuteReader();

            html.Append("<table>");
            html.Append("<tr><td colspan=3><hr/></td></tr>");
            html.Append($"<td>{"Product Name"}</td>");
            html.Append($"<td>{"Total Price"}</td>");
            html.Append($"<td>{"Order Date"}</td>");
            html.Append("</tr>");
            html.Append("<tr><td colspan=3><hr/></td></tr>");

            while (reader.Read())
            {
                html.Append($"<td>{reader.GetString(0)}</td>");
                html.Append($"<td>{reader.GetDecimal(1)}</td>");
                dblTotalSales += (double)reader.GetDecimal(1);
                html.Append($"<td>{reader.GetDateTime(2)}</td>");
                html.Append("</tr>");
            }
            html.Append("<tr><td colspan=3><hr/></td></tr>");
            html.Append("</table>");
            html.Append($"<h3>Total Sales: $" + dblTotalSales + " Sales</h3>");
            html.Append("</body></html>");

            reader.Close();
            return html;
        }

        public static StringBuilder GenerateManagerPurchaseReceipt(string strProductName, int intQuantity, double dblPrice)
        {
            string strGetID = $"SELECT ProductID FROM FullerIsp212332.Products WHERE ProductName = '{strProductName}'";
            SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
            int intProductID = (int)cmdGetID.ExecuteScalar();

            string strInsertQuery = $"INSERT INTO FullerIsp212332.ManagerPurchases VALUES({intProductID}, {intQuantity}, {dblPrice}, {dblPrice * (double)intQuantity})";
            SqlCommand cmdInsertQuery = new SqlCommand(strInsertQuery, _cntDatabase);
            cmdInsertQuery.ExecuteNonQuery();

            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

            css.Append("<style>");
            css.Append("td {padding:5px;text-align:center;font-weight:bold;text-align:conter;}");
            css.Append("h1{color: black;}");
            css.Append("</style>");

            html.Append("<html>");
            html.Append($"<head>{css}<title>Manager Purchase Receipt</title></head>");
            html.Append("<body>");
            html.Append($"<h1>Manager Purchase Receipt</h1>");

            html.Append("<table>");
            html.Append("<tr><td colspan=5><hr/></td></tr>");
            html.Append($"<td>{"Product Name"}</td>");
            html.Append($"<td>{"Quantity"}</td>");
            html.Append($"<td>{"Price Per Item"}</td>");
            html.Append($"<td>{"Total Price"}</td>");
            html.Append($"<td>{"Total (With Tax)"}</td>");
            html.Append("</tr>");
            html.Append("<tr><td colspan=5><hr/></td></tr>");

            SqlDataReader reader;
            SqlCommand cmd;
            cmd = _cntDatabase.CreateCommand();
            cmd.CommandText = "SELECT ProductName, QuantityPurchased, PricePerItem, TotalPrice FROM FullerIsp212332.Products JOIN FullerIsp212332.ManagerPurchases ON Products.ProductID = ManagerPurchases.ProductID";
            reader = cmd.ExecuteReader();

            double dblTotalCost = 0;
            html.Append("<tr><td colspan=5><hr/></td></tr>");
            while(reader.Read())
            {
                html.Append("<tr><td colspan=5></td></tr>");
                html.Append($"<td>{reader.GetString(0)}</td>");
                html.Append($"<td>{reader.GetInt32(1)}</td>");
                html.Append($"<td>${Math.Round(reader.GetDecimal(2), 2)}</td>");
                html.Append($"<td>${Math.Round(reader.GetDecimal(3), 2)}</td>");
                dblTotalCost += (double)reader.GetDecimal(3);
                html.Append($"<td>${Math.Round((double)reader.GetDecimal(3) * 1.0825, 2)}</td>");
                html.Append("<tr><td colspan=5></td></tr>");
            }
            html.Append("<tr><td colspan=5><hr/></td></tr>");
            html.Append("</table>");
            html.Append($"<h3>Total Price: ${Math.Round(dblTotalCost, 2)}, With Tax: ${Math.Round(dblTotalCost * 1.0825, 2)}");
            html.Append("</body></html>");

            reader.Close();
            return html;
        }

        //REPORTS END---------------------------------------------------------------------------------------------------------------------------------------------------------

        public static string[] GetEmployeeInformation(string strCurrentUser)
        {
            string[] arrEmployeeInfo = new string[5];

            string strGetFName = "SELECT FirstName FROM FullerIsp212332.Employees WHERE Username = '" + strCurrentUser + "'";
            SqlCommand cmdGetFName = new SqlCommand(strGetFName, _cntDatabase);
            arrEmployeeInfo[0] = (string)cmdGetFName.ExecuteScalar();

            string strGetLName = "SELECT LastName FROM FullerIsp212332.Employees WHERE Username = '" + strCurrentUser + "'";
            SqlCommand cmdGetLName = new SqlCommand(strGetLName, _cntDatabase);
            arrEmployeeInfo[1] = (string)cmdGetLName.ExecuteScalar();

            string strGetAddress = "SELECT Address FROM FullerIsp212332.Employees WHERE Username = '" + strCurrentUser + "'";
            SqlCommand cmdGetAddress = new SqlCommand(strGetAddress, _cntDatabase);
            arrEmployeeInfo[2] = (string)cmdGetAddress.ExecuteScalar();

            arrEmployeeInfo[3] = strCurrentUser;

            string strGetPassword = "SELECT Password FROM FullerIsp212332.Employees WHERE Username = '" + strCurrentUser + "'";
            SqlCommand cmdGetPasswords = new SqlCommand(strGetPassword, _cntDatabase);
            arrEmployeeInfo[4] = (string)cmdGetPasswords.ExecuteScalar();

            return arrEmployeeInfo;
        }

        public static void UpdateEmployeeInformation(string strCurrentUser, string strNewFName, string strNewLName, string strNewAddress, string strNewUsername, string strNewPassword)
        {
            string strGetID = "SELECT EmployeeID FROM FullerIsp212332.Employees WHERE Username = '" + strCurrentUser + "'";
            SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
            int intEmployeeID = (int)cmdGetID.ExecuteScalar();

            string strUpdate = "UPDATE FullerIsp212332.Employees SET FirstName = '" + strNewFName + "', Lastname = '" + strNewLName + "', Address = '" + strNewAddress + "', Username = '" + strNewUsername + "', Password = '" + strNewPassword + "' WHERE EmployeeID = " + intEmployeeID;
            SqlCommand cmdUpdate = new SqlCommand(strUpdate, _cntDatabase);
            cmdUpdate.ExecuteNonQuery();

            MessageBox.Show("Information Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //ADD, UPDATE, DELETE SCHEDULES START---------------------------------------------------------------------------------------------------------------------------------------------
        public static List<string[]> GetEmployeeNames()
        {
            List<string[]> lstNames = new List<string[]>();

            SqlDataReader reader;
            SqlCommand cmd;
            cmd = _cntDatabase.CreateCommand();
            cmd.CommandText = "SELECT * FROM FullerIsp212332.Employees";
            reader = cmd.ExecuteReader();

            int intListIndex = 0;
            while(reader.Read())
            {
                lstNames.Add(new string[2]);
                lstNames[intListIndex][0] = reader.GetString(1);
                lstNames[intListIndex][1] = reader.GetString(2);
                intListIndex++;
            }

            reader.Close();
            return lstNames;
        }
        
        public static void AddSchedule(string strFName, string strLName, string strSunday, string strMonday, string strTuesday, string strWednesday, string strThursday, string strFriday, string strSaturday, string strWeek)
        {
            string strGetID = "SELECT EmployeeID FROM FullerIsp212332.Employees WHERE FirstName = '" + strFName + "' AND LastName = '" + strLName + "'";
            SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
            int intEmployeeID = (int)cmdGetID.ExecuteScalar();

            string strStartDate = "";
            if(strWeek == "This Week")
            {
                DateTime tempDate = DateTime.Now;

                switch(DateTime.Now.DayOfWeek.ToString())
                {
                    case "Sunday":
                        tempDate = DateTime.Now;
                        break;
                    case "Monday":
                        tempDate = DateTime.Now.AddDays(-1);
                        break;
                    case "Tuesday":
                        tempDate = DateTime.Now.AddDays(-2);
                        break;
                    case "Wednesday":
                        tempDate = DateTime.Now.AddDays(-3);
                        break;
                    case "Thursday":
                        tempDate = DateTime.Now.AddDays(-4);
                        break;
                    case "Friday":
                        tempDate = DateTime.Now.AddDays(-5);
                        break;
                    case "Saturday":
                        tempDate = DateTime.Now.AddDays(-6);
                        break;
                }

                strStartDate = "'" + tempDate.Year.ToString() + "-" + FormatDayOrMonth(tempDate.Month.ToString()) + "-" + FormatDayOrMonth(tempDate.Day.ToString()) + "'";
            }
            else if (strWeek == "Next Week")
            {
                DateTime tempDate = DateTime.Now;

                switch (DateTime.Now.DayOfWeek.ToString())
                {
                    case "Sunday":
                        tempDate = DateTime.Now;
                        break;
                    case "Monday":
                        tempDate = DateTime.Now.AddDays(-1);
                        break;
                    case "Tuesday":
                        tempDate = DateTime.Now.AddDays(-2);
                        break;
                    case "Wednesday":
                        tempDate = DateTime.Now.AddDays(-3);
                        break;
                    case "Thursday":
                        tempDate = DateTime.Now.AddDays(-4);
                        break;
                    case "Friday":
                        tempDate = DateTime.Now.AddDays(-5);
                        break;
                    case "Saturday":
                        tempDate = DateTime.Now.AddDays(-6);
                        break;
                }

                tempDate = tempDate.AddDays(7);

                strStartDate = "'" + tempDate.Year.ToString() + "-" + FormatDayOrMonth(tempDate.Month.ToString()) + "-" + FormatDayOrMonth(tempDate.Day.ToString()) + "'";
            }
            else
            {
                MessageBox.Show("Invalid Date.", "Error Creating Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string strInsertSchedule = "INSERT INTO FullerIsp212332.Schedules(EmployeeID, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, StartDate) VALUES(" + intEmployeeID + ", '" + strSunday + "', '" + strMonday + "', '" + strTuesday + "', '" + strWednesday + "', '" + strThursday + "', '" + strFriday + "', '" + strSaturday + "', " + strStartDate + ")";
            SqlCommand cmdInsertSchedule = new SqlCommand(strInsertSchedule, _cntDatabase);
            cmdInsertSchedule.ExecuteNonQuery();

            MessageBox.Show("Schedule Created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void RemoveSchedule(string strFName, string strLName, string strWeek)
        {
            string strGetID = "SELECT EmployeeID FROM FullerIsp212332.Employees WHERE FirstName = '" + strFName + "' AND LastName = '" + strLName + "'";
            SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
            int intEmployeeID = (int)cmdGetID.ExecuteScalar();

            string strStartDate = "";
            if (strWeek == "This Week")
            {
                DateTime tempDate = DateTime.Now;

                switch (DateTime.Now.DayOfWeek.ToString())
                {
                    case "Sunday":
                        tempDate = DateTime.Now;
                        break;
                    case "Monday":
                        tempDate = DateTime.Now.AddDays(-1);
                        break;
                    case "Tuesday":
                        tempDate = DateTime.Now.AddDays(-2);
                        break;
                    case "Wednesday":
                        tempDate = DateTime.Now.AddDays(-3);
                        break;
                    case "Thursday":
                        tempDate = DateTime.Now.AddDays(-4);
                        break;
                    case "Friday":
                        tempDate = DateTime.Now.AddDays(-5);
                        break;
                    case "Saturday":
                        tempDate = DateTime.Now.AddDays(-6);
                        break;
                }

                strStartDate = "'" + tempDate.Year.ToString() + "-" + FormatDayOrMonth(tempDate.Month.ToString()) + "-" + FormatDayOrMonth(tempDate.Day.ToString()) + "'";

                string strDeleteQuery = "DELETE FROM FullerIsp212332.Schedules WHERE StartDate = " + strStartDate;
                SqlCommand cmdDeleteQuery = new SqlCommand(strDeleteQuery, _cntDatabase);
                cmdDeleteQuery.ExecuteNonQuery();
            }
            else if (strWeek == "Next Week")
            {
                DateTime tempDate = DateTime.Now;

                switch (DateTime.Now.DayOfWeek.ToString())
                {
                    case "Sunday":
                        tempDate = DateTime.Now;
                        break;
                    case "Monday":
                        tempDate = DateTime.Now.AddDays(-1);
                        break;
                    case "Tuesday":
                        tempDate = DateTime.Now.AddDays(-2);
                        break;
                    case "Wednesday":
                        tempDate = DateTime.Now.AddDays(-3);
                        break;
                    case "Thursday":
                        tempDate = DateTime.Now.AddDays(-4);
                        break;
                    case "Friday":
                        tempDate = DateTime.Now.AddDays(-5);
                        break;
                    case "Saturday":
                        tempDate = DateTime.Now.AddDays(-6);
                        break;
                }

                tempDate = tempDate.AddDays(7);

                strStartDate = "'" + tempDate.Year.ToString() + "-" + FormatDayOrMonth(tempDate.Month.ToString()) + "-" + FormatDayOrMonth(tempDate.Day.ToString()) + "'";

                string strDeleteQuery = "DELETE FROM FullerIsp212332.Schedules WHERE StartDate = " + strStartDate;
                SqlCommand cmdDeleteQuery = new SqlCommand(strDeleteQuery, _cntDatabase);
                cmdDeleteQuery.ExecuteNonQuery();
            }
            else if (strWeek == "All Previous Weeks")
            {
                DateTime tempDate = DateTime.Now;

                switch (DateTime.Now.DayOfWeek.ToString())
                {
                    case "Sunday":
                        tempDate = DateTime.Now;
                        break;
                    case "Monday":
                        tempDate = DateTime.Now.AddDays(-1);
                        break;
                    case "Tuesday":
                        tempDate = DateTime.Now.AddDays(-2);
                        break;
                    case "Wednesday":
                        tempDate = DateTime.Now.AddDays(-3);
                        break;
                    case "Thursday":
                        tempDate = DateTime.Now.AddDays(-4);
                        break;
                    case "Friday":
                        tempDate = DateTime.Now.AddDays(-5);
                        break;
                    case "Saturday":
                        tempDate = DateTime.Now.AddDays(-6);
                        break;
                }

                strStartDate = "'" + tempDate.Year.ToString() + "-" + FormatDayOrMonth(tempDate.Month.ToString()) + "-" + FormatDayOrMonth(tempDate.Day.ToString()) + "'";

                string strDeleteQuery = "DELETE FROM FullerIsp212332.Schedules WHERE StartDate < " + strStartDate;
                SqlCommand cmdDeleteQuery = new SqlCommand(strDeleteQuery, _cntDatabase);
                cmdDeleteQuery.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Invalid Date.", "Error Creating Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Schedule removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static string[]GetEmployeeTasks(string strFName, string strLName, string strWeek)
        {
            string strGetID = "SELECT EmployeeID FROM FullerIsp212332.Employees WHERE FirstName = '" + strFName + "' AND LastName = '" + strLName + "'";
            SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
            int intEmployeeID = (int)cmdGetID.ExecuteScalar();

            string[] arrTasks = new string[7];

            string strStartDate = "";
            if (strWeek == "This Week")
            {
                DateTime tempDate = DateTime.Now;

                switch (DateTime.Now.DayOfWeek.ToString())
                {
                    case "Sunday":
                        tempDate = DateTime.Now;
                        break;
                    case "Monday":
                        tempDate = DateTime.Now.AddDays(-1);
                        break;
                    case "Tuesday":
                        tempDate = DateTime.Now.AddDays(-2);
                        break;
                    case "Wednesday":
                        tempDate = DateTime.Now.AddDays(-3);
                        break;
                    case "Thursday":
                        tempDate = DateTime.Now.AddDays(-4);
                        break;
                    case "Friday":
                        tempDate = DateTime.Now.AddDays(-5);
                        break;
                    case "Saturday":
                        tempDate = DateTime.Now.AddDays(-6);
                        break;
                }

                strStartDate = "'" + tempDate.Year.ToString() + "-" + FormatDayOrMonth(tempDate.Month.ToString()) + "-" + FormatDayOrMonth(tempDate.Day.ToString()) + "'";
            }
            else if (strWeek == "Next Week")
            {
                DateTime tempDate = DateTime.Now;

                switch (DateTime.Now.DayOfWeek.ToString())
                {
                    case "Sunday":
                        tempDate = DateTime.Now;
                        break;
                    case "Monday":
                        tempDate = DateTime.Now.AddDays(-1);
                        break;
                    case "Tuesday":
                        tempDate = DateTime.Now.AddDays(-2);
                        break;
                    case "Wednesday":
                        tempDate = DateTime.Now.AddDays(-3);
                        break;
                    case "Thursday":
                        tempDate = DateTime.Now.AddDays(-4);
                        break;
                    case "Friday":
                        tempDate = DateTime.Now.AddDays(-5);
                        break;
                    case "Saturday":
                        tempDate = DateTime.Now.AddDays(-6);
                        break;
                }

                tempDate = tempDate.AddDays(7);

                strStartDate = "'" + tempDate.Year.ToString() + "-" + FormatDayOrMonth(tempDate.Month.ToString()) + "-" + FormatDayOrMonth(tempDate.Day.ToString()) + "'";
            }
            else
            {
                MessageBox.Show("Invalid Date.", "Error Updating Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            SqlDataReader reader;
            SqlCommand cmd;
            cmd = _cntDatabase.CreateCommand();
            cmd.CommandText = "SELECT * FROM FullerIsp212332.Schedules WHERE EmployeeID = " + intEmployeeID + " AND StartDate = " + strStartDate;
            reader = cmd.ExecuteReader();

            try
            {
                reader.Read();
                arrTasks[0] = reader.GetString(2);
                arrTasks[1] = reader.GetString(3);
                arrTasks[2] = reader.GetString(4);
                arrTasks[3] = reader.GetString(5);
                arrTasks[4] = reader.GetString(6);
                arrTasks[5] = reader.GetString(7);
                arrTasks[6] = reader.GetString(8);
            }
            catch(Exception ex)
            {
                MessageBox.Show("No schedule found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reader.Close();
                return null;
            }

            reader.Close();
            return arrTasks;
        }

        public static void UpdateSchedule(string strFName, string strLName, string strSunday, string strMonday, string strTuesday, string strWednesday, string strThursday, string strFriday, string strSaturday, string strWeek)
        {
            string strGetID = "SELECT EmployeeID FROM FullerIsp212332.Employees WHERE FirstName = '" + strFName + "' AND LastName = '" + strLName + "'";
            SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
            int intEmployeeID = (int)cmdGetID.ExecuteScalar();

            string strStartDate = "";
            if (strWeek == "This Week")
            {
                DateTime tempDate = DateTime.Now;

                switch (DateTime.Now.DayOfWeek.ToString())
                {
                    case "Sunday":
                        tempDate = DateTime.Now;
                        break;
                    case "Monday":
                        tempDate = DateTime.Now.AddDays(-1);
                        break;
                    case "Tuesday":
                        tempDate = DateTime.Now.AddDays(-2);
                        break;
                    case "Wednesday":
                        tempDate = DateTime.Now.AddDays(-3);
                        break;
                    case "Thursday":
                        tempDate = DateTime.Now.AddDays(-4);
                        break;
                    case "Friday":
                        tempDate = DateTime.Now.AddDays(-5);
                        break;
                    case "Saturday":
                        tempDate = DateTime.Now.AddDays(-6);
                        break;
                }

                strStartDate = "'" + tempDate.Year.ToString() + "-" + FormatDayOrMonth(tempDate.Month.ToString()) + "-" + FormatDayOrMonth(tempDate.Day.ToString()) + "'";
            }
            else if (strWeek == "Next Week")
            {
                DateTime tempDate = DateTime.Now;

                switch (DateTime.Now.DayOfWeek.ToString())
                {
                    case "Sunday":
                        tempDate = DateTime.Now;
                        break;
                    case "Monday":
                        tempDate = DateTime.Now.AddDays(-1);
                        break;
                    case "Tuesday":
                        tempDate = DateTime.Now.AddDays(-2);
                        break;
                    case "Wednesday":
                        tempDate = DateTime.Now.AddDays(-3);
                        break;
                    case "Thursday":
                        tempDate = DateTime.Now.AddDays(-4);
                        break;
                    case "Friday":
                        tempDate = DateTime.Now.AddDays(-5);
                        break;
                    case "Saturday":
                        tempDate = DateTime.Now.AddDays(-6);
                        break;
                }

                tempDate = tempDate.AddDays(7);

                strStartDate = "'" + tempDate.Year.ToString() + "-" + FormatDayOrMonth(tempDate.Month.ToString()) + "-" + FormatDayOrMonth(tempDate.Day.ToString()) + "'";
            }
            else if (strWeek == "Previous Week")
            {
                DateTime tempDate = DateTime.Now;

                switch (DateTime.Now.DayOfWeek.ToString())
                {
                    case "Sunday":
                        tempDate = DateTime.Now;
                        break;
                    case "Monday":
                        tempDate = DateTime.Now.AddDays(-1);
                        break;
                    case "Tuesday":
                        tempDate = DateTime.Now.AddDays(-2);
                        break;
                    case "Wednesday":
                        tempDate = DateTime.Now.AddDays(-3);
                        break;
                    case "Thursday":
                        tempDate = DateTime.Now.AddDays(-4);
                        break;
                    case "Friday":
                        tempDate = DateTime.Now.AddDays(-5);
                        break;
                    case "Saturday":
                        tempDate = DateTime.Now.AddDays(-6);
                        break;
                }

                strStartDate = "'" + tempDate.Year.ToString() + "-" + FormatDayOrMonth(tempDate.Month.ToString()) + "-" + FormatDayOrMonth(tempDate.Day.ToString()) + "'";

                string strUpdateQuery1 = "UPDATE FullerIsp212332.Schedules SET Sunday = '" + strSunday + "', Monday = '" + strMonday + "', Tuesday = '" + strTuesday + "', Wednesday = '" + strWednesday + "', Thursday = '" + strThursday + "', Friday = '" + strFriday + "', Saturday = '" + strSaturday + "' WHERE StartDate = " + strStartDate + " AND EmployeeID = " + intEmployeeID;
                SqlCommand cmdUpdateQuery1 = new SqlCommand(strUpdateQuery1, _cntDatabase);
                cmdUpdateQuery1.ExecuteNonQuery();

                MessageBox.Show("Schedule Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Invalid Date.", "Error Creating Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string strUpdateQuery = "UPDATE FullerIsp212332.Schedules SET Sunday = '" + strSunday + "', Monday = '" + strMonday + "', Tuesday = '" + strTuesday + "', Wednesday = '" + strWednesday + "', Thursday = '" + strThursday + "', Friday = '" + strFriday + "', Saturday = '" + strSaturday + "' WHERE StartDate = " + strStartDate + " AND EmployeeID = " + intEmployeeID;
            SqlCommand cmdUpdateQuery = new SqlCommand(strUpdateQuery, _cntDatabase);
            cmdUpdateQuery.ExecuteNonQuery();

            MessageBox.Show("Schedule Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //ADD, UPDATE, DELETE SCHEDULES START---------------------------------------------------------------------------------------------------------------------------------------------
        
        public static void MakeRequest(string strUsername, string strRequestType, string strRequest)
        {
            string strGetID = "SELECT EmployeeID FROM FullerIsp212332.Employees WHERE Username ='" + strUsername + "'";
            SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
            int intEmployeeID = (int)cmdGetID.ExecuteScalar();

            string strFullRequest = strRequestType + " " + strRequest;
            if (strFullRequest.Length <= 300)
            {
                string strInsertQuery = "INSERT INTO FullerIsp212332.Requests(EmployeeID, Request, Status) VALUES(" + intEmployeeID + ", '" + strFullRequest + "', 'Unread')";
                SqlCommand cmdInsertQuery = new SqlCommand(strInsertQuery, _cntDatabase);
                cmdInsertQuery.ExecuteNonQuery();

                MessageBox.Show("Request made.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Request too long.", "Input Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<string[]> GetRequests()
        {
            List<string[]> lstRequests = new List<string[]>();

            SqlDataReader reader;
            SqlCommand cmd;
            cmd = _cntDatabase.CreateCommand();
            cmd.CommandText = "SELECT * FROM FullerIsp212332.Requests";
            reader = cmd.ExecuteReader();

            int intListIndex = 0;
            while (reader.Read())
            {
                lstRequests.Add(new string[3]);
                lstRequests[intListIndex][0] = reader.GetInt32(0).ToString();
                lstRequests[intListIndex][1] = reader.GetString(2);
                lstRequests[intListIndex][2] = reader.GetString(3);
                intListIndex++;
            }

            reader.Close();
            return lstRequests;
        }

        public static void UpdateRequest(int intRequestID, string strNewStatus)
        {
            string strUpdateQuery = "UPDATE FullerIsp212332.Requests SET Status = '" + strNewStatus + "' WHERE RequestID = " + intRequestID;
            SqlCommand cmdUpdateQuery = new SqlCommand(strUpdateQuery, _cntDatabase);
            cmdUpdateQuery.ExecuteNonQuery();

            MessageBox.Show("Response succesful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
