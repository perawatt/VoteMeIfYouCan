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
        Task<IEnumerable<TopicViewModel>> ListTopic(string userName);
        Task<IEnumerable<ChoiceViewModel>> ListChoice(string topicId);
        Task<IEnumerable<VoteViewModel>> GetVoteDetail(string topicId, string choiceId);
    }
}
