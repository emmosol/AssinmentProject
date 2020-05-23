using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TwitterClone.DataAccess;
using TwitterClone.Models;

namespace TwitterClone.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Person person)
        {

            using (var context = new TwitterCloneDbContext())
            {

                bool isValid = context.Person.Any(x => x.UserId == person.UserId && x.Password == person.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(person.UserId, false);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid Used details");
            }
                return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Person model)
        {
            using (var context = new TwitterCloneDbContext())
            {
                context.Person.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("login");
        }
        [HttpPost]
        public ActionResult Index(Person model)
        {
            if (model.UserId == "admin" && model.Password == "admin")
            {
                FormsAuthentication.SetAuthCookie(model.UserId, false);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Accounts");

        }
    }
}