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
using System.IO;

namespace App_For_Accounting_Products_In_Fridge
{
    /// <summary>
    /// Interaction logic for StartingPage.xaml
    /// </summary>
    public partial class StartingPage : Page
    {
        List<Product> ShoppingList = new List<Product>();


        public StartingPage()
        {
            InitializeComponent();
            }
         
        private void AvailableProductsButton_Click(object sender, RoutedEventArgs e)
        {try
            {
                NavigationService.Navigate(Pages.AvailableProductsPage);
            }
            catch { MessageBox.Show("Error"); }
        }
        private void ProductsForPurchaseButton_Click(object sender, RoutedEventArgs e)
        {try
            {
                NavigationService.Navigate(Pages.ShoppingListPage);
            }
            catch { MessageBox.Show("Error"); }
        }
        private void necessaryFoodButton_Click(object sender, RoutedEventArgs e)
        {try
            {
                NavigationService.Navigate(Pages.NecessaryFoodPage);
            }
            catch { MessageBox.Show ("Error"); }
        }
        
    }
}
