using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using MathFightFrontEnd.Data;
using MathFightFrontEnd.Helpers;
using MathFightFrontEnd.Models;

namespace MathFightFrontEnd.ViewModels
{
    public class PlayMultiplayerViewModel : ViewModelBase, IPageViewModel
    {
        private IEnumerable<ProblemModel> problems;

        public Difficulty Difficulty { get; set; }

        public string Name
        {
            get
            {
                return "Multiplayer Playing";
            }
        }

        public int CurrentProblem { get; set; }

        public int TotalProblems { get; set; }

        public IEnumerable<ProblemModel> Problems
        {
            get
            {
                if (this.problems == null)
                {
                    this.problems = DataPersister.GetProblems(this.Difficulty);
                }
                return this.problems;
            }
        }

        public void DifficultySelected(object sender, DifficultyArgs e)
        {
            this.Difficulty = e.Difficulty;
        }

        public void NextProblem()
        {
            var phonesCollectionView = this.GetDefaultView(this.problems);
            phonesCollectionView.MoveCurrentToNext();
            if (phonesCollectionView.IsCurrentAfterLast)
            {
                phonesCollectionView.MoveCurrentToLast();
            }
        }

        private ICollectionView GetDefaultView<T>(IEnumerable<T> collection)
        {
            return CollectionViewSource.GetDefaultView(collection);
        }
    }
}