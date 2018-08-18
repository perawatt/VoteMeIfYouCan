using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBService.Models
{
    public class User
    {
        [BsonId]
        public int _id { get; set; }
    }
}
