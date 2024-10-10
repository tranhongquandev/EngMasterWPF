using AutoMapper;
using EngMasterWPF.DTOs;

using EngMasterWPF.Services;
using EngMasterWPF.Utilities;
using Microsoft.Extensions.DependencyInjection;
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
    public class StudentViewModel : ViewModelBase
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

        private readonly IServiceProvider _service ;
       
        private readonly IMapper _mapper;
        

        #endregion

        public StudentViewModel()
        {
            Page = 1;
            PageSize = 10;

            _service = Installer.InstallServices.Instance.serviceProvider;
            
            _mapper = _service.GetRequiredService<IMapper>();

            Application.Current.Dispatcher.Invoke( async () =>
            {
                    
                   var loadData = LoadData(Page, PageSize);
                   var countItems = CountItems();

                   await Task.WhenAll(loadData, countItems);

            });


            ToggleComboBoxFilterCommand = new RelayCommand(_canExecute => true, _execute => { IsComboBoxOpen = !IsComboBoxOpen; });
            ChangePageSizeCommand = new RelayCommand<ComboBoxItem>(_canExecute => true,  async _execute => await ChangePageSizeCommandHandler(_execute!) );

            FirstPageCommand  = new RelayCommand(_canExecute => true, async _execute => { Page = 1; await LoadData(Page, PageSize); });
            PrevPageCommand = new RelayCommand(_canExecute => true, async _execute => { if(Page > 1) Page--; await LoadData(Page, PageSize); });
            NextPageCommand = new RelayCommand(_canExecute => true, async _execute => { if (Page < TotalPages) Page++; await LoadData(Page, PageSize); });
            LastPageCommand = new RelayCommand(_canExecute => true, async _execute => { Page = TotalPages; await LoadData(Page, PageSize); });



        }


        #region Method Handler

        private async Task LoadData(int page, int pageSize)
        {
            IsLoading = true;

            StudentService studentService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<StudentService>();
            var studentInDb = await studentService.GetStudentsByPageAsync(page,pageSize);

            if (!studentInDb.Any())
            {
                IsLoading = false;
                IsDataFound = true;
                return;
            }

            Students = studentInDb;
            await Task.Delay(500);
            IsLoading = false;
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
       

        #endregion

        #region Command Handler

        private async Task  ChangePageSizeCommandHandler(ComboBoxItem value)
        {

            if (value?.Content is string content && int.TryParse(content, out int newSize))
            {
                PageSize = newSize;
                TotalPages = (int)Math.Ceiling((double)TotalItems / PageSize);
                await LoadData(Page, PageSize); 
            }

        }


        #endregion


    }
}
