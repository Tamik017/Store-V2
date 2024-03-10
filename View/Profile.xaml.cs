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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            DataContext = new MainVM();
        }

        private void ProductBtn(object sender, RoutedEventArgs e)
        {
            Products ProductWindow = new Products();
            ProductWindow.Show();
            this.Close();
        }

        private void LogoutBtn(object sender, RoutedEventArgs e)
        {
            Login LoginWindow = new Login();
            LoginWindow.Show();
            this.Close();
        }

        private void ProductAdminBtn(object sender, RoutedEventArgs e)
        {
            ProfileAdmin AdmWindow = new ProfileAdmin();
            AdmWindow.Show();
            this.Close();
        }
    }
}
