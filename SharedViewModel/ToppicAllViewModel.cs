﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedViewModel
{
    public class ToppicAllViewModel
    {
        public IEnumerable<TopicViewModel> MyTopics { get; set; }
        public IEnumerable<TopicViewModel> AllTopics { get; set; }

    }
}
