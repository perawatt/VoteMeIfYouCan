using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedViewModel
{
    public class TopicViewModel
    {
        public string _id { get; set; }
        public string TopicName { get; set; }
        public string OwnerUserName { get; set; }
        public IEnumerable<ChoiceViewModel> Choices { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
