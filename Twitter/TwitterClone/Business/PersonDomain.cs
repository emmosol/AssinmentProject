using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterClone.Models;

namespace TwitterClone.Business
{
    public class PersonDomain
    {
        public void SetUserId()
        {

        }
        public string GetUserId()
        {
            return string.Empty;
        }
        public void SetFullName()
        {

        }
        public string GetFullName()
        {
            return string.Empty;
        }
        public string GetEmail()
        {
            return string.Empty;
        }
        public void SetEmail(string email)
        {

        }
        public void SetJoined(DateTime JoinedDate)
        {

        }

        public DateTime GetJoined()
        {
            return DateTime.Now;
        }
        public void SetActive(Boolean value)
        {

        }
        public bool GetActive()
        {
            return false;
        }
        public void SetFollowing()
        {
        }
        public List<Person> GetFollowing()
        {
            return new List<Person>();
        }
        public List<Person> GetFollowers()
        {
            return new List<Person>();
        }
        public void SetFollowers(List<Person> person)
        {

        }
        public void SetTweets(List<Tweet> tweets)
        {

        }
        public List<Tweet> GetTweets(List<Tweet> tweets)
        {
            return new List<Tweet>();
        }
    }
}