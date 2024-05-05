using Store.Model;
using Store.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModel
{
    public class ProfileVM : ObservableObject
    {
        //private PVZ pvzModel = new PVZ();
        public RelayCommand ProductCommand { get; }
        public RelayCommand LogoutCommand { get; }
        public RelayCommand StatisticCommand { get; }
        public RelayCommand SotrudnikProfile {  get; }
        public RelayCommand AdminProfile { get; }
        public RelayCommand ProductAdminCommand { get; }
        public ProfileVM()
        {
            ProductCommand = new RelayCommand(parameter => product());
            LogoutCommand = new RelayCommand(parameter => logout());
            StatisticCommand = new RelayCommand(parameter => statistic());
            SotrudnikProfile = new RelayCommand(parameter => profileSotrudnik());
            AdminProfile = new RelayCommand(parameter => profileAdmin());
            ProductAdminCommand = new RelayCommand(parameter => productAdmin());

            //PVZ = "№ 1, 6";
            Current = "69";
        }

        public void product()
        {
            ProductsView productsWindow = new ProductsView();
            productsWindow.Show();
        }

        public void productAdmin()
        {
            ProductsAdmin productsAdminWindow = new ProductsAdmin();
            productsAdminWindow.Show();
        }

        public void logout()
        {
            Login loginWindow = new Login();
            loginWindow.Show();
        }

        public void statistic()
        {
            Statistics statisticWindow = new Statistics();
            statisticWindow.Show();
        }

        public void profileAdmin()
        {
            ProfileAdmin profileAdminWindow = new ProfileAdmin();
            profileAdminWindow.Show();
        }
        public void profileSotrudnik()
        {
            Profile profileWindow = new Profile();
            profileWindow.Show();
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
