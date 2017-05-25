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
    /// Interaction logic for AddShoppingList.xaml
    /// </summary>
    public partial class AddShoppingList : Page
    {
        static string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        IO shoppingListFileOutput = new IO(path, "shoppinglistFile.txt");
        List<Product> _sL = new List<Product>();
        public AddShoppingList()
        {
            InitializeComponent();
        }
        Product _newProduct;
        public Product NewProduct
        {
            get
            {
                return _newProduct;
            }
        }
        public void OutputShoppingList()
        {
            shoppingListFileOutput.WriteShoppingListAndNecessaryProductsList(_sL);

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
                _sL.Add(_newProduct);
                //OutputShoppingList();
                Pages.ShoppingListPage.NewProductAdded(_newProduct);
                NavigationService.GoBack();
            }
            catch
            { MessageBox.Show("Произошла ошибка"); }

        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
