using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TRPO_pr13.Service;

namespace TRPO_pr13.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public UsersServise service { get; set; } = new();
        public User? user { get; set; } = new();
        public MainPage()
        {
            InitializeComponent();
        }

        private void go_form(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserFormPage());
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удалить?",
            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                service.Remove(user);
            }

        }

        private void Edit(object sender, EventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Выберите элемент из списка!");
                return;
            }
            NavigationService.Navigate(new UserFormPage(user));
        }

        private void role(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RolePage());
        }
    }
}
