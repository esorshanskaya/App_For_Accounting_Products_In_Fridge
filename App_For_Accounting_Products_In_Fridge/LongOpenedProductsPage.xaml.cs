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
        static string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        IO availableProductsListFileInput = new IO(path, "availableproductslistfile.txt");

        List<Product> _availableProductsListCopy = new List<Product>();

        public List<Product> _availableProductsList = new List<Product>();
        public List<Product> _currentLongOpenedProductsList = new List<Product>();

        public LongOpenedProductsPage()
        {
            InitializeComponent();
            InputAvailableProductsList();
            RefreshListBox();
        }
        private void InputAvailableProductsList()
        { try {
                _availableProductsListCopy = availableProductsListFileInput.ReadAvailableProductsList();
                DateTime thisDay = DateTime.Today;


                foreach (Product item in _availableProductsListCopy)
                {


                    if ((((thisDay.Subtract(item.DateOfOpening)).Days) > 5))
                    {
                        _currentLongOpenedProductsList.Add(item);

                    }
                }
            }
            catch { MessageBox.Show("Произошла ошибка"); }
        }
       
        public void NewProductAdded(Product _newProduct)
        {try
            {
                _availableProductsList.Add(_newProduct);
                DateTime thisDay = DateTime.Today;



                if ((((thisDay.Subtract(_newProduct.DateOfOpening)).Days) > 5))
                {
                    _currentLongOpenedProductsList.Add(_newProduct);

                }
            }
            catch { MessageBox.Show("Произошла ошибка"); }

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
