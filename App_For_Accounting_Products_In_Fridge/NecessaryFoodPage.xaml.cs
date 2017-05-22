﻿using System;
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
    /// Interaction logic for NecessaryFoodPage.xaml
    /// </summary>
    public partial class NecessaryFoodPage : Page
    {
        List<Product> _necessaryFoodList = new List<Product>();
        public NecessaryFoodPage()

        {


            InitializeComponent();
            _necessaryFoodList.Add(new Product("Milk"));
            RefreshListBox();
        }
        public void NewProductAdded(Product _newProduct)
        {
            _necessaryFoodList.Add(_newProduct);
            NFlistBox.ItemsSource = null;
            NFlistBox.ItemsSource = _necessaryFoodList;
        }
        private void RefreshListBox()
        {
            NFlistBox.ItemsSource = null;
            NFlistBox.ItemsSource = _necessaryFoodList;
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.AddNecessaryFoodListPage);
        }
        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (NFlistBox.SelectedIndex != -1)
            {
                _necessaryFoodList.RemoveAt(NFlistBox.SelectedIndex);
                RefreshListBox();
            }
        }
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            if (NFlistBox.SelectedIndex != -1)
            {
                NFlistBox.Focus();
                _necessaryFoodList.Clear();
                RefreshListBox();
            }
        }
    }
}
