using LibraryApp.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowCustomerDataBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerDAO customerDAO = new CustomerDAO();
            List<string> columns = new();
            List<string> conditions = new();
            if (NameSearch.Text != "")
            {
                columns.Add("Name");
                conditions.Add(NameSearch.Text);
            }
            if (SurnameSearch.Text != "")
            {
                columns.Add("Surname");
                conditions.Add(SurnameSearch.Text);
            }
            if (PhoneSearch.Text != "")
            {
                columns.Add("Phone");
                conditions.Add(PhoneSearch.Text);
            }
            ShowCustomerData.ItemsSource = customerDAO.select(columns, conditions);
        }

        private void ShowBookDataBtn_Click(object sender, RoutedEventArgs e)
        {
            BookDAO bookDAO = new BookDAO();
            List<string> columns = new();
            List<string> conditions = new();
            if (TitleSearch.Text != "")
            {
                columns.Add("Title");
                conditions.Add(TitleSearch.Text);
            }
            if (AuthorSearch.Text != "")
            {
                columns.Add("Author");
                conditions.Add(AuthorSearch.Text);
            }
            if (GenreSearch.Text != "")
            {
                columns.Add("Genre");
                conditions.Add(GenreSearch.Text);
            }
            ShowBookData.ItemsSource = bookDAO.select(columns, conditions);
        }

        private void CreateBookBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CreateCustomerBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
