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

        private ViewModelBase _currentView = new HomeViewModel();
        public ViewModelBase CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private string _breadcumb = "Tổng quan";
        public string Breadcumb
        {
            get => _breadcumb;
            set
            {
                _breadcumb = value;
                OnPropertyChanged();
            }
        }

        private string _iconBreadcumb = "Grid24";
        public string IconBreadcumb
        {
            get => _iconBreadcumb;
            set
            {
                _iconBreadcumb = value;
                OnPropertyChanged();
            }
        }

        private bool _isAvatarPopupOpen = false;
        public bool IsAvatarPopupOpen
        {
            get => _isAvatarPopupOpen;
            set
            {
                _isAvatarPopupOpen = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public MainViewModel()
        {

            ToggleSideBarCommand = new RelayCommand(_canExecute => true, _execute => IsExpand = !IsExpand);
            ToggleAvatarPopupConmmand = new RelayCommand(_canExecute => true, _execute => IsAvatarPopupOpen = !IsAvatarPopupOpen);

            NavigateHomeCommand = new RelayCommand(_canExecute => true, _execute => { CurrentView = new HomeViewModel(); Breadcumb = "Tổng quan"; IconBreadcumb = "Grid24"; });
            NavigateStudentCommand = new RelayCommand(_canExecute => true, _execute => {CurrentView = new StudentViewModel() ; Breadcumb = "Học viên"; IconBreadcumb = "PeopleTeam24"; });
            NavigateTeacherCommand = new RelayCommand(_canExecute => true, _execute => {CurrentView = new TeacherViewModel(); Breadcumb = "Giảng viên"; IconBreadcumb = "VideoBackgroundEffect24"; });
            NavigateCourseCommand = new RelayCommand(_canExecute => true, _execute => {CurrentView = new CourseViewModel(); Breadcumb = "Khóa học";IconBreadcumb = "TaskListSquareLtr24"; });
            NavigateGradeCommand = new RelayCommand(_canExecute => true, _execute => {CurrentView = new GradeViewModel(); Breadcumb = "Lớp học";IconBreadcumb = "Building24"; });
            NavigateNotificationCommand = new RelayCommand(_canExecute => true, _execute => { CurrentView = new NotificationViewModel(); Breadcumb = "Thông báo"; IconBreadcumb = "AlertBadge24"; });
        }


        #region Command

        public ICommand ToggleSideBarCommand { get; private set; }
        public ICommand ToggleAvatarPopupConmmand { get; private set; }

        public ICommand NavigateHomeCommand { get; private set; }
        public ICommand NavigateStudentCommand { get; private set; }
        public ICommand NavigateTeacherCommand { get; private set; }
        public ICommand NavigateCourseCommand { get; private set; }
        public ICommand NavigateGradeCommand { get; private set; }
        public ICommand NavigateNotificationCommand { get; private set; }

        #endregion
    }

}
