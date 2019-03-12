using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QueryEngine
{
    public abstract class Post
    {
        protected string userId;
        protected string date;
        protected string text;
        protected bool flag;
        protected int coolVotes;
        protected int funnyVotes;
        protected int usefulVotes;

        internal virtual void getDeleted()
        {

        }
    }

    public class Review : Post
    {
        private string reviewId;
        private string businessId;
        private int stars;

        public event PropertyChangedEventHandler reviewPropertyChanged; // notifies when a review has changed

        public Review(string newBusinessId, int numStars, string newText)
        {
            // generate a review_Id (22 characters long)
            // for now, have the user enter the businessId but implement better later on
            // call method in QueryEngine to insert a new Review into database

            this.businessId = newBusinessId;
            this.stars = numStars;
            this.text = newText;
        }

        override internal void getDeleted()
        {

        }

        private void OnReviewPropertyChanged(object sender, PropertyChangedEventArgs e) // event handler for a change in review data
        {
            // Handle event in the QueryEngine class
        }
    }

    public class Reply : Post // Potential Extra Credit
    {
        private string replyId;
        private string reviewId;

        public event PropertyChangedEventHandler replyPropertyChanged; // notifies when reply has changed

        public Reply(string business_Id, string newReviewId, string newText){
            // Change this to allow the GUI to have an event to grab the current review business_Id from QueryEngine
            // generate a Reply_Id

            this.reviewId = newReviewId;
            this.text = newText;
        }

        override internal void getDeleted()
        {

        }

        private void OnReplyPropertyChanged(object sender, PropertyChangedEventArgs e) // event handler for a change in reply data
        {
            // Handle event in the QueryEngine class
        }
    }
}
