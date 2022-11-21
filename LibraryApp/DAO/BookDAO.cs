﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryApp.DAO
{
    class BookDAO
    {
        public void connectToDatabase()
        {
            String str = "Server=(localdb)\\MSSQLLocalDB;Integrated Security=True;Database=LibraryAppDatabase";

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

        public List<Book> getAllBooks()
        {
            List<Book> books = new List<Book>();
            String str = "Server=(localdb)\\MSSQLLocalDB;Integrated Security=True;Database=LibraryAppDatabase";
            SqlConnection con = new SqlConnection(str);

            String query = "SELECT * FROM BookTable";

            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string sID = dbr["Id"].ToString();
                    string stitle = (string)dbr["Title"]; // name is string value
                    string sauthor = (string)dbr["Author"];
                    string sgenre = dbr["Genre"].ToString();
                    Book book = new Book()
                    {
                        Id = int.Parse(sID),
                        Title = stitle,
                        Author = sauthor,
                        Genre = sgenre
                    };
                    books.Add(book);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

            return books;
        }

        public List<Book> select(string column, string condition)
        {
            List<Book> books = new List<Book>();

            String str = "Server=localhost\\SQLEXPRESS2019;Integrated Security=True;Database=StudentsDatabase";

            SqlConnection con = new SqlConnection(str);

            String query = $"SELECT * FROM StudentsData WHERE {column} LIKE {condition}";

            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string sID = dbr["Id"].ToString();
                    string stitle = (string)dbr["Title"]; // name is string value
                    string sauthor = (string)dbr["Author"];
                    string sgenre = dbr["Genre"].ToString();
                    Book book = new Book()
                    {
                        Id = int.Parse(sID),
                        Title = stitle,
                        Author = sauthor,
                        Genre = sgenre
                    };
                    books.Add(book);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }


            return books;
        }
    }
}
