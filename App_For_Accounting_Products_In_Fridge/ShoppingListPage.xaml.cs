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
    /// Interaction logic for ShoppingListPage.xaml
    /// </summary>
    public partial class ShoppingListPage : Page
    {
        List<Product> _shoppingList = new List<Product>();
        public ShoppingListPage()
        {
           
           
            InitializeComponent();
            _shoppingList.Add(new Product("Milk"));
            RefreshListBox();
        }
        public void NewProductAdded(Product _newProduct)
        {
            _shoppingList.Add(_newProduct);
            ShoppinglistBox.ItemsSource = null;
            ShoppinglistBox.ItemsSource = _shoppingList;
        }
        private void RefreshListBox()
        {
            ShoppinglistBox.ItemsSource = null;
            ShoppinglistBox.ItemsSource = _shoppingList;
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        { 
            NavigationService.GoBack();
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.AddShoppingList);
        }
        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (ShoppinglistBox.SelectedIndex != -1)
            {
                _shoppingList.RemoveAt(ShoppinglistBox.SelectedIndex);
                RefreshListBox();
            }
        }
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            if (ShoppinglistBox.SelectedIndex != -1)
            {
                ShoppinglistBox.Focus();
                _shoppingList.Clear();
                RefreshListBox();
            }
        }
    }
}
