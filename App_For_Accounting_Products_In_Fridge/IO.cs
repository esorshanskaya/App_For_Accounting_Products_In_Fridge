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

        public IO(string path, string filename)//конструктор для присваивания значений пути и имени файла
        {
            this.filename = filename;
            this.path = path;
        }

        private void checkIfExists()// Метод для проверки существования пути к файлу и самого файла
        {
            if (!Directory.Exists(path))// если такой путь к файлу не существует:
                createDirectory();//используем метод для создания такого пути к файлу
            if (!File.Exists(path + filename))// если не существует данного файла с данным путем:
                createFile();// используем метод для создания файла с заданным путем
        }




        private void createDirectory()//метод для создания направления
        {
            Directory.CreateDirectory(path);
        }


        private void createFile()//метод для создания файла
        {
            FileStream fs = new FileStream(path + filename, FileMode.Create, FileAccess.Write);// открываем поток для работы с файлом, создаем сам файл
            StreamWriter sw = new StreamWriter(fs);// открываем поток для записи данных в файл
            Console.WriteLine("");

            sw.Close();// закрываем поток для записи в файл
            fs.Close();//закрываем поток для работы с файлом
        }




        public void WriteShoppingListAndNecessaryProductsList(List<Product> listOfProducts)//метод для записи данных из "Список покупок" и "Необходимые продукты" в файл 

        {   checkIfExists();// вызываем метод для проверки существования пути к файлу и самого файла.При необходимости метод создает недостающий элемент
            FileStream fs = new FileStream(path + filename, FileMode.Create, FileAccess.Write);// открываем поток для работы с файлом.доступ к файлу-запись
            StreamWriter sw = new StreamWriter(fs);// открываем поток для записи в файл
            foreach (Product item in listOfProducts)// цикл для прохода по всем продуктам в листе
                sw.WriteLine("{0},{1},{2}", item.Name, item.Amount,item.TradeMark);// записываем в файл характеристики 
            sw.Close();//закрываем поток для записи в файл
            fs.Close();//закрываем поток для работы с файлом
        }




        public void WriteAvailableProductsList(List<Product> listOfProducts)//метод для записи данных из "Продукты в холодильнике" в файл 

        {
            checkIfExists();// вызываем метод для проверки существования пути к файлу и самого файла.При необходимости метод создает недостающий элемент
            FileStream fs = new FileStream(path + filename, FileMode.Create, FileAccess.Write);// открываем поток для работы с файлом.доступ к файлу-запись
            StreamWriter sw = new StreamWriter(fs);// открываем поток для записи в файл
            foreach (Product item in listOfProducts)// цикл для прохода по всем продуктам в листе
                sw.WriteLine("{0},{1},{2},{3},{4},{5}", item.Name, item.Amount, item.TradeMark,item.DateOfProduction,item.DateOfOpening,item.expirationDate);// записываем в файл характеристики 
            sw.Close();//закрываем поток для записи в файл
            fs.Close();//закрываем поток для работы с файлом
        }
        public List<Product> ReadShoppingListAndNecessaryProductsList()// метод для чтения данных из файла с возвращаемым значением(листом) для "Список покупок" и "Необходимые продукты"
        {
            checkIfExists();// вызываем метод для проверки существования пути к файлу и самого файла.При необходимости метод создает недостающий элемент
            FileStream fs = new FileStream(path + filename, FileMode.Open, FileAccess.Read);// открываем поток для работы с файлом.доступ к файлу-чтение
            StreamReader sr = new StreamReader(fs);// открываем поток для чтения файла
            List<Product> listOfProducts = new List<Product>();// создаем лист, чтобы добавлять туда экземпляры класса Продукт из файла
            while (!sr.EndOfStream)// пока не закончится файл
      
               { string[] temp = sr.ReadLine().Split(',');// создаем одномерный массив, куда помещаются разделенные(по каждой запятой) данные из файла.
                Product productFromFile = new Product(temp[0], double.Parse(temp[1]),temp[2]);// создаем новый экземпляр продукта, вызывая конструктор и присваивая значения из массива
                listOfProducts.Add(productFromFile);// добавляем в лист
           
            }
            sr.Close();//закрываем поток для записи в файл
            fs.Close();//закрываем поток для работы с файлом
            return listOfProducts;// возвращаем лист с продуктами
        }
       
        public List<Product> ReadAvailableProductsList()// метод для чтения данных из файла с возвращаемым значением(листом) для"Продукты в холодильнике"
        {
            checkIfExists();// вызываем метод для проверки существования пути к файлу и самого файла.При необходимости метод создает недостающий элемент
            FileStream fs = new FileStream(path + filename, FileMode.Open, FileAccess.Read);// открываем поток для работы с файлом.доступ к файлу-чтение
            StreamReader sr = new StreamReader(fs);// открываем поток для чтения файла
            List<Product> listOfProducts = new List<Product>();// создаем лист, чтобы добавлять туда экземпляры класса Продукт из файла
            while (!sr.EndOfStream)// пока не закончится файл
            {
                string[] temp = sr.ReadLine().Split(',');// создаем одномерный массив, куда помещаются разделенные(по каждой запятой) данные из файла.
                Product productFromFile = new Product(temp[0], double.Parse(temp[1]), temp[2],DateTime.Parse(temp[3]), DateTime.Parse(temp[4]), DateTime.Parse(temp[5]));// создаем новый экземпляр продукта, вызывая конструктор и присваивая значения из массива
                listOfProducts.Add(productFromFile);// добавляем в лист
            }
            sr.Close();//закрываем поток для записи в файл
            fs.Close();//закрываем поток для работы с файлом
            return listOfProducts;// возвращаем лист с продуктами
        }
    }
}

