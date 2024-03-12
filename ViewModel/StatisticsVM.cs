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
    public class StatisticsVM : ObservableObject
    {
        public RelayCommand ProfileCommand { get; }
        public RelayCommand ProductCommand { get; }
        public StatisticsVM()
        {
            ProfileCommand = new RelayCommand(parameter => profile());
            ProductCommand = new RelayCommand(parameter => product());
        }

        public void profile()
        {
            ProfileAdmin profileAdminWindow = new ProfileAdmin();
            profileAdminWindow.Show();
        }

        public void product()
        {
            ProductsAdmin productsAdminWindow = new ProductsAdmin();
            productsAdminWindow.Show();
        }
    }
}
