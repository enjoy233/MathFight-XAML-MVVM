using System.Runtime.Serialization;

namespace MathFightFrontEnd.Models
{
    [DataContract]
    public class ProblemModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "question")]
        public string Question { get; set; }

        [DataMember(Name = "answer")]
        public string Answer { get; set; }

        [DataMember(Name = "difficulty")]
        public int Difficulty { get; set; }
    }
}