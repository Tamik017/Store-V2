using Store.Model;
using Store.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

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
            // Показываем новое окно
            loginWindow.Show();
            // Закрываем текущее окно
            App.Current.MainWindow.Close();
        }
    }
}
