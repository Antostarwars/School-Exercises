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

        // TODO: AGGIUNGERE I COMMENTI CHE VUOLE IL PROF
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
