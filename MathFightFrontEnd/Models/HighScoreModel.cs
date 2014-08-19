using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MathFightFrontEnd.Models
{
    [DataContract]
    public class HighScoreModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "rating")]
        public int Rating { get; set; }
    }
}
