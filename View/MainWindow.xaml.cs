<<<<<<< HEAD
﻿using Store.View;
using Store.ViewModel;
using System.Text;
=======
﻿using System.Text;
>>>>>>> 6db6e7f3ead8ff0dda23b1e2c59ebba2dab146d7
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
<<<<<<< HEAD
            //DataContext = new MainVM();
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            Login LoginWindow = new Login();
            LoginWindow.Show();
            this.Close();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Registration RegistrationWindow = new Registration();
            RegistrationWindow.Show();
            this.Close();
=======
>>>>>>> 6db6e7f3ead8ff0dda23b1e2c59ebba2dab146d7
        }
    }
}