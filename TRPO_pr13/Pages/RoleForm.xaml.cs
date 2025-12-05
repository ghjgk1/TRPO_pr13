using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TRPO_pr13.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoleForm.xaml
    /// </summary>
    public partial class RoleForm : Page
    {
        Role _role { get; set; } = new();
        RoleService _service { get; set; } = new();

        bool isEdit = false;

        public RoleForm(Role? role = null)
        {
            InitializeComponent();
            if (role != null)
            {
                _service.LoadRelation(role, "Users");
                _role = role;
                isEdit = true;
            }
            DataContext = _role;
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (isEdit)
                _service.Commit();
            else
                _service.Add(_role);

            NavigationService.GoBack();
        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
