using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using MathFightFrontEnd.Behavior;
using MathFightFrontEnd.Data;
using MathFightFrontEnd.Helpers;

namespace MathFightFrontEnd.ViewModels
{
    public class LoginRegisterFormViewModel : ViewModelBase, IPageViewModel
    {
        private string message;
        private ICommand loginCommand;
        private ICommand registerCommand;

        public LoginRegisterFormViewModel()
        {
            // REMOVE
            this.Username = "martin";
            this.Email = "test@gmail.com";
        }

        public event EventHandler<UserArgs> LoginSuccess;

        public string Name
        {
            get
            {
                return "Login Form";
            }
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
                this.OnPropertyChanged("Message");
            }
        }

        public ICommand Login
        {
            get
            {
                if (this.loginCommand == null)
                {
                    this.loginCommand = new RelayCommand(this.HandleLoginCommand);
                }
                return this.loginCommand;
            }
        }

        public ICommand Register
        {
            get
            {
                if (this.registerCommand == null)
                {
                    this.registerCommand = new RelayCommand(this.HandleRegisterCommand);
                }
                return this.registerCommand;
            }
        }

        protected void RaiseLoginSuccess(string username)
        {
            if (this.LoginSuccess != null)
            {
                this.LoginSuccess(this, new UserArgs(username));
            }
        }

        private void HandleRegisterCommand(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
            var authenticationCode = this.GetSha1HashData(password);

            bool isRegistered = DataPersister.RegisterUser(this.Username, this.Email, authenticationCode);
            if (isRegistered)
            {
                this.HandleLoginCommand(parameter);
            }
        }

        private void HandleLoginCommand(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
            var authenticationCode = this.GetSha1HashData(password);

            var username = DataPersister.LoginUser(this.Username, authenticationCode);

            if (!string.IsNullOrEmpty(username))
            {
                this.RaiseLoginSuccess(username);
            }
        }

        private string GetSha1HashData(string text)
        {
            byte[] buffer = Encoding.Default.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSha1 = new SHA1CryptoServiceProvider();
            string hash = BitConverter.ToString(cryptoTransformSha1.ComputeHash(buffer)).Replace("-", "");
            return hash;
        }
    }
}