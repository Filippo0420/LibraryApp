using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DAO
{
    internal class DAO
    {
        public string connString { 
            get
            {
                return "Server=(localdb)\\MSSQLLocalDB;Integrated Security=True;Database=LibraryAppDatabase";
                //return "Server=localhost\\SQLEXPRESS2019;Integrated Security=True;Database=LibraryAppDatabase"
            }
        }
    }
}
