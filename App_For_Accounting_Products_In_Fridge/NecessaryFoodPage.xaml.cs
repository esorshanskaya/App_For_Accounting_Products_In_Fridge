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
        static string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        IO necessaryProductsListFileInput = new IO(path, "necessaryproductslistfile.txt");
        IO necessaryProductsListFileOutput = new IO(path, "necessaryproductslistfile.txt");

        bool flag;
        int index;
        static string login;
        List<Product> _necessaryFoodList = new List<Product>();
        List<Product> _necessaryFoodListAfterSearching = new List<Product>();
     
        public NecessaryFoodPage()

        {


            InitializeComponent();
            InputNecessaryProductsList();
          
            RefreshListBox();
            OutputNecessaryProductsList();
           
        }
        public void Login(string _login)
        {
            login = _login;

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
        {
            try
            {
                if (!(flag == true))
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
                            if ((item.Name.Equals(_necessaryFoodListAfterSearching[NFlistBox.SelectedIndex].Name) && item.Amount.Equals(_necessaryFoodListAfterSearching[NFlistBox.SelectedIndex].Amount) && item.TradeMark.Equals(_necessaryFoodListAfterSearching[NFlistBox.SelectedIndex].TradeMark)))
                            { index = _necessaryFoodList.IndexOf(item); }
                        }


                        _necessaryFoodList.RemoveAt(index);
                        RefreshListBox();
                    }
                }
                necessaryProductsListFileOutput.WriteShoppingListAndNecessaryProductsList(_necessaryFoodList);
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
                    _necessaryFoodList.Clear();
                    RefreshListBox();
                    necessaryProductsListFileOutput.WriteShoppingListAndNecessaryProductsList(_necessaryFoodList);
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
            catch { MessageBox.Show("Произошла ошибка"); }
        }
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch { MessageBox.Show("Произошла ошибка"); }
        }
    }
}
