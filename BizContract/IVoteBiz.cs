using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SharedViewModel;

namespace BizContract
{
    public interface IVoteBiz
    {
        Task<string>Login(string userName);
        Task<ToppicAllViewModel> ListTopic(string userName);
        Task<TopicViewModel> ListChoice(string topicId);
        Task<IEnumerable<VoteViewModel>> GetVoteDetail(string topicId, string choiceId);
        Task Vote(int score, string topicId, string choiceId, string userName);
        Task AddTopic(string userName, string topicName);
        Task AddChoice(string userName, string topicId, string choiceName);
    }
}
