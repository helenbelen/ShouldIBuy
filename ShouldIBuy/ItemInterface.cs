using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ShouldIBuy
{
    interface ItemInterface
    {
        string GetName();
        string GetLocation();
        double GetPrice();
        int GetID();
        string MakeRecommendation();
        void AddReview(BasicReview r);
        void RemoveReview(BasicReview r);
        int getAverage();
        string commonReview(ArrayList a);
    }
}
