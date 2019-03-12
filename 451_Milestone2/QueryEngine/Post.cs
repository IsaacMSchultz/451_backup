using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryEngine
{
    public abstract class Post
    {
        protected string User_Id { get; }
        protected string Date { get; set; }
        protected string Text { get; set; }
        protected int Cool_Votes { get; set; }
        protected int Funny_Votes { get; set; }
        protected int Useful_Votes { get; set; }

        public virtual void getDeleted()
        {

        }
    }

    public class Review : Post
    {
        private string Review_Id { get; set; }
        private string Business_Id { get; }
        private int stars { get; set; }

        public override void getDeleted()
        {

        }
    }

    public class Reply : Post // Potential Extra Credit
    {
        public override void getDeleted()
        {

        }
    }
}
