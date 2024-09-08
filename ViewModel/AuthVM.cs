using EngMasterWPF.Repository;
using EngMasterWPF.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EngMasterWPF.ViewModel
{
    public class AuthVM : BaseViewModel
    {
        private string _username = string.Empty;
        private string _password = string.Empty;
        
        private string _errorMsg = string.Empty;
        public string ErrorMsg { get => _errorMsg ; private set { _errorMsg = value; OnPropertyChanged(); } }

        public string Username
        {
            get => _username; set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password; set { _password = value; OnPropertyChanged(); }
        }

        public AuthVM()
        {
            // Initialize the command
            LoginCommand = new RelayCommand<Window>(_canExecute => CanLogin(), _execute => LoginCommandHandler(_execute!));
            PasswordChangedCommand = new RelayCommand<PasswordBox>(_canExecute => true, _execute => { _password = _execute!.Password; });

          
        }

        public ICommand LoginCommand { get; private set; }
        public ICommand PasswordChangedCommand { get; private set; }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        private void LoginCommandHandler(Window sender)
        {
            var services = Installer.InstallServices.Instance.serviceProvider;

            IAuthRepository _authRepository = services.GetRequiredService<IAuthRepository>();

            //Check username
            var user = _authRepository.Find(x => x.Username == Username);

            if (user.Count() <= 0)
            {
                ErrorMsg = "Tài khoản không tồn tại. Vui lòng thử lại!";
                return;
            }
            if (user.Any(x => x.IsActive == false))
            {
                ErrorMsg = "Tài khoản đang bị khóa. Vui lòng liên hệ quản trị viên!";
                return;
            }
            else
            {
                //Check password
                var PasswordHashDB = user.Select( x => x.PasswordHash);
                if (BCrypt.Net.BCrypt.EnhancedVerify(Password, PasswordHashDB.First()))
                {
                    ErrorMsg = string.Empty;
                    var mainWindow = services.GetRequiredService<MainWindow>();
                    sender.Close();
                    mainWindow.ShowDialog();
                }
                else
                {
                    ErrorMsg = "Mật khẩu không đúng. Vui lòng thử lại!";
                    return;
                }  
            }

        }
    }
}
