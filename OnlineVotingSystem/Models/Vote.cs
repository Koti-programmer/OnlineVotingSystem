using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingSystem.Models
{
    public class Vote
    {
        public int VoteId { get; set; }
        public int UserId { get; set; }
        public int CandidateId { get; set; }

        public virtual User User { get; set; }
        public virtual Candidate Candidate { get; set; }
    }


}