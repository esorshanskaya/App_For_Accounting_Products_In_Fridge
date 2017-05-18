using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_For_Accounting_Products_In_Fridge
{
    static class Pages
    {
        private static MainPage _mainPage = new MainPage();
        private static LoginPage _loginPage = new LoginPage();
        private static RegistrationPage _registrationPage = new RegistrationPage();
        private static StartingPage _startingPage = new StartingPage();
        private static AvailableProductsPage _availableProductsPage = new AvailableProductsPage();
        private static NecessaryFoodPage _necessaryFoodPage = new NecessaryFoodPage();
        private static ShoppingListPage _shoppingListPage = new ShoppingListPage();



        public static LoginPage LoginPage
        {
        get
            {
                return _loginPage;
            }
}
        public static RegistrationPage RegistrationPage
        {
            get
            {
                return _registrationPage;
            }
        }
        public static MainPage MainPage
{
    get
    {
        return _mainPage;
    }
}
        public static StartingPage StartingPage
        {
            get
            {
                return _startingPage;
            }
        }
        public static AvailableProductsPage AvailableProductsPage
        {
            get
            {
                return _availableProductsPage;
            }
        }
             public static NecessaryFoodPage NecessaryFoodPage
        {
            get
            {
                return _necessaryFoodPage;
            }

        }
        public static ShoppingListPage ShoppingListPage
        {
            get
            {
                return _shoppingListPage;
            }

        }
    }
}
