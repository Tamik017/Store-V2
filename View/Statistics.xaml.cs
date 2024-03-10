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
    /// Логика взаимодействия для Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        public Statistics()
        {
            InitializeComponent();
            //DataContext = new MainVM();
        }

        private void Profil(object sender, RoutedEventArgs e)
        {
            ProfileAdmin AAWindow = new ProfileAdmin();
            AAWindow.Show();
            this.Close();
        }

        private void Prosucts(object sender, RoutedEventArgs e)
        {
            ProductsAdmin ProductsAdminWindow = new ProductsAdmin();
            ProductsAdminWindow.Show();
            this.Close();
        }
    }
}
