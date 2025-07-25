using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingSystem.Models
{
        public class VoteResultViewModel
        {
            public string CandidateName { get; set; }
            public string Party { get; set; }
            public int VoteCount { get; set; }
        }
    }

