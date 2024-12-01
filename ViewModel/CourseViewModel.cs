using AutoMapper;
using EngMasterWPF.DTOs;
using EngMasterWPF.Services;
using EngMasterWPF.Utilities;
using EngMasterWPF.Views.CourseView;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EngMasterWPF.ViewModel
{
    public class CourseViewModel : ViewModelBase
    {

        #region Property

        private CourseDTO _currentCourse;
        public CourseDTO CurrentCourse
        {
            get { return _currentCourse; }
            set
            {
                _currentCourse = value;
                OnPropertyChanged(nameof(CurrentCourse));
            }
        }

        private string _searchText = "";
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
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

        private bool _isComboBoxOpen = false;
        public bool IsComboBoxOpen
        {
            get => _isComboBoxOpen;
            set
            {
                _isComboBoxOpen = value;
                OnPropertyChanged();
            }
        }


        private int _page;
        public int Page
        {
            get => _page;
            set
            {
                _page = value;
                OnPropertyChanged();
            }
        }

        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize = value;
                OnPropertyChanged();
            }
        }

        private int _totalPages;
        public int TotalPages
        {
            get => _totalPages;
            set
            {
                _totalPages = value;
                OnPropertyChanged();
            }
        }


        private int _totalItems;
        public int TotalItems
        {
            get => _totalItems;
            set
            {
                _totalItems = value;
                OnPropertyChanged();
            }
        }

        private bool _isUpdate = false;
        public bool IsUpdate
        {
            get => _isUpdate;
            set
            {
                _isUpdate = value;
                OnPropertyChanged();
            }
        }

        private bool _isOpen = false;
        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                OnPropertyChanged();
            }
        }


        private bool _isOpenDelete = false;
        public bool IsOpenDeletePopup
        {
            get => _isOpenDelete;
            set
            {
                _isOpenDelete = value;
                OnPropertyChanged();
            }
        }

        private bool _isOpenUpdate = false;
        public bool IsOpenUpdateModal
        {
            get => _isOpenUpdate;
            set
            {
                _isOpenUpdate = value;
                OnPropertyChanged();
            }
        }

        private bool _isSubmit = false;
        public bool IsSubmit
        {
            get => _isSubmit;
            set
            {
                _isSubmit = value;
                OnPropertyChanged();
            }
        }

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _courseName;
        public string CourseName
        {
            get => _courseName;
            set
            {
                _courseName = value;
                OnPropertyChanged();
            }
        }

        private string _courseCode;
        public string CourseCode
        {
            get => _courseCode;
            set
            {
                _courseCode = value;
                OnPropertyChanged();
            }
        }

        private string _levelName;
        public string LevelName
        {
            get => _levelName;
            set
            {
                _levelName = value;
                OnPropertyChanged();
            }

        }
        private string _duration;
        public string Duration
        {
            get => _duration;
            set
            {
                _duration = value;
                OnPropertyChanged();
            }
        }

        private int _fee;
        public int Fee
        {
            get => _fee;
            set
            {
                _fee = value;
                OnPropertyChanged();
            }
        }

        private int _levelId;
        public int LevelId
        {
            get => _levelId;
            set
            {
                _levelId = value;
                OnPropertyChanged();
            }
        }

        private double _discount;
        public double Discount
        {
            get => _discount;
            set
            {
                _discount = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private readonly IServiceProvider _service;

        private readonly IMapper _mapper;

        private CancellationTokenSource _cancellationTokenSource;

        #endregion

        #region Command

        public ICommand ToggleComboBoxFilterCommand { get; private set; }
        public ICommand ChangePageSizeCommand { get; private set; }
        public ICommand SearchTextCommand { get; private set; }


        public ICommand FirstPageCommand { get; private set; }
        public ICommand PrevPageCommand { get; private set; }
        public ICommand NextPageCommand { get; private set; }
        public ICommand LastPageCommand { get; private set; }
        public ICommand OpenModalAddCommand { get; private set; }

        public ICommand OpenModalUpdateCommand { get; private set; }

        public ICommand OpenDeletePopupCommand { get; private set; }

        public ICommand CloseModalCommand { get; private set; }

        public ICommand CloseDeletePopupCommand { get; private set; }

        public ICommand DeleteCourseCommand { get; private set; }

        public ICommand UpdateCourseCommand { get; private set; }

        #endregion

        public CourseViewModel()
        {

            Page = 1;
            PageSize = 10;

            _service = Installer.InstallServices.Instance.serviceProvider;

            _mapper = _service.GetRequiredService<IMapper>();

            Application.Current.Dispatcher.Invoke(async () =>
            {

                var loadData = LoadData(SearchText,Page, PageSize);
                var countItems = CountItems();

                await Task.WhenAll(loadData, countItems);

            });




            ToggleComboBoxFilterCommand = new RelayCommand(_canExecute => true, _execute => { IsComboBoxOpen = !IsComboBoxOpen; });
            ChangePageSizeCommand = new RelayCommand<ComboBoxItem>(_canExecute => true, async _execute => await ChangePageSizeCommandHandler(_execute!));

            FirstPageCommand = new RelayCommand(_canExecute => true, async _execute => { Page = 1; await LoadData(SearchText, Page, PageSize); });
            PrevPageCommand = new RelayCommand(_canExecute => true, async _execute => { if (Page > 1) Page--; await LoadData(SearchText, Page, PageSize); });
            NextPageCommand = new RelayCommand(_canExecute => true, async _execute => { if (Page < TotalPages) Page++; await LoadData(SearchText,Page, PageSize); });
            LastPageCommand = new RelayCommand(_canExecute => true, async _execute => { Page = TotalPages; await LoadData(SearchText, Page, PageSize); });

            OpenModalAddCommand = new RelayCommand(_canExecute => true, _execute => OpenDialogModal());

            OpenModalUpdateCommand = new RelayCommand(_canExecute => true, _execute => OpenModalUpdate(CurrentCourse));

            OpenDeletePopupCommand = new RelayCommand(
            _canExecute => true,
            (param) =>
            {
            if (param is int id)
            {
                Id = id;
                IsOpenDeletePopup = true;
            }
            }
            );

            CloseModalCommand = new RelayCommand(_canExecute => true, _execute => CloseModal());

            CloseDeletePopupCommand = new RelayCommand(_canExecute => true, _execute => CloseDeleteDialog());

            SearchTextCommand = new RelayCommand<string>(_canExecute => true, async _execute => await SearchCourseCommandHandler(SearchText));

            UpdateCourseCommand = new RelayCommand(_canExecute => true, async _execute => await UpdateCourseAsyncMethod(CurrentCourse.Id));

            DeleteCourseCommand = new RelayCommand(
                _canExecute => true,
                async param =>
                {
                    if (param is int id)
                    {
                        await DeleteCourseAsyncTask(id);
                        IsOpenDeletePopup = false;
                    }
                    else
                    {
                        MessageBox.Show("Invalid ID for course deletion.");
                    }
                }
            );
        }



        #region Function
        private async Task LoadData(string? name,int page, int pageSize)
        {
            IsLoading = true;

            try
            {
                CourseService courseService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<CourseService>();
                var courseInitDb = await courseService.GetCourseByFilter(name, page, pageSize);

                if (!courseInitDb.Any())
                {
                    IsLoading = false;
                    IsDataFound = true;
                    return;
                }

                Courses = courseInitDb;
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
        #endregion

        private async Task DeleteCourseAsyncTask(int courseId)
        {
            if (courseId <= 0)
            {
                MessageBox.Show($"Invalid course ID: {courseId}");
                return;
            }

            try
            {
                CourseService courseService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<CourseService>();
                bool isDeleted = await courseService.DeleteCourseAsync(courseId);
                if (isDeleted)
                {
                    MessageBox.Show("Course deleted successfully.");
                    await LoadData(SearchText,Page, PageSize);
                }
                else
                {
                    MessageBox.Show($"Failed to delete course with ID: {courseId}", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong. Error: {ex.Message}");
            }
        }


        private async Task CountItems()
        {
            CourseService courseService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<CourseService>();
            TotalItems = await courseService.CountAll();
            TotalPages = (int)Math.Ceiling((double)TotalItems / PageSize);
        }

        private void OpenDialogModal()
        {
            IsOpen = true;
            IsUpdate = false;
        }


        private void CloseDeleteDialog()
        {
            IsOpenDeletePopup = false;
        }

        private void CloseModal()
        {
            IsOpen = false;
            IsOpenUpdateModal = false;
        }

        private void OpenModalUpdate(CourseDTO currentCourse)
        {
            CurrentCourse = currentCourse;
            IsOpenUpdateModal = true;
            IsUpdate = true;
        }

        private void OpenDeletePopup()
        {
            IsOpenDeletePopup = true;
        }

        private async Task UpdateCourseAsyncMethod(int id)
        {
            IsSubmit = true;
            var updateCourse = new UpdateCourseDTO
            {
                CourseName = CurrentCourse.CourseName ?? string.Empty,
                Duration = CurrentCourse.Duration ?? string.Empty,
                Fee = CurrentCourse.Fee ?? 0,
                Discount = CurrentCourse.Discount ?? 0,
                Description = CurrentCourse.Description ?? string.Empty,
                IsActive = CurrentCourse.IsActive ?? true,
                LevelId = CurrentCourse.LevelId ?? 0,
                CourseCode = CurrentCourse.CourseCode ?? string.Empty,
            };

            string jsonCourse = JsonConvert.SerializeObject(updateCourse);
            try
            {

                CourseService courseService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<CourseService>();
                var result = await courseService.UpdateCourseAsync(updateCourse,id);

                MessageBox.Show("Course updated successfully.");
                IsSubmit = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong. Error: {ex.Message}\n{ex.StackTrace}");
                IsSubmit = false;
                return;
            }
        }

        private async Task ChangePageSizeCommandHandler(ComboBoxItem value)
        {

            if (value?.Content is string content && int.TryParse(content, out int newSize))
            {
                PageSize = newSize;
                TotalPages = (int)Math.Ceiling((double)TotalItems / PageSize);
                await LoadData(SearchText, Page, PageSize);
            }

        }

        private async Task SearchCourseCommandHandler(string name)
        {
            IsLoading = true;
            IsDataFound = false;

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            if (name.IsNullOrEmpty())
            {
                await LoadData(SearchText, Page, PageSize);
                IsDataFound = false;
                return;
            }

            try
            {
                await Task.Delay(2000, token);

                CourseService courseService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<CourseService>();
                var courseInitDb = await courseService.GetCourseByFilter(name, Page,PageSize);
                if (courseInitDb.Any())
                {
                    Courses = courseInitDb;
                    IsLoading = false;
                }
                else
                {
                    IsLoading = false;

                    IsDataFound = true;
                }
            }
            catch (TaskCanceledException)
            {
                return;
            }


        }
    }
}
