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
    public class StudentViewModel : ViewModelBase
    {
        #region Property


        private StudentDTO _currentStudent;
        public StudentDTO CurrentStudent
        {
            get { return _currentStudent; }
            set
            {
                _currentStudent = value;
                OnPropertyChanged(nameof(CurrentStudent));
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

        private string studentCode;
        public string StudentCode
        {
            get => studentCode;
            set
            {
                studentCode = value;
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

        private string _enrollmentDate;
        public string EnrollmentDate
        {
            get => _enrollmentDate;
            set
            {
                _enrollmentDate = value;
                OnPropertyChanged();
            }
        }

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<StudentDTO> _students;
        public ObservableCollection<StudentDTO> Students
        {
            get => _students;
            set
            {
                _students = value;
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

        private bool _isOpen;
        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                OnPropertyChanged();
            }
        }

        private bool _isUpdate;
        public bool IsUpdate
        {
            get => _isUpdate;
            set
            {
                _isUpdate = value;
                OnPropertyChanged();
            }
        }

        private bool _isOpenDeletePopup;
        public bool IsOpenDeletePopup
        {
            get => _isOpenDeletePopup;
            set
            {
                _isOpenDeletePopup = value;
                OnPropertyChanged();
            }
        }

        private bool _isOpenUpdateModal;
        public bool IsOpenUpdateModal
        {
            get => _isOpenUpdateModal;
            set
            {
                _isOpenUpdateModal = value;
                OnPropertyChanged();
            }
        }

        private bool _isSubmit;
        public bool IsSubmit
        {
            get => _isSubmit;
            set
            {
                _isSubmit = value;
                OnPropertyChanged();
            }
        }



        private readonly IServiceProvider _service;

        private readonly IMapper _mapper;

        private CancellationTokenSource _cancellationTokenSource;


        #endregion

        public StudentViewModel()
        {
            Page = 1;
            PageSize = 10;

            _service = Installer.InstallServices.Instance.serviceProvider;

            _mapper = _service.GetRequiredService<IMapper>();

            Application.Current.Dispatcher.Invoke(async () =>
            {

                var loadData = LoadData(null, Page, PageSize);
                var countItems = CountItems();

                await Task.WhenAll(loadData, countItems);

            });


            ToggleComboBoxFilterCommand = new RelayCommand(_canExecute => true, _execute => { IsComboBoxOpen = !IsComboBoxOpen; });
            ChangePageSizeCommand = new RelayCommand<ComboBoxItem>(_canExecute => true, async _execute => await ChangePageSizeCommandHandler(_execute!));

            FirstPageCommand = new RelayCommand(_canExecute => true, async _execute => { Page = 1; await LoadData(SearchText, Page, PageSize); });
            PrevPageCommand = new RelayCommand(_canExecute => true, async _execute => { if (Page > 1) Page--; await LoadData(SearchText, Page, PageSize); });
            NextPageCommand = new RelayCommand(_canExecute => true, async _execute => { if (Page < TotalPages) Page++; await LoadData(SearchText, Page, PageSize); });
            LastPageCommand = new RelayCommand(_canExecute => true, async _execute => { Page = TotalPages; await LoadData(SearchText, Page, PageSize); });
            OpenModalAddCommand = new RelayCommand(_canExecute => true, _execute => OpenDialogModal());

            CloseModalCommand = new RelayCommand(_canExecute => true, _execute => CloseModal());

            OpenModalUpdateCommand = new RelayCommand(_canExecute => true, _execute => OpenModalUpdate(CurrentStudent, Id));


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

            CloseModalUpdateCommand = new RelayCommand(_canExecute => true, _execute => CloseModalUpdate());

            CloseDeletePopupCommand = new RelayCommand(_canExecute => true, _execute => CloseDeleteDialog());

            SearchTextCommand = new RelayCommand<string>(_canExecute => true, async _execute => await SearchStudentCommandHandler(SearchText));

            UpdateStudentCommand = new RelayCommand(_canExecute => true, async _execute => await UpdateStudentAsyncMethod(CurrentStudent.Id));

            DeleteStudentCommand = new RelayCommand(
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

        #region Method Handler

        private async Task LoadData(string? name, int page, int pageSize)
        {
            IsLoading = true;

            try
            {
                StudentService studentService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<StudentService>();
                var studentInDb = await studentService.GetStudentByFilter(name, page, pageSize);

                if (!studentInDb.Any())
                {
                    IsLoading = false;
                    IsDataFound = true;
                    return;
                }

                Students = studentInDb;
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
            StudentService studentService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<StudentService>();
            TotalItems = await studentService.CountAll();
            TotalPages = (int)Math.Ceiling((double)TotalItems / PageSize);
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

        public ICommand CloseModalCommand { get; private set; }

        public ICommand CloseModalUpdateCommand { get; private set; }
        public ICommand OpenModalUpdateCommand { get; private set; }

        public ICommand OpenDeletePopupCommand { get; private set; }

        public ICommand CloseDeletePopupCommand { get; private set; }

        public ICommand UpdateStudentCommand { get; private set; }

        public ICommand DeleteStudentCommand { get; private set; }


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

        private string NormalizeDateOfBirth(string dateOfBirth)
        {
            if (DateTime.TryParse(dateOfBirth, out DateTime dob))
            {
                return dob.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            }

            return new DateTime(2000, 1, 1).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }

        private async Task UpdateStudentAsyncMethod(int studentId)
        {
            IsSubmit = true;
            var updateStudent = new UpdateStudentDTO
            {
                FullName = CurrentStudent.FullName ?? string.Empty,
                Gender = CurrentStudent.Gender ?? string.Empty,
                Email = CurrentStudent.Email ?? string.Empty,
                PhoneNumber = CurrentStudent.PhoneNumber ?? string.Empty,
                DateOfBirth = NormalizeDateOfBirth(CurrentStudent.DateOfBirth),
                StudentCode = CurrentStudent.StudentCode ?? string.Empty,
                Status = CurrentStudent.Status ?? string.Empty,
            };

            string jsonCourse = JsonConvert.SerializeObject(updateStudent);
            try
            {
                StudentService studentService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<StudentService>();
                var result = await studentService.UpdateStudentAsync(updateStudent, studentId);

                MessageBox.Show("Student updated successfully.");
                await LoadData(SearchText, Page, PageSize);
                IsSubmit = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something {jsonCourse} went wrong. Error: {ex.Message}\n{ex.StackTrace}");
                IsSubmit = false;
                return;
            }
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

        private void CloseModalUpdate()
        {
            IsOpenUpdateModal = false;
        }

        private void OpenModalUpdate(StudentDTO currentStudent, int id)
        {

            Id = id;
            CurrentStudent = currentStudent;
            IsOpenUpdateModal = true;
            //IsUpdate = true;
        }

        private void OpenDeletePopup()
        {
            IsOpenDeletePopup = true;
        }

        private void OpenDialogModal()
        {
            IsOpen = true;
            IsUpdate = false;
        }

        private async Task DeleteCourseAsyncTask(int studentId)
        {
            if (studentId <= 0)
            {
                MessageBox.Show($"Invalid course ID: {studentId}");
                return;
            }

            try
            {
                StudentService studentService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<StudentService>();
                bool isDeleted = await studentService.DeleteStudentAsync(studentId);
                if (isDeleted)
                {
                    MessageBox.Show("Student deleted successfully.");
                    await LoadData(SearchText, Page, PageSize);
                }
                else
                {
                    MessageBox.Show($"Failed to delete student with ID: {studentId}", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong. Error: {ex.Message}");
            }
        }
        private async Task SearchStudentCommandHandler(string name)
        {
            IsLoading = true;
            IsDataFound = false;

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            if (name.IsNullOrEmpty())
            {
                await LoadData(null, Page, PageSize);
                IsDataFound = false;
                return;
            }

            try
            {
                await Task.Delay(2000, token);

                StudentService studentService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<StudentService>();
                var studentInDb = await studentService.GetStudentByFilter(name, Page, PageSize);
                if (studentInDb.Any())
                {
                    Students = studentInDb;
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
