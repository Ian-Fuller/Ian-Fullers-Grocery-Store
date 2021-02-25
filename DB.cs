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
        private const string CONN_STRING = @"Server = [SERVER]; Database = [DATABASE]; User Id = [USER ID]; Password = [PASSWORD]";
        private static SqlConnection _conn = new SqlConnection(CONN_STRING);

        //CLASS OBEJCTS
        //CLASS OBJECTS

        //Open/Close functions
        public static void OpenDatabase()
        {
            try
            {
                _conn.Open();
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
                _conn.Close();
                MessageBox.Show("Closed successfully.", "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection could not be closed.\n" + ex.Message, "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Query template
        public static void ProductsQuery(/*arguments*/)
        {
            string query = "";

            SqlCommand cmd = new SqlCommand(query, _conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {

            }
            catch (SqlException ex)
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
                    MessageBox.Show(errorMessages.ToString(), "Error Update Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message + "Error (PO7)", "Error Update Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Nonquery template
        public static void NonQuery(/*arguments*/)
        {
            string nonQuery = "";

            SqlCommand cmd = new SqlCommand(nonQuery, _conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {

            }
            catch (SqlException ex)
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
                    MessageBox.Show(errorMessages.ToString(), "[ERROR MESSAGE]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message + "Error (PO7)", "[ERROR MESSAGE]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
