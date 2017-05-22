using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_For_Accounting_Products_In_Fridge
{
    public class TypeOfProduct
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _standartExpirationDate;

        public int standartExpirationDate
        {
            get { return _standartExpirationDate; }
            set { _standartExpirationDate = value; }
        }


    }
}
