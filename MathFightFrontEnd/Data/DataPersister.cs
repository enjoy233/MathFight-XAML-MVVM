using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathFightFrontEnd.Models;
using System.Windows;

namespace MathFightFrontEnd.Data
{
    public class DataPersister
    {
        protected static string AccessToken { get; set; }

        private const string BaseServicesUrl = "http://blueberrywebapi.apphb.com/api/";

        internal static bool RegisterUser(string username, string email, string authenticationCode)
        {
            bool isRegistered = false;
            var userModel = new UserModel()
            {
                Username = username,
                Email = email,
                AuthCode = authenticationCode
            };
            try
            {
                HttpRequester.Post(BaseServicesUrl + "users/register", userModel);
                isRegistered = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Invalid username and/or paswword and/or email! ", "Something went wrong", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            return isRegistered;
        }

        internal static string LoginUser(string username, string authenticationCode)
        {
            var userModel = new UserModel()
            {
                Username = username,
                AuthCode = authenticationCode
            };

            LoginResponseModel loginResponse = new LoginResponseModel();
            try
            {
                loginResponse = HttpRequester.Post<LoginResponseModel>(BaseServicesUrl + "auth/token", userModel);
            }
            catch (Exception e)
            {
                MessageBox.Show("Username and/or password incorrect! ", "Something went wrong", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            AccessToken = loginResponse.AccessToken;
            return loginResponse.Username;
        }

        internal static bool LogoutUser()
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;
            bool isLogoutSuccessful = false;
            try
            {
                isLogoutSuccessful = HttpRequester.Put(BaseServicesUrl + "users/logout", headers);
            }
            catch (Exception e)
            {
                MessageBox.Show("Logout Error!", "Something went wrong", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            return isLogoutSuccessful;
        }

        internal static IEnumerable<UsersRatingModel> GetHighscores()
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;
            IEnumerable<UsersRatingModel> highscores = null;
            try
            {
                highscores = HttpRequester.Get<IEnumerable<UsersRatingModel>>(BaseServicesUrl + "users/highscore", headers);
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not get highscore! ", "Something went wrong", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            highscores = HttpRequester.Get<IEnumerable<UsersRatingModel>>(BaseServicesUrl + "users/highscore", headers);
            return highscores;
        }

        internal static List<ProblemModel> GetProblems(Difficulty difficulty)
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;
            List<ProblemModel> problems = new List<ProblemModel>();
            try
            {
                problems = HttpRequester.Get<List<ProblemModel>>(BaseServicesUrl + "problems?difficulty=" + (int)difficulty, headers);
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not get data from server! ", "Something went wrong", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            return problems;
        }

        internal static bool ChangeSetting(string username, string authenticationCode)
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;

            var userModel = new UserModel()
            {
                Username = username,
                AuthCode = authenticationCode
            };
            bool isChangeSuccessful = false;
            try
            {
                isChangeSuccessful = HttpRequester.Post<bool>(BaseServicesUrl + "users/change", userModel, headers);
            }
            catch (Exception e)
            {
                MessageBox.Show("Change settings unsuccessful! ", "Something went wrong", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            return isChangeSuccessful;
        }

        internal static IEnumerable<UsersRatingModel> GetMultiplayers()
        {
            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;
            IEnumerable<UsersRatingModel> multiplayers = null;
            try
            {
                multiplayers = HttpRequester.Get<IEnumerable<UsersRatingModel>>(BaseServicesUrl + "users/multiplayer", headers);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to load multiplayer! ", "Something went wrong", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            return multiplayers;
        }

        internal static bool SavePlayerScore(int score)
        {
            UsersRatingModel playerScore = new UsersRatingModel()
            {
                Rating = score
            };

            var headers = new Dictionary<string, string>();
            headers["X-accessToken"] = AccessToken;
            bool isSuccessfull = false;
            try
            {
                isSuccessfull = HttpRequester.Post<bool>(BaseServicesUrl + "users/rating", playerScore, headers);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to save player score! ", "Something went wrong", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            return isSuccessfull;
        }
    }
}