using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QueryEngine1
{
    public abstract class Post
    {
        protected string userId;
        protected string postId;
        protected string date;
        protected string text;
        protected bool flag; //if the post is flagged to be checked by a moderator
        protected int coolVotes;
        protected int funnyVotes;
        protected int usefulVotes;

        public string UserId { get { return userId; } }
        public string PostId { get { return postId; } }
        public string Date { get { return date; } }
        public string Text { get { return text; } }
        public bool Flag { get { return flag; } }
        public int CoolVotes { get { return coolVotes; } }
        public int FunnyVotes { get { return funnyVotes; } }
        public int UsefulVotes { get { return usefulVotes; } }

        public event PropertyChangedEventHandler PostPropertyChanged; // notifies when reply has changed

        internal virtual void getDeleted()
        {

        }

        internal void OnPostPropertyChanged(object sender, PropertyChangedEventArgs e) // event handler for a change in post data
        {
            OnPostPropertyChanged(this, e);
        }
    }

    public class Review : Post
    {
        //private string reviewId;
        private string businessId;
        private int stars;

        //public string ReviewId { get { return reviewId; } }
        public string BusinessId { get { return businessId; } }
        public int Stars { get { return stars; } }

        //public event PropertyChangedEventHandler reviewPropertyChanged; // notifies when a review has changed

        public Review(string newBusinessId, int numStars, string newText)
        {
            // generate a review_Id (22 characters long)
            // for now, have the user enter the businessId but implement better later on
            // call method in QueryEngine to insert a new Review into database

            this.businessId = newBusinessId;
            this.stars = numStars;
            this.text = newText;

            OnPostPropertyChanged(this, new PropertyChangedEventArgs("newReview"));
        }

        override internal void getDeleted()
        {

        }

        //private void OnPostPropertyChanged(object sender, PropertyChangedEventArgs e) // event handler for a change in review data
        //{
            // Handle event in the QueryEngine class
        //}
    }

    public class Reply : Post // Potential Extra Credit
    {
        //private string replyId;
        private string reviewId;

        //public string ReplyId { get { return replyId; } }
        public string ReviewId { get { return reviewId; } }

        //public event PropertyChangedEventHandler replyPropertyChanged; // notifies when reply has changed

        public Reply(string business_Id, string newReviewId, string newText){
            // Change this to allow the GUI to have an event to grab the current review business_Id from QueryEngine
            // generate a Reply_Id

            this.reviewId = newReviewId;
            this.text = newText;
        }

        override internal void getDeleted()
        {

        }

        //private void OnPostPropertyChanged(object sender, PropertyChangedEventArgs e) // event handler for a change in reply data
        //{
            // Handle event in the QueryEngine class
        //}
    }
}
