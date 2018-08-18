using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedViewModel
{
    public class ChoiceViewModel
    {
        public string _id { get; set; }
        public string ChoiceName { get; set; }
        public IEnumerable<VoteViewModel> Votes { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
