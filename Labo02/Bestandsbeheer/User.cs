using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestandsbeheer
{
    public class User
    {
        private string username;
        private bool isAdmin;

        public User(string username, bool isAdmin)
        {
            this.username = username;
            this.isAdmin = isAdmin;
        }

        public string Username { get => username; }
        public bool IsAdmin { get => isAdmin; }
    }

}
