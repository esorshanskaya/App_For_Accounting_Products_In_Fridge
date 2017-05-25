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
    /// Interaction logic for EditingProductPage.xaml
    /// </summary>
    public partial class EditingProductPage : Page
    {
        List<Product> _availableProductsList = new List<Product>();
        Product oldProduct;
        public EditingProductPage()
        {

   

            InitializeComponent();

        }

        Product _newProduct;
        public void NewProductAdded(Product _newProduct)
        {
            _availableProductsList.Add(_newProduct);
            oldProduct=new Product(_newProduct.Name, _newProduct.Amount, _newProduct.TradeMark, _newProduct.DateOfProduction, _newProduct.DateOfOpening, _newProduct.expirationDate);
            textBoxName.Text = _newProduct.Name;
            textBoxAmount.Text = _newProduct.Amount.ToString();
            textBoxTradeMark.Text = _newProduct.TradeMark;
            textBoxExpirationDate.Text = (_newProduct.expirationDate).ToString("d");
            textBoxDateOfProduction.Text = (_newProduct.DateOfProduction).ToString("d");
            textBoxDateOfOpening.Text = (_newProduct.DateOfOpening).ToString("d");
        }
        public Product NewProduct
        {
            get
            {
                return _newProduct;
            }
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime thisDay = DateTime.Today;
                double amount;
                DateTime dateOfProduction;
                DateTime dateOfOpening;
                DateTime expirationDate1;
                if (string.IsNullOrWhiteSpace(textBoxName.Text))
                {

                    MessageBox.Show("Необходимо ввести название продукта");
                    textBoxName.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBoxTradeMark.Text))
                {

                    MessageBox.Show("Необходимо ввести название торговой марки");
                    textBoxName.Focus();
                    return;
                }
                if (!double.TryParse(textBoxAmount.Text, out amount))
                {
                    MessageBox.Show("Некорректное значение веса");
                    textBoxAmount.Focus();
                    return;
                }
                if (!DateTime.TryParse(textBoxDateOfProduction.Text, out dateOfProduction))
                {
                    MessageBox.Show("Некорректная дата");
                    textBoxDateOfProduction.Focus();
                    return;
                }

                string[] datearray = (textBoxDateOfProduction.Text).Split('.');
                DateTime dateofProduction = new DateTime((int.Parse(datearray[2])), (int.Parse(datearray[1])), (int.Parse(datearray[0])));
                if (((thisDay.Subtract(dateofProduction).Days) < 0))
                {
                    MessageBox.Show("Некорректная дата.");
                    textBoxDateOfProduction.Focus();
                    return;
                }
                if (!DateTime.TryParse(textBoxDateOfOpening.Text, out dateOfOpening))
                {
                    MessageBox.Show("Некорректная дата");
                    textBoxAmount.Focus();
                    return;
                }
                string[] dateOfOpeningarray = (textBoxDateOfOpening.Text).Split('.');
                DateTime dateofOpening = new DateTime((int.Parse(dateOfOpeningarray[2])), (int.Parse(dateOfOpeningarray[1])), (int.Parse(dateOfOpeningarray[0])));
                if (((thisDay.Subtract(dateofOpening).Days) < 0))
                {
                    MessageBox.Show("Некорректная дата.");
                    textBoxDateOfProduction.Focus();
                    return;
                }
                if (!DateTime.TryParse(textBoxExpirationDate.Text, out expirationDate1))
                {
                    MessageBox.Show("Некорректная дата");
                    textBoxAmount.Focus();
                    return;
                }
                string[] expirationDatearray = (textBoxExpirationDate.Text).Split('.');

                DateTime expirationDate = new DateTime((int.Parse(expirationDatearray[2])), (int.Parse(expirationDatearray[1])), (int.Parse(expirationDatearray[0])));

                _newProduct = new Product(textBoxName.Text, amount, textBoxTradeMark.Text, dateofProduction, dateofOpening, expirationDate);
                textBoxName.Text = "";
                textBoxAmount.Text = "";
                textBoxTradeMark.Text = "";
                textBoxExpirationDate.Text = "";
                textBoxDateOfProduction.Text = "";
                textBoxDateOfOpening.Text = "";
                Pages.AvailableProductsListPage.NewProductAdded(_newProduct);
                Pages.ExpiringFoodPage.NewProductAdded(_newProduct);
                Pages.ExpiredFoodPage.NewProductAdded(_newProduct);
                Pages.LongOpenedProductsPage.NewProductAdded(_newProduct);
           

                NavigationService.GoBack();
            }
            catch { MessageBox.Show("Произошла ошибка"); }
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Pages.AvailableProductsListPage.NewProductAdded(oldProduct);
            Pages.ExpiringFoodPage.NewProductAdded(oldProduct);
            Pages.ExpiredFoodPage.NewProductAdded(oldProduct);
            Pages.LongOpenedProductsPage.NewProductAdded(oldProduct);
            NavigationService.GoBack();
        }
    }
}

