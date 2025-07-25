using System.Linq;
using System.Web.Mvc;
using OnlineVotingSystem.Models;

namespace OnlineVotingSystem.Controllers
{
    public class VoteController : Controller
    {
        private VotingDbContext db = new VotingDbContext();

        // GET: /Vote/Result
        public ActionResult Result()
        {
            var results = db.Candidates
                .Select(c => new VoteResultViewModel
                {
                    CandidateName = c.Name,
                    Party = c.Party,
                    VoteCount = db.Votes.Count(v => v.CandidateId == c.CandidateId)
                })
                .ToList();

            return View(results);
        }

        // GET: /Vote/Vote
        public ActionResult Vote()
        {
            var candidates = db.Candidates.ToList();
            return View(candidates);
        }

        // POST: /Vote/Vote
        [HttpPost]
        public ActionResult Vote(int candidateId)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int userId = (int)Session["UserId"];

            // Check if the user has already voted
            var existingVote = db.Votes.FirstOrDefault(v => v.UserId == userId);
            if (existingVote != null)
            {
                TempData["Message"] = "You have already voted.";
                return RedirectToAction("Result");
            }

            // Save the vote
            var vote = new Vote
            {
                CandidateId = candidateId,
                UserId = userId
            };

            db.Votes.Add(vote);
            db.SaveChanges();

            TempData["Message"] = "Your vote has been successfully submitted!";
            return RedirectToAction("Result");
        }
    }
}
