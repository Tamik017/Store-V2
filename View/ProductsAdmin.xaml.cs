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
    /// Логика взаимодействия для ProductsAdmin.xaml
    /// </summary>
    public partial class ProductsAdmin : Window
    {
        public ProductsAdmin()
        {
            InitializeComponent();
        }

        private void ButtonProfile(object sender, RoutedEventArgs e)
        {
            ProfileAdmin ProfileAdminWindow = new ProfileAdmin();
            ProfileAdminWindow.Show();
            this.Close();
        }
    }
}
