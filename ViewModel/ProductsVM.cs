using Store.Model;
using Store.Model.DTO;
using Store.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Store.ViewModel
{
    public class ProductsVM : ObservableObject
    {
        private Products_Model products_Model = new Products_Model();
        private List<Model.Products> _originalAdminProductsList;
        public RelayCommand ProfileCommand { get; }
        public RelayCommand FilterCommand { get; }
        public RelayCommand AddCommand { get; }
        public RelayCommand ProfileAdminCommand { get; }
        public RelayCommand UpdateCommand { get; }

        public ProductsVM()
        {
            ProfileCommand = new RelayCommand(parameter => profile());
            FilterCommand = new RelayCommand(parameter => filter());
            AddCommand = new RelayCommand(parameter => add());
            ProfileAdminCommand = new RelayCommand(parameter => profileAdmin());
            UpdateCommand = new RelayCommand(parameter => update());

            ApplicationContext context = new ApplicationContext();
            AdminProductsList = context.GetProducts();
            _originalAdminProductsList = AdminProductsList.ToList();
        }

        public void profile()
        {
            Profile profileWindow = new Profile();
            profileWindow.Show();
        }

        public void profileAdmin()
        {
            ProfileAdmin profileAdminWindow = new ProfileAdmin();
            profileAdminWindow.Show();
        }

        public void update()
        {
            using (var context = new ApplicationContext())
            {
                foreach (var product in AdminProductsList)
                {
                    var existingProduct = context.Set<Products>().FirstOrDefault(p => p.Товар_ID == product.Товар_ID);
                    if (existingProduct != null)
                    {
                        if (existingProduct.Количество != product.Количество)
                        {
                            existingProduct.Количество = product.Количество;
                            MessageBox.Show($"Количество товаров успешно изменено для товара с ID {product.Товар_ID}.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении изменений в базе данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void add()
        {

        }

        public void filter()
        {
            using (var context = new ApplicationContext())
            {
                if (!string.IsNullOrEmpty(SearchText))
                {
                    AdminProductsList = _originalAdminProductsList.Where(p =>
                        p.Товар_ID.ToString().Contains(SearchText) ||
                        p.Поставщик.Название.Contains(SearchText) ||
                        p.Категория.Название.Contains(SearchText) ||
                        p.Цена.ToString().Contains(SearchText) ||
                        p.Рейтинг.ToString().Contains(SearchText) ||
                        p.Количество.ToString().Contains(SearchText)
                    ).ToList();
                }
                else
                {
                    AdminProductsList = _originalAdminProductsList.ToList();
                }
            }
        }

        public List<Model.Products> AdminProductsList
        {
            get
            {
                return products_Model.Products;
            }
            set
            {
                products_Model.Products = value;
                OnPropertyChanged(nameof(AdminProductsList));
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                filter();
            }
        }
    }
}
