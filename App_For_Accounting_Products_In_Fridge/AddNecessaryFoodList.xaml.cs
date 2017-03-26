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
    /// Interaction logic for AddNecessaryFoodList.xaml
    /// </summary>
    public partial class AddNecessaryFoodList : Page
    {
        public AddNecessaryFoodList()
        {
            InitializeComponent();
        }
        List<Product> _necessaryProductsInFridge = new List<Product>();
        Product newProduct;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            newProduct = new Product(textBox.Text);
            _necessaryProductsInFridge.Add(newProduct);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Product item in _necessaryProductsInFridge)
            {
                
            }
        }
    }
}
