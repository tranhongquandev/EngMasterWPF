using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngMasterWPF.Utilities;

namespace EngMasterWPF.ViewModel
{
    public class NavigationVM : BaseViewModel
    {
        private object? _curentView;
        public object? CurrentView
        {
            get => _curentView;
            set
            {
                _curentView = value;
                OnPropertyChanged();
            }
        }
    }
}
