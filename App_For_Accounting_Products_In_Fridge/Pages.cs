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
        private static AvailableProductsListPage _availableProductsListPage = new AvailableProductsListPage();
        private static ShoppingListPage _shoppingListPage = new ShoppingListPage();
        private static ExpiringFoodPage _expiringFoodPage = new ExpiringFoodPage();
        private static ExpiredFoodPage _expiredFoodPage = new ExpiredFoodPage();
        private static AddShoppingList _addShoppingList = new AddShoppingList();
        private static AddNecessaryFoodListPage _addNecessaryFoodListPage = new AddNecessaryFoodListPage();
        private static AddAvailableProductsPage _addAvailableProductsPage = new AddAvailableProductsPage();



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
        public static ExpiringFoodPage ExpiringFoodPage
        {
            get
            {
                return _expiringFoodPage;
            }

        }
        public static ExpiredFoodPage ExpiredFoodPage
        {
            get
            {
                return _expiredFoodPage;
            }

        }

        public static AvailableProductsListPage AvailableProductsListPage
        {
            get
            {
                return _availableProductsListPage;
            }

        } 
        public static AddShoppingList AddShoppingList
        {
            get
            {
                return _addShoppingList;
            }

        }
        public static AddNecessaryFoodListPage AddNecessaryFoodListPage
        {
            get
            {
                return _addNecessaryFoodListPage;
            }

        }
        public static AddAvailableProductsPage AddAvailableProductsPage
        {
            get
            {
                return _addAvailableProductsPage;
            }

        }
    }
}
