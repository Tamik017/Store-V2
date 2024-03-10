using Store.ViewModel;
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
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Store.View
{
    /// <summary>
    /// Логика взаимодействия для ProfileAdmin.xaml
    /// </summary>
    public partial class ProfileAdmin : Window
    {
        public ProfileAdmin()
        {
            InitializeComponent();
            DataContext = new MainVM();
        }

        private void ProductBtn(object sender, RoutedEventArgs e)
        {
            ProductsAdmin ProductsAdminWindow = new ProductsAdmin();
            ProductsAdminWindow.Show();
            this.Close();
        }

        private void LogoutBtn(object sender, RoutedEventArgs e)
        {
            Login LoginWindow = new Login();
            LoginWindow.Show();
            this.Close();
        }

        private void StatisticsBtn(object sender, RoutedEventArgs e)
        {
            Statistics StatWindow = new Statistics();
            StatWindow.Show();
            this.Close();
        }

        private void ProfileSotrudnikBtn(object sender, RoutedEventArgs e)
        {
            Profile ProfileWindow = new Profile();
            ProfileWindow.Show();
            this.Close();
        }
    }
}
