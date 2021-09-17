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
        //Database Connection
        private static SqlConnection _cntDatabase = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB;" +
                                                                      "AttachDbFilename = " + Application.StartupPath + "\\StoreDatabase.mdf;" +
                                                                      "Integrated Security = True;" +
                                                                      "Connection Timeout = 30");

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
            try
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
            catch (Exception ex2)
            {
                MessageBox.Show("Error showing exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //PANELS START-----------------------------------------------------------------------------------------------------------------------------------------------------
        //Gets count of rows for filling product panels
        public static int GetRowsCount(String strTable)
        {
            try
            {
                string strQuery = "SELECT COUNT(*) FROM dbo." + strTable;
                SqlCommand cmd = new SqlCommand(strQuery, _cntDatabase);
                if (cmd.ExecuteScalar() == null)
                {
                    return 0;
                }
                else
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                ShowSQLException(ex, "Could not get number of rows in requested table.");
                return 0;
            }
        }

        //Fills/Refreshes ProductPanels
        public static void FillRefreshPanels(List<ProductPanel> lstPanels)
        {
            try
            {
                SqlDataReader reader;
                SqlCommand cmd;
                cmd = _cntDatabase.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.Products";
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    long lngLength = reader.GetBytes(5, 0, null, 0, 0); //Gets length of bytes in field
                    byte[] arrBuffer = new byte[lngLength]; //Makes a buffer based on that length
                    reader.GetBytes(5, 0, arrBuffer, 0, (int)lngLength); //Reads the bytes into the array
                    lstPanels.Add(new ProductPanel(reader.GetInt32(0), reader.GetString(1), (double)reader.GetDecimal(2), reader.GetString(3), reader.GetInt32(4), arrBuffer, 0, 0));
                }

                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error retrieving product data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Fills/Refreshes SpecialPanels
        public static void FillRefreshSpecialPanels(List<SpecialPanel> lstPanels)
        {
            try
            {
                SqlDataReader reader;
                SqlCommand cmd;
                cmd = _cntDatabase.CreateCommand();
                cmd.CommandText = "SELECT Products.ProductID, ProductName, Price, Size, UnitsInStock, ProductImage, PriceDiscounted, ExtraDetails FROM dbo.Products JOIN dbo.Specials ON Products.ProductID = Specials.ProductID";
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    long lngLength = reader.GetBytes(5, 0, null, 0, 0); //Gets length of bytes in field
                    byte[] arrBuffer = new byte[lngLength]; //Makes a buffer based on that length
                    reader.GetBytes(5, 0, arrBuffer, 0, (int)lngLength); //Reads the bytes into the array
                    lstPanels.Add(new SpecialPanel(reader.GetInt32(0), reader.GetString(1), (double)reader.GetDecimal(2), reader.GetString(3), reader.GetInt32(4), arrBuffer, 0, 0, reader.GetInt32(6), reader.GetString(7)));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving specials data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //PANELS END---------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Called when user attempts to log in a manager or employee
        public static string Login(string strUsername, string strPassword)
        {
            try
            {
                //Attempts to log in as employee
                string strEmployeeQuery = "SELECT Password FROM dbo.Employees WHERE Username = '" + strUsername + "'";
                SqlCommand employeeCommand = new SqlCommand(strEmployeeQuery, _cntDatabase);
                if ((string)employeeCommand.ExecuteScalar() == strPassword)
                {
                    return "Employee";
                }

                //Attempts to log in as manager
                string strManagerQuery = "SELECT Password FROM dbo.Managers WHERE Username = '" + strUsername + "'";
                SqlCommand managerCommand = new SqlCommand(strManagerQuery, _cntDatabase);
                if ((string)managerCommand.ExecuteScalar() == strPassword)
                {
                    return "Manager";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error logging in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "";
        }

        //Puts an invoice into the invoices table when a purchase is made
        public static void CreateInvoice(string strCity, string strAddress, List<ProductPanel> lstProducts, List<int> lstQuantities)
        {
            try
            {
                int intNewID;

                //new ID = current highest id in table + 1
                if (GetRowsCount("Customers") == 0)
                {
                    intNewID = 1;
                }
                else
                {
                    string strGetHighestID = "SELECT MAX(CustomerID) FROM dbo.Customers";
                    SqlCommand idCommand = new SqlCommand(strGetHighestID, _cntDatabase);
                    intNewID = (int)idCommand.ExecuteScalar() + 1;
                }

                string strInsert = "INSERT INTO dbo.Customers(CustomerID, City, Address) VALUES(" + intNewID + ", '" + strCity + "', '" + strAddress + "')";
                SqlCommand insertCommand = new SqlCommand(strInsert, _cntDatabase);
                insertCommand.ExecuteNonQuery();

                for (int intCurrentProduct = 0; intCurrentProduct < lstProducts.Count; intCurrentProduct++)
                {
                    string strOrderDate = "'" + DateTime.Now.Year.ToString() + "-" + FormatDayOrMonth(DateTime.Now.Month.ToString()) + "-" + FormatDayOrMonth(DateTime.Now.Day.ToString()) + "'";
                    string strNewInvoice = "INSERT INTO dbo.Invoices(CustomerID, ProductID, Discount, Quantity, TotalPrice, OrderDate) VALUES(" + intNewID + ", " + lstProducts[intCurrentProduct].intProductID + ", " + lstProducts[intCurrentProduct].GetDiscount() + ", " + lstQuantities[intCurrentProduct] + ", " + (Math.Round(lstProducts[intCurrentProduct].dblPrice * (1f - (double)lstProducts[intCurrentProduct].GetDiscount() / 100f), 2)) * lstQuantities[intCurrentProduct] + ", " + strOrderDate + ")";
                    SqlCommand invoiceCommand = new SqlCommand(strNewInvoice, _cntDatabase);
                    invoiceCommand.ExecuteNonQuery();
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
            try
            {
                if (strDayMonth.Length == 1)
                {
                    strDayMonth = "0" + strDayMonth;
                }

                return strDayMonth;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error formatting date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "00";
            }
        }

        //PRODUCTS ADD, UPDATE, DELETE START--------------------------------------------------------------------------------------------------------------------------------------------
        //Adds product to products table
        public static void AddNewProduct(string strName, double dblPrice, string strSize, int intStock, byte[] arrBytes)
        {
            try
            {
                string strInsertQuery = $"INSERT INTO dbo.Products(ProductName, Price, Size, UnitsInStock, ProductImage) VALUES('" + strName + "', " + dblPrice + ", '" + strSize + "', " + intStock + ", @Image)";
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
        //Removes product from products table
        public static void RemoveProduct(string strProductName)
        {
            try
            {
                string strGetProductID = "SELECT ProductID FROM dbo.Products WHERE ProductName = '" + strProductName + "'";
                SqlCommand cmdGetProductID = new SqlCommand(strGetProductID, _cntDatabase);
                int intProductID = 0;
                if (cmdGetProductID.ExecuteScalar() == null)
                {
                    MessageBox.Show("Could not find product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    intProductID = (int)cmdGetProductID.ExecuteScalar();
                }

                string strRemoveSpecials = "DELETE FROM dbo.Specials WHERE ProductID = " + intProductID;
                SqlCommand cmdRemoveSpecials = new SqlCommand(strRemoveSpecials, _cntDatabase);
                cmdRemoveSpecials.ExecuteNonQuery();

                string strRemovePurchases = "DELETE FROM dbo.ManagerPurchases WHERE ProductID = " + intProductID;
                SqlCommand cmdRemovePurchases = new SqlCommand(strRemovePurchases, _cntDatabase);
                cmdRemovePurchases.ExecuteNonQuery();

                string strRemoveProduct = "DELETE FROM dbo.Products WHERE ProductID = " + intProductID;
                SqlCommand cmdRemoveProduct = new SqlCommand(strRemoveProduct, _cntDatabase);
                cmdRemoveProduct.ExecuteNonQuery();

                MessageBox.Show("Product successfully removed from database.", "Product Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowSQLException(ex, "Failed to remove product");
            }
        }
        //Updates product value by column name passed in
        public static void UpdateProduct(string strColumnName, string strNewValue, string strProductName)
        {
            try
            {
                if(strColumnName == "ProductName")
                {
                    if (strNewValue.Length <= 50)
                    {
                        string strUpdateQuery = "UPDATE dbo.Products SET " + strColumnName + " = '" + strNewValue + "' WHERE ProductName = '" + strProductName + "'";
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
                        string strUpdateQuery = "UPDATE dbo.Products SET " + strColumnName + " = " + dblPrice + " WHERE ProductName = '" + strProductName + "'";
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
                        string strUpdateQuery = "UPDATE dbo.Products SET " + strColumnName + " = " + strNewValue + " WHERE ProductName = '" + strProductName + "'";
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
                        string strGetOldQuantity = $"SELECT UnitsInStock FROM dbo.Products WHERE ProductName = '{strProductName}'";
                        SqlCommand cmdGetOldQuantity = new SqlCommand(strGetOldQuantity, _cntDatabase);
                        int intOldQuantity = 0;
                        if(cmdGetOldQuantity.ExecuteScalar() == null)
                        {
                            MessageBox.Show("Product not found", "Error Updating Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            intOldQuantity = (int)cmdGetOldQuantity.ExecuteScalar();
                        }

                        string strGetPrice = $"SELECT Price FROM dbo.Products WHERE ProductName = '{strProductName}'";
                        SqlCommand cmdGetPrice = new SqlCommand(strGetPrice, _cntDatabase);
                        double dblPrice = 0;
                        if (cmdGetPrice.ExecuteScalar() == null)
                        {
                            MessageBox.Show("Product not found", "Error Updating Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            dblPrice = (double)(decimal)cmdGetPrice.ExecuteScalar();
                        }

                        string strUpdateQuery = "UPDATE dbo.Products SET " + strColumnName + " = " + intStock + " WHERE ProductName = '" + strProductName + "'";
                        SqlCommand cmdUpdateQuery = new SqlCommand(strUpdateQuery, _cntDatabase);
                        cmdUpdateQuery.ExecuteNonQuery();

                        StringBuilder html = GenerateManagerPurchaseReceipt(strProductName, intStock - intOldQuantity, dblPrice);

                        string strFileName = "ManagerPurchaseReceipt.html";
                        try
                        {
                            string strDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";

                            using (StreamWriter swWriter = new StreamWriter(strDesktopPath + strFileName))
                            {
                                swWriter.WriteLine(html);
                            }
                            System.Diagnostics.Process.Start(strDesktopPath + strFileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("You don't have write permissions", "Error System Permissions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        DateTime dtToday = DateTime.Now;
                        using (StreamWriter swWriter = new StreamWriter($"{dtToday.ToString("yyyy-MM-dd-HHmmss")} - " + strFileName))
                        {
                            swWriter.WriteLine(html);
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
                    string strUpdateQuery = "UPDATE dbo.Products SET " + strColumnName + " = @Image WHERE ProductName = '" + strProductName + "'";
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
        //Add special
        public static void AddSpecial(string strProductName, int intDiscount, string strExtraDetails)
        {
            try
            {
                string strGetProductID = "SELECT ProductID FROM dbo.Products WHERE ProductName = '" + strProductName + "'";
                SqlCommand cmdGetProductID = new SqlCommand(strGetProductID, _cntDatabase);
                int intProductID = 0;
                if(cmdGetProductID.ExecuteScalar() == null)
                {
                    MessageBox.Show("Special not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    intProductID = (int)cmdGetProductID.ExecuteScalar();
                }

                string strInsertCommand = "INSERT INTO dbo.Specials(ProductID, PriceDiscounted, ExtraDetails) VALUES(" + intProductID + ", " + intDiscount + ", '" + strExtraDetails + "')";
                SqlCommand cmdInsertCommand = new SqlCommand(strInsertCommand, _cntDatabase);
                cmdInsertCommand.ExecuteNonQuery();

                MessageBox.Show("Special successfully added.", "Special Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error adding special", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //remove special
        public static void RemoveSpecial(string strName, int intDiscount)
        {
            try
            {
                string strGetOldProductID = "SELECT ProductID FROM dbo.Products WHERE ProductName = '" + strName + "'";
                SqlCommand cmdGetOldProductID = new SqlCommand(strGetOldProductID, _cntDatabase);
                int intOldProductID = 0;
                if (cmdGetOldProductID.ExecuteScalar() == null)
                {
                    MessageBox.Show("Special not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    intOldProductID = (int)cmdGetOldProductID.ExecuteScalar();
                }

                string strDeleteQuery = "DELETE FROM dbo.Specials WHERE ProductID = " + intOldProductID + " AND PriceDiscounted = " + intDiscount;
                SqlCommand cmdDeleteQuery = new SqlCommand(strDeleteQuery, _cntDatabase);
                cmdDeleteQuery.ExecuteNonQuery();

                MessageBox.Show("Special successfully removed from database.", "Special Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                ShowSQLException(ex, "Failed to remove special");
            }
        }
        //Updates special value by column name passed in
        public static void UpdateSpecial(string strName, int intDiscount, string strColumnName, string strNewValue)
        {
            try
            {
                if (strColumnName == "Product")
                {
                    string strGetOldProductID = "SELECT ProductID FROM dbo.Products WHERE ProductName = '" + strName + "'";
                    SqlCommand cmdGetOldProductID = new SqlCommand(strGetOldProductID, _cntDatabase);
                    int intOldProductID = 0;
                    if (cmdGetOldProductID.ExecuteScalar() == null)
                    {
                        MessageBox.Show("Special not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        intOldProductID = (int)cmdGetOldProductID.ExecuteScalar();
                    }

                    string strGetNewProductID = "SELECT ProductID FROM dbo.Products WHERE ProductName = '" + strNewValue + "'";
                    SqlCommand cmdGetNewProductID = new SqlCommand(strGetNewProductID, _cntDatabase);
                    int intNewProductID = 0;
                    if (cmdGetNewProductID.ExecuteScalar() == null)
                    {
                        MessageBox.Show("Special not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        intNewProductID = (int)cmdGetNewProductID.ExecuteScalar();
                    }

                    string strUpdateQuery = "UPDATE dbo.Specials SET ProductID = " + intNewProductID + " WHERE ProductID = " + intOldProductID + " AND PriceDiscounted = " + intDiscount;
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

                        string strGetOldProductID = "SELECT ProductID FROM dbo.Products WHERE ProductName = '" + strName + "'";
                        SqlCommand cmdGetOldProductID = new SqlCommand(strGetOldProductID, _cntDatabase);
                        int intOldProductID = 0;
                        if (cmdGetOldProductID.ExecuteScalar() == null)
                        {
                            MessageBox.Show("Special not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            intOldProductID = (int)cmdGetOldProductID.ExecuteScalar();
                        }

                        string strUpdateQuery = "UPDATE dbo.Specials SET " + strColumnName + " = " + intNewDiscount + " WHERE ProductID = " + intOldProductID + " AND PriceDiscounted = " + intDiscount;
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
                        string strGetOldProductID = "SELECT ProductID FROM dbo.Products WHERE ProductName = '" + strName + "'";
                        SqlCommand cmdGetOldProductID = new SqlCommand(strGetOldProductID, _cntDatabase);
                        int intOldProductID = 0;
                        if (cmdGetOldProductID.ExecuteScalar() == null)
                        {
                            MessageBox.Show("Special not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            intOldProductID = (int)cmdGetOldProductID.ExecuteScalar();
                        }

                        string strUpdateQuery = "UPDATE dbo.Specials SET " + strColumnName + " = '" + strNewValue + "' WHERE ProductID = " + intOldProductID + " AND PriceDiscounted = " + intDiscount;
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
        //Fills data grid view with schedule
        public static string GetSchedule(string strUsername, DataGridView dgvSchedule, string strWeek)
        {
            try
            {
                string strGetID = "SELECT EmployeeID FROM dbo.Employees WHERE Username ='" + strUsername + "'";
                SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
                int intEmployeeID = 0;
                if (cmdGetID.ExecuteScalar() == null)
                {
                    MessageBox.Show("Schedule not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Not found";
                }
                else
                {
                    intEmployeeID = (int)cmdGetID.ExecuteScalar();
                }

                string strStartDate = "";
                if (strWeek == "This Week")
                {
                    DateTime dtTempDate = DateTime.Now;

                    switch (DateTime.Now.DayOfWeek.ToString())
                    {
                        case "Sunday":
                            dtTempDate = DateTime.Now;
                            break;
                        case "Monday":
                            dtTempDate = DateTime.Now.AddDays(-1);
                            break;
                        case "Tuesday":
                            dtTempDate = DateTime.Now.AddDays(-2);
                            break;
                        case "Wednesday":
                            dtTempDate = DateTime.Now.AddDays(-3);
                            break;
                        case "Thursday":
                            dtTempDate = DateTime.Now.AddDays(-4);
                            break;
                        case "Friday":
                            dtTempDate = DateTime.Now.AddDays(-5);
                            break;
                        case "Saturday":
                            dtTempDate = DateTime.Now.AddDays(-6);
                            break;
                    }

                    strStartDate = "'" + dtTempDate.Year.ToString() + "-" + FormatDayOrMonth(dtTempDate.Month.ToString()) + "-" + FormatDayOrMonth(dtTempDate.Day.ToString()) + "'";

                    string strGetSchedule = "SELECT Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday FROM dbo.Schedules WHERE EmployeeID = " + intEmployeeID + " AND StartDate = " + strStartDate;
                    SqlCommand cmdGetSchedule = new SqlCommand(strGetSchedule, _cntDatabase);
                    SqlDataAdapter sdaGetSchedule = new SqlDataAdapter();
                    DataTable dtbGetSchedule = new DataTable();

                    sdaGetSchedule.SelectCommand = cmdGetSchedule;
                    sdaGetSchedule.Fill(dtbGetSchedule);
                    dgvSchedule.DataSource = dtbGetSchedule;

                    string strToday = DateTime.Now.DayOfWeek.ToString();
                    string strGetToday = "SELECT " + strToday + " FROM dbo.Schedules WHERE EmployeeID = " + intEmployeeID;
                    SqlCommand cmdGetToday = new SqlCommand(strGetToday, _cntDatabase);
                    return (string)cmdGetToday.ExecuteScalar();
                }
                else if (strWeek == "Next Week")
                {
                    DateTime dtTempDate = DateTime.Now;

                    switch (DateTime.Now.DayOfWeek.ToString())
                    {
                        case "Sunday":
                            dtTempDate = DateTime.Now;
                            break;
                        case "Monday":
                            dtTempDate = DateTime.Now.AddDays(-1);
                            break;
                        case "Tuesday":
                            dtTempDate = DateTime.Now.AddDays(-2);
                            break;
                        case "Wednesday":
                            dtTempDate = DateTime.Now.AddDays(-3);
                            break;
                        case "Thursday":
                            dtTempDate = DateTime.Now.AddDays(-4);
                            break;
                        case "Friday":
                            dtTempDate = DateTime.Now.AddDays(-5);
                            break;
                        case "Saturday":
                            dtTempDate = DateTime.Now.AddDays(-6);
                            break;
                    }

                    dtTempDate = dtTempDate.AddDays(7);

                    strStartDate = "'" + dtTempDate.Year.ToString() + "-" + FormatDayOrMonth(dtTempDate.Month.ToString()) + "-" + FormatDayOrMonth(dtTempDate.Day.ToString()) + "'";

                    string strGetSchedule = "SELECT Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday FROM dbo.Schedules WHERE EmployeeID = " + intEmployeeID + " AND StartDate = " + strStartDate;
                    SqlCommand cmdGetSchedule = new SqlCommand(strGetSchedule, _cntDatabase);
                    SqlDataAdapter sdaGetSchedule = new SqlDataAdapter();
                    DataTable dtbGetSchedule = new DataTable();

                    sdaGetSchedule.SelectCommand = cmdGetSchedule;
                    sdaGetSchedule.Fill(dtbGetSchedule);
                    dgvSchedule.DataSource = dtbGetSchedule;

                    string strToday = DateTime.Now.DayOfWeek.ToString();
                    string strGetToday = "SELECT " + strToday + " FROM dbo.Schedules WHERE EmployeeID = " + intEmployeeID;
                    SqlCommand cmdGetToday = new SqlCommand(strGetToday, _cntDatabase);
                    return (string)cmdGetToday.ExecuteScalar();
                }
                else if (strWeek == "All Previous Weeks")
                {
                    DateTime dtTempDate = DateTime.Now;

                    switch (DateTime.Now.DayOfWeek.ToString())
                    {
                        case "Sunday":
                            dtTempDate = DateTime.Now;
                            break;
                        case "Monday":
                            dtTempDate = DateTime.Now.AddDays(-1);
                            break;
                        case "Tuesday":
                            dtTempDate = DateTime.Now.AddDays(-2);
                            break;
                        case "Wednesday":
                            dtTempDate = DateTime.Now.AddDays(-3);
                            break;
                        case "Thursday":
                            dtTempDate = DateTime.Now.AddDays(-4);
                            break;
                        case "Friday":
                            dtTempDate = DateTime.Now.AddDays(-5);
                            break;
                        case "Saturday":
                            dtTempDate = DateTime.Now.AddDays(-6);
                            break;
                    }

                    strStartDate = "'" + dtTempDate.Year.ToString() + "-" + FormatDayOrMonth(dtTempDate.Month.ToString()) + "-" + FormatDayOrMonth(dtTempDate.Day.ToString()) + "'";

                    string strGetSchedule = "SELECT Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday FROM dbo.Schedules WHERE EmployeeID = " + intEmployeeID + " AND StartDate < " + strStartDate;
                    SqlCommand cmdGetSchedule = new SqlCommand(strGetSchedule, _cntDatabase);
                    SqlDataAdapter sdaGetSchedule = new SqlDataAdapter();
                    DataTable dtbGetSchedule = new DataTable();

                    sdaGetSchedule.SelectCommand = cmdGetSchedule;
                    sdaGetSchedule.Fill(dtbGetSchedule);
                    dgvSchedule.DataSource = dtbGetSchedule;

                    string strToday = DateTime.Now.DayOfWeek.ToString();
                    string strGetToday = "SELECT " + strToday + " FROM dbo.Schedules WHERE EmployeeID = " + intEmployeeID;
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

        //gets requests from requests table
        public static void GetRequests(DataGridView dgvRequests)
        {
            try
            {
                string strGetRequests = "SELECT RequestID, FirstName, LastName, Request, Status FROM dbo.Requests JOIN dbo.Employees ON Requests.EmployeeID = Employees.EmployeeID";
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
        //Generates a report of all the products in the Products table
        public static StringBuilder GenerateInventoryReport()
        {
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

            try
            {
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
                cmd.CommandText = "SELECT ProductID, ProductName, Price, Size, UnitsInStock FROM dbo.Products";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot print report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                html.Append("<html><body><h1>Error</h1></body></html>");
            }

            return html;
        }
        //Generates a report of all the employee schedules
        public static StringBuilder GenerateScheduleReport()
        {
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

            try
            {
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
                cmd.CommandText = "SELECT Employees.EmployeeID, FirstName, LastName, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday FROM dbo.Employees JOIN dbo.Schedules ON Employees.EmployeeID = Schedules.EmployeeID";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot print report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                html.Append("<html><body><h1>Error</h1></body></html>");
            }

            return html;
        }
        //Generates a report that adds all of the sales from the Invoices table
        public static StringBuilder GenerateSalesReport(string strPeriod, DateTime dtToday)
        {
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

            try
            {
                string strStartDate = "";
                string strEndDate = "";
                double dblTotalSales = 0;

                if (strPeriod == "Weekly")
                {
                    strStartDate = dtToday.AddDays(-7).Year.ToString() + "-" + dtToday.AddDays(-7).Month.ToString() + "-" + dtToday.AddDays(-7).Day.ToString();
                    strEndDate = dtToday.Year.ToString() + "-" + dtToday.Month.ToString() + "-" + dtToday.Day.ToString();
                }
                else if (strPeriod == "Monthly")
                {
                    strStartDate = dtToday.AddDays(-30).Year.ToString() + "-" + dtToday.AddDays(-30).Month.ToString() + "-" + dtToday.AddDays(-30).Day.ToString();
                    strEndDate = dtToday.Year.ToString() + "-" + dtToday.Month.ToString() + "-" + dtToday.Day.ToString();
                }
                else //Daily
                {
                    strStartDate = dtToday.Year.ToString() + "-" + dtToday.Month.ToString() + "-" + dtToday.Day.ToString();
                    strEndDate = dtToday.Year.ToString() + "-" + dtToday.Month.ToString() + "-" + dtToday.Day.ToString();
                }

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
                cmd.CommandText = "SELECT ProductName, TotalPrice, OrderDate FROM dbo.Products JOIN dbo.Invoices ON Products.ProductID = Invoices.ProductID WHERE OrderDate BETWEEN '" + strStartDate + "' AND '" + strEndDate + "'";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot print report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                html.Append("<html><body><h1>Error</h1></body></html>");
            }

            return html;
        }
        //Generates a report that totals the managers purchases
        public static StringBuilder GenerateManagerPurchaseReceipt(string strProductName, int intQuantity, double dblPrice)
        {
            StringBuilder html = new StringBuilder();
            StringBuilder css = new StringBuilder();

            try
            {
                string strGetID = $"SELECT ProductID FROM dbo.Products WHERE ProductName = '{strProductName}'";
                SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
                int intProductID = 0;
                if(cmdGetID.ExecuteScalar() == null)
                {
                    MessageBox.Show("Cannot print receipt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    html.Append("<html><body><h1>Error</h1></body></html>");
                    return html;
                }
                else
                {
                    intProductID = (int)cmdGetID.ExecuteScalar();
                }

                string strInsertQuery = $"INSERT INTO dbo.ManagerPurchases VALUES({intProductID}, {intQuantity}, {dblPrice}, {dblPrice * (double)intQuantity})";
                SqlCommand cmdInsertQuery = new SqlCommand(strInsertQuery, _cntDatabase);
                cmdInsertQuery.ExecuteNonQuery();

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
                cmd.CommandText = "SELECT ProductName, QuantityPurchased, PricePerItem, TotalPrice FROM dbo.Products JOIN dbo.ManagerPurchases ON Products.ProductID = ManagerPurchases.ProductID";
                reader = cmd.ExecuteReader();

                double dblTotalCost = 0;
                html.Append("<tr><td colspan=5><hr/></td></tr>");
                while (reader.Read())
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot print receipt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                html.Append("<html><body><h1>Error</h1></body></html>");
            }

            return html;
        }

        //REPORTS END---------------------------------------------------------------------------------------------------------------------------------------------------------
        //Fills the textboxes on frmUpdateEmployee so the employee knows what they are changing
        public static string[] GetEmployeeInformation(string strCurrentUser)
        {
            string[] arrEmployeeInfo = { "", "", "", "", "" };

            try
            {
                string strGetFName = "SELECT FirstName FROM dbo.Employees WHERE Username = '" + strCurrentUser + "'";
                SqlCommand cmdGetFName = new SqlCommand(strGetFName, _cntDatabase);
                if(cmdGetFName.ExecuteScalar() == null)
                {
                    MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return arrEmployeeInfo;
                }
                else
                {
                    arrEmployeeInfo[0] = (string)cmdGetFName.ExecuteScalar();
                }

                string strGetLName = "SELECT LastName FROM dbo.Employees WHERE Username = '" + strCurrentUser + "'";
                SqlCommand cmdGetLName = new SqlCommand(strGetLName, _cntDatabase);
                arrEmployeeInfo[1] = (string)cmdGetLName.ExecuteScalar();

                string strGetAddress = "SELECT Address FROM dbo.Employees WHERE Username = '" + strCurrentUser + "'";
                SqlCommand cmdGetAddress = new SqlCommand(strGetAddress, _cntDatabase);
                arrEmployeeInfo[2] = (string)cmdGetAddress.ExecuteScalar();

                arrEmployeeInfo[3] = strCurrentUser;

                string strGetPassword = "SELECT Password FROM dbo.Employees WHERE Username = '" + strCurrentUser + "'";
                SqlCommand cmdGetPasswords = new SqlCommand(strGetPassword, _cntDatabase);
                arrEmployeeInfo[4] = (string)cmdGetPasswords.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot retrieve employee information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return arrEmployeeInfo;
        }
        //Updates the employee's information
        public static void UpdateEmployeeInformation(string strCurrentUser, string strNewFName, string strNewLName, string strNewAddress, string strNewUsername, string strNewPassword)
        {
            try
            {
                string strGetID = "SELECT EmployeeID FROM dbo.Employees WHERE Username = '" + strCurrentUser + "'";
                SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
                int intEmployeeID = 0;
                if (cmdGetID.ExecuteScalar() == null)
                {
                    MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    intEmployeeID = (int)cmdGetID.ExecuteScalar();
                }

                string strUpdate = "UPDATE dbo.Employees SET FirstName = '" + strNewFName + "', Lastname = '" + strNewLName + "', Address = '" + strNewAddress + "', Username = '" + strNewUsername + "', Password = '" + strNewPassword + "' WHERE EmployeeID = " + intEmployeeID;
                SqlCommand cmdUpdate = new SqlCommand(strUpdate, _cntDatabase);
                cmdUpdate.ExecuteNonQuery();

                MessageBox.Show("Information Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot update information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //SCHEDULING START---------------------------------------------------------------------------------------------------------------------------------------------
        //Gets employee names so schedules can be addes, updated, and removed
        public static List<string[]> GetEmployeeNames()
        {
            List<string[]> lstNames = new List<string[]>();

            try
            {
                SqlDataReader reader;
                SqlCommand cmd;
                cmd = _cntDatabase.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.Employees";
                reader = cmd.ExecuteReader();

                int intListIndex = 0;
                while (reader.Read())
                {
                    lstNames.Add(new string[2]);
                    lstNames[intListIndex][0] = reader.GetString(1);
                    lstNames[intListIndex][1] = reader.GetString(2);
                    intListIndex++;
                }

                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cannot retrieve employee names.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string[] arrEmpty = { "", "" };
                lstNames.Add(arrEmpty);
            }

            return lstNames;
        }

        //Gets all of the StartDates for the shceduels so they can be selected from when updating, removing, etc.
        public static List<string> GetScheduleDates()
        {
            List<string> lstDates = new List<string>();

            try
            {
                SqlDataReader reader;
                SqlCommand cmd;
                cmd = _cntDatabase.CreateCommand();
                cmd.CommandText = "SELECT DISTINCT StartDate FROM dbo.Schedules";
                reader = cmd.ExecuteReader();

                //Formats the date and puts it into the list
                while (reader.Read())
                {
                    lstDates.Add($"{reader.GetDateTime(0).Year.ToString()}-{FormatDayOrMonth(reader.GetDateTime(0).Month.ToString())}-{FormatDayOrMonth(reader.GetDateTime(0).Day.ToString())}");
                }

                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cannot retrieve schedule dates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lstDates.Add("");
            }

            return lstDates;
        }

        //Gets employee tasks for employee viewing and manager updating
        public static string[] GetEmployeeTasks(string strFName, string strLName, string strDate)
        {
            string[] arrTasks = { "", "", "", "", "", "", "" };

            try
            {
                //Gets ID so schedule can be found with foreign key
                string strGetID = $"SELECT EmployeeID FROM dbo.Employees WHERE FirstName = '{strFName}' AND LastName = '{strLName}'";
                SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
                int intEmployeeID = 0;
                if (cmdGetID.ExecuteScalar() == null)
                {
                    MessageBox.Show("Schedule not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return arrTasks;
                }
                else
                {
                    intEmployeeID = (int)cmdGetID.ExecuteScalar();
                }

                SqlDataReader reader;
                SqlCommand cmd;
                cmd = _cntDatabase.CreateCommand();
                cmd.CommandText = $"SELECT * FROM dbo.Schedules WHERE EmployeeID = {intEmployeeID} AND StartDate = '{strDate}'";
                reader = cmd.ExecuteReader();

                try
                {
                    //Puts tasks into array
                    reader.Read();
                    arrTasks[0] = reader.GetString(2);
                    arrTasks[1] = reader.GetString(3);
                    arrTasks[2] = reader.GetString(4);
                    arrTasks[3] = reader.GetString(5);
                    arrTasks[4] = reader.GetString(6);
                    arrTasks[5] = reader.GetString(7);
                    arrTasks[6] = reader.GetString(8);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No schedule for the selected date found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reader.Close();
                }

                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("No schedule for the selected date found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return arrTasks;
        }

        //Adds schedule for employee. An employee can only have one shcedule per week
        public static void AddSchedule(string strFName, string strLName, string strSunday, string strMonday, string strTuesday, string strWednesday, string strThursday, string strFriday, string strSaturday, string strDate)
        {
            try
            {
                //Gets ID so schedule can be found with foreign key
                string strGetID = $"SELECT EmployeeID FROM dbo.Employees WHERE FirstName = '{strFName}' AND LastName = '{strLName}'";
                SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
                int intEmployeeID = 0;
                if (cmdGetID.ExecuteScalar() == null)
                {
                    MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    intEmployeeID = (int)cmdGetID.ExecuteScalar();
                }

                //Cancels creation if the employee already has a schedule for the selected week
                string strCheckForExistance = $"SELECT ScheduleID FROM dbo.Schedules WHERE EmployeeID = {intEmployeeID} AND StartDate = '{strDate}'";
                SqlCommand cmdCheckForExistance = new SqlCommand(strCheckForExistance, _cntDatabase);
                if(cmdCheckForExistance.ExecuteScalar() != null)
                {
                    MessageBox.Show("This employee already has a schedule for the selected week. Try deleting the current schedule before adding, or just update the currently existing schedule.", "Cannot add schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Creates the schedule
                string strInsertSchedule = $"INSERT INTO dbo.Schedules VALUES({intEmployeeID}, '{strSunday}', '{strMonday}', '{strTuesday}', '{strWednesday}', '{strThursday}', '{strFriday}', '{strSaturday}', '{strDate}')";
                SqlCommand cmdInsertSchedule = new SqlCommand(strInsertSchedule, _cntDatabase);
                cmdInsertSchedule.ExecuteNonQuery();

                MessageBox.Show("Schedule Created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cannot add schedule", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Removes a schedule by using the employee's name and shcedule date
        public static void RemoveSchedule(string strFName, string strLName, string strDate)
        {
            try
            {
                //Gets ID from the employee's name so the schedule can be found
                string strGetID = $"SELECT EmployeeID FROM dbo.Employees WHERE FirstName = '{strFName}' AND LastName = '{strLName}'";
                SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
                int intEmployeeID = 0;
                if (cmdGetID.ExecuteScalar() == null)
                {
                    MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    intEmployeeID = (int)cmdGetID.ExecuteScalar();
                }

                //Deletes the schedule
                string strRemoveSchedule = $"DELETE FROM dbo.Schedules WHERE EmployeeID = {intEmployeeID} AND StartDate = '{strDate}'";
                SqlCommand cmdRemoveSchedule = new SqlCommand(strRemoveSchedule, _cntDatabase);
                cmdRemoveSchedule.ExecuteNonQuery();

                MessageBox.Show("Schedule removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cannot remove schedule", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Updates schedule
        public static void UpdateSchedule(string strFName, string strLName, string strSunday, string strMonday, string strTuesday, string strWednesday, string strThursday, string strFriday, string strSaturday, string strDate)
        {
            try
            {
                //Gets ID from the employee's name so the schedule can be found
                string strGetID = $"SELECT EmployeeID FROM dbo.Employees WHERE FirstName = '{strFName}' AND LastName = '{strLName}'";
                SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
                int intEmployeeID = 0;
                if (cmdGetID.ExecuteScalar() == null)
                {
                    MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    intEmployeeID = (int)cmdGetID.ExecuteScalar();
                }

                //Updates the schedule
                string strUpdateQuery = $"UPDATE dbo.Schedules SET Sunday = '{strSunday}', Monday = '{strMonday}', Tuesday = '{strTuesday}', Wednesday = '{strWednesday}', Thursday = '{strThursday}', Friday = '{strFriday}', Saturday = '{strSaturday}' WHERE StartDate = '{strDate}' AND EmployeeID = {intEmployeeID}";
                SqlCommand cmdUpdateQuery = new SqlCommand(strUpdateQuery, _cntDatabase);
                cmdUpdateQuery.ExecuteNonQuery();

                MessageBox.Show("Schedule Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cannot update schedule", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //SCHEDULING END---------------------------------------------------------------------------------------------------------------------------------------------
        
        //REQUESTS START----------------------------------------------------------------------------------------------------------------------------------------------
        //Generates a request based on the type of request that was apssed in
        public static void MakeRequest(string strUsername, string strRequestType, string strRequest)
        {
            try
            {
                string strGetID = "SELECT EmployeeID FROM dbo.Employees WHERE Username ='" + strUsername + "'";
                SqlCommand cmdGetID = new SqlCommand(strGetID, _cntDatabase);
                int intEmployeeID = 0;
                if (cmdGetID.ExecuteScalar() == null)
                {
                    MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    intEmployeeID = (int)cmdGetID.ExecuteScalar();
                }

                string strFullRequest = strRequestType + " " + strRequest;
                if (strFullRequest.Length <= 300)
                {
                    string strInsertQuery = "INSERT INTO dbo.Requests(EmployeeID, Request, Status) VALUES(" + intEmployeeID + ", '" + strFullRequest + "', 'Unread')";
                    SqlCommand cmdInsertQuery = new SqlCommand(strInsertQuery, _cntDatabase);
                    cmdInsertQuery.ExecuteNonQuery();

                    MessageBox.Show("Request made.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Request too long.", "Input Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error requesting change", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //gets requests so managers can see them
        public static List<string[]> GetRequests()
        {
            List<string[]> lstRequests = new List<string[]>();

            try
            {
                SqlDataReader reader;
                SqlCommand cmd;
                cmd = _cntDatabase.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo.Requests";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot get requests", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string[] arrEmpty = { "", "", "" };
                lstRequests.Add(arrEmpty);
            }

            return lstRequests;
        }
        //Updates a request's status when a manager responds to it
        public static void UpdateRequest(int intRequestID, string strNewStatus)
        {
            try
            {
                string strUpdateQuery = "UPDATE dbo.Requests SET Status = '" + strNewStatus + "' WHERE RequestID = " + intRequestID;
                SqlCommand cmdUpdateQuery = new SqlCommand(strUpdateQuery, _cntDatabase);
                cmdUpdateQuery.ExecuteNonQuery();

                MessageBox.Show("Response succesful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating request", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //REQUESTS END----------------------------------------------------------------------------------------------------------------------------------------------
        //Updates the users password when they request a password recovery
        public static void UpdatePassword(string strUsername, string strNewPassword)
        {
            try
            {
                string strUpdateEmployee = $"UPDATE dbo.Employees SET Password = '{strNewPassword}' WHERE Username = '{strUsername}'";
                SqlCommand cmdUpdateEmployee = new SqlCommand(strUpdateEmployee, _cntDatabase);
                cmdUpdateEmployee.ExecuteNonQuery();

                string strUpdateManager = $"UPDATE dbo.Managers SET Password = '{strNewPassword}' WHERE Username = '{strUsername}'";
                SqlCommand cmdUpdateManager = new SqlCommand(strUpdateManager, _cntDatabase);
                cmdUpdateManager.ExecuteNonQuery();

                MessageBox.Show("Email sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating and sending password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Requces the quantity of a product when the customer makes a purchase
        public static bool ReduceProductQuantity(List<ProductPanel> lstProducts, List<int> lstQuantities)
        {
            List<int> lstNewQuantities = new List<int>();

            try
            {
                for (int intCurrentItem = 0; intCurrentItem < lstProducts.Count; intCurrentItem++)
                {
                    string strGetOldQuantity = $"SELECT UnitsInStock FROM dbo.Products WHERE ProductName = '{lstProducts[intCurrentItem].strProductName}'";
                    SqlCommand cmdGetOldQuantity = new SqlCommand(strGetOldQuantity, _cntDatabase);
                    int intOldQuantity = 0;
                    if (cmdGetOldQuantity.ExecuteScalar() == null)
                    {
                        MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        intOldQuantity = (int)cmdGetOldQuantity.ExecuteScalar();
                    }

                    lstNewQuantities.Add(intOldQuantity - lstQuantities[intCurrentItem]);

                    if (lstNewQuantities[intCurrentItem] < 0)
                    {
                        MessageBox.Show($"Not enough {lstProducts[intCurrentItem].strProductName} left in stock. Try reducing the quantity of your order", "Not Enough Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                for (int intCurrentQuantity = 0; intCurrentQuantity < lstNewQuantities.Count; intCurrentQuantity++)
                {
                    string strSetQuantity = $"UPDATE dbo.Products SET UnitsInStock = {lstNewQuantities[intCurrentQuantity]} WHERE ProductName = '{lstProducts[intCurrentQuantity].strProductName}'";
                    SqlCommand cmdSetQuantity = new SqlCommand(strSetQuantity, _cntDatabase);
                    cmdSetQuantity.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error purchasing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
