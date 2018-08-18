using BizContract;
using DAC;
using DAC.Models;
using DACContract;
using SharedViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Biz
{
    public class VoteBiz : IVoteBiz
    {
        IVoteDAC dac;

        VoteBiz()
        {
            dac = new VoteDAC();
        }

        public async Task<string> Login(string userName)
        {
            var user = await dac.GetUser(userName);
            if (user == null)
            {
                var newUser = new User { UserName = userName };
                await dac.AddUser(newUser);
            }
            return userName;
        }

        public async Task<ToppicAllViewModel> ListTopic(string userName)
        {
            var topic = await dac.ListTopic(userName);
            var viewTopic = topic.Select(it => new TopicViewModel
            {
                _id = it._id,
                Choices = it.Choices.Select(c => new ChoiceViewModel
                {
                    _id = c._id,
                    ChoiceName = c.ChoiceName,
                    Votes = c.Votes.Select(v => new VoteViewModel
                    {
                        _id = v._id,
                        Rate = v.Rate,
                        UserName = v.UserName,
                        VoteDate = v.VoteDate
                    }),
                    CreateDate = c.CreateDate
                }),
                CreateDate = it.CreateDate,
                OwnerUserName = it.OwnerUserName,
                TopicName = it.TopicName
            });
            var userTopic = viewTopic.Where(it => it.OwnerUserName == userName);

            var result = new ToppicAllViewModel
            {
                AllTopics = viewTopic,
                MyTopics = userTopic
            };
            return result;
        }

        public async Task<TopicViewModel> ListChoice(string topicId)
        {
            var topic =  await dac.GetTopic(topicId);
            var result = ConvertToTopicViewModel(topic);
            return result;
        }

        public Task<IEnumerable<VoteViewModel>> GetVoteDetail(string topicId, string choiceId)
        {
            throw new NotImplementedException();
        }

        public async Task AddTopic(string userName, string topicName)
        {
            var topic = new Topic
            {
                _id = Guid.NewGuid().ToString(),
                Choices = new List<Choice>(),
                OwnerUserName = userName,
                TopicName = topicName,
                CreateDate = DateTime.Now
            };
            await dac.AddTopic(topic);
        }

        public Task AddChoice(string userName, string topicId, string choiceName)
        {
            var choice = new Choice
            {

            };
            throw new NotImplementedException();
        }

        public Task Vote(int score, string topic, string choice, string userName)
        {
            throw new NotImplementedException();
        }

        private TopicViewModel ConvertToTopicViewModel(Topic topic)
        {
            var viewTopic = new TopicViewModel
            {
                _id = topic._id,
                Choices = topic.Choices.Select(c => new ChoiceViewModel
                {
                    _id = c._id,
                    ChoiceName = c.ChoiceName,
                    Votes = c.Votes.Select(v => new VoteViewModel
                    {
                        _id = v._id,
                        Rate = v.Rate,
                        UserName = v.UserName,
                        VoteDate = v.VoteDate
                    }),
                    CreateDate = c.CreateDate
                }),
                CreateDate = topic.CreateDate,
                OwnerUserName = topic.OwnerUserName,
                TopicName = topic.TopicName
            };

            return viewTopic;
        }

    }
}
