using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ShouldIBuy
{
    public class WebResult
    {
        private string title, link, snippet;
        public WebResult(string titleString, string linkString, string snippetString)
        {
            title = titleString;
            link = linkString;
            snippet = snippetString;

        }
        public string Title { get { return title; } set { title = value; } }
        public string Link { get { return link; } set { link = value; } }
        public string Snippet { get { return snippet; } set { snippet = value; } }


    }

    public static class WebOperations
    {

       static private ArrayList products = new ArrayList();
        static private ArrayList webResults = new ArrayList();
        static HttpClient client = new HttpClient();
        static private StreamReader streamReader;
        static private BasicItem b;
       static private JToken json;
        
        public static ArrayList loadProducts()
        {

            StreamReader streamReader = new StreamReader(@"C: \Users\HelenBelen\Documents\Visual Studio 2017\Projects\ShouldIBuy\ShouldIBuy\items.json");
            string itemText = streamReader.ReadToEnd();
            JToken json = JObject.Parse(itemText);
            List<JToken> newProducts = json.SelectToken("products").ToList();
            foreach (var item in newProducts)
            {

                b = new BasicItem(item.SelectToken("name").ToString(), item.SelectToken("location").ToString(), Convert.ToDouble(item.SelectToken("price").ToString()));
                List<JToken> newReviews = item.SelectToken("reviews").ToList();

                foreach(var review in newReviews)
                {
                    double d = 0.0;

                    

                    b.AddReview(new BasicReview((review.SelectToken("rating").First.Value<double>()), review.SelectToken("description").ToString()));

                }
                products.Add(b);
            }


            return products;


        }
       public  static async Task<bool> GetProductAsync(string selected)
        {
            string searchTerm = selected + " product reviews";
            string path = "https://www.googleapis.com/customsearch/v1?key=AIzaSyCry0Qr93JZNfA9C3YoMZUaFt8vO-V0U60&cx=015289336426978601899:4me23nqjxew&q=" + searchTerm;
            bool success = true;
            HttpResponseMessage response = await client.GetAsync(path);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    webResults.Clear();
                    string s = await response.Content.ReadAsStringAsync();
                    JToken json = JObject.Parse(s);
                    List<JToken> category = json.SelectToken("items").ToList();
                    foreach (var item in category)
                    {


                        webResults.Add(new WebResult(item.SelectToken("title").ToString(), item.SelectToken("link").ToString(), item.SelectToken("snippet").ToString()));
                    }

                }
            }
            catch (Exception e)
            {
                System.Console.Write(e.Message);
                success = false;
            }
            return success;

        }

        public static ArrayList getWebResults() => webResults;
      

    }

}
