using Store.Model;
using Store.Model.DTO;
using Store.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModel
{
    public class LoginVM : ObservableObject
    {
        private LoginModel loginModel = new LoginModel();
        public RelayCommand LogCommand { get; }
        public LoginVM()
        {
            LogCommand = new RelayCommand(parameter => login());
        }

        public void login()
        {
            Products productsWindow = new Products();
            // Показываем новое окно
            productsWindow.Show();
            // Закрываем текущее окно
            //App.Current.MainWindow.Close();
        }

        public string LoginText
        {
            get
            {
                return loginModel.Login;
            }
            set 
            { 
                loginModel.Login = value; 
                OnPropertyChanged(nameof(LoginText));
            }
        }

        public string PasswordText
        {
            get
            {
                return loginModel.Password;
            }
            set
            {
                loginModel.Password = value;
                OnPropertyChanged(nameof(PasswordText));
            }
        }
    }
}
