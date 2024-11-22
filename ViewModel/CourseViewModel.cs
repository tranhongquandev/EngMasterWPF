using AutoMapper;
using EngMasterWPF.DTOs;
using EngMasterWPF.Services;
using EngMasterWPF.Utilities;
using EngMasterWPF.Views.CourseView;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

        public ICommand CloseModalCommand { get; private set; }


        #endregion

        public CourseViewModel()
        {

            Page = 1;
            PageSize = 10;

            _service = Installer.InstallServices.Instance.serviceProvider;

            _mapper = _service.GetRequiredService<IMapper>();

            Application.Current.Dispatcher.Invoke(async () =>
            {

                var loadData = LoadData(Page, PageSize);
                var countItems = CountItems();

                await Task.WhenAll(loadData, countItems);

            });


            ToggleComboBoxFilterCommand = new RelayCommand(_canExecute => true, _execute => { IsComboBoxOpen = !IsComboBoxOpen; });
            ChangePageSizeCommand = new RelayCommand<ComboBoxItem>(_canExecute => true, async _execute => await ChangePageSizeCommandHandler(_execute!));

            FirstPageCommand = new RelayCommand(_canExecute => true, async _execute => { Page = 1; await LoadData(Page, PageSize); });
            PrevPageCommand = new RelayCommand(_canExecute => true, async _execute => { if (Page > 1) Page--; await LoadData(Page, PageSize); });
            NextPageCommand = new RelayCommand(_canExecute => true, async _execute => { if (Page < TotalPages) Page++; await LoadData(Page, PageSize); });
            LastPageCommand = new RelayCommand(_canExecute => true, async _execute => { Page = TotalPages; await LoadData(Page, PageSize); });

            OpenModalAddCommand = new RelayCommand(_canExecute => true, _execute => OpenDialogModal());

            OpenModalUpdateCommand = new RelayCommand(_canExecute => true, _execute => OpenModalUpdate());

            CloseModalCommand = new RelayCommand(_canExecute => true, _execute => CloseModal());

            SearchTextCommand = new RelayCommand<string>(_canExecute => true, async _execute => await SearchCourseCommandHandler(SearchText));


        }



        #region Function
        private async Task LoadData(int page, int pageSize)
        {
            IsLoading = true;

            try
            {
                CourseService courseService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<CourseService>();
                var courseInitDb = await courseService.GetCoursesByPageAsync(page, pageSize);

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

        private void CloseModal()
        {
            IsOpen = false;
        }

        private void OpenModalUpdate()
        {
            IsOpen = true;
            IsUpdate = true;
        }

        private async Task ChangePageSizeCommandHandler(ComboBoxItem value)
        {

            if (value?.Content is string content && int.TryParse(content, out int newSize))
            {
                PageSize = newSize;
                TotalPages = (int)Math.Ceiling((double)TotalItems / PageSize);
                await LoadData(Page, PageSize);
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
                await LoadData(Page, PageSize);
                IsDataFound = false;
                return;
            }

            try
            {
                await Task.Delay(2000, token);

                CourseService courseService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<CourseService>();
                var courseInitDb = await courseService.GetByName(name);
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
