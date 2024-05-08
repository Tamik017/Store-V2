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

        // Добавляем свойство для хранения идентификатора текущего сотрудника
        private int _currentEmployeeId;
        public int CurrentEmployeeId
        {
            get { return _currentEmployeeId; }
            set
            {
                _currentEmployeeId = value;
                OnPropertyChanged(nameof(CurrentEmployeeId));
            }
        }

        public RelayCommand LogCommand { get; }

        public LoginVM()
        {
            LogCommand = new RelayCommand(parameter => login());
        }

        public void login()
        {
            var employee = dbContext._employees.FirstOrDefault(e => e.Email == LoginText && e.PasswordUser == PasswordText);

            if (employee != null)
            {
                CurrentEmployeeId = employee.Сотрудник_ID;

                if (employee.Роль == "employee")
                {
                    ProductsView productsWindow = new ProductsView();
                    productsWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    productsWindow.Show();
                    CloseCurrentWindow();
                }
                else if (employee.Роль == "admin")
                {
                    ProductsAdmin productsAdminWindow = new ProductsAdmin();
                    productsAdminWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    productsAdminWindow.Show();
                    CloseCurrentWindow();
                }
            }
            else
            {
                MessageBox.Show("Ошибка в логине или пароле");
            }
        }

        private void CloseCurrentWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    break;
                }
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
