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
    /// Interaction logic for ShoppingListPage.xaml
    /// </summary>
    public partial class ShoppingListPage : Page
    {
        public ShoppingListPage()
        {
            InitializeComponent();
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
