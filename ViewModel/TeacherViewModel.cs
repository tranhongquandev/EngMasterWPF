using AutoMapper;
using EngMasterWPF.DTOs;

using EngMasterWPF.Services;
using EngMasterWPF.Utilities;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EngMasterWPF.ViewModel
{
    public class TeacherViewModel : ViewModelBase
    {
        #region Property

        private TeacherDTO _currentTeacher;
        public TeacherDTO CurrentTeacher
        {
            get { return _currentTeacher; }
            set
            {
                _currentTeacher = value;
                OnPropertyChanged(nameof(CurrentTeacher));
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

        private ObservableCollection<TeacherDTO> _teachers;
        public ObservableCollection<TeacherDTO> Teachers
        {
            get => _teachers;
            set
            {
                _teachers = value;
                OnPropertyChanged();
            }
        }

        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                _imageUrl = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _gender;
        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        private string _dateOfBirth;
        public string DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }


        private string _teacherCode;
        public string TeacherCode
        {
            get => _teacherCode;
            set
            {
                _teacherCode = value;
                OnPropertyChanged();
            }
        }

        private string _hireDate;
        public string HireDate
        {
            get => _hireDate;
            set
            {
                _hireDate = value;
                OnPropertyChanged();
            }
        }

        private string _endDate;
        public string EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }

        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
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

        private readonly IServiceProvider _service;

        private readonly IMapper _mapper;

        private CancellationTokenSource _cancellationTokenSource;


        #endregion

        public TeacherViewModel()
        {
            Page = 1;
            PageSize = 10;

            _service = Installer.InstallServices.Instance.serviceProvider;

            _mapper = _service.GetRequiredService<IMapper>();

            Application.Current.Dispatcher.Invoke(async () =>
            {

                var loadData = LoadData(SearchText, Page, PageSize);
                var countItems = CountItems();

                await Task.WhenAll(loadData, countItems);

            });


            ToggleComboBoxFilterCommand = new RelayCommand(_canExecute => true, _execute => { IsComboBoxOpen = !IsComboBoxOpen; });
            ChangePageSizeCommand = new RelayCommand<ComboBoxItem>(_canExecute => true, async _execute => await ChangePageSizeCommandHandler(_execute!));

            FirstPageCommand = new RelayCommand(_canExecute => true, async _execute => { Page = 1; await LoadData(SearchText, Page, PageSize); });
            PrevPageCommand = new RelayCommand(_canExecute => true, async _execute => { if (Page > 1) Page--; await LoadData(SearchText, Page, PageSize); });
            NextPageCommand = new RelayCommand(_canExecute => true, async _execute => { if (Page < TotalPages) Page++; await LoadData(SearchText, Page, PageSize); });
            LastPageCommand = new RelayCommand(_canExecute => true, async _execute => { Page = TotalPages; await LoadData(SearchText, Page, PageSize); });

            SearchTextCommand = new RelayCommand<string>(_canExecute => true, async _execute => await SearchTeacherCommandHandler(SearchText));

            OpenModalAddCommand = new RelayCommand(_canExecute => true, _execute => OpenDialogModal());

            OpenModalUpdateCommand = new RelayCommand(_canExecute => true, _execute => OpenModalUpdate(CurrentTeacher));

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

            UpdateTeacherCommand = new RelayCommand(_canExecute => true, async _execute => await UpdateTeacherAsyncMethod(CurrentTeacher.Id));

            DeleteTeacherCommand = new RelayCommand(
                _canExecute => true,
                async param =>
                {
                    if (param is int id)
                    {
                        await DeleteTeacherAsync(id);
                        IsOpenDeletePopup = false;
                    }
                    else
                    {
                        MessageBox.Show("Invalid ID for teacher deletion.");
                    }
                }
            );
        }

        #region Method Handler

        private async Task LoadData(string? name,int page, int pageSize)
        {
            IsLoading = true;

            try
            {
                TeacherService teacherService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<TeacherService>();
                var teacherInDb = await teacherService.GetTeacherByFilter(name, page, pageSize);

                if (!teacherInDb.Any())
                {
                    IsLoading = false;
                    IsDataFound = true;
                    return;
                }

                Teachers = teacherInDb;
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

        private async Task CountItems()
        {
            TeacherService teacherService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<TeacherService>();
            TotalItems = await teacherService.CountAll();
            TotalPages = (int)Math.Ceiling((double)TotalItems / PageSize);
        }

        private async Task DeleteTeacherAsync(int courseId)
        {
            if (courseId <= 0)
            {
                MessageBox.Show($"Invalid course ID: {courseId}");
                return;
            }

            try
            {
                TeacherService teacherService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<TeacherService>();
                bool isDeleted = await teacherService.DeleteTeacherAsync(courseId);
                if (isDeleted)
                {
                    MessageBox.Show("Teacher deleted successfully.");
                    await LoadData(SearchText,Page, PageSize);
                }
                else
                {
                    MessageBox.Show($"Failed to delete teacher with ID: {courseId}", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong. Error: {ex.Message}");
            }
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

        private void OpenModalUpdate(TeacherDTO currentTeacher)
        {
            CurrentTeacher = currentTeacher;
            IsOpenUpdateModal = true;
            IsUpdate = true;
        }

        private void OpenDeletePopup()
        {
            IsOpenDeletePopup = true;
        }

        private string NormalizeDateOfBirth(DateTime dateOfBirth)
        {
            return dateOfBirth.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }

        private async Task UpdateTeacherAsyncMethod(int id)
        {
            IsSubmit = true;
            var updateTeacher = new UpdateTeacherDTO
            {
                FullName = CurrentTeacher.FullName ?? string.Empty,
                Gender = CurrentTeacher.Gender ?? string.Empty,
                Email = CurrentTeacher.Email ?? string.Empty,
                PhoneNumber = CurrentTeacher.PhoneNumber ?? string.Empty,
                DateOfBirth = NormalizeDateOfBirth(CurrentTeacher.DateOfBirth ?? new DateTime(2000, 1, 1)),
                HireDate = NormalizeDateOfBirth(CurrentTeacher.HireDate ?? new DateTime(2024, 1, 1)),
                EndDate = NormalizeDateOfBirth(CurrentTeacher.EndDate ?? new DateTime(2025, 1, 1)),
                IsActive = CurrentTeacher.IsActive,
                TeacherCode = CurrentTeacher.TeacherCode,
                Address = CurrentTeacher.Address
            };

            string jsonCourse = JsonConvert.SerializeObject(updateTeacher);
            try
            {

                TeacherService teacherService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<TeacherService>();
                var result = await teacherService.UpdateTeacherAsync(updateTeacher,id);

                MessageBox.Show("Teacher updated successfully.");
                await LoadData(SearchText, Page, PageSize);
                IsSubmit = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong. Error: {ex.Message}\n{ex.StackTrace}");
                IsSubmit = false;
                return;
            }
        }
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

        public ICommand DeleteTeacherCommand { get; private set; }

        public ICommand UpdateTeacherCommand { get; private set; }


        #endregion

        #region Command Handler

        private async Task ChangePageSizeCommandHandler(ComboBoxItem value)
        {

            if (value?.Content is string content && int.TryParse(content, out int newSize))
            {
                PageSize = newSize;
                TotalPages = (int)Math.Ceiling((double)TotalItems / PageSize);
                await LoadData(SearchText, Page, PageSize);
            }

        }

        private async Task SearchTeacherCommandHandler(string name)
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

                TeacherService teacherService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<TeacherService>();
                var teacherInDb = await teacherService.GetTeacherByFilter(name, Page, PageSize);
                if (teacherInDb.Any())
                {
                    Teachers = teacherInDb;
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

            #endregion


        }
    }
}
