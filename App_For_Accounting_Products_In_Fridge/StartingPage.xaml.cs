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
    /// Interaction logic for StartingPage.xaml
    /// </summary>
    public partial class StartingPage : Page
    {
        public StartingPage()
        {
            InitializeComponent();
        }
        private void AvailableProductsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.AvailableProductsPage);
        }
        private void ProductsForPurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.ShoppingListPage);
        }
        private void necessaryFoodButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.NecessaryFoodPage);
        }
    }
}
