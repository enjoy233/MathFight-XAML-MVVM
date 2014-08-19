using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MathFightFrontEnd.Behavior;
using MathFightFrontEnd.Data;
using MathFightFrontEnd.Helpers;
using MathFightFrontEnd.Models;
using System.ComponentModel;
using System.Windows.Data;
using System.Timers;
using System.Diagnostics;
using System.Windows;

namespace MathFightFrontEnd.ViewModels
{
    public class SingleplayerGameViewModel : ViewModelBase, IPageViewModel
    {
        private int currentProblem;
        private int totalProblems;
        private bool timerIsRunning;
        private int timeLeft;
        private Timer elapsedTime;
        private string answer;

        public int TimeLeft
        {
            get
            {
                return this.timeLeft;
            }
            set
            {
                this.timeLeft = value;
                this.OnPropertyChanged("TimeLeft");
            }
        }

        public Difficulty Difficulty { get; set; }

        public string Name
        {
            get
            {
                return "Singleplayer Game";
            }
        }

        public int CurrentProblem
        {
            get
            {
                return this.currentProblem;
            }
            set
            {
                this.currentProblem = value;
                this.OnPropertyChanged("CurrentProblem");
            }
        }

        public int TotalProblems
        {
            get
            {
                return this.totalProblems;
            }
            set
            {
                this.totalProblems = value;
                this.OnPropertyChanged("TotalProblems");
            }
        }

        public string Answer
        {
            get
            {
                return this.answer;
            }
            set
            {
                this.answer = value;
                this.OnPropertyChanged("Answer");
            }
        }

        private ICommand skipCommand;
        private ICommand checkCommand;

        public ICommand Skip
        {
            get
            {
                if (this.skipCommand == null)
                {
                    this.skipCommand = new RelayCommand(this.HandleSkipCommand);
                }
                return this.skipCommand;
            }
        }

        public ICommand Check
        {
            get
            {
                if (this.checkCommand == null)
                {
                    this.checkCommand = new RelayCommand(this.HandleCheckCommand);
                }
                return this.checkCommand;
            }
        }

        private void HandleCheckCommand(object parameter)
        {
            var inputBox = parameter as TextBox;
            inputBox.Focus();
            if (!string.IsNullOrEmpty(this.Answer))
            {
                this.playerAnswers.Add(this.Answer);
            }
            else
            {
                this.playerAnswers.Add(null);
            }
            this.Answer = "";
            HandleSkipCommand(true);
        }

        private void HandleSkipCommand(object parameter)
        {
            if (parameter == null)
            {
                this.playerAnswers.Add(null);
            }

            if (!this.timerIsRunning)
            {
                RunTimer();
                this.timerIsRunning = true;
            }

            if (this.NextProblem())
            {
                this.CurrentProblem++;
            }
            else
            {
                CalculatePlayerScore();
            }
            this.Answer = "";
        }

        private void RunTimer()
        {
            this.elapsedTime = new Timer(1000);
            this.elapsedTime.Start();
            this.elapsedTime.Elapsed += new ElapsedEventHandler(TimerElapsed);
        }

        private void StopTimer()
        {
            this.elapsedTime.Stop();
            this.elapsedTime.Enabled = false;
        }

        private void TimerElapsed(object sender, EventArgs e)
        {
            if (this.TimeLeft > 0)
            {
                this.TimeLeft--;
            }
            else
            {
                StopTimer();
                CalculatePlayerScore();
            }
        }

        public void DifficultySelected(object sender, DifficultyArgs e)
        {
            this.Difficulty = e.Difficulty;
        }

        private List<string> playerAnswers;

        public void CalculatePlayerScore()
        {
            int playerScore = 0;
            int playerAnswersCount = this.playerAnswers.Count;
            for (int i = 0; i < playerAnswersCount; i++)
            {
                if (playerAnswers[i] != null)
                {
                    if (playerAnswers[i] == problems[i].Answer)
                    {
                        switch (this.Difficulty)
                        {
                            case Difficulty.Easy:
                                playerScore += 3;
                                break;
                            case Difficulty.Hard:
                                playerScore += 5;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (this.Difficulty)
                        {
                            case Difficulty.Easy:
                                playerScore -= 1;
                                break;
                            case Difficulty.Hard:
                                playerScore -= 3;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            if (timerIsRunning)
            {
                DataPersister.SavePlayerScore(playerScore);
                MessageBox.Show(string.Format("Your score is {0}.", playerScore));
                RaiseGameFinished();
            }

            this.timerIsRunning = false;
            StopTimer();
        }

        public event EventHandler GameFinishedEvent;

        protected void RaiseGameFinished()
        {
            if (this.GameFinishedEvent != null)
            {
                this.GameFinishedEvent(this, new EventArgs());
            }
        }

        private List<ProblemModel> problems;

        public List<ProblemModel> Problems
        {
            get
            {
                playerAnswers = new List<string>();
                this.timerIsRunning = false;
                if (this.elapsedTime != null)
                {
                    this.StopTimer();
                }
                this.TimeLeft = 30;
                this.problems = DataPersister.GetProblems(this.Difficulty);
                this.CurrentProblem = 1;
                this.TotalProblems = problems.Count;

                return problems;
            }
        }

        private ICollectionView GetDefaultView<T>(IEnumerable<T> collection)
        {
            return CollectionViewSource.GetDefaultView(collection);
        }

        public bool NextProblem()
        {
            var phonesCollectionView = this.GetDefaultView(this.problems);
            phonesCollectionView.MoveCurrentToNext();
            if (phonesCollectionView.IsCurrentAfterLast)
            {
                phonesCollectionView.MoveCurrentToLast();
                return false;
            }

            return true;
        }
    }
}
