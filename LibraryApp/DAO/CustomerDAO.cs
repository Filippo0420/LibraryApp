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
    class CustomerDAO
    {
        public void connectToDatabase()
        {
            String str = "Server=localhost\\SQLEXPRESS2019;Integrated Security=True;Database=LibraryAppDatabase";

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

        public List<Customer> getAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            String str = "Server=localhost\\SQLEXPRESS2019;Integrated Security=True;Database=LibraryAppDatabase";
            SqlConnection con = new SqlConnection(str);

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
    }
}
