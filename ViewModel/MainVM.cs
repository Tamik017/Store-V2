using Store.Model;
<<<<<<< HEAD
using Store.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
=======
using System;
using System.Collections.Generic;
>>>>>>> 6db6e7f3ead8ff0dda23b1e2c59ebba2dab146d7
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
<<<<<<< HEAD
using System.Windows.Input;
=======
>>>>>>> 6db6e7f3ead8ff0dda23b1e2c59ebba2dab146d7

namespace Store.ViewModel
{
    class MainVM : ObservableObject
    {
<<<<<<< HEAD
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainVM()
        {
            PVZ = "№ 1, 6";
            Current = "69";

            LogCommand = new RelayCommand(Log);
            RegCommand = new RelayCommand(Reg);
            //GiveawayCommand = new RelayCommand(Giveaway);
            //SettingsCommand = new RelayCommand(Settings);
            //HelpCommand = new RelayCommand(Help);

            CurrentView = new Login();
        }

        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            set { currentView = value; OnPropertyChanged(); }
        }

        public ICommand LogCommand { get; set; }
        public ICommand RegCommand { get; set; }
        public ICommand GiveawayCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand HelpCommand { get; set; }

        private void Log(object obj) => CurrentView = new Login();
        private void Reg(object obj) => CurrentView = new Registration();
        //private void Giveaway(object obj) => CurrentView = new GiveawayVM();
        //private void Settings(object obj) => CurrentView = new SettingsVM();
        //private void Help(object obj) => CurrentView = new HelpVM();
=======
        private bool _popupIsOpen; // Объявляем поле PopupIsOpen

        public MainVM()
        {
            _popupIsOpen = false; // Устанавливаем начальное значение
        }

        public bool PopupIsOpen
        {
            get { return _popupIsOpen; }
            set
            {
                _popupIsOpen = value;
                OnPropertyChanged(nameof(PopupIsOpen));
            }
        }

        private RelayCommand profileButtonCommand;

        public RelayCommand ProfileButtonCommand
        {
            get { return new RelayCommand(param => ExecuteProfileButtonClick()); }
        }

        private void ExecuteProfileButtonClick()
        {
            PopupIsOpen = !PopupIsOpen;
        }
>>>>>>> 6db6e7f3ead8ff0dda23b1e2c59ebba2dab146d7

    }
}