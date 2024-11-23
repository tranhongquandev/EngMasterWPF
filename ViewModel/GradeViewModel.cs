﻿using AutoMapper;
using EngMasterWPF.DTOs;

using EngMasterWPF.Services;
using EngMasterWPF.Utilities;
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

        private readonly IServiceProvider _service;

        private readonly IMapper _mapper;

        private CancellationTokenSource _cancellationTokenSource;


        #endregion

        public GradeViewModel()
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

            SearchTextCommand = new RelayCommand<string>(_canExecute => true, async _execute => await SearchGradeCommandHandler(SearchText));
        }

        #region Method Handler

        private async Task LoadData(int page, int pageSize)
        {
            IsLoading = true;

            try
            {
                GradeService gradeService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<GradeService>();
                var gradeInitDb = await gradeService.GetGradesByPageAsync(page, pageSize);

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


        #endregion

        #region Command Handler

        private async Task ChangePageSizeCommandHandler(ComboBoxItem value)
        {

            if (value?.Content is string content && int.TryParse(content, out int newSize))
            {
                PageSize = newSize;
                TotalPages = (int)Math.Ceiling((double)TotalItems / PageSize);
                await LoadData(Page, PageSize);
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
                await LoadData(Page, PageSize);
                IsDataFound = false;
                return;
            }

            try
            {
                await Task.Delay(2000, token);

                GradeService gradeService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<GradeService>();
                var gradeInDb = await gradeService.GetByName(name);
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
    }
}
