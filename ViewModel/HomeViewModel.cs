﻿using AutoMapper;
using EngMasterWPF.DTOs;
using EngMasterWPF.Services;
using EngMasterWPF.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Windows;
using System.Windows.Input;

namespace EngMasterWPF.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        #region Property
        private int _totalTeachers;
        public int TotalTeachers
        {
            get => _totalTeachers;
            set
            {
                _totalTeachers = value;
                OnPropertyChanged();
            }
        }

        private int _totalStudents;
        public int TotalStudents
        {
            get => _totalStudents;
            set
            {
                _totalStudents = value;
                OnPropertyChanged();
            }
        }

        private int _totalCourses;
        public int TotalCourses
        {
            get => _totalCourses;
            set
            {
                _totalCourses = value;
                OnPropertyChanged();
            }
        }

        private int _totalClasses;
        public int TotalClasses
        {
            get => _totalClasses;
            set
            {
                _totalClasses = value;
                OnPropertyChanged();
            }
        }

        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private string _breadcumb = "Course";
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

        private bool _isLoading = false;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        private bool _isDataFound = false;
        public bool IsDataFound
        {
            get => _isDataFound;
            set
            {
                _isDataFound = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<CourseDTO> _courses;
        public ObservableCollection<CourseDTO> Courses
        {
            get => _courses;
            set
            {
                _courses = value;
                OnPropertyChanged();
            }
        }



        private readonly IServiceProvider _service;

        private readonly IMapper _mapper;
        #endregion


        #region Command
        public ICommand NavigateCourseCommand { get; private set; }
        #endregion
        public HomeViewModel()
        {


            _service = Installer.InstallServices.Instance.serviceProvider;

            _mapper = _service.GetRequiredService<IMapper>();

            Application.Current.Dispatcher.Invoke(async () =>
            {

                var loadData = LoadData(1,4);
                var countCourses = CountCourses();
                var countStudents = CountStudents();
                var countTeachers = CountTeachers();
                var countClasses = CountClasses();

                await Task.WhenAll(countCourses, countStudents,countTeachers, countClasses, loadData);

            });

            NavigateCourseCommand = new RelayCommand(_canExecute => true, _execute => { CurrentView = _service.GetRequiredService<CourseViewModel>(); Breadcumb = "Khóa học"; IconBreadcumb = "TaskListSquareLtr24"; });


            
        }

        #region Command

        #endregion

        private async Task LoadData( int page, int pageSize)
        {
            IsLoading = true;

            try
            {
                CourseService homeService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<CourseService>();
                var homeInitDb = await homeService.GetCourseByFilter(null, page, pageSize);

                if (homeInitDb == null || !homeInitDb.Any())
                {
                    IsLoading = false;
                    IsDataFound = true;
                    return;
                }

                Courses = homeInitDb;
                await Task.Delay(500);
                IsLoading = false;
                IsDataFound = false;
            }
            catch
            {
                IsLoading = false;
                IsDataFound = true;
                return;
            }


        }

        private async Task CountTeachers()
        {
            TeacherService teacherService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<TeacherService>();
            TotalTeachers = await teacherService.CountAll();
        }

        private async Task CountStudents()
        {
            StudentService studentService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<StudentService>();
            TotalStudents = await studentService.CountAll();
        }

        private async Task CountClasses()
        {
            GradeService gradeService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<GradeService>();
            TotalClasses = await gradeService.CountAll();
        }

        private async Task CountCourses()
        {
            CourseService courseService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<CourseService>();
            TotalCourses = await courseService.CountAll();
        }
    }
}
