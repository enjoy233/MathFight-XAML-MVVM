using System.Runtime.Serialization;

namespace MathFightFrontEnd.Models
{
    [DataContract]
    public class UsersRatingModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "rating")]
        public int Rating { get; set; }
    }
}