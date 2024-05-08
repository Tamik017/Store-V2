using Store.Model;
using Store.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Store.ViewModel
{
    public class MainWindowVM : ObservableObject
    {
        public RelayCommand LogNavCommand { get; }
        public MainWindowVM()
        {
            LogNavCommand = new RelayCommand(parameter => loginNav());
        }

        public void loginNav()
        {
            Login loginWindow = new Login();
            loginWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            loginWindow.Show();
            App.Current.MainWindow.Close();
        }
    }
}
