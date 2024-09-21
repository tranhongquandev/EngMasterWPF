using EngMasterWPF.Utilities;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EngMasterWPF.ViewModel
{
    public class ControlBarViewModel : ViewModelBase
    {
        public ControlBarViewModel()
        {
            MinimizeCommand = new RelayCommand<UserControl>(_canExecute => true, _execute => { var window = GetParentWindow(_execute!) as Window; window!.WindowState = WindowState.Minimized; });
            MaximizeCommand = new RelayCommand<UserControl>(_canExecute => true, _execute => { var window = GetParentWindow(_execute!) as Window; window!.WindowState = window!.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized; });
            CloseCommand = new RelayCommand<UserControl>(_canExecute => true, _execute => { var window = GetParentWindow(_execute!) as Window; window!.Close(); });
            DragMoveCommand = new RelayCommand<UserControl>(_canExecute => true, _execute => { var window = GetParentWindow(_execute!) as Window; window!.DragMove(); });

        }

        #region Command

        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand DragMoveCommand { get; set; }

        #endregion

        static Window GetParentWindow(DependencyObject child)
        {

            DependencyObject parent = VisualTreeHelper.GetParent(child);
            while (parent != null)
            {
                if (parent is Window window)
                {
                    return window;
                }
                parent = VisualTreeHelper.GetParent(parent);
            }
            return null!;
        }
    }

}
