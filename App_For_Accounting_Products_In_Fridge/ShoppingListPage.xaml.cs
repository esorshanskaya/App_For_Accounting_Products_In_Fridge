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
    /// Interaction logic for ShoppingListPage.xaml
    /// </summary>
    public partial class ShoppingListPage : Page
    {
       
 static string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);


        IO shoppingListFileOutput = new IO(path, "shoppinglistFile.txt");
        IO shoppingListFileInput = new IO(path, "shoppinglistFile.txt");
        bool flag;
        int index;
        List<Product> _shoppingList = new List<Product>();
        List<Product> _shoppingListAfterSearching = new List<Product>();
        public ShoppingListPage()
        {


            InitializeComponent();
            InputShoppingList();
            RefreshListBox();
            OutputShoppingList();
        }
        private void InputShoppingList()
        {
            _shoppingList = shoppingListFileInput.ReadShoppingListAndNecessaryProductsList();



        }
        public void OutputShoppingList()
        {
            shoppingListFileOutput.WriteShoppingListAndNecessaryProductsList(_shoppingList);

        }
        public void NewProductAdded(Product _newProduct)
        {
            _shoppingList.Add(_newProduct);
            shoppingListFileOutput.WriteShoppingListAndNecessaryProductsList(_shoppingList);
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
            ShoppinglistBox.ItemsSource = null;
            ShoppinglistBox.ItemsSource = _shoppingList;
            flag = false;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.AddShoppingList);
            ShoppinglistBox.ItemsSource = null;
            ShoppinglistBox.ItemsSource = _shoppingList;
            flag = false;
        }


        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(flag == true))
                {
                    if (ShoppinglistBox.SelectedIndex != -1)
                    {
                        _shoppingList.RemoveAt(ShoppinglistBox.SelectedIndex);
                        RefreshListBox();
                    }
                }
                if (flag == true)
                {
                    if (ShoppinglistBox.SelectedIndex != -1)
                    {
                        foreach (Product item in _shoppingList)
                        {
                            if ((item.Name.Equals(_shoppingListAfterSearching[ShoppinglistBox.SelectedIndex].Name) && item.Amount.Equals(_shoppingListAfterSearching[ShoppinglistBox.SelectedIndex].Amount) && item.TradeMark.Equals(_shoppingListAfterSearching[ShoppinglistBox.SelectedIndex].TradeMark)))
                            { index = _shoppingList.IndexOf(item); }
                        }


                        _shoppingList.RemoveAt(index);
                        RefreshListBox();
                    }
                }
                shoppingListFileOutput.WriteShoppingListAndNecessaryProductsList(_shoppingList);
                flag = false;
            }
            catch { MessageBox.Show("Произошла ошибка"); }
        }
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(flag == true))
                {
                    _shoppingList.Clear();
                    shoppingListFileOutput.WriteShoppingListAndNecessaryProductsList(_shoppingList);
                    RefreshListBox();
                }
            }
            catch { MessageBox.Show("Произошла ошибка"); }
        }
        private void editingButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(flag == true))
                {
                    if (ShoppinglistBox.SelectedIndex != -1)
                    {

                        Pages.EditingProductForPurchasingPage.NewProductAdded(_shoppingList[ShoppinglistBox.SelectedIndex]);
                        _shoppingList.RemoveAt(ShoppinglistBox.SelectedIndex);
                        NavigationService.Navigate(Pages.EditingProductForPurchasingPage);
                        ShoppinglistBox.ItemsSource = null;
                        ShoppinglistBox.ItemsSource = _shoppingList;

                    }
                }
                if (flag == true)
                {
                    if (ShoppinglistBox.SelectedIndex != -1)
                    {
                        foreach (Product item in _shoppingList)
                        {
                            if ((item.Name.Equals(_shoppingListAfterSearching[ShoppinglistBox.SelectedIndex].Name) && item.Amount.Equals(_shoppingListAfterSearching[ShoppinglistBox.SelectedIndex].Amount) && item.TradeMark.Equals(_shoppingListAfterSearching[ShoppinglistBox.SelectedIndex].TradeMark)))
                            {
                                index = _shoppingList.IndexOf(item);
                            }

                        }
                        Pages.EditingProductForPurchasingPage.NewProductAdded(_shoppingList[index]);
                        _shoppingList.RemoveAt(index);
                        NavigationService.Navigate(Pages.EditingProductForPurchasingPage);
                        ShoppinglistBox.ItemsSource = null;
                        ShoppinglistBox.ItemsSource = _shoppingList;
                    }
                }

                flag = false;
            }
            catch { MessageBox.Show("Произошла ошибка"); }
        }
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                flag = true;
                _shoppingListAfterSearching.Clear();
                string name = textBoxSearch.Text;
                foreach (Product item in _shoppingList)
                {
                    if (item.Name.Contains(name))
                    {
                        _shoppingListAfterSearching.Add(item);

                    }


                }

                ShoppinglistBox.ItemsSource = null;
                ShoppinglistBox.ItemsSource = _shoppingListAfterSearching;
                textBoxSearch.Clear();

            }
            catch { MessageBox.Show("Произошла ошибка"); }
        }
    }
}
