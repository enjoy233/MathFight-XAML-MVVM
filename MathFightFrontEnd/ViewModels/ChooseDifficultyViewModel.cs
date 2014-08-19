using System;
using System.Windows.Input;
using MathFightFrontEnd.Behavior;
using MathFightFrontEnd.Helpers;
using MathFightFrontEnd.Models;

namespace MathFightFrontEnd.ViewModels
{
    public class ChooseDifficultyViewModel : ViewModelBase, IPageViewModel
    {
        private ICommand easySelectedCommand;
        private ICommand hardSelectedCommand;

        public event EventHandler<DifficultyArgs> DifficultySelected;

        public string Name
        {
            get
            {
                return "Choose Difficulty";
            }
        }

        public ICommand EasySelected
        {
            get
            {
                if (this.easySelectedCommand == null)
                {
                    this.easySelectedCommand = new RelayCommand(this.HandleEasySelectedCommand);
                }
                return this.easySelectedCommand;
            }
        }

        public ICommand HardSelected
        {
            get
            {
                if (this.hardSelectedCommand == null)
                {
                    this.hardSelectedCommand = new RelayCommand(this.HandleHardSelectedCommand);
                }
                return this.hardSelectedCommand;
            }
        }

        protected void RaiseDifficultySelected(Difficulty difficulty)
        {
            if (this.DifficultySelected != null)
            {
                this.DifficultySelected(this, new DifficultyArgs(difficulty));
            }
        }

        private void HandleHardSelectedCommand(object parameter)
        {
            this.RaiseDifficultySelected(Difficulty.Hard);
        }

        private void HandleEasySelectedCommand(object parameter)
        {
            this.RaiseDifficultySelected(Difficulty.Easy);
        }
    }
}