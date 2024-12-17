using EngMasterWPF.DTOs;
using EngMasterWPF.Services;
using EngMasterWPF.Utilities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EngMasterWPF.ViewModel
{
    public class StaffViewModel : ViewModelBase
    {

        private ObservableCollection<GetAllRoleDTO> _roleList = new ObservableCollection<GetAllRoleDTO>();
        public ObservableCollection<GetAllRoleDTO> RoleList
        {
            get => _roleList;
            set
            {
                _roleList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<GetStaffDTO> _staffList = new ObservableCollection<GetStaffDTO>();
        public ObservableCollection<GetStaffDTO> StaffList
        {
            get => _staffList;
            set
            {
                _staffList = value;
                OnPropertyChanged();
            }
        }

        private CancellationTokenSource _cancellationTokenSource;

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


        private int _page = 1;
        public int Page
        {
            get => _page;
            set
            {
                _page = value;
                OnPropertyChanged();
            }
        }

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize = value;
                OnPropertyChanged();
            }
        }

        private int _totalCount;
        public int TotalCount
        {
            get => _totalCount;
            set
            {
                _totalCount = value;
                OnPropertyChanged();
            }
        }


        private int _totalPage;
        public int TotalPage
        {
            get => _totalPage;
            set
            {
                _totalPage = value;
                OnPropertyChanged();
            }
        }

        private string? searchName = null;
        public string? SearchName
        {
            get => searchName;
            set
            {
                searchName = value;
                OnPropertyChanged();
            }
        }

        private static  IServiceProvider _serviceProvider = Installer.InstallServices.Instance.serviceProvider;

        private StaffService _staffService = _serviceProvider.GetRequiredService<StaffService>();

        private int? _userId = Installer.InstallServices.Instance.userId;


        public StaffViewModel()
        {
            

        Application.Current.Dispatcher.Invoke(async () =>
            {

                var loadInitData = GetData(null, Page, PageSize, _userId);

                await Task.WhenAll(loadInitData);

            });

            SearchCommand = new RelayCommand(_canExecute => true ,async _execute => await HandleSearchCommand(SearchName));


        }


        #region Declare Command

        public ICommand SearchCommand { get; private set; }

        #endregion


        #region Handle Data

        public async Task GetData(string? name, int? page, int? pageSize, int? userId)
        {
            
            var staffList = await _staffService.GetStaffByFilter(name, page, pageSize, userId);


            if (staffList.Any())
            {   
                StaffList = new ObservableCollection<GetStaffDTO>(staffList);
                TotalCount = StaffList.Count();
                TotalPage = (int)Math.Ceiling((double)TotalCount / PageSize);
            }
            else
            {
                return;
            }
        }

        #endregion

        #region Handle Command

        public async Task HandleSearchCommand(string? searchText)
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            if (string.IsNullOrEmpty(searchText))
            {
                await GetData(null, Page, PageSize, _userId);
                IsDataFound = false;
                return;
            }
            try
            {
                await Task.Delay(500, token);

                await GetData(searchText, Page, PageSize, _userId);
               
                    IsLoading = false;
                IsDataFound = false;


            }
            catch (TaskCanceledException)
            {
                IsLoading = false;

                IsDataFound = true;
                return;
            }
        }

        #endregion
    }
}
