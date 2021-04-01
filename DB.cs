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
        public static void FillPanel(int intCurrentRow, List<ProductPanel> lstPanels, int intLeft, int intTop)
        {
            string strProductName;
            double dblPrice;
            string strSize;
            int intUnitsInStock;
            byte[] arrImageBytes;

            try
            {
                string strNameQuery = "SELECT ProductName FROM FullerIsp212332.Products WHERE ProductID = " + intCurrentRow;
                SqlCommand nameCommand = new SqlCommand(strNameQuery, _cntDatabase);
                strProductName = (string)nameCommand.ExecuteScalar();

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
        }

        public static void FillSpecialPanel(int intCurrentRow, List<SpecialPanel> lstPanels, int intLeft, int intTop)
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
                intID = (int)IDCommand.ExecuteScalar();

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
        }

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
                    DateTime thirtyDaysFromNow = DateTime.Now.AddDays(30);
                    string strDueDate = "'" + thirtyDaysFromNow.Year.ToString() + "-" + FormatDayOrMonth(thirtyDaysFromNow.Month.ToString()) + "-" + FormatDayOrMonth(thirtyDaysFromNow.Day.ToString()) + "'";
                    string strNewInvoice = "INSERT INTO FullerIsp212332.Invoices(CustomerID, ProductID, Discount, Quantity, TotalPrice, OrderDate, DueDate, Paid) VALUES(" + intNewID + ", " + lstProducts[intCurrentProduct].intProductID + ", " + lstProducts[intCurrentProduct].GetDiscount() + ", " + lstQuantities[intCurrentProduct] + ", " + (Math.Round(lstProducts[intCurrentProduct].dblPrice * (1f - (double)lstProducts[intCurrentProduct].GetDiscount() / 100f), 2)) * lstQuantities[intCurrentProduct] + ", " + strOrderDate + ", " + strDueDate + ", 'No')";
                    SqlCommand invoiceCommand = new SqlCommand(strNewInvoice, _cntDatabase);
                    invoiceCommand.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Making Purchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string FormatDayOrMonth(string strDayMonth)
        {
            if(strDayMonth.Length == 1)
            {
                strDayMonth = "0" + strDayMonth;
            }

            return strDayMonth;
        }
    }
}
