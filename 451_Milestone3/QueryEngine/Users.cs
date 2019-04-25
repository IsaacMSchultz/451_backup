using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
//using System.Text.RegularExpressions;

namespace QueryEngine1
{
    public class User
    {
        private string name;
        private Location location;
        private string id;
        private int coolVotes;
        private int funnyVotes;
        private int usefulVotes;
        private int fans;
        private int reviewCount;
        private double avgStars;


        public string UserId { get { return id; } }
        public string UserName { get { return name; } }
        public Location UserLocation { get { return location; } }
        public int UserCoolVotes { get { return coolVotes; } }
        public int UserFunnyVotes { get { return funnyVotes; } }
        public int UserUsefulVotes { get { return usefulVotes; } }
        public int UserFans { get { return fans; } }
        public int UserReviewCount { get { return reviewCount; } }
        public double UserAvgStars { get { return avgStars; } }

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

    public class UnRegisteredUser
    {
        public bool Register() //function to handle building a new user class with the information the new user types in.
        {
            return true;
        }
    }

    public class BusinessAdmin
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

    public class Moderator //extra credit possibility
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
