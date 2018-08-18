using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedViewModel
{
    public class VoteViewModel
    {
        public string _id { get; set; }
        public string UserName { get; set; }
        public int Rate { get; set; }
        public DateTime VoteDate { get; set; }
    }
}
