using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryApp.DAO
{
    class LoansDAO
    {
        void connectToDatabase()
        {
            String str = "Server=localhost\\SQLEXPRESS2019;Integrated Security=True;Database=StudentsDatabase";

            SqlConnection con = new SqlConnection(str);
            try
            {
                con.Open();
                MessageBox.Show("connected with sql server");
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
