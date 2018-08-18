using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAC.Models
{
    public class Topic
    {
        [BsonId]
        public string _id { get; set; }
        public string TopicName { get; set; }
        public string OwnerUserName { get; set; }
        public IEnumerable<Choice> Choices { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class Choice
    {
        [BsonId]
        public string _id { get; set; }
        public string ChoiceName { get; set; }
        public IEnumerable<Vote> Votes { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class Vote
    {
        [BsonId]
        public string _id { get; set; }
        public string UserName { get; set; }
        public int Rate { get; set; }
        public DateTime VoteDate { get; set; }
    }
}
