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

namespace ShouldIBuy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        ArrayList availableItems;
        String recommendationString, numberofRecommendationsString, commonReviewsString;
        public MainWindow()
        {
            InitializeComponent();
            availableItems = new ArrayList();
            fillListView();
        }

       public void fillListView ()
        {
           

           
            availableItems.Add(new BasicItem("Paper Towels", "Wal-Mart", 2.99));
            availableItems.Add(new BasicItem("Shirt", "Target", 5.50));
            availableItems.Add(new BasicItem("Soap", "Dollar Tree", 1.00));


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
        private void Item_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateDisplays();
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

   
        private void updateDisplays()
        {
            getItemInformation_toDisplay();
            reviews_TextBox.Text = "The Number Of Reviews Posted For This Item " + numberofRecommendationsString;
            Recomm_TextBox.Text = recommendationString;
            commonReviews_TextBox.Text = commonReviewsString;

        }
       
    }
}
