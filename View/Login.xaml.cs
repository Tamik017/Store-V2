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

namespace Store.View
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            //DataContext = new MainVM();
        }

        private void Loginbtn_Click(object sender, RoutedEventArgs e)
        {
            Products ProductWindow = new Products();
            ProductWindow.Show();
            this.Close();
        }

        private void Registrationbtn_Click(object sender, RoutedEventArgs e)
        {
            Registration RegistrationWindow = new Registration();
            RegistrationWindow.Show();
            this.Close();
        }
    }
}
