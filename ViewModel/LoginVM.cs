using Microsoft.EntityFrameworkCore;
using Store.Model;
using Store.Model.DTO;
using Store.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Store.ViewModel
{
    public class LoginVM : ObservableObject
    {
        private ApplicationContext dbContext = new ApplicationContext();
        private LoginModel loginModel = new LoginModel();
        public RelayCommand LogCommand { get; }
        public LoginVM()
        {
            LogCommand = new RelayCommand(parameter => login());
        }

        public void login()
        {
            // Получаем из базы данных сотрудника с указанным email и паролем
            var employee = dbContext._employees.FirstOrDefault(e => e.Email == LoginText && e.PasswordUser == PasswordText);

            if (employee != null)
            {
                // Если сотрудник найден, открываем окно с продуктами и закрываем текущее окно
                ProductsView productsWindow = new ProductsView();
                productsWindow.Show();
                //loginWindow.Close();
            }
            else
            {
                // Если сотрудник не найден, выводим сообщение об ошибке
                MessageBox.Show("Ошибка в логине или пароле");
            }
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
