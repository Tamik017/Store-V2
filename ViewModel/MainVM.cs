using Store.Model;
using Store.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Store.ViewModel
{
    class MainVM : ObservableObject
    {
        //private string _PVZ;
        //public string PVZ
        //{
        //    get => _PVZ;
        //    set
        //    {
        //        _PVZ = value;
        //        OnPropertyChanged(nameof(PVZ));
        //    }
        //}

        //private string _Current;
        //public string Current
        //{
        //    get => _Current;
        //    set
        //    {
        //        _Current = value;
        //        OnPropertyChanged(nameof(Current));
        //    }
        //}

        public MainVM()
        {
            //PVZ = "№ 1, 6";
            //Current = "69";

            LogCommand = new RelayCommand(Log);
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
        //private void Giveaway(object obj) => CurrentView = new GiveawayVM();
        //private void Settings(object obj) => CurrentView = new SettingsVM();
        //private void Help(object obj) => CurrentView = new HelpVM();
    }
}