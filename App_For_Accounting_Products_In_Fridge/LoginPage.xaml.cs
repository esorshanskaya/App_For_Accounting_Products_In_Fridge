using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    { bool flag;
        static string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        IO userListFileInput = new IO(path, "userFile.txt");

        List<Users> _usersList = new List<Users>();
        public LoginPage()
        {
            InitializeComponent();
            InputUserList();
            textBoxLogin.Focus();
        }
        private void InputUserList()
        {
            _usersList = userListFileInput.ReadUsersList();



        }
        public void NewUserAdded(Users _newUser)
        {
            _usersList.Add(_newUser);

        }
        

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {



            foreach (Users item in _usersList)
            {

                if (textBoxLogin.Text.Equals(item.Login) && passwordBox.Text.Equals(item.Password))
                { flag = true; }



                else
                { flag = false; }
            }
                if (flag == false)
                { MessageBox.Show("Неправильный логин или пароль"); }
            
            if (flag == true)
         {
                Pages.NecessaryFoodPage.Login(textBoxLogin.Text);
                NavigationService.Navigate(Pages.StartingPage);}
        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
          
            if (e.Key == Key.Enter)
                buttonLogin_Click(null, null);
        }
    }
}
