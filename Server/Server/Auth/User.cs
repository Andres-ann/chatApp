using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Auth
{
    public class User
    {
        public string UserName { get; set; }

        public string Password { private get; set; } 
        public List<Role> Roles { get; set; }

        public bool IsValid(string password)
        {
            return Password.Equals(password);
        }

    }
}
