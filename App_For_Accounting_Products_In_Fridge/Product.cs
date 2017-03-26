using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_For_Accounting_Products_In_Fridge
{
    class Product
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private TypeOfProduct _typeOfProduct;

        public TypeOfProduct TypeOfProduct
        {
            get { return _typeOfProduct; }
            set { _typeOfProduct = value; }
        }

        private TradeMark _tradeMark;

        public TradeMark TradeMark
        {
            get { return _tradeMark; }
            set { _tradeMark = value; }
        }

        private DateTime _dateOfProduction;

        public DateTime DateOfProduction
        {
            get { return _dateOfProduction; }
            set { _dateOfProduction = value; }
        }
        private DateTime _dateOfOpening;

        public DateTime DateOfOpening
        {
            get { return _dateOfOpening; }
            set { _dateOfOpening = value; }
        }
        private DateTime _expirationDate;

        public DateTime expirationDate
        {
            get { return _expirationDate; }
            set { _expirationDate = value; }
        }
        

        public string Info
        {
            get
            {
                return $"{_name} - {_tradeMark} - {_typeOfProduct} - {_dateOfProduction} - {_dateOfOpening} - {_expirationDate}";
            }
        }
        public Product(string name,TradeMark tradeMark, TypeOfProduct typeOfProduct, DateTime dateOfProduction, DateTime dateOfOpening, DateTime expirationDate)
        {
            _name = name;
            _tradeMark = tradeMark;
            _typeOfProduct = typeOfProduct;
            _dateOfProduction =dateOfProduction;
            _dateOfOpening =dateOfOpening;
            _expirationDate = expirationDate;
            
        }
        public Product(string name)
        {
            _name = name;

        }

    }
}
