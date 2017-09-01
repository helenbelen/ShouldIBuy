using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ShouldIBuy
{
    class BasicItem : ItemInterface
    {
        public string itemName, itemLocation, itemRecommendation;
        public double itemPrice, itemAverage;
        public static int itemID = 0;
        private int itemIDNumber;
        private ArrayList itemReviews; 
        public BasicItem(string name, string location, double price)
        {
            itemID++;
            itemIDNumber = itemID;
            itemName = name;
            itemLocation = location;
            itemPrice = price;
            itemReviews = new ArrayList();


        }
       public string GetName() => itemName;
       public string GetLocation() => itemLocation;
       public double GetPrice() => itemPrice;

        public string MakeRecommendation() {
            
                if(itemAverage >= 4.0)
            {
                itemRecommendation = "BUY";
            }
                else if(itemAverage < 4.0 && >= 2.0)
            {
                itemRecommendation = "WAIT";

            }
            else
            {
                itemRecommendation = "DONT BUY";
            }
            return itemRecommendation;
        }   
        
      public  void AddReview(BasicReview r){

            itemReviews.Add(r);

        }
        public void RemoveReview(BasicReview reviewToRemove) {
            foreach (BasicReview r in itemReviews) { 
            if (reviewToRemove.reviewNumber == r.reviewNumber)
                {
                 itemReviews.RemoveAt(itemReviews.IndexOf(reviewToRemove);
                }
            }

        }

       public double getAverage(){
            double sum = 0.0;
            foreach (BasicReview r in itemReviews)
            {
                sum += r.rating;
            }

            itemAverage = sum / (itemReviews.Count);
            return itemAverage;
        }
    }
}
