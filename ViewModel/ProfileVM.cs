using Microsoft.EntityFrameworkCore;
using Store.Model;
using Store.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Store.ViewModel
{
    public class ProfileVM : ObservableObject
    {
        public RelayCommand ProductCommand { get; }
        public RelayCommand LogoutCommand { get; }
        public RelayCommand StatisticCommand { get; }
        public RelayCommand ProductAdminCommand { get; }

        private int _currentEmployeeId;
        public ProfileVM()
        {
            ProductCommand = new RelayCommand(parameter => product());
            LogoutCommand = new RelayCommand(parameter => logout());
            StatisticCommand = new RelayCommand(parameter => statistic());
            ProductAdminCommand = new RelayCommand(parameter => productAdmin());

            using (var context = new ApplicationContext())
            {
                Current = Convert.ToString(context._orders.Count());

                var CurrentEmployeeId = 40;

                var employee = context.Set<Employees>().FirstOrDefault(e => e.Сотрудник_ID == CurrentEmployeeId);
                if (employee != null)
                {
                    var evaluation = context.Set<Rating>().FirstOrDefault(e => e.Оценка_ID == employee.Оценка_ID);
                    if (evaluation != null)
                    {
                        PVZ = evaluation.Адресс_Оценки;
                    }
                    else
                    {
                        MessageBox.Show("Не удалось найти оценку для сотрудника.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Не удалось найти сотрудника.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void product()
        {
            ProductsView productsWindow = new ProductsView();
            productsWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            productsWindow.Show();
            CloseCurrentWindow();
        }

        public void productAdmin()
        {
            ProductsAdmin productsAdminWindow = new ProductsAdmin();
            productsAdminWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            productsAdminWindow.Show();
            CloseCurrentWindow();
        }

        public void logout()
        {
            Login loginWindow = new Login();
            loginWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            loginWindow.Show();
            CloseCurrentWindow();
        }

        public void statistic()
        {
            Statistics statisticWindow = new Statistics();
            statisticWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            statisticWindow.Show();
            CloseCurrentWindow();
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

        private string _PVZ;
        public string PVZ
        {
            get => _PVZ;
            set
            {
                _PVZ = value;
                OnPropertyChanged(nameof(PVZ));
            }
        }

        private string _Current;
        public string Current
        {
            get => _Current;
            set
            {
                _Current = value;
                OnPropertyChanged(nameof(Current));
            }
        }
    }
}
