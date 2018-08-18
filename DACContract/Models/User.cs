using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DAC.Models
{
    public class User
    {
        [BsonId]
        public string UserName { get; set; }
    }
}
