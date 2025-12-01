using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TRPO_pr13.Service;

namespace TRPO_pr13.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentFormPage.xaml
    /// </summary>
    public partial class UserFormPage : Page
    {
        public User _user { get; set; } = new();
        public UsersServise _service { get; set; } = new();

        bool isEdit = false;
        public UserFormPage(User? user = null)
        {
            InitializeComponent();
            if (user != null)
            {
                isEdit = true;
                _user = user;
            }

            if (_user.Profile == null)
                _user.Profile = new UserProfile();

            DataContext = _user;
        }

        void UpdateValidation()
        {
            login.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            name.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            password.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            email.GetBindingExpression(TextBox.TextProperty)?.UpdateSource(); 
            date.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
        }

        bool ValidateForm()
        {
            UpdateValidation();

            bool hasError = Validation.GetHasError(login) || Validation.GetHasError(name) || Validation.GetHasError(password) || Validation.GetHasError(email) || Validation.GetHasError(date);

            return !hasError;
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (isEdit)
                _service.Commit();
            else
                if (!ValidateForm())
                    return;
                else 
                    _service.Add(_user);

            NavigationService.GoBack();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
