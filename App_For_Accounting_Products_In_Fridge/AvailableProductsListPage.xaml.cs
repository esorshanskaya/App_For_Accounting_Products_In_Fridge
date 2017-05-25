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
    /// Interaction logic for AvailableProductsListPage.xaml
    /// </summary>
    public partial class AvailableProductsListPage : Page
    {
        IO availableProductsListFileInput = new IO(@"C:\Users\L\Desktop\proverka\", "availableproductslistfile.txt");
        IO availableProductsListFileOutput = new IO(@"C:\Users\L\Desktop\proverka\", "availableproductslistfile.txt");
        int index;
        bool flag;
        List<Product> _availableProductsList = new List<Product>();
        List<Product> _availableProductsListAfterSearching = new List<Product>();
        public AvailableProductsListPage()
        { 
      
            InitializeComponent();
            InputAvailableProductsList();
            
            RefreshListBox();
            
            OutputAvailableProductsList();
        }
        private void InputAvailableProductsList()
        {
            _availableProductsList = availableProductsListFileInput.ReadAvailableProductsList();
          

        }
        public void OutputAvailableProductsList()
        { availableProductsListFileOutput.WriteAvailableProductsList(_availableProductsList); }

        public void NewProductAdded(Product _newProduct)
        {
            _availableProductsList.Add(_newProduct);
            listBoxAvailableProducts.ItemsSource = null;
            listBoxAvailableProducts.ItemsSource = _availableProductsList;
            availableProductsListFileOutput.WriteAvailableProductsList(_availableProductsList);
        }
        private void RefreshListBox()
        {
            listBoxAvailableProducts.ItemsSource = null;
            listBoxAvailableProducts.ItemsSource = _availableProductsList;
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            listBoxAvailableProducts.ItemsSource = null;
            listBoxAvailableProducts.ItemsSource = _availableProductsList;
            NavigationService.GoBack();
            flag = false;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            listBoxAvailableProducts.ItemsSource = null;
            listBoxAvailableProducts.ItemsSource = _availableProductsList;
            NavigationService.Navigate(Pages.AddAvailableProductsPage);
            flag = false;
        }
        //private void buttonRemove_Click(object sender, RoutedEventArgs e)
        //{
        //    if (listBoxAvailableProducts.SelectedIndex != -1)
        //    {
        //        _availableProductsList.RemoveAt(listBoxAvailableProducts.SelectedIndex);
        //        RefreshListBox();
        //    }
        //    availableProductsListFileOutput.WriteAvailableProductsList(_availableProductsList);
        //}
        //private void clearButton_Click(object sender, RoutedEventArgs e)
        //{
        
        //        _availableProductsList.Clear();
        //        RefreshListBox();
        //    availableProductsListFileOutput.WriteAvailableProductsList(_availableProductsList);
        //}
        //private void editingButton_Click(object sender, RoutedEventArgs e)
        //{
            
        //    if (listBoxAvailableProducts.SelectedIndex != -1)
        //    {

        //        Pages.EditingProductPage.NewProductAdded(_availableProductsList[listBoxAvailableProducts.SelectedIndex]);
        //        _availableProductsList.RemoveAt(listBoxAvailableProducts.SelectedIndex);
        //        NavigationService.Navigate(Pages.EditingProductPage);

        //    }
        //    listBoxAvailableProducts.ItemsSource = null;
        //    listBoxAvailableProducts.ItemsSource = _availableProductsList;
        //}
        //     private void buttonSearch_Click(object sender, RoutedEventArgs e)
        //{
        //    _availableProductsListAfterSearching.Clear();
        //    string name = textBoxSearch.Text;
        //    foreach (Product item in _availableProductsList)
        //    {
        //        if (item.Name.Contains(name))
        //        { _availableProductsListAfterSearching.Add(item);
                   
        //        }
              

        //    }
            
        //    listBoxAvailableProducts.ItemsSource = null;
        //    listBoxAvailableProducts.ItemsSource = _availableProductsListAfterSearching;
        //    textBoxSearch.Clear();

        //}
        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (!(flag == true))
            {
                if (listBoxAvailableProducts.SelectedIndex != -1)
                {
                    _availableProductsList.RemoveAt(listBoxAvailableProducts.SelectedIndex);
                    RefreshListBox();
                }
            }
            if (flag == true)
            {
                if (listBoxAvailableProducts.SelectedIndex != -1)
                {
                    foreach (Product item in _availableProductsList)
                    {
                        if ((item.Name.Equals(_availableProductsListAfterSearching[listBoxAvailableProducts.SelectedIndex].Name) && item.Amount.Equals(_availableProductsListAfterSearching[listBoxAvailableProducts.SelectedIndex].Amount) && item.TradeMark.Equals(_availableProductsListAfterSearching[listBoxAvailableProducts.SelectedIndex].TradeMark)))
                        { index = _availableProductsList.IndexOf(item); }
                    }


                    _availableProductsList.RemoveAt(index);
                    RefreshListBox();
                }
            }
           availableProductsListFileOutput.WriteShoppingListAndNecessaryProductsList(_availableProductsList);
            flag = false;
        }
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(flag == true))
            {
                _availableProductsList.Clear();
                availableProductsListFileOutput.WriteShoppingListAndNecessaryProductsList(_availableProductsList);
                RefreshListBox();
            }
        }
        private void editingButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(flag == true))
            {
                if (listBoxAvailableProducts.SelectedIndex != -1)
                {

                    Pages.EditingProductPage.NewProductAdded(_availableProductsList[listBoxAvailableProducts.SelectedIndex]);
                    _availableProductsList.RemoveAt(listBoxAvailableProducts.SelectedIndex);
                    NavigationService.Navigate(Pages.EditingProductPage);
                    listBoxAvailableProducts.ItemsSource = null;
                    listBoxAvailableProducts.ItemsSource = _availableProductsList;

                }
            }
            if (flag == true)
            {
                if (listBoxAvailableProducts.SelectedIndex != -1)
                {
                    foreach (Product item in _availableProductsList)
                    {
                        if ((item.Name.Equals(_availableProductsListAfterSearching[listBoxAvailableProducts.SelectedIndex].Name) && item.Amount.Equals(_availableProductsListAfterSearching[listBoxAvailableProducts.SelectedIndex].Amount) && item.TradeMark.Equals(_availableProductsListAfterSearching[listBoxAvailableProducts.SelectedIndex].TradeMark)))
                        {
                            index = _availableProductsList.IndexOf(item);
                        }

                    }
                    Pages.EditingProductForPurchasingPage.NewProductAdded(_availableProductsList[index]);
                    _availableProductsList.RemoveAt(index);
                    NavigationService.Navigate(Pages.EditingProductForPurchasingPage);
                    listBoxAvailableProducts.ItemsSource = null;
                    listBoxAvailableProducts.ItemsSource = _availableProductsList;
                }
            }

            flag = false;

        }
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
            _availableProductsListAfterSearching.Clear();
            string name = textBoxSearch.Text;
            foreach (Product item in _availableProductsList)
            {
                if (item.Name.Contains(name))
                {
                    _availableProductsListAfterSearching.Add(item);

                }


            }

            listBoxAvailableProducts.ItemsSource = null;
            listBoxAvailableProducts.ItemsSource = _availableProductsListAfterSearching;
            textBoxSearch.Clear();

        }
    }
}

