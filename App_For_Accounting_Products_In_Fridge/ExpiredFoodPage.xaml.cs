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
    /// Interaction logic for ExpiredFoodPage.xaml
    /// </summary>
    public partial class ExpiredFoodPage : Page
    {
        static string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        IO availableProductsListFileInput = new IO(path, "availableproductslistfile.txt");

        List<Product> _expiredProductsList = new List<Product>();
   List<Product> _currentExpiredProductsList = new List<Product>();
        List<Product> _availableProductsList = new List<Product>();

        public ExpiredFoodPage()
        {
            InitializeComponent();
            InputAvailableProductsList();
            RefreshListBox();
        }
        private void InputAvailableProductsList()
        {
            _availableProductsList = availableProductsListFileInput.ReadAvailableProductsList();
            DateTime thisDay = DateTime.Today;


            foreach (Product item in _availableProductsList)
            {


                if (((thisDay.Subtract(item.expirationDate)).Days) > 0)
                {
                    _currentExpiredProductsList.Add(item);

                }
            }
        }
    

        public void NewProductAdded(Product _newProduct)
        {
            _expiredProductsList.Add(_newProduct);
            DateTime thisDay = DateTime.Today;
 


                if (((thisDay.Subtract(_newProduct.expirationDate)).Days) > 0)
                {
                    _currentExpiredProductsList.Add(_newProduct);

                }
            
          
        }
        private void RefreshListBox()
        {
           

            listBoxExpiredFood.ItemsSource = null;
            listBoxExpiredFood.ItemsSource = _currentExpiredProductsList;
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
