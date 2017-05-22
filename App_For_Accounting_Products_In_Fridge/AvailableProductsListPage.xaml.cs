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
    /// Interaction logic for AvailableProductsListPage.xaml
    /// </summary>
    public partial class AvailableProductsListPage : Page
    {
        List<Product> _availableProductsList = new List<Product>();
        public AvailableProductsListPage()
        { 
      
            InitializeComponent();
            _availableProductsList.Add(new Product("Milk"));
            RefreshListBox();
        }
        public void NewProductAdded(Product _newProduct)
        {
            _availableProductsList.Add(_newProduct);
            listBoxAvailableProducts.ItemsSource = null;
            listBoxAvailableProducts.ItemsSource = _availableProductsList;
        }
        private void RefreshListBox()
        {
            listBoxAvailableProducts.ItemsSource = null;
            listBoxAvailableProducts.ItemsSource = _availableProductsList;
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.AddAvailableProductsPage);
        }
        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxAvailableProducts.SelectedIndex != -1)
            {
                _availableProductsList.RemoveAt(listBoxAvailableProducts.SelectedIndex);
                RefreshListBox();
            }
        }
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxAvailableProducts.SelectedIndex != -1)
            {
                listBoxAvailableProducts.Focus();
                _availableProductsList.Clear();
                RefreshListBox();
            }
        }
    }
}
