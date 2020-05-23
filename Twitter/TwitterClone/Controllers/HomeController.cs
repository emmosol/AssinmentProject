using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone.Filters;
using TwitterClone.Models;
using TwitterClone.Business;
using TwitterClone.DataAccess;

namespace TwitterClone.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private TwitterCloneDbContext db = new TwitterCloneDbContext();
        [HttpGet]
        public ActionResult Index(Person person)
        {
            //TweetsDomain td = new TweetsDomain();
            var viewModel = new PersonTweetModel
            {
                TweetsList = db.Tweet.ToList(),
                Tweet = new Tweet(),
                Person = new Person()

            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult UpdateTweet(PersonTweetModel domainObject)
        {
            var user = User.Identity.Name;
            domainObject.Tweet.UserId = user;
            domainObject.Tweet.Created = DateTime.Now;
            var viewModel = new PersonTweetModel
            {
                TweetsList = domainObject.TweetsList,
                Tweet = domainObject.Tweet,
                Person = domainObject.Person

            };

            TweetsDomain td = new TweetsDomain();
            td.SetMessage(domainObject.Tweet);
            viewModel.TweetsList = db.Tweet.ToList();
            return RedirectToAction("Index","Home");
        }


        public ActionResult NewTweet(PersonTweetModel domainObject)
        {
            var user = User.Identity.Name;
            domainObject.Tweet.UserId = user;
            domainObject.Tweet.Created = DateTime.Now;
            var viewModel = new PersonTweetModel
            {
                TweetsList = domainObject.TweetsList,
                Tweet = domainObject.Tweet,
                Person = domainObject.Person

            };

            TweetsDomain td = new TweetsDomain();
            td.SetMessage(domainObject.Tweet);
            return View(viewModel);
        }
    }
}