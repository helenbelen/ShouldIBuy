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
        public double itemPrice;
        public int itemAverage;
        public static int itemID = 0;
        public int itemIDNumber;
        private ArrayList itemReviews, commonReviews;
        public BasicItem(string name, string location, double price)
        {
            itemID = itemID + 1;
            itemIDNumber = itemID;


            itemName = name;
            itemLocation = location;
            itemPrice = price;
            itemReviews = new ArrayList();
            commonReviews = new ArrayList();
            getAverage();


        }
        public string GetName() => itemName;
        public string GetLocation() => itemLocation;
        public double GetPrice() => itemPrice;

        public string MakeRecommendation() {
            getAverage();
            string recomm;
            if (numberOfReviews() > 0) {
                switch (itemAverage)
                {
                    case 0:
                        recomm = "We Recommend You Not Buy";
                        break;

                    case 1:
                        recomm = "We Recommend You Not Buy";
                        break;

                    case 2:
                        recomm = "We Recommend You Not Buy";
                        break;

                    case 3:
                        recomm = "We Recommend That You Wait";
                        break;

                    case 4:
                        recomm = "We Recommend That You Buy";
                        break;

                    case 5:
                        recomm = "We Recommend That You Buy";
                        break;

                    default:
                        recomm = "We Cannot Make A Recommendation";
                        break;

                }
            }
            else
            {
                recomm = "We Suggest You Wait Until At Least One Review Has Been Posted For This Item";
            }


            itemRecommendation = recomm;
            return itemRecommendation;
        }

        public void AddReview(BasicReview r) {

            itemReviews.Add(r);
            getAverage();

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
            getAverage();

        }

        public int getAverage() {
            if (itemReviews.Count > 0)
            {
                double sum = 0.0;
                foreach (BasicReview r in itemReviews)
                {
                    sum += r.GetRating();
                }

                itemAverage = (int)sum / (itemReviews.Count);
            }
            else
            {
                itemAverage = 0;
            }
            return itemAverage;
        }

        public int numberOfReviews() => itemReviews.Count;

        public int GetID() => itemIDNumber;

        public bool reviewOnItem(BasicReview r)
        {
            if (itemReviews.Contains(r))
            {
                return true;
            }

            return false;
        }

        public string commonReview(ArrayList reviewforItems) {
            return "";
        }


        public string commonSubsequence(string[] X, string[] Y, int firstArrayLength, int secondArrayLength)
        {
            //string rowLine = "{0}" + Environment.NewLine;
            string commonWords = Environment.NewLine;
          
          
           // int[,] stringArray = new int[firstArraylength + 1, secondArrayLength + 1];
            
            
            for (int i = 0; i <= firstArrayLength; i++)
            {
                //rowLine += "\n";
                for ( int j = 0; j <= secondArrayLength; j++)
                {
                    if (i == 0 || j == 0)
                    {
                       // stringArray[i, j] = 0;
                        //rowLine += stringArray[i, j] + "  ";
                    }
                    else if (X[i - 1] == Y[j - 1]) {
                       // stringArray[i, j] = stringArray[i - 1, j - 1] + 1;
                        commonWords += X[i - 1] + "...";
                        
                        //rowLine += stringArray[i, j] + "  ";
                    }
                    else
                    {
                       // stringArray[i, j] = Math.Max(stringArray[i - 1, j], stringArray[i, j - 1]);
                        //rowLine += stringArray[i, j] + "  ";
                    }
                }

            }

            return commonWords;
        }

        public string processReviews()
        {
            commonReviews.Clear();
            BasicReview[] myReviews = new BasicReview[itemReviews.Count];
            itemReviews.CopyTo(myReviews, 0);
            string myCommon = "";
            if (itemReviews.Count == 0)
            {
                myCommon = "There are no reviews for this item yeat";

            }
            else if (itemReviews.Count == 1)
            {

                myCommon = myReviews[0].GetDescription();
            }
            else
            {


                for (int i = 0; i < myReviews.Length - 1; i++)
                {
                    for (int j = 1; j < myReviews.Length; j++)
                    {
                        if (i != j)
                        {


                            string[] firstReview = myReviews[i].GetDescription().Split(' ');
                            string[] secondReview = myReviews[j].GetDescription().Split(' ');
                            int firstReviewLength = myReviews[i].GetDescription().Split(' ').Length;
                            int secondReviewLength = myReviews[j].GetDescription().Split(' ').Length;
                            commonReviews.Add(commonSubsequence(firstReview, secondReview, firstReviewLength, secondReviewLength));
                        }
                    }
                }
              
                int greatestLength = 0;
                foreach (String s in commonReviews)
                {
                    if (s.ToString().Length > greatestLength)
                    {

                        myCommon = s.ToString();
                        greatestLength = s.ToString().Length;
                    }
                    else if (s.ToString().Length == greatestLength)
                    {
                        myCommon += s.ToString();

                    }
                }
            }
            return myCommon;
        }

     
     }
}
