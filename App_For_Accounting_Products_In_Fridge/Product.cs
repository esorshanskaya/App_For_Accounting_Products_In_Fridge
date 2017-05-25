using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_For_Accounting_Products_In_Fridge
{
    public class Product
    {
        DateTime thisDay = DateTime.Today;
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private double _amount;

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        

        private string _tradeMark;

        public string TradeMark
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
                return $"{_name} - {_tradeMark}  - {_dateOfProduction} - {_dateOfOpening} - {_expirationDate}";
            }
        }

        public string Info1
        {
            get
            {
                return $"{_name} '{_tradeMark}' {_amount} грамм";
            }
        }
        public string Info2
        {
            get
            {
                return $"{_name} {_tradeMark} {_amount} грамм, дата производства: {(_dateOfProduction.Date).ToString("d")}, дата вскрытия упаковки: {(_dateOfOpening.Date).ToString("d")}, годен до: {(_expirationDate.Date).ToString("d")}";
            }
        }
        public string Info3
        {
            get
            {
                return $"{_name} {_tradeMark} {_amount} грамм, срок годности истек {(_expirationDate.Date).ToString("d")}, просрочен на {thisDay.Subtract(_expirationDate).Days} дней";
            }
        }
        public string Info4
        {
            get
            {
                return $"{_name} {_tradeMark} {_amount} грамм, срок годности {(_expirationDate.Date).ToString("d")} истекает через {Math.Abs((thisDay.Subtract(_expirationDate)).Days)} дней";
            }
        }
        public string Info5
        {
            get
            {
                return $"{_name} {_tradeMark} {_amount} грамм, дата вскрытия упаковки {(_dateOfOpening.Date).ToString("d")} открыт {Math.Abs((thisDay.Subtract(_dateOfOpening)).Days) } дней назад";
            }
        }
        public string Info6
        {
            get
            {
                return $"{_name} '{_tradeMark}'";
            }
        }
        public Product(string name,string tradeMark, DateTime dateOfProduction, DateTime dateOfOpening, DateTime expirationDate)
        {
            _name = name;
            _tradeMark = tradeMark;
        
            _dateOfProduction =dateOfProduction;
            _dateOfOpening =dateOfOpening;
            _expirationDate = expirationDate;
            
        }
        public Product(string name)
        {
            _name = name;

        }


        public Product(string name, double amount,string tradeMark)
        {
            _name = name;
            _amount = amount;
            _tradeMark = tradeMark;
        }
        public Product(string name, double amount, string tradeMark,DateTime dateOfProduction,DateTime dateofOpening,DateTime expirationDate)
        {
            _name = name;
            _amount = amount;
            _tradeMark = tradeMark;
            _dateOfProduction = dateOfProduction;
            _dateOfOpening = dateofOpening;
            _expirationDate = expirationDate;
        }



    }
}
