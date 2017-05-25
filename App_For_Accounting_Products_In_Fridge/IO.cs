using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace App_For_Accounting_Products_In_Fridge
{
    class IO
    {

        private string path;
        private string filename;
   

        public IO(string path, string filename)
        {
            this.filename = filename;
            this.path = path;
        }
      
        private void checkIfExists()
        {
            if (!Directory.Exists(path))
                createDirectory();
            if (!File.Exists(path + filename))
                createFile();
        }




        private void createDirectory()
        {
            Directory.CreateDirectory(path);
        }


        private void createFile()
        {
            FileStream fs = new FileStream(path + filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("");

            sw.Close();
            fs.Close();
        }

       



        private void createDirectory1()
        {
            Directory.CreateDirectory(path);
        }


       


        public void WriteShoppingListAndNecessaryProductsList(List<Product> listOfProducts)

        {
            checkIfExists();
            FileStream fs = new FileStream(path + filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach (Product item in listOfProducts)
                sw.WriteLine("{0},{1},{2}", item.Name, item.Amount, item.TradeMark);
            sw.Close();
            fs.Close();
        }


        public void WriteUserList(List<Users> listOfUsers)

        {
            checkIfExists();
            FileStream fs = new FileStream(path + filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach (Users item in listOfUsers)
            { sw.WriteLine("{0},{1}", item.Login, item.Password); }
            sw.Close();
            fs.Close();
        }


        public void WriteAvailableProductsList(List<Product> listOfProducts)

        {
            checkIfExists();
            FileStream fs = new FileStream(path + filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach (Product item in listOfProducts)
                sw.WriteLine("{0},{1},{2},{3},{4},{5}", item.Name, item.Amount, item.TradeMark, item.DateOfProduction, item.DateOfOpening, item.expirationDate);
            sw.Close();
            fs.Close();
        }
        public List<Product> ReadShoppingListAndNecessaryProductsList()
        {
            checkIfExists();
            FileStream fs = new FileStream(path + filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            List<Product> listOfProducts = new List<Product>();
            while (!sr.EndOfStream)

            {
                string[] temp = sr.ReadLine().Split(',');
                Product productFromFile = new Product(temp[0], double.Parse(temp[1]), temp[2]);
                listOfProducts.Add(productFromFile);

            }
            sr.Close();
            fs.Close();
            return listOfProducts;
        }

        public List<Users> ReadUsersList()
        {
            checkIfExists();
            FileStream fs = new FileStream(path + filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            List<Users> usersList = new List<Users>();
            while (!sr.EndOfStream)

            {
                string[] temp = sr.ReadLine().Split(',');
                Users userFromFile = new Users(temp[0], temp[1]);
                usersList.Add(userFromFile);

            }
            sr.Close();
            fs.Close();
            return usersList;
        }

        public List<Product> ReadAvailableProductsList()
        {
            checkIfExists();
            FileStream fs = new FileStream(path + filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            List<Product> listOfProducts = new List<Product>();
            while (!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine().Split(',');
                Product productFromFile = new Product(temp[0], double.Parse(temp[1]), temp[2], DateTime.Parse(temp[3]), DateTime.Parse(temp[4]), DateTime.Parse(temp[5]));
                listOfProducts.Add(productFromFile);
            }
            sr.Close();
            fs.Close();
            return listOfProducts;
        }
    }
}

