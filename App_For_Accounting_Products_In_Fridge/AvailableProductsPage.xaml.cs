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

namespace App_For_Accounting_Products_In_Fridge
{
    /// <summary>
    /// Interaction logic for AvailableProductsPage.xaml
    /// </summary>
    public partial class AvailableProductsPage : Page
    {
        public AvailableProductsPage()
        {
            InitializeComponent();
        }
        private void listofProductsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.AvailableProductsListPage);
        }
        private void listofExpiringFoodButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.ExpiringFoodPage);
        }
        private void listofExpiredFoodButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.ExpiredFoodPage);
        }
        private void listofLongOpenedProductsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.LongOpenedProductsPage);
        }
       
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

       
    }
}
