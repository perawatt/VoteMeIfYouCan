using DAC.Models;
using DACContract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace DAC
{
    public class VoteDAC : IVoteDAC
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<User> UserCollection;
        private readonly IMongoCollection<Topic> TopicCollection;

        public VoteDAC()
        {
            client = new MongoClient("mongodb://voteme:lljick146@ds056559.mlab.com:56559/votemeifyoucan");
            database = client.GetDatabase("votemeifyoucan");
            var userCollectionName = "user";
            var topicCollectionName = "topic";
            UserCollection = database.GetCollection<User>(userCollectionName);
            TopicCollection = database.GetCollection<Topic>(topicCollectionName);
        }


        public async Task<User> GetUser(string userName)
        {
            var result = await UserCollection.Find(it => it.UserName == userName).FirstOrDefaultAsync();
            return result;
        }

        public async Task AddUser(User user)
        {
            await UserCollection.InsertOneAsync(user);
        }

        public async Task AddTopic(Topic topic)
        {
            await TopicCollection.InsertOneAsync(topic);
        }

        public async Task UpDateTopic(Topic topic)
        {
            await TopicCollection.ReplaceOneAsync(it => it._id == topic._id, topic);
        }

        public async Task<IEnumerable<Choice>> ListChoice(string topicId)
        {
            var topic = await TopicCollection.Find(it => it._id == topicId).FirstOrDefaultAsync();
            var choice = topic.Choices.ToList();
            return choice;
        }

        public async Task<IEnumerable<Topic>> ListTopic(string userName)
        {
            var result = await TopicCollection.Find(it => true).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Vote>> GetVoteDetail(string topicId, string choiceId)
        {
            var topic = await TopicCollection.Find(it => it._id == topicId).FirstOrDefaultAsync();
            var choice = topic.Choices.FirstOrDefault(it => it._id == choiceId);
            return choice.Votes;
        }

        public async Task<Topic> GetTopic(string topicId)
        {
            var result = await TopicCollection.Find(it => it._id == topicId).FirstOrDefaultAsync();
            return result;
        }
    }
}
