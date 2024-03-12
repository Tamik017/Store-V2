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
    public class ProductsVM : ObservableObject
    {
        private products productsModel = new products();
        public RelayCommand ProfileCommand { get; }
        public RelayCommand FilterCommand { get; }
        public RelayCommand AddCommand { get; }
        public RelayCommand ProfileAdminCommand { get; }
        public ProductsVM()
        {
            ProfileCommand = new RelayCommand(parameter => profile());
            FilterCommand = new RelayCommand(parameter => filter());
            AddCommand = new RelayCommand(parameter => add());
            ProfileAdminCommand = new RelayCommand(parameter => profileAdmin());
        }

        public void profile()
        {
            Profile profileWindow = new Profile();
            // Показываем новое окно
            profileWindow.Show();
            // Закрываем текущее окно
            //App.Current.MainWindow.Close();
        }

        public void profileAdmin()
        {
            ProfileAdmin profileAdminWindow = new ProfileAdmin();
            profileAdminWindow.Show();
        }

        public void add()
        {

        }

        public void filter()
        {

        }

        public string SearchText
        {
            get
            {
                return productsModel.Название;
            }
            set
            {
                productsModel.Название = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }
    }
}
