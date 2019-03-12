using System;
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

        }
    }

    class User : BasicUser
    {
        private string name;
        private double latitude;
        private double longitude;
        private string id;
        private int coolVotes;
        private int funnyVotes;
        private int useFull;
        private int fans;
        private int reviewCOunt;
        private double avgStars;

        public event PropertyChangedEventHandler userPropertyChanged; //event for notifying that there was a property changed. 

        public void WriteReview()
        {

        }

        public void Checkin()
        {

        }

        public void RateBusiness()
        {

        }

        public void FlagPost()
        {

        }

        public void VoteOnReview()
        {

        }
        
        public void AddFriend()
        {

        }

        public void RemoveFriend()
        {

        }

        public void DeleteReview() //only for deleing the users own review
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

        public void WriteReply() //possible extra credit to track replies on comments.
        {

        }

        public void EditPost()
        {

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

        public void FlagPost()
        {

        }

        public void WriteReply() //possible extra credit to track replies on comments.
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

        public void RemoveContent(Post badPost)
        {

        }

        public void BanUser(string userID)
        {

        }
    }

    public class Checkin
    {
        private string business_Id;
        private string day; // may need to select a different data type
        private string time; // ^
        private int count;
    }
}
