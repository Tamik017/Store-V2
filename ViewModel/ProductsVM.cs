using Microsoft.EntityFrameworkCore;
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
        private List<Categories> _categories;
        public RelayCommand ProfileCommand { get; }
        public RelayCommand FilterCommand { get; }
        public RelayCommand AddCommand { get; }
        public RelayCommand ProfileAdminCommand { get; }
        public RelayCommand UpdateCommand { get; }
        public RelayCommand ResetCommand { get; }

        public ProductsVM()
        {
            ProfileCommand = new RelayCommand(parameter => profile());
            FilterCommand = new RelayCommand(parameter => filter());
            AddCommand = new RelayCommand(parameter => add());
            ProfileAdminCommand = new RelayCommand(parameter => profileAdmin());
            UpdateCommand = new RelayCommand(parameter => update());
            ResetCommand = new RelayCommand(parameter => reset());

            ApplicationContext context = new ApplicationContext();
            AdminProductsList = context.GetProducts();
            _originalAdminProductsList = AdminProductsList.ToList();
            Categories = context.GetCategories();
        }

        public List<Categories> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        private Categories _selectedCategory;
        public Categories SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
                filter();
            }
        }

        private int _currentEmployeeId;
        public int CurrentEmployeeId
        {
            get { return _currentEmployeeId; }
            set { _currentEmployeeId = value; }
        }

        public void profile()
        {
            Profile profileWindow = new Profile();
            profileWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            profileWindow.Show();
            CloseCurrentWindow();
        }

        public void profileAdmin()
        {
            ProfileAdmin profileAdminWindow = new ProfileAdmin();
            profileAdminWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            profileAdminWindow.Show();
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

        private void add()
        {
            try
            {
                // Создаем новый экземпляр товара
                var newProduct = new Products();

                // Устанавливаем идентификатор существующего поставщика
                // Здесь предполагается, что у вас есть переменная, содержащая идентификатор выбранного поставщика
                // Например, SelectedSupplierId
                newProduct.Поставщик_ID = 1;
                newProduct.Категория_ID = 1;

                // Добавляем новый товар в базу данных
                using (var context = new ApplicationContext())
                {
                    // Добавляем новый товар в контекст данных
                    context.Set<Products>().Add(newProduct);

                    // Сохраняем изменения в базе данных
                    context.SaveChanges();

                    // Добавляем новый товар в список администраторских товаров
                    AdminProductsList.Add(newProduct);
                }
            }
            catch (DbUpdateException ex)
            {
                // Подробности об ошибке при сохранении изменений
                var innerException = ex.InnerException;
                if (innerException != null)
                {
                    MessageBox.Show($"Ошибка при сохранении изменений в базе данных: {innerException.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show($"Ошибка при сохранении изменений в базе данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении товара: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void update()
        {
            using (var context = new ApplicationContext())
            {
                try
                {
                    bool changesMade = false;

                    foreach (var product in AdminProductsList)
                    {
                        var existingProduct = context.Set<Products>().FirstOrDefault(p => p.Товар_ID == product.Товар_ID);
                        if (existingProduct != null)
                        {
                            if (existingProduct.Количество != product.Количество ||
                                existingProduct.Категория_ID != product.Категория_ID ||
                                existingProduct.Поставщик != product.Поставщик ||
                                existingProduct.Цена != product.Цена ||
                                existingProduct.Рейтинг != product.Рейтинг)
                            {
                                existingProduct.Количество = product.Количество;
                                existingProduct.Цена = product.Цена;
                                existingProduct.Рейтинг = product.Рейтинг;
                                existingProduct.Категория_ID = product.Категория_ID;
                                existingProduct.Категория = product.Категория;
                                existingProduct.Поставщик = product.Поставщик;

                                changesMade = true;
                            }
                        }
                        else
                        {
                            context.Set<Products>().Add(product);
                            changesMade = true;
                        }
                    }

                    var deletedProductIds = _originalAdminProductsList.Select(p => p.Товар_ID).Except(AdminProductsList.Select(p => p.Товар_ID)).ToList();
                    foreach (var deletedProductId in deletedProductIds)
                    {
                        var deletedProduct = context.Set<Products>().FirstOrDefault(p => p.Товар_ID == deletedProductId);
                        if (deletedProduct != null)
                        {
                            var orderItems = context.Set<OrderElements>().Where(item => item.Товар_ID == deletedProductId);
                            context.Set<OrderElements>().RemoveRange(orderItems);
                            context.Set<Products>().Remove(deletedProduct);

                            changesMade = true;
                        }
                    }

                    if (changesMade)
                    {
                        context.SaveChanges();
                        MessageBox.Show("Изменения успешно сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Нет изменений для сохранения.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении изменений в базе данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show($"Подробности: {ex.InnerException.Message}", "Подробности об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        public void filter()
        {
            if (SelectedCategory != null)
            {
                AdminProductsList = _originalAdminProductsList.Where(p => p.Категория.Категория_ID == SelectedCategory.Категория_ID).ToList();
            }
            else
            {
                AdminProductsList = _originalAdminProductsList.ToList();
            }
        }

        public void reset()
        {
            AdminProductsList = _originalAdminProductsList.ToList();
            SelectedCategory = null;
        }

        public void search()
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
                search();
            }
        }
    }
}
