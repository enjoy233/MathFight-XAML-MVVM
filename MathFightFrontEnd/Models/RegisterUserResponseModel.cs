﻿using System.Runtime.Serialization;

namespace MathFightWebApi.App.Models
{
    [DataContract]
    public class RegisterUserResponseModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }
    }
}