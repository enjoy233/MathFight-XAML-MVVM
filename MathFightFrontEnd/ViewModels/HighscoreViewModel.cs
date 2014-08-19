using System.Collections.ObjectModel;
using MathFightFrontEnd.Data;
using MathFightFrontEnd.Models;

namespace MathFightFrontEnd.ViewModels
{
    public class HighscoreViewModel : ViewModelBase, IPageViewModel
    {
        private ObservableCollection<UsersRatingModel> highscores;

        public string Name
        {
            get
            {
                return "Highscores";
            }
        }

        public ObservableCollection<UsersRatingModel> Highscores
        {
            get
            {
                if (this.highscores == null)
                {
                    this.highscores = new ObservableCollection<UsersRatingModel>();
                }

                var requestHighscores = DataPersister.GetHighscores();
                this.highscores.Clear();
                foreach (var item in requestHighscores)
                {
                    this.highscores.Add(item);
                }

                return this.highscores;
            }
        }
    }
}