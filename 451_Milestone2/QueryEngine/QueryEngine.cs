using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QueryEngine
{
    /// <summary>
    /// 
    /// </summary>
    class QueryEngine 
    {
        private string searchQuery;
        public event PropertyChangedEventHandler yelpDataChanged; // event for notifying that there was a property changed. 

        QueryEngine()
        {
            searchQuery = "";
        }

        private void DataChanged(object sender, PropertyChangedEventArgs e) // Event handler for when user data changes.
        {
            // good model of how we will be implementing this class
            if (sender is Review reviewChanged)
            {
                if (e.PropertyName == "newReview")
                {
                    // run an INSERT if the reviewId is not in the database
                }

                // "UPDATE review WHERE review.reviewId = " AND reviewChanged.reviewId AND " 
            }
            YelpPropertyChanged(sender, e);
        }

        private void YelpPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            yelpDataChanged?.Invoke(sender, e);
        }

        public void addSearchParameter()
        {

        }
    }
}
