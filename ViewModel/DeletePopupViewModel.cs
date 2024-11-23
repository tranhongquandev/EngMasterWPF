using AutoMapper;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EngMasterWPF.ViewModel
{
    public class DeletePopupViewModel : ViewModelBase
    {
        #region Property

        private bool _isOpen = true;
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

        public DeletePopupViewModel()
        {
            _service = Installer.InstallServices.Instance.serviceProvider;

            _mapper = _service.GetRequiredService<IMapper>();

            DeletCourseCommand = new RelayCommand(_canExecute => true, async _execute => await DeleteCourseAsync());

            ClosePopupCommand = new RelayCommand(_canExecute => true, _execute => CloseDialog());
        }

        #region Method Handler

        #endregion


        #region Command

        public ICommand ToggleComboBoxFilterCommand { get; private set; }
        public ICommand ChangePageSizeCommand { get; private set; }
        public ICommand DeletCourseCommand { get; private set; }

        public ICommand ClosePopupCommand { get; private set; }


        #endregion

        #region Command Handler

        private async Task DeleteCourseAsync()
        {

        }

        private void CloseDialog()
        {
            IsOpen = false;
        }



        #endregion


    }
}
