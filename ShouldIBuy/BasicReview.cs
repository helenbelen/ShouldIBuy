using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShouldIBuy
{
   
    class BasicReview : ReviewInterface
    {
        public double rating;
        public string description;
        public static int reviewID;
        public int reviewNumber;

        public BasicReview (double newRating, string newDescription){
            reviewID++;
            reviewNumber = reviewID;
            rating = newRating;
            description = newDescription;
        }

        public double GetRating() {
            
            return rating;

        }

        public String GetDescription() {

            return description;
        }



    }

}
