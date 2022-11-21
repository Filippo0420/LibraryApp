using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryApp.DAO
{
    class LoansDAO : DAO
    {
        public void connectToDatabase()
        {
            SqlConnection con = new SqlConnection(connString);
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
