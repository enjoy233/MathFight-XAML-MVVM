using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MathFightFrontEnd.Behavior;
using MathFightFrontEnd.Data;
using MathFightFrontEnd.Helpers;

namespace MathFightFrontEnd.ViewModels
{
    public class SettingsViewModel : ViewModelBase, IPageViewModel
    {
        private ICommand changeUsernameCommand;
        private ICommand changePasswordCommand;

        public event EventHandler<UserArgs> UsernameChangedSuccess;

        public string Name
        {
            get
            {
                return "Settings";
            }
        }

        public string NewUsername { get; set; }

        public ICommand ChangeUsername
        {
            get
            {
                if (this.changeUsernameCommand == null)
                {
                    this.changeUsernameCommand = new RelayCommand(this.HandleChangeUsernameCommand);
                }
                return this.changeUsernameCommand;
            }
        }

        public ICommand ChangePassword
        {
            get
            {
                if (this.changePasswordCommand == null)
                {
                    this.changePasswordCommand = new RelayCommand(this.HandleChangePasswordCommand);
                }
                return this.changePasswordCommand;
            }
        }

        protected void RaiseUsernameChangedSuccess(string username)
        {
            if (this.UsernameChangedSuccess != null)
            {
                this.UsernameChangedSuccess(this, new UserArgs(username));
            }
        }

        private void HandleChangePasswordCommand(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
            var authenticationCode = this.GetSha1HashData(password);

            if (DataPersister.ChangeSetting(null, authenticationCode))
            {
                MessageBox.Show("Password changed successfuly!");
            }
        }

        private void HandleChangeUsernameCommand(object parameter)
        {
            if (DataPersister.ChangeSetting(this.NewUsername, null))
            {
                this.RaiseUsernameChangedSuccess(NewUsername);
                MessageBox.Show("Username changed successfuly!");
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