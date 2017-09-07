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
        BasicReview r;
        ArrayList availableItems;
        public MainWindow()
        {
            InitializeComponent();
            availableItems = new ArrayList();
            Main();
        }

       public void Main()
        {
            BasicItem item1 = new BasicItem("Paper Towels", "Wal-Mart", 2.99);
            BasicItem item2 = new BasicItem("Shirt", "Target", 5.50);
            BasicItem item3 = new BasicItem("Soap", "Dollar Tree", 1.00);

           
            availableItems.Add(item1);
            availableItems.Add(item2);
            availableItems.Add(item3);


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
                        r = new BasicReview(rating, comments);
                        b.AddReview(r);
                    }
                }

            }






        }

        private string getSelectedItem() => this.Item_List.SelectedValue.ToString();

      

        

        private void Second_Tab_GotFocus(object sender, RoutedEventArgs e)
        {
            

            if (getSelectedItem()!= null)
            {
                foreach (BasicItem b in availableItems)
                {
                    if (b.GetName() == getSelectedItem())
                    {
                        this.Data_Display.Text = b.numberOfReviews().ToString();
                    }
                }

            }
        }

        private void First_Tab_GotFocus(object sender, RoutedEventArgs e)
        {
            if (getSelectedItem() != null)
            {
                foreach (BasicItem b in availableItems)
                {
                    if (b.GetName() == getSelectedItem())
                    {
                        this.Data_Display.Text = "We recommend you to: " + b.MakeRecommendation() + " because this item has an average rating of " + b.getAverage().ToString();
                    }
                }

            }

        }
    }
}
