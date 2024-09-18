using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EngMasterWPF.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace EngMasterWPF.ViewModel
{
    public class NavigationVM : BaseViewModel
    {
        private bool _isSideBarOpen = true;
        public bool IsSideBarOpen
        {
            get => _isSideBarOpen;
            set
            {
                _isSideBarOpen = value;
                OnPropertyChanged();
            }
        }
        private string _breadcumbTitle = string.Empty;
        public string BreadcumbTitle
        {
            get => _breadcumbTitle;
            set
            {
                _breadcumbTitle = value;
                OnPropertyChanged();
            }
        }

        private IServiceProvider _services { get; set; }


        public NavigationVM()
        {
            CurrentView = new HomeVM();
            HomeCommand = new RelayCommand(_canExecute => true, _execute => Home());
            StudentCommand = new RelayCommand(_canExecute => true, _execute => Student());
            TeacherCommand = new RelayCommand(_canExecute => true, _execute => Teacher());
            CourseCommand = new RelayCommand(_canExecute => true, _execute => Course());
            GradeCommand = new RelayCommand(_canExecute => true, _execute => Grade());
            NotifyCommand = new RelayCommand(_canExecute => true, _execute => Notification());
            ToggleSideBarCommand = new RelayCommand(_canExecute => true, _execute => ToggleSideBar());

             _services = Installer.InstallServices.Instance.serviceProvider;

        }
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

        public ICommand HomeCommand { get; set; }
        public ICommand StudentCommand { get; set; }
        public ICommand TeacherCommand { get; set; }
        public ICommand CourseCommand { get; set; }
        public ICommand GradeCommand { get; set; }
        public ICommand NotifyCommand { get; set; }
        public ICommand ToggleSideBarCommand { get; set; }

        private void Home()
        {
            CurrentView = _services.GetRequiredService<HomeVM>();
            BreadcumbTitle = string.Empty;
        }
        private void Student()
        {
            CurrentView = _services.GetRequiredService<StudentVM>();
            BreadcumbTitle = string.Empty;
            BreadcumbTitle = "Quản lý học viên";

        }
        private void Teacher()
        {
            CurrentView = _services.GetRequiredService<TeacherVM>();
            BreadcumbTitle = string.Empty;
            BreadcumbTitle = "Quản lý giảng viên";

        }
        private void Course()
        {
            CurrentView = _services.GetRequiredService<CourseVM>();
            BreadcumbTitle = string.Empty;
            BreadcumbTitle = "Quản lý khóa học";

        }
        private void Grade()
        {
            CurrentView = _services.GetRequiredService<GradeVM>();
            BreadcumbTitle = string.Empty;
            BreadcumbTitle = "Quản lý lớp";
        }
        private void Notification()
        {
            CurrentView = _services.GetRequiredService<NotificationVM>();
            BreadcumbTitle = string.Empty;
            BreadcumbTitle = "Quản lý thông báo";

        }
        private void ToggleSideBar()
        {
            IsSideBarOpen = !IsSideBarOpen;
        }
    }
}
