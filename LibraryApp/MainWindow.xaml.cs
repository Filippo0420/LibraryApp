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

        private void ShowDataBtn_Click(object sender, RoutedEventArgs e)
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
    }
}
