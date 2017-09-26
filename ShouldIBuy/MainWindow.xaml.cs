using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace ShouldIBuy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    

public partial class MainWindow : Window
    {

        private ArrayList availableItems, webResults;
        
        private String recommendationString, numberofRecommendationsString, commonReviewsString;
        public MainWindow()
        {
            InitializeComponent();
            availableItems = new ArrayList();
            webResults = new ArrayList();           
            fillListView();
        }

       public void fillListView ()
        {

            availableItems = WebOperations.loadProducts();
            

            foreach (BasicItem b in availableItems)
            {

                this.Item_List.Items.Add(b.GetName());
            }

        }

        private void AddReview_Button_Click(object sender, RoutedEventArgs e)
        {
            double rating = this.AddReview_Slider.Value;
            string comments = this.AddReview_Comment.Text;

          
            
            if(getSelectedItem() != null)
            {
                foreach (BasicItem b in availableItems)
                {
                    if (b.GetName() == getSelectedItem())
                    {
                       
                        b.AddReview(new BasicReview(rating, comments));
                    }
                }

            }

            this.AddReview_Comment.Text = "";

            updateDisplays();


        }

        private string getSelectedItem() => this.Item_List.SelectedValue.ToString();

      

        

        private void Second_Tab_GotFocus(object sender, RoutedEventArgs e)
        {
            updateDisplays();
        }

        private void First_Tab_GotFocus(object sender, RoutedEventArgs e)
        {

            updateDisplays();

         }
       
        private void Third_Tab_GotFocus(object sender, RoutedEventArgs e)
        {

            updateDisplays();

            
        }

        private void Fourth_Tab_GotFocus(object sender, RoutedEventArgs e)

        {
            updateDisplays();
        }

        private void Item_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateDisplays();
        }

        private void searchResults_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.webResults = WebOperations.getWebResults();
            foreach(WebResult w in this.webResults)
            {
                if(searchResults_list.SelectedItem != null && searchResults_list.SelectedItem.ToString() == w.Title)
                {
                    Uri link = new Uri(w.Link);
                   web_browser.Navigate(link);
                   
                }
            }
           
        }

    


        private void getItemInformation_toDisplay()
        {
            if (getSelectedItem() != null)
            {
                foreach (BasicItem b in availableItems)
                {
                    if (b.GetName() == getSelectedItem())
                    {
                        numberofRecommendationsString = b.numberOfReviews().ToString();
                        recommendationString = b.MakeRecommendation();
                        commonReviewsString = b.processReviews();
                    }
                }

            }

        }

   
        private async void updateDisplays()
        {
            Item_List.IsEnabled = false;
            getItemInformation_toDisplay();
            reviews_TextBox.Text = "The Number Of Reviews Posted For This Item " + numberofRecommendationsString;
            Recomm_TextBox.Text = recommendationString;
            commonReviews_TextBox.Text = commonReviewsString;
           
          await WebOperations.GetProductAsync(getSelectedItem());
          this.webResults = WebOperations.getWebResults();
          searchResults_list.Items.Clear();
            foreach (WebResult w in webResults)
            {

                this.searchResults_list.Items.Add(w.Title);
            }
            Item_List.IsEnabled = true ;
          
        }
       
    }
}
