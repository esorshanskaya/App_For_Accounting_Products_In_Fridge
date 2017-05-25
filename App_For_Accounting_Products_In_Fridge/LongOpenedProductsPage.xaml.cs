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
    /// Interaction logic for LongOpenedProductsPage.xaml
    /// </summary>
    public partial class LongOpenedProductsPage : Page
    {
        public List<Product> _availableProductsList = new List<Product>();
        public List<Product> _currentLongOpenedProductsList = new List<Product>();

        public LongOpenedProductsPage()
        {
            InitializeComponent();

            RefreshListBox();
        }
        public void NewProductAdded(Product _newProduct)
        {
            _availableProductsList.Add(_newProduct);
            DateTime thisDay = DateTime.Today;



            if ((((thisDay.Subtract(_newProduct.DateOfOpening)).Days) >5) )
            {
                _currentLongOpenedProductsList.Add(_newProduct);

            }

        }
        private void RefreshListBox()
        {
            listBoxLongOpenedProducts.ItemsSource = null;
            listBoxLongOpenedProducts.ItemsSource = _currentLongOpenedProductsList;
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
