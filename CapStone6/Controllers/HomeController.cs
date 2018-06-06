using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapStone6.Models;

namespace CapStone6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TaskList()
        {
            Capstone6Entities ORM = new Capstone6Entities();

            ViewBag.TaskList = ORM.Tasks.ToList();

            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult RegisterNewUser(User newUser)
        {
            Capstone6Entities ORM = new Capstone6Entities();

            ORM.Users.Add(newUser);

            ORM.SaveChanges();

            return View("Index");
        }

        public ActionResult SignIn(User user)
        {
            Capstone6Entities ORM = new Capstone6Entities();

            List<User> users = ORM.Users.ToList();

            if (users.Where(X => X.UserName == user.UserName).ToList().Count() == 0)
            {
                ViewBag.Error = "Username does not exist";
                return View("Error");
            }

            User thisUser = ORM.Users.Find(user.UserName);

            if (thisUser.Password != user.Password)
            {
                ViewBag.Error = "Incorrect Password";
            }

            ViewBag.Message = $"Welcome {user.UserName}!";
            return View("Welcome");

        }
    }
}
