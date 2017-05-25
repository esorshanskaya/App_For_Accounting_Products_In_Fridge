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
    /// Interaction logic for NecessaryFoodPage.xaml
    /// </summary>
    public partial class NecessaryFoodPage : Page
    {
        IO necessaryProductsListFileInput = new IO(@"C:\Users\L\Desktop\proverka\", "necessaryproductslistfile.txt");
        IO necessaryProductsListFileOutput = new IO(@"C:\Users\L\Desktop\proverka\", "necessaryproductslistfile.txt");
        bool flag;
        int index;
        List<Product> _necessaryFoodList = new List<Product>();
        List<Product> _necessaryFoodListAfterSearching = new List<Product>();
        public NecessaryFoodPage()

        {


            InitializeComponent();
            InputNecessaryProductsList();
            RefreshListBox();
            OutputNecessaryProductsList();
        }
        private void InputNecessaryProductsList()
        {
            _necessaryFoodList = necessaryProductsListFileInput.ReadShoppingListAndNecessaryProductsList();
            

        }
        public void OutputNecessaryProductsList()
        { necessaryProductsListFileOutput.WriteShoppingListAndNecessaryProductsList(_necessaryFoodList); }
        public void NewProductAdded(Product _newProduct)
        {
            _necessaryFoodList.Add(_newProduct);
            NFlistBox.ItemsSource = null;
            NFlistBox.ItemsSource = _necessaryFoodList;
            necessaryProductsListFileOutput.WriteShoppingListAndNecessaryProductsList(_necessaryFoodList);
        }
        private void RefreshListBox()
        {
            NFlistBox.ItemsSource = null;
            NFlistBox.ItemsSource = _necessaryFoodList;
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            NFlistBox.ItemsSource = null;
            NFlistBox.ItemsSource = _necessaryFoodList;
            flag = false;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.AddNecessaryFoodListPage);
            NFlistBox.ItemsSource = null;
            NFlistBox.ItemsSource = _necessaryFoodList;
          
        }
        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {if (!(flag == true))
            {
                if (NFlistBox.SelectedIndex != -1)
                {
                    _necessaryFoodList.RemoveAt(NFlistBox.SelectedIndex);
                    RefreshListBox();
                }
            }
            if (flag == true)
            {
                if (NFlistBox.SelectedIndex != -1)
                {
                    foreach (Product item in _necessaryFoodList)
                    {
                      if((item.Name.Equals(_necessaryFoodListAfterSearching[NFlistBox.SelectedIndex].Name) && item.Amount.Equals(_necessaryFoodListAfterSearching[NFlistBox.SelectedIndex].Amount) && item.TradeMark.Equals(_necessaryFoodListAfterSearching[NFlistBox.SelectedIndex].TradeMark)))
                        { index = _necessaryFoodList.IndexOf(item); }
                    }


                    _necessaryFoodList.RemoveAt(index);
                    RefreshListBox();
                }
            }
            necessaryProductsListFileOutput.WriteShoppingListAndNecessaryProductsList(_necessaryFoodList);
            flag = false;
        }
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(flag == true))
            {
                _necessaryFoodList.Clear();
                RefreshListBox();
                necessaryProductsListFileOutput.WriteShoppingListAndNecessaryProductsList(_necessaryFoodList);
            }
        }
        private void editingButton_Click(object sender, RoutedEventArgs e)
        {if (!(flag == true))
            {
                if (NFlistBox.SelectedIndex != -1)
                {

                    Pages.EditingNecessaryProductPage.NewProductAdded(_necessaryFoodList[NFlistBox.SelectedIndex]);
                    _necessaryFoodList.RemoveAt(NFlistBox.SelectedIndex);
                    NavigationService.Navigate(Pages.EditingNecessaryProductPage);
                    NFlistBox.ItemsSource = null;
                    NFlistBox.ItemsSource = _necessaryFoodList;
                }
            }
                if (flag == true)
                {
                    if (NFlistBox.SelectedIndex != -1)
                    {
                        foreach (Product item in _necessaryFoodList)
                        {
                            if ((item.Name.Equals(_necessaryFoodListAfterSearching[NFlistBox.SelectedIndex].Name) && item.Amount.Equals(_necessaryFoodListAfterSearching[NFlistBox.SelectedIndex].Amount) && item.TradeMark.Equals(_necessaryFoodListAfterSearching[NFlistBox.SelectedIndex].TradeMark)))
                            {
                                index = _necessaryFoodList.IndexOf(item);

                            }

                        }
                        Pages.EditingNecessaryProductPage.NewProductAdded(_necessaryFoodList[index]);
                        
                        NavigationService.Navigate(Pages.EditingNecessaryProductPage);
                        _necessaryFoodList.RemoveAt(index);
                        NFlistBox.ItemsSource = null;
                        NFlistBox.ItemsSource = _necessaryFoodList;
                    }
                }
            
               
            flag = false;
        
        }
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
            _necessaryFoodListAfterSearching.Clear();
            string name = textBoxSearch.Text;
            foreach (Product item in _necessaryFoodList)
            {
                if (item.Name.Contains(name))
                {
                    _necessaryFoodListAfterSearching.Add(item);

                }


            }
           
            NFlistBox.ItemsSource = null;
           NFlistBox.ItemsSource = _necessaryFoodListAfterSearching;
            textBoxSearch.Clear();

        }
    }
}
