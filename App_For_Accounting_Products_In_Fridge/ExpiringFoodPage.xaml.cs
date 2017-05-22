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
    /// Interaction logic for ExpiringFoodPage.xaml
    /// </summary>
    public partial class ExpiringFoodPage : Page
    {
       public  List<Product> _expiringProductsList = new List<Product>();
        public List<Product> _currentExpiringProductsList = new List<Product>();
     
     
        public ExpiringFoodPage()
          
        {
            InitializeComponent();
      

            RefreshListBox();
        }
        public void NewProductAdded(Product _newProduct)
        {
            _expiringProductsList.Add(_newProduct);
            DateTime thisDay = DateTime.Today;



            if ((((thisDay.Subtract(_newProduct.expirationDate)).Days) > -3) & (((thisDay.Subtract(_newProduct.expirationDate)).Days) <= 0))
            {
                _currentExpiringProductsList.Add(_newProduct);

            }
          
        }
        private void RefreshListBox()
        {
            listBoxExpiringFood.ItemsSource = null;
            listBoxExpiringFood.ItemsSource = _currentExpiringProductsList;
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
    }

