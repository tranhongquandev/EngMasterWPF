using EngMasterWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EngMasterWPF.ViewModel
{
    public class ControlBarVM : BaseViewModel
    {
        public ControlBarVM()
        {
            CloseCommand = new RelayCommand<UserControl>(_canExecute => true, _execute => { var window = GetWindowParent(_execute!) as Window; window!.Close(); });
            DragMoveCommand = new RelayCommand<UserControl>(_canExecute => true, _execute => { var window = GetWindowParent(_execute!) as Window; window!.DragMove(); });

            MinimizeWindowCommand = new RelayCommand<UserControl>(_canExecute => true, _execute => { var window = GetWindowParent(_execute!) as Window; window!.WindowState = WindowState.Minimized; });
            MaximizeWindowCommand = new RelayCommand<UserControl>(_canExecute => true, _execute => { var window = GetWindowParent(_execute!) as Window; window!.WindowState = window!.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized; });
        }

        public ICommand CloseCommand { get; private set; }
        public ICommand MinimizeWindowCommand { get; private set; }
        public ICommand MaximizeWindowCommand { get; private set; }
        public ICommand DragMoveCommand { get; private set; }


        FrameworkElement GetWindowParent(UserControl element)
        {
            FrameworkElement parent = element;
            while (parent.Parent != null)
            {
                parent = (FrameworkElement)parent.Parent ;
            }
            return parent;
        }
    }
}
