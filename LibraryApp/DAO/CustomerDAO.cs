using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;

namespace LibraryApp.DAO
{
    class CustomerDAO : DAO
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

        public List<Customer> getAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            SqlConnection con = new SqlConnection(connString);

            String query = "SELECT * FROM CustomerTable";

            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string sID = dbr["Id"].ToString();
                    string sname = (string)dbr["Name"]; // name is string value
                    string ssurname = (string)dbr["Surname"];
                    string sphone = dbr["Phone"].ToString();
                    Customer customer = new Customer()
                    {
                        Id = int.Parse(sID),
                        Name = sname,
                        Surname = ssurname,
                        Phone = sphone
                    };
                    customers.Add(customer);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

            return customers;
        }

        public List<Customer> select(List<string> column, List<string> condition)
        {
            List<Customer> customers = new List<Customer>();

            SqlConnection con = new SqlConnection(connString);
            String query = $"SELECT * FROM CustomerTable ";
            if (column.Count != 0)
            {
                query += "WHERE ";
            }
            for (int i = 0; i < column.Count; i++)
            {
                query += $"{column[i]} LIKE '{condition[i]}' ";
                if (i < column.Count - 1)
                {
                    query += "AND ";
                }
            }

            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string sID = dbr["Id"].ToString();
                    string sname = (string)dbr["Name"]; // name is string value
                    string ssurname = (string)dbr["Surname"];
                    string sphone = dbr["Phone"].ToString();
                    Customer customer = new Customer()
                    {
                        Id = int.Parse(sID),
                        Name = sname,
                        Surname = ssurname,
                        Phone = sphone
                    };
                    customers.Add(customer);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }


            return customers;
        }
    }
}
