using System;
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
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        static string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        IO userListFileOutput = new IO(path, "userFile.txt");
        IO userListFileInput = new IO(path, "userFile.txt");
        List<Users> usersList = new List<Users>();
        bool flag;
        string password;
        string repeatedPassword;
        string login;
        Users newUser;
        public RegistrationPage()
        {
            InitializeComponent();
            InputUserList();
            OutputUserList();
        }
        private void InputUserList()
        {
            usersList = userListFileInput.ReadUsersList();



        }
        public void OutputUserList()
        {
            userListFileOutput.WriteUserList(usersList);

        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            InputUserList();
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {

                MessageBox.Show("Введите Логин");
                LoginTextBox.Focus();
                return;
            }
            login = LoginTextBox.Text;
            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {

                MessageBox.Show("Необходимо ввести пароль");
               PasswordTextBox.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(RepeatingPasswordTextBox.Text))
            {
                MessageBox.Show("Необходимо повторить пароль");
                RepeatingPasswordTextBox.Focus();
                return;
            }
            password = PasswordTextBox.Text;
            repeatedPassword = RepeatingPasswordTextBox.Text;
            if (!(password==repeatedPassword))
            {
                MessageBox.Show("Пароли не совпадают");
                RepeatingPasswordTextBox.Focus();
            }
            foreach (Users item in usersList)
            {
                if (login==item.Login)
                    {
                    flag = false;
                    MessageBox.Show("Такой пользователь уже зарегистрирован"); }
                else
                { flag = true; }

            }
           
                newUser = new Users(LoginTextBox.Text, PasswordTextBox.Text);
                Pages.LoginPage.NewUserAdded(newUser);
            usersList.Add(newUser);
                OutputUserList();
                NavigationService.GoBack();
            }
            
        
        }
    }

