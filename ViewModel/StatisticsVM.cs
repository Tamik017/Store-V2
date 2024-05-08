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
    public class StatisticsVM : ObservableObject
    {
        public RelayCommand ProfileCommand { get; }
        public RelayCommand ProductCommand { get; }
        public StatisticsVM()
        {
            ProfileCommand = new RelayCommand(parameter => profile());
            ProductCommand = new RelayCommand(parameter => product());

            Calculate();
        }

        private void Calculate()
        {
            using (var context = new ApplicationContext())
            {
                try
                {
                    var allProducts = context.Set<Products>().ToList();
                    var allZP = context.Set<Employees>().ToList();

                    decimal totalSum = allProducts.Sum(p => p.Цена);
                    decimal totalZP = allZP.Sum(p => p.Зарплата);

                    sumProduct = totalSum.ToString();
                    sumZP = totalZP.ToString();
                }
                catch (Exception ex)
                {
                    sumProduct = "Ошибка при подсчете суммы";
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
        }

        public void profile()
        {
            ProfileAdmin profileAdminWindow = new ProfileAdmin();
            profileAdminWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            profileAdminWindow.Show();
            CloseCurrentWindow();
        }

        public void product()
        {
            ProductsAdmin productsAdminWindow = new ProductsAdmin();
            productsAdminWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            productsAdminWindow.Show();
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

        private string _sumProducts;
        public string sumProduct
        {
            get => _sumProducts;
            set
            {
                _sumProducts = value;
                OnPropertyChanged(nameof(sumProduct));
            }
        }

        private string _sumZP;
        public string sumZP
        {
            get => _sumZP;
            set
            {
                _sumZP = value;
                OnPropertyChanged(nameof(sumZP));
            }
        }
    }
}
