using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MathFightFrontEnd.Behavior;
using MathFightFrontEnd.Data;
using MathFightFrontEnd.Helpers;

namespace MathFightFrontEnd.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private ICommand changeViewModelCommand;

        private IPageViewModel currentViewModel;
        private bool loggedInUser = false;
        private ICommand logoutCommand;

        private string username;

        public IPageViewModel CurrentViewModel
        {
            get
            {
                return this.currentViewModel;
            }
            set
            {
                this.currentViewModel = value;
                this.OnPropertyChanged("CurrentViewModel");
            }
        }

        public bool LoggedInUser
        {
            get
            {
                return this.loggedInUser;
            }
            set
            {
                this.loggedInUser = value;
                this.OnPropertyChanged("LoggedInUser");
            }
        }

        public LoginRegisterFormViewModel LoginRegisterVM { get; set; }

        public MainMenuViewModel MainMenuVM { get; set; }

        public SingleplayerGameViewModel SingleplayerGameVM { get; set; }

        public MultiplayerGameViewModel MultiplayerGameVM { get; set; }

        public PlayMultiplayerViewModel PlayMultiplayerVM { get; set; }

        public HighscoreViewModel HighscoreVM { get; set; }

        public SettingsViewModel SettingsVM { get; set; }

        public ChooseDifficultyViewModel ChooseDifficultyVM { get; set; }

        public List<IPageViewModel> ViewModels { get; set; }

        public AppViewModel()
        {
            MainMenuVM = new MainMenuViewModel();
            SingleplayerGameVM = new SingleplayerGameViewModel();
            MultiplayerGameVM = new MultiplayerGameViewModel();
            PlayMultiplayerVM = new PlayMultiplayerViewModel();
            HighscoreVM = new HighscoreViewModel();
            SettingsVM = new SettingsViewModel();
            LoginRegisterVM = new LoginRegisterFormViewModel();
            ChooseDifficultyVM = new ChooseDifficultyViewModel();

            this.ViewModels = new List<IPageViewModel>();
            this.ViewModels.Add(MainMenuVM);

            LoginRegisterVM.LoginSuccess += this.LoginSuccessful;
            SettingsVM.UsernameChangedSuccess += this.UsernameChangedSuccessful;
            ChooseDifficultyVM.DifficultySelected += this.DifficultySelected;
            ChooseDifficultyVM.DifficultySelected += SingleplayerGameVM.DifficultySelected;
            SingleplayerGameVM.GameFinishedEvent += this.GameFinished;

            this.CurrentViewModel = this.LoginRegisterVM;
        }

        private void GameFinished(object sender, EventArgs e)
        {
            this.CurrentViewModel = this.MainMenuVM;
        }

        public ICommand ChangeViewModel
        {
            get
            {
                if (this.changeViewModelCommand == null)
                {
                    this.changeViewModelCommand =
                        new RelayCommand(this.HandleChangeViewModelCommand);
                }
                return this.changeViewModelCommand;
            }
        }

        public ICommand Logout
        {
            get
            {
                if (this.logoutCommand == null)
                {
                    this.logoutCommand = new RelayCommand(this.HandleLogoutCommand);
                }
                return this.logoutCommand;
            }
        }

        private void HandleLogoutCommand(object parameter)
        {
            bool isUserLoggedOut = DataPersister.LogoutUser();
            if (isUserLoggedOut)
            {
                this.Username = "";
                this.LoggedInUser = false;
                this.HandleChangeViewModelCommand(this.LoginRegisterVM);
            }
        }

        public void HandleChangeViewModelCommand(object parameter)
        {
            var newCurrentViewModel = parameter as IPageViewModel;
            this.CurrentViewModel = newCurrentViewModel;
        }

        private void LoginSuccessful(object sender, UserArgs e)
        {
            this.Username = e.Username;
            this.LoggedInUser = true;
            this.HandleChangeViewModelCommand(this.ViewModels[0]);
        }

        private void DifficultySelected(object sender, DifficultyArgs e)
        {
            this.CurrentViewModel = SingleplayerGameVM;
        }

        private void UsernameChangedSuccessful(object sender, UserArgs e)
        {
            this.Username = e.Username;
        }

        public string Username
        {
            get
            {
                if (string.IsNullOrEmpty(this.username))
                {
                    return "Anonymouse";
                }

                return username;
            }
            set
            {
                username = value;
                this.OnPropertyChanged("Username");
            }
        }
    }
}
