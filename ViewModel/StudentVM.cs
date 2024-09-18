using AutoMapper;
using EngMasterWPF.DTOs;
using EngMasterWPF.Repository;
using EngMasterWPF.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace EngMasterWPF.ViewModel
{
    public class StudentVM : BaseViewModel
    {
        private bool _isSelected = false;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }


        private int _currentPage = 1;
        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage < 1)
                {
                    _currentPage = 1;
                }
                else if (_currentPage > _pageCount)
                {
                    _currentPage = _pageCount;
                }
                else
                {
                    _currentPage = value;
                }
                OnPropertyChanged();


            }
        }

        private int _pageSize = 9;
        private int _pageCount = 0;
        public int DataCount { get; set; }


        private ObservableCollection<StudentDTO>? _students;
        public ObservableCollection<StudentDTO> Students
        {
            get { return _students!; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;
        public StudentVM()
        {
            // Get dependency injection
            IServiceProvider _services = Installer.InstallServices.Instance.serviceProvider;
            _userProfileRepository = _services.GetRequiredService<IUserProfileRepository>();
            _mapper = _services.GetRequiredService<IMapper>();

            // Init Data
            LoadData(CurrentPage);
            DataCount = _userProfileRepository.CountStudents();
            _pageCount = (int)Math.Ceiling((double)DataCount / _pageSize);


            // Init Command
            FirstPage = new RelayCommand(_canExecute => true, _execute => { CurrentPage = 1; LoadData(CurrentPage); });
            PreviousPage = new RelayCommand(_canExecute => true, _execute => { if (CurrentPage > 1) CurrentPage -= 1; LoadData(CurrentPage); });
            NextPage = new RelayCommand(_canExecute => true, _execute => { if (CurrentPage >= _pageCount) return; CurrentPage += 1; LoadData(CurrentPage); });
            LastPage = new RelayCommand(_canExecute => true, _execute => { CurrentPage = _pageCount; LoadData(CurrentPage); });
            SearchCommand = new RelayCommand(_canExecute => true, _execute => { SearchStudent(SearchValue!); });


        }



        private async void LoadData(int page)
        {
            IsLoading = true;

            Students = _mapper.Map<ObservableCollection<StudentDTO>>(_userProfileRepository.GetAllStudentsPagination(CurrentPage))!;

            await Task.Delay(1000);

            IsLoading = false;  // Tắt trạng thái loading khi tải xong

        }

        private string? _searchValue;
        public string? SearchValue
        {
            get { return _searchValue; }
            set
            {
                _searchValue = value;
                OnPropertyChanged();
            }
        }

        private void SearchStudent(string parameter)
        {
            var userInDB = _userProfileRepository.Find(x => x.FirstName!.Contains(parameter)! || x.LastName!.Contains(parameter));

            if (userInDB == null) return;

            Students = _mapper.Map<ObservableCollection<StudentDTO>>(userInDB)!;
        }

        #region Command
        public ICommand FirstPage { get; set; }
        public ICommand PreviousPage { get; set; }
        public ICommand NextPage { get; set; }
        public ICommand LastPage { get; set; }
        public ICommand SearchCommand { get; set; }
        #endregion





    }
}

