﻿using Store.View;
using Store.ViewModel;
using System.Text;
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
            //DataContext = new MainVM();
            DataContext = new MainWindowVM();
        }

        //private void Log_Click(object sender, RoutedEventArgs e)
        //{
        //    Login LoginWindow = new Login();
        //    LoginWindow.Show();
        //    this.Close();
        //}

    }
}