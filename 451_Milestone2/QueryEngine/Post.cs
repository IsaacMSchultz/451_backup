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
        protected string User_Id;
        protected string Date;
        protected string Text;
        protected bool Flag;
        protected int Cool_Votes;
        protected int Funny_Votes;
        protected int Useful_Votes;

        internal virtual void getDeleted()
        {

        }
    }

    public class Review : Post
    {
        private string Review_Id;
        private string Business_Id;
        private int stars;

        public event PropertyChangedEventHandler reviewPropertyChanged; // notifies when a review has changed

        public Review(string business_Id, int strs, string text)
        {
            // generated a review_Id (22 characters long)
            // call method in QueryEngine to insert a new Review into database
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
        private string Reply_Id { get; set; }
        private string Review_Id { get; }

        public event PropertyChangedEventHandler replyPropertyChanged; // notifies when reply has changed

        public Reply(string business_Id, string review_Id, string text){
            // Change this to allow the GUI to have an event to grab the current review business_Id from QueryEngine
            // generate a Reply_Id

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
