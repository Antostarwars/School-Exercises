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
                    accounts.Add(lines[2], new Account(lines[0], lines[1], lines[2], lines[3]));
                }
        }

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
                    sw.WriteLine($"{name},{surname},{username},{Encrypt(password)} :3");
                }
                return true;
            }

            return false;
        }

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
