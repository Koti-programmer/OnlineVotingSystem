using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineVotingSystem.Models;

namespace OnlineVotingSystem.Controllers
{
    public class AccountController : Controller
    {
        private VotingDbContext db = new VotingDbContext();

        public ActionResult Register() => View();

        [HttpPost]
        public ActionResult Register(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(User user)
        {
            var validUser = db.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (validUser != null)
            {
                Session["UserId"] = validUser.UserId;
                return RedirectToAction("Vote", "Vote");
            }
            ViewBag.Error = "Invalid credentials";
            return View();
        }
    }

}