
using EngMasterWPF.Services;
using EngMasterWPF.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace EngMasterWPF.ViewModel
{
    public class AuthViewModel : ViewModelBase
    {
        #region Property

        private string? _email;
        public string? Email
        {
            get => _email;
            set
            {
                var regex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                _email = value;

                ErrorMessage = string.Empty;

                if (string.IsNullOrEmpty(value))
                {
                    EmailError = "Email không được để trống!";
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(value, regex))
                {
                    EmailError = "Email không hợp lệ!";
                }
                else
                {
                    EmailError = string.Empty;
                    _email = value;
                }
                OnPropertyChanged();
            }
        }

        private string? _emailError = string.Empty;
        public string? EmailError
        {
            get => _emailError;
            set
            {
                _emailError = value;
                OnPropertyChanged();
            }
        }

        private string? _password;
        public string? Password
        {

            get => _password;
            set
            {

                _password = value;
                OnPropertyChanged();
            }
        }

   

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        private bool _isSubmitting = false;
        public bool IsSubmitting
        {
            get => _isSubmitting;
            set
            {
                _isSubmitting = value;
                OnPropertyChanged();
            }
        }

        private bool _isDeveloperModeSubmit = false;
        public bool IsDeveloperModeSubmit
        {
            get => _isDeveloperModeSubmit;
            set
            {
                _isDeveloperModeSubmit = value;
                OnPropertyChanged();
            }
        }

        private bool _isCanSubmit = false;
        public bool IsCanSubmit
        {
            get =>  _isCanSubmit;
            set
            {
                _isCanSubmit = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public AuthViewModel()
        {
            SubmitCommand = new RelayCommand<Button>(_canExecute => CanSubmit(), async (_execute) =>  await SubmitCommandExecute());
            PasswordChangedCommand = new RelayCommand<PasswordBox>(_canExecute => true, _execute => { Password = _execute!.Password; });
            DeveloperCommand = new RelayCommand<Button>(_canExecute => true, _execute => DeveloperModeCommandExecute());
        }

        #region Command

        public ICommand SubmitCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand DeveloperCommand { get; set; }

        #endregion

        #region CanExecute Hanlder

        private bool CanSubmit()
        {
            bool isEmailValid = !string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(EmailError);
            bool isPasswordValid = !string.IsNullOrEmpty(Password);
            if (isEmailValid && isPasswordValid)
            {
                IsCanSubmit = true;
                return true;
            }
           else 
           {
                IsCanSubmit = false;
                return false;
            }
            
        }
        private async Task SubmitCommandExecute()
        {
            IsSubmitting = true;

            var _authService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<AuthService>();
            var result = await _authService.LoginAsync(Email!, Password!);

            if (result != null && result.GetType().GetProperty("status") != null && (int)result.GetType().GetProperty("status").GetValue(result) == 200)
            {
                var serviceProvider = Installer.InstallServices.Instance.serviceProvider;
                MainWindowViewModel mainWindowViewModel = MainWindowViewModel.Instance;
                MainViewModel mainViewModel = serviceProvider.GetRequiredService<MainViewModel>();
                var service = Installer.InstallServices.Instance;
                service.userId  = (int)result.GetType().GetProperty("userId").GetValue(result);
                mainWindowViewModel.CurrentView = mainViewModel;

                return;
            }
            else
            {
                ErrorMessage = "Email hoặc mật khẩu không đúng!";
            }
            IsSubmitting = false;
        }

        private async void DeveloperModeCommandExecute()
        {
            var serviceProvider = Installer.InstallServices.Instance.serviceProvider;
            IsDeveloperModeSubmit = true;
            MainWindowViewModel mainWindowViewModel = MainWindowViewModel.Instance;
            await Task.Delay(1000);
            MainViewModel mainViewModel = serviceProvider.GetRequiredService<MainViewModel>();
            
           


            mainWindowViewModel.CurrentView = mainViewModel;
            return;
        }

        #endregion
    }
}
