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

        public async Task AddChoice(string userName, string topicId, string choiceName)
        {
            var topic = await dac.GetTopic(topicId);
            var choice = new Choice
            {
                _id = Guid.NewGuid().ToString(),
                ChoiceName = choiceName,
                CreateDate = DateTime.Now,
                Votes = new List<Vote>(),
            };
            var upDatedchoice = new List<Choice>();
            upDatedchoice.AddRange(topic.Choices.ToList());
            upDatedchoice.Add(choice);
            var upDatedTopic = topic;
            upDatedTopic.Choices = upDatedchoice;
            await dac.UpDateTopic(upDatedTopic);
        }

        public async Task Vote(int score, string topicId, string choiceId, string userName)
        {
            var topic = await dac.GetTopic(topicId);

            var vote = new Vote
            {
                _id = Guid.NewGuid().ToString(),
                Rate = score,
                UserName = userName,
                VoteDate = DateTime.Now
            };

            var choice = topic.Choices.FirstOrDefault(it => it._id == choiceId);

            var updatedVote = new List<Vote>();
            updatedVote.AddRange(choice.Votes.ToList());
            updatedVote.Add(vote);

            var updatedChoice = choice;
            updatedChoice.Votes = updatedVote;
            var upDatedTopic = topic;

            upDatedTopic.Choices.FirstOrDefault(x => x._id == choiceId).Votes = updatedVote;

            await dac.UpDateTopic(upDatedTopic);
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
