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
        //    //IO shoppingListFileInput = new IO(@"C:\Users\L\Desktop\proverka\", "shoppinglistfile.txt");
        //    List<Product> NecessaryProductsList = new List<Product>();
        //    IO necessaryProductsListFileInput = new IO(@"C:\Users\L\Desktop\proverka\", "necessaryproductslistfile.txt");
        //    List<Product> AvailableProductsList = new List<Product>();
        //    IO availableProductsListFileInput = new IO(@"C:\Users\L\Desktop\proverka\", "availableproductslistfile.txt");

        public StartingPage()
        {
            InitializeComponent();
            //InputShoppingList();
            //InputNecessaryProductsList();
            //InputAvailableProductsList();

          
        }
        //private void InputShoppingList()
        //    {
        //    ShoppingList = shoppingListFileInput.ReadShoppingListAndNecessaryProductsList();
        //    foreach (Product item in ShoppingList)
        //    {
        //        Pages.ShoppingListPage.NewProductAdded(item);
        //    }

            
        //}
        //private void InputNecessaryProductsList()
        //{
        //    NecessaryProductsList = availableProductsListFileInput.ReadAvailableProductsList();
        //    foreach (Product item in NecessaryProductsList)
        //    {
        //        Pages.NecessaryFoodPage.NewProductAdded(item);
        //    }
            
        //}
        //private void InputAvailableProductsList()
        //{
        //    AvailableProductsList = necessaryProductsListFileInput.ReadShoppingListAndNecessaryProductsList();
        //    foreach (Product item in AvailableProductsList)
        //    {
        //        Pages.AvailableProductsListPage.NewProductAdded(item);
        //    }
        //    return;

        //}
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //InputAvailableProductsList();
            //InputNecessaryProductsList();
            //InputAvailableProductsList();

        }
    }
}
