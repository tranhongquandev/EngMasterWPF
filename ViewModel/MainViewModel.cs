using EngMasterWPF.DTOs;
using EngMasterWPF.Services;
using EngMasterWPF.Utilities;
using EngMasterWPF.ViewModel;
using EngMasterWPF.Views.CourseView;
using EngMasterWPF.Views.GradeView;
using EngMasterWPF.Views.HomeView;
using EngMasterWPF.Views.StudentView;
using EngMasterWPF.Views.TeacherView;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Controls;

namespace EngMasterWPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Property

        IServiceProvider _service = Installer.InstallServices.Instance.serviceProvider;

        private int? _userId = Installer.InstallServices.Instance.userId;

       

        private StaffDTO _userInfo = new StaffDTO
        {
            FullName = "Chế độ nhà phát triển",
            Email = "developer@gmail.com"
        };
         
        public StaffDTO UserInfo
        {
            get => _userInfo;
            set
            {
                _userInfo = value;
                OnPropertyChanged();
            }
        }





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

        private ViewModelBase _currentView ;
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
            CurrentView = _service.GetRequiredService<HomeViewModel>();

            ToggleSideBarCommand = new RelayCommand(_canExecute => true, _execute => IsExpand = !IsExpand);
            ToggleAvatarPopupConmmand = new RelayCommand(_canExecute => true, _execute => IsAvatarPopupOpen = !IsAvatarPopupOpen);

            NavigateHomeCommand = new RelayCommand(_canExecute => true, _execute => { CurrentView = _service.GetRequiredService<HomeViewModel>(); Breadcumb = "Tổng quan";  });
            NavigateStudentCommand = new RelayCommand(_canExecute => true, _execute => {CurrentView = _service.GetRequiredService<StudentViewModel>(); Breadcumb = "Học viên"; });
            NavigateTeacherCommand = new RelayCommand(_canExecute => true, _execute => {CurrentView = _service.GetRequiredService<TeacherViewModel>(); Breadcumb = "Giảng viên"; });
            NavigateCourseCommand = new RelayCommand(_canExecute => true, _execute => {CurrentView = _service.GetRequiredService<CourseViewModel>(); Breadcumb = "Khóa học"; });
            NavigateGradeCommand = new RelayCommand(_canExecute => true, _execute => {CurrentView = _service.GetRequiredService<GradeViewModel>(); Breadcumb = "Lớp học"; });
            NavigateStaffCommand = new RelayCommand(_canExecute => true, _execute => { CurrentView = _service.GetRequiredService<StaffViewModel>(); Breadcumb = "Người dùng";  });


            if (_userId != null)
            {
                Application.Current.Dispatcher.Invoke(async () =>
                {
                    var loadUserInfo = GetUserInfo(_userId);
                    await Task.WhenAll(loadUserInfo);
                });
            }


            //System.Windows.MessageBox.Show($"UserIdInLogin: {UserIdInLogin}");



            //NavigateToDetailCommand = new RelayCommand(_canExecute => true, _execute => { CurrentView = new AccountView(); Breadcumb = "Chi tiết"; IconBreadcumb = "Info24"; });
            SignOutCommand = new RelayCommand(_canExecute => true, async _execute => await SignOutCommandHandler());
        }


        #region Command

        public ICommand ToggleSideBarCommand { get; private set; }
        public ICommand ToggleAvatarPopupConmmand { get; private set; }

        public ICommand NavigateHomeCommand { get; private set; }
        public ICommand NavigateStudentCommand { get; private set; }
        public ICommand NavigateTeacherCommand { get; private set; }
        public ICommand NavigateCourseCommand { get; private set; }
        public ICommand NavigateGradeCommand { get; private set; }
        public ICommand NavigateToDetailCommand { get; private set; }
        public ICommand NavigateStaffCommand { get; private set; }

        public ICommand SignOutCommand { get; private set; }


        #endregion


        #region Command Execute Handler

        private async Task SignOutCommandHandler()
        {
            var _authService = _service.GetRequiredService<AuthService>();
            var _isLogout = await _authService.LogoutAsync();

            if(_isLogout)
            {
                MainWindowViewModel.Instance.CurrentView = _service.GetRequiredService<AuthViewModel>();

            }
            else
            {
                return;
            }

        }

        public async Task GetUserInfo(int? id)
        {
            var userService = _service.GetRequiredService<StaffService>();

            var user = await userService.GetById(id);

            if (user != null)
            {
                UserInfo = user;
            }

            else
            {
                return;
            }
        }
        #endregion
    }

}
