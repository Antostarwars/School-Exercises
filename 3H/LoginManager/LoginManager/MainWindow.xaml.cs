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

namespace LoginManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccountManager accountManager = new AccountManager(); // Create account manager

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitLogin_Click(object sender, RoutedEventArgs e)
        {
            // Check if username and password are correct
            if (!accountManager.Login(UsernameBox.Text, PasswordBox.Password)) 
                // Show error message
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else 
                // Show success message
                MessageBox.Show("Login successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SubmitRegister_Click(object sender, RoutedEventArgs e)
        {
            // Check if all fields are filled
            if (NameRegister.Text == "" || SurnameRegister.Text == "" || UsernameRegister.Text == "" || PasswordRegister.Password == "")
                // Show error message
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            // Check if passwords match
            else if (PasswordRegister.Password != ConfirmPasswordRegister.Password)
                // Show error message
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                // Register account
                if (accountManager.Register(NameRegister.Text, SurnameRegister.Text, UsernameRegister.Text, PasswordRegister.Password))
                    // Show success message
                    MessageBox.Show("Registration successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    // Show error message
                    MessageBox.Show("Username already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void SubmitDelete_Click(object sender, RoutedEventArgs e)
        {
            // Check if all fields are filled
            if (UsernameDelete.Text == "" || PasswordDelete.Password == "")
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                // Delete account
                if (accountManager.deleteAccount(UsernameDelete.Text, PasswordDelete.Password))
                    MessageBox.Show("Account deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
