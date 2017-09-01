using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShouldIBuy
{
    interface ItemInterface
    {
        string GetName();
        string GetLocation();
        double GetPrice();
        string MakeRecommendation();
        void AddReview(BasicReview r);
        void RemoveReview(BasicReview r);
        double getAverage();
    }
}
