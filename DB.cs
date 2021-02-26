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

        public static void ShowSQLException(SqlException ex, string errorMessage)
        {
            StringBuilder errorMessages = new StringBuilder();
            if (ex is SqlException)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                MessageBox.Show(errorMessages.ToString(), errorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(ex.Message, errorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Query template
        public static void ProductsQuery(/*parameters*/)
        {
            string query = "";

            SqlCommand cmd = new SqlCommand(query, _cntDatabase);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {

            }
            catch (SqlException ex)
            {
                ShowSQLException(ex, "[ERROR MESSAGE]");
            }
        }

        //Nonquery template
        public static void NonQuery(/*parameters*/)
        {
            string nonQuery = "";

            SqlCommand cmd = new SqlCommand(nonQuery, _cntDatabase);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {

            }
            catch (SqlException ex)
            {
                ShowSQLException(ex, "[ERROR MESSAGE]");
            }
        }
    }
}
