using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManager
{
    class Account
    {
        private string name;
        private string surname;
        private string username;
        private string password;

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="surname">Surname of the user</param>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password of the user</param>
        public Account(string name, string surname, string username, string password)
        {
            this.name = name;
            this.surname = surname;
            this.username = username;
            this.password = password;
        }

        // Properties
        public string Name
        {
            get { return name; }
        }

        public string Surname
        {
            get { return surname; }
        }

        public string Username
        {
            get { return username; }
        }

        public string Password
        {
            get { return password; }
        }

    }
}
