using DAC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DACContract
{
    public interface IVoteDAC
    {
        Task<User> GetUser(string userName);
        Task<IEnumerable<Topic>> ListTopic(string userName);
        Task<Topic> GetTopic(string topicId);
        Task<IEnumerable<Choice>> ListChoice(string topicId);
        Task<IEnumerable<Vote>> GetVoteDetail(string topicId, string choiceId);
        Task AddUser(User user);
        Task AddTopic(Topic topic);
        Task UpDateTopic(Topic topic);
    }
}
