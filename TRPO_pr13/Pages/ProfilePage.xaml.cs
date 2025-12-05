using Microsoft.Win32;

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

using TRPO_pr13.Service;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TRPO_pr13.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public User _user { get; set; } = new();
        public UsersServise _service { get; set; } = new();

        public ProfilePage(User user)
        {
            InitializeComponent();
            _user = user;
            DataContext = _user;
        }

        private void AvatarButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                _user.Profile.AvatarUrl = op.FileName;
            }
        }

        void UpdateValidation()
        {
            phone.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            birthday.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            bio.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
        }

        bool ValidateForm()
        {
            UpdateValidation();

            bool hasError = Validation.GetHasError(phone) || Validation.GetHasError(birthday) || Validation.GetHasError(bio);

            return !hasError;
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (!ValidateForm())
                return;
            else
                _service.Commit();
            NavigationService.GoBack();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
