using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManager
{
    class AccountManager
    {
        private string path = "../../../../accounts.txt";
        private Dictionary<string, Account> accounts = new Dictionary<string, Account>(); // File format is name,surname,username,password

        public AccountManager()
        {
            // Read accounts from file
            using (StreamReader sr = new StreamReader(path))

                while (!sr.EndOfStream)
                {
                    var lines = sr.ReadLine().Split(',');
                    accounts.Add(lines[2], new Account(lines[0], lines[1], lines[2], lines[3])); // Add account to dictionary
                }
        }

        /// <summary>
        /// Check if account exists and password is correct, then login
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>True if logged in otherwise false</returns>
        public bool Login(string username, string password)
        {
            // Check if account exists and password is correct
            if (accounts.ContainsKey(username))
            {
                if (accounts[username].Password == Encrypt(password))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Register a new account
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="surname">Surname of the user</param>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>True if registered otherwise false</returns>
        public bool Register(string name, string surname, string username, string password)
        {
            // Check if username already exists
            if (!accounts.ContainsKey(username))
            {
                // Add account to dictionary and file
                accounts.Add(username, new Account(name, surname, username, Encrypt(password)));
                using (StreamWriter sw = new StreamWriter(path, true)) // true to append
                {
                    // Write new account
                    sw.WriteLine($"{name},{surname},{username},{Encrypt(password)}");
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// delete and account
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>True if deleted, otherwise false</returns>
        public bool deleteAccount(string username, string password)
        {
            // Check if account exists and password is correct
            if (accounts.ContainsKey(username))
            {
                // Remove account from dictionary and file
                if (accounts[username].Password == Encrypt(password))
                {
                    accounts.Remove(username);
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        // Write all accounts except the one to delete
                        foreach (var account in accounts)
                        {
                            sw.WriteLine($"{account.Value.Name},{account.Value.Surname},{account.Value.Username},{account.Value.Password}");
                        }
                    }
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Encrypt password using Base64
        /// </summary>
        /// <param name="password">Password to encrypt</param>
        /// <returns>Encrypted Password</returns>
        private string Encrypt(string password)
        {
                // Encrypt password
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
        }
    }
}
