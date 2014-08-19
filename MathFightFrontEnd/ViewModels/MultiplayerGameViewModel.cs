using System.Collections.ObjectModel;
using MathFightFrontEnd.Data;
using MathFightFrontEnd.Models;

namespace MathFightFrontEnd.ViewModels
{
    public class MultiplayerGameViewModel : ViewModelBase, IPageViewModel
    {
        private ObservableCollection<UsersRatingModel> multiplayerUsers;

        public string Name
        {
            get
            {
                return "Multiplayer Game";
            }
        }

        public ObservableCollection<UsersRatingModel> MultiplayerUsers
        {
            get
            {
                if (this.multiplayerUsers == null)
                {
                    this.multiplayerUsers = new ObservableCollection<UsersRatingModel>();
                }

                var requestHighscores = DataPersister.GetMultiplayers();
                this.multiplayerUsers.Clear();
                foreach (var item in requestHighscores)
                {
                    this.multiplayerUsers.Add(item);
                }

                return this.multiplayerUsers;
            }
        }
    }
}