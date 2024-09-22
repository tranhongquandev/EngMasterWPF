using EngMasterWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows;

namespace EngMasterWPF.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        

        #region Property

        //Singleton pattern
        private static MainWindowViewModel? _instance;
        public static MainWindowViewModel Instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainWindowViewModel();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }


        private ViewModelBase? _currentView = new AuthViewModel();
        //private ViewModelBase? _currentView = new MainViewModel();

        public ViewModelBase CurrentView
        {
            get { return _currentView!; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
                
            }
        }

        #endregion

        



    }
}
