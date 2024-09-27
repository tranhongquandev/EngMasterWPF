using EngMasterWPF.Repository;
using EngMasterWPF.Utilities;
using Microsoft.Extensions.DependencyInjection;
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
                _email = value;
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
            if( !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
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
        #endregion

        #region Execute Handler

        private async Task SubmitCommandExecute()
        {

            IsSubmitting = true;

            var service = Installer.InstallServices.Instance.serviceProvider;

            IAuthRepository authRepository = service.GetRequiredService<IAuthRepository>();


            try
            {
                var userInDb = await authRepository.Find(x => x.Email == Email);

                if (userInDb.Count() > 0)
                {
                    var passwordInDb = userInDb.Select(x => x.PasswordHash);

                    if (BCrypt.Net.BCrypt.EnhancedVerify(Password, passwordInDb.First()))
                    {

                        await Task.Delay(2000);
                        MainWindowViewModel mainWindowViewModel = MainWindowViewModel.Instance;
                        mainWindowViewModel.CurrentView = new MainViewModel();
                        return;
                    }
                    else
                    {
                        await Task.Delay(2000);
                        IsSubmitting = false;
                        ErrorMessage = "Mật khẩu không chính xác. Vui lòng thử lại!";
                        return;

                    }

                }
                else
                {
                    await Task.Delay(2000);
                    ErrorMessage = "Tài khoản không tồn tại trên hệ thống.";
                    IsSubmitting = false;
                    return;
                }

            } catch (Exception )
            {
                ErrorMessage = "Không thể kết nối đến CDSL!";
                IsSubmitting = false;
                return;
            }

           
            
        }

        private async void DeveloperModeCommandExecute()
        {
            IsDeveloperModeSubmit = true;
            MainWindowViewModel mainWindowViewModel = MainWindowViewModel.Instance;
            await Task.Delay(2000);
            mainWindowViewModel.CurrentView = new MainViewModel();
            return;
        }

        #endregion
    }
}
