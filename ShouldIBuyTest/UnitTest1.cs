using System;
using ShouldIBuy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShouldIBuyTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BasicItem_CreatedCorrectly()
        {
            BasicItem myItem = new BasicItem("Ball", "Wal-Mart", 1.00);
            String expected = "Ball";
            String actual = myItem.GetName();
            Assert.AreEqual(expected, actual, "Basic Item Constructor Isn't Not Working");


          }
        [TestMethod]
        public void BasicReview_CreatedCorrectly()
        {
            BasicReview myReview = new BasicReview(4.0, "This Item was pretty good");
            
            Double expected = 4.0;
            Double actual = myReview.GetRating();
            Assert.AreEqual(expected, actual, "Basic Revuew Constructor Isn't Not Working");


          }

        [TestMethod]
        public void AddReview_ToItem()
        {
            BasicItem myItem = new BasicItem("Ball", "Wal-Mart", 1.00);

            BasicReview myReview = new BasicReview(4.0, "This Item was pretty good");

            myItem.AddReview(myReview);

            int expected = 1;
            int actual = myItem.numberOfReviews();
            Assert.AreEqual(expected, actual, "Reviews Are Not Added To Item");


          }

        [TestMethod]
        public void RemoveReview_FromItem()
        {
            BasicItem myItem = new BasicItem("Ball", "Wal-Mart", 1.00);

            BasicReview myReview = new BasicReview(4.0, "This Item was pretty good");

            myItem.AddReview(myReview);
            myItem.RemoveReview(myReview);
            int expected = 0;
            int actual = myItem.numberOfReviews();
            Assert.AreEqual(expected, actual, "Reviews Are Not Removed From Item");


        }
        [TestMethod]
        public void RemoveCorrectReview_FromItem()
        {
            BasicItem myItem = new BasicItem("Ball", "Wal-Mart", 1.00);

            BasicReview myReview = new BasicReview(4.0, "This Item was pretty good");
            BasicReview mysecondReview = new BasicReview(4.0, "This Item was pretty good I suppose");
            BasicReview mythirdReview = new BasicReview(5.0, "This Item was pretty good");

            myItem.AddReview(myReview);
            myItem.AddReview(mysecondReview);
            myItem.AddReview(mythirdReview);
            myItem.RemoveReview(mysecondReview);
           
            Assert.IsFalse(myItem.reviewOnItem(mysecondReview),"The correct Review is not being removed");


        }

        [TestMethod]
        public void getReviewAverage()
        {
            BasicItem myItem = new BasicItem("Ball", "Wal-Mart", 1.00);

            BasicReview myReview = new BasicReview(4.0, "This Item was pretty good");
            BasicReview mysecondReview = new BasicReview(4.0, "This Item was pretty good I suppose");
            BasicReview mythirdReview = new BasicReview(5.0, "This Item was pretty good");

            myItem.AddReview(myReview);
            myItem.AddReview(mysecondReview);
            myItem.AddReview(mythirdReview);
         

            int expected = (int)((4.0 + 4.0 + 5.0) / 3.0);
            int actual = (int)myItem.getAverage();
            Assert.AreEqual(expected, actual, "Item is not calculating average correctly");


        }
        [TestMethod]
        public void getRecommendation()
        {
            BasicItem myItem = new BasicItem("Ball", "Wal-Mart", 1.00);

            BasicReview myReview = new BasicReview(4.0, "This Item was pretty good");
            BasicReview mysecondReview = new BasicReview(4.0, "This Item was pretty good I suppose");
            BasicReview mythirdReview = new BasicReview(5.0, "This Item was pretty good");

            myItem.AddReview(myReview);
            myItem.AddReview(mysecondReview);
            myItem.AddReview(mythirdReview);
            myItem.RemoveReview(mysecondReview);

            string expected = "We Recommend That You Buy";

            string actual = myItem.MakeRecommendation();
            Assert.AreEqual(expected, actual, "Item is providing the correct recommendation");


        }
        [TestMethod]
        public void ItemID_CalculatingCorrectly()
        {
            int expected = BasicItem.itemID + 5;
            BasicItem myItem = new BasicItem("Ball", "Wal-Mart", 1.00);
            BasicItem myItem2 = new BasicItem("Ball", "Wal-Mart", 1.00);
            BasicItem myItem3 = new BasicItem("Ball", "Wal-Mart", 1.00);
            BasicItem myItem4 = new BasicItem("Ball", "Wal-Mart", 1.00);
            BasicItem myItem5 = new BasicItem("Ball", "Wal-Mart", 1.00);
            


            int actual = myItem5.GetID();
            Assert.AreEqual(expected, actual, "Review Is Not Keeping track of ID");

        }

        [TestMethod]
        public void ReviewID_CalculatingCorrectly()
        {
            int expected = BasicReview.reviewID + 3;

            BasicReview myReview = new BasicReview(4.0, "This Item was pretty good");
            BasicReview mysecondReview = new BasicReview(4.0, "This Item was pretty good I suppose");
            BasicReview mythirdReview = new BasicReview(5.0, "This Item was pretty good");

            
            int actual = mythirdReview.GetID();
            Assert.AreEqual(expected, actual, "Review Is Not Keeping track of ID");



        }
        [TestMethod]
        public void getcommon_reviewText()
        {
            BasicItem myItem = new BasicItem("Ball", "Wal-Mart", 1.00);

            BasicReview myReview = new BasicReview(4.0, "This sucks!");
            BasicReview mysecondReview = new BasicReview(4.0, "This Item was pretty good I suppose");
            BasicReview mythirdReview = new BasicReview(5.0, "This Item was pretty good");

            myItem.AddReview(myReview);
            myItem.AddReview(mysecondReview);
            myItem.AddReview(mythirdReview);
            

            string expected = Environment.NewLine + "This...Item...was...pretty...good...";

            string actual = myItem.processReviews();
            Assert.AreEqual(expected, actual, "Item not getting the correct common string");


        }



    }
}
