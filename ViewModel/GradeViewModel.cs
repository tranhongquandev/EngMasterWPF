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
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EngMasterWPF.ViewModel
{
    public class GradeViewModel : ViewModelBase
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

        private ObservableCollection<ClassDTO> _grades;
        public ObservableCollection<ClassDTO> Grades
        {
            get => _grades;
            set
            {
                _grades = value;
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

        private bool _isDelete = false;
        public bool IsDelete
        {
            get => _isDelete;
            set
            {
                _isDelete = value;
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

        private bool _isOpenCreateModal = false;
        public bool IsOpenCreateModal
        {
            get => _isOpenCreateModal;
            set
            {
                if (_isOpenCreateModal != value)
                {
                    _isOpenCreateModal = value;
                    OnPropertyChanged();
                }
            }
        }


        private readonly IServiceProvider _service;

        private readonly IMapper _mapper;

        private CancellationTokenSource _cancellationTokenSource;


        #endregion

        #region Property AddModalClass

        private string _classCode;
        public string ClassCode
        {
            get => _classCode;
            set
            {
                _classCode = value;
                OnPropertyChanged();
            }
        }

        private string _className;
        public string ClassName
        {
            get => _className;
            set
            {
                _className = value;
                OnPropertyChanged();
            }
        }

        private DateTime _startDate = DateTime.UtcNow;
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime _endDate = DateTime.UtcNow.AddMonths(2);
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }

        private string _courseId;
        public string CourseId
        {
            get => _courseId;
            set
            {
                _courseId = value;
                OnPropertyChanged();
            }
        }

        private string _teacherId;
        public string TeacherId
        {
            get => _teacherId;
            set
            {
                _teacherId = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<TeacherDTO> _teacherList;
        public ObservableCollection<TeacherDTO> TeacherList
        {
            get => _teacherList;
            set
            {
                _teacherList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<CourseDTO> _courseList;
        public ObservableCollection<CourseDTO> CourseList
        {
            get => _courseList;
            set
            {
                _courseList = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Modals
        private bool _isOpenClassDetail = false;
        public bool IsOpenClassDetail
        {
            get => _isOpenClassDetail;
            set
            {
                _isOpenClassDetail = value;
                OnPropertyChanged();
            }
        }

        private string? setClassNameForDetail;
        public string? SetClassNameForDetail
        {
            get => setClassNameForDetail;
            set
            {
                setClassNameForDetail = value;
                OnPropertyChanged();
            }
        }



        #endregion

        #region ClassDetail

        private ObservableCollection<StudentDTO> _studentInClass;
        public ObservableCollection<StudentDTO> StudentInClass
        {
            get => _studentInClass;
            set
            {
                _studentInClass = value;
                OnPropertyChanged();
            }
        }

        #endregion
        public GradeViewModel()
        {
            Page = 1;
            PageSize = 9;

            _service = Installer.InstallServices.Instance.serviceProvider;

            _mapper = _service.GetRequiredService<IMapper>();

            Application.Current.Dispatcher.Invoke(async () =>
            {

                var loadData = LoadData(SearchText, Page, PageSize);
                var countItems = CountItems();
                var loadTeacher = LoadingTeacher();
                var loadCourse = LoadingCourse();

                await Task.WhenAll(loadData, countItems, loadTeacher, loadCourse);

            });


            ToggleComboBoxFilterCommand = new RelayCommand(_canExecute => true, _execute => { IsComboBoxOpen = !IsComboBoxOpen; });
            ChangePageSizeCommand = new RelayCommand<ComboBoxItem>(_canExecute => true, async _execute => await ChangePageSizeCommandHandler(_execute!));

            FirstPageCommand = new RelayCommand(_canExecute => true, async _execute => { Page = 1; await LoadData(SearchText, Page, PageSize); });
            PrevPageCommand = new RelayCommand(_canExecute => true, async _execute => { if (Page > 1) Page--; await LoadData(SearchText, Page, PageSize); });
            NextPageCommand = new RelayCommand(_canExecute => true, async _execute => { if (Page < TotalPages) Page++; await LoadData(SearchText, Page, PageSize); });
            LastPageCommand = new RelayCommand(_canExecute => true, async _execute => { Page = TotalPages; await LoadData(SearchText, Page, PageSize); });

            SearchTextCommand = new RelayCommand<string>(_canExecute => true, async _execute => await SearchGradeCommandHandler(SearchText));


            OpenCreateGradeModalCommand = new RelayCommand(_canExecute => true, _execute => { IsOpenCreateModal = !IsOpenCreateModal; });
            OpenDetailClassCommand = new RelayCommand<object>(_canExecute => true, async param =>
            {
                IsOpenClassDetail = !IsOpenClassDetail;

                if (param is int id)
                {
                    await GetStudentInClass(id);
                }
                else if (param is string strId && int.TryParse(strId, out int parsedId))
                {
                    await GetStudentInClass(parsedId);
                }

            });
            CreateClassCommand = new RelayCommand(_canExecute => true, async _execute =>
            {

                var entity = new AddClassDTO
                {
                    ClassCode = this.ClassCode,
                    ClassName = this.ClassName,
                    StartDate = this.StartDate.ToUniversalTime().ToString("o"),
                    EndDate = this.EndDate.ToUniversalTime().ToString("o"),
                    CourseId = long.Parse(this.CourseId),
                    TeacherId = long.Parse(this.TeacherId)
                };
                await CreateClassAsync(entity);

            });
            DeleteClassCommand = new RelayCommand<int>(
                 _canExecute => true,
                 async id => { await DeleteClassAsync(id); }
             );
        }

        #region Method Handler

        private async Task LoadData(string? name, int page, int pageSize)
        {
            IsLoading = true;

            try
            {
                GradeService gradeService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<GradeService>();
                var gradeInitDb = await gradeService.GetGradeByFilter(name, page, pageSize);

                if (!gradeInitDb.Any())
                {
                    IsLoading = false;
                    IsDataFound = true;
                    return;
                }

                Grades = gradeInitDb;
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
            GradeService gradeService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<GradeService>();
            TotalItems = await gradeService.CountAll();
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

        // CreateCommand
        public ICommand OpenCreateGradeModalCommand { get; private set; }
        public ICommand CreateClassCommand { get; private set; }
        public ICommand DeleteClassCommand { get; private set; }
        public ICommand OpenDetailClassCommand { get; private set; }


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

        private async Task SearchGradeCommandHandler(string name)
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

                GradeService gradeService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<GradeService>();
                var gradeInDb = await gradeService.GetGradeByFilter(name, Page, PageSize);
                if (gradeInDb.Any())
                {
                    Grades = gradeInDb;
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

        public async Task LoadingTeacher()
        {
            var _teacherService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<TeacherService>();
            var teacherList = await _teacherService.GetTeacherByFilter("", 1, 100);

            if (teacherList!.Any())
            {
                TeacherList = teacherList;
            }
        }

        public async Task LoadingCourse()
        {
            var _courseServices = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<CourseService>();
            var _courseList = await _courseServices.GetCourseByFilter("", 1, 100);

            if (_courseList!.Any())
            {
                CourseList = _courseList;
            }
        }

        public async Task CreateClassAsync(AddClassDTO classDTO)
        {
            var _classService = _service.GetRequiredService<GradeService>();

            //MessageBox.Show(classDTO.ToString());


            var result = await _classService.AddClassAsync(classDTO);
            if (result)
            {
                MessageBox.Show("Tạo lớp học thành công");
                IsOpenCreateModal = false;
                await CountItems();
                await LoadData(SearchText, Page, PageSize);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra vui lòng thử lại");
            }
        }

        public async Task DeleteClassAsync(int id)
        {

            var _classService = _service.GetRequiredService<GradeService>();
            var result = await _classService.DeleteClassAsync(id);
            if (!result)
            {
                MessageBox.Show("Có lỗi xảy ra vui lòng thử lại");
                return;
            }

            await LoadData(SearchText, Page, PageSize);
            await CountItems();
            MessageBox.Show("Xóa lớp học thành công");
        }

        public async Task GetStudentInClass(int? id)
        {


            var _classService = _service.GetRequiredService<GradeService>();
            var _classInfo = await _classService.GetById(id);

            if (_classInfo != null)
            {
               
                SetClassNameForDetail = _classInfo.ClassName;
            }

            var _studentInClass = await _classService.GetStudentByClassId(id);
            if (_studentInClass != null)
            {
                StudentInClass = _studentInClass;

            }
        
    
           
        

        }
    }
}
