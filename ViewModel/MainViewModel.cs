using EngMasterWPF.Utilities;
using EngMasterWPF.Views.CourseView;
using EngMasterWPF.Views.GradeView;
using EngMasterWPF.Views.HomeView;
using EngMasterWPF.Views.NotificationView;
using EngMasterWPF.Views.StudentView;
using EngMasterWPF.Views.TeacherView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf.Ui.Controls;

namespace EngMasterWPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Property
        private bool _isExpand = true;
        public bool IsExpand
        {
            get => _isExpand;
            set
            {
                _isExpand = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> _navigationItems = [];
        public ObservableCollection<object> NavigationItems
        {
            get => _navigationItems;
            set
            {
                _navigationItems = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<object> _navigationItemsSetting = [];
        public ObservableCollection<object> NavigationItemsSetting
        {
            get => _navigationItemsSetting;
            set
            {
                _navigationItemsSetting = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> BreadcrumbItems { get; set; }

        #endregion

        public MainViewModel()
        {

            ToggleSideBarCommand = new RelayCommand(_canExecute => true, _execute => IsExpand = !IsExpand);

            

            NavigationItems = new ObservableCollection<object>
            {
                new NavigationViewItem { Content = "Home", Icon = new SymbolIcon{ Symbol = SymbolRegular.Home24 }, TargetPageType = typeof(HomeView) },
                new NavigationViewItem { Content = "Student", Icon = new SymbolIcon{ Symbol = SymbolRegular.PeopleTeam24 }, TargetPageType = typeof(StudentView) },
                new NavigationViewItem { Content = "Teacher", Icon = new SymbolIcon{ Symbol = SymbolRegular.VideoBackgroundEffect24 }, TargetPageType = typeof(TeacherView) },
                new NavigationViewItem { Content = "Course", Icon = new SymbolIcon{ Symbol = SymbolRegular.TaskListSquareLtr24 }, TargetPageType = typeof(CourseView) },
                new NavigationViewItem { Content = "Grade", Icon = new SymbolIcon{ Symbol = SymbolRegular.Building24 }, TargetPageType = typeof(GradeView) },
                new NavigationViewItem { Content = "Notification", Icon = new SymbolIcon{ Symbol = SymbolRegular.AlertBadge24 }, TargetPageType = typeof(NotificationView) },
            };

            BreadcrumbItems = new ObservableCollection<string>
        {
            "Home",
            "Settings",
            "Account"
        };


        }


        #region Command

        public ICommand ToggleSideBarCommand { get; private set; }
        #endregion
    }

}
