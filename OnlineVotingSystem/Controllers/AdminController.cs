using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineVotingSystem.Models;

namespace OnlineVotingSystem.Controllers
{
    public class AdminController : Controller
    {
        private VotingDbContext db = new VotingDbContext();

        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var validAdmin = db.Admins.FirstOrDefault(a => a.Username == admin.Username && a.Password == admin.Password);
            if (validAdmin != null)
            {
                Session["AdminId"] = validAdmin.AdminId;
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        public ActionResult Dashboard() => View(db.Candidates.ToList());

        public ActionResult AddCandidate() => View();

        [HttpPost]
        public ActionResult AddCandidate(Candidate candidate)
        {
            db.Candidates.Add(candidate);
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }

}