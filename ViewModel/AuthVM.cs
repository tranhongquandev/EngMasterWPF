using EngMasterWPF.Repository;
using EngMasterWPF.Utilities;
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

        public string errorMsg { get; set; } = string.Empty;

        public string Username { get => _username; set { _username = value; OnPropertyChanged(); } }

        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }

        private IAuthRepository _authRepository;

        public AuthVM(IAuthRepository authRepository)
        {
            _authRepository = authRepository;


            // Initialize the command
            LoginCommand = new RelayCommand<Window>(_canExecute => CanLogin(), _execute => Login(_execute!));
            PasswordChangedCommand = new RelayCommand<PasswordBox>(_canExecute => true, _execute => { Password = _execute!.Password; });

        }



        public ICommand LoginCommand { get; private set; }
        public ICommand PasswordChangedCommand { get; private set; }

        


        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        private void Login(Window sender)
        {
            var user = _authRepository.Find(x => x.Username == Username && x.Password == Password);

            if (user == null)
            {
                errorMsg = "Tài khoản hoặc mật khẩu không đúng. Vui lòng thử lại!";
                return;
            }

            var mainWindow = new MainWindow();
            mainWindow.Show();
            sender.Close();
        }
    }
}
