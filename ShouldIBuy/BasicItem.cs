using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ShouldIBuy
{
    public class BasicItem : ItemInterface
    {
        public string itemName, itemLocation, itemRecommendation;
        public double itemPrice, itemAverage;
        public static int itemID = 0;
        public int itemIDNumber = 0;
        private ArrayList itemReviews; 
        public BasicItem(string name, string location, double price)
        {
            itemID = 1 + itemID;
            itemIDNumber = itemID;
            itemName = name;
            itemLocation = location;
            itemPrice = price;
            itemReviews = new ArrayList();
            getAverage();


        }
       public string GetName() => itemName;
       public string GetLocation() => itemLocation;
       public double GetPrice() => itemPrice;

        public string MakeRecommendation() {
            getAverage();
            string recomm;
                if(itemAverage >= 4.0)
            {
                recomm = "BUY";
            }
                else if(itemAverage < 4.0 & itemAverage >= 2.0)
            {
                recomm = "WAIT";

            }
            else
            {
                recomm = "DONT BUY";
            }
            itemRecommendation = recomm;
            return itemRecommendation;
        }   
        
      public  void AddReview(BasicReview r){

            itemReviews.Add(r);

        }
        public void RemoveReview(BasicReview reviewToRemove)
        {
            
            foreach (BasicReview r in itemReviews)
            {
                if (reviewToRemove.reviewNumber == r.reviewNumber)
                {
                    itemReviews.RemoveAt(itemReviews.IndexOf(reviewToRemove));
                    break;
                }
            }

            
        }

       public double getAverage(){
            if (itemReviews.Count > 0)
            {
                double sum = 0.0;
                foreach (BasicReview r in itemReviews)
                {
                    sum += r.GetRating();
                }

                itemAverage = sum / (itemReviews.Count);
            }
            else
            {
                itemAverage = 0;
            }
            return itemAverage;
        }

        public int numberOfReviews() => itemReviews.Count;

        public int GetID() => itemIDNumber;

        public bool reviewOnItem (BasicReview r)
        {
            if (itemReviews.Contains(r))
            {
                return true;
            }
                
               return false;
        }
            
                 
     }
}
