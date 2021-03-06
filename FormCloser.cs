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
    public class FormCloser
    {
        public static List<Form> lstOpenedForms = new List<Form>();

        public static void returnToMain()
        {
            for (int intForm = lstOpenedForms.Count - 1; intForm > 0; intForm--)
            {
                lstOpenedForms[intForm].Close();
                lstOpenedForms.RemoveAt(intForm);
            }
        }
    }
}
