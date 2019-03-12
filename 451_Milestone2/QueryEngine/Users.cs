﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
//using System.Text.RegularExpressions;

namespace QueryEngine
{
    public abstract class BasicUser
    {
        public void Search() // function prototype to handle searching for all users
        {
            // will trigger some kind of event to let the GUI know what the search returned.
        }
    }

    class User : BasicUser
    {
        private string name;
        private Location userLocation;
        private string id;
        private int coolVotes;
        private int funnyVotes;
        private int useFull;
        private int fans;
        private int reviewCOunt;
        private double avgStars;

        public event PropertyChangedEventHandler userPropertyChanged; //event for notifying that there was a property changed. 

        public void WriteReview(string reviewText)
        {

        }

        public void Checkin(string businessId)
        {

        }

        public void RateBusiness(string businessId)
        {

        }

        public void FlagPost(string postId)
        {

        }

        public void VoteOnReview(string reviewId)
        {

        }
        
        public void AddFriend(string friendId)
        {

        }

        public void RemoveFriend(string friendId)
        {

        }

        public void DeleteReview(string reviewId) //only for deleing the users own review
        {

        }

        public bool LogIn()
        {
            return true;
        }

        public bool LogOut()
        {
            return true;
        }

        public void WriteReply(string replyText, string postId) //possible extra credit to track replies on comments.
        {

        }

        public void EditPost()
        {
            OnUserPropertyChanged(this, new PropertyChangedEventArgs("postText"));
        }

        private void OnUserPropertyChanged(object sender, PropertyChangedEventArgs e) //event handler for a change in user data.
        {
            //how to handle this in the QueryEngine class
        }
    }

    public class UnRegisteredUser : BasicUser
    {
        public bool Register() //function to handle building a new user class with the information the new user types in.
        {
            return true;
        }
    }

    public class BusinessAdmin : BasicUser
    {
        private string businessId;
        private string businessName;

        public void FlagPost(string postId)
        {

        }

        public void WriteReply(string replyText, string postId) //possible extra credit to track replies on comments.
        {

        }
    }

    public class Moderator : BasicUser //extra credit possibility
    {
        private string moderatorId;
        private string name;

        public void showFlaggedText()
        {

        }

        public void RemoveContent(string badPostId)
        {

        }

        public void BanUser(string userId)
        {

        }
    }
}
