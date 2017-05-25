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
    /// Interaction logic for EditingNecessaryProductPage.xaml
    /// </summary>
    public partial class EditingNecessaryProductPage : Page
    {
        Product _newProduct;
        List<Product> _necessaryProductsList = new List<Product>();
        Product oldProduct;
        public EditingNecessaryProductPage()
        {
            InitializeComponent();
        }
        public void NewProductAdded(Product _newProduct)
        {
            _necessaryProductsList.Add(_newProduct);
            oldProduct = new Product(_newProduct.Name, _newProduct.Amount, _newProduct.TradeMark);

            textBoxName.Text = _newProduct.Name;
            textBoxAmount.Text = _newProduct.Amount.ToString();
            textBoxTradeMark.Text = _newProduct.TradeMark;
  
        }
        public Product NewProduct
        {
            get
            {
                return _newProduct;
            }
        }
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {try
            {
                double amount;
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
                _newProduct = new Product(textBoxName.Text, amount, textBoxTradeMark.Text);
                textBoxName.Text = "";
                textBoxAmount.Text = "";
                textBoxTradeMark.Text = "";
                Pages.NecessaryFoodPage.NewProductAdded(_newProduct);
                NavigationService.GoBack();
            }
            catch { MessageBox.Show("Произошла ошибка"); }
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Pages.NecessaryFoodPage.NewProductAdded(oldProduct);
          

            NavigationService.GoBack();
        }
    }
}
